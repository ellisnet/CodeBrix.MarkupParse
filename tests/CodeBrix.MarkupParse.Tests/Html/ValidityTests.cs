using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests generated according to the W3C-Test.org page:
/// http://www.w3c-test.org/html/semantics/forms/constraints/form-validation-willValidate.html
/// </summary>

public class ValidityTests
{
    [Fact]
    public void TestWillvalidateInputHidden1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "hidden";
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
        Assert.Equal("hidden", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputButton1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "button";
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
        Assert.Equal("button", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputReset1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "reset";
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
        Assert.Equal("reset", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateButtonButton1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.Type = "button";
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
        Assert.Equal("button", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateButtonReset1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.Type = "reset";
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
        Assert.Equal("reset", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateFieldset1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("fieldset") as HtmlFieldSetElement;
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
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateOutput1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("output") as HtmlOutputElement;
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
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateObject1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("object") as HtmlObjectElement;
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
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateKeygen1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("keygen") as HtmlKeygenElement;
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
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputText1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("text", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputText2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("text", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputText3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("text", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputText4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("text", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSearch1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("search", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSearch2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("search", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSearch3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("search", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSearch4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("search", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTel1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("tel", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTel2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("tel", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTel3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("tel", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTel4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("tel", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputUrl1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("url", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputUrl2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("url", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputUrl3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("url", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputUrl4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("url", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputEmail1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("email", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputEmail2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("email", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputEmail3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("email", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputEmail4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("email", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputPassword1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("password", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputPassword2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("password", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputPassword3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("password", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputPassword4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("password", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDatetime1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("datetime", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDatetime2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("datetime", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDatetime3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("datetime", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDatetime4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("datetime", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDate1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("date", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDate2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("date", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDate3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("date", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputDate4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("date", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputMonth1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("month", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputMonth2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("month", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputMonth3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("month", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputMonth4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("month", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputWeek1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("week", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputWeek2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("week", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputWeek3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("week", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputWeek4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("week", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTime1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("time", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTime2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("time", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTime3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("time", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputTime4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("time", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputColor1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("color", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputColor2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("color", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputColor3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("color", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputColor4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("color", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputFile1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("file", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputFile2()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("file", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputFile3()
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("file", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputFile4()
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("file", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSubmit1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("submit", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSubmit2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        Assert.Equal("submit", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSubmit3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("readOnly", "readOnly");
        Assert.Equal("submit", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateInputSubmit4()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("input") as HtmlInputElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", null);
        element.SetAttribute("readOnly", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("submit", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateButtonSubmit1()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", "disabled");
        Assert.Equal("submit", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateButtonSubmit2()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", null);
        Assert.Equal("submit", element.Type);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateButtonSubmit3()
    {
        var document = ("").ToHtmlDocument();
        var element = document.CreateElement("button") as HtmlButtonElement;
        Assert.NotNull(element);
        element.Type = "submit";
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
        element.SetAttribute("disabled", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.Equal("submit", element.Type);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateSelect1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateSelect2()
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
        element.SetAttribute("disabled", null);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateSelect3()
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
        element.SetAttribute("disabled", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateTextarea1()
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
        element.SetAttribute("disabled", "disabled");
        Assert.False(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateTextarea2()
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
        element.SetAttribute("disabled", null);
        Assert.True(element.WillValidate);
    }

    [Fact]
    public void TestWillvalidateTextarea3()
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
        element.SetAttribute("disabled", null);
        var dl = document.CreateElement("datalist");
        dl.AppendChild(element);
        Assert.False(element.WillValidate);
    }
}
