using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Urls; //Was previously: namespace AngleSharp.Core.Tests.Urls

public class UrlApiTests
{
    [Fact]
    public void UrlSearchWithoutQueryIsEmpty()
    {
        var url = new Url("https://florian-rappl.de/foo/bar");
        Assert.Equal("", url.Search);
        Assert.Null(url.Query);
        Assert.Equal("", url.SearchParams.ToString());
    }

    [Fact]
    public void UrlSearchWithQueryIsNotEmpty()
    {
        var url = new Url("https://florian-rappl.de/foo/bar?qxz=baz");
        Assert.Equal("?qxz=baz", url.Search);
        Assert.Equal("qxz=baz", url.Query);
        Assert.Equal("qxz=baz", url.SearchParams.ToString());
    }

    [Fact]
    public void UrlHashhWithoutFragmentIsEmpty()
    {
        var url = new Url("https://florian-rappl.de/foo/bar");
        Assert.Equal("", url.Hash);
        Assert.Null(url.Fragment);
    }

    [Fact]
    public void UrlHashhWithFragmentIsNotEmpty()
    {
        var url = new Url("https://florian-rappl.de/foo/bar#baz");
        Assert.Equal("#baz", url.Hash);
        Assert.Equal("baz", url.Fragment);
    }

    [Fact]
    public void UrlHashAssigningStringWithHash()
    {
        var url = new Url("https://florian-rappl.de/foo/bar#baz");
        Assert.Equal("#baz", url.Hash);
        Assert.Equal("baz", url.Fragment);
        url.Hash = "#foobar";
        Assert.Equal("#foobar", url.Hash);
        Assert.Equal("foobar", url.Fragment);
    }

    [Fact]
    public void UrlHashAssigningStringWithoutHash()
    {
        var url = new Url("https://florian-rappl.de/foo/bar#baz");
        Assert.Equal("#baz", url.Hash);
        Assert.Equal("baz", url.Fragment);
        url.Hash = "foobar";
        Assert.Equal("#foobar", url.Hash);
        Assert.Equal("foobar", url.Fragment);
    }

    [Fact]
    public void UrlHashAssigningEmpty()
    {
        var url = new Url("https://florian-rappl.de/foo/bar#baz");
        Assert.Equal("#baz", url.Hash);
        Assert.Equal("baz", url.Fragment);
        url.Hash = "";
        Assert.Equal("", url.Hash);
        Assert.Null(url.Fragment);
    }

    [Fact]
    public void UrlPathnameIncludesSlash()
    {
        var url = new Url("https://florian-rappl.de/foo/bar");
        Assert.Equal("/foo/bar", url.PathName);
        Assert.Equal("foo/bar", url.Path);
    }

    [Fact]
    public void UrlPathnameIsNeverEmpty()
    {
        var url = new Url("https://florian-rappl.de");
        Assert.Equal("/", url.PathName);
        Assert.Equal("", url.Path);
    }

    [Fact]
    public void UrlUsernameAndPasswordAreEmptyIfNotGiven()
    {
        var url = new Url("https://florian-rappl.de/foo/bar");
        Assert.Equal("", url.UserName);
        Assert.Equal("", url.Password);
    }

    [Fact]
    public void UrlQueryIsClearedWithNull()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        Assert.Equal("qxz=bar", url.SearchParams.ToString());
        Assert.Equal("qxz=bar", url.Query);
        Assert.Equal("?qxz=bar", url.Search);
        url.Query = null;
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("", url.SearchParams.ToString());
        Assert.Null(url.Query);
        Assert.Equal("", url.Search);
    }

    [Fact]
    public void UrlQueryIsClearedWithEmpty()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        Assert.Equal("qxz=bar", url.SearchParams.ToString());
        Assert.Equal("qxz=bar", url.Query);
        Assert.Equal("?qxz=bar", url.Search);
        url.Query = "";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("", url.SearchParams.ToString());
        Assert.Equal("", url.Query);
        Assert.Equal("", url.Search);
    }

    [Fact]
    public void UrlParamsAreLive()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        url.Query = "foo=bar";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("bar", url.SearchParams.Get("foo"));
        Assert.Equal("foo=bar", url.Query);
    }

    [Fact]
    public void UrlQueryDoesNotDependOnParams()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        url.Query = "foo";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("", url.SearchParams.Get("foo"));
        Assert.Equal("foo", url.Query);
    }

    [Fact]
    public void UrlSearchAssigningStringWithoutQuestion()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        url.Search = "foo=bar";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("bar", url.SearchParams.Get("foo"));
        Assert.Equal("foo=bar", url.Query);
    }

    [Fact]
    public void UrlSearchAssigningStringWithQuestion()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        url.Search = "?foo=bar";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Equal("bar", url.SearchParams.Get("foo"));
        Assert.Equal("foo=bar", url.Query);
    }

    [Fact]
    public void UrlSearchAssigningEmpty()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("bar", url.SearchParams.Get("qxz"));
        Assert.True(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        url.Search = "";
        Assert.Null(url.SearchParams.Get("qxz"));
        Assert.False(url.SearchParams.Has("qxz"));
        Assert.Null(url.SearchParams.Get("foo"));
        Assert.Null(url.Query);
    }

    [Fact]
    public void UrlParamsAreConnectedWhenAppend()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("qxz=bar", url.Query);
        url.SearchParams.Append("foo", "bar");
        Assert.Equal("qxz=bar&foo=bar", url.Query);
    }

    [Fact]
    public void UrlParamsAreConnectedWhenDelete()
    {
        var url = new Url("https://florian-rappl.de?qxz=bar");
        Assert.Equal("qxz=bar", url.Query);
        url.SearchParams.Delete("qxz");
        Assert.Equal("", url.Query);
    }

    [Fact]
    public void UrlParamsResolveValuesDecoded()
    {
        var url = new Url("https://florian-rappl.de?qxz=%20foo%20yo");
        Assert.Equal(" foo yo", url.SearchParams.Get("qxz"));
        Assert.Equal("?qxz=%20foo%20yo", url.Search);
        Assert.Equal("qxz=%20foo%20yo", url.SearchParams.ToString());
    }

    [Fact]
    public void UrlParamsResolveValuesDecodedAlsoWhenAdded()
    {
        var url = new Url("https://florian-rappl.de?qxz=%20foo%20yo");
        url.SearchParams.Set("qxz", "foo");
        Assert.Equal("foo", url.SearchParams.Get("qxz"));
        url.SearchParams.Set("bar", "crazy / shit ?");
        Assert.Equal("?qxz=foo&bar=crazy%20%2F%20shit%20%3F", url.Search);
        Assert.Equal("crazy / shit ?", url.SearchParams.Get("bar"));
        Assert.Equal("qxz=foo&bar=crazy%20%2F%20shit%20%3F", url.SearchParams.ToString());
    }
}
