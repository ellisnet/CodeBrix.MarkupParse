using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class TreeWalkerTests
{
    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void TreeWalkerJavaScriptKitDivision()
    {
        var source = @"<div id=contentarea>
<p>Some <span>text</span></p>
<b>Bold text</b>
</div>";
        var doc = Html(source);
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("contentarea");
        Assert.NotNull(rootnode);

        var walker = doc.CreateTreeWalker(rootnode, FilterSettings.Element);
        Assert.NotNull(walker);
        Assert.Equal(rootnode, walker.Current);

        var results = new List<INode>();

        while (walker.ToNext() != null)
        {
            results.Add(walker.Current);
        }

        Assert.Equal(3, results.Count);
        Assert.IsAssignableFrom<HtmlParagraphElement>(results[0]);
        Assert.IsAssignableFrom<HtmlSpanElement>(results[1]);
        Assert.IsAssignableFrom<HtmlBoldElement>(results[2]);

        walker.Current = rootnode;
        Assert.IsAssignableFrom<HtmlParagraphElement>(walker.ToFirst());
    }

    [Fact]
    public void TreeWalkerJavaScriptKitParagraph()
    {
        var source = @"<p id=essay>George<span> loves </span><b>JavaScript!</b></p>";
        var doc = Html(source);
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("essay");
        Assert.NotNull(rootnode);

        var walker = doc.CreateTreeWalker(rootnode, FilterSettings.Text);
        Assert.NotNull(walker);
        Assert.Equal(rootnode, walker.Current);

        Assert.Equal("George", walker.ToFirst().TextContent);

        var paratext = walker.Current.TextContent;

        while (walker.ToNextSibling() != null)
        {
            paratext += walker.Current.TextContent;
        }

        Assert.Equal("George loves JavaScript!", paratext);
    }

    [Fact]
    public void TreeWalkerJavaScriptKitList()
    {
        var source = @"<ul id=mylist>
<li class='item'>List 1</li>
<li class='item'>List 2</li>
<li>List 3</li>
</ul>";
        var doc = Html(source);
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("mylist");
        Assert.NotNull(rootnode);

        var walker = doc.CreateTreeWalker(rootnode, FilterSettings.Element, node =>
        {

            if (node is IHtmlListItemElement element && element.ClassList.Contains("item"))
            {
                return FilterResult.Accept;
            }

            return FilterResult.Reject;
        });

        Assert.NotNull(walker);
        Assert.Equal(rootnode, walker.Current);

        var results = new List<INode>();

        while (walker.ToNext() != null)
        {
            results.Add(walker.Current);
        }

        Assert.Equal(7, rootnode.ChildNodes.Length);
        Assert.Equal(3, rootnode.Children.Length);
        Assert.Equal(2, results.Count);

        var item1 = results[0] as IHtmlListItemElement;
        var item2 = results[1] as IHtmlListItemElement;

        Assert.NotNull(item1);
        Assert.NotNull(item2);

        Assert.Equal("item", item1.ClassName);
        Assert.Equal("item", item2.ClassName);
    }

    [Fact]
    public void TreeWalkerDotteroSpans()
    {
        var source = @"<div id=""content"">
        <span>
            <b>1. Section</b><br />
            <span>
                <b>1.1. Subsection</b><br />
            </span>
        </span>
        <span>
            <b>2.Section</b><br />
        </span>
    </div>";
        var doc = Html(source);
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("content");
        Assert.NotNull(rootnode);

        var walker = doc.CreateTreeWalker(rootnode, FilterSettings.Element, 
            m => m.GetTagName() == "span" ? FilterResult.Accept : FilterResult.Skip);
        Assert.NotNull(walker);
        Assert.Equal(rootnode, walker.Current);

        var node = walker.ToFirst();
        var sections = 0;
        Assert.NotNull(node);

        while (node != null)
        {
            Assert.Equal("span", node.GetTagName());
            sections++;
            node = walker.ToNextSibling();
        }

        Assert.Equal(2, sections);
    }
}
