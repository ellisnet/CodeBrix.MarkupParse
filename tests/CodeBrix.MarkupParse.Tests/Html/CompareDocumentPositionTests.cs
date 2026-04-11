using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class CompareDocumentPositionTests
{
    [Fact]
    public void CompareDocumentPositionsWithSameParent()
    {
        var doc = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var parent1 = doc.QuerySelector("#parent-1");
        var parent2 = doc.QuerySelector("#parent-2");

        Assert.Equal(DocumentPositions.Following, parent1.CompareDocumentPosition(parent2));
        Assert.Equal(DocumentPositions.Preceding, parent2.CompareDocumentPosition(parent1));
    }

    [Fact]
    public void CompareDocumentPositionsWithSameNodes()
    {
        var doc = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var parent1 = doc.QuerySelector("#parent-1");
        var child1 = doc.QuerySelector("#child-1");

        Assert.Equal(DocumentPositions.Same, parent1.CompareDocumentPosition(parent1));
        Assert.Equal(DocumentPositions.Same, child1.CompareDocumentPosition(child1));
    }

    [Fact]
    public void CompareDocumentPositionsWithDifferentTrees()
    {
        var doc1 = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();
        var doc2 = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var parent1 = doc1.QuerySelector("#parent-1");
        var parent2 = doc2.QuerySelector("#parent-1");

        var initial = parent1.CompareDocumentPosition(parent2);
        var reverse = parent2.CompareDocumentPosition(parent1);

        if ((initial & DocumentPositions.Preceding) == DocumentPositions.Preceding)
        {
            Assert.Equal(DocumentPositions.ImplementationSpecific | DocumentPositions.Disconnected | DocumentPositions.Preceding, initial);
            Assert.Equal(DocumentPositions.ImplementationSpecific | DocumentPositions.Disconnected | DocumentPositions.Following, reverse);
        }
        else
        {
            Assert.Equal(DocumentPositions.ImplementationSpecific | DocumentPositions.Disconnected | DocumentPositions.Following, initial);
            Assert.Equal(DocumentPositions.ImplementationSpecific | DocumentPositions.Disconnected | DocumentPositions.Preceding, reverse);
        }
    }

    [Fact]
    public void CompareDocumentPositionsWithNestedChildren()
    {
        var doc = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var child1 = doc.QuerySelector("#child-1");
        var child2 = doc.QuerySelector("#child-2");

        Assert.Equal(DocumentPositions.Following, child1.CompareDocumentPosition(child2));
        Assert.Equal(DocumentPositions.Preceding, child2.CompareDocumentPosition(child1));
    }

    [Fact]
    public void CompareDocumentPositionsWithContainingElements()
    {
        var doc = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var parent1 = doc.QuerySelector("#parent-1");
        var child1 = doc.QuerySelector("#child-1");

        Assert.Equal(DocumentPositions.ContainedBy | DocumentPositions.Following, parent1.CompareDocumentPosition(child1));

        var parent2 = doc.QuerySelector("#parent-2");
        var child2 = doc.QuerySelector("#child-2");

        Assert.Equal(DocumentPositions.Contains | DocumentPositions.Preceding, child2.CompareDocumentPosition(parent2));
    }

    [Fact]
    public void CompareDocumentPositionsWithDifferentLevelsOfElements()
    {
        var doc = "<!DOCTYPE html><div id='parent-1'><span id='child-1'>1</span></div><div id='parent-2'><span id='child-2'>2</span></div>".ToHtmlDocument();

        var parent1 = doc.QuerySelector("#parent-1");
        var child2 = doc.QuerySelector("#child-2");

        Assert.Equal(DocumentPositions.Following, parent1.CompareDocumentPosition(child2));
        Assert.Equal(DocumentPositions.Preceding, child2.CompareDocumentPosition(parent1));

        var parent2 = doc.QuerySelector("#parent-2");
        var child1 = doc.QuerySelector("#child-1");

        Assert.Equal(DocumentPositions.Following, child1.CompareDocumentPosition(parent2));
        Assert.Equal(DocumentPositions.Preceding, parent2.CompareDocumentPosition(child1));
    }

    [Fact]
    public void CompareDocumentPositionsHeadBeforeBody()
    {
        var doc = "<!DOCTYPE html><div></div>".ToHtmlDocument();

        var head = doc.Head;
        var body = doc.Body;

        Assert.Equal(DocumentPositions.Following, head.CompareDocumentPosition(body));
    }

    [Fact]
    public void CompareDocumentPositionsFromQuirksMode()
    {
        var doc = @"<div class=testHTML><p id=test class=testClass><b id=testB></b>.</p>
<p id=test2 class=""nonsense testClass""></p>
<p><ppk></ppk></p>
<div id=test></div></div>".ToHtmlDocument();
        var x = doc.QuerySelector("#test");
        var y = doc.QuerySelector("#test2");
        var z = doc.QuerySelector("#testB");

        Assert.Equal(DocumentPositions.Following, x.CompareDocumentPosition(y));
        Assert.Equal(DocumentPositions.Following | DocumentPositions.ContainedBy, x.CompareDocumentPosition(z));
    }

    [Fact]
    public void CompareDocumentPositionsShim()
    {
        var doc = "".ToHtmlDocument();
        var docfrag = doc.CreateDocumentFragment();
        var el = docfrag.AppendChild(doc.CreateElement("div"));
        var txt = docfrag.AppendChild(doc.CreateTextNode("foo"));

        Assert.Equal(DocumentPositions.Contains | DocumentPositions.Preceding, el.CompareDocumentPosition(docfrag));
        Assert.Equal(DocumentPositions.ContainedBy | DocumentPositions.Following, docfrag.CompareDocumentPosition(el));
        Assert.Equal(DocumentPositions.Same, el.CompareDocumentPosition(el));
        Assert.Equal(DocumentPositions.Following, el.CompareDocumentPosition(txt));
    }

    [Fact]
    public void CompareDocumentPositionEmptyQueue()
    {
        var doc = "<!DOCTYPE html><html><head></head><body><div id=\"result\"></div><script></script></body></html>".ToHtmlDocument();
        var div1 = doc.CreateElement("div");
        var div2 = doc.CreateElement("div");
        var result = div1.CompareDocumentPosition(div2);
        Assert.Equal(DocumentPositions.Following, result);
    }
}
