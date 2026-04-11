using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class NamespaceSelector : ISelector
{
    private readonly string _prefix;

    /// <summary>
    /// </summary>
    /// <param name="prefix">The escaped prefix text</param>
    public NamespaceSelector(string prefix)
    {
        _prefix = prefix;
    }

    public Priority Specificity => Priority.Zero;

    public string Text => CssUtilities.Escape(_prefix);

    public bool Match(IElement element, IElement scope) => element.MatchesCssNamespace(_prefix);

    public void Accept(ISelectorVisitor visitor) => visitor.Type(_prefix);
}
