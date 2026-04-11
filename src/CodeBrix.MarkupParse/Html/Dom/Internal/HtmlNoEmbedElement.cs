using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a noembed HTML element.
/// </summary>
sealed class HtmlNoEmbedElement : HtmlElement
{
    public HtmlNoEmbedElement(Document owner, string prefix = null)
        : base(owner, TagNames.NoEmbed, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }
}
