using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class NodeIteratorTests
{
    [Fact]
    public void NodeIteratorJavaScriptKitDivision()
    {
        var source = @"<div id=contentarea>
<p>Some <span>text</span></p>
<b>Bold text</b>
</div>";
        var doc = source.ToHtmlDocument();
        var rootnode = doc.GetElementById("contentarea");
        var iterator = doc.CreateNodeIterator(rootnode, FilterSettings.Element);

        Assert.Equal(rootnode, iterator.Root);
        Assert.True(iterator.IsBeforeReference);

        var results = new List<INode>();

        while (iterator.Next() != null)
        {
            results.Add(iterator.Reference);
        }

        Assert.False(iterator.IsBeforeReference);
        Assert.Equal(4, results.Count);
        Assert.IsAssignableFrom<HtmlDivElement>(results[0]);
        Assert.IsAssignableFrom<HtmlParagraphElement>(results[1]);
        Assert.IsAssignableFrom<HtmlSpanElement>(results[2]);
        Assert.IsAssignableFrom<HtmlBoldElement>(results[3]);

        do
        {
            results.Remove(iterator.Reference);
        }
        while (iterator.Previous() != null);

        Assert.True(iterator.IsBeforeReference);
    }

    [Fact]
    public void NodeIteratorJavaScriptKitParagraph()
    {
        var source = @"<p id=essay>George<span> loves </span><b>JavaScript!</b></p>";
        var doc = source.ToHtmlDocument();
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("essay");
        Assert.NotNull(rootnode);

        var iterator = doc.CreateNodeIterator(rootnode, FilterSettings.Text);
        Assert.NotNull(iterator);
        Assert.Equal(rootnode, iterator.Root);
        Assert.True(iterator.IsBeforeReference);

        Assert.Equal("George", iterator.Next().TextContent);

        var paratext = iterator.Reference.TextContent;

        while (iterator.Next() != null)
        {
            paratext += iterator.Reference.TextContent;
        }

        Assert.Equal("George loves JavaScript!", paratext);
    }

    [Fact]
    public void NodeIteratorJavaScriptKitList()
    {
        var source = @"<ul id=mylist>
<li class='item'>List 1</li>
<li class='item'>List 2</li>
<li>List 3</li>
</ul>";
        var doc = source.ToHtmlDocument();
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("mylist");
        Assert.NotNull(rootnode);

        var iterator = doc.CreateNodeIterator(rootnode, FilterSettings.Element, node =>
        {

            if (node is IHtmlListItemElement element && element.ClassList.Contains("item"))
            {
                return FilterResult.Accept;
            }

            return FilterResult.Reject;
        });

        Assert.NotNull(iterator);
        Assert.Equal(rootnode, iterator.Root);

        var results = new List<INode>();

        while (iterator.Next() != null)
        {
            results.Add(iterator.Reference);
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
    public void NodeIteratorDotteroSpans()
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
        var doc = source.ToHtmlDocument();
        Assert.NotNull(doc);

        var rootnode = doc.GetElementById("content");
        Assert.NotNull(rootnode);

        var iterator = doc.CreateNodeIterator(rootnode, FilterSettings.Element,
            m => m.GetTagName() == "span" ? FilterResult.Accept : FilterResult.Skip);
        Assert.NotNull(iterator);
        Assert.Equal(rootnode, iterator.Root);

        var node = iterator.Next();
        var sections = 0;
        Assert.NotNull(node);

        while (node != null)
        {
            Assert.Equal("span", node.GetTagName());
            sections++;
            node = iterator.Next();
        }

        Assert.Equal(3, sections);
    }

    [Fact]
    public void NodeIteratorFromDocumentDoesNotThrowException()
    {
        var doc = "<div></div>".ToHtmlDocument();
        var ni = doc.CreateNodeIterator(doc, FilterSettings.All);
        Assert.Equal(doc, ni.Root);
        Assert.Equal(doc, ni.Next());
        Assert.Equal(doc.DocumentElement, ni.Next());
        Assert.Equal(doc.Head, ni.Next());
        Assert.Equal(doc.Body, ni.Next());
        Assert.Equal(doc.Body.FirstChild, ni.Next());
        Assert.Null(ni.Next());
    }

    [Fact]
    public void NodeIteratorFromEmptyElementDoesNotThrowException()
    {
        var doc = "<div></div>".ToHtmlDocument();
        var div = doc.QuerySelector("div");
        var ni = doc.CreateNodeIterator(div, FilterSettings.All);
        Assert.Equal(div, ni.Root);
        Assert.Equal(div, ni.Next());
        Assert.Null(ni.Next());
        Assert.Equal(div, ni.Previous());
        Assert.Null(ni.Previous());
    }

    [Fact]
    public void NodeIteratorUsingPreviousWorksAsExpected()
    {
        var doc = "<div><span>foo</span></div>".ToHtmlDocument();
        var div = doc.QuerySelector("div");
        var ni = doc.CreateNodeIterator(div, FilterSettings.Element);
        Assert.Equal(div, ni.Root);
        Assert.Equal(div, ni.Next());
        Assert.NotNull(ni.Next());
        Assert.Null(ni.Next());
        Assert.NotNull(ni.Previous());
        Assert.Equal(div, ni.Previous());
        Assert.Null(ni.Previous());
        Assert.Equal(div, ni.Next());
        Assert.Equal(div, ni.Previous());
        Assert.Null(ni.Previous());
    }

    [Fact]
    public void NodeIteratorUsingCommentsWithNoCommentsOnlyYieldsNull()
    {
        var doc = "<div><span>foo</span></div>".ToHtmlDocument();
        var div = doc.QuerySelector("div");
        var ni = doc.CreateNodeIterator(div, FilterSettings.Comment);
        Assert.Equal(div, ni.Root);
        Assert.Null(ni.Next());
        Assert.Null(ni.Next());
        Assert.Null(ni.Previous());
        Assert.Null(ni.Previous());
        Assert.Null(ni.Next());
        Assert.Null(ni.Previous());
    }

    [Fact]
    public void NodeIteratorShouldDealWithNodeRemoval_Issue1222()
    {
        var doc = "<div id='outer'><div id='inner1'></div><div id='inner2'></div></div>".ToHtmlDocument();
        var outer = doc.GetElementById("outer");
        var inner1 = doc.GetElementById("inner1");
        var inner2 = doc.GetElementById("inner2");
        var iterator = doc.CreateNodeIterator(outer, FilterSettings.Element);
        var node1 = iterator.Next();
        var node2 = iterator.Next();
        node2.Parent.RemoveChild(node2);
        var node3 = iterator.Next();

        Assert.Equal(outer, node1);
        Assert.Equal(inner1, node2);
        Assert.Equal(inner2, node3);
    }
}
