using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The Element interface represents an object within a DOM document. 
/// </summary>
[DomName("Element")]
public interface IElement : INode, IParentNode, IChildNode, INonDocumentTypeChildNode
{
    /// <summary>
    /// Gets the namespace prefix of this element.
    /// </summary>
    [DomName("prefix")]
    string Prefix { get; }

    /// <summary>
    /// Gets the local part of the qualified name of this element.
    /// </summary>
    [DomName("localName")]
    string LocalName { get; }

    /// <summary>
    /// Gets the namespace URI of this element.
    /// </summary>
    [DomName("namespaceURI")]
    string NamespaceUri { get; }

    /// <summary>
    /// Gets the given namespace URI of this element.
    /// This one will not be resolved via its parent, but only yields the provided namespace, if any.
    /// </summary>
    string GivenNamespaceUri { get; }

    /// <summary>
    /// Gets the sequence of associated attributes.
    /// </summary>
    [DomName("attributes")]
    INamedNodeMap Attributes { get; }

    /// <summary>
    /// Gets the list of class names.
    /// </summary>
    [DomName("classList")]
    ITokenList ClassList { get; }

    /// <summary>
    /// Gets or sets the value of the class attribute.
    /// </summary>
    [DomName("className")]
    string ClassName { get; set; }

    /// <summary>
    /// Gets or sets the id value of the element.
    /// </summary>
    [DomName("id")]
    string Id { get; set; }

    /// <summary>
    /// Inserts new HTML elements specified by the given HTML string at
    /// a position relative to the current element specified by the
    /// position.
    /// </summary>
    /// <param name="position">The relation to the current element.</param>
    /// <param name="html">The HTML code to generate elements for.</param>
    [DomName("insertAdjacentHTML")]
    void Insert(AdjacentPosition position, string html);

    /// <summary>
    /// Returns a boolean value indicating whether the specified element
    /// has the specified attribute or not.
    /// </summary>
    /// <param name="name">The attributes name.</param>
    /// <returns>The return value of true or false.</returns>
    [DomName("hasAttribute")]
    bool HasAttribute(string name);

    /// <summary>
    /// Returns a boolean value indicating whether the specified element
    /// has the specified attribute or not.
    /// </summary>
    /// <param name="namespaceUri">
    /// A string specifying the namespace of the attribute.
    /// </param>
    /// <param name="localName">The attributes name.</param>
    /// <returns>The return value of true or false.</returns>
    [DomName("hasAttributeNS")]
    bool HasAttribute(string namespaceUri, string localName);

    /// <summary>
    /// Returns the value of the named attribute on the specified element.
    /// </summary>
    /// <param name="name">
    /// The name of the attribute whose value you want to get.
    /// </param>
    /// <returns>
    /// If the named attribute does not exist, the value returned will be
    /// null, otherwise the attribute's value.
    /// </returns>
    [DomName("getAttribute")]
    string GetAttribute(string name);

    /// <summary>
    /// Returns the value of the named attribute on the specified element.
    /// </summary>
    /// <param name="namespaceUri">
    /// A string specifying the namespace of the attribute.
    /// </param>
    /// <param name="localName">
    /// The name of the attribute whose value you want to get.
    /// </param>
    /// <returns>
    /// If the named attribute does not exist, the value returned will be
    /// null, otherwise the attribute's value.
    /// </returns>
    [DomName("getAttributeNS")]
    string GetAttribute(string namespaceUri, string localName);

    /// <summary>
    /// Adds a new attribute or changes the value of an existing attribute
    /// on the specified element.
    /// </summary>
    /// <param name="name">The name of the attribute as a string.</param>
    /// <param name="value">The desired new value of the attribute.</param>
    /// <returns>The current element.</returns>
    [DomName("setAttribute")]
    void SetAttribute(string name, string value);

    /// <summary>
    /// Adds a new attribute or changes the value of an existing attribute
    /// on the specified element.
    /// </summary>
    /// <param name="namespaceUri">
    /// A string specifying the namespace of the attribute.
    /// </param>
    /// <param name="name">The name of the attribute as a string.</param>
    /// <param name="value">The desired new value of the attribute.</param>
    [DomName("setAttributeNS")]
    void SetAttribute(string namespaceUri, string name, string value);

    /// <summary>
    /// Removes an attribute from the specified element.
    /// </summary>
    /// <param name="name">
    /// Is a string that names the attribute to be removed.
    /// </param>
    /// <returns>True if an attribute was removed, otherwise false.</returns>
    [DomName("removeAttribute")]
    bool RemoveAttribute(string name);

    /// <summary>
    /// Removes an attribute from the specified element.
    /// </summary>
    /// <param name="namespaceUri">
    /// A string specifying the namespace of the attribute.
    /// </param>
    /// <param name="localName">
    /// Is a string that names the attribute to be removed.
    /// </param>
    /// <returns>True if an attribute was removed, otherwise false.</returns>
    [DomName("removeAttributeNS")]
    bool RemoveAttribute(string namespaceUri, string localName);

    /// <summary>
    /// Returns a set of elements which have all the given class names.
    /// </summary>
    /// <param name="classNames">
    /// A string representing the list of class names to match; class names
    /// are separated by whitespace.
    /// </param>
    /// <returns>A collection of elements.</returns>
    [DomName("getElementsByClassName")]
    IHtmlCollection<IElement> GetElementsByClassName(string classNames);

    /// <summary>
    /// Returns a NodeList of elements with the given tag name. The
    /// complete document is searched, including the root node.
    /// </summary>
    /// <param name="tagName">
    /// A string representing the name of the elements. The special string
    /// "*" represents all elements.
    /// </param>
    /// <returns>
    /// A collection of elements in the order they appear in the tree.
    /// </returns>
    [DomName("getElementsByTagName")]
    IHtmlCollection<IElement> GetElementsByTagName(string tagName);

    /// <summary>
    /// Returns a list of elements with the given tag name belonging to the
    /// given namespace. The complete document is searched, including the
    /// root node.
    /// </summary>
    /// <param name="namespaceUri">
    /// The namespace URI of elements to look for.
    /// </param>
    /// <param name="tagName">
    /// Either the local name of elements to look for or the special value
    /// "*", which matches all elements.
    /// </param>
    /// <returns>
    /// A collection of elements in the order they appear in the tree.
    /// </returns>
    [DomName("getElementsByTagNameNS")]
    IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceUri, string tagName);

    /// <summary>
    /// Checks if the element is matched by the given selector.
    /// </summary>
    /// <param name="selectors">Represents the selector to test.</param>
    /// <returns>
    /// True if the element would be selected by the specified selector,
    /// otherwise false.
    /// </returns>
    [DomName("matches")]
    bool Matches(string selectors);

    /// <summary>
    /// Returns the closest ancestor of the current element (or the current element itself) which matches the selectors given in the parameter.
    /// </summary>
    /// <param name="selectors">Represents the selector to test.</param>
    /// <returns>
    /// The closest ancestor of the current element (or the current element itself) which matches the selectors given. If there isn't such an ancestor, it returns null.
    /// </returns>
    [DomName("closest")]
    IElement Closest(string selectors);

    /// <summary>
    /// Gets or sets the inner HTML (excluding the current element) of the
    /// element.
    /// </summary>
    [DomName("innerHTML")]
    string InnerHtml { get; set; }

    /// <summary>
    /// Gets or sets the outer HTML (including the current element) of the
    /// element.
    /// </summary>
    [DomName("outerHTML")]
    string OuterHtml { get; set; }

    /// <summary>
    /// Gets the name of the tag that represents the current element.
    /// </summary>
    [DomName("tagName")]
    string TagName { get; }

    /// <summary>
    /// Creates a new shadow root for the current element, if there is none
    /// already.
    /// </summary>
    /// <param name="mode">The mode of the shadow root.</param>
    /// <returns>The new shadow root.</returns>
    [DomName("attachShadow")]
    [DomInitDict]
    IShadowRoot AttachShadow(ShadowRootMode mode = ShadowRootMode.Open);

    /// <summary>
    /// Gets the assigned slot of the current element, if any.
    /// </summary>
    [DomName("assignedSlot")]
    IElement AssignedSlot { get; }

    /// <summary>
    /// Gets the value of the slot attribute.
    /// </summary>
    [DomName("slot")]
    string Slot { get; set; }

    /// <summary>
    /// Gets the shadow root of the current element, if any.
    /// </summary>
    [DomName("shadowRoot")]
    IShadowRoot ShadowRoot { get; }

    /// <summary>
    /// Gets if the element is currently focused.
    /// </summary>
    bool IsFocused { get; }

    /// <summary>
    /// Gets the source reference if available.
    /// </summary>
    ISourceReference SourceReference { get; }
}
