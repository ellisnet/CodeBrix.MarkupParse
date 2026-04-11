using CodeBrix.MarkupParse.Html.Dom;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class TimeInputType : BaseInputType
{
    #region ctor

    public TimeInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var value = Input.Value;
        var date = ConvertFromTime(value);
        var min = ConvertFromTime(Input.Minimum);
        var max = ConvertFromTime(Input.Maximum);
        return CheckTime(current, value, date, min, max);
    }

    public override double? ConvertToNumber(string value)
    {
        var dt = ConvertFromTime(value);

        if (dt.HasValue)
        {
            return dt.Value.Subtract(new DateTime()).TotalMilliseconds;
        }

        return null;
    }

    public override string ConvertFromNumber(double value)
    {
        var dt = new DateTime().AddMilliseconds(value);
        return ConvertFromDate(dt);
    }

    public override DateTime? ConvertToDate(string value)
    {
        var time = ConvertFromTime(value);

        if (time != null)
        {
            return UnixEpoch.Add(time.Value.Subtract(new DateTime()));
        }

        return null;
    }

    public override string ConvertFromDate(DateTime value)
    {
        return string.Format(CultureInfo.InvariantCulture, "{0:00}:{1:00}:{2:00},{3:000}", value.Hour, value.Minute, value.Second, value.Millisecond);
    }

    public override void DoStep(int n)
    {
        var dt = ConvertFromTime(Input.Value);

        if (dt.HasValue)
        {
            var date = dt.Value.AddMilliseconds(GetStep() * n);
            var min = ConvertFromTime(Input.Minimum);
            var max = ConvertFromTime(Input.Maximum);

            if ((!min.HasValue || min.Value <= date) && (!max.HasValue || max.Value >= date))
            {
                Input.ValueAsDate = date;
            }
        }
    }

    #endregion

    #region Step

    protected override double GetDefaultStepBase()
    {
        return 0.0;
    }

    protected override double GetDefaultStep()
    {
        return 60.0;
    }

    protected override double GetStepScaleFactor()
    {
        return 1000.0;
    }

    #endregion

    #region Helper

    protected static DateTime? ConvertFromTime(string value)
    {
        if (value is {Length: > 0 })
        {
            var position = 0;
            var ts = ToTime(value, ref position);

            if (ts != null && position == value.Length)
            {
                return new DateTime(0, DateTimeKind.Utc).Add(ts.Value);
            }
        }

        return null;
    }

    #endregion
}
