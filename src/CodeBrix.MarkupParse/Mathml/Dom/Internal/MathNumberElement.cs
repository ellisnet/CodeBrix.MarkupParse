using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The mn math element.
/// </summary>
sealed class MathNumberElement : MathElement
{
    public MathNumberElement(Document owner, string prefix = null)
        : base(owner, TagNames.Mn, prefix, NodeFlags.MathTip | NodeFlags.Special | NodeFlags.Scoped)
	    {
	    }
}
