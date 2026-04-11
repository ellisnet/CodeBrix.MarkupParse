using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// The nth-of-type selector.
/// </summary>
sealed class FirstTypeSelector : ChildSelector, ISelector
{
    public FirstTypeSelector(int step, int offset, ISelector kind)
        : base(PseudoClassNames.NthOfType, step, offset, kind)
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
        var k = 0;
        var step = Step;
        var n = Math.Sign(step);
        var offset = Offset;
        var length = nodes.Length;
        var nodeName = element.NodeName;

        for (var i = 0; i < length; i++)
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
