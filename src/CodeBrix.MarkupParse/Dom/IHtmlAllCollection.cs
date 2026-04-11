using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// An HTMLAllCollection is always rooted at document and matching all
/// elements. It represents the tree of elements in a one-dimensional
/// fashion.
/// </summary>
[DomName("HTMLAllCollection")]
public interface IHtmlAllCollection : IHtmlCollection<IElement>
{
}
