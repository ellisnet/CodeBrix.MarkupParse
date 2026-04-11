using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class MarkdownDocument : Document
{
    public MarkdownDocument(IBrowsingContext context, TextSource source)
        : base(context, source)
    {
    }

    public override IElement DocumentElement => null;

    public override IEntityProvider Entities => HtmlEntityProvider.Resolver;

    public override Element CreateElementFrom(string name, string prefix, NodeFlags flags) => new AnyElement(this, name, prefix, null, flags);

    public override Node Clone(Document owner, bool deep)
    {
        var document = new MarkdownDocument(Context, Source);
        CloneDocument(document, deep);
        return document;
    }

    protected override void SetTitle(string value)
    {
    }
}
