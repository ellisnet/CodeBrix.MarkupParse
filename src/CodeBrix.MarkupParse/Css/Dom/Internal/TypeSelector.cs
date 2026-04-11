using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class TypeSelector : ISelector
{
    private readonly string _type;

    public TypeSelector(string type)
    {
        _type = type;
    }

    /// <summary>
    /// Gets the raw type name value
    /// </summary>
    internal string TypeName => _type;

    public Priority Specificity => Priority.OneTag;

    public string Text => CssUtilities.Escape(_type);

    public void Accept(ISelectorVisitor visitor) => visitor.Type(_type);

    public bool Match(IElement element, IElement scope) => _type.Isi(element.LocalName);
}
