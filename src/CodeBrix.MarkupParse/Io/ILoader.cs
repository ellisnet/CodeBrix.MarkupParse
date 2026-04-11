using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Represents the basic interface for all loaders.
/// </summary>
public interface ILoader
{
    /// <summary>
    /// Gets the currently active downloads.
    /// </summary>
    /// <returns>The downloads in progress.</returns>
    IEnumerable<IDownload> GetDownloads();
}
