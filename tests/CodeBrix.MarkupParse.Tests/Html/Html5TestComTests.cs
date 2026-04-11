using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/html5test-com.dat
/// </summary>

public class Html5TestComTests
{
    [Fact]
    public void WrongDivTagMistake()
    {
        var doc = (@"<div<div>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodydivdiv = dochtmlbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodydivdiv.ChildNodes);
        Assert.Empty(dochtmlbodydivdiv.Attributes);
        Assert.Equal("div<div", dochtmlbodydivdiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydivdiv.NodeType);
    }

    [Fact]
    public void WrongDivAttributeMistake()
    {
        var doc = (@"<div foo<bar=''>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodydiv = dochtmlbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodydiv.ChildNodes);
        Assert.Single(dochtmlbodydiv.Attributes);
        Assert.Equal("div", dochtmlbodydiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydiv.NodeType);
        Assert.Equal("", dochtmlbodydiv.GetAttribute("foo<bar"));
    }

    [Fact]
    public void WrongDivLetterInAttributeMistake()
    {
        var doc = (@"<div foo=`bar`>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodydiv = dochtmlbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodydiv.ChildNodes);
        Assert.Single(dochtmlbodydiv.Attributes);
        Assert.Equal("div", dochtmlbodydiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydiv.NodeType);
        Assert.Equal("`bar`", dochtmlbodydiv.Attributes.GetNamedItem("foo").Value);
    }

    [Fact]
    public void EntitiesAngles()
    {
        var doc = (@"&lang;&rang;").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal(@"⟨⟩", text.TextContent);
    }

    [Fact]
    public void EntitiesApos()
    {
        var doc = (@"&apos;").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal(@"'", text.TextContent);
    }

    [Fact]
    public void EntitiesKopf()
    {
        var doc = (@"&Kopf;").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal(@"𝕂", text.TextContent);
    }

    [Fact]
    public void EntitiesNotinva()
    {
        var doc = (@"&notinva;").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal(@"∉", text.TextContent);
    }

    [Fact]
    public void BogusCommentAsDoctype()
    {
        var doc = (@"<?import namespace=""foo"" implementation=""#bar"">").ToHtmlDocument();

        var comment = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, comment.NodeType);
        Assert.Equal(@"?import namespace=""foo"" implementation=""#bar""", comment.TextContent);

        var dochtml = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);
    }

    [Fact]
    public void MisplacedCdataSection()
    {
        var doc = (@"<![CDATA[x]]>").ToHtmlDocument();
        var cdata = doc.ChildNodes[0];
        Assert.Empty(cdata.ChildNodes);
        Assert.Equal("[CDATA[x]]", cdata.TextContent);
        Assert.Equal(NodeType.Comment, cdata.NodeType);

        var dochtml = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);
    }

    [Fact]
    public void TextAreaWithComments()
    {
        var doc = (@"<textarea><!--</textarea>--></textarea>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodytextarea = dochtmlbody.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodytextarea.ChildNodes);
        Assert.Empty(dochtmlbodytextarea.Attributes);
        Assert.Equal("textarea", dochtmlbodytextarea.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytextarea.NodeType);

        var text1 = dochtmlbodytextarea.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal(@"<!--", text1.TextContent);

        var text2 = dochtmlbody.ChildNodes[1];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"-->", text2.TextContent);
    }

    [Fact]
    public void UnsortedListWithEntries()
    {
        var doc = (@"<ul><li>A </li> <li>B</li></ul>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodyul = dochtmlbody.ChildNodes[0] as Element;
        Assert.Equal(3, dochtmlbodyul.ChildNodes.Length);
        Assert.Empty(dochtmlbodyul.Attributes);
        Assert.Equal("ul", dochtmlbodyul.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyul.NodeType);

        var dochtmlbodyulli1 = dochtmlbodyul.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyulli1.ChildNodes);
        Assert.Empty(dochtmlbodyulli1.Attributes);
        Assert.Equal("li", dochtmlbodyulli1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyulli1.NodeType);

        var text1 = dochtmlbodyulli1.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal(@"A ", text1.TextContent);

        var text2 = dochtmlbodyul.ChildNodes[1];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@" ", text2.TextContent);

        var dochtmlbodyulli2 = dochtmlbodyul.ChildNodes[2] as Element;
        Assert.Single(dochtmlbodyulli2.ChildNodes);
        Assert.Empty(dochtmlbodyulli2.Attributes);
        Assert.Equal("li", dochtmlbodyulli2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyulli2.NodeType);

        var text3 = dochtmlbodyulli2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal(@"B", text3.TextContent);
    }

    [Fact]
    public void TableWithFormAndInputs()
    {
        var doc = (@"<table><form><input type=hidden><input></form><div></div></table>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(3, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodyinput = dochtmlbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodyinput.ChildNodes);
        Assert.Empty(dochtmlbodyinput.Attributes);
        Assert.Equal("input", dochtmlbodyinput.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyinput.NodeType);

        var dochtmlbodydiv = dochtmlbody.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbodydiv.ChildNodes);
        Assert.Empty(dochtmlbodydiv.Attributes);
        Assert.Equal("div", dochtmlbodydiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydiv.NodeType);

        var dochtmlbodytable = dochtmlbody.ChildNodes[2] as Element;
        Assert.Equal(2, dochtmlbodytable.ChildNodes.Length);
        Assert.Empty(dochtmlbodytable.Attributes);
        Assert.Equal("table", dochtmlbodytable.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytable.NodeType);

        var dochtmlbodytableform = dochtmlbodytable.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodytableform.ChildNodes);
        Assert.Empty(dochtmlbodytableform.Attributes);
        Assert.Equal("form", dochtmlbodytableform.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytableform.NodeType);

        var dochtmlbodytableinput = dochtmlbodytable.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbodytableinput.ChildNodes);
        Assert.Single(dochtmlbodytableinput.Attributes);
        Assert.Equal("input", dochtmlbodytableinput.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytableinput.NodeType);
        Assert.Equal("hidden", dochtmlbodytableinput.Attributes.GetNamedItem("type").Value);
    }

    [Fact]
    public void MathMLTag()
    {
        var doc = (@"<math></math>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);
        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Single(dochtmlbody.ChildNodes);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodymath = dochtmlbody.ChildNodes[0] as Element;
        Assert.True((dochtmlbodymath.Flags & NodeFlags.MathMember) == NodeFlags.MathMember);
        Assert.Equal(NamespaceNames.MathMlUri, dochtmlbodymath.NamespaceUri);
        Assert.Empty(dochtmlbodymath.ChildNodes);
        Assert.Empty(dochtmlbodymath.Attributes);
        Assert.Equal("math", dochtmlbodymath.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodymath.NodeType);
    }

    [Fact]
    public void TabsInClassNames()
    {
        var html = "<html><body><div class=\"class1\tclass2\"></div></body></html>";
        var dom = (html).ToHtmlDocument();
        var div = dom.QuerySelector("div");

        Assert.Equal(2, div.ClassList.Length);
        Assert.True(div.ClassList.Contains("class1"));
        Assert.True(div.ClassList.Contains("class2"));
    }

    [Fact]
    public void NewLinesInClassNames()
    {
        var html = "<html><body><div class=\"class1" + Environment.NewLine + "class2  class3\r\n\t class4\"></div></body></html>";
        var dom = (html).ToHtmlDocument();
        var div = dom.QuerySelector("div");

        Assert.Equal(4, div.ClassList.Length);
        Assert.True(div.ClassList.Contains("class1"));
        Assert.True(div.ClassList.Contains("class4"));
    }

    [Fact]
    public void AutoCloseTwoTagsInARow()
    {
        var html = @" <table id=table-uda>
    <thead>
        <tr>
            <th>Attribute
             <th>Setter Condition
   <tbody><tr><td><dfn id=dom-uda-protocol title=dom-uda-protocol><code>protocol</code></dfn>
     <td><a href=#url-scheme title=url-scheme>&lt;scheme&gt;</a>
     </tr></table>";

        var dom = (html).ToHtmlDocument();

        Assert.Single(dom.QuerySelectorAll("tbody"));
        Assert.Equal("table", dom.QuerySelector("tbody").Parent.GetTagName());
    }

    [Fact]
    public void AutoCreateTableTags()
    {
        var html = @"<table id=table-uda>
        <tr>
            <th>Attribute
             <th>Setter Condition
        <tr><td><dfn id=dom-uda-protocol title=dom-uda-protocol><code>protocol</code></dfn>
     <td><a href=#url-scheme title=url-scheme>&lt;scheme&gt;</a>
     </tr></table>";
        var dom = (html).ToHtmlDocument();

        // should create wrapper
        Assert.Single(dom.QuerySelectorAll("body"));
        Assert.Single(dom.QuerySelectorAll("html"));
        Assert.Single(dom.QuerySelectorAll("head"));
        Assert.Single(dom.QuerySelectorAll("tbody"));
        Assert.Equal(2, dom.QuerySelectorAll("th").Length);
        Assert.Equal(2, dom.QuerySelectorAll("tr").Length);
        Assert.Equal("table", dom.QuerySelector("tbody").Parent.GetTagName());
        Assert.Equal(11, dom.QuerySelectorAll("body *").Length);
    }

    [Fact]
    public void AutoCreateHtmlBody()
    {
        var test = @"<html>
                <head>  
            <script type=""text/javascript"">lf={version: 2064750,baseUrl: '/',helpHtml: '<a class=""email"" href=""mailto:xxxxx@xxxcom"">email</a>',prefs: { pageSize: 0}};

            lf.Scripts={""crypt"":{""path"":""/scripts/thirdp/sha512.min.2009762.js"",""nameSpace"":""Sha512""}};

            </script><link rel=""icon"" type=""image/x-icon"" href=""/favicon.ico""> 

                <title>Title</title>
            <script type=""text/javascript"" src=""/scripts/thirdp/jquery-1.7.1.min.2009762.js""></script>
            <script type=""text/javascript"">var _gaq = _gaq || [];

            _gaq.push(['_setAccount', 'UA-xxxxxxx1']);

            _gaq.push(['_trackPageview']);
            </script>

            </head>

            <body>

            <script type=""text/javascript"">
            alert('done');
            </script>";

        var dom = (test).ToHtmlDocument();
        Assert.Equal(4, dom.QuerySelectorAll("script").Length);
    }

    [Fact]
    public void AutoCreateHead()
    {
        var test = @"<html>
            <script id=script1 type=""text/javascript"" src=""stuff""></script>
            <div id=div1>This should be in the body.</div>";

        var dom = (test).ToHtmlDocument();
        Assert.Equal(dom.QuerySelector("#script1"), dom.QuerySelector("head > :first-child"));
        Assert.Equal(dom.QuerySelector("#div1"), dom.QuerySelector("body > :first-child"));
    }

    [Fact]
    public void AutoCreateBody()
    {
        var test = @"<html>
                <div id=div1>This should be in the body.</div>
                <script id=script1 type=""text/javascript"" src=""stuff""></script>";

        var dom = (test).ToHtmlDocument();

        Assert.Empty(dom.QuerySelector("head").Children);
        Assert.Equal(2, dom.QuerySelector("body").Children.Length);

        Assert.Equal(dom.QuerySelector("#div1"), dom.QuerySelector("body > :first-child"));
    }

    [Fact]
    public void NewLinesInTags()
    {
        var test = @"<table 
                border
                =0 cellspacing=
                ""2"" cellpadding=""2"" width=""100%""><span" + (char)10 + "id=test></span></table>";
        var dom = test.ToHtmlFragment();

        var body = dom.QuerySelector("body");
        Assert.NotNull(body);

        var output = body.InnerHtml;
        Assert.Equal(@"<span id=""test""></span><table border=""0"" cellspacing=""2"" cellpadding=""2"" width=""100%""></table>", output);
    }

    [Fact]
    public void HtmlPageSupportsRoundTripping()
    {
        var originalSourceCode = Assets.selectors;
        var initialDocument = originalSourceCode.ToHtmlDocument();
        var initialSourceCode = initialDocument.ToHtml();
        var finalDocument = initialSourceCode.ToHtmlDocument();
        var finalSourceCode = finalDocument.ToHtml();
        Assert.Equal(initialSourceCode, finalSourceCode);
    }
}
