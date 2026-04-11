using CodeBrix.MarkupParse.Io;
using Xunit;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Urls; //Was previously: namespace AngleSharp.Core.Tests.Urls

public class MimeTypeTests
{
    [Fact]
    public void MimeTypeWithOnlyGeneralType()
    {
        var original = "application";
        var mt = new MimeType(original);
        Assert.Equal("application", mt.GeneralType);
        Assert.Equal("", mt.MediaType);
        Assert.Equal("", mt.Suffix);
        Assert.Empty(mt.Keys);
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeInCommonForm()
    {
        var original = "application/html";
        var mt = new MimeType(original);
        Assert.Equal("application", mt.GeneralType);
        Assert.Equal("html", mt.MediaType);
        Assert.Equal("", mt.Suffix);
        Assert.Empty(mt.Keys);
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithSuffix()
    {
        var original = "application/html+xml";
        var mt = new MimeType(original);
        Assert.Equal("application", mt.GeneralType);
        Assert.Equal("html", mt.MediaType);
        Assert.Equal("xml", mt.Suffix);
        Assert.Empty(mt.Keys);
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithSuffixAndParameter()
    {
        var original = "application/html+xml;foo=bar";
        var mt = new MimeType(original);
        Assert.Equal("application", mt.GeneralType);
        Assert.Equal("html", mt.MediaType);
        Assert.Equal("xml", mt.Suffix);
        Assert.Single(mt.Keys);
        Assert.Equal("foo", mt.Keys.First());
        Assert.Equal("bar", mt.GetParameter("foo"));
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithMultipleParameters()
    {
        var original = "application/html;foo=bar;cool=dude";
        var mt = new MimeType(original);
        Assert.Equal("application", mt.GeneralType);
        Assert.Equal("html", mt.MediaType);
        Assert.Equal("", mt.Suffix);
        Assert.Equal(2, mt.Keys.Count());
        Assert.Equal("foo", mt.Keys.First());
        Assert.Equal("cool", mt.Keys.Last());
        Assert.Equal("bar", mt.GetParameter("foo"));
        Assert.Equal("dude", mt.GetParameter("cool"));
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithInvalidFormat()
    {
        var original = "app;yo=there";
        var mt = new MimeType(original);
        Assert.Equal("app;yo=there", mt.GeneralType);
        Assert.Equal("", mt.MediaType);
        Assert.Equal("", mt.Suffix);
        Assert.Empty(mt.Keys);
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithSingleParameter()
    {
        var original = "text/html;yo=there";
        var mt = new MimeType(original);
        Assert.Equal("text", mt.GeneralType);
        Assert.Equal("html", mt.MediaType);
        Assert.Equal("", mt.Suffix);
        Assert.Single(mt.Keys);
        Assert.Equal("yo", mt.Keys.First());
        Assert.Equal("there", mt.GetParameter("yo"));
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeWithRecoveredIllFormat()
    {
        var original = "text/+xml;yo=there";
        var mt = new MimeType(original);
        Assert.Equal("text", mt.GeneralType);
        Assert.Equal("", mt.MediaType);
        Assert.Equal("xml", mt.Suffix);
        Assert.Single(mt.Keys);
        Assert.Equal("yo", mt.Keys.First());
        Assert.Equal("there", mt.GetParameter("yo"));
        Assert.Equal(original, mt.ToString());
    }

    [Fact]
    public void MimeTypeReverseMappingAvailable()
    {
        var original = "image/png";
        var extension = MimeTypeNames.GetExtension(original);
        Assert.Equal(".png", extension);
    }

    [Fact]
    public void MimeTypeReverseMappingUnavailable()
    {
        var original = "image/foobar";
        var extension = MimeTypeNames.GetExtension(original);
        Assert.Equal("", extension);
    }
}
