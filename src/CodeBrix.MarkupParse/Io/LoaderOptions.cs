using System;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Options for the loader.
/// </summary>
public sealed class LoaderOptions
{
    /// <summary>
    /// Gets or sets if navigation is enabled.
    /// By default it is enabled.
    /// </summary>
    public bool IsNavigationDisabled { get; set; }

    /// <summary>
    /// Gets or sets if resource loading is enabled.
    /// By default it is disabled.
    /// </summary>
    public bool IsResourceLoadingEnabled { get; set; }

    /// <summary>
    /// Gets or sets the filter, if any.
    /// </summary>
    public Predicate<Request> Filter { get; set; }
}
