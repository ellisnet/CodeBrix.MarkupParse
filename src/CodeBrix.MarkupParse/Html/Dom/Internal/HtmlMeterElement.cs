using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML meter element.
/// https://html.spec.whatwg.org/multipage/forms.html#dom-meter-low
/// </summary>
sealed class HtmlMeterElement : HtmlElement, IHtmlMeterElement
{
    #region Fields

    private readonly NodeList _labels;

    #endregion

    #region ctor

    public HtmlMeterElement(Document owner, string prefix = null)
        : base(owner, TagNames.Meter, prefix)
    {
        _labels = [];
    }

    #endregion

    #region Properties

    public INodeList Labels => _labels;

    public double Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value).ToDouble(0.0).Constraint(Minimum, Maximum);
        set => this.SetOwnAttribute(AttributeNames.Value, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Maximum
    {
        get => this.GetOwnAttribute(AttributeNames.Max).ToDouble(1.0).Constraint(Minimum, double.PositiveInfinity);
        set => this.SetOwnAttribute(AttributeNames.Max, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Minimum
    {
        get => this.GetOwnAttribute(AttributeNames.Min).ToDouble(0.0);
        set => this.SetOwnAttribute(AttributeNames.Min, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Low
    {
        get => this.GetOwnAttribute(AttributeNames.Low).ToDouble(Minimum).Constraint(Minimum, Maximum);
        set => this.SetOwnAttribute(AttributeNames.Low, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double High
    {
        get => this.GetOwnAttribute(AttributeNames.High).ToDouble(Maximum).Constraint(Low, Maximum);
        set => this.SetOwnAttribute(AttributeNames.High, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    public double Optimum
    {
        get => this.GetOwnAttribute(AttributeNames.Optimum).ToDouble((Maximum + Minimum) * 0.5).Constraint(Minimum, Maximum);
        set => this.SetOwnAttribute(AttributeNames.Optimum, value.ToString(NumberFormatInfo.InvariantInfo));
    }

    #endregion
}
