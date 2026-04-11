using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// Represents a compound selector, which is a chain of simple selectors
/// that are not separated by a combinator.
/// </summary>
sealed class CompoundSelector : Selectors, ISelector
{
    public bool Match(IElement element, IElement scope)
    {
        for (var i = 0; i < _selectors.Count; i++)
        {
            if (!_selectors[i].Match(element, scope))
            {
                return false;
            }
        }

        return true;
    }

    public void Accept(ISelectorVisitor visitor)
    {
        visitor.Many(_selectors);
    }

    protected override string Stringify()
    {
        var parts = new string[_selectors.Count];

        for (var i = 0; i < _selectors.Count; i++)
        {
            parts[i] = _selectors[i].Text;
        }

        return string.Concat(parts);
    }

    protected override Priority ComputeSpecificity()
    {
        var sum = new Priority();

        for (var i = 0; i < _selectors.Count; i++)
        {
            sum += _selectors[i].Specificity;
        }

        return sum;
    }
}
