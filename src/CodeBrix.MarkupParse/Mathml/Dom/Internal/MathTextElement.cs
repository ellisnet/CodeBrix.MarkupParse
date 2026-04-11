using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The mtext math element.
/// </summary>
sealed class MathTextElement : MathElement
{
    public MathTextElement(Document owner, string prefix = null)
        : base(owner, TagNames.Mtext, prefix, NodeFlags.MathTip | NodeFlags.Special | NodeFlags.Scoped)
	    {
	    }
}
