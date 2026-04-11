using CodeBrix.MarkupParse.Text;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a document fragment.
/// </summary>
sealed class DocumentFragment : Node, IDocumentFragment
{
    #region Fields

    private HtmlCollection<IElement> _elements;

    #endregion

    #region ctor

    internal DocumentFragment(Document owner)
        : base(owner, "#document-fragment", NodeType.DocumentFragment)
    {
    }

    internal DocumentFragment(Element contextElement, string html)
        : this(contextElement.Owner)
    {
        var root = contextElement.ParseSubtree(html);

        while (root.HasChildNodes)
        {
            var child = root.FirstChild;
            root.RemoveChild(child);

            if (child is Node childNode)
            {
                Owner.AdoptNode(child);
                InsertBefore(childNode, null, false);
            }
        }
    }

    #endregion

    #region Properties

    public int ChildElementCount => ChildNodes.OfType<Element>().Count();

    public IHtmlCollection<IElement> Children => _elements ??= new HtmlCollection<IElement>(this, deep: false);

    public IElement FirstElementChild
    {
        get
        {
            var children = ChildNodes;
            var n = children.Length;

            for (var i = 0; i < n; i++)
            {
                if (children[i] is IElement child)
                {
                    return child;
                }
            }

            return null;
        }
    }

    public IElement LastElementChild
    {
        get
        {
            var children = ChildNodes;

            for (var i = children.Length - 1; i >= 0; i--)
            {
                if (children[i] is IElement child)
                {
                    return child;
                }
            }

            return null;
        }
    }

    public override string TextContent
    {
        get
        {
            var sb = StringBuilderPool.Obtain();

            foreach (var child in this.GetDescendants().OfType<IText>())
            {
                sb.Append(child.Data);
            }

            return sb.ToPool();
        }
        set
        {
            var node = !string.IsNullOrEmpty(value) ? new TextNode(Owner, value) : null;
            ReplaceAll(node, false);
        }
    }

    #endregion

    #region Methods

    public void Prepend(params INode[] nodes) => this.PrependNodes(nodes);

    public void Append(params INode[] nodes) => this.AppendNodes(nodes);

    public IElement QuerySelector(string selectors) => ChildNodes.QuerySelector(selectors, null);

    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => ChildNodes.QuerySelectorAll(selectors, null);

    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => ChildNodes.GetElementsByClassName(classNames);

    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => ChildNodes.GetElementsByTagName(tagName);

    public IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceURI, string tagName) => ChildNodes.GetElementsByTagName(namespaceURI, tagName);

    public IElement GetElementById(string elementId) => ChildNodes.GetElementById(elementId);

    public override Node Clone(Document owner, bool deep)
    {
        var node = new DocumentFragment(owner);
        CloneNode(node, owner, deep);
        return node;
    }

    #endregion
}
