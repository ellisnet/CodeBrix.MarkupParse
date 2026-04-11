using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The DocumentFragment interface represents a minimal document object
/// that has no parent.
/// </summary>
[DomName("DocumentFragment")]
public interface IDocumentFragment : INode, IParentNode, INonElementParentNode
{
}
