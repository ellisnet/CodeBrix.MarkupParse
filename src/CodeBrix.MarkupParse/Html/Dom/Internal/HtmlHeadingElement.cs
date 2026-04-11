using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the an HTML heading element (h1, h2, h3, h4, h5, h6).
/// </summary>
sealed class HtmlHeadingElement : HtmlElement, IHtmlHeadingElement
{
    public HtmlHeadingElement(Document owner, string name = null, string prefix = null)
        : base(owner, name ?? TagNames.H1, prefix, NodeFlags.Special)
    {
    }
}
