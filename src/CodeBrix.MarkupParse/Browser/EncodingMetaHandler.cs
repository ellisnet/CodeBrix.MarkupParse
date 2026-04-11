using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Text;
using System;
using System.Text;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Implementation of an encoding meta handler.
/// </summary>
public class EncodingMetaHandler : IMetaHandler
{
    /// <summary>
    /// Create a new instance of the EncodingMetaHandler
    /// </summary>
    /// <remarks>This will initialize additional encoding providers to correctly support all encodings</remarks>
    public EncodingMetaHandler()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    void IMetaHandler.HandleContent(IHtmlMetaElement element)
    {
        var encoding = this.GetEncoding(element);

        if (encoding != null)
        {
            var document = element.Owner!;
            document.Source.CurrentEncoding = encoding;
        }
    }

    /// <summary>
    /// Gets the associated encoding, if any.
    /// </summary>
    /// <param name="element">The element to get the encoding from.</param>
    /// <returns>The discovered encoding or null.</returns>
    protected virtual Encoding GetEncoding(IHtmlMetaElement element)
    {
        var charset = element.Charset;

        if (charset != null)
        {
            charset = charset.Trim();

            if (TextEncoding.IsSupported(charset))
            {
                return TextEncoding.Resolve(charset);
            }
        }

        var shouldParseContent = element.HttpEquivalent.Isi(HeaderNames.ContentType);
        return shouldParseContent ? TextEncoding.Parse(element.Content ?? string.Empty) : null;
    }
}
