using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class AttrAvailableSelector : BaseAttrSelector, ISelector
{
    public AttrAvailableSelector(string name, string prefix)
        : base(name, prefix)
    {
    }

    public string Text => string.Concat("[", Attribute, "]");

    public void Accept(ISelectorVisitor visitor) => visitor.Attribute(Attribute, string.Empty, null);

    public bool Match(IElement element, IElement scope) => element.HasAttribute(Name);
}
