using CodeBrix.MarkupParse.Dom;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// Represents a group of selectors, i.e., zero or more selectors separated
/// by commas.
/// </summary>
sealed class ListSelector : Selectors, ISelector, IMultiSelector
{
    public void Accept(ISelectorVisitor visitor)
    {
        visitor.List(_selectors);
    }

    public bool Match(IElement element, IElement scope)
    {
        for (var i = 0; i < _selectors.Count; i++)
        {
            if (_selectors[i].Match(element, scope))
            {
                return true;
            }
        }

        return false;
    }

    public ISelector GetMatchingSelector(IElement element, IElement scope = null)
    {
        foreach (var selector in _selectors.OrderByDescending(m => m.Specificity))
        {
            if (selector.Match(element, scope))
            {
                return selector;
            }
        }

        return null;
    }

    protected override string Stringify()
    {
        var parts = new string[_selectors.Count];

        for (var i = 0; i < _selectors.Count; i++)
        {
            parts[i] = _selectors[i].Text;
        }

        return string.Join(", ", parts);
    }

    protected override Priority ComputeSpecificity()
    {
        var max = Priority.Zero;

        for (var i = 0; i < _selectors.Count; i++)
        {
            var value = _selectors[i].Specificity;

            if (value > max)
            {
                max = value;
            }
        }

        return max;
    }
}
