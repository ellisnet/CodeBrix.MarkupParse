using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom.Events;
using CodeBrix.MarkupParse.Html.Construction;
using CodeBrix.MarkupParse.Text;
using System;
using System.IO;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a generic node attribute.
/// </summary>
public sealed class Attr : IAttr, IConstructableAttr
{
    #region Fields

    private readonly string _localName;
    private readonly string _prefix;
    private readonly string _namespace;
    private string _value;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new attribute with the given local name.
    /// </summary>
    /// <param name="localName">The local name of the attribute.</param>
    public Attr(string localName)
        : this(localName, string.Empty)
    {
    }

    /// <summary>
    /// Creates a new attribute with the given local name and value.
    /// </summary>
    /// <param name="localName">The local name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    public Attr(string localName, string value)
    {
        _localName = localName;
        _value = value;
    }

    /// <summary>
    /// Creates a new attribute with the given properties.
    /// </summary>
    /// <param name="prefix">The prefix of the attribute.</param>
    /// <param name="localName">The local name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <param name="namespaceUri">The namespace of the attribute.</param>
    public Attr(string prefix, string localName, string value, string namespaceUri)
    {
        _prefix = prefix;
        _localName = localName;
        _value = value;
        _namespace = namespaceUri;
    }

    #endregion

    #region Internal Properties

    internal NamedNodeMap Container
    {
        get;
        set;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets always true.
    /// </summary>
    public bool IsSpecified => true;

    /// <summary>
    /// Gets the owner of the attribute, if any.
    /// </summary>
    public IElement OwnerElement => Container?.Owner;

    /// <summary>
    /// Gets the attribute's prefix.
    /// </summary>
    public string Prefix => _prefix;

    /// <summary>
    /// Gets if the attribute is an id attribute.
    /// </summary>
    public bool IsId => _prefix is null && _localName.Isi(AttributeNames.Id);

    /// <summary>
    /// Gets if the value is given or not.
    /// </summary>
    public bool Specified => !string.IsNullOrEmpty(_value);

    /// <summary>
    /// Gets the attribute's fully qualified name.
    /// </summary>
    public string Name => _prefix is null ? _localName : string.Concat(_prefix, ":", _localName);

    StringOrMemory IConstructableAttr.Value
    {
        get => Value;
        set => Value = value.ToString();
    }

    StringOrMemory IConstructableAttr.Name => Name;

    /// <summary>
    /// Gets the attribute's value.
    /// </summary>
    public string Value
    {
        get => _value;
        set
        {
            var oldValue = _value;
            _value = value;
            Container?.RaiseChangedEvent(this, value, oldValue);
        }
    }

    /// <summary>
    /// Gets the attribute's local name.
    /// </summary>
    public string LocalName => _localName;

    /// <summary>
    /// Gets the attribute's namespace.
    /// </summary>
    public string NamespaceUri => _namespace;

    string INode.BaseUri => OwnerElement!.BaseUri;

    Url INode.BaseUrl => OwnerElement?.BaseUrl;

    string INode.NodeName => Name;

    INodeList INode.ChildNodes => NodeList.Empty;

    IDocument INode.Owner => OwnerElement?.Owner;

    IElement INode.ParentElement => null;

    INode INode.Parent => null;

    INode INode.FirstChild => null;

    INode INode.LastChild => null;

    INode INode.NextSibling => null;

    INode INode.PreviousSibling => null;

    NodeType INode.NodeType => NodeType.Attribute;

    string INode.NodeValue
    {
        get => Value;
        set => Value = value;
    }

    string INode.TextContent
    {
        get => Value;
        set => Value = value;
    }

    bool INode.HasChildNodes => false;

    NodeFlags INode.Flags => throw new NotImplementedException();

    #endregion

    #region Methods

    /// <summary>
    /// Checks if the attribute equals another attribute.
    /// </summary>
    /// <param name="other">The other attribute.</param>
    /// <returns>True if both are equivalent, otherwise false.</returns>
    public bool Equals(IAttr other) =>  Prefix.Is(other?.Prefix) && NamespaceUri.Is(other?.NamespaceUri) && Value.Is(other?.Value);

    /// <summary>
    /// Computes the hash code of the attribute.
    /// </summary>
    /// <returns>The computed hash code.</returns>
    public override int GetHashCode()
    {
        const int prime = 31;
        var result = 1;

        result = result * prime + _localName.GetHashCode();
        result = result * prime + (_value ?? string.Empty).GetHashCode();
        result = result * prime + (_namespace ?? string.Empty).GetHashCode();
        result = result * prime + (_prefix ?? string.Empty).GetHashCode();

        return result;
    }

    #endregion

    #region INode Implementation

    INode INode.Clone(bool deep) => new Attr(_prefix, _localName, _value, _namespace);

    bool INode.Equals(INode otherNode) => otherNode is IAttr attr && Equals(attr);

    DocumentPositions INode.CompareDocumentPosition(INode otherNode) => OwnerElement?.CompareDocumentPosition(otherNode) ?? DocumentPositions.Disconnected;

    void INode.Normalize() {}

    bool INode.Contains(INode otherNode) => false;

    bool INode.IsDefaultNamespace(string namespaceUri) => OwnerElement?.IsDefaultNamespace(namespaceUri) ?? false;

    string INode.LookupNamespaceUri(string prefix) => OwnerElement?.LookupNamespaceUri(prefix);

    string INode.LookupPrefix(string namespaceUri) => OwnerElement?.LookupPrefix(namespaceUri);

    INode INode.AppendChild(INode child) => throw new DomException(DomError.NotSupported);

    INode INode.InsertBefore(INode newElement, INode referenceElement) => throw new DomException(DomError.NotSupported);

    INode INode.RemoveChild(INode child) => throw new DomException(DomError.NotSupported);

    INode INode.ReplaceChild(INode newChild, INode oldChild) => throw new DomException(DomError.NotSupported);

    void IEventTarget.AddEventListener(string type, DomEventHandler callback, bool capture) => throw new DomException(DomError.NotSupported);

    void IEventTarget.RemoveEventListener(string type, DomEventHandler callback, bool capture) => throw new DomException(DomError.NotSupported);

    void IEventTarget.InvokeEventListener(Event ev) => throw new DomException(DomError.NotSupported);

    bool IEventTarget.Dispatch(Event ev) => throw new DomException(DomError.NotSupported);

    void IMarkupFormattable.ToHtml(TextWriter writer, IMarkupFormatter formatter) {}

    #endregion
}
