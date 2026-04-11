using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Construction;
using System;

namespace CodeBrix.MarkupParse.Mathml.Dom; //Was previously: namespace AngleSharp.Mathml.Dom

/// <summary>
/// Represents an element of the MathML DOM.
/// </summary>
public class MathElement : Element, IConstructableMathElement
{
    #region ctor

    /// <inheritdoc />
    public MathElement(Document owner, string name, string prefix = null, NodeFlags flags = NodeFlags.None)
        : base(owner, name, prefix, NamespaceNames.MathMlUri, flags | NodeFlags.MathMember)
    {
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override IElement ParseSubtree(string html) => this.ParseHtmlSubtree(html);

    /// <inheritdoc />
    public override Node Clone(Document owner, bool deep)
    {
        var factory = Context.GetFactory<IElementFactory<Document, MathElement>>();
        var node = factory.Create(owner, LocalName, Prefix);
        CloneElement(node, owner, deep);
        return node;
    }

    #endregion
}
