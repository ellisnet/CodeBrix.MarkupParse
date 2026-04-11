using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Html.Parser.Tokens;
using CodeBrix.MarkupParse.Text;
using Xunit;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class HtmlTokenizationTests
{
    private static HtmlTokenizer CreateTokenizer(TextSource source)
    {
        return new HtmlTokenizer(source, HtmlEntityProvider.Resolver);
    }

    [Fact]
    public void TokenizationCarriageReturnPureCharactersIssue_786()
    {
        var ms = new MemoryStream(Encoding.UTF8.GetBytes("\r\nThis is test 1\r\nThis is test 2"));
        var s = new TextSource(ms);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Character, token.Type);
        Assert.Equal("\nThis is test 1\nThis is test 2", token.Data);
    }

    [Fact]
    public void TokenizationCarriageWithTextSourceIssue_786()
    {
        var ms = new MemoryStream(Encoding.UTF8.GetBytes("\r\nThis is test 1\r\nThis is test 2"));
        var s = new TextSource(ms);
        var t = CreateTokenizer(s);
        var token = t.Get();
        var start = token.Position.Index;
        var text = s.Text.Substring(start, s.Index - start);
        Assert.Equal("\r\nThis is test 1\r\nThis is test 2", text);
    }

    [Fact]
    public void TokenizationCarriageReturnNonLeadingIssue_786()
    {
        var ms = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><p>\r\nThis is test 1<p> \r\nThis is test 2</body></html>"));
        var s = new TextSource(ms);
        var t = CreateTokenizer(s);
        var tokenHtmlOpen = t.Get();
        var tokenBodyOpen = t.Get();
        var tokenP1 = t.Get();
        var tokenP1data = t.Get();
        var tokenP2 = t.Get();
        var tokenP2data = t.Get();
        var tokenBodyClose = t.Get();
        var tokenHtmlClose = t.Get();
        var eof = t.Get();
        Assert.Equal(HtmlTokenType.EndTag, tokenHtmlClose.Type);
        Assert.Equal(HtmlTokenType.StartTag, tokenHtmlOpen.Type);
        Assert.Equal(HtmlTokenType.EndTag, tokenBodyClose.Type);
        Assert.Equal(HtmlTokenType.StartTag, tokenBodyOpen.Type);
        Assert.Equal(HtmlTokenType.StartTag, tokenP1.Type);
        Assert.Equal(HtmlTokenType.StartTag, tokenP2.Type);
        Assert.Equal(HtmlTokenType.Character, tokenP1data.Type);
        Assert.Equal(HtmlTokenType.Character, tokenP2data.Type);
        Assert.Equal(HtmlTokenType.EndOfFile, eof.Type);
        Assert.Equal("\nThis is test 1", tokenP1data.Data);
        Assert.Equal(" \nThis is test 2", tokenP2data.Data);
    }

    [Fact]
    public void TokenizationFinalEOF()
    {
        var s = new TextSource("");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.EndOfFile, token.Type);
    }
    [Fact]
    public void TokenizationLongerCharacterReference()
    {
        var content = "&abcdefghijklmnopqrstvwxyzABCDEFGHIJKLMNOPQRSTV;";
        var s = new TextSource(content);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Character, token.Type);
        Assert.Equal(content, token.Data);
    }

    [Fact]
    public void TokenizationStartTagDetection()
    {
        var s = new TextSource("<p>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.StartTag, token.Type);
        Assert.Equal("p", ((HtmlTagToken)token).Name);
    }

    [Fact]
    public void TokenizationBogusCommentEmpty()
    {
        var s = new TextSource("<!>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Comment, token.Type);
        Assert.Equal(string.Empty, token.Data);
    }

    [Fact]
    public void TokenizationBogusCommentQuestionMark()
    {
        var s = new TextSource("<?>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Comment, token.Type);
        Assert.Equal("?", token.Data);
    }

    [Fact]
    public void TokenizationBogusCommentClosingTag()
    {
        var s = new TextSource("</ >");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Comment, token.Type);
        Assert.Equal(" ", token.Data);
    }

    [Fact]
    public void TokenizationTagNameDetection()
    {
        var s = new TextSource("<span>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal("span", ((HtmlTagToken)token).Name);
    }

    [Fact]
    public void TokenizationTagSelfClosingDetected()
    {
        var s = new TextSource("<img />");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.True(((HtmlTagToken)token).IsSelfClosing);
    }

    [Fact]
    public void TokenizationAttributesDetected()
    {
        var s = new TextSource("<a target='_blank' href='http://whatever' title='ho'>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(3, ((HtmlTagToken)token).Attributes.Count);
    }

    [Fact]
    public void TokenizationAttributePositionsFoundSameLine()
    {
        var s = new TextSource("<a target='_blank' href='http://whatever' title='ho'>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        var attrs = ((HtmlTagToken)token).Attributes;
        Assert.Equal(new TextPosition(1, 4, 4), attrs[0].Position);
        Assert.Equal(new TextPosition(1, 20, 20), attrs[1].Position);
        Assert.Equal(new TextPosition(1, 43, 43), attrs[2].Position);
    }

    [Fact]
    public void TokenizationAttributePositionsFoundOtherLine()
    {
        var s = new TextSource("<a target='_blank'\nhref='http://whatever'\n title='ho'>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        var attrs = ((HtmlTagToken)token).Attributes;
        Assert.Equal(new TextPosition(1, 4, 4), attrs[0].Position);
        Assert.Equal(new TextPosition(2, 1, 20), attrs[1].Position);
        Assert.Equal(new TextPosition(3, 2, 44), attrs[2].Position);
    }

    [Fact]
    public void TokenizationAttributePositionsFoundAdditionalSpacesInOtherLine()
    {
        var s = new TextSource("<a target='_blank'   \n href='http://whatever'\n    title='ho'>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        var attrs = ((HtmlTagToken)token).Attributes;
        Assert.Equal(new TextPosition(1, 4, 4), attrs[0].Position);
        Assert.Equal(new TextPosition(2, 2, 24), attrs[1].Position);
        Assert.Equal(new TextPosition(3, 5, 51), attrs[2].Position);
    }

    [Fact]
    public void TokenizationAttributeNameDetection()
    {
        var s = new TextSource("<input required>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal("required", ((HtmlTagToken)token).Attributes[0].Name);
    }

    [Fact]
    public void TokenizationTagMixedCaseHandling()
    {
        var s = new TextSource("<InpUT>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal("input", ((HtmlTagToken)token).Name);
    }

    [Fact]
    public void TokenizationTagSpacesBehind()
    {
        var s = new TextSource("<i   >");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal("i", ((HtmlTagToken)token).Name);
    }

    [Fact]
    public void TokenizationCharacterReferenceNotin()
    {
        var str = string.Empty;
        var src = "I'm &notin; I tell you";
        var s = new TextSource(src);
        var t = CreateTokenizer(s);
        var token = default(HtmlToken);

        do
        {
            token = t.Get();

            if (token.Type == HtmlTokenType.Character)
            {
                str += token.Data;
            }
        }
        while (token.Type != HtmlTokenType.EndOfFile);

        Assert.Equal("I'm ∉ I tell you", str);
    }

    [Fact]
    public void TokenizationCharacterReferenceNotIt()
    {
        var str = string.Empty;
        var src = "I'm &notit; I tell you";
        var s = new TextSource(src);
        var t = CreateTokenizer(s);
        var token = default(HtmlToken);

        do
        {
            token = t.Get();

            if (token.Type == HtmlTokenType.Character)
            {
                str += token.Data;
            }
        }
        while (token.Type != HtmlTokenType.EndOfFile);

        Assert.Equal("I'm ¬it; I tell you", str);
    }

    [Fact]
    public void TokenizationDoctypeDetected()
    {
        var s = new TextSource("<!doctype html>");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Doctype, token.Type);
    }

    [Fact]
    public void TokenizationCommentDetected()
    {
        var s = new TextSource("<!-- hi my friend -->");
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Comment, token.Type);
    }

    [Fact]
    public void TokenizationCDataDetected()
    {
        var s = new TextSource("<![CDATA[hi mum how <!-- are you doing />]]>");
        var t = CreateTokenizer(s);
        t.IsAcceptingCharacterData = true;
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Character, token.Type);
    }

    [Fact]
    public void TokenizationCDataCorrectCharacters()
    {
        var sb = new StringBuilder();
        var s = new TextSource("<![CDATA[hi mum how <!-- are you doing />]]>");
        var t = CreateTokenizer(s);
        var token = default(HtmlToken);
        t.IsAcceptingCharacterData = true;

        do
        {
            token = t.Get();

            if (token.Type == HtmlTokenType.Character)
            {
                sb.Append(token.Data);
            }
        }
        while (token.Type != HtmlTokenType.EndOfFile);

        Assert.Equal("hi mum how <!-- are you doing />", sb.ToString());
    }

    [Fact]
    public void TokenizationUnusualDoctype()
    {
        var s = new TextSource("<!DOCTYPE root_element SYSTEM \"DTD_location\">");
        var t = CreateTokenizer(s);
        var e = t.Get();
        Assert.Equal(HtmlTokenType.Doctype, e.Type);
        var d = (HtmlDoctypeToken)e;
        Assert.NotNull(d.Name);
        Assert.Equal("root_element", d.Name);
        Assert.False(d.IsSystemIdentifierMissing);
        Assert.Equal("DTD_location", d.SystemIdentifier);
    }

    [Fact]
    public void TokenizationOnlyCarriageReturn()
    {
        var s = new TextSource("\r");
        var t = CreateTokenizer(s);
        var e = t.Get();
        Assert.Equal(HtmlTokenType.Character, e.Type);
        Assert.Equal("\n", e.Data);
    }

    [Fact]
    public void TokenizationOnlyLineFeed()
    {
        var s = new TextSource("\n");
        var t = CreateTokenizer(s);
        var e = t.Get();
        Assert.Equal(HtmlTokenType.Character, e.Type);
        Assert.Equal("\n", e.Data);
    }

    [Fact]
    public void TokenizationCarriageReturnLineFeed()
    {
        var s = new TextSource("\r\n");
        var t = CreateTokenizer(s);
        var e = t.Get();
        Assert.Equal(HtmlTokenType.Character, e.Type);
        Assert.Equal("\n", e.Data);
    }

    [Fact]
    public async Task TokenizationChangeEncodingWithMultibyteCharacter()
    {
        var phrase = "ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ";  // 78 bytes
        var content = string.Concat(Enumerable.Repeat(phrase, 53));    // x53 => 4134 bytes
        var encoding = new UTF8Encoding(false);
        using var contentStm = new MemoryStream(encoding.GetBytes(content));
        var s = new TextSource(contentStm, encoding);
        var t = CreateTokenizer(s);
        // Read 4096 bytes to buffer
        await s.PrefetchAsync(100, CancellationToken.None);
        // Change encoding utf-8 to utf-8. (Same, but different instance)
        s.CurrentEncoding = TextEncoding.Utf8;
        var token = t.Get();
        Assert.True(s.CurrentEncoding == TextEncoding.Utf8);
        Assert.True(s.CurrentEncoding != encoding);
        Assert.Equal(content, token.Data);
    }

    [Fact]
    public void TokenizationLongestLegalCharacterReference()
    {
        var content = "&CounterClockwiseContourIntegral;";
        var s = new TextSource(content);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Character, token.Type);
        Assert.Equal("∳", token.Data);
    }

    [Fact]
    public void TokenizationLongestIllegalCharacterReference()
    {
        var content = "&CounterClockwiseContourIntegralWithWrongName;";
        var s = new TextSource(content);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.Equal(HtmlTokenType.Character, token.Type);
        Assert.Equal("&CounterClockwiseContourIntegralWithWrongName;", token.Data);
    }

    [Fact]
    public void TokenizationWithReallyLongAttributeShouldNotBreak()
    {
        var content = Assets.GetManifestResourceString("Html.HtmlTokenization.TokenizationWithReallyLongAttributeShouldNotBreak.txt");
        var s = new TextSource(content);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.NotNull(token);
        Assert.IsAssignableFrom<HtmlTagToken>(token);
    }

    [Fact]
    public void TokenizationWithManyAttributesShouldNotBreak()
    {
        var content = Assets.GetManifestResourceString("Html.HtmlTokenization.TokenizationWithManyAttributesShouldNotBreak.txt");
        var s = new TextSource(content);
        var t = CreateTokenizer(s);
        var token = t.Get();
        Assert.NotNull(token);
        Assert.IsAssignableFrom<HtmlTagToken>(token);
    }
}
