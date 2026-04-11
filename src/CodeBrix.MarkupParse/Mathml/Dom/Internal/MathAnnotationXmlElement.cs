using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// The annotation-xml math element.
/// </summary>
sealed class MathAnnotationXmlElement : MathElement
{
    public MathAnnotationXmlElement(Document owner, string prefix = null)
        : base(owner, TagNames.AnnotationXml, prefix, NodeFlags.Special | NodeFlags.Scoped)
	    {
	    }
}
