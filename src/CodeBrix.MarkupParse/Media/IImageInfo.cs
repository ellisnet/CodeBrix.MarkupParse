using System;

namespace CodeBrix.MarkupParse.Media; //Was previously: namespace AngleSharp.Media

/// <summary>
/// Contains information about an image file.
/// </summary>
public interface IImageInfo : IResourceInfo
{
    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    int Height { get; }
}
