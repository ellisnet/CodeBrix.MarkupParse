using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML legend element.
/// </summary>
sealed class HtmlLegendElement : HtmlElement, IHtmlLegendElement
{
    #region ctor

    public HtmlLegendElement(Document owner, string prefix = null)
        : base(owner, TagNames.Legend, prefix)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the associated form.
    /// </summary>
    public IHtmlFormElement Form
    {
        get 
        {
            var fieldset = Parent as HtmlFieldSetElement;
            return fieldset?.Form;
        }
    }

    #endregion
}
