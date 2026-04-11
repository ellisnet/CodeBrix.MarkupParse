using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests_innerHTML_1.dat,
/// tree-construction/tests4.dat
/// </summary>

public class HtmlFragmentTests
{
    static INodeList HtmlFragment(string code, IElement context = null)
    {
        return code.ToHtmlFragment(context);
    }

    static IElement Create(string tagName)
    {
        var doc = "".ToHtmlDocument();
        return doc.CreateElement(tagName);
    }

    [Fact]
    public void FragmentBodyContextDoubleBodyAndSpanElement()
    {
        var doc = (@"<body><span>").ToHtmlFragment("body");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);
    }

    [Fact]
    public void FragmentBodyContextSpanAndDoubleBodyElement()
    {
        var doc = (@"<span><body>").ToHtmlFragment("body");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);
    }

    [Fact]
    public void FragmentDivContextSpanAndDoubleBodyElement()
    {
        var doc = (@"<span><body>").ToHtmlFragment("div");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);
    }

    [Fact]
    public void FragmentHtmlContextBodyAndSpanElement()
    {
        var doc = (@"<body><span>").ToHtmlFragment("html");

        var dochead0 = doc[0] as Element;
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(dochead0.Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docbody1 = doc[1] as Element;
        Assert.Single(docbody1.ChildNodes);
        Assert.Empty(docbody1.Attributes);
        Assert.Equal("body", docbody1.GetTagName());
        Assert.Equal(NodeType.Element, docbody1.NodeType);

        var docbody1span0 = docbody1.ChildNodes[0] as Element;
        Assert.Empty(docbody1span0.ChildNodes);
        Assert.Empty(docbody1span0.Attributes);
        Assert.Equal("span", docbody1span0.GetTagName());
        Assert.Equal(NodeType.Element, docbody1span0.NodeType);
    }

    [Fact]
    public void FragmentBodyContextFramesetAndSpanElement()
    {
        var doc = (@"<frameset><span>").ToHtmlFragment("body");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);

    }

    [Fact]
    public void FragmentBodyContextSpanAndFramesetElement()
    {
        var doc = (@"<span><frameset>").ToHtmlFragment("body");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);
    }

    [Fact]
    public void FragmentDivContextSpanAndFramesetElement()
    {
        var doc = (@"<span><frameset>").ToHtmlFragment("div");

        var docspan0 = doc[0] as Element;
        Assert.Empty(docspan0.ChildNodes);
        Assert.Empty(docspan0.Attributes);
        Assert.Equal("span", docspan0.GetTagName());
        Assert.Equal(NodeType.Element, docspan0.NodeType);
    }

    [Fact]
    public void FragmentHtmlContextEmpty()
    {
        var doc = (@"").ToHtmlFragment("html");
        var dochead0 = doc[0] as Element;
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(dochead0.Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docbody1 = doc[1] as Element;
        Assert.Empty(docbody1.ChildNodes);
        Assert.Empty(docbody1.Attributes);
        Assert.Equal("body", docbody1.GetTagName());
        Assert.Equal(NodeType.Element, docbody1.NodeType);
    }

    [Fact]
    public void FragmentHtmlContextFramesetAndSpanElement()
    {
        var doc = (@"<frameset><span>").ToHtmlFragment("html");

        var dochead0 = doc[0] as Element;
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(dochead0.Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docframeset1 = doc[1] as Element;
        Assert.Empty(docframeset1.ChildNodes);
        Assert.Empty(docframeset1.Attributes);
        Assert.Equal("frameset", docframeset1.GetTagName());
        Assert.Equal(NodeType.Element, docframeset1.NodeType);
    }

    [Fact]
    public void FragmentTableContextOpeningTableAndTrElement()
    {
        var doc = (@"<table><tr>").ToHtmlFragment("table");

        var doctbody0 = doc[0] as Element;
        Assert.Single(doctbody0.ChildNodes);
        Assert.Empty(doctbody0.Attributes);
        Assert.Equal("tbody", doctbody0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0.NodeType);

        var doctbody0tr0 = doctbody0.ChildNodes[0] as Element;
        Assert.Empty(doctbody0tr0.ChildNodes);
        Assert.Empty(doctbody0tr0.Attributes);
        Assert.Equal("tr", doctbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0tr0.NodeType);
    }

    [Fact]
    public void FragmentTableContextClosingTableAndTrElement()
    {
        var doc = (@"</table><tr>").ToHtmlFragment("table");

        var doctbody0 = doc[0] as Element;
        Assert.Single(doctbody0.ChildNodes);
        Assert.Empty(doctbody0.Attributes);
        Assert.Equal("tbody", doctbody0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0.NodeType);

        var doctbody0tr0 = doctbody0.ChildNodes[0] as Element;
        Assert.Empty(doctbody0tr0.ChildNodes);
        Assert.Empty(doctbody0tr0.Attributes);
        Assert.Equal("tr", doctbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0tr0.NodeType);
    }

    [Fact]
    public void FragmentFramesetContextClosingFramesetAndFrameElement()
    {
        var doc = (@"</frameset><frame>").ToHtmlFragment("frameset");

        var docframe0 = doc[0] as Element;
        Assert.Empty(docframe0.ChildNodes);
        Assert.Empty(docframe0.Attributes);
        Assert.Equal("frame", docframe0.GetTagName());
        Assert.Equal(NodeType.Element, docframe0.NodeType);
    }

    [Fact]
    public void FragmentSelectContextClosingSelectAndOptionElement()
    {
        var doc = (@"</select><option>").ToHtmlFragment("select");
        var docoption0 = doc[0] as Element;
        Assert.Empty(docoption0.ChildNodes);
        Assert.Empty(docoption0.Attributes);
        Assert.Equal("option", docoption0.GetTagName());
        Assert.Equal(NodeType.Element, docoption0.NodeType);
    }

    [Fact]
    public void FragmentSelectContextInputAndOptionElement()
    {
        var doc = (@"<input><option>").ToHtmlFragment("select");

        var docoption0 = doc[0] as Element;
        Assert.Empty(docoption0.ChildNodes);
        Assert.Empty(docoption0.Attributes);
        Assert.Equal("option", docoption0.GetTagName());
        Assert.Equal(NodeType.Element, docoption0.NodeType);
    }

    [Fact]
    public void FragmentTdContextTableAndDoubleTdElement()
    {
        var doc = (@"<table><td><td>").ToHtmlFragment("td");

        var doctable0 = doc[0] as Element;
        Assert.Single(doctable0.ChildNodes);
        Assert.Empty(doctable0.Attributes);
        Assert.Equal("table", doctable0.GetTagName());
        Assert.Equal(NodeType.Element, doctable0.NodeType);

        var doctable0tbody0 = doctable0.ChildNodes[0] as Element;
        Assert.Single(doctable0tbody0.ChildNodes);
        Assert.Empty(doctable0tbody0.Attributes);
        Assert.Equal("tbody", doctable0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, doctable0tbody0.NodeType);

        var doctable0tbody0tr0 = doctable0tbody0.ChildNodes[0] as Element;
        Assert.Equal(2, doctable0tbody0tr0.ChildNodes.Length);
        Assert.Empty(doctable0tbody0tr0.Attributes);
        Assert.Equal("tr", doctable0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, doctable0tbody0tr0.NodeType);

        var doctable0tbody0tr0td0 = doctable0tbody0tr0.ChildNodes[0] as Element;
        Assert.Empty(doctable0tbody0tr0td0.ChildNodes);
        Assert.Empty(doctable0tbody0tr0td0.Attributes);
        Assert.Equal("td", doctable0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, doctable0tbody0tr0td0.NodeType);

        var doctable0tbody0tr0td1 = doctable0tbody0tr0.ChildNodes[1] as Element;
        Assert.Empty(doctable0tbody0tr0td1.ChildNodes);
        Assert.Empty(doctable0tbody0tr0td1.Attributes);
        Assert.Equal("td", doctable0tbody0tr0td1.GetTagName());
        Assert.Equal(NodeType.Element, doctable0tbody0tr0td1.NodeType);

    }

    [Fact]
    public void FragmentTdContextTfootAndAnchorElement()
    {
        var doc = (@"<tfoot><a>").ToHtmlFragment("td");

        var doca0 = doc[0] as Element;
        Assert.Empty(doca0.ChildNodes);
        Assert.Empty(doca0.Attributes);
        Assert.Equal("a", doca0.GetTagName());
        Assert.Equal(NodeType.Element, doca0.NodeType);
    }

    [Fact]
    public void FragmentTrContextTdAndFinishedTableAndTdElement()
    {
        var doc = (@"<td><table></table><td>").ToHtmlFragment("tr");

        var doctd0 = doc[0] as Element;
        Assert.Single(doctd0.ChildNodes);
        Assert.Empty(doctd0.Attributes);
        Assert.Equal("td", doctd0.GetTagName());
        Assert.Equal(NodeType.Element, doctd0.NodeType);

        var doctd0table0 = doctd0.ChildNodes[0] as Element;
        Assert.Empty(doctd0table0.ChildNodes);
        Assert.Empty(doctd0table0.Attributes);
        Assert.Equal("table", doctd0table0.GetTagName());
        Assert.Equal(NodeType.Element, doctd0table0.NodeType);

        var doctd1 = doc[1] as Element;
        Assert.Empty(doctd1.ChildNodes);
        Assert.Empty(doctd1.Attributes);
        Assert.Equal("td", doctd1.GetTagName());
        Assert.Equal(NodeType.Element, doctd1.NodeType);
    }

    [Fact]
    public void FragmentTbodyContextTdAndTableAndTbodyAndMisplacedAnchorAndTrElement()
    {
        var doc = (@"<td><table><tbody><a><tr>").ToHtmlFragment("tbody");

        var doctr0 = doc[0] as Element;
        Assert.Single(doctr0.ChildNodes);
        Assert.Empty(doctr0.Attributes);
        Assert.Equal("tr", doctr0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0.NodeType);

        var doctr0td0 = doctr0.ChildNodes[0] as Element;
        Assert.Equal(2, doctr0td0.ChildNodes.Length);
        Assert.Empty(doctr0td0.Attributes);
        Assert.Equal("td", doctr0td0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0td0.NodeType);

        var doctr0td0a0 = doctr0td0.ChildNodes[0] as Element;
        Assert.Empty(doctr0td0a0.ChildNodes);
        Assert.Empty(doctr0td0a0.Attributes);
        Assert.Equal("a", doctr0td0a0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0td0a0.NodeType);

        var doctr0td0table1 = doctr0td0.ChildNodes[1] as Element;
        Assert.Single(doctr0td0table1.ChildNodes);
        Assert.Empty(doctr0td0table1.Attributes);
        Assert.Equal("table", doctr0td0table1.GetTagName());
        Assert.Equal(NodeType.Element, doctr0td0table1.NodeType);

        var doctr0td0table1tbody0 = doctr0td0table1.ChildNodes[0] as Element;
        Assert.Single(doctr0td0table1tbody0.ChildNodes);
        Assert.Empty(doctr0td0table1tbody0.Attributes);
        Assert.Equal("tbody", doctr0td0table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0td0table1tbody0.NodeType);

        var doctr0td0table1tbody0tr0 = doctr0td0table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(doctr0td0table1tbody0tr0.ChildNodes);
        Assert.Empty(doctr0td0table1tbody0tr0.Attributes);
        Assert.Equal("tr", doctr0td0table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0td0table1tbody0tr0.NodeType);

    }

    [Fact]
    public void FragmentTbodyContextMisplacedTheadAndAnchorElement()
    {
        var doc = (@"<thead><a>").ToHtmlFragment("tbody");

        var doca0 = doc[0] as Element;
        Assert.Empty(doca0.ChildNodes);
        Assert.Empty(doca0.Attributes);
        Assert.Equal("a", doca0.GetTagName());
        Assert.Equal(NodeType.Element, doca0.NodeType);
    }

    [Fact]
    public void FragmentColgroupContextClosingColgroupAndColElement()
    {
        var doc = (@"</colgroup><col>").ToHtmlFragment("colgroup");

        var doccol0 = doc[0] as Element;
        Assert.Empty(doccol0.ChildNodes);
        Assert.Empty(doccol0.Attributes);
        Assert.Equal("col", doccol0.GetTagName());
        Assert.Equal(NodeType.Element, doccol0.NodeType);
    }

    [Fact]
    public void FragmentDivContextWithText()
    {
        var doc = (@"direct div content").ToHtmlFragment("div");

        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("direct div content", docText0.TextContent);
    }

    [Fact]
    public void FragmentTextareaContextWithText()
    {
        var doc = (@"direct textarea content").ToHtmlFragment("textarea");
        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("direct textarea content", docText0.TextContent);
    }

    [Fact]
    public void FragmentTextAreaContextWithTextAndMarkup()
    {
        var doc = (@"textarea content with <em>pseudo</em> <foo>markup").ToHtmlFragment("textarea");
        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("textarea content with <em>pseudo</em> <foo>markup", docText0.TextContent);
    }

    [Fact]
    public void FragmentStyleContextWithText()
    {
        var doc = (@"this is &#x0043;DATA inside a <style> element").ToHtmlFragment("style");

        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("this is &#x0043;DATA inside a <style> element", docText0.TextContent);
    }

    [Fact]
    public void FragmentPlaintextContext()
    {
        var doc = (@"</plaintext>").ToHtmlFragment("plaintext");

        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("</plaintext>", docText0.TextContent);
    }

    [Fact]
    public void FragmentHtmlContextWithText()
    {
        var doc = (@"setting html's innerHTML").ToHtmlFragment("html");

        var dochead0 = doc[0] as Element;
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(dochead0.Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docbody1 = doc[1] as Element;
        Assert.Single(docbody1.ChildNodes);
        Assert.Empty(docbody1.Attributes);
        Assert.Equal("body", docbody1.GetTagName());
        Assert.Equal(NodeType.Element, docbody1.NodeType);

        var docbody1Text0 = docbody1.ChildNodes[0];
        Assert.Equal(NodeType.Text, docbody1Text0.NodeType);
        Assert.Equal("setting html's innerHTML", docbody1Text0.TextContent);
    }

    [Fact]
    public void FragmentHeadContextWithTextInTitle()
    {
        var doc = (@"<title>setting head's innerHTML</title>").ToHtmlFragment("head");

        var doctitle0 = doc[0] as Element;
        Assert.Single(doctitle0.ChildNodes);
        Assert.Empty(doctitle0.Attributes);
        Assert.Equal("title", doctitle0.GetTagName());
        Assert.Equal(NodeType.Element, doctitle0.NodeType);

        var doctitle0Text0 = doctitle0.ChildNodes[0];
        Assert.Equal(NodeType.Text, doctitle0Text0.NodeType);
        Assert.Equal("setting head's innerHTML", doctitle0Text0.TextContent);
    }

    [Fact]
    public void FosterFragmentDoubleClosedBody()
    {
        var doc = (@"<body>X</body></body>").ToHtmlFragment("html");

        var dochead0 = doc[0] as Element;
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(dochead0.Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docbody1 = doc[1] as Element;
        Assert.Single(docbody1.ChildNodes);
        Assert.Empty(docbody1.Attributes);
        Assert.Equal("body", docbody1.GetTagName());
        Assert.Equal(NodeType.Element, docbody1.NodeType);

        var docbody1Text0 = docbody1.ChildNodes[0];
        Assert.Equal(NodeType.Text, docbody1Text0.NodeType);
        Assert.Equal("X", docbody1Text0.TextContent);
    }

    [Fact]
    public void FragmentButtonWithText()
    {
        var doc = ("<button>Boo!</button>").ToHtmlFragment();
        var buttonElement = doc.QuerySelector("button") as IHtmlButtonElement;

        Assert.NotNull(buttonElement);
        Assert.Equal("Boo!", buttonElement.TextContent);
    }

    [Fact]
    public void FragmentButtonWithTextAndAttribute()
    {
        var doc = ("<button type=SEARCH>Boo!</button>").ToHtmlFragment();
        var buttonElement = doc.QuerySelector("button") as IHtmlButtonElement;

        Assert.NotNull(buttonElement);
        Assert.Equal("Boo!", buttonElement.TextContent);
        Assert.Equal("search", buttonElement.Type);
        Assert.Equal("SEARCH", buttonElement.GetAttribute("type"));
    }

    [Fact]
    public void FragmentButtonDefaultSubmitType()
    {
        var doc = ("<button>Boo!</button>").ToHtmlFragment();
        var buttonElement = doc.QuerySelector("button") as IHtmlButtonElement;

        Assert.NotNull(buttonElement);
        Assert.Equal("Boo!", buttonElement.TextContent);
        Assert.Equal("submit", buttonElement.Type);
        Assert.False(buttonElement.HasAttribute("type"));
    }
    
    [Fact]
    public void FragmentClassNameCaseNumbered()
    {
        var dom = ("<div class=\"class1 CLASS2 claSS3\" x=\"y\" />").ToHtmlFragment();
        var el = dom.QuerySelector("div");

        Assert.NotNull(el);
        Assert.Equal(3, el.ClassList.Length);

        Assert.Equal(new List<string>(new [] { "class1", "CLASS2", "claSS3" }), new List<string>(el.ClassList));

        Assert.Empty(dom.QuerySelectorAll(".class2"));
        Assert.Single(dom.QuerySelectorAll(".CLASS2"));
    }

    [Fact]
    public void FragmentClassNameOnlyCase()
    {
        var dom = ("<div class=\"class CLASS\" />").ToHtmlFragment();
        var el = dom.QuerySelector("div");

        Assert.NotNull(el);
        Assert.Equal(2, el.ClassList.Length);

        Assert.Equal(new List<string>(new[] { "class", "CLASS" }), new List<string>(el.ClassList));
    }

    [Fact]
    public void FragmentUnquotedAttributeHandling()
    {
        var doc = ("<div custattribute=10/23/2012 id=\"tableSample\"><span>sample text</span></div>").ToHtmlFragment();
        var obj = doc.QuerySelector("#tableSample");

        Assert.Equal("10/23/2012", obj.GetAttribute("custattribute"));
    }

    [Fact]
    public void FragmentCaretsInAttributes()
    {
        var doc = ("<div><img src=\"test.png\" alt=\">\" /></div>").ToHtmlFragment();
        var div = doc.QuerySelector("div");

        Assert.NotNull(div);
        Assert.Equal("<div><img src=\"test.png\" alt=\">\"></div>", div.OuterHtml);
    }

    [Fact]
    public void FragmentUnwrapWithoutParent()
    {
        var s = "This is <b> a big</b> text";
        var f = s.ToHtmlFragment();
        var t = f.QuerySelector("b");

        Assert.Equal("<b> a big</b>", t.OuterHtml);
    }

    [Fact]
    public void FragmentRoundtripEncoding()
    {
        var html = "<span>Test &nbsp; nbsp</span>";
        var dom = (html).ToHtmlFragment();

        var body = dom.QuerySelector("body");
        Assert.NotNull(body);

        var output = body.InnerHtml.Replace("" + (char)160, "&nbsp;");
        Assert.Equal(html, output);
    }

    [Fact]
    public void FragmentClassAndStyleAsBoolean()
    {
        var html = @"<span class="""" style="""">Test </span><div class style><br /></div>";
        var dom = (html).ToHtmlFragment();

        var body = dom.QuerySelector("body");
        Assert.NotNull(body);

        var output = body.InnerHtml.Replace("" + (char)160, "&nbsp;");
        Assert.Equal(@"<span class="""" style="""">Test </span><div class="""" style=""""><br></div>", output);
    }

    [Fact]
    public void FragmentUtf8HighValuesConversion()
    {
        var html = @"<span>&#55449;&#56580;</span>";
        var dom = (html).ToHtmlFragment();
        var span = dom.QuerySelector("span");

        Assert.NotNull(span);
        Assert.Equal("\uFFFD\uFFFD", span.InnerHtml);
    }

    [Fact]
    public void FragmentTableShouldBeAlright()
    {
        var fragment = "<table></table>";
        var document = "<!DOCTYPE html><div id=outputPanel></div>".ToHtmlDocument();
        var element = document.GetElementById("outputPanel");
        element.InnerHtml = fragment;

        Assert.Equal(fragment, element.InnerHtml);
    }

    [Fact]
    public void FragmentTailShouldBeConsidered()
    {
        var fragment = "<script>alert('foo');</script><p>Test</p>";
        var document = "<!DOCTYPE html><div id=outputPanel></div>".ToHtmlDocument();
        var nodes = fragment.ToHtmlFragment(document.Body);

        Assert.Equal(2, nodes.Length);
        Assert.Equal("script", nodes[0].GetTagName());
        Assert.Equal("p", nodes[1].GetTagName());
    }

    [Fact]
    public void InnerHtmlShouldConsiderAllElementsOfFragmentsContainingScriptElements()
    {
        var fragment = "<p>Foo</p><script>alert('foo');</script><p>Test</p>";
        var document = "<!DOCTYPE html><div id=outputPanel></div>".ToHtmlDocument();
        document.Body.InnerHtml = fragment;
        var nodes = document.Body.ChildNodes;

        Assert.Null(document.QuerySelector("#outputPanel"));
        Assert.Equal(3, nodes.Length);
        Assert.Equal("p", nodes[0].GetTagName());
        Assert.Equal("Foo", nodes[0].TextContent);
        Assert.Equal("script", nodes[1].GetTagName());
        Assert.Equal("p", nodes[2].GetTagName());
        Assert.Equal("Test", nodes[2].TextContent);
    }
}
