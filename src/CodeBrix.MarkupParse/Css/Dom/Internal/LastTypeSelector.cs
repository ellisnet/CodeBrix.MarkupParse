using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// The nth-last-of-type selector.
/// </summary>
sealed class LastTypeSelector : ChildSelector, ISelector
{
    public LastTypeSelector(int step, int offset, ISelector kind)
        : base(PseudoClassNames.NthLastOfType, step, offset, kind)
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
        var nodeName = element.NodeName;

        for (var i = nodes.Length - 1; i >= 0; i--)
        {
            if (nodes[i] is IElement child && child.NodeName.Is(nodeName))
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
