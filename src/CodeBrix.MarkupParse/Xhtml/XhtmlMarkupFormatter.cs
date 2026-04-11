using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Xhtml; //Was previously: namespace AngleSharp.Xhtml

/// <summary>
/// Represents the standard XHTML markup formatter.
/// </summary>
public class XhtmlMarkupFormatter : IMarkupFormatter
{
    #region Instance

    /// <summary>
    /// An instance of the XhtmlMarkupFormatter.
    /// </summary>
    public static readonly IMarkupFormatter Instance = new XhtmlMarkupFormatter();

    #endregion

    #region Private fields

    private readonly bool _emptyTagsToSelfClosing;

    #endregion

    #region Constructors

    /// <summary>
    /// Default constructor for <see cref="XhtmlMarkupFormatter"/>
    /// </summary>
    public XhtmlMarkupFormatter() : this(true)
    {
    }

    /// <summary>
    /// Constructor for <see cref="XhtmlMarkupFormatter"/>
    /// </summary>
    /// <param name="emptyTagsToSelfClosing">
    /// Specify if empty elements like &lt;div&gt;&lt;/div&gt;
    /// should be converted to self-closing ones like &lt;div /&gt;
    /// </param>
    public XhtmlMarkupFormatter(bool emptyTagsToSelfClosing)
    {
        _emptyTagsToSelfClosing = emptyTagsToSelfClosing;
    }

    #endregion

    /// <summary>
    /// Gets the status if empty tags will be self-closed or not.
    /// </summary>
    public bool IsSelfClosingEmptyTags => _emptyTagsToSelfClosing;

    #region Methods

    /// <inheritdoc />
    public virtual string CloseTag(IElement element, bool selfClosing)
    {
        var prefix = element.Prefix;
        var name = element.LocalName;
        var tag = !string.IsNullOrEmpty(prefix) ? prefix + ":" + name : name;
        return (selfClosing || _emptyTagsToSelfClosing && !element.HasChildNodes) ? string.Empty : string.Concat("</", tag, ">");
    }

    /// <inheritdoc />
    public virtual string Comment(IComment comment) =>
        string.Concat("<!--", comment.Data, "-->");

    /// <inheritdoc />
    public virtual string Doctype(IDocumentType doctype)
    {
        var publicId = doctype.PublicIdentifier;
        var systemId = doctype.SystemIdentifier;
        var noExternalId = string.IsNullOrEmpty(publicId) && string.IsNullOrEmpty(systemId);
        var externalId = noExternalId ? string.Empty : " " + (string.IsNullOrEmpty(publicId) ?
            string.Concat("SYSTEM \"", systemId, "\"") :
            string.Concat("PUBLIC \"", publicId, "\" \"", systemId, "\""));
        return string.Concat("<!DOCTYPE ", doctype.Name, externalId, ">");
    }

    /// <inheritdoc />
    public virtual string OpenTag(IElement element, bool selfClosing)
    {
        var prefix = element.Prefix;
        var temp = StringBuilderPool.Obtain();
        temp.Append(Symbols.LessThan);

        if (!string.IsNullOrEmpty(prefix))
        {
            temp.Append(prefix).Append(Symbols.Colon);
        }

        temp.Append(element.LocalName);

        foreach (var attribute in element.Attributes)
        {
            temp.Append(' ').Append(Attribute(attribute));
        }

        if (selfClosing || _emptyTagsToSelfClosing && !element.HasChildNodes)
        {
            temp.Append(" /");
        }

        temp.Append(Symbols.GreaterThan);
        return temp.ToPool();
    }

    /// <inheritdoc />
    public virtual string Processing(IProcessingInstruction processing)
    {
        var value = string.Concat(processing.Target, " ", processing.Data);
        return string.Concat("<?", value, "?>");
    }

    /// <inheritdoc />
    public virtual string LiteralText(ICharacterData text) => text.Data;

    /// <inheritdoc />
    public virtual string Text(ICharacterData text) => EscapeText(text.Data);

    /// <summary>
    /// Creates the string representation of the attribute.
    /// </summary>
    /// <param name="attribute">The attribute to serialize.</param>
    /// <returns>The string representation.</returns>
    protected virtual string Attribute(IAttr attribute)
    {
        var namespaceUri = attribute.NamespaceUri;
        var localName = attribute.LocalName;
        var value = attribute.Value;
        var temp = StringBuilderPool.Obtain();

        if (string.IsNullOrEmpty(namespaceUri))
        {
            temp.Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XmlUri))
        {
            temp.Append(NamespaceNames.XmlPrefix).Append(Symbols.Colon).Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XLinkUri))
        {
            temp.Append(NamespaceNames.XLinkPrefix).Append(Symbols.Colon).Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XmlNsUri))
        {
            temp.Append(XmlNamespaceLocalName(localName));
        }
        else
        {
            temp.Append(attribute.Name);
        }

        temp.Append(Symbols.Equality).Append(Symbols.DoubleQuote);

        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i])
            {
                case Symbols.Ampersand: temp.Append("&amp;"); break;
                case Symbols.NoBreakSpace: temp.Append("&#160;"); break;
                case Symbols.LessThan: temp.Append("&lt;"); break;
                case Symbols.DoubleQuote: temp.Append("&quot;"); break;
                default: temp.Append(value[i]); break;
            }
        }

        return temp.Append(Symbols.DoubleQuote).ToPool();
    }

    #endregion

    #region Helpers

    /// <summary>
    /// Escapes the given text by replacing special characters with their
    /// XHTML entity (amp, nbsp as numeric value, lt, and gt).
    /// </summary>
    /// <param name="content">The string to alter.</param>
    /// <returns>The altered string.</returns>
    public static string EscapeText(string content)
    {
        var temp = StringBuilderPool.Obtain();

        for (var i = 0; i < content.Length; i++)
        {
            switch (content[i])
            {
                case Symbols.Ampersand: temp.Append("&amp;"); break;
                case Symbols.NoBreakSpace: temp.Append("&#160;"); break;
                case Symbols.GreaterThan: temp.Append("&gt;"); break;
                case Symbols.LessThan: temp.Append("&lt;"); break;
                default: temp.Append(content[i]); break;
            }
        }

        return temp.ToPool();
    }

    /// <summary>
    /// Gets the local name using the XML namespace prefix if required.
    /// </summary>
    /// <param name="localName">The name to be properly represented.</param>
    /// <returns>The string representation.</returns>
    public static string XmlNamespaceLocalName(string localName) => !localName.Is(NamespaceNames.XmlNsPrefix) ? string.Concat(NamespaceNames.XmlNsPrefix, Symbols.Colon, localName) : localName;

    #endregion
}
