using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Construction;
using System;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents an element of the SVG DOM.
/// </summary>
public class SvgElement : Element, ISvgElement, IConstructableSvgElement
{
    #region ctor

    /// <inheritdoc />
    public SvgElement(Document owner, string name, string prefix = null, NodeFlags flags = NodeFlags.None)
        : base(owner, name, prefix, NamespaceNames.SvgUri, flags | NodeFlags.SvgMember)
    {
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override IElement ParseSubtree(string html) => this.ParseHtmlSubtree(html);

    /// <inheritdoc />
    public override Node Clone(Document owner, bool deep)
    {
        var factory = Context.GetFactory<IElementFactory<Document, SvgElement>>();
        var node = factory.Create(owner, LocalName, Prefix);
        CloneElement(node, owner, deep);
        return node;
    }

    #endregion
}
