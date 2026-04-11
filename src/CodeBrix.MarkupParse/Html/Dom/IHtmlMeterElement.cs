using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the meter HTML element.
/// </summary>
[DomName("HTMLMeterElement")]
public interface IHtmlMeterElement : IHtmlElement, ILabelabelElement
{
    /// <summary>
    /// Gets or sets the current value.
    /// </summary>
    [DomName("value")]
    double Value { get; set; }

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [DomName("min")]
    double Minimum { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [DomName("max")]
    double Maximum { get; set; }

    /// <summary>
    /// Gets or sets the low value.
    /// </summary>
    [DomName("low")]
    double Low { get; set; }

    /// <summary>
    /// Gets or sets the high value.
    /// </summary>
    [DomName("high")]
    double High { get; set; }

    /// <summary>
    /// Gets or sets the optimum value.
    /// </summary>
    [DomName("optimum")]
    double Optimum { get; set; }
}
