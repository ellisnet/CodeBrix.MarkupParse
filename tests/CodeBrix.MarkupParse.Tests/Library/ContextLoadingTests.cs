using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Html.Dom.Events;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Media;
using Xunit;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class ContextLoadingTests
{
    [Fact]
    public async Task ContextLoadEmptyDocumentWithoutUrl()
    {
        var document = await BrowsingContext.New().OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        Assert.NotNull(document);
        Assert.NotNull(document.DocumentElement);
        Assert.NotNull(document.Body);
        Assert.NotNull(document.Head);
        Assert.Equal("http://localhost/", document.DocumentUri);
        Assert.Equal(2, document.DocumentElement.ChildElementCount);
        Assert.Equal(0, document.Body.ChildElementCount);
        Assert.Equal(0, document.Head.ChildElementCount);
    }

    [Fact]
    public async Task ContextLoadEmptyDocumentFromVirtualResponse()
    {
        var document = await BrowsingContext.New().OpenAsync(m => m.Address("http://anglesharp.github.io").Content("<h1>CodeBrix.MarkupParse rocks</h1>"), TestContext.Current.CancellationToken);
        Assert.NotNull(document);
        Assert.NotNull(document.DocumentElement);
        Assert.NotNull(document.Body);
        Assert.NotNull(document.Head);
        Assert.Equal("http://anglesharp.github.io/", document.DocumentUri);
        Assert.Equal(2, document.DocumentElement.ChildElementCount);
        Assert.Equal(1, document.Body.ChildElementCount);
        Assert.Equal(0, document.Head.ChildElementCount);
        Assert.Equal("CodeBrix.MarkupParse rocks", document.QuerySelector("h1").TextContent);
    }

    [Fact]
    public async Task ContextLoadEmptyDocumentWithUrl()
    {
        var document = await BrowsingContext.New().OpenNewAsync(url: "http://localhost:8081", cancellation: TestContext.Current.CancellationToken);
        Assert.NotNull(document);
        Assert.NotNull(document.DocumentElement);
        Assert.NotNull(document.Body);
        Assert.NotNull(document.Head);
        Assert.Equal("http://localhost:8081/", document.DocumentUri);
        Assert.Equal(2, document.DocumentElement.ChildElementCount);
        Assert.Equal(0, document.Body.ChildElementCount);
        Assert.Equal(0, document.Head.ChildElementCount);
    }

    [Fact]
    public async Task ContextLoadFromUrl()
    {
        if (Helper.IsNetworkAvailable())
        {
            var title = "PostUrlencodeNormal";
            var address = "http://anglesharp.azurewebsites.net/PostUrlEncodeNormal";
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(address, TestContext.Current.CancellationToken);
            var h1 = document.QuerySelector("h1");

            Assert.NotNull(document);
            Assert.NotNull(document.DocumentElement);
            Assert.NotNull(document.Body);
            Assert.NotNull(document.Head);
            Assert.Equal(address, document.DocumentUri);
            Assert.Equal(title, document.Title);
            Assert.Equal(title, h1.TextContent);
        }
    }

    [Fact]
    public async Task ContextFormSubmission()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://anglesharp.azurewebsites.net/PostUrlEncodeNormal";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);

            Assert.Single(document.Forms);

            var form = document.Forms[0];
            var name = form.Elements["Name"] as IHtmlInputElement;
            var number = form.Elements["Number"] as IHtmlInputElement;
            var isactive = form.Elements["IsActive"] as IHtmlInputElement;

            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);

            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;
            var result = await form.SubmitAsync();

            Assert.NotNull(result);
            Assert.Equal(result, context.Active);
            Assert.Equal("okay", context.Active.Body.TextContent);
        }
    }

    [Fact]
    public async Task ContextNavigateFromLinkRefererShouldBeOriginalUrl()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://anglesharp.azurewebsites.net/";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);
            var anchors = document.QuerySelectorAll<IHtmlAnchorElement>("ul a");
            var anchor = anchors.FirstOrDefault(m => m.TextContent == "Header");
            var result = await context.OpenAsync(Url.Create(anchor.Href), TestContext.Current.CancellationToken);

            Assert.NotNull(result);
            Assert.Equal(result, context.Active);
            Assert.Equal(address, context.Active.Body.TextContent);
        }
    }

    [Fact]
    public async Task ContextNavigateFromLinkToPage()
    {
        if (Helper.IsNetworkAvailable())
        {
            var title = "PostUrlencodeNormal";
            var address = "http://anglesharp.azurewebsites.net/";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);
            var anchors = document.QuerySelectorAll<IHtmlAnchorElement>("ul a");
            var anchor = anchors.FirstOrDefault(m => m.TextContent == title);
            var result = await anchor.NavigateAsync();

            Assert.NotNull(result);
            Assert.Equal(result, context.Active);
            Assert.Equal(title, context.Active.Title);
        }
    }

    [Fact]
    public async Task ContextLoadExternalResources()
    {
        var delayRequester = new DelayRequester(100);
        var imageService = new ResourceService<IImageInfo>("image/jpeg", response => new MockImageInfo { Source = response.Address });
        var config = Configuration.Default.With(delayRequester).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true }).With(imageService);
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(m => m.Content("<img src=whatever.jpg>"), TestContext.Current.CancellationToken);
        var img = document.QuerySelector<IHtmlImageElement>("img");
        Assert.Equal(1, delayRequester.RequestCount);
        Assert.True(img.IsCompleted);
    }

    [Fact]
    public async Task ContextNoLoadExternalResources()
    {
        var delayRequester = new DelayRequester(100);
        var config = Configuration.Default.With(delayRequester).WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(m => m.Content("<img src=whatever.jpg>"), TestContext.Current.CancellationToken);
        var img = document.QuerySelector<IHtmlImageElement>("img");
        Assert.Equal(0, delayRequester.RequestCount);
        Assert.False(img.IsCompleted);
    }

    [Fact]
    public async Task GzipEncoding_Issue1122()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "https://www.powerball.com";
            var config = Configuration.Default.WithLocaleBasedEncoding().WithPageRequester();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);

            Assert.NotNull(document);
            // Any value goes - it should just be readable and make sense
            Assert.Equal("Home | Powerball", document.Title);
            // Sure, this can break fast if they change something; but we need an indicator that we can trust
            Assert.NotNull(document.QuerySelector("a.u-text-transform-uppercase.c-skipnav"));
        }
    }

    [Fact]
    public async Task LoadContextFromStreamLoadedShouldNotFaceBufferTooSmall()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://kommersant.ru/rss-list";
            var config = Configuration.Default.WithPageRequester();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);

            Assert.NotNull(document);
            Assert.NotEqual(0, document.All.Length);
        }
    }

    [Fact]
    public async Task LoadContextFromStreamLoadedShouldNotBeStuckForever()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://eurobelarus.info/";
            var config = Configuration.Default.WithPageRequester();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);

            Assert.NotNull(document);
            Assert.NotEqual(0, document.All.Length);
        }
    }

    [Fact]
    public async Task LoadContextFromStreamChunked()
    {
        // Warning: This test might fail under certain conditions, e.g.,
        // * client uses a proxy or
        // * client is connected to VPN (at least with the VPN client of Windows 10).
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://anglesharp.azurewebsites.net/Chunked";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var events = new EventReceiver<HtmlParseEvent>(handler => context.GetService<IHtmlParser>().Parsing += handler);
            var start = DateTime.Now;
            events.OnReceived = _ => start = DateTime.Now;
            await context.OpenAsync(address, TestContext.Current.CancellationToken);
            var end = DateTime.Now;
            Assert.True(end - start > TimeSpan.FromSeconds(1));
        }
    }

    [Fact]
    public async Task ProxyShouldBeAvailableDuringLoading()
    {
        var windowIsNotNull = false;
        var scripting = new CallbackScriptEngine(options => windowIsNotNull = options.Document.DefaultView.Proxy != null);
        var config = Configuration.Default.WithScripts(scripting).WithMockRequester();
        var source = "<title>Some title</title><body><script type='c-sharp' src='foo.cs'></script>";
        await BrowsingContext.New(config).OpenAsync(m =>
            m.Content(source).Address("http://www.example.com"), TestContext.Current.CancellationToken);
        Assert.True(windowIsNotNull);
    }

    [Fact]
    public async Task LoadTestPageWithAllSubresources()
    {
        if (Helper.IsNetworkAvailable())
        {
            //Formerly used the following url:
            //https://meadjohnson.world.tmall.com/search.htm?search=y&orderType=defaultSort&scene=taobao_shop
            //However: The connection to taobao is usually very bad and the
            //page takes ~10-30s (or longer!) to load. Replaced with another
            //solution taken directly from the CodeBrix.MarkupParse infrastructure.
            var address = "http://anglesharp.azurewebsites.net/Page";
            var config = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);
            Assert.NotNull(document);
        }
    }

    [Fact]
    public async Task LoadingPdfDocumentInsteadOfHtmlShouldWork()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = "http://www.europarl.europa.eu/sides/getDoc.do?type=COMPARL&reference=PE-583.901&format=PDF&language=EN&secondRef=01";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address, TestContext.Current.CancellationToken);
            Assert.NotNull(document);
        }
    }

    [Fact]
    public async Task GetDownloadsOfEmptyDocumentShouldBeZero()
    {
        var config = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var document = await BrowsingContext.New(config).OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        var downloads = document.GetDownloads().ToArray();

        Assert.Empty(downloads);
    }

    [Fact]
    public async Task GetDownloadsOfExampleDocumentWithoutCssAndJsShouldYieldPartialResources()
    {
        var config = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var content = @"<link rel=stylesheet type=text/css href=bootstraph.css>
<link rel=stylesheet type=text/css href=fontawesome.css>
<link rel=stylesheet type=text/css href=style.css>
<body>
    <img src=foo.png>
    <iframe src=foo.html></iframe>
    <script>alert('Hello World!');</script>
    <script src=test.js></script>
</body>";
        var document = await BrowsingContext.New(config).OpenAsync(res => res.Content(content).Address("http://localhost"), TestContext.Current.CancellationToken);
        var downloads = document.GetDownloads().ToArray();

        Assert.Equal(2, downloads.Length);

        foreach (var download in downloads)
        {
            Assert.True(download.IsCompleted);
            Assert.NotNull(download.Source);
        }

        Assert.Equal(document.QuerySelector("img"), downloads[0].Source);
        Assert.Equal(document.QuerySelector("iframe"), downloads[1].Source);
    }

    [Fact]
    public async Task JavaScriptWithIntegrityAndCorsShouldBeCheckedButNotParsedIfDeclined()
    {
        var hasBeenChecked = false;
        var hasBeenParsed = false;
        var scripting = new CallbackScriptEngine(_ =>
        {
            hasBeenParsed = true;
        }, MimeTypeNames.DefaultJavaScript);
        var provider = new MockIntegrityProvider((_, _) =>
        {
            hasBeenChecked = true;
            return false;
        });
        var config = Configuration.Default.WithScripts(scripting).With(provider).WithMockRequester();
        var content = @"<body>
<script src=""https://code.jquery.com/jquery-2.2.4.js"" integrity=""sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI="" crossorigin=""anonymous""></script>
</body>";
        await BrowsingContext.New(config).OpenAsync(res => res.Content(content).Address("http://localhost"), TestContext.Current.CancellationToken);

        Assert.True(hasBeenChecked);
        Assert.False(hasBeenParsed);
    }

    [Fact]
    public async Task JavaScriptWithIntegrityAndCorsShouldBeCheckedAndParsed()
    {
        var hasBeenChecked = false;
        var hasBeenParsed = false;
        var scripting = new CallbackScriptEngine(_ =>
        {
            hasBeenParsed = true;
        }, MimeTypeNames.DefaultJavaScript);
        var provider = new MockIntegrityProvider((_, _) =>
        {
            hasBeenChecked = true;
            return true;
        });
        var config = Configuration.Default.WithScripts(scripting).With(provider).WithMockRequester();
        var content = @"<body>
<script src=""https://code.jquery.com/jquery-2.2.4.js"" integrity=""sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI="" crossorigin=""anonymous""></script>
</body>";
        await BrowsingContext.New(config).OpenAsync(res => res.Content(content).Address("http://localhost"), TestContext.Current.CancellationToken);

        Assert.True(hasBeenChecked);
        Assert.True(hasBeenParsed);
    }

    [Fact]
    public async Task JavaScriptWithIntegrityButNoCorsShouldNotBeChecked()
    {
        var hasBeenChecked = false;
        var hasBeenParsed = false;
        var scripting = new CallbackScriptEngine(_ =>
        {
            hasBeenParsed = true;
        }, MimeTypeNames.DefaultJavaScript);
        var provider = new MockIntegrityProvider((_, _) =>
        {
            hasBeenChecked = true;
            return false;
        });
        var config = Configuration.Default.WithScripts(scripting).With(provider).WithMockRequester();
        var content = @"<body>
<script src=""https://code.jquery.com/jquery-2.2.4.js"" integrity=""sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI=""></script>
</body>";
        await BrowsingContext.New(config).OpenAsync(res => res.Content(content).Address("http://localhost"), TestContext.Current.CancellationToken);

        Assert.False(hasBeenChecked);
        Assert.True(hasBeenParsed);
    }

    [Fact]
    public async Task LoadCustomDocumentWithRegisteredHandler()
    {
        var type = "text/markdown";
        var context = BrowsingContext.New();
        var documentFactory = context.GetFactory<IDocumentFactory>() as DefaultDocumentFactory;
        documentFactory.Register(type, (ctx, options, _) => Task.FromResult<IDocument>(new MarkdownDocument(ctx, options.Source)));
        var document = await context.OpenAsync(res => res.Content("").Header(HeaderNames.ContentType, type), TestContext.Current.CancellationToken);
        Assert.IsAssignableFrom<MarkdownDocument>(document);
    }

    [Fact]
    public async Task LoadCustomDocumentWithoutUnregisteredHandler()
    {
        var type = "text/markdown";
        var context = BrowsingContext.New();
        var documentFactory = context.GetFactory<IDocumentFactory>() as DefaultDocumentFactory;
        documentFactory.Register(type, (ctx, options, _) => Task.FromResult<IDocument>(new MarkdownDocument(ctx, options.Source)));
        var handler = documentFactory.Unregister(type);
        var document = await context.OpenAsync(res => res.Content("").Header(HeaderNames.ContentType, type), TestContext.Current.CancellationToken);
        Assert.NotNull(handler);
        Assert.IsAssignableFrom<HtmlDocument>(document);
    }

    [Fact]
    public async Task LoadCustomDocumentWithoutAnyHandler()
    {
        var config = new Configuration();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(res => res.Content("").Header(HeaderNames.ContentType, "text/markdown"), TestContext.Current.CancellationToken);
        Assert.IsAssignableFrom<HtmlDocument>(document);
    }

    [Fact]
    public async Task LoadingResourcesFromAStreamShouldNotFail()
    {
        if (Helper.IsNetworkAvailable())
        {
            var uri = "http://florian-rappl.de";
            var config = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });

            var req = new HttpClient();
            var message = new HttpRequestMessage(System.Net.Http.HttpMethod.Get, uri);

            using var response = await req.SendAsync(message, TestContext.Current.CancellationToken);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stream = await response.Content.ReadAsStreamAsync(TestContext.Current.CancellationToken);
                var document = await BrowsingContext.New(config).OpenAsync(m => m.Content(stream).Address(uri), TestContext.Current.CancellationToken);
                Assert.NotNull(document);
            }
        }
    }

    [Fact]
    public async Task LoadingIframeWithEmptySourceIsLikeLoadingWithout()
    {
        var config = new Configuration().WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var context = BrowsingContext.New(config);
        var source = @"<iframe src="""" class=""updates-iframe""></iframe>";
        var document = await context.OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var iframe = document.QuerySelector<HtmlIFrameElement>("iframe");
        Assert.Null(iframe.ContentDocument);
    }
}
