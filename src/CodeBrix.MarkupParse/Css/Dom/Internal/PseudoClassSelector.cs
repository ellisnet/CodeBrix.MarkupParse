using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class PseudoClassSelector : ISelector
{
    private readonly Predicate<IElement> _action;
    private readonly string _pseudoClass;

    public PseudoClassSelector(Predicate<IElement> action, string pseudoClass)
    {
        _action = action;
        _pseudoClass = pseudoClass;
        Specificity = Priority.OneClass;
    }

    public PseudoClassSelector(Predicate<IElement> action, string pseudoClass, Priority specificity)
    {
        _action = action;
        _pseudoClass = pseudoClass;
        Specificity = specificity;
    }

    public Priority Specificity { get; }

    public string Text => PseudoClassNames.Separator + _pseudoClass;

    public void Accept(ISelectorVisitor visitor) => visitor.PseudoClass(_pseudoClass);

    public bool Match(IElement element, IElement scope) => _action.Invoke(element);
}
