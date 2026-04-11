using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class ValidationTests
{
    [Fact]
    public void BasicInvalidFormValidation()
    {
        var doc = (@"<form id=""fm1"">
  <fieldset id=""test0"">
    <input type=""text"" required value="""" id=""test1"">
  </fieldset>
  <input type=""email"" value=""abc"" id=""test2"">
  <button id=""test3"">TEST</button>
  <select id=""test4""></select>
  <textarea id=""test5""></textarea>
  <output id=""test6""></output>
</form>").ToHtmlDocument();
        Assert.Single(doc.Forms);
        var form = doc.Forms[0];
        Assert.IsAssignableFrom<IHtmlFormElement>(form);
        Assert.False(form.CheckValidity());
    }

    [Fact]
    public void BasicValidFormValidation()
    {
        var doc = (@"<form id=""fm2"">
  <fieldset>
    <input type=""text"" required value=""abc"">
  </fieldset>
  <input type=""email"" value=""test@example.com"">
  <button>TEST</button>
  <select></select>
  <textarea></textarea>
  <output></output>
</form>").ToHtmlDocument();
        Assert.Single(doc.Forms);
        var form = doc.Forms[0];
        Assert.IsAssignableFrom<IHtmlFormElement>(form);
        Assert.True(form.CheckValidity());
    }

    [Fact]
    public void InvalidFormValidationWithChanges()
    {
        var doc = (@"<form id=""fm3"">
  <fieldset id=""fs"">
    <legend><input type=""text"" id=""inp1""></legend>
    <input type=""text"" required value="""" id=""inp2"">
  </fieldset>
</form>").ToHtmlDocument();
        Assert.Single(doc.Forms);
        var form = doc.Forms[0];
        Assert.IsAssignableFrom<IHtmlFormElement>(form);
        Assert.False(form.CheckValidity());
        var fieldSet = doc.GetElementById("fs") as IHtmlFieldSetElement;
        Assert.NotNull(fieldSet);
        fieldSet.IsDisabled = true;
        Assert.True(form.CheckValidity());
        var input = doc.GetElementById("inp1") as IHtmlInputElement;
        Assert.NotNull(input);
        input.Value = "aaa";
        input.Type = "url";
        Assert.False(form.CheckValidity());
    }

    [Fact]
    public void TestCustomErrorInput1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.SetCustomValidity("My custom error");
        Assert.True(element.Validity.IsCustomError);
        Assert.Equal("My custom error", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorInput2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.SetCustomValidity("");
        Assert.False(element.Validity.IsCustomError);
        Assert.Equal("", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorButton1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.SetCustomValidity("My custom error");
        Assert.True(element.Validity.IsCustomError);
        Assert.Equal("My custom error", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorButton2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.SetCustomValidity("");
        Assert.False(element.Validity.IsCustomError);
        Assert.Equal("", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorSelect1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("select") as HtmlSelectElement;
        Assert.NotNull(element);
        var option1 = document.CreateElement<IHtmlOptionElement>();
        option1.Text = "test1";
        option1.Value = "";
        var option2 = document.CreateElement<IHtmlOptionElement>();
        option2.Text = "test1";
        option2.Value = "1";
        element.AddOption(option1);
        element.AddOption(option2);
        element.SetCustomValidity("My custom error");
        Assert.True(element.Validity.IsCustomError);
        Assert.Equal("My custom error", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorSelect2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("select") as HtmlSelectElement;
        Assert.NotNull(element);
        var option1 = document.CreateElement<IHtmlOptionElement>();
        option1.Text = "test1";
        option1.Value = "";
        var option2 = document.CreateElement<IHtmlOptionElement>();
        option2.Text = "test1";
        option2.Value = "1";
        element.AddOption(option1);
        element.AddOption(option2);
        element.SetCustomValidity("");
        Assert.False(element.Validity.IsCustomError);
        Assert.Equal("", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorTextarea1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("textarea") as HtmlTextAreaElement;
        Assert.NotNull(element);
        element.SetCustomValidity("My custom error");
        Assert.True(element.Validity.IsCustomError);
        Assert.Equal("My custom error", element.ValidationMessage);
    }

    [Fact]
    public void TestCustomErrorTextarea2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("textarea") as HtmlTextAreaElement;
        Assert.NotNull(element);
        element.SetCustomValidity("");
        Assert.False(element.Validity.IsCustomError);
        Assert.Equal("", element.ValidationMessage);
    }

    [Fact]
    public void TestTypemismatchInputEmail1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "test@example.com";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("value", @"
     test@example.com
    ");
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("email", element.Type);
        Assert.True(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail5()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "test1@example.com,test2@example.com";
        Assert.Equal("email", element.Type);
        Assert.True(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail6()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", "multiple");
        element.Value = "test1@example.com,test2@example.com";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputEmail7()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", "multiple");
        element.Value = "test1@example.com;test2@example.com";
        Assert.Equal("email", element.Type);
        Assert.True(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputUrl1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputUrl2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "http://www.example.com";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputUrl3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("value", @"
     http://www.example.com 
     ");
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestTypemismatchInputUrl4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("url", element.Type);
        Assert.True(element.Validity.IsTypeMismatch);
    }

    [Fact]
    public void TestBadinputInputEmail1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", null);
        element.Value = "";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputEmail2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", null);
        element.Value = "test1@example.com";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputEmail3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", "multiple");
        element.Value = "test1@example.com,test2@eample.com";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputEmail4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("multiple", "multiple");
        element.Value = "test,1@example.com";
        Assert.Equal("email", element.Type);
        Assert.True(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputDatetime1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputDatetime2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputDatetime3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputColor1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "color";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "";
        Assert.Equal("color", element.Type);
        Assert.True(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputColor2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "color";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "#000000";
        Assert.Equal("color", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputColor3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "color";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "#FFFFFF";
        Assert.Equal("color", element.Type);
        Assert.False(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestBadinputInputColor4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "color";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("color", element.Type);
        Assert.True(element.Validity.IsBadInput);
    }

    [Fact]
    public void TestIsvalidInputText1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "text";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "4");
        element.Value = "abcdef";
        element.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputText2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "text";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "[A-Z]");
        element.Value = "abc";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputText3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "text";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputSearch1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "search";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "4");
        element.Value = "abcdef";
        element.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputSearch2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "search";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "[A-Z]");
        element.Value = "abc";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputSearch3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "search";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTel1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "tel";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "4");
        element.Value = "abcdef";
        element.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTel2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "tel";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "[A-Z]");
        element.Value = "abc";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTel3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "tel";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputPassword1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "password";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "4");
        element.Value = "abcdef";
        element.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputPassword2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "password";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "[A-Z]");
        element.Value = "abc";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputPassword3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "password";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputUrl1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "20");
        element.Value = "http://www.example.com";
        element.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputUrl2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "http://www.example.com");
        element.Value = "http://www.example.net";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputUrl3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputUrl4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "url";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputEmail1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("maxLength", "10");
        element.Value = "test@example.com";
        element.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputEmail2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("pattern", "test@example.com");
        element.Value = "test@example.net";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputEmail3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.Value = "abc";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputEmail4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "email";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDatetime1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "2000-01-01T12:00:00Z");
        element.Value = "2001-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDatetime2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "2001-01-01T12:00:00Z");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDatetime3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "120");
        element.Value = "2001-01-01T12:03:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDatetime4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "datetime";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDate1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "date";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "2000-01-01");
        element.Value = "2001-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDate2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "date";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "2001-01-01");
        element.Value = "2000-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDate3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "date";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "3");
        element.Value = "2000-01-03";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputDate4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "date";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputMonth1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "month";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "2000-01");
        element.Value = "2001-01";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputMonth2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "month";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "2001-01");
        element.Value = "2000-01";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputMonth3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "month";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "3");
        element.Value = "2001-03";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputMonth4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "month";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputWeek1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "week";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "2000-W01");
        element.Value = "2001-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputWeek2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "week";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "2001-W01");
        element.Value = "2000-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputWeek3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "week";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "2");
        element.Value = "2001-W03";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputWeek4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "week";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTime1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "time";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "12:00:00");
        element.Value = "13:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTime2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "time";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "12:00:00");
        element.Value = "11:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTime3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "time";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "120");
        element.Value = "12:03:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputTime4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "time";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputNumber1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "number";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("max", "5");
        element.Value = "6";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputNumber2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "number";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("min", "5");
        element.Value = "4";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputNumber3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "number";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("step", "2");
        element.Value = "3";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputNumber4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "number";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputCheckbox1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "checkbox";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.SetAttribute("checked", null);
        element.SetAttribute("name", "test1");
        Assert.Equal("checkbox", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputRadio1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "radio";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.SetAttribute("checked", null);
        element.SetAttribute("name", "test1");
        Assert.Equal("radio", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidInputFile1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "file";
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        Assert.Equal("file", element.Type);
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidSelect1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("select") as HtmlSelectElement;
        Assert.NotNull(element);
        var option1 = document.CreateElement<IHtmlOptionElement>();
        option1.Text = "test1";
        option1.Value = "";
        var option2 = document.CreateElement<IHtmlOptionElement>();
        option2.Text = "test1";
        option2.Value = "1";
        element.AddOption(option1);
        element.AddOption(option2);
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.False(element.Validity.IsValid);
    }

    [Fact]
    public void TestIsvalidTextarea1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("textarea") as HtmlTextAreaElement;
        Assert.NotNull(element);
        element.RemoveAttribute("required");
        element.RemoveAttribute("pattern");
        element.RemoveAttribute("step");
        element.RemoveAttribute("max");
        element.RemoveAttribute("min");
        element.RemoveAttribute("maxlength");
        element.RemoveAttribute("value");
        element.RemoveAttribute("multiple");
        element.RemoveAttribute("checked");
        element.RemoveAttribute("selected");
        element.SetAttribute("required", "required");
        element.Value = "";
        Assert.False(element.Validity.IsValid);
    }
}
