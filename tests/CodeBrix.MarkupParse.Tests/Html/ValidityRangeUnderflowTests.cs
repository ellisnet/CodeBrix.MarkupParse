using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests generated according to the W3C-Test.org page:
/// http://www.w3c-test.org/html/semantics/forms/constraints/form-validation-validity-rangeUnderflow.html
/// </summary>

public class ValidityRangeUnderflowTests
{
    private static IDocument CreateTestDocument()
    {
        return string.Empty.ToHtmlDocument();
    }

    [Fact]
    public void TestRangeunderflowInputDatetime1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime2()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T12:00:00Z");
        element.Value = "";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001-01-01  12:00:00Z");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T11:00:00Z");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime5()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001-01-01T23:59:59Z");
        element.Value = "2000-01-01T24:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime6()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "1980-01-01T12:00Z");
        element.Value = "79-01-01T12:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime7()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T13:00:00Z");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime8()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T12:00:00.2Z");
        element.Value = "2000-01-01T12:00:00.1Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T12:00:00.02Z");
        element.Value = "2000-01-01T12:00:00.01Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime10()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01T12:00:00.002Z");
        element.Value = "2000-01-01T12:00:00.001Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime11()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "9999-01-01T12:00:00Z");
        element.Value = "2000-01-01T12:00:00Z";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDatetime12()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "8593-01-01T02:09+02:09");
        element.Value = "8592-01-01T02:09+02:09";
        Assert.Equal("datetime", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "2000-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate2()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01");
        element.Value = "";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001/01/01");
        element.Value = "2000-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-02-02");
        element.Value = "2000-1-1";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate5()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "988-01-01");
        element.Value = "987-01-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate6()
    {
        var document = CreateTestDocument();
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
        element.Value = "2000-13-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate7()
    {
        var document = CreateTestDocument();
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
        element.Value = "2000-02-30";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate8()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01-01");
        element.Value = "2000-12-01";
        Assert.Equal("date", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-12-01");
        element.Value = "2000-01-01";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputDate10()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "9999-01-02");
        element.Value = "9999-01-01";
        Assert.Equal("date", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "2000-01";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth2()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01");
        element.Value = "";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001/01");
        element.Value = "2000-02";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-02");
        element.Value = "2000-1";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth5()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "988-01");
        element.Value = "987-01";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth6()
    {
        var document = CreateTestDocument();
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
        element.Value = "2000-13";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth7()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-01");
        element.Value = "2000-12";
        Assert.Equal("month", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth8()
    {
        var document = CreateTestDocument();
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
        element.Value = "2000-12";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputMonth9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "9999-01");
        element.Value = "2000-01";
        Assert.Equal("month", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "2000-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek2()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-W01");
        element.Value = "";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001/W02");
        element.Value = "2000-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001-W02");
        element.Value = "2000-W1";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek5()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2001-W02");
        element.Value = "2000-w01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek6()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "988-W01");
        element.Value = "987-W01";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek7()
    {
        var document = CreateTestDocument();
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
        element.Value = "2000-W57";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek8()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-W01");
        element.Value = "2000-W12";
        Assert.Equal("week", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "2000-W12");
        element.Value = "2000-W01";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputWeek10()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "9999-W01");
        element.Value = "2000-W01";
        Assert.Equal("week", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "12:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime2()
    {
        var document = CreateTestDocument();
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
        element.Value = "";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12.00.01");
        element.Value = "12:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12:00:01");
        element.Value = "12.00.00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime5()
    {
        var document = CreateTestDocument();
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
        element.Value = "13:00:00";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime6()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "13:00:00");
        element.Value = "12";
        Assert.Equal("time", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime7()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12:00:02");
        element.Value = "12:00:00";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime8()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12:00:00.2");
        element.Value = "12:00:00.1";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12:00:00.02");
        element.Value = "12:00:00.01";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime10()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "12:00:00.002");
        element.Value = "12:00:00.001";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputTime11()
    {
        var document = CreateTestDocument();
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
        element.Value = "11:59";
        Assert.Equal("time", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber1()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "");
        element.Value = "10";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber2()
    {
        var document = CreateTestDocument();
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
        element.Value = "";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber3()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "4");
        element.Value = "5";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber4()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "-5.6");
        element.Value = "-5.5";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    //TODO: SetCulture("ru") - NUnit-specific
    public void TestRangeunderflowInputNumber4InRussia()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "-5.6");
        element.Value = "-5.5";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber5()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "0");
        element.Value = "-0";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber6()
    {
        var document = CreateTestDocument();
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
        element.Value = "6abc";
        Assert.Equal("number", element.Type);
        Assert.False(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber7()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "6");
        element.Value = "5";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber8()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "-5.4");
        element.Value = "-5.5";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }

    [Fact]
    public void TestRangeunderflowInputNumber9()
    {
        var document = CreateTestDocument();
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
        element.SetAttribute("min", "5e+2");
        element.Value = "-5e-1";
        Assert.Equal("number", element.Type);
        Assert.True(element.Validity.IsRangeUnderflow);
    }
}
