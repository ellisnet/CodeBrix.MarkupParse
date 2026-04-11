using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML element with only semantic meaning.
/// </summary>
sealed class HtmlSemanticElement : HtmlElement
{
    public HtmlSemanticElement(Document owner, string name, string prefix = null)
        : base(owner, name, prefix, NodeFlags.Special)
    {
    }
}
