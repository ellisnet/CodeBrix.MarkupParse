using System;

namespace CodeBrix.MarkupParse.Media; //Was previously: namespace AngleSharp.Media

/// <summary>
/// Contains information about a video file.
/// </summary>
public interface IVideoInfo : IMediaInfo
{
    /// <summary>
    /// Gets the width of the video.
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Gets the height of the video.
    /// </summary>
    int Height { get; }
}
