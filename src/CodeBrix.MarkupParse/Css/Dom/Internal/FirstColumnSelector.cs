using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// The nth-column selector.
/// </summary>
sealed class FirstColumnSelector : ChildSelector, ISelector
{
    public FirstColumnSelector(int step, int offset, ISelector kind)
        : base(PseudoClassNames.NthColumn, step, offset, kind)
    {
    }

    public bool Match(IElement element, IElement scope)
    {
        var parent = element.ParentElement;

        if (parent != null)
        {
            // remove interface dispatch overhead
            if (parent.ChildNodes is NodeList nodeList)
            {
                return DoMatch(new ConcreteNodeListAccessor(nodeList), element);
            }

            return DoMatch(new InterfaceNodeListAccessor(parent.ChildNodes), element);
        }

        return false;
    }

    private bool DoMatch<T>(T nodes, IElement element) where T : INodeListAccessor
    {
        var step = Step;
        var n = Math.Sign(step);
        var k = 0;
        var offset = Offset;
        var length = nodes.Length;

        for (var i = 0; i < length; i++)
        {
            if (nodes[i] is IHtmlTableCellElement child)
            {
                var span = child.ColumnSpan;
                k += span;

                if (child == element)
                {
                    var diff = k - offset;

                    for (var index = 0; index < span; index++, diff--)
                    {
                        if (diff == 0 || (Math.Sign(diff) == n && diff % step == 0))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        return false;
    }
}
