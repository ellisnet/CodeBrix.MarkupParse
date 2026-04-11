using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML modifier (ins / del) element.
/// </summary>
sealed class HtmlModElement : HtmlElement, IHtmlModElement
{
    #region ctor

    public HtmlModElement(Document owner, string name = null, string prefix = null)
        : base(owner, name ?? TagNames.Ins, prefix)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the value that contains a URI of a resource
    /// explaining the change.
    /// </summary>
    public string Citation
    {
        get => this.GetOwnAttribute(AttributeNames.Cite);
        set => this.SetOwnAttribute(AttributeNames.Cite, value);
    }

    /// <summary>
    /// Gets or sets the value that contains date-and-time string
    /// representing a timestamp for the change.
    /// </summary>
    public string DateTime
    {
        get => this.GetOwnAttribute(AttributeNames.Datetime);
        set => this.SetOwnAttribute(AttributeNames.Datetime, value);
    }

    #endregion
}
