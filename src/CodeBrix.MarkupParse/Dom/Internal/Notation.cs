using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a notation node.
/// </summary>
[DomName("Notation")]
public sealed class Notation : Node
{
    #region ctor

    /// <summary>
    /// Creates a new notation node.
    /// </summary>
    public Notation(Document owner, string name)
        : base(owner, name, NodeType.Notation)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the value of the public identifier.
    /// </summary>
    [DomName("publicId")]
    public string PublicId
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the value of the system identifier.
    /// </summary>
    [DomName("systemId")]
    public string SystemId
    {
        get;
        set;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns a duplicate of the node on which this method was called.
    /// </summary>
    /// <returns>The duplicate node.</returns>

    public override Node Clone(Document newOwner, bool deep)
    {
        var node = new Notation(newOwner, NodeName);
        CloneNode(node, newOwner, deep);
        return node;
    }

    #endregion
}
