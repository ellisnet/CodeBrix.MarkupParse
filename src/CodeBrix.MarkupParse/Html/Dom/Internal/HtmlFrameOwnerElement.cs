using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base class for frame owned elements.
/// </summary>
abstract class HtmlFrameOwnerElement : HtmlElement
{
    #region ctor

    public HtmlFrameOwnerElement(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
        : base(owner, name, prefix, flags)
    {
    }

    #endregion

    #region Properties

    public bool CanContainRangeEndpoint
    {
        get;
        private set;
    }

    public int DisplayWidth
    {
        get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(0);
        set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
        get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(0);
        set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int MarginWidth
    {
        get => this.GetOwnAttribute(AttributeNames.MarginWidth).ToInteger(0);
        set => this.SetOwnAttribute(AttributeNames.MarginWidth, value.ToString());
    }

    public int MarginHeight
    {
        get => this.GetOwnAttribute(AttributeNames.MarginHeight).ToInteger(0);
        set => this.SetOwnAttribute(AttributeNames.MarginHeight, value.ToString());
    }

    #endregion
}
