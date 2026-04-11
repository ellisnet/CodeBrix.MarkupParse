using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML picture element.
/// </summary>
sealed class HtmlPictureElement : HtmlElement, IHtmlPictureElement
{
    public HtmlPictureElement(Document owner, string prefix = null)
        : base(owner, TagNames.Picture, prefix)
    {
    }
}
