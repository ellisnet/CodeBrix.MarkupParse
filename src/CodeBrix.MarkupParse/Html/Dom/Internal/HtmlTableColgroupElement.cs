using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML column group element.
/// </summary>
sealed class HtmlTableColgroupElement : HtmlElement, IHtmlTableColumnElement
{
    #region ctor

    public HtmlTableColgroupElement(Document owner, string prefix = null)
        : base(owner, TagNames.Colgroup, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the value of the horizontal alignment attribute.
    /// </summary>
    public HorizontalAlignment Align
    {
        get => this.GetOwnAttribute(AttributeNames.Align).ToEnum(HorizontalAlignment.Center);
        set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    /// <summary>
    /// Gets or sets the number of columns in a group or affected by a grouping.
    /// </summary>
    public int Span
    {
        get => this.GetOwnAttribute(AttributeNames.Span).ToInteger(0);
        set => this.SetOwnAttribute(AttributeNames.Span, value.ToString());
    }

    /// <summary>
    /// Gets or sets the value of the vertical alignment attribute.
    /// </summary>
    public VerticalAlignment VAlign
    {
        get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum(VerticalAlignment.Middle);
        set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    /// <summary>
    /// Gets or sets the value of the width attribute.
    /// </summary>
    public string Width
    {
        get => this.GetOwnAttribute(AttributeNames.Width);
        set => this.SetOwnAttribute(AttributeNames.Width, value);
    }

    #endregion
}
