using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Construction;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML frame element.
/// </summary>
sealed class HtmlFrameElement : HtmlFrameElementBase, IConstructableFrameElement
{
    #region ctor

    public HtmlFrameElement(Document owner, string prefix = null)
        : base(owner, TagNames.Frame, prefix, NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public bool NoResize
    {
        get => this.GetOwnAttribute(AttributeNames.NoResize).ToBoolean(false);
        set => this.SetOwnAttribute(AttributeNames.NoResize, value.ToString());
    }

    #endregion
}
