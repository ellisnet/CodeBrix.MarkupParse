using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Browser.Dom; //Was previously: namespace AngleSharp.Browser.Dom

/// <summary>
/// Holds the user-agent information.
/// </summary>
[DomName("NavigatorID")]
[DomNoInterfaceObject]
public interface INavigatorId
{
    /// <summary>
    /// Gets the name of the application.
    /// </summary>
    [DomName("appName")]
    string Name { get; }

    /// <summary>
    /// Gets the version of the application.
    /// </summary>
    [DomName("appVersion")]
    string Version { get; }

    /// <summary>
    /// Gets the platform of the application.
    /// </summary>
    [DomName("platform")]
    string Platform { get; }

    /// <summary>
    /// Gets the full name of the user-agent.
    /// </summary>
    [DomName("userAgent")]
    string UserAgent { get; }
}
