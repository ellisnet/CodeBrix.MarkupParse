using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests generated according to the W3C-Test.org page:
/// http://www.w3c-test.org/html/semantics/forms/constraints/form-validation-validity-valueMissing.html
/// </summary>

public class ValidityValueMissingTests
{
    [Fact]
    public void TestValuemissingInputText1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputText2()
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
        element.Value = "abc";
        Assert.Equal("text", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputText3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputSearch1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputSearch2()
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
        element.Value = "abc";
        Assert.Equal("search", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputSearch3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTel1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTel2()
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
        element.Value = "abc";
        Assert.Equal("tel", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTel3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputUrl1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputUrl2()
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
        element.Value = "abc";
        Assert.Equal("url", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputUrl3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputEmail1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputEmail2()
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
        element.Value = "abc";
        Assert.Equal("email", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputEmail3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputPassword1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputPassword2()
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
        element.Value = "abc";
        Assert.Equal("password", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputPassword3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime2()
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
        element.Value = "2000-12-10T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime3()
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
        element.Value = "2000-12-10 12:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime4()
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
        element.Value = "1979-10-14T12:00:00.001-04:00";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime5()
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
        element.Value = "8592-01-01T02:09+02:09";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime6()
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
        element.Value = "1234567";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime7()
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
        element.Value = "2015-01-01T14:11:21.695Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime8()
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
        element.Value = "1979-10-99 99:99Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime9()
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
        element.Value = "1979-10-14 12:00:00";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime10()
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
        element.Value = "2001-12-21  12:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime11()
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
        element.Value = "abc";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDatetime12()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate2()
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
        element.Value = "2000-12-10";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate3()
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
        element.Value = "9999-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate4()
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
        element.Value = "1234567";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate5()
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
        element.Value = "2015-01-01T14:11:21.695Z";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate6()
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
        element.Value = "9999-99-99";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate7()
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
        element.Value = "37/01/01";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate8()
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
        element.Value = "2000/01/01";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputDate9()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth2()
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
        element.Value = "2000-12";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth3()
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
        element.Value = "9999-01";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth4()
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
        element.Value = "1234567";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth5()
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
        element.Value = "2015-01-01T14:11:21.695Z";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth6()
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
        element.Value = "2000-99";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth7()
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
        element.Value = "37-01";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth8()
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
        element.Value = "2000/01";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputMonth9()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek2()
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
        element.Value = "2000-W12";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek3()
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
        element.Value = "9999-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek4()
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
        element.Value = "1234567";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek5()
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
        element.Value = "2015-01-01T14:11:21.695Z";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek6()
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
        element.Value = "2000-W99";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek7()
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
        element.Value = "2000-W00";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek8()
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
        element.Value = "2000-w01";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputWeek9()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime2()
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
        element.Value = "12:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime3()
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
        element.Value = "12:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime4()
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
        element.Value = "12:00:00.001";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime5()
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
        element.Value = "12:00:00.01";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime6()
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
        element.Value = "12:00:00.1";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime7()
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
        element.Value = "1234567";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime8()
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
        element.Value = "2015-01-01T14:11:21.695Z";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime9()
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
        element.Value = "25:00:00";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime10()
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
        element.Value = "12:60:00";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime11()
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
        element.Value = "12:00:60";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime12()
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
        element.Value = "12:00:00:001";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputTime13()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber2()
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
        element.Value = "123";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber3()
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
        element.Value = "-123.45";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber4()
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
        element.Value = "123.01e-10";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    //TODO: SetCulture("ru") - NUnit-specific
    public void TestValuemissingInputNumber5InRussia()
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
        element.Value = "123.01E+10";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber5()
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
        element.Value = "123.01E+10";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber6()
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
        element.Value = "-0";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber7()
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
        element.Value = " 123 ";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber8()
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
        element.Value = "null";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber9()
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
        element.Value = "null";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber10()
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
        element.Value = "abc";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputNumber11()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputCheckbox1()
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
        element.SetAttribute("required", null);
        element.SetAttribute("checked", null);
        element.SetAttribute("name", "test1");
        Assert.Equal("checkbox", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputCheckbox2()
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
        element.SetAttribute("checked", "checked");
        element.SetAttribute("name", "test1");
        Assert.Equal("checkbox", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputCheckbox3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputRadio1()
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
        element.SetAttribute("required", null);
        element.SetAttribute("checked", null);
        element.SetAttribute("name", "test1");
        Assert.Equal("radio", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputRadio2()
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
        element.SetAttribute("checked", "checked");
        element.SetAttribute("name", "test1");
        Assert.Equal("radio", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputRadio3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputFile1()
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
        element.SetAttribute("required", null);
        element.SetAttribute("files", "null");
        Assert.Equal("file", element.Type);
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingInputFile2()
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
        Assert.Equal("file", element.Type);
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingSelect1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingSelect2()
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
        element.Value = "1";
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingSelect3()
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
        Assert.True(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingTextarea1()
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
        element.SetAttribute("required", null);
        element.Value = "";
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingTextarea2()
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
        element.Value = "abc";
        Assert.False(element.Validity.IsValueMissing);
    }

    [Fact]
    public void TestValuemissingTextarea3()
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
        Assert.True(element.Validity.IsValueMissing);
    }
}
