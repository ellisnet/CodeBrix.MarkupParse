using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests generated according to the W3C-Test.org page:
/// http://www.w3c-test.org/html/semantics/forms/constraints/form-validation-checkValidity.html
/// </summary>

public class ValidityCheckTests
{
    [Fact]
    public void GetSubmissionReturnsNullWithInvalidForm()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "text";
        element.SetAttribute("maxLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        var fm = document.CreateElement("form") as IHtmlFormElement;
        Assert.NotNull(fm);
        fm.AppendChild(element);
        document.Body.AppendChild(fm);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
        Assert.Null(fm.GetSubmission(element));
    }

    [Fact]
    public void TestCheckvalidityInputText1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("text", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputText2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputText3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("text", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputText4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("text", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputSearch1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("search", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputSearch2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputSearch3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("search", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputSearch4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("search", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTel1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("tel", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTel2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTel3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("tel", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTel4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("tel", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputPassword1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("password", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputPassword2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputPassword3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("password", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputPassword4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("password", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputUrl1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("url", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputUrl2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputUrl3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("url", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputUrl4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("url", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputUrl5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("url", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputEmail1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("email", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputEmail2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true) as HtmlInputElement;
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        element2.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputEmail3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("email", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputEmail4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("email", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputEmail5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("email", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDatetime1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("datetime", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDatetime2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("datetime", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDatetime3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("datetime", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDatetime4()
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
        element.SetAttribute("step", "120000");
        element.Value = "2001-01-01T12:03:00Z";
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("datetime", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDatetime5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("datetime", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDate1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("date", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDate2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("date", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDate3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("date", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDate4()
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
        element.SetAttribute("step", "172800000");
        element.Value = "2001-01-03";
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("date", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputDate5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("date", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputMonth1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("month", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputMonth2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("month", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputMonth3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("month", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputMonth4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("month", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputMonth5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("month", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputWeek1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("week", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputWeek2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("week", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputWeek3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("week", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputWeek4()
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
        element.SetAttribute("step", "1209600000");
        element.Value = "2001-W03";
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("week", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputWeek5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("week", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTime1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("time", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTime2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("time", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTime3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("time", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTime4()
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
        element.SetAttribute("step", "120000");
        element.Value = "12:03:00";
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("time", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputTime5()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("time", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputNumber1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("number", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputNumber2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("number", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputNumber3()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("number", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputNumber4()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("number", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputCheckbox1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("checkbox", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputCheckbox2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("checkbox", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputRadio1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("radio", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputRadio2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("radio", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputFile1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("file", element.Type);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityInputFile2()
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
        element.SetAttribute("files", "null");
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.Equal("file", element.Type);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvaliditySelect1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvaliditySelect2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityTextarea1()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.True(element.CheckValidity());
        Assert.True(fm.CheckValidity());
    }

    [Fact]
    public void TestCheckvalidityTextarea2()
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
        var fm = document.CreateElement("form") as IHtmlFormElement;
        var element2 = element.Clone(true);
        fm.AppendChild(element2);
        document.Body.AppendChild(fm);
        Assert.False(element.CheckValidity());
        Assert.False(fm.CheckValidity());
    }
}
