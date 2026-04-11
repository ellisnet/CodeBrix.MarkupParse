using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Media;
using CodeBrix.MarkupParse.Media.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML audio element.
/// </summary>
sealed class HtmlAudioElement : HtmlMediaElement<IAudioInfo>, IHtmlAudioElement
{
    #region Fields

    private IAudioTrackList _audios;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new HTML audio element.
    /// </summary>
    public HtmlAudioElement(Document owner, string prefix = null)
        : base(owner, TagNames.Audio, prefix)
    {
        _audios = null;
    }

    #endregion

    #region Properties

    public override IAudioTrackList AudioTracks => _audios;

    #endregion
}
