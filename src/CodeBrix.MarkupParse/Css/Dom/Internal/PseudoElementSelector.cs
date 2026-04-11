using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class PseudoElementSelector : ISelector
{
    private readonly Predicate<IElement> _action;
    private readonly string _pseudoElement;

    public PseudoElementSelector(Predicate<IElement> action, string pseudoElement)
    {
        _action = action;
        _pseudoElement = pseudoElement;
    }

    public Priority Specificity => Priority.OneTag;

    public string Text => PseudoElementNames.Separator + CssUtilities.Escape(_pseudoElement);

    public void Accept(ISelectorVisitor visitor) => visitor.PseudoElement(_pseudoElement);

    public bool Match(IElement element, IElement scope) => _action.Invoke(element);
}
