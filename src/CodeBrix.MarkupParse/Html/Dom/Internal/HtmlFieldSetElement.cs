using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML fieldset element.
/// </summary>
sealed class HtmlFieldSetElement : HtmlFormControlElement, IHtmlFieldSetElement
{
    #region Fields

    private HtmlFormControlsCollection _elements;

    #endregion

    #region ctor

    public HtmlFieldSetElement(Document owner, string prefix = null)
        : base(owner, TagNames.Fieldset, prefix)
    {
    }

    #endregion

    #region Properties

    public string Type => TagNames.Fieldset;

    public IHtmlFormControlsCollection Elements => _elements ??= new HtmlFormControlsCollection(Form!, this);

    #endregion

    #region Methods

    protected override bool IsFieldsetDisabled()
    {
        return false;
    }

    protected override bool CanBeValidated()
    {
        return true;
    }

    #endregion
}
