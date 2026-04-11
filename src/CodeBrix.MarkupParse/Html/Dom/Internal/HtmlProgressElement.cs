using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML progress element.
/// https://html.spec.whatwg.org/multipage/forms.html#the-progress-element
/// </summary>
sealed class HtmlProgressElement : HtmlElement, IHtmlProgressElement
{
    #region Fields

    private readonly NodeList _labels;

    #endregion

    #region ctor

    public HtmlProgressElement(Document owner, string prefix = null)
        : base(owner, TagNames.Progress, prefix)
    {
        _labels = [];
    }

    #endregion

    #region Properties

    public INodeList Labels => _labels;

    public bool IsDeterminate => !string.IsNullOrEmpty(this.GetOwnAttribute(AttributeNames.Value));

    public double Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value).ToDouble(0.0);
        set => this.SetOwnAttribute(AttributeNames.Value, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Maximum
    {
        get => this.GetOwnAttribute(AttributeNames.Max).ToDouble(1.0);
        set => this.SetOwnAttribute(AttributeNames.Max, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Position => IsDeterminate ? Math.Max(Math.Min(Value / Maximum, 1.0), 0.0) : -1.0;

    #endregion
}
