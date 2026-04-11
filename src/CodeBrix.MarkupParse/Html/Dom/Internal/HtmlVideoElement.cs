using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Media;
using CodeBrix.MarkupParse.Media.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML video element.
/// </summary>
sealed class HtmlVideoElement : HtmlMediaElement<IVideoInfo>, IHtmlVideoElement
{
    #region Fields

    private IVideoTrackList _videos;

    #endregion

    #region ctor

    public HtmlVideoElement(Document owner, string prefix = null)
        : base(owner, TagNames.Video, prefix)
    {
        _videos = null;
    }

    #endregion

    #region Properties

    public override IVideoTrackList VideoTracks => _videos;

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

    public int OriginalWidth => Media?.Width ?? 0;

    public int OriginalHeight => Media?.Height ?? 0;

    public string Poster
    {
        get => this.GetUrlAttribute(AttributeNames.Poster);
        set => this.SetOwnAttribute(AttributeNames.Poster, value);
    }

    #endregion
}
