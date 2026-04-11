using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests generated according to the W3C-Test.org page:
/// http://www.w3c-test.org/html/semantics/forms/constraints/form-validation-validity-tooShort.html
/// </summary>

public class ValidityTooShortTests
{
    [Fact]
    public void TestTooshortInputText1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputText9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("text", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputSearch9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("search", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputTel9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("tel", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputUrl9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("url", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputEmail9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("email", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "AAAAA";
        element.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortInputPassword9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.Equal("password", element.Type);
        Assert.True(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea1()
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
        element.SetAttribute("minLength", "");
        element.Value = "abc";
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea2()
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
        element.SetAttribute("minLength", "4");
        element.Value = "";
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea3()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea4()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea5()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea6()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcde";
        element.IsDirty = true;
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea7()
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
        element.SetAttribute("minLength", "4");
        element.Value = "\r\n\r\n\r\n";
        element.IsDirty = true;
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea8()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abcd";
        element.IsDirty = true;
        Assert.False(element.Validity.IsTooShort);
    }

    [Fact]
    public void TestTooshortTextarea9()
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
        element.SetAttribute("minLength", "4");
        element.Value = "abc";
        element.IsDirty = true;
        Assert.True(element.Validity.IsTooShort);
    }
}
