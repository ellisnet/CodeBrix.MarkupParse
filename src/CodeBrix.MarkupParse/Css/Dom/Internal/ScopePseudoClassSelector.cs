using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class ScopePseudoClassSelector : ISelector
{
    public static readonly ISelector Instance = new ScopePseudoClassSelector();

    private ScopePseudoClassSelector()
    {
    }

    public Priority Specificity => Priority.OneClass;

    public string Text => PseudoClassNames.Separator + PseudoClassNames.Scope;

    public void Accept(ISelectorVisitor visitor) => visitor.PseudoClass(PseudoClassNames.Scope);

    public bool Match(IElement element, IElement scope)
    {
        var realScope = scope ?? element.Owner!.DocumentElement;
        return object.ReferenceEquals(element, realScope);
    }
}
