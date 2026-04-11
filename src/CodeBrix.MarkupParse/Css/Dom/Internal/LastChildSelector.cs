using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// The nth-lastchild selector.
/// </summary>
sealed class LastChildSelector : ChildSelector, ISelector
{
    public LastChildSelector(int step, int offset, ISelector kind)
        : base(PseudoClassNames.NthLastChild, step, offset, kind)
    {
    }

    protected override bool IncludeParameterInSpecificity => true;

    public bool Match(IElement element, IElement scope)
    {
        var parent = element.ParentElement;

        if (parent != null)
        {
            // remove interface dispatch overhead
            if (parent.ChildNodes is NodeList nodeList)
            {
                return DoMatch(new ConcreteNodeListAccessor(nodeList), element, scope);
            }

            return DoMatch(new InterfaceNodeListAccessor(parent.ChildNodes), element, scope);
        }

        return false;
    }

    private bool DoMatch<T>(T nodes, IElement element, IElement scope) where T : INodeListAccessor
    {
        var step = Step;
        var n = Math.Sign(step);
        var k = 0;
        var kind = Kind;
        var matchAll = ReferenceEquals(Kind, AllSelector.Instance);
        var offset = Offset;

        for (var i = nodes.Length - 1; i >= 0; i--)
        {
            if (nodes[i] is IElement child && (matchAll || kind.Match(child, scope)))
            {
                k += 1;

                if (child == element)
                {
                    var diff = k - offset;
                    return diff == 0 || (Math.Sign(diff) == n && diff % step == 0);
                }
            }
        }

        return false;
    }
}
