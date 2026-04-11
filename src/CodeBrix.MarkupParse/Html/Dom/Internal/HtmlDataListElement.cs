using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML datalist element.
/// </summary>
sealed class HtmlDataListElement : HtmlElement, IHtmlDataListElement
{
    #region Fields

    private HtmlCollection<IHtmlOptionElement> _options;

    #endregion

    #region ctor

    public HtmlDataListElement(Document owner, string prefix = null)
        : base(owner, TagNames.Datalist, prefix)
    {
    }

    #endregion

    #region Properties

    public IHtmlCollection<IHtmlOptionElement> Options => _options ??= new HtmlCollection<IHtmlOptionElement>(this);

    #endregion
}
