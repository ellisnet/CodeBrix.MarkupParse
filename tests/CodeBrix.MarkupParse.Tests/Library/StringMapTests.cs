using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class StringMapTests
{
    private HtmlElement a;
    private StringMap stringMap;

    public StringMapTests()
    {
        var document = new HtmlDocument();
        a = new HtmlElement(document, "a");
        a.SetAttribute("data-test1", "test");
        a.SetAttribute("data-b", "b");
        stringMap = new StringMap("data-", a);
    }

    [Fact]
    public void RemoveTest()
    {
        stringMap.Remove("b");
        Assert.Null(a.GetAttribute("data-b"));
    }

    [Fact]
    public void ContainsTest()
    {
        Assert.True(stringMap.Contains("b"));
        Assert.Equal("b", a.GetAttribute("data-b"));
    }

    [Fact]
    public void GetEnumeratorTest()
    {
        foreach (var str in stringMap)
        {
            Assert.Equal(a.GetAttribute("data-" + str.Key), str.Value);
        }
    }
}
