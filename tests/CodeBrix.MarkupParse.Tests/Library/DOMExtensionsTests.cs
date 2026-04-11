using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class DOMExtensionsTests
{
    [Fact]
    public void ExtensionAttrWithEmptyList()
    {
        var document = "".ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Attr("test", "test");
        Assert.Empty(elements);
    }

    [Fact]
    public void ExtensionBeforeWithSimpleElements()
    {
        var document = @"<div class='container'>
  <h2>Greetings</h2>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>".ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(3, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        inner.Before("<p>Test</p>");
        Assert.Equal(5, container.ChildElementCount);
        Assert.Equal("p", inner[0].PreviousElementSibling.GetTagName());
        Assert.Equal("p", inner[1].PreviousElementSibling.GetTagName());
    }

    [Fact]
    public void ExtensionAfterWithSimpleElements()
    {
        var document = @"<div class='container'>
  <h2>Greetings</h2>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>".ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(3, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        inner.After("<p>Test</p>");
        Assert.Equal(5, container.ChildElementCount);
        Assert.Equal("p", inner[0].NextElementSibling.GetTagName());
        Assert.Equal("p", inner[1].NextElementSibling.GetTagName());
    }

    [Fact]
    public void ExtensionAppendWithSimpleElements()
    {
        var document = @"<div class='container'>
  <h2>Greetings</h2>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>".ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(3, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        Assert.Equal(0, inner[0].ChildElementCount);
        Assert.Equal(0, inner[1].ChildElementCount);
        Assert.Single(inner[0].ChildNodes);
        Assert.Single(inner[1].ChildNodes);
        inner.Append("<p>Test</p>");
        Assert.Equal(3, container.ChildElementCount);
        Assert.Equal(1, inner[0].ChildElementCount);
        Assert.Equal(1, inner[1].ChildElementCount);
        Assert.Equal(2, inner[0].ChildNodes.Length);
        Assert.Equal(2, inner[1].ChildNodes.Length);
        Assert.Equal("p", inner[0].ChildNodes[1].GetTagName());
        Assert.Equal("p", inner[1].ChildNodes[1].GetTagName());
    }

    [Fact]
    public void ExtensionPrependWithSimpleElements()
    {
        var document = @"<div class='container'>
  <h2>Greetings</h2>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>".ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(3, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        Assert.Equal(0, inner[0].ChildElementCount);
        Assert.Equal(0, inner[1].ChildElementCount);
        Assert.Single(inner[0].ChildNodes);
        Assert.Single(inner[1].ChildNodes);
        inner.Prepend("<p>Test</p>");
        Assert.Equal(3, container.ChildElementCount);
        Assert.Equal(1, inner[0].ChildElementCount);
        Assert.Equal(1, inner[1].ChildElementCount);
        Assert.Equal(2, inner[0].ChildNodes.Length);
        Assert.Equal(2, inner[1].ChildNodes.Length);
        Assert.Equal("p", inner[0].ChildNodes[0].GetTagName());
        Assert.Equal("p", inner[1].ChildNodes[0].GetTagName());
    }

    [Fact]
    public void ExtensionWrapWithSimpleElements()
    {
        var document = (@"<div class='container'>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>").ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(2, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        inner.Wrap("<div class='new'></div>");
        Assert.Equal(2, container.ChildElementCount);
        Assert.Equal("div", container.Children[0].GetTagName());
        Assert.Equal("new", container.Children[0].ClassName);
        Assert.Equal("div", container.Children[1].GetTagName());
        Assert.Equal("new", container.Children[1].ClassName);
        Assert.Equal(1, container.Children[0].ChildElementCount);
        Assert.Equal("Hello", container.Children[0].FirstElementChild.TextContent);
        Assert.Equal(1, container.Children[1].ChildElementCount);
        Assert.Equal("Goodbye", container.Children[1].FirstElementChild.TextContent);
    }

    [Fact]
    public void ExtensionWrapWithSimpleText()
    {
        var document = (@"<p>Hello</p>
<p>cruel</p>
<p>World</p>").ToHtmlDocument();
        var body = document.Body;
        Assert.Equal(3, body.ChildElementCount);
        var p = document.QuerySelectorAll("p");
        Assert.Equal("p", body.Children[0].GetTagName());
        Assert.Equal("p", body.Children[1].GetTagName());
        Assert.Equal("p", body.Children[2].GetTagName());
        p.Wrap("<div></div>");
        Assert.Equal(3, body.ChildElementCount);
        Assert.Equal("div", body.Children[0].GetTagName());
        Assert.Equal("div", body.Children[1].GetTagName());
        Assert.Equal("div", body.Children[2].GetTagName());
        Assert.Equal(1, body.Children[0].ChildElementCount);
        Assert.Equal(1, body.Children[1].ChildElementCount);
        Assert.Equal(1, body.Children[2].ChildElementCount);
        Assert.Equal("Hello", body.Children[0].FirstElementChild.TextContent);
        Assert.Equal("cruel", body.Children[1].FirstElementChild.TextContent);
        Assert.Equal("World", body.Children[2].FirstElementChild.TextContent);
    }

    [Fact]
    public void ExtensionWrapWithComplexElements()
    {
        var document = (@"<span>Span Text</span>
<strong>What about me?</strong>
<span>Another One</span>").ToHtmlDocument();
        var body = document.Body;
        Assert.Equal(3, body.ChildElementCount);
        var span = document.QuerySelectorAll("span");
        Assert.Equal("span", body.Children[0].GetTagName());
        Assert.Equal("strong", body.Children[1].GetTagName());
        Assert.Equal("span", body.Children[2].GetTagName());
        span.Wrap("<div><div><p><em><b></b></em></p></div></div>");
        Assert.Equal(3, body.ChildElementCount);
        Assert.Equal("div", body.Children[0].GetTagName());
        Assert.Equal("strong", body.Children[1].GetTagName());
        Assert.Equal("div", body.Children[2].GetTagName());
        Assert.Equal(1, body.Children[0].ChildElementCount);
        Assert.Equal(0, body.Children[1].ChildElementCount);
        Assert.Equal(1, body.Children[2].ChildElementCount);
        var bold = document.QuerySelectorAll("b");
        Assert.Equal(2, bold.Length);
        Assert.Equal(1, bold[0].ChildElementCount);
        Assert.Equal(1, bold[1].ChildElementCount);
        Assert.Equal("span", bold[0].FirstElementChild.GetTagName());
        Assert.Equal("span", bold[1].FirstElementChild.GetTagName());
        Assert.Equal("Span Text", bold[0].FirstElementChild.TextContent);
        Assert.Equal("Another One", bold[1].FirstElementChild.TextContent);
    }

    [Fact]
    public void ExtensionWrapInnerWithSimpleElements()
    {
        var document = (@"<div class='container'>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>").ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(2, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        inner.WrapInner("<div class='new'></div>");
        Assert.Equal(2, container.ChildElementCount);
        Assert.Equal("div", container.Children[0].GetTagName());
        Assert.Equal("inner", container.Children[0].ClassName);
        Assert.Equal(1, container.Children[0].ChildElementCount);
        Assert.Equal("div", container.Children[0].FirstElementChild.GetTagName());
        Assert.Equal("new", container.Children[0].FirstElementChild.ClassName);
        Assert.Equal("Hello", container.Children[0].FirstElementChild.TextContent);
        Assert.Equal("div", container.Children[1].GetTagName());
        Assert.Equal("inner", container.Children[1].ClassName);
        Assert.Equal(1, container.Children[1].ChildElementCount);
        Assert.Equal("div", container.Children[1].FirstElementChild.GetTagName());
        Assert.Equal("new", container.Children[1].FirstElementChild.ClassName);
        Assert.Equal("Goodbye", container.Children[1].FirstElementChild.TextContent);
    }

    [Fact]
    public void ExtensionWrapInnerWithSimpleText()
    {
        var document = (@"<p>Hello</p>
<p>cruel</p>
<p>World</p>").ToHtmlDocument();
        var body = document.Body;
        Assert.Equal(3, body.ChildElementCount);
        var p = document.QuerySelectorAll("p");
        Assert.Equal("p", body.Children[0].GetTagName());
        Assert.Equal("p", body.Children[1].GetTagName());
        Assert.Equal("p", body.Children[2].GetTagName());
        p.WrapInner("<b></b>");
        Assert.Equal(3, body.ChildElementCount);

        Assert.Equal("p", body.Children[0].GetTagName());
        Assert.Equal(1, body.Children[0].ChildElementCount);
        Assert.Equal("p", body.Children[1].GetTagName());
        Assert.Equal(1, body.Children[1].ChildElementCount);
        Assert.Equal("p", body.Children[2].GetTagName());
        Assert.Equal(1, body.Children[2].ChildElementCount);

        Assert.Equal("b", body.Children[0].FirstElementChild.GetTagName());
        Assert.Equal(0, body.Children[0].FirstElementChild.ChildElementCount);
        Assert.Equal("Hello", body.Children[0].FirstElementChild.TextContent);
        Assert.Equal("b", body.Children[1].FirstElementChild.GetTagName());
        Assert.Equal(0, body.Children[1].FirstElementChild.ChildElementCount);
        Assert.Equal("cruel", body.Children[1].FirstElementChild.TextContent);
        Assert.Equal("b", body.Children[2].FirstElementChild.GetTagName());
        Assert.Equal(0, body.Children[2].FirstElementChild.ChildElementCount);
        Assert.Equal("World", body.Children[2].FirstElementChild.TextContent);
    }

    [Fact]
    public void ExtensionWrapAllWithSimpleElements()
    {
        var document = (@"<div class='container'>
  <div class='inner'>Hello</div>
  <div class='inner'>Goodbye</div>
</div>").ToHtmlDocument();
        var container = document.QuerySelector(".container");
        Assert.Equal(2, container.ChildElementCount);
        var inner = document.QuerySelectorAll(".inner");
        inner.WrapAll("<div class='new' />");
        Assert.Equal(1, container.ChildElementCount);
        Assert.Equal("div", container.FirstElementChild.GetTagName());
        Assert.Equal("new", container.FirstElementChild.ClassName);
        Assert.Equal(2, container.FirstElementChild.ChildElementCount);
        Assert.Equal("Hello", container.FirstElementChild.Children[0].TextContent);
        Assert.Equal("Goodbye", container.FirstElementChild.Children[1].TextContent);
    }

    [Fact]
    public void ExtensionWrapAllWithComplexElements()
    {
        var document = (@"<span>Span Text</span>
<strong>What about me?</strong>
<span>Another One</span>").ToHtmlDocument();
        Assert.Equal(3, document.Body.ChildElementCount);
        var span = document.QuerySelectorAll("span");
        span.WrapAll("<div><div><p><em><b></b></em></p></div></div>");
        Assert.Equal(2, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.FirstElementChild.GetTagName());
        var bold = document.QuerySelector("b");
        Assert.NotNull(bold);
        Assert.Equal(2, bold.ChildElementCount);
        Assert.Equal("Span Text", bold.Children[0].TextContent);
        Assert.Equal("Another One", bold.Children[1].TextContent);
    }

    [Fact]
    public void ExtensionAttrGetWithNoElement()
    {
        var document = ("<ul><li id=foo>First element").ToHtmlDocument();
        var ids = document.QuerySelectorAll("ol").Attr("id");
        Assert.Empty(ids);
    }

    [Fact]
    public void ExtensionAttrGetWithNoAttribute()
    {
        var document = ("<ul><li>First element").ToHtmlDocument();
        var ids = document.QuerySelectorAll("li").Attr("id");
        Assert.Single(ids);

        var id = ids.First();
        Assert.Null(id);
    }

    [Fact]
    public void ExtensionAttrGetDataAttribute()
    {
        var document = ("<ul><li data-id=foo>First element").ToHtmlDocument();
        var ids = document.QuerySelectorAll("li").Attr("data-id");
        Assert.Single(ids);

        var id = ids.First();
        Assert.Equal("foo", id);
    }

    [Fact]
    public void ExtensionAttrGetWithOneElement()
    {
        var document = ("<ul><li id=foo>First element").ToHtmlDocument();
        var ids = document.QuerySelectorAll("li").Attr("id");
        Assert.Single(ids);

        var id = ids.First();
        Assert.Equal("foo", id);
    }

    [Fact]
    public void ExtensionAttrGetWithManyElements()
    {
        var document = ("<ul><li id=foo>First element<li id=bar>Second element<li>Third element<li id=baz>Last element").ToHtmlDocument();
        var ids = document.QuerySelectorAll("li").Attr("id").ToArray();
        Assert.Equal(4, ids.Length);

        Assert.Equal("foo", ids[0]);
        Assert.Equal("bar", ids[1]);
        Assert.Null(ids[2]);
        Assert.Equal("baz", ids[3]);
    }

    [Fact]
    public void ExtensionAttrSetWithOneElement()
    {
        var document = ("<ul><li>First element").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Attr("test", "test");
        Assert.Single(elements);

        var attr = elements[0].Attributes;
        Assert.Single(attr);

        var test = attr.First();
        Assert.Equal("test", test.Name);
        Assert.Equal("test", test.Value);
    }

    [Fact]
    public void ExtensionAttrWithOneElementButMultipleAttributes()
    {
        var document = ("<ul><li>First element").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Attr(new
        {
            test1 = "test",
            test2 = "test",
            test3 = string.Empty,
            test4 = 9,
            test5 = true
        });
        Assert.Single(elements);

        var attr = elements[0].Attributes;
        Assert.Equal(5, attr.Count());

        var element = elements[0];
        Assert.Equal("test", element.GetAttribute("test1"));
        Assert.Equal("test", element.GetAttribute("test2"));
        Assert.Equal("", element.GetAttribute("test3"));
        Assert.Equal("9", element.GetAttribute("test4"));
        Assert.Equal("True", element.GetAttribute("test5"));
    }

    [Fact]
    public void ExtensionAttrWithMultipleElements()
    {
        var document = ("<ul><li>First element<li>Second element<li>third<li class=bla>Last").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Attr("test", "test");
        Assert.Equal(4, elements.Count());

        var attr1 = elements[0].Attributes;
        Assert.Single(attr1);

        var test1 = attr1.First();
        Assert.Equal("test", test1.Name);
        Assert.Equal("test", test1.Value);

        var attr2 = elements[1].Attributes;
        Assert.Single(attr2);

        var test2 = attr2.First();
        Assert.Equal("test", test2.Name);
        Assert.Equal("test", test2.Value);

        var attr3 = elements[2].Attributes;
        Assert.Single(attr3);

        var test3 = attr3.First();
        Assert.Equal("test", test3.Name);
        Assert.Equal("test", test3.Value);

        var attr4 = elements[3].Attributes;
        Assert.Equal(2, attr4.Count());

        var cls = attr4.First();
        Assert.Equal("class", cls.Name);
        Assert.Equal("bla", cls.Value);

        var test4 = attr4.Skip(1).First();
        Assert.Equal("test", test4.Name);
        Assert.Equal("test", test4.Value);
    }

    [Fact]
    public void ExtensionTextWithEmptyList()
    {
        var document = ("").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Text("test");
        Assert.Empty(elements);
    }

    [Fact]
    public void ExtensionTextWithOneElement()
    {
        var document = ("<ul><li>First element").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Text("test");
        Assert.Single(elements);

        var text = elements[0].TextContent;
        Assert.Single(elements[0].ChildNodes);
        Assert.Equal("test", text);
    }

    [Fact]
    public void ExtensionTextWithMultipleElements()
    {
        var document = ("<ul><li>First element<li>Second element<li>third<li class=bla>Last").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Text("test");
        Assert.Equal(4, elements.Count());

        var text1 = elements[0].ChildNodes;
        Assert.Single(text1);

        var test1 = text1[0];
        Assert.Equal("test", test1.TextContent);

        var text2 = elements[1].ChildNodes;
        Assert.Single(text2);

        var test2 = text2[0];
        Assert.Equal("test", test2.TextContent);

        var text3 = elements[2].ChildNodes;
        Assert.Single(text3);

        var test3 = text3[0];
        Assert.Equal("test", test3.TextContent);

        var text4 = elements[3].ChildNodes;
        Assert.Single(text4);

        var test4 = text4[0];
        Assert.Equal("test", test4.TextContent);
    }

    [Fact]
    public void ExtensionHtmlWithEmptyList()
    {
        var document = ("").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Html("<p>Some paragraph</p>");
        Assert.Empty(elements);
    }

    [Fact]
    public void ExtensionHtmlWithOneElement()
    {
        var document = ("<ul><li>First element").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Html("<b><i>Text</i></b>");
        Assert.Single(elements);

        var childs = elements[0].ChildNodes;
        Assert.Single(childs);

        var bold = childs[0];
        Assert.Equal(NodeType.Element, bold.NodeType);
        Assert.Equal("b", bold.GetTagName());
        Assert.Single(bold.ChildNodes);

        var italic = bold.ChildNodes[0];
        Assert.Equal(NodeType.Element, italic.NodeType);
        Assert.Equal("i", italic.GetTagName());
        Assert.Single(italic.ChildNodes);

        var text = italic.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Text", text.TextContent);
    }

    [Fact]
    public void ExtensionHtmlWithMultipleElements()
    {
        var document = ("<ul><li>First element<li>Second element<li>third<li class=bla>Last").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Html("<b><i>Text</i></b>");
        Assert.Equal(4, elements.Count());

        for (var i = 0; i < 4; i++)
        {
            Assert.Single(elements[i].ChildNodes);

            var bold = elements[i].ChildNodes[0];
            Assert.Equal(NodeType.Element, bold.NodeType);
            Assert.Equal("b", bold.GetTagName());
            Assert.Single(bold.ChildNodes);

            var italic = bold.ChildNodes[0];
            Assert.Equal(NodeType.Element, italic.NodeType);
            Assert.Equal("i", italic.GetTagName());
            Assert.Single(italic.ChildNodes);

            var text = italic.ChildNodes[0];
            Assert.Equal(NodeType.Text, text.NodeType);
            Assert.Equal("Text", text.TextContent);
        }
    }

    [Fact]
    public void ExtensionHtmlWithMultipleNestedElements()
    {
        var document = ("<ul><li>First element</li><li>Second element</li><li>third</li><li class=bla><ul><li>First nested</li><li>Second nested</li><li><ul><li>Last nesting level</li></ul></li></ul></li>").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Html("<b><i>Text</i></b>");
        Assert.Equal(8, elements.Count());

        for (var i = 0; i < elements.Count(); i++)
        {
            Assert.Single(elements[i].ChildNodes);

            var bold = elements[i].ChildNodes[0];
            Assert.Equal(NodeType.Element, bold.NodeType);
            Assert.Equal("b", bold.GetTagName());
            Assert.Single(bold.ChildNodes);

            var italic = bold.ChildNodes[0];
            Assert.Equal(NodeType.Element, italic.NodeType);
            Assert.Equal("i", italic.GetTagName());
            Assert.Single(italic.ChildNodes);

            var text = italic.ChildNodes[0];
            Assert.Equal(NodeType.Text, text.NodeType);
            Assert.Equal("Text", text.TextContent);
        }

        var elementsInDocument = document.QuerySelectorAll("li");
        Assert.Equal(4, elementsInDocument.Count());

        for (var i = 0; i < elements.Count(); i++)
        {
            Assert.Single(elements[i].ChildNodes);

            var bold = elements[i].ChildNodes[0];
            Assert.Equal(NodeType.Element, bold.NodeType);
            Assert.Equal("b", bold.GetTagName());
            Assert.Single(bold.ChildNodes);

            var italic = bold.ChildNodes[0];
            Assert.Equal(NodeType.Element, italic.NodeType);
            Assert.Equal("i", italic.GetTagName());
            Assert.Single(italic.ChildNodes);

            var text = italic.ChildNodes[0];
            Assert.Equal(NodeType.Text, text.NodeType);
            Assert.Equal("Text", text.TextContent);
        }
    }

    [Fact]
    public void LinqOnChildrenOfQuerySelectorToCollection()
    {
        var document = ("<body><ul><li><li class=foo><li><li class=bar><li>").ToHtmlDocument();
        var elements = document.QuerySelectorAll("li").Where(m => string.IsNullOrEmpty(m.ClassName)).ToCollection();
        Assert.Equal(3, elements.Length);
        Assert.NotEqual("foo", elements[1].ClassName);
    }

    [Fact]
    public void LinqWithChildrenToCollectionStaysLive()
    {
        var document = ("<body><ul><li><li class=foo><li><li class=bar><li>").ToHtmlDocument();
        var list = document.Body.Children[0];
        var elements = list.Children.Where(m => string.IsNullOrEmpty(m.ClassName)).ToCollection();
        Assert.Equal(3, elements.Length);
        list.AppendChild(document.CreateElement("li"));
        Assert.Equal(4, elements.Length);
    }

    [Fact]
    public void ClearAllAttributesOnSingleElementWorks()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#first");
        Assert.Equal(2, element.Attributes.Length);
        element.ClearAttr();
        Assert.Empty(element.Attributes);
    }

    [Fact]
    public void ClearAllAttributesOnMultipleElementsWorks()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var elements = document.QuerySelectorAll("span");

        foreach (var element in elements)
        {
            Assert.NotEqual(0, element.Attributes.Length);
        }

        elements.ClearAttr();

        foreach (var element in elements)
        {
            Assert.Empty(element.Attributes);
        }
    }

    [Fact]
    public void RemoveExistingAttributeYieldsTrue()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#first");
        Assert.Equal(2, element.Attributes.Length);
        var result = element.RemoveAttribute("foo");
        Assert.True(result);
        Assert.Single(element.Attributes);
    }

    [Fact]
    public void RemoveNonExistingAttributeYieldsFalse()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#first");
        Assert.Equal(2, element.Attributes.Length);
        var result = element.RemoveAttribute("bar");
        Assert.False(result);
        Assert.Equal(2, element.Attributes.Length);
    }

    [Fact]
    public void ClearAllAttributesDirectlyWorks()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#first");
        Assert.Equal(2, element.Attributes.Length);
        element.Attributes.Clear();
        Assert.Empty(element.Attributes);
    }

    [Fact]
    public void RemoveExistingAttributeWithNamespaceYieldsTrue()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#second");
        Assert.Single(element.Attributes);
        element.SetAttribute("http://my-namespace", "foo", "bar");
        Assert.Equal(2, element.Attributes.Length);
        var result = element.RemoveAttribute("http://my-namespace", "foo");
        Assert.True(result);
        Assert.Single(element.Attributes);
    }

    [Fact]
    public void RemoveNonExistingAttributeWithNamespaceYieldsFalse()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#second");
        Assert.Single(element.Attributes);
        element.SetAttribute("http://my-namespace", "foo", "bar");
        Assert.Equal(2, element.Attributes.Length);
        var result = element.RemoveAttribute("http://your-namespace", "foo");
        Assert.False(result);
        Assert.Equal(2, element.Attributes.Length);
    }

    [Fact]
    public void ClearAllAttributesOnEmptyCollectionThrowsNoError()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var elements = document.QuerySelectorAll("div");
        Assert.Empty(elements);
        elements.ClearAttr();
    }

    [Fact]
    public void EmptyOnASingleElementRemovesChildren()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var element = document.QuerySelector("#first");
        Assert.Single(element.ChildNodes);
        element.Empty();
        Assert.Empty(element.ChildNodes);
    }

    [Fact]
    public void EmptyOnCollectionWithItselfNestedWorks()
    {
        var document = ("<body><span id=first foo=bar><i>inner</i></span> <span id=second><span class=emphasized>text</span></span>").ToHtmlDocument();
        var elements = document.QuerySelectorAll("span");
        var count = document.All.Length;
        elements.Empty();
        Assert.Equal(count - 2, document.All.Length);
    }
}
