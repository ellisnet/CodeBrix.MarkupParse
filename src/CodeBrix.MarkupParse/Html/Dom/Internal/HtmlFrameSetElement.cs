using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML frameset element.
/// Obsolete since HTML 4.01.
/// </summary>
[DomHistorical]
sealed class HtmlFrameSetElement : HtmlElement
{
    #region ctor

    public HtmlFrameSetElement(Document owner, string prefix = null)
        : base(owner, TagNames.Frameset, prefix, NodeFlags.Special)
    {
    }

    #endregion

    #region Properties

    public int Columns
    {
        get => this.GetOwnAttribute(AttributeNames.Cols).ToInteger(1);
        set => this.SetOwnAttribute(AttributeNames.Cols, value.ToString());
    }

    public int Rows
    {
        get => this.GetOwnAttribute(AttributeNames.Rows).ToInteger(1);
        set => this.SetOwnAttribute(AttributeNames.Rows, value.ToString());
    }

    #endregion
}
