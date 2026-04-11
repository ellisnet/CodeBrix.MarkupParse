using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Urls; //Was previously: namespace AngleSharp.Core.Tests.Urls

public class LocationTests
{
    [Fact]
    public void AbsoluteLocationWithoutPathGoogle()
    {
        var url = "http://www.google.de";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("www.google.de", location.Host);
        Assert.Equal(url + "/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithPathGoogle()
    {
        var url = "https://www.google.de/mypath";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/mypath", location.PathName);
        Assert.Equal("https:", location.Protocol);
        Assert.Equal("www.google.de", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void ProtocolRelativeLocationWithPathGoogleApis()
    {
        var url = "//ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.js";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/ajax/libs/jquery/1.4.2/jquery.js", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("ajax.googleapis.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithPortAndQueryLocalhost()
    {
        var url = "http://localhost:8080/?mytest";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("8080", location.Port);
        Assert.Equal("?mytest", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("localhost:8080", location.Host);
        Assert.Equal("localhost", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void DataLocationSchemeOnly()
    {
        var url = "data:";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("data:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void DataLocationComplete()
    {
        var data = "image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEcAAAAcCAMAAAAEJ1IZAAAABGdBTUEAALGPC/xhBQAAVAI/VAI/VAI/VAI/VAI/VAI/VAAAA////AI/VRZ0U8AAAAFJ0Uk5TYNV4S2UbgT/Gk6uQt585w2wGXS0zJO2lhGttJK6j4YqZSobH1AAAAAElFTkSuQmCC";
        var scheme = "data:";
        var url = scheme + data;
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal(data, location.PathName);
        Assert.Equal(scheme, location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationUsernamePasswordWithPort()
    {
        var url = "http://user:password@example.com:8080";
        var location = new Location(url);
        Assert.Equal("user", location.UserName);
        Assert.Equal("password", location.Password);
        Assert.Equal("", location.Hash);
        Assert.Equal("8080", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com:8080", location.Host);
        Assert.Equal("example.com", location.HostName);
        Assert.Equal(url + "/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationUsernamePasswordWithPortPathQueryAndFragment()
    {
        var url = "https://user:password@example.com:8080/path?query=value#fragment";
        var location = new Location(url);
        Assert.Equal("user", location.UserName);
        Assert.Equal("password", location.Password);
        Assert.Equal("#fragment", location.Hash);
        Assert.Equal("8080", location.Port);
        Assert.Equal("?query=value", location.Search);
        Assert.Equal("/path", location.PathName);
        Assert.Equal("https:", location.Protocol);
        Assert.Equal("example.com:8080", location.Host);
        Assert.Equal("example.com", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationAbsoluteDirectory()
    {
        var url = "/path";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/path", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url.Substring(1), location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void QueryRelativeLocation()
    {
        var url = "?query=value";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?query=value", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationRelativeSimple()
    {
        var url = "picture.png";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/picture.png", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationAbsoluteFile()
    {
        var url = "/hello.css";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/hello.css", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url.Substring(1), location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationRelativeDirectoryFile()
    {
        var url = "scripts/js/jquery.js";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/scripts/js/jquery.js", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void FragmentRelativeLocation()
    {
        var url = "#example";
        var location = new Location(url);
        Assert.Equal("#example", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationAbsoluteDirectoryFile()
    {
        var url = "/absolute/resource.jpg";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/absolute/resource.jpg", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url.Substring(1), location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationRelativeHtml()
    {
        var url = "index.html";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/index.html", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationRelativeHtmlWithQuery()
    {
        var url = "index.html?id=5";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?id=5", location.Search);
        Assert.Equal("/index.html", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void PathRelativeLocationRelativeWithQueryAndFragment()
    {
        var url = "default.aspx?word#first";
        var location = new Location(url);
        Assert.Equal("#first", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?word", location.Search);
        Assert.Equal("/default.aspx", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationIpAddressWithPortAndTelnetScheme()
    {
        var url = "telnet://192.0.2.16:80/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("telnet:", location.Protocol);
        Assert.Equal("//192.0.2.16:80/", location.PathName);
        Assert.Equal("", location.Host);
        Assert.Equal("", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationTelephonePseudo()
    {
        var url = "tel:+1-816-555-1212";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("tel:", location.Protocol);
        Assert.Equal("+1-816-555-1212", location.PathName);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationNewProtocol()
    {
        var url = "news:comp.infosystems.www.servers.unix";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("news:", location.Protocol);
        Assert.Equal("comp.infosystems.www.servers.unix", location.PathName);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationMailProtocolQueryMultiple()
    {
        var url = "mailto:?to=addr1@an.example,addr2@an.example";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?to=addr1@an.example,addr2@an.example", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("mailto:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationMailProtocolSimple()
    {
        var url = "mailto:John.Doe@example.com";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("mailto:", location.Protocol);
        Assert.Equal("John.Doe@example.com", location.PathName);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationLdapWithIpV6Address()
    {
        var url = "ldap://[2001:db8::7]/c=GB?objectClass?one";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?objectClass?one", location.Search);
        Assert.Equal("ldap:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("//[2001:db8::7]/c=GB", location.PathName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithPercentEncodedAndUppercase()
    {
        var url = "HTTP://example.com.:80/%70a%74%68?a=%31#1%323";
        var location = new Location(url);
        Assert.Equal("#1%323", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?a=%31", location.Search);
        Assert.Equal("/%70a%74%68", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com.", location.Host);
        Assert.Equal("http://example.com./%70a%74%68?a=%31#1%323", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationUrn()
    {
        var url = "urn:oasis:names:specification:docbook:dtd:xml:4.1.2";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("urn:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("oasis:names:specification:docbook:dtd:xml:4.1.2", location.PathName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationSimpleExample()
    {
        var url = "http://example.com";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url + "/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationIpExample()
    {
        var url = "http://127.0.0.1:8080/mypath";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("8080", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/mypath", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("127.0.0.1:8080", location.Host);
        Assert.Equal("127.0.0.1", location.HostName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationW3Project()
    {
        var url = "http://www.w3.org/pub/WWW/TheProject.html";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/pub/WWW/TheProject.html", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("www.w3.org", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationIpV6LongAddress()
    {
        var url = "http://[3ffe:1900:4545:3:200:f8ff:fe21:67cf]/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("[3ffe:1900:4545:3:200:f8ff:fe21:67cf]", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationIpV6AbbrAddress()
    {
        var url = "http://[::1]/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("[::1]", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleQueryEmpty()
    {
        var url = "http://example.com/?";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/?", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleFragmentEmpty()
    {
        var url = "http://example.com/#";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/#", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleQueryAndFragmentEmpty()
    {
        var url = "http://example.com/?#";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/?#", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleNoPathFragmentEmpty()
    {
        var url = "http://example.com#";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/#", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleNoPathQueryEmpty()
    {
        var url = "http://example.com?";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/?", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleNoPathQueryAndFragmentEmpty()
    {
        var url = "http://example.com?#";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/?#", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationExampleTildeDirectory()
    {
        var url = "http://example.com/~smith/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/~smith/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationGoingUpToRoot()
    {
        var url = "http://example.com/../..";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationGoingUpAndDown()
    {
        var url = "/a/b/c/./../../g";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/a/g", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("a/g", location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationOnWindows()
    {
        var url = "file:c:\\windows\\My Documents 100%20\\foo.txt";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/c:/windows/My%20Documents%20100%20/foo.txt", location.PathName);
        Assert.Equal("file:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("file:///c:/windows/My%20Documents%20100%20/foo.txt", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationPercentPathSingle()
    {
        var url = "https://example.com/%E8";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/%E8", location.PathName);
        Assert.Equal("https:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationPercentPathDouble()
    {
        var url = "http://example.com/%25C3%2587";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/%25C3%2587", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationQueryString()
    {
        var url = "http://example.com/?q=string";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?q=string", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationPortIgnored()
    {
        var url = "http://example.com:80/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationCurrentDirectory()
    {
        var url = "http://example.com/%2E/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://example.com/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationOneUp()
    {
        var url = "mid/content=5/../6";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/mid/6", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("mid/6", location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationOneUp()
    {
        var url = "http://www.example.com///../";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("//", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("www.example.com", location.Host);
        Assert.Equal("http://www.example.com//", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationFilenameWithSemicolon()
    {
        var url = "http://example.com/file.txt;parameter";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/file.txt;parameter", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationUnknownTagScheme()
    {
        var url = "tag:example.com,2006-08-18:/path/to/something";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("tag:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("example.com,2006-08-18:/path/to/something", location.PathName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationAuthorityAndPath()
    {
        var url = "http://user:pass@example.com/path/to/";
        var location = new Location(url);
        Assert.Equal("user", location.UserName);
        Assert.Equal("pass", location.Password);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/path/to/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationViewSourceProtocol()
    {
        var url = "view-source:http://example.com/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("view-source:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("http://example.com/", location.PathName);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationAuthorityAndPathWithQueryAndFragment()
    {
        var url = "http://user:pass@example.com/path/to/resource?query=x#fragment";
        var location = new Location(url);
        Assert.Equal("user", location.UserName);
        Assert.Equal("pass", location.Password);
        Assert.Equal("#fragment", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?query=x", location.Search);
        Assert.Equal("/path/to/resource", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithQueryAndPercent()
    {
        var url = "http://example.com/search?q=Q%26A";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?q=Q%26A", location.Search);
        Assert.Equal("/search", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithAmpersandQuerySingleValue()
    {
        var url = "http://example.com/?&&x=b";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?&&x=b", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationWithAmpersandQueryTwoValues()
    {
        var url = "http://example.com/?q=a&&x=b";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?q=a&&x=b", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationFileWithBackslashes()
    {
        var url = "file:c:\\windows\\My Documents 100%20\\foo.txt";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/c:/windows/My%20Documents%20100%20/foo.txt", location.PathName);
        Assert.Equal("file:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("file:///c:/windows/My%20Documents%20100%20/foo.txt", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationFileEverythingFine()
    {
        var url = "file:///c:/windows/My%20Documents%20100%20/foo.txt";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/c:/windows/My%20Documents%20100%20/foo.txt", location.PathName);
        Assert.Equal("file:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationFileWithPipe()
    {
        var url = "file:///c|/windows/My%20Documents%20100%20/foo.txt";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/c:/windows/My%20Documents%20100%20/foo.txt", location.PathName);
        Assert.Equal("file:", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("file:///c:/windows/My%20Documents%20100%20/foo.txt", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationAuthorityNothing()
    {
        var url = "http://:@example.com";
        var location = new Location(url);
        Assert.Equal("", location.UserName);
        Assert.Equal("", location.Password);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal("http://:@example.com/", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationWithoutProtocol()
    {
        var url = "//example.com/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationOnlyQuery()
    {
        var url = "?one=1&two=2&three=3";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?one=1&two=2&three=3", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationUnicodeLetters()
    {
        var url = "http://www.詹姆斯.com/atomtests/iri/詹.html";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/atomtests/iri/%E8%A9%B9.html", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("www.xn--8ws00zhy3a.com", location.Host);
        Assert.Equal("http://www.xn--8ws00zhy3a.com/atomtests/iri/%E8%A9%B9.html", location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationFtpShortPath()
    {
        var url = "ftp://a/b/c/d;p?q";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?q", location.Search);
        Assert.Equal("/b/c/d;p", location.PathName);
        Assert.Equal("ftp:", location.Protocol);
        Assert.Equal("a", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationEmpty()
    {
        var url = "";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal(url, location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void RelativeLocationSlash()
    {
        var url = "/";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/", location.PathName);
        Assert.Equal("", location.Protocol);
        Assert.Equal("", location.Host);
        Assert.Equal("", location.Href);
        Assert.True(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationNutsUrl()
    {
        var url = "http://example.com/:@-._~!$&'()*+,=;:@-._~!$&'()*+,=:@-._~!$&'()*+,==?/?:@-._~!$'()*+,;=/?:@-._~!$'()*+,;==#/?:@-._~!$&'()*+,;=";
        var location = new Location(url);
        Assert.Equal("#/?:@-._~!$&'()*+,;=", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("?/?:@-._~!$'()*+,;=/?:@-._~!$'()*+,;==", location.Search);
        Assert.Equal("/:@-._~!$&'()*+,=;:@-._~!$&'()*+,=:@-._~!$&'()*+,==", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void AbsoluteLocationDecodedPath()
    {
        var url = "http://example.com/blue%2Fred%3Fand+green";
        var location = new Location(url);
        Assert.Equal("", location.Hash);
        Assert.Equal("", location.Port);
        Assert.Equal("", location.Search);
        Assert.Equal("/blue%2Fred%3Fand+green", location.PathName);
        Assert.Equal("http:", location.Protocol);
        Assert.Equal("example.com", location.Host);
        Assert.Equal(url, location.Href);
        Assert.False(location.IsRelative);
    }

    [Fact]
    public void LocationAssignWithNewUrlFiresChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Assign("http://example.com/bar");
        Assert.True(changed);
        Assert.Equal("http://example.com/bar", location.Href);
    }

    [Fact]
    public void LocationAssignWithOldUrlDoesNotFireChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Assign("http://example.com/foo");
        Assert.False(changed);
        Assert.Equal("http://example.com/foo", location.Href);
    }

    [Fact]
    public void LocationSetHrefWithNewUrlFiresChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Href = "http://example.com/baz";
        Assert.True(changed);
        Assert.Equal("http://example.com/baz", location.Href);
    }

    [Fact]
    public void LocationSetHrefWithOldUrlDoesNotFireChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Href = "http://example.com/foo";
        Assert.False(changed);
        Assert.Equal("http://example.com/foo", location.Href);
    }

    [Fact]
    public void LocationReplaceWithNewUrlFiresChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Replace("http://example.com/bar");
        Assert.True(changed);
        Assert.Equal("http://example.com/bar", location.Href);
    }

    [Fact]
    public void LocationReplaceWithOldUrlDoesNotFireChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var changed = false;
        location.Changed += (_, _) => changed = true;
        location.Replace("http://example.com/foo");
        Assert.False(changed);
        Assert.Equal("http://example.com/foo", location.Href);
    }

    [Fact]
    public void LocationReloadFiresChangeEvent()
    {
        var url = "http://example.com/foo";
        var location = new Location(url);
        var reloaded = false;
        location.Changed += (_, e) => reloaded = e.IsReloaded;
        location.Reload();
        Assert.True(reloaded);
    }
}
