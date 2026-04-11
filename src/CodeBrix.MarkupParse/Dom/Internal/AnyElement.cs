using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

sealed class AnyElement : Element
{
    public AnyElement(Document owner, string localName, string prefix, string namespaceUri, NodeFlags flags = NodeFlags.None)
        : base(owner, localName, prefix, namespaceUri, flags)
    {
    }

    /// <inheritdoc />
    public override IElement ParseSubtree(string html) => this.ParseHtmlSubtree(html);
}
