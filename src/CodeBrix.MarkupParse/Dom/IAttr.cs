using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// This type represents a DOM element's attribute as an object. 
/// </summary>
[DomName("Attr")]
public interface IAttr : INode, IEquatable<IAttr>
{
    /// <summary>
    /// Gets the local name of the attribute.
    /// </summary>
    [DomName("localName")]
    string LocalName { get; }

    /// <summary>
    /// Gets the attribute's name.
    /// </summary>
    [DomName("name")]
    string Name { get; }

    /// <summary>
    /// Gets the attribute's value.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }

    /// <summary>
    /// Gets the namespace URL of the attribute.
    /// </summary>
    [DomName("namespaceURI")]
    string NamespaceUri { get; }

    /// <summary>
    /// Gets the prefix used by the namespace.
    /// </summary>
    [DomName("prefix")]
    string Prefix { get; }

    /// <summary>
    /// Gets the owning element, if any.
    /// </summary>
    [DomName("ownerElement")]
    IElement OwnerElement { get; }

    /// <summary>
    /// Gets always true.
    /// </summary>
    [DomName("specified")]
    bool IsSpecified { get; }
}
