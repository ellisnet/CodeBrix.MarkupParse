using CodeBrix.MarkupParse.Common;
using System;
using System.Text;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library;

public class ArrayPoolBufferTests
{
    [Fact]
    public void CanAppendString()
    {
        using var b = new ArrayPoolBuffer(128);
        b.Append("Hello World!".AsSpan());
        Assert.Equal("Hello World!", b.GetDataAndClear().ToString());
    }

    [Fact]
    public void CanAppendMultipleTimesAndProduceStrings()
    {
        var b = new ArrayPoolBuffer(128);
        b.Append("Hello World!".AsSpan());
        b.Append('!');
        Assert.Equal("Hello World!!", b.GetDataAndClear().ToString());
    }

    [Fact]
    public void CanProduceMultipleStrings()
    {
        var b = new ArrayPoolBuffer(1024);

        for (var i = 0; i < 5; i++)
        {
            b.Append('<');
            b.Append('s');
            b.Append('c');
            b.Append('r');
            b.Append('i');
            b.Append('p');
            b.Append('t');
            b.Append('>');
            Assert.Equal("<script>", b.GetDataAndClear().ToString());

            b.Append('<');
            b.Append('!');
            b.Append('-');
            b.Append('-');
            b.Append('.');
            b.Append('.');
            b.Append('.');
            Assert.Equal("<!--...", b.GetDataAndClear().ToString());

            b.Append('s');
            b.Append('c');
            b.Append('r');
            b.Append('i');
            b.Append('p');
            b.Append('t');
            b.Insert(0, '<');
            b.Insert(1, '/');
            b.Append('>');
            Assert.Equal("</script>", b.GetDataAndClear().ToString());

            b.Append('b');
            b.Append('o');
            b.Append('d');
            b.Append('y');
            b.Insert(0, '<');
            b.Insert(1, '/');
            b.Append('>');
            Assert.Equal("</body>", b.GetDataAndClear().ToString());

            b.Append('n');
            b.Append('o');
            b.Append('f');
            b.Append('r');
            b.Append('a');
            b.Append('m');
            b.Append('e');
            b.Append('s');
            Assert.Equal("noframes", b.GetDataAndClear().ToString());

            b.Append('h');
            b.Append('t');
            b.Append('m');
            b.Append('l');
            Assert.Equal("html", b.GetDataAndClear().ToString());
        }
    }

    [Fact]
    public void CanAppendMultipleTimesWhileDiscarding()
    {
        var b = new ArrayPoolBuffer(16);
        for (var i = 0; i < 1024; i++)
        {
            b.Append('<');
            b.Append('s');
            b.Append('c');
            b.Append('r');
            b.Append('i');
            b.Append('p');
            b.Append('t');
            b.Append('>');
            Assert.True(b.HasText("<script>".AsSpan()));
            b.Discard();

            b.Append('<');
            b.Append('!');
            b.Append('-');
            b.Append('-');
            b.Append('.');
            b.Append('.');
            b.Append('.');
            Assert.True(b.HasText("<!--...".AsSpan()));
            b.Discard();

            b.Append('s');
            b.Append('c');
            b.Append('r');
            b.Append('i');
            b.Append('p');
            b.Append('t');
            b.Insert(0, '<');
            b.Insert(1, '/');
            b.Append('>');
            Assert.True(b.HasText("</script>".AsSpan()));
            b.Discard();

            b.Append('b');
            b.Append('o');
            b.Append('d');
            b.Append('y');
            b.Insert(0, '<');
            b.Insert(1, '/');
            b.Append('>');
            Assert.True(b.HasText("</body>".AsSpan()));
            b.Discard();

            b.Append('n');
            b.Append('o');
            b.Append('f');
            b.Append('r');
            b.Append('a');
            b.Append('m');
            b.Append('e');
            b.Append('s');
            Assert.True(b.HasText("noframes".AsSpan()));
            b.Discard();

            b.Append('h');
            b.Append('t');
            b.Append('m');
            b.Append('l');
            Assert.True(b.HasText("html".AsSpan()));
            b.Discard();
        }        
    }

    [Fact]
    public void ShouldNotCrashForCertainInput_Issue1174()
    {
        var content = Convert.FromBase64String("PHNjcmlwdD58PCEtLTxzY3JpcHQ+AAAAAAAAAAAAAA==");
        var html = Encoding.UTF8.GetString(content);
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        parser.ParseDocument(html.ToCharArray(), 0);
    }
}
