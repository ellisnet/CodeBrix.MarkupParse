using CodeBrix.MarkupParse.Browser;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Processors;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base class for frame elements.
/// </summary>
abstract class HtmlFrameElementBase : HtmlFrameOwnerElement
{
    #region Fields

    private IBrowsingContext _context;
    private FrameRequestProcessor _request;

    #endregion

    #region ctor

    public HtmlFrameElementBase(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
        : base(owner, name, prefix, flags | NodeFlags.Special)
    {
        _request = new FrameRequestProcessor(owner.Context, this);
    }

    #endregion

    #region Properties

    public IDownload CurrentDownload => _request?.Download;

    public string Name
    {
        get => this.GetOwnAttribute(AttributeNames.Name);
        set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Scrolling
    {
        get => this.GetOwnAttribute(AttributeNames.Scrolling);
        set => this.SetOwnAttribute(AttributeNames.Scrolling, value);
    }

    public IDocument ContentDocument => _context?.Active;

    public string LongDesc
    {
        get => this.GetOwnAttribute(AttributeNames.LongDesc);
        set => this.SetOwnAttribute(AttributeNames.LongDesc, value);
    }

    public string FrameBorder
    {
        get => this.GetOwnAttribute(AttributeNames.FrameBorder);
        set => this.SetOwnAttribute(AttributeNames.FrameBorder, value);
    }

    public IBrowsingContext NestedContext => _context ??= NewChildContext();

    #endregion

    #region Internal Methods

    internal virtual string GetContentHtml()
    {
        return null!;
    }

    internal override void SetupElement()
    {
        base.SetupElement();

        _context ??= NewChildContext();
        if (this.GetOwnAttribute(AttributeNames.Src) != null)
        {
            UpdateSource();
        }
    }

    internal void UpdateSource()
    {
        var content = GetContentHtml();
        var source = Source;

        if ((source != null && source != Owner.DocumentUri) || content != null)
        {
            var url = this.HyperReference(source!);
            this.Process(_request, url!);
        }
    }

    #endregion

    #region Helpers

    private IBrowsingContext NewChildContext()
    {
        var childContext = default(IBrowsingContext);
        if (Context is BrowsingContext context)
        {
            childContext  = context.CreateChild(Name, Sandboxes.None, true);
        }
        else
        {
            childContext  = Context.CreateChild(Name, Sandboxes.None);
        }
        Owner.AttachReference(childContext);
        return childContext;
    }

    #endregion
}
