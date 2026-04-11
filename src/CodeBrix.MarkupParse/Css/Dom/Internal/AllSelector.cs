using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class AllSelector : ISelector
{
    public static readonly ISelector Instance = new AllSelector();

    private AllSelector()
    {
    }

    public Priority Specificity => Priority.Zero;

    public string Text => "*";

    public void Accept(ISelectorVisitor visitor) => visitor.Type(Text);

    public bool Match(IElement element, IElement scope) => true;
}
