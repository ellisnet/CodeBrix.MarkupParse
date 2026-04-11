using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class PageImportTests
{
    [Fact]
    public async Task ImportPageFromVirtualRequest()
    {
        var requester = new MockRequester();
        var receivedRequest = new TaskCompletionSource<string>();
        requester.OnRequest = request => receivedRequest.SetResult(request.Address.Href);
        var config = Configuration.Default.With(requester).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });

        var document = await BrowsingContext.New(config).OpenAsync(m => m.Content("<!doctype html><link rel=import href=http://example.com/test.html>"), TestContext.Current.CancellationToken);
        var link = document.QuerySelector<IHtmlLinkElement>("link");
        var result = await receivedRequest.Task;

        Assert.Equal("import", link.Relation);
        Assert.NotNull(link.Import);
        Assert.Equal("http://example.com/test.html", result);
    }

    [Fact]
    public async Task ImportPageWithDirectCycle()
    {
        var content = "<!doctype html><link rel=import href=http://example.com/test.html>";
        var requester = new MockRequester();
        var requestCount = 0;
        requester.OnRequest = _ => requestCount++;
        requester.BuildResponse(_ => content);
        var config = Configuration.Default.With(requester).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var document = await BrowsingContext.New(config).OpenAsync(m => m.Content(content), TestContext.Current.CancellationToken);
        var link = document.QuerySelector<IHtmlLinkElement>("link");
        Assert.Equal("import", link.Relation);
        Assert.NotNull(link.Import);
        Assert.Equal(1, requestCount);
    }

    [Fact]
    public async Task ImportPageWithIndirectCycle()
    {
        var content = "<!doctype html><link rel=import href=http://example.com/test.html>";
        var nested = new Queue<string>(new [] 
        {
            "<!doctype html><link rel=import href=http://example.com/foo.html>",
            "<!doctype html><link rel=import href=http://example.com/bar.html>",
            "<!doctype html><link rel=import href=http://example.com/test.html>",
            "<!doctype html><link rel=import href=http://example.com/foo.html>"
        });
        var requester = new MockRequester();
        var requestCount = 0;
        requester.OnRequest = _ => requestCount++;
        requester.BuildResponse(_ => nested.Dequeue());
        var config = Configuration.Default.With(requester).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var document = await BrowsingContext.New(config).OpenAsync(m => m.Content(content), TestContext.Current.CancellationToken);
        var link = document.QuerySelector<IHtmlLinkElement>("link");
        Assert.Equal("import", link.Relation);
        Assert.NotNull(link.Import);
        Assert.Equal(3, requestCount);
    }
}
