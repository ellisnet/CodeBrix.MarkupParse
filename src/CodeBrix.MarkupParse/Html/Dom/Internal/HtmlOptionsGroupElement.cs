using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML optgroup element.
/// </summary>
sealed class HtmlOptionsGroupElement : HtmlElement, IHtmlOptionsGroupElement
{
    #region ctor

    public HtmlOptionsGroupElement(Document owner, string prefix = null)
        : base(owner, TagNames.Optgroup, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd | NodeFlags.HtmlSelectScoped)
    {
    }

    #endregion

    #region Properties

    public string Label
    {
        get => this.GetOwnAttribute(AttributeNames.Label);
        set => this.SetOwnAttribute(AttributeNames.Label, value);
    }
    public bool IsDisabled
    {
        get => this.GetBoolAttribute(AttributeNames.Disabled);
        set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    #endregion
}
