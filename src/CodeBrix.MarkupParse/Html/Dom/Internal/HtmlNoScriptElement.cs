using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a noscript HTML element.
/// </summary>
sealed class HtmlNoScriptElement : HtmlElement
{
    public HtmlNoScriptElement(Document owner, string prefix = null, bool? scripting = false)
        : base(owner, TagNames.NoScript, prefix, GetFlags(scripting ?? owner.Context.IsScripting()))
    {
    }

    private static NodeFlags GetFlags(bool scripting)
    {
        if (scripting)
        {
            return NodeFlags.Special | NodeFlags.LiteralText;
        }

        return NodeFlags.Special;
    }
}
