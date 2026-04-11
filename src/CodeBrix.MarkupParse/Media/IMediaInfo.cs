using CodeBrix.MarkupParse.Media.Dom;

namespace CodeBrix.MarkupParse.Media; //Was previously: namespace AngleSharp.Media

/// <summary>
/// Contains information about a media resource.
/// </summary>
public interface IMediaInfo : IResourceInfo
{
    /// <summary>
    /// Gets the controller responsible for the media.
    /// </summary>
    IMediaController Controller { get; }
}
