using CodeBrix.MarkupParse.Dom;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML li, dd or dt tag.
/// </summary>
sealed class HtmlListItemElement : HtmlElement, IHtmlListItemElement
{
    #region ctor

    /// <summary>
    /// Creates a new item tag.
    /// </summary>
    public HtmlListItemElement(Document owner, string name = null, string prefix = null)
        : base(owner, name ?? TagNames.Li, prefix, NodeFlags.Special | NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd)
    {
    }

    #endregion

    #region Properties

    public int? Value
    {
        get => int.TryParse(this.GetOwnAttribute(AttributeNames.Value), NumberStyles.Integer, CultureInfo.InvariantCulture, out var i) ? i : new int?();
        set => this.SetOwnAttribute(AttributeNames.Value, value.HasValue ? value.Value.ToString() : null);
    }

    #endregion
}
