using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The math string element.
/// </summary>
sealed class MathStringElement : MathElement
{
    public MathStringElement(Document owner, string prefix = null)
        : base(owner, TagNames.Ms, prefix, NodeFlags.MathTip | NodeFlags.Special | NodeFlags.Scoped)
	    {
	    }
}
