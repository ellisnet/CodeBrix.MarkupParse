using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a noframes HTML element.
/// </summary>
sealed class HtmlNoFramesElement : HtmlElement
{
    public HtmlNoFramesElement(Document owner, string prefix = null)
        : base(owner, TagNames.NoFrames, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }
}
