using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// The interface implemented by elements that may load resources.
/// </summary>
[DomNoInterfaceObject]
public interface ILoadableElement
{
    /// <summary>
    /// Gets the current download or resource, if any.
    /// </summary>
    IDownload CurrentDownload { get; }
}
