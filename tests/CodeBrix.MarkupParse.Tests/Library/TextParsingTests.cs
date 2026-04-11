using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Text;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class TextParsingTests
{
    [Fact]
    public void TextSourceJustIteratesOverCharacters()
    {
        var str = "img\r\n{";
        var source = new TextSource(str);

        Assert.Equal(0, source.Index);

        var i = source.ReadCharacter();
        var m = source.ReadCharacter();
        var g = source.ReadCharacter();
        var carriageReturn = source.ReadCharacter();
        var newline = source.ReadCharacter();
        var openBracket = source.ReadCharacter();
        var eof = source.ReadCharacter();
        var stillEof = source.ReadCharacter();

        Assert.Equal('i', i);
        Assert.Equal('m', m);
        Assert.Equal('g', g);
        Assert.Equal('\r', carriageReturn);
        Assert.Equal('\n', newline);
        Assert.Equal('{', openBracket);
        Assert.Equal(Symbols.EndOfFile, eof);
        Assert.Equal(Symbols.EndOfFile, stillEof);
    }

    [Fact]
    public void TokenizerTreatsCarriageReturnNewlineAsNewline()
    {
        var str = "img\r\n{";
        var source = new TextSource(str);
        var tokenizer = new ExampleTokenizer(source);

        var i = tokenizer.Next();
        var m = tokenizer.Next();
        var g = tokenizer.Next();
        var newline = tokenizer.Next();
        var previousG = tokenizer.Previous();
        var newlineAgain = tokenizer.Next();
        var openBracket = tokenizer.Next();
        var eof = tokenizer.Next();
        var stillEof = tokenizer.Next();

        Assert.Equal('i', i);
        Assert.Equal('m', m);
        Assert.Equal('g', g);
        Assert.Equal('\n', newline);
        Assert.Equal('g', previousG);
        Assert.Equal('\n', newlineAgain);
        Assert.Equal('{', openBracket);
        Assert.Equal(Symbols.EndOfFile, eof);
        Assert.Equal(Symbols.EndOfFile, stillEof);
    }

    class ExampleTokenizer(TextSource source) : BaseTokenizer(source)
    {
        public char Next() => GetNext();

        public char Previous() => GetPrevious();
    }
}
