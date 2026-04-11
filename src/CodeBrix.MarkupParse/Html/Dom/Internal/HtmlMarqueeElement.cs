using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML marquee element.
/// </summary>
[DomHistorical]
sealed class HtmlMarqueeElement : HtmlElement, IHtmlMarqueeElement
{
    #region ctor

    public HtmlMarqueeElement(Document owner, string prefix = null)
        : base(owner, TagNames.Marquee, prefix, NodeFlags.Special | NodeFlags.Scoped)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the minimum delay in ms.
    /// </summary>
    public int MinimumDelay
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets or sets the amount of scrolling in pixels.
    /// </summary>
    public int ScrollAmount
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the delay of scrolling in ms.
    /// </summary>
    public int ScrollDelay
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the loop number.
    /// </summary>
    public int Loop
    {
        get;
        set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Starts the marquee loop.
    /// </summary>
    public void Start() => Owner.QueueTask(() => this.FireSimpleEvent(EventNames.Play));

    /// <summary>
    /// Stops the marquee loop.
    /// </summary>
    public void Stop() => Owner.QueueTask(() => this.FireSimpleEvent(EventNames.Pause));

    #endregion
}
