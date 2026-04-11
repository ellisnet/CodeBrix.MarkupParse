using CodeBrix.MarkupParse.Attributes;
using System;
using System.IO;

namespace CodeBrix.MarkupParse.Io.Dom; //Was previously: namespace AngleSharp.Io.Dom

/// <summary>
/// Represents a binary large object.
/// http://dev.w3.org/2006/webapi/FileAPI/#dfn-Blob
/// </summary>
[DomName("Blob")]
public interface IBlob : IDisposable
{
    /// <summary>
    /// Gets the length of the blob.
    /// </summary>
    [DomName("size")]
    int Length { get; }

    /// <summary>
    /// Gets the mime-type of the blob.
    /// </summary>
    [DomName("type")]
    string Type { get; }

    /// <summary>
    /// Gets if the stream to the blob is closed.
    /// </summary>
    [DomName("isClosed")]
    bool IsClosed { get; }

    /// <summary>
    /// Gets the stream to the file.
    /// </summary>
    Stream Body { get; }

    /// <summary>
    /// Slices a subset of the blob into a another blob.
    /// </summary>
    /// <param name="start">The start of the slicing in bytes.</param>
    /// <param name="end">The end of the slicing in bytes.</param>
    /// <param name="contentType">The mime-type of the new blob.</param>
    /// <returns>A new blob with this blob's subset.</returns>
    [DomName("slice")]
    IBlob Slice(int start = 0, int end = int.MaxValue, string contentType = null);

    /// <summary>
    /// Closes the stream to the blob.
    /// </summary>
    [DomName("close")]
    void Close();
}
