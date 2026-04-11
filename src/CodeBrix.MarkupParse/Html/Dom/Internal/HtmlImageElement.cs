using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Processors;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the image element.
/// </summary>
sealed class HtmlImageElement : HtmlElement, IHtmlImageElement
{
    #region Fields

    private readonly ImageRequestProcessor _request;

    #endregion

    #region ctor
    
    public HtmlImageElement(Document owner, string prefix = null)
        : base(owner, TagNames.Img, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
        _request = new ImageRequestProcessor(owner.Context);
    }

    #endregion

    #region Properties

    public IDownload CurrentDownload => _request?.Download;

    public string ActualSource => IsCompleted ? _request.Source : string.Empty;

    public string SourceSet
    {
        get => this.GetOwnAttribute(AttributeNames.SrcSet);
        set => this.SetOwnAttribute(AttributeNames.SrcSet, value);
    }

    public string Sizes
    {
        get => this.GetOwnAttribute(AttributeNames.Sizes);
        set => this.SetOwnAttribute(AttributeNames.Sizes, value);
    }

    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string AlternativeText
    {
        get => this.GetOwnAttribute(AttributeNames.Alt);
        set => this.SetOwnAttribute(AttributeNames.Alt, value);
    }

    public string CrossOrigin
    {
        get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
        set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    public string UseMap
    {
        get => this.GetOwnAttribute(AttributeNames.UseMap);
        set => this.SetOwnAttribute(AttributeNames.UseMap, value);
    }

    public int DisplayWidth
    {
        get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(OriginalWidth);
        set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
        get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(OriginalHeight);
        set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int OriginalWidth => _request?.Width ?? 0;

    public int OriginalHeight => _request?.Height ?? 0;

    public bool IsCompleted => _request?.IsReady ?? false;

    public bool IsMap
    {
        get => this.GetBoolAttribute(AttributeNames.IsMap);
        set => this.SetBoolAttribute(AttributeNames.IsMap, value);
    }

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();
        UpdateSource();
    }

    internal void UpdateSource()
    {
        var url = this.GetImageCandidate();

        if (url != null)
        {
            this.Process(_request, url);
        }
    }

    #endregion
}
