using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Contains a list of common namespaces.
/// </summary>
public static class NamespaceNames
{
    /// <summary>
    /// Gets the namespace for HTML elements.
    /// </summary>
    public static readonly string HtmlUri = "http://www.w3.org/1999/xhtml";

    /// <summary>
    /// Gets the namespace for XMLNS elements.
    /// </summary>
    public static readonly string XmlNsUri = "http://www.w3.org/2000/xmlns/";

    /// <summary>
    /// Gets the namespace for XMLNS elements.
    /// </summary>
    public static readonly string XLinkUri = "http://www.w3.org/1999/xlink";

    /// <summary>
    /// Gets the namespace for XML elements.
    /// </summary>
    public static readonly string XmlUri = "http://www.w3.org/XML/1998/namespace";

    /// <summary>
    /// Gets the namespace for SVG elements.
    /// </summary>
    public static readonly string SvgUri = "http://www.w3.org/2000/svg";

    /// <summary>
    /// Gets the namespace for MathML elements.
    /// </summary>
    public static readonly string MathMlUri = "http://www.w3.org/1998/Math/MathML";

    /// <summary>
    /// Gets the prefix for XMLNS elements.
    /// </summary>
    public static readonly string XmlNsPrefix = "xmlns";

    /// <summary>
    /// Gets the prefix for XMLNS elements.
    /// </summary>
    public static readonly string XLinkPrefix = "xlink";

    /// <summary>
    /// Gets the prefix for XML elements.
    /// </summary>
    public static readonly string XmlPrefix = "xml";
}
