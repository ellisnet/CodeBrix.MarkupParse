using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Used to declare properties for the marquee element.
/// </summary>
[DomName("HTMLMarqueeElement")]
public interface IHtmlMarqueeElement : IHtmlElement
{
    /// <summary>
    /// Gets the minimum delay in ms.
    /// </summary>
    int MinimumDelay { get; }

    /// <summary>
    /// Gets or sets the amount of scrolling in pixels.
    /// </summary>
    [DomName("scrollamount")]
    int ScrollAmount { get; set; }

    /// <summary>
    /// Gets or sets the delay of scrolling in ms.
    /// </summary>
    [DomName("scrolldelay")]
    int ScrollDelay { get; set; }

    /// <summary>
    /// Gets or sets the loop number.
    /// </summary>
    [DomName("loop")]
    int Loop { get; set; }
}
