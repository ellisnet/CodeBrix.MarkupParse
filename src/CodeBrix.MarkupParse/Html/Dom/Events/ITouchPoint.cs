using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// Represents the interface for the data of a single touch point.
/// </summary>
[DomName("Touch")]
public interface ITouchPoint
{
    /// <summary>
    /// Gets the id of the touch point.
    /// </summary>
    [DomName("identifier")]
    int Id { get; }

    /// <summary>
    /// Gets the target of the touch point.
    /// </summary>
    [DomName("target")]
    IEventTarget Target { get; }

    /// <summary>
    /// Gets the x-coordinate relative to the screen.
    /// </summary>
    [DomName("screenX")]
    int ScreenX { get; }

    /// <summary>
    /// Gets the y-coordinate relative to the screen.
    /// </summary>
    [DomName("screenY")]
    int ScreenY { get; }

    /// <summary>
    /// Gets the x-coordinate relative to the client.
    /// </summary>
    [DomName("clientX")]
    int ClientX { get; }

    /// <summary>
    /// Gets the y-coordinate relative to the client.
    /// </summary>
    [DomName("clientY")]
    int ClientY { get; }

    /// <summary>
    /// Gets the x-coordinate relative to the page.
    /// </summary>
    [DomName("pageX")]
    int PageX { get; }

    /// <summary>
    /// Gets the y-coordinate relative to the page.
    /// </summary>
    [DomName("pageY")]
    int PageY { get; }
}
