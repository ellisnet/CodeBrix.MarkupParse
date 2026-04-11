using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io;
using Newtonsoft.Json.Linq;
using Xunit;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class CookieHandlingTests
{
    [Fact]
    public async Task SettingSimpleSingleCookieInRequestAppearsInDocument()
    {
        var cookie = await LoadDocumentWithCookie("UserID=Foo");
        Assert.Equal("UserID=Foo", cookie);
    }

    [Fact]
    public async Task AccessLloydsBankWithMixedPathAndDomainCookiesShouldWork()
    {
        if (Helper.IsNetworkAvailable())
        {
            var configuration = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
            var context = BrowsingContext.New(configuration);
            await context.OpenAsync("https://online.lloydsbank.co.uk/personal/logon/login.jsp", TestContext.Current.CancellationToken);
        }
    }

    [Fact]
    public async Task PlainVersion1CookieIsCorrectlyTransformed()
    {
        var cookie = await LoadDocumentWithCookie(
            "FGTServer=04E2E1A642B2BB49C6FE0115DE3976CB377263F3278BD6C8E2F8A24EE4DF7562F089BFAC5C0102; Version=1");
        Assert.Equal(
            "$Version=1; FGTServer=04E2E1A642B2BB49C6FE0115DE3976CB377263F3278BD6C8E2F8A24EE4DF7562F089BFAC5C0102",
            cookie);
    }

    [Fact]
    public async Task Version1CookieIsAlreadyTransformed()
    {
        var cookie = await LoadDocumentWithCookie("Customer=\"WILE_E_COYOTE\"; Version=\"1\"");
        Assert.Equal("$Version=\"1\"; Customer=\"WILE_E_COYOTE\"", cookie);
    }

    [Fact]
    public async Task Version1CookieWithSingleEntryAlreadyTransformedCorrectly()
    {
        var cookie = await LoadDocumentWithCookie("Shipping=FedEx; Version=\"1\"");
        Assert.Equal("$Version=\"1\"; Shipping=FedEx", cookie);
    }

    [Fact]
    public async Task CookieExpiresInFuture()
    {
        var year = DateTime.Today.Year + 1;
        var dayOfWeek = new DateTime(year, 8, 3).ToString("ddd", CultureInfo.InvariantCulture);
        var cookie = $"ppkcookie2=another test; expires={dayOfWeek}, 3 Aug {year} 20:47:11 GMT; path=/";
        var document = await LoadDocumentAloneWithCookie("");
        document.Cookie = cookie;
        Assert.Equal("ppkcookie2=another test", document.Cookie);
    }

    [Fact]
    public async Task CookieExpiredAlready()
    {
        var year = DateTime.Today.Year - 1;
        var dayOfWeek = new DateTime(year, 8, 3).ToString("ddd", CultureInfo.InvariantCulture);
        var document = await LoadDocumentAloneWithCookie("");
        document.Cookie = $"ppkcookie2=yet another test; expires={dayOfWeek}, 3 Aug {year} 20:47:11 GMT; path=/";
        Assert.Equal("", document.Cookie);
    }

    [Fact]
    public async Task CookieExpiredInGmtInterpretedAsLocaltime()
    {
        //This test must be executed in an environment where the local time is ahead of GMT.
        var expires = DateTime.Now.AddMinutes(10).ToUniversalTime();
        var document = await LoadDocumentAloneWithCookie("");
        document.Cookie = $"ppkcookie2=yet yet another test; expires={expires.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture)} GMT; path=/";
        Assert.Equal("ppkcookie2=yet yet another test", document.Cookie);
    }

    [Fact]
    public async Task SettingTwoSimpleCookiesInRequestAppearsInDocument()
    {
        var cookie = await LoadDocumentWithCookie("UserID=Foo, Auth=bar");
        Assert.Equal("UserID=Foo; Auth=bar", cookie);
    }

    [Fact]
    public async Task SettingSingleCookieWithMaxAgeInRequestAppearsInDocument()
    {
        var cookie = await LoadDocumentWithCookie("cookie=two; Max-Age=36001");
        Assert.Equal("cookie=two", cookie);
    }

    [Fact]
    public async Task SettingSingleCookieChangesValue()
    {
        var document = await LoadDocumentAloneWithCookie("cookie=two; Max-Age=36001");
        Assert.Equal("cookie=two", document.Cookie);
        document.Cookie = "cookie=one";
        Assert.Equal("cookie=one", document.Cookie);
    }

    [Fact]
    public async Task SettingOtherCookieAddsCookie()
    {
        var document = await LoadDocumentAloneWithCookie("cookie=two; Max-Age=36001");
        Assert.Equal("cookie=two", document.Cookie);
        document.Cookie = "foo=bar";
        Assert.Equal("cookie=two; foo=bar", document.Cookie);
    }

    [Fact]
    public async Task InvalidatingCookieRemovesTheCookie()
    {
        var document = await LoadDocumentAloneWithCookie("cookie=two; Max-Age=36001, foo=bar");
        Assert.Equal("cookie=two; foo=bar", document.Cookie);
        document.Cookie = "cookie=expiring; Expires=Tue, 10 Nov 2009 23:00:00 GMT";
        Assert.Equal("foo=bar", document.Cookie);
    }

    [Fact]
    public async Task SettingSingleExpiredCookieInRequestDoesNotAppearInDocument()
    {
        var cookie = await LoadDocumentWithCookie("cookie=expiring; Expires=Tue, 10 Nov 2009 23:00:00 GMT");
        Assert.Equal("", cookie);
    }

    [Fact]
    public async Task SettingMultipleExpiredCookieInRequestDoNotAppearInDocument()
    {
        var cookie = await LoadDocumentWithCookie(
            "cookie=expiring; Expires=Tue, 10 Nov 2009 23:00:00 GMT, foo=bar; Expires=Tue, 10 Nov 2009 23:00:00 GMT");
        Assert.Equal("", cookie);
    }

    [Fact]
    public async Task SettingOneExpiredCookieAndAFutureCookieInRequestDoAppearInDocument()
    {
        var cookie = await LoadDocumentWithCookie(
            "cookie=expiring; Expires=Tue, 10 Nov 2009 23:00:00 GMT, foo=bar; Expires=Tue, 28 Jan 2035 13:37:00 GMT");
        Assert.Equal("foo=bar", cookie);
    }

    [Fact]
    public async Task SettingSingleCookieInDocumentAppearsInRequest()
    {
        var request = default(Request);
        var config = Configuration.Default.WithDefaultCookies().WithMockRequester(req => request = req);
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(res =>
            res.Content("<a href=mockpage.html></a>").Address("http://localhost/"), TestContext.Current.CancellationToken);

        document.Cookie = "UserID=Foo";
        await document.QuerySelector<IHtmlAnchorElement>("a").NavigateAsync();

        Assert.NotNull(request);
        Assert.True(request.Headers.ContainsKey(HeaderNames.Cookie));
        Assert.Equal("UserID=Foo", request.Headers[HeaderNames.Cookie]);
    }

    [Fact]
    public async Task SettingNewCookieInSubsequentRequestDoesNotExpirePreviousCookies()
    {
        var config = Configuration.Default.WithDefaultCookies().WithVirtualRequester(_ => VirtualResponse.Create(
            res => res.Address("http://localhost/mockpage.html").Content("<div></div>")
                .Cookie("Auth=Bar; Path=/")));
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(res =>
            res.Content("<a href=mockpage.html></a>").Address("http://localhost/").Cookie("UserID=Foo; Path=/"), TestContext.Current.CancellationToken);

        document = await document.QuerySelector<IHtmlAnchorElement>("a").NavigateAsync();

        Assert.Equal("UserID=Foo; Auth=Bar", document.Cookie);
    }

    [Fact]
    public async Task SettingNoCookieInSubsequentRequestLeavesCookieSituationUnchanged()
    {
        var config = Configuration.Default.WithDefaultCookies().WithVirtualRequester(_ => VirtualResponse.Create(
            res => res.Address("http://localhost/mockpage.html").Content("<div></div>")));
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(res =>
            res.Content("<a href=mockpage.html></a>").Address("http://localhost/").Cookie("UserID=Foo"), TestContext.Current.CancellationToken);

        document = await document.QuerySelector<IHtmlAnchorElement>("a").NavigateAsync();

        Assert.Equal("UserID=Foo", document.Cookie);
    }

    [Fact]
    public async Task SettingOneCookiesInOneRequestAppearsInDocument()
    {
        if (Helper.IsNetworkAvailable() && Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var url = "https://httpbingo.org/cookies/set?k1=v1";
            var config = Configuration.Default.WithDefaultCookies().WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url, TestContext.Current.CancellationToken);

            Assert.Equal("k1=v1", document.Cookie);
        }
    }

    [Fact]
    public async Task SettingTwoCookiesInOneRequestAppearsInDocument()
    {
        if (Helper.IsNetworkAvailable() && Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var url = "https://httpbingo.org/cookies/set?k2=v2&k1=v1";
            var config = Configuration.Default.WithDefaultCookies().WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url, TestContext.Current.CancellationToken);
            var cookies = document.Cookie.Split(';').Select(m => m.Trim());

            Assert.Equivalent(new[] {"k1=v1", "k2=v2"}, cookies);
        }
    }

    [Fact]
    public async Task SettingThreeCookiesInOneRequestAppearsInDocument()
    {
        if (Helper.IsNetworkAvailable() && Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var url = "https://httpbingo.org/cookies/set?test=baz&k2=v2&k1=v1&foo=bar";
            var config = Configuration.Default.WithDefaultCookies().WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url, TestContext.Current.CancellationToken);
            var cookies = document.Cookie.Split(';').Select(m => m.Trim());

            Assert.Equivalent(new[] {"k1=v1", "k2=v2", "foo=bar", "test=baz"}, cookies);
        }
    }

    [Fact]
    public async Task SettingThreeCookiesInOneRequestAreTransportedToNextRequest()
    {
        if (Helper.IsNetworkAvailable() && Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var baseUrl = "https://httpbingo.org/cookies";
            var url = baseUrl + "/set?test=baz&k2=v2&k1=v1&foo=bar";
            var config = Configuration.Default.WithDefaultCookies().WithDefaultLoader();
            var context = BrowsingContext.New(config);
            await context.OpenAsync(url, TestContext.Current.CancellationToken);
            var document = await context.OpenAsync(baseUrl, TestContext.Current.CancellationToken);

            var expected = JObject.Parse(@"{
  ""foo"": ""bar"",
  ""k1"": ""v1"",
  ""k2"": ""v2"",
  ""test"": ""baz""
}
");

            Assert.Equal(expected.ToString(), JObject.Parse(document.Body.TextContent).ToString());
        }
    }

    [Fact]
    public async Task SettingCookieIsPreservedViaRedirect()
    {
        if (Helper.IsNetworkAvailable() && Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var cookieUrl = "https://httpbingo.org/cookies/set?test=baz";
            var redirectUrl = "https://httpbingo.org/redirect-to?url=https%3A%2F%2Fhttpbingo.org%2Fcookies";
            var config = Configuration.Default.WithDefaultCookies().WithDefaultLoader();
            var context = BrowsingContext.New(config);
            await context.OpenAsync(cookieUrl, TestContext.Current.CancellationToken);
            var document = await context.OpenAsync(redirectUrl, TestContext.Current.CancellationToken);

           Assert.Equal(@"{
  ""test"": ""baz""
}
".Replace(Environment.NewLine, "\n"), document.Body.TextContent);
        }
    }

    [Fact]
    public async Task SendingRequestToLocalResourceContainsLocalCookie()
    {
        var content = "<!doctype html><img src=foo.png />";
        var cookieValue = "test=true";
        var requestCount = 0;
        var imgCookie = string.Empty;
        var initial =
            VirtualResponse.Create(m => m.Content(content).Address("http://www.local.com").Cookie(cookieValue));
        await LoadDocumentWithFakeRequesterAndCookie(initial, req =>
        {
            var res = VirtualResponse.Create(m => m.Content(string.Empty).Address(req.Address));
            imgCookie = req.Headers.GetOrDefault(HeaderNames.Cookie, string.Empty);
            requestCount++;
            return res;
        });

        Assert.Equal(1, requestCount);
        Assert.Equal(cookieValue, imgCookie);
    }

    [Fact]
    public async Task SendingRequestToOtherResourceOmitsLocalCookie()
    {
        var content = "<!doctype html><img src=http://www.other.com/foo.png />";
        var cookieValue = "test=true";
        var requestCount = 0;
        var imgCookie = string.Empty;
        var initial =
            VirtualResponse.Create(m => m.Content(content).Address("http://www.local.com").Cookie(cookieValue));
        await LoadDocumentWithFakeRequesterAndCookie(initial, req =>
        {
            var res = VirtualResponse.Create(m => m.Content(string.Empty).Address(req.Address));
            imgCookie = req.Headers.GetOrDefault(HeaderNames.Cookie, string.Empty);
            requestCount++;
            return res;
        });

        Assert.Equal(1, requestCount);
        Assert.Equal(string.Empty, imgCookie);
    }

    [Fact]
    public async Task CookieWithUTCTimeStampVariant1()
    {
        var content = "<!doctype html>";
        var cookieValue =
            "fm=0; Expires=Wed, 03 Jan 2018 10:54:24 UTC; Path=/; Domain=.twitter.com; Secure; HTTPOnly";
        var requestCount = 0;
        var initial = VirtualResponse.Create(m =>
            m.Content(content).Address("http://www.twitter.com").Header(HeaderNames.SetCookie, cookieValue));
        var document = await LoadDocumentWithFakeRequesterAndCookie(initial, req =>
        {
            var res = VirtualResponse.Create(m => m.Content(string.Empty).Address(req.Address));
            requestCount++;
            return res;
        });

        Assert.Equal(0, requestCount);
    }

    [Fact]
    public async Task CookieWithUTCTimeStampVariant2()
    {
        var content = "<!doctype html>";
        var cookieValue =
            "ct0=cf2c3d61837dc0513fe9dfa8019a3af8; Expires=Wed, 03 Jan 2018 16:54:34 UTC; Path=/; Domain=.twitter.com; Secure";
        var requestCount = 0;
        var initial = VirtualResponse.Create(m =>
            m.Content(content).Address("http://www.twitter.com").Header(HeaderNames.SetCookie, cookieValue));
        var document = await LoadDocumentWithFakeRequesterAndCookie(initial, req =>
        {
            var res = VirtualResponse.Create(m => m.Content(string.Empty).Address(req.Address));
            requestCount++;
            return res;
        });

        Assert.Equal(0, requestCount);
    }

    [Fact]
    public async Task SendingRequestToLocalResourceSendsLocalCookie()
    {
        var content = "<!doctype html><img src=http://www.local.com/foo.png />";
        var cookieValue = "test=true";
        var requestCount = 0;
        var imgCookie = string.Empty;
        var initial =
            VirtualResponse.Create(m => m.Content(content).Address("http://www.local.com").Cookie(cookieValue));
        await LoadDocumentWithFakeRequesterAndCookie(initial, req =>
        {
            var res = VirtualResponse.Create(m => m.Content(string.Empty).Address(req.Address));
            imgCookie = req.Headers.GetOrDefault(HeaderNames.Cookie, string.Empty);
            requestCount++;
            return res;
        });

        Assert.Equal(1, requestCount);
        Assert.Equal(cookieValue, imgCookie);
    }

    [Fact]
    public async Task DefaultHttpRequesterWorksWithVersion1Cookies()
    {
        var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
        var context = BrowsingContext.New(config);
        var cookieValue =
            "FGTServer=04E2E1A642B2BB49C6FE0115DE3976CB377263F3278BD6C8E2F8A24EE4DF7562F089BFAC5C0102; Version=1";

        var document = await context.OpenAsync(res => res.Content("<div></div>")
            .Address("http://localhost/")
            .Header(HeaderNames.SetCookie, cookieValue), TestContext.Current.CancellationToken);

        Assert.NotEmpty(document.Cookie);
    }

    [Fact]
    public void DateTimeShouldBeAccepted_Issue663()
    {
        var mcp = new MemoryCookieProvider();
        var url = Url.Create("http://www.example.com");
        mcp.SetCookie(url,
            "c-s=expires=1531601411~access=/clientimg/richmond/*!/content/richmond/*~md5=c56447496f01a9cd01bbec1b3a293357; path=/; secure");
    }

    [Fact]
    public void DataUrlShouldNotDeliverAnyCookie_Issue702()
    {
        var mcp = new MemoryCookieProvider();
        var url = Url.Create("data:image/gif;base64,R0lGODlhAQABAIAAAAUEBAAAACwAAAAAAQABAAACAkQBADs=");
        var cookie = mcp.GetCookie(url);
        Assert.Empty(cookie);
    }

    [Fact]
    public void NoOriginShouldNotDeliverAnyCookie_Issue702()
    {
        if (Helper.IsFramework(".NET 6.0", ".NET 7.0", ".NET 8.0"))
        {
            var mcp = new MemoryCookieProvider();
            var url = new Url("");
            var cookie = mcp.GetCookie(url);
            Assert.Empty(cookie);
        }
    }

    [Fact]
    public void ShouldChangeSelectedCookiesOnRedirect_Issue548()
    {
        var requester = new MockRequester();
        var mcp = new MemoryCookieProvider();
        var config = Configuration.Default.With(mcp).With(requester).WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var receivedCookieHeader = "THECOOKIE=value1; Path=/path1";
        var url = new Url("http://example.com/path1");
        //request 1: /path1, set a cookie THECOOKIE=value1
        requester.BuildResponse(_ => VirtualResponse.Create(r => r
            .Address("http://example.com/path1")
            .Content("")
            .Header(HeaderNames.SetCookie, receivedCookieHeader)));
        context.OpenAsync("http://example.com/path1", TestContext.Current.CancellationToken);
        //request 2: /path1/somefile.jsp redirects to /path2/file2.jsp
        requester.BuildResponses(new Func<Request, IResponse>[] {
            _ => {
                return VirtualResponse.Create(r => r
                .Address("http://example.com/path1/somefile.jsp")
                .Content("")
                .Status(System.Net.HttpStatusCode.Redirect)
                .Header(HeaderNames.Location, "http://example.com/path2/file2.jsp"));
            },
            req => {
                receivedCookieHeader = req.Headers.GetOrDefault(HeaderNames.Cookie, string.Empty);
                return VirtualResponse.Create(r => r
                .Address("http://example.com/path2/file2.jsp")
                .Content(""));
            }
        });
        context.OpenAsync("http://example.com/path1/somefile.jsp", TestContext.Current.CancellationToken);
        Assert.Equal(string.Empty, receivedCookieHeader);
    }

    [Fact]
    public void MissingCookie_Issue768()
    {
        var mcp = new MemoryCookieProvider();
        var url = Url.Create("http://www.example.com");
        var cookie = "A=A";
        mcp.SetCookie(url,
            $"{cookie}; expires={DateTime.UtcNow.AddHours(1):R}");
        Assert.Equal(mcp.GetCookie(url), cookie);
    }

    private static Task<IDocument> LoadDocumentWithFakeRequesterAndCookie(IResponse initialResponse,
        Func<Request, IResponse> onRequest)
    {
        var requester = new MockRequester();
        requester.BuildResponse(onRequest);
        var config = Configuration.Default.With(requester)
            .WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true }).WithDefaultCookies();
        return BrowsingContext.New(config).OpenAsync(initialResponse, CancellationToken.None);
    }

    private static async Task<IDocument> LoadDocumentAloneWithCookie(string cookieValue)
    {
        var config = Configuration.Default.WithDefaultCookies();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(res =>
            res.Content("<div></div>").Address("http://localhost/").Header(HeaderNames.SetCookie, cookieValue));

        return document;
    }

    private static async Task<string> LoadDocumentWithCookie(string cookieValue)
    {
        var document = await LoadDocumentAloneWithCookie(cookieValue);
        return document.Cookie;
    }
}
