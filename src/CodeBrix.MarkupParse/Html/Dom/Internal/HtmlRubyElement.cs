using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The ruby HTML element.
/// </summary>
sealed class HtmlRubyElement : HtmlElement
{
    public HtmlRubyElement(Document owner, string prefix = null)
        : base(owner, TagNames.Ruby, prefix)
    {
    }
}
