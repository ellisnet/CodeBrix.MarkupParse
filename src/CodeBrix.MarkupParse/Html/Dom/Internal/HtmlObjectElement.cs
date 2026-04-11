using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Processors;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML object element.
/// </summary>
sealed class HtmlObjectElement : HtmlFormControlElement, IHtmlObjectElement
{
    #region Fields

    private readonly ObjectRequestProcessor _request;

    #endregion

    #region ctor
    
    public HtmlObjectElement(Document owner, string prefix = null)
        : base(owner, TagNames.Object, prefix, NodeFlags.Scoped)
    {
        _request = new ObjectRequestProcessor(owner.Context);
    }

    #endregion

    #region Properties

    public IDownload CurrentDownload => _request?.Download;

    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Data);
        set => this.SetOwnAttribute(AttributeNames.Data, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public bool TypeMustMatch
    {
        get => this.GetBoolAttribute(AttributeNames.TypeMustMatch);
        set => this.SetBoolAttribute(AttributeNames.TypeMustMatch, value);
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

    public IDocument ContentDocument => null;

    public IWindow ContentWindow => null;

    #endregion

    #region Methods

    protected override bool CanBeValidated()
    {
        return false;
    }

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();
        UpdateSource(this.GetOwnAttribute(AttributeNames.Data));
    }

    internal void UpdateSource(string value)
{
        if (value != null)
        {
            var url = new Url(Source!);
            this.Process(_request, url);
        }
    }

    #endregion
}
