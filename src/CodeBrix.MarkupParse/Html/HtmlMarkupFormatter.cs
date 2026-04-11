using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Text;

namespace CodeBrix.MarkupParse.Html; //Was previously: namespace AngleSharp.Html

/// <summary>
/// Represents the standard HTML5 markup formatter.
/// </summary>
public class HtmlMarkupFormatter : IMarkupFormatter
{
    #region Instance

    /// <summary>
    /// An instance of the HtmlMarkupFormatter.
    /// </summary>
    public static readonly IMarkupFormatter Instance = new HtmlMarkupFormatter();

    #endregion

    #region Methods

    /// <inheritdoc />
    public virtual string Comment(IComment comment) => string.Concat("<!--", comment.Data, "-->");

    /// <inheritdoc />
    public virtual string Doctype(IDocumentType doctype)
    {
        var ids = GetIds(doctype.PublicIdentifier, doctype.SystemIdentifier);
        return string.Concat("<!DOCTYPE ", doctype.Name, ids, ">");
    }

    /// <inheritdoc />
    public virtual string Processing(IProcessingInstruction processing)
    {
        var value = string.Concat(processing.Target, " ", processing.Data);
        return string.Concat("<?", value, ">");
    }

    /// <inheritdoc />
    public virtual string LiteralText(ICharacterData text) => text.Data;

    /// <inheritdoc />
    public virtual string Text(ICharacterData text)
    {
        var content = text.Data;
        return EscapeText(content);
    }

    /// <inheritdoc />
    public virtual string OpenTag(IElement element, bool selfClosing)
    {
        var temp = StringBuilderPool.Obtain();
        temp.Append(Symbols.LessThan);

        if (!string.IsNullOrEmpty(element.Prefix))
        {
            temp.Append(element.Prefix).Append(Symbols.Colon);
        }

        temp.Append(element.LocalName);

        foreach (var attribute in element.Attributes)
        {
            temp.Append(' ').Append(Attribute(attribute));
        }

        temp.Append(Symbols.GreaterThan);
        return temp.ToPool();
    }

    /// <inheritdoc />
    public virtual string CloseTag(IElement element, bool selfClosing)
    {
        var prefix = element.Prefix;
        var name = element.LocalName;
        var tag = !string.IsNullOrEmpty(prefix) ? string.Concat(prefix, ":", name) : name;
        return selfClosing ? string.Empty : string.Concat("</", tag, ">");
    }

    /// <summary>
    /// Creates the string representation of the attribute.
    /// </summary>
    /// <param name="attr">The attribute to serialize.</param>
    /// <returns>The string representation.</returns>
    protected virtual string Attribute(IAttr attr)
    {
        var temp = StringBuilderPool.Obtain();

        WriteAttributeName(attr, temp);

        if (attr.Value != null)
        {
            temp.Append(Symbols.Equality).Append(Symbols.DoubleQuote);
            WriteAttributeValue(attr, temp);
            return temp.Append(Symbols.DoubleQuote).ToPool();
        }

        return temp.ToPool();
    }

    internal static void WriteAttributeName(IAttr attr, StringBuilder stringBuilder)
    {
        var namespaceUri = attr.NamespaceUri;
        var localName = attr.LocalName;

        if (string.IsNullOrEmpty(namespaceUri))
        {
            stringBuilder.Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XmlUri))
        {
            stringBuilder.Append(NamespaceNames.XmlPrefix).Append(Symbols.Colon).Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XLinkUri))
        {
            stringBuilder.Append(NamespaceNames.XLinkPrefix).Append(Symbols.Colon).Append(localName);
        }
        else if (namespaceUri.Is(NamespaceNames.XmlNsUri))
        {
            stringBuilder.Append(XmlNamespaceLocalName(localName));
        }
        else
        {
            stringBuilder.Append(attr.Name);
        }
    }

    internal static void WriteAttributeValue(IAttr attr, StringBuilder stringBuilder)
    {
        var value = attr.Value ?? string.Empty;

        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i])
            {
                case Symbols.Ampersand: stringBuilder.Append("&amp;"); break;
                case Symbols.NoBreakSpace: stringBuilder.Append("&nbsp;"); break;
                case Symbols.DoubleQuote: stringBuilder.Append("&quot;"); break;
                default: stringBuilder.Append(value[i]); break;
            }
        }
    }

    #endregion

    #region Helpers

    /// <summary>
    /// Escapes the given text by replacing special characters with their
    /// HTML entity (amp, nobsp, lt, and gt).
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
                case Symbols.NoBreakSpace: temp.Append("&nbsp;"); break;
                case Symbols.GreaterThan: temp.Append("&gt;"); break;
                case Symbols.LessThan: temp.Append("&lt;"); break;
                default: temp.Append(content[i]); break;
            }
        }

        return temp.ToPool();
    }

    /// <summary>
    /// Gets the doctype identifiers from the given public and system identifier.
    /// </summary>
    /// <param name="publicId">The public identifier.</param>
    /// <param name="systemId">The system identifier.</param>
    /// <returns>The combined string representation.</returns>
    public static string GetIds(string publicId, string systemId)
    {
        if (string.IsNullOrEmpty(publicId) && string.IsNullOrEmpty(systemId))
        {
            return string.Empty;
        }
        else if (string.IsNullOrEmpty(systemId))
        {
            return $" PUBLIC \"{publicId}\"";
        }
        else if (string.IsNullOrEmpty(publicId))
        {
            return $" SYSTEM \"{systemId}\"";
        }

        return $" PUBLIC \"{publicId}\" \"{systemId}\"";
    }

    /// <summary>
    /// Gets the local name using the XML namespace prefix if required.
    /// </summary>
    /// <param name="name">The name to be properly represented.</param>
    /// <returns>The string representation.</returns>
    public static string XmlNamespaceLocalName(string name) => name != NamespaceNames.XmlNsPrefix ? string.Concat(NamespaceNames.XmlNsPrefix, ":", name) : name;

    #endregion
}
