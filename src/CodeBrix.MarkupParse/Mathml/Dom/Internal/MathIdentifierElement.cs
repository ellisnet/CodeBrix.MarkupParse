using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The mi math element.
/// </summary>
sealed class MathIdentifierElement : MathElement
{
    public MathIdentifierElement(Document owner, string prefix = null)
        : base(owner, TagNames.Mi, prefix, NodeFlags.Special | NodeFlags.MathTip | NodeFlags.Scoped)
	    {
	    }
}
