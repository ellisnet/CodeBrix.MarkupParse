using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class IdSelector : ISelector
{
    private readonly string _id;

    public IdSelector(string id)
    {
        _id = id;
    }

    public Priority Specificity => Priority.OneId;

    public string Text => "#" + CssUtilities.Escape(_id);

    public void Accept(ISelectorVisitor visitor) => visitor.Id(_id);

    public bool Match(IElement element, IElement scope) => element.Id.Is(_id);
}
