using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io.Processors; //Was previously: namespace AngleSharp.Io.Processors

sealed class FrameRequestProcessor : BaseRequestProcessor
{
    #region Fields
    
    private readonly HtmlFrameElementBase _element;

    #endregion

    #region ctor

    public FrameRequestProcessor(IBrowsingContext context, HtmlFrameElementBase element)
        : base(context?.GetService<IResourceLoader>()!)
    {
        _element = element;
    }

    #endregion

    #region Properties

    public IDocument Document
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    public override Task ProcessAsync(ResourceRequest request)
    {
        var contentHtml = _element!.GetContentHtml();

        if (contentHtml != null)
        {
            var referer = _element.Owner.DocumentUri;
            return ProcessResponse(contentHtml, referer);
        }

        return base.ProcessAsync(request);
    }

    protected override Task ProcessResponseAsync(IResponse response)
    {
        var cancel = CancellationToken.None;
        var context = _element.NestedContext;
        var task = context.OpenAsync(response, cancel);
        return WaitResponse(task);
    }

    #endregion

    #region Helpers

    private Task ProcessResponse(string response, string referer)
    {
        var cancel = CancellationToken.None;
        var context = _element.NestedContext;
        var task = context.OpenAsync(m => m.Content(response).Address(referer), cancel);
        return WaitResponse(task);
    }

    private async Task WaitResponse(Task<IDocument> task)
    {
        Document = await task.ConfigureAwait(false);
    }

    #endregion
}
