using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Io.Dom; //Was previously: namespace AngleSharp.Io.Dom

/// <summary>
/// Represents a concrete file.
/// http://dev.w3.org/2006/webapi/FileAPI/#dfn-file
/// </summary>
[DomName("File")]
public interface IFile : IBlob
{
    /// <summary>
    /// Gets the file's name.
    /// </summary>
    [DomName("name")]
    string Name { get; }

    /// <summary>
    /// Gets the last modified date of the file.
    /// </summary>
    [DomName("lastModified")]
    DateTime LastModified { get; }
}
