using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class NestedSelector : ISelector
{
    public static readonly ISelector Instance = new NestedSelector();

    private NestedSelector()
    {
    }

    public Priority Specificity => Priority.OneClass;

    public string Text => "&";

    public void Accept(ISelectorVisitor visitor) => visitor.Type(Text);

    public bool Match(IElement element, IElement scope) => element.Owner!.DocumentElement == element;
}
