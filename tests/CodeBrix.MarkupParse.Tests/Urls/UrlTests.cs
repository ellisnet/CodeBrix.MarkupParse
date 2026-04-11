using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Urls; //Was previously: namespace AngleSharp.Core.Tests.Urls

public class UrlTests
{
    [Fact]
    public void UrlWithHttpAsResourceIsARelativeUrl()
    {
        var address = "http";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal("http", result.Href);
        Assert.True(result.IsRelative);
    }

    [Fact]
    public void UrlWithHttpAndColonIsAValidUrl()
    {
        var address = "http:";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal("http:///", result.Href);
        Assert.True(string.IsNullOrEmpty(result.Path));
        Assert.True(string.IsNullOrEmpty(result.Query));
    }

    [Fact]
    public void UrlWithSchemeOnlyIsAnInvalidUrl()
    {
        var address = "http://";
        var result = new Url(address);
        Assert.True(result.IsInvalid);
        Assert.Equal("http:///", result.Href);
        Assert.True(string.IsNullOrEmpty(result.Path));
        Assert.True(string.IsNullOrEmpty(result.Query));
    }

    [Fact]
    public void ValidityOfValidGoogleHostnameAddress()
    {
        var address = "http://www.google.de";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
    }

    [Fact]
    public void ValidityOfValidGoogleHostnameAndPathEmptyAddress()
    {
        var address = "http://www.google.de/";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
    }

    [Fact]
    public void ValidityOfValidGoogleHostnameAndPathAddress()
    {
        var address = "http://www.google.de/some-path";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
    }

    [Fact]
    public void ValidityOfValidGoogleHostnameAndPathAndFragmentEmptyAddress()
    {
        var address = "http://www.google.de/some-path#";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
    }

    [Fact]
    public void ValidityOfValidGoogleHostnameAndPathAndQueryAndFragmentAddress()
    {
        var address = "http://www.google.de/some-path?a=b#header";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
    }

    [Fact]
    public void ValidityOfInvalidFragmentEmptyHostnameAddress()
    {
        var address = "http://#foo";
        var result = new Url(address);
        Assert.True(result.IsInvalid);
    }

    [Fact]
    public void OriginOfGitHubAddressShouldBeGitHubCom()
    {
        var address = "https://github.com/FlorianRappl/CodeBrix.MarkupParse";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal("https://github.com", result.Origin);
    }

    [Fact]
    public void UrlWithSpecialCharacterDash()
    {
        var address = "http://example-domain.com/image.jpg";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal(address, result.Href);
        Assert.Equal("example-domain.com", result.HostName);
    }

    [Fact]
    public void UrlQueryWithEmDashCharacter()
    {
        var address = "http://test/?hi—there";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal("http://test/?hi%E2%80%94there", result.Href);
        Assert.Equal("hi%E2%80%94there", result.Query);
    }

    [Fact]
    public void UrlWithSpecialCharacterUnderscoreDomain()
    {
        var address = "http://example_domain.com/image.jpg";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal(address, result.Href);
        Assert.Equal("example_domain.com", result.HostName);
    }

    [Fact]
    public void UrlWithSpecialCharacterUnderscoreSubDomain()
    {
        var address = "https://loony_picture.dirty.ru/";
        var result = new Url(address);
        Assert.False(result.IsInvalid);
        Assert.Equal(address, result.Href);
        Assert.Equal("loony_picture.dirty.ru", result.HostName);
    }

    [Fact]
    public void ExtendUrlWithPortWithAbsoluteUrlWithoutPortShouldHaveStandardPort()
    {
        var baseAddress = new Url("https://localhost:5000/foo");
        var newAddress = "http://example.com/bar";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("", result.Port);
        Assert.Equal(newAddress, result.Href);
    }

    [Fact]
    public void ExtendUrlWithPortWithRelativeUrlWithoutSchemeAndPortShouldHaveStandardPort()
    {
        var baseAddress = new Url("https://localhost:5000/foo");
        var newAddress = "//example.com/bar";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("", result.Port);
        Assert.Equal("https:" + newAddress, result.Href);
    }

    [Fact]
    public void ExtendUrlWithPortWithRelativeUrlShouldHaveThatPort()
    {
        var baseAddress = new Url("https://localhost:5000/foo");
        var newAddress = "/bar";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("5000", result.Port);
        Assert.Equal("https://localhost:5000" + newAddress, result.Href);
    }

    [Fact]
    public void RelativeUrlWithBaseUrlOverridesPortWhenHostIsSpecified()
    {
        var baseUrl = new Url("http://localhost:12345/account/login");
        var relative = "https://hosted-domain.com/signin";
        var url = new Url(baseUrl, relative);
        Assert.Equal("https://hosted-domain.com/signin", url.ToString());
    }

    [Fact]
    public void RelativeUrlWithBaseUrlDoesNotOverridePortIfNoHostIsSpecified()
    {
        var baseUrl = new Url("http://localhost:12345/account/login");
        var relative = "/signin";
        var url = new Url(baseUrl, relative);
        Assert.Equal("http://localhost:12345/signin", url.ToString());
    }

    [Fact]
    public void NoIndexOutOfRangeExceptionParseSchemeIssue711()
    {
        var baseUrl = new Url("http://some.domain.com");
        var relative = "http:";
        var url = new Url(baseUrl, relative);
        Assert.True(url.IsInvalid);
        Assert.Equal("http://some.domain.com/", url.ToString());
    }

    [Fact]
    public void PunycodeSquareReplacement_Issue797_Valid()
    {
        var url = new Url("http://ec².com");
        Assert.False(url.IsInvalid);
        Assert.Equal("http://ec2.com/", url.ToString());
    }

    [Fact]
    public void PunycodeSquareReplacement_Issue797_Invalid()
    {
        var url = new Url("http://www.example.c؀om/");
        Assert.True(url.IsInvalid);
    }

    [Fact]
    public void PunycodeSquareReplacement_Issue797_InvalidAfterMapping()
    {
        var url = new Url("http://www.examp？le.com/");
        Assert.True(url.IsInvalid);
    }

    [Fact]
    public void InvalidRelativeUrlAsDifferentProtocolScheme()
    {
        var baseUrl = new Url("http://some.domain.com");
        var relative = "https:";
        var url = new Url(baseUrl, relative);
        Assert.False(url.IsInvalid);
        Assert.Equal("https:///", url.ToString());
    }

    [InlineData("http://localhost:12345/signin")]
    [InlineData("https://loony_picture.dirty.ru/")]
    [InlineData("http://www.google.de/some-path?a=b#header")]
    [Theory]
    public void SameUrlsHaveSameHashCode(string url)
    {
        var url1 = new Url(url);
        var url2 = new Url(url);
        Assert.Equal(url1.GetHashCode(), url2.GetHashCode());
    }

    [Fact]
    public void ExtendFragmentUrlWithBaseQueryParameters_Issue1037()
    {
        var baseAddress = new Url("https://localhost:8080/?foo=bar");
        var newAddress = "#section1";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("https://localhost:8080/?foo=bar#section1", result.Href);
    }

    [Fact]
    public void NotExtendQueryUrlWithBaseQueryParameters_Issue1037()
    {
        var baseAddress = new Url("https://localhost:8080/?foo=bar");
        var newAddress = "?section=2";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("https://localhost:8080/?section=2", result.Href);
    }

    [Fact]
    public void NotExtendRelativePathUrlWithBaseQueryParameters_Issue1037()
    {
        var baseAddress = new Url("https://localhost:8080/?foo=bar");
        var newAddress = "section/3";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("https://localhost:8080/section/3", result.Href);
    }

    [Fact]
    public void NotExtendAbsolutePathUrlWithBaseQueryParameters_Issue1037()
    {
        var baseAddress = new Url("https://localhost:8080/?foo=bar");
        var newAddress = "/section/4";
        var result = new Url(baseAddress, newAddress);
        Assert.Equal("https://localhost:8080/section/4", result.Href);
    }
}
