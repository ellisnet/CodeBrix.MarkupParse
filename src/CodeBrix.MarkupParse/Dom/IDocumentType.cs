using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The DocumentType interface represents a Node containing a doctype.
/// </summary>
[DomName("DocumentType")]
public interface IDocumentType : INode, IChildNode
{
    /// <summary>
    /// Gets or sets the name of the document type.
    /// </summary>
    [DomName("name")]
    string Name { get; }

    /// <summary>
    /// Gets or sets the public ID of the document type.
    /// </summary>
    [DomName("publicId")]
    string PublicIdentifier { get; }

    /// <summary>
    /// Gets or sets the system ID of the document type.
    /// </summary>
    [DomName("systemId")]
    string SystemIdentifier { get; }
}
