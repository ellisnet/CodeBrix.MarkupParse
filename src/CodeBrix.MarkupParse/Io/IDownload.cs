using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Basic contract for a currently active download.
/// </summary>
public interface IDownload : ICancellable<IResponse>
{
    /// <summary>
    /// Gets the target of the download.
    /// </summary>
    Url Target { get; }

    /// <summary>
    /// Gets the originator of the download, if any.
    /// </summary>
    object Source { get; }
}
