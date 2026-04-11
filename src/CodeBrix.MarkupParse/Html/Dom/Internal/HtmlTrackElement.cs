using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Media.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML track element.
/// </summary>
sealed class HtmlTrackElement : HtmlElement, IHtmlTrackElement
{
    #region Fields

    private TrackReadyState _ready;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new HTML track element.
    /// </summary>
    public HtmlTrackElement(Document owner, string prefix = null)
        : base(owner, TagNames.Track, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
        _ready = TrackReadyState.None;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the kind of the track.
    /// </summary>
    public string Kind
    {
        get => this.GetOwnAttribute(AttributeNames.Kind);
        set => this.SetOwnAttribute(AttributeNames.Kind, value);
    }

    /// <summary>
    /// Gets or sets the media source.
    /// </summary>
    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    /// <summary>
    /// Gets or sets the language of the source.
    /// </summary>
    public string SourceLanguage
    {
        get => this.GetOwnAttribute(AttributeNames.SrcLang);
        set => this.SetOwnAttribute(AttributeNames.SrcLang, value);
    }

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    public string Label
    {
        get => this.GetOwnAttribute(AttributeNames.Label);
        set => this.SetOwnAttribute(AttributeNames.Label, value);
    }

    /// <summary>
    /// Gets or sets if given track is the default track.
    /// </summary>
    public bool IsDefault
    {
        get => this.GetBoolAttribute(AttributeNames.Default);
        set => this.SetBoolAttribute(AttributeNames.Default, value);
    }

    /// <summary>
    /// Gets the ready state of the given track.
    /// </summary>
    public TrackReadyState ReadyState => _ready;

    public ITextTrack Track => null;

    #endregion
}
