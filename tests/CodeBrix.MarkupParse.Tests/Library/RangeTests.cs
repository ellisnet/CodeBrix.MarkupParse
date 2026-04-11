using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class RangeTests
{
    [Fact]
    public void NewRangeIsCollapsedInDocument()
    {
        var document = "<body></body>".ToHtmlDocument();
        var range = document.CreateRange();

        Assert.Equal(0, range.Start);
        Assert.Equal(document, range.Head);
        Assert.Equal(0, range.End);
        Assert.Equal(document, range.Tail);
        Assert.Equal(document, range.CommonAncestor);
        Assert.True(range.IsCollapsed);
    }

    [Fact]
    public void CanSelectRangeWithinTextNode_Issue1118()
    {
        var document = "<body></body>".ToHtmlDocument();
        var text = document.Body.AppendChild(document.CreateTextNode("this is a test"));
        var range = document.CreateRange();
        range.StartWith(text, 5);

        Assert.Equal(5, range.Start);
        Assert.Equal(text, range.Head);
        Assert.Equal(5, range.End);
        Assert.Equal(text, range.Tail);
        Assert.Equal(text, range.CommonAncestor);
        Assert.True(range.IsCollapsed);
    }

    [Fact]
    public void CanSelectSomeRange_Issue1119()
    {
        var document = "<body><p><em>Text1</em>Text2</p></body>".ToHtmlDocument();
        var common = document.QuerySelector("p");
        var text1 = document.QuerySelector("em").FirstChild;
        var text2 = common.LastChild;
        var range = document.CreateRange();
        range.StartBefore(text1);
        range.EndBefore(text2);

        Assert.Equal(0, range.Start);
        Assert.Equal(text1.Parent, range.Head);
        Assert.Equal(1, range.End);
        Assert.Equal(text2.Parent, range.Tail);
        Assert.Equal(common, range.CommonAncestor);
        Assert.False(range.IsCollapsed);
    }

    [Fact]
    public void CanSelectSomeRange_Issue1147()
    {
        var document = "<body></body>".ToHtmlDocument();
        var text1 = document.Body.AppendChild(document.CreateTextNode("Text1"));
        var text2 = document.Body.AppendChild(document.CreateTextNode("TextLonger2"));
        var range1 = document.CreateRange();
        var range2 = document.CreateRange();
        range1.StartWith(text1, "Text".Length);
        range1.EndWith(text2, "TextLonger".Length);
        range2.StartWith(text1, "Text".Length);
        range2.EndWith(text2, "TextLonger".Length);
        range2.StartWith(text2, "TextLonger2".Length);

        Assert.Equal("Text".Length, range1.Start);
        Assert.Equal(text1, range1.Head);
        Assert.Equal("TextLonger".Length, range1.End);
        Assert.Equal(text2, range1.Tail);
        Assert.Equal(document.Body, range1.CommonAncestor);
        Assert.False(range1.IsCollapsed);
        Assert.Equal("TextLonger2".Length, range2.Start);
        Assert.Equal("TextLonger2".Length, range2.End);
        Assert.True(range2.IsCollapsed);
    }

    [Fact]
    public void CheckCommonAncestor()
    {
        var document = "<body></body>".ToHtmlDocument();
        var p1 = document.Body.AppendChild(document.CreateElement("p"));
        var p2 = document.Body.AppendChild(document.CreateElement("p"));
        var p11 = p1.AppendChild(document.CreateElement("p"));
        var p12 = p1.AppendChild(document.CreateElement("p"));
        var p21 = p2.AppendChild(document.CreateElement("p"));

        var range1 = document.CreateRange();
        var range2 = document.CreateRange();

        range1.StartAfter(p11);
        range1.EndBefore(p12);
        range2.StartAfter(p11);
        range2.EndBefore(p21);

        Assert.Equal(p1, range1.CommonAncestor);
        Assert.Equal(document.Body, range2.CommonAncestor);
    }

    [Fact]
    public void CanIntersects()
    {
        var document = "<body></body>".ToHtmlDocument();
        var p1 = document.Body.AppendChild(document.CreateElement("p"));
        var p2 = document.Body.AppendChild(document.CreateElement("p"));
        var p3 = document.Body.AppendChild(document.CreateElement("p"));

        var range1 = document.CreateRange();
        var range2 = document.CreateRange();

        range1.StartAfter(p1);
        range1.EndBefore(p3);
        range2.StartWith(p1, 0);
        range2.EndWith(p3, 0);

        Assert.False(range1.Intersects(p1));
        Assert.True(range1.Intersects(p2));
        Assert.False(range1.Intersects(p3));
        Assert.True(range1.Intersects(document.Body));

        Assert.True(range2.Intersects(p1));
        Assert.True(range2.Intersects(p2));
        Assert.True(range2.Intersects(p3));
        Assert.True(range2.Intersects(document.Body));
    }

    [Fact]
    public void CanContains()
    {
        var document = "<body></body>".ToHtmlDocument();
        var p1 = document.Body.AppendChild(document.CreateElement("p"));
        var p2 = document.Body.AppendChild(document.CreateElement("p"));
        var p3 = document.Body.AppendChild(document.CreateElement("p"));

        var range1 = document.CreateRange();
        var range2 = document.CreateRange();
        var range3 = document.CreateRange();

        range1.StartAfter(p1);
        range1.EndBefore(p3);
        range2.StartWith(p1, 0);
        range2.EndWith(p3, 0);
        range3.Select(document.Body);

        Assert.False(range1.Contains(p1, 0));
        Assert.True(range1.Contains(p2, 0));
        Assert.False(range1.Contains(p3, 0));
        Assert.False(range1.Contains(document.Body, 0));

        Assert.False(range2.Contains(p1, 0));
        Assert.True(range2.Contains(p2, 0));
        Assert.False(range2.Contains(p3, 0));
        Assert.False(range2.Contains(document.Body, 0));

        Assert.True(range3.Contains(p1, 0));
        Assert.True(range3.Contains(p2, 0));
        Assert.True(range3.Contains(p3, 0));
        Assert.True(range3.Contains(document.Body, 0));
    }

    [Fact]
    public void CanClearContent()
    {
        var document = @"
<html>
<head></head>
<body>
<p> No deletion before start <span id=""start""></span> This should be cleared </p>
<p> <span id=""toDelete""></span>This should be deleted too <span id=""end""></span> This is not to be deleted</p>
<p> This should not be deleted either</p>
</body>
</html>".ToHtmlDocument();
        var start = document.QuerySelector("#start");
        var end = document.QuerySelector("#end");
        var toDelete = document.QuerySelector("#toDelete");

        var range = document.CreateRange();

        range.StartWith(start, 0);
        range.EndWith(end, 0);

        range.ClearContent();

        var htmlRaw = document.DocumentElement.OuterHtml;
        Assert.Contains("No deletion before start", htmlRaw);
        Assert.Contains("This is not to be deleted", htmlRaw);
        Assert.Contains("This should not be deleted either", htmlRaw);
        Assert.DoesNotContain("This should be cleared", htmlRaw);
        Assert.DoesNotContain("This should be deleted too", htmlRaw);
        Assert.False(document.Contains(toDelete));
    }
}
