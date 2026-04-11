using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The mo math element.
/// </summary>
sealed class MathOperatorElement : MathElement
{
    public MathOperatorElement(Document owner, string prefix = null)
        : base(owner, TagNames.Mo, prefix, NodeFlags.Special | NodeFlags.MathTip | NodeFlags.Scoped)
	    {
	    }
}
