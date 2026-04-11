using System;

namespace CodeBrix.MarkupParse.Media; //Was previously: namespace AngleSharp.Media

/// <summary>
/// Contains information about a general object file.
/// </summary>
public interface IObjectInfo : IResourceInfo
{
    /// <summary>
    /// Gets the width of the object.
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Gets the height of the object.
    /// </summary>
    int Height { get; }
}
