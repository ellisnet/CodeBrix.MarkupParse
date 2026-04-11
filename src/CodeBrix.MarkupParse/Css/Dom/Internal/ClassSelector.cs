using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class ClassSelector : ISelector
{
    private readonly string _cls;

    public ClassSelector(string cls)
    {
        _cls = cls;
    }

    public Priority Specificity => Priority.OneClass;

    public string Text => "." + CssUtilities.Escape(_cls);

    public void Accept(ISelectorVisitor visitor) => visitor.Class(_cls);

    public bool Match(IElement element, IElement scope) => element.ClassList.Contains(_cls);
}
