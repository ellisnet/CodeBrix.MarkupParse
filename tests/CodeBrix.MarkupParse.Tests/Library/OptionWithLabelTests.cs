using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class OptionWithLabelTests
{
    private static readonly string[] spaces = new[] { "\u0020", "\u0009", "\u000A", "\u000C", "\u000D" };

    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void OptionNoChildrenEmptyLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("label", "");
        Assert.Equal("", option.Label);
    }

    [Fact]
    public void OptionNoChildrenLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("label", "label");
        Assert.Equal("label", option.Label);
    }

    [Fact]
    public void OptionNoChildrenNamespacedLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("http://www.example.com/", "label", "");
        Assert.Equal("", option.Label);
    }

    [Fact]
    public void OptionSingleChildNoLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        Assert.Equal("child", option.Label);
    }

    [Fact]
    public void OptionSingleChildEmptyLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("label", "");
        Assert.Equal("", option.Label);
    }

    [Fact]
    public void OptionSingleChildLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("label", "label");
        Assert.Equal("label", option.Label);
    }

    [Fact]
    public void OptionSingleChildNamespacedLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("http://www.example.com/", "label", "label");
        Assert.Equal("child", option.Label);
    }

    [Fact]
    public void OptionTwoChildrenNoLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        Assert.Equal("child node", option.Label);
    }

    [Fact]
    public void OptionTwoChildrenEmptyLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("label", "");
        Assert.Equal("", option.Label);
    }

    [Fact]
    public void OptionTwoChildrenLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("label", "label");
        Assert.Equal("label", option.Label);
    }

    [Fact]
    public void OptionTwoChildrenNamespacedLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("http://www.example.com/", "label", "label");
        Assert.Equal("child node", option.Label);
    }

    [Fact]
    public void OptionNoChildrenEmptyValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("value", "");
        Assert.Equal("", option.Value);
    }

    [Fact]
    public void OptionNoChildrenValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("value", "value");
        Assert.Equal("value", option.Value);
    }

    [Fact]
    public void OptionNoChildrenNamespacedValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("http://www.example.com/", "value", "");
        Assert.Equal("", option.Value);
    }

    [Fact]
    public void OptionSingleChildNoValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        Assert.Equal("child", option.Value);
    }

    [Fact]
    public void OptionSingleChildEmptyValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("value", "");
        Assert.Equal("", option.Value);
    }

    [Fact]
    public void OptionSingleChildValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("value", "value");
        Assert.Equal("value", option.Value);
    }

    [Fact]
    public void OptionSingleChildNamespacedValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.SetAttribute("http://www.example.com/", "value", "value");
        Assert.Equal("child", option.Value);
    }

    [Fact]
    public void OptionTwoChildrenNoValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        Assert.Equal("child node", option.Value);
    }

    [Fact]
    public void OptionTwoChildrenEmptyValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("value", "");
        Assert.Equal("", option.Value);
    }

    [Fact]
    public void OptionTwoChildrenValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("value", "value");
        Assert.Equal("value", option.Value);
    }

    [Fact]
    public void OptionTwoChildrenNamespacedValue()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.AppendChild(document.CreateTextNode(" child "));
        option.AppendChild(document.CreateTextNode(" node "));
        option.SetAttribute("http://www.example.com/", "value", "value");
        Assert.Equal("child node", option.Value);
    }

    [Fact]
    public void OptionInOptGroup()
    {
        var document = Html(@"<select id=""test"" name=""entry""><optgroup label=""Main menu""><option value=""1"">Exit</option></optgroup></select>");
        var select = document.GetElementById("test") as IHtmlSelectElement;
        Assert.NotNull(select);
        var option = select.QuerySelector("option") as IHtmlOptionElement;
        Assert.NotNull(option);
        Assert.Equal("1", option.Value);
        var parent = option.ParentElement as IHtmlOptionsGroupElement;
        Assert.NotNull(parent);
        Assert.Equal("Main menu", parent.Label);
        var sameOption = select.Options[0];
        Assert.IsAssignableFrom<IHtmlOptionElement>(sameOption);
        Assert.Equal(option, sameOption);
    }

    [Fact]
    public void OptionsInOptGroupMixedWithOptionsNoInOptGroup()
    {
        var document = Html(@"<select><optgroup><option>1</option><option>2</option></optgroup><option>3</option><optgroup><option>4</option><option>5</option></optgroup></select>");
        var select = document.QuerySelector("select") as IHtmlSelectElement;
        Assert.NotNull(select);
        var options = select.Options;
        Assert.NotNull(options);
        Assert.Equal(5, options.Length);
        Assert.Equal("1", options.GetOptionAt(0).Value);
        Assert.Equal("2", options.GetOptionAt(1).Value);
        Assert.Equal("3", options.GetOptionAt(2).Value);
        Assert.Equal("4", options.GetOptionAt(3).Value);
        Assert.Equal("5", options.GetOptionAt(4).Value);
    }

    [Fact]
    public void OptionWithNonEmptyLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("label", "label");
        option.TextContent = "text";
        Assert.Equal("text", option.Text);
    }

    [Fact]
    public void OptionWithEmptyLabel()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.SetAttribute("label", "");
        option.TextContent = "text";
        Assert.Equal("text", option.Text);
    }

    [Fact]
    public void OptionTextShouldLeaveNbspAlone()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.TextContent = "\u00a0text";
        Assert.Equal("\u00a0text", option.Text);
    }

    [Fact]
    public void OptionTextShouldLeaveTrailingNbspAlone()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.TextContent = "text\u00a0";
        Assert.Equal("text\u00a0", option.Text);
    }

    [Fact]
    public void OptionTextShouldLeaveASingleInternalNbspAlone()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.TextContent = "before\u00a0after";
        Assert.Equal("before\u00a0after", option.Text);
    }

    [Fact]
    public void OptionTextShouldLeaveMultipleInternalNbspAlone()
    {
        var document = Html("");
        var option = document.CreateElement<IHtmlOptionElement>();
        option.TextContent = "before\u00a0\u00a0after";
        Assert.Equal("before\u00a0\u00a0after", option.Text);
    }

    [Fact]
    public void OptionTextShouldStripLeadingSpaceCharacters()
    {
        foreach (var space in spaces)
        {
            var document = Html("");
            var option = document.CreateElement<IHtmlOptionElement>();
            option.TextContent = space + "text";
            Assert.Equal("text", option.Text);
        }
    }

    [Fact]
    public void OptionTextShouldStripTrailingSpaceCharacters()
    {
        foreach (var space in spaces)
        {
            var document = Html("");
            var option = document.CreateElement<IHtmlOptionElement>();
            option.TextContent = "text" + space;
            Assert.Equal("text", option.Text);
        }
    }

    [Fact]
    public void OptionTextShouldStripLeadingAndTrailingSpaceCharacters()
    {
        foreach (var space in spaces)
        {
            var document = Html("");
            var option = document.CreateElement<IHtmlOptionElement>();
            option.TextContent = space + "text" + space;
            Assert.Equal("text", option.Text);
        }
    }

    [Fact]
    public void OptionTextShouldReplaceSingleInternalSpaceCharacters()
    {
        foreach (var space in spaces)
        {
            var document = Html("");
            var option = document.CreateElement<IHtmlOptionElement>();
            option.TextContent = "before" + space + "after";
            Assert.Equal("before after", option.Text);
        }
    }

    [Fact]
    public void OptionTextShouldReplaceMultipleInternalSpaceCharacters()
    {
        foreach (var space1 in spaces)
        {
            foreach (var space2 in spaces)
            {
                var document = Html("");
                var option = document.CreateElement<IHtmlOptionElement>();
                option.TextContent = "before" + space1 + space2 + "after";
                Assert.Equal("before after", option.Text);
            }
        }
    }
}
