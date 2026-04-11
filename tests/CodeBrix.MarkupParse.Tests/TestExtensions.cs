using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Scripting;
using CodeBrix.MarkupParse.Tests.External;
using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Text;
using System;
using System.IO;
using Xunit;

namespace CodeBrix.MarkupParse.Tests; //Was previously: namespace AngleSharp.Core.Tests

static class TestExtensions
{
    public static string GetTagName(this INode node)
    {
        var element = node as IElement;

        Assert.Equal(NodeType.Element, node.NodeType);
        Assert.NotNull(element);
        Assert.Null(element.Prefix);

        return element.LocalName;
    }

    public static IConfiguration WithScripting(this IConfiguration config)
    {
        var service = new CallbackScriptEngine(_ => { }, MimeTypeNames.DefaultJavaScript);
        return config.With(service);
    }

    public static IConfiguration WithScripts<T>(this IConfiguration config, T scripting)
        where T : IScriptingService
    {
        return config.With(scripting);
    }

    public static IConfiguration WithPageRequester(this IConfiguration config, bool enableNavigation = true, bool enableResourceLoading = false)
    {
        return config.With(new PageRequester()).WithDefaultLoader(new LoaderOptions
        {
            IsResourceLoadingEnabled = enableResourceLoading,
            IsNavigationDisabled = !enableNavigation,
        });
    }

    public static IConfiguration WithMockRequester(this IConfiguration config, Action<Request> onRequest = null)
    {
        var mockRequester = new MockRequester { OnRequest = onRequest };
        return config.WithMockRequester(mockRequester);
    }

    public static IConfiguration WithVirtualRequester(this IConfiguration config, Func<Request, IResponse> onRequest = null)
    {
        var mockRequester = new VirtualRequester(onRequest);
        return config.WithMockRequester(mockRequester);
    }

    public static IConfiguration WithMockRequester(this IConfiguration config, IRequester mockRequester)
    {
        return config.With(mockRequester).WithDefaultLoader(new LoaderOptions
        {
            IsResourceLoadingEnabled = true,
        });
    }

    public static IDocument ToHtmlDocument(this string sourceCode, IConfiguration configuration = null, DomEventHandler onError = null)
    {
        var context = BrowsingContext.New(configuration ?? Configuration.Default);
        var htmlParser = context.GetService<IHtmlParser>();

        if (onError is not null)
        {
            htmlParser.Error += onError;
        }

        if (TestRuntime.UsePrefetchedTextSource)
        {
            return htmlParser.ParseDocument(sourceCode.AsMemory());
        }
        else
        {
            return htmlParser.ParseDocument(sourceCode);
        }
    }

    public static INodeList ToHtmlFragment(this string sourceCode, IElement contextElement = null, IConfiguration configuration = null)
    {
        var context = BrowsingContext.New(configuration);
        var htmlParser = context.GetService<IHtmlParser>();
        return htmlParser.ParseFragment(sourceCode, contextElement);
    }

    public static INodeList ToHtmlFragment(this string sourceCode, string contextElement, IConfiguration configuration = null)
    {
        var doc = string.Empty.ToHtmlDocument();
        var element = doc.CreateElement(contextElement);
        return sourceCode.ToHtmlFragment(element, configuration);
    }

    public static IDocument ToHtmlDocument(this Stream content, IConfiguration configuration = null)
    {
        var context = BrowsingContext.New(configuration);
        var htmlParser = context.GetService<IHtmlParser>();
        return htmlParser.ParseDocument(content);
    }
}
