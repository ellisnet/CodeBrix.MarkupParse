using CodeBrix.MarkupParse.Text;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class CommonExtensionsTests
{
    [Fact]
    public void HexadecimalNumbersWorking()
    {
        for (var i = 0; i < 256; i++)
        {
            var num = (byte)i;
            var a = num.ToHex();
            var b = i.ToString("X").PadLeft(2, '0');
            Assert.Equal(b, a);
        }
    }

    [Fact]
    public void CollapseEmptyString()
    {
        var str = string.Empty;
        var result = str.Collapse();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseNoSpacesString()
    {
        var str = "ThisIsMyString";
        var result = str.Collapse();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseSingleSpacesString()
    {
        var str = "This Is My String";
        var result = str.Collapse();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseMultipleSpacesString()
    {
        var original = "This Is My String";
        var str = "This  Is  My  String";
        var result = str.Collapse();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseMultipleLeadingSpacesString()
    {
        var original = " This Is My String";
        var str = "  This  Is  My  String";
        var result = str.Collapse();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseMultipleTrailingSpacesString()
    {
        var original = "This Is My String ";
        var str = "This  Is  My  String  ";
        var result = str.Collapse();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseMultipleLeadingTrailingSpacesString()
    {
        var original = " This Is My String ";
        var str = "  This  Is  My  String  ";
        var result = str.Collapse();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseStripEmptyString()
    {
        var str = string.Empty;
        var result = str.CollapseAndStrip();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseStripNoSpacesString()
    {
        var str = "ThisIsMyString";
        var result = str.CollapseAndStrip();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseStripSingleSpacesString()
    {
        var str = "This Is My String";
        var result = str.CollapseAndStrip();
        Assert.Equal(str, result);
    }

    [Fact]
    public void CollapseStripMultipleSpacesString()
    {
        var original = "This Is My String";
        var str = "This  Is  My  String";
        var result = str.CollapseAndStrip();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseStripMultipleLeadingSpacesString()
    {
        var original = "This Is My String";
        var str = "  This  Is  My  String";
        var result = str.CollapseAndStrip();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseStripMultipleTrailingSpacesString()
    {
        var original = "This Is My String";
        var str = "This  Is  My  String  ";
        var result = str.CollapseAndStrip();
        Assert.Equal(original, result);
    }

    [Fact]
    public void CollapseStripMultipleLeadingTrailingSpacesString()
    {
        var original = "This Is My String";
        var str = "  This  Is  My  String  ";
        var result = str.CollapseAndStrip();
        Assert.Equal(original, result);
    }

    [Fact]
    public void FromHexNumeric()
    {
        var number = '2';
        var result = number.FromHex();
        Assert.Equal(2, result);
    }

    [Fact]
    public void FromHexLowercase()
    {
        var number = 'c';
        var result = number.FromHex();
        Assert.Equal(12, result);
    }

    [Fact]
    public void FromHexUppercase()
    {
        var number = 'F';
        var result = number.FromHex();
        Assert.Equal(15, result);
    }

    [Fact]
    public void StripLineBreaksWithoutLineBreak()
    {
        var str = "Hi there how are you";
        var result = str.StripLineBreaks();
        Assert.Equal(str, result);
    }

    [Fact]
    public void StripLineBreaksWithLineBreak()
    {
        var str = "Hi\nthere\thow\r\n\nare you";
        var result = str.StripLineBreaks();
        Assert.Equal("Hithere\thoware you", result);
    }

    [Fact]
    public void StripLineBreaksOnlyLineBreak()
    {
        var str = "\r\n\r\n\n\n\r\n";
        var result = str.StripLineBreaks();
        Assert.Equal("", result);
    }

    [Fact]
    public void StripLineBreaksEmptyString()
    {
        var str = "";
        var result = str.StripLineBreaks();
        Assert.Equal(str, result);
    }

    [Fact]
    public void StripLeadingTailingSpacesEmptyString()
    {
        var str = "";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Equal(str, result);
    }

    [Fact]
    public void StripLeadingTailingSpacesSpaceString()
    {
        var str = "       ";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Empty(result);
    }

    [Fact]
    public void StripLeadingTailingSpacesNormalString()
    {
        var str = "Hello how are you";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Equal(str, result);
    }

    [Fact]
    public void StripLeadingTailingSpacesLeadingSpacesString()
    {
        var str = "   What is that";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Equal("What is that", result);
    }

    [Fact]
    public void StripLeadingTailingSpacesTailingSpacesString()
    {
        var str = "How are you   ";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Equal("How are you", result);
    }

    [Fact]
    public void StripLeadingTailingSpacesBothKindOfSpacesString()
    {
        var str = "   Hello how are you    ";
        var result = str.StripLeadingTrailingSpaces();
        Assert.Equal("Hello how are you", result);
    }

    [Fact]
    public void SplitStringOnSpace()
    {
        var str = "Hi there how are you";
        var result = str.SplitWithoutTrimming(' ');
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void SplitStringNothingFound()
    {
        var str = "Hi there how are you";
        var result = str.SplitWithoutTrimming('z');
        Assert.Single(result);
    }

    [Fact]
    public void SplitStringFinalDelimiter()
    {
        var str = "Hi there how are you ";
        var result = str.SplitWithoutTrimming(' ');
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void SplitTrimmingStringOnSpace()
    {
        var str = "Hi there how are you";
        var result = str.SplitWithTrimming(' ');
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void SplitTrimmingStringNothingFound()
    {
        var str = "Hi there how are you";
        var result = str.SplitWithTrimming('z');
        Assert.Single(result);
    }

    [Fact]
    public void SplitTrimmingStringTrimming()
    {
        var str = "Hi;  there how ;are you";
        var result = str.SplitWithTrimming(';');
        Assert.Equal("there how", result[1]);
    }

    [Fact]
    public void SplitTrimmingStringLength()
    {
        var str = "Hi;  there how ;are you";
        var result = str.SplitWithTrimming(';');
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void NormalizeLineEndingsEmptyString()
    {
        var str = "";
        var result = str.NormalizeLineEndings();
        Assert.Equal("", result);
    }

    [Fact]
    public void NormalizeLineEndingsNormalizedSingle()
    {
        var str = "\r\n";
        var result = str.NormalizeLineEndings();
        Assert.Equal("\r\n", result);
    }

    [Fact]
    public void NormalizeLineEndingsSingleCarriageReturn()
    {
        var str = "\r";
        var result = str.NormalizeLineEndings();
        Assert.Equal("\r\n", result);
    }

    [Fact]
    public void NormalizeLineEndingsSingleLineFeed()
    {
        var str = "\n";
        var result = str.NormalizeLineEndings();
        Assert.Equal("\r\n", result);
    }

    [Fact]
    public void NormalizeLineEndingsMixedText()
    {
        var str = "\nHi\rHow are you,\nJohn?\r\nYep, that is a\nnice\rtnetennba\r\n";
        var result = str.NormalizeLineEndings();
        Assert.Equal("\r\nHi\r\nHow are you,\r\nJohn?\r\nYep, that is a\r\nnice\r\ntnetennba\r\n", result);
    }
}
