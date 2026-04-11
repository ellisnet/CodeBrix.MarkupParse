using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents an entity node.
/// </summary>
[DomName("Entity")]
public sealed class Entity : Node
{
    #region Fields

    private string _publicId;
    private string _systemId;
    private string _notationName;
    private string _inputEncoding;
    private string _xmlVersion;
    private string _xmlEncoding;
    private string _value;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new entity node.
    /// </summary>
    public Entity(Document owner)
        : this(owner, string.Empty)
    {
    }

    /// <summary>
    /// Creates a new entity node.
    /// </summary>
    public Entity(Document owner, string name)
        : base(owner, name, NodeType.Entity)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the public identiifer.
    /// </summary>
    [DomName("publicId")]
    public string PublicId => _publicId;

    /// <summary>
    /// Gets the system identifier.
    /// </summary>
    [DomName("systemId")]
    public string SystemId => _systemId;

    /// <summary>
    /// Gets or sets the notation name.
    /// </summary>
    [DomName("notationName")]
    public string NotationName
    {
        get => _notationName;
        set => _notationName = value;
    }

    /// <summary>
    /// Gets the used input encoding.
    /// </summary>
    [DomName("inputEncoding")]
    public string InputEncoding => _inputEncoding;

    /// <summary>
    /// Gets the used XML encoding.
    /// </summary>
    [DomName("xmlEncoding")]
    public string XmlEncoding => _xmlEncoding;

    /// <summary>
    /// Gets the used XML version.
    /// </summary>
    [DomName("xmlVersion")]
    public string XmlVersion => _xmlVersion;

    /// <summary>
    /// Gets or sets the entity's value.
    /// </summary>
    [DomName("textContent")]
    public override string TextContent
    {
        get => NodeValue;
        set => NodeValue = value;
    }

    /// <summary>
    /// Gets or sets the value of the entity.
    /// </summary>
    [DomName("nodeValue")]
    public override string NodeValue
    {
        get => _value!;
        set => _value = value;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns a duplicate of the node on which this method was called.
    /// </summary>
    public override Node Clone(Document newOwner, bool deep)
    {
        var node = new Entity(newOwner, NodeName);
        CloneNode(node, newOwner, deep);
        node._xmlEncoding = this._xmlEncoding;
        node._xmlVersion = this._xmlVersion;
        node._systemId = this._systemId;
        node._publicId = this._publicId;
        node._inputEncoding = this._inputEncoding;
        node._notationName = this._notationName;
        return node;
    }

    #endregion
}
