using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Browser.Dom; //Was previously: namespace AngleSharp.Browser.Dom

/// <summary>
/// Connectivity information regarding the navigator.
/// </summary>
[DomName("NavigatorOnLine")]
[DomNoInterfaceObject]
public interface INavigatorOnline
{
    /// <summary>
    /// Gets if the connection is established.
    /// </summary>
    [DomName("onLine")]
    bool IsOnline { get; }
}
