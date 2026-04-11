using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The plaintext HTML element.
/// </summary>
sealed class HtmlPlaintextElement : HtmlElement
{
    public HtmlPlaintextElement(Document owner, string prefix)
        : base(owner, TagNames.Plaintext, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }
}
