using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class DateInputType : BaseInputType
{
    #region ctor

    public DateInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var value = Input.Value;
        var date = ConvertFromDate(value);
        var min = ConvertFromDate(Input.Minimum);
        var max = ConvertFromDate(Input.Maximum);
        return CheckTime(current, value, date, min, max);
    }

    public override double? ConvertToNumber(string value)
    {
        var dt = ConvertFromDate(value);

        if (dt.HasValue)
        {
            return dt.Value.Subtract(UnixEpoch).TotalMilliseconds;
        }

        return null;
    }

    public override string ConvertFromNumber(double value)
    {
        var dt = UnixEpoch.AddMilliseconds(value);
        return ConvertFromDate(dt);
    }

    public override DateTime? ConvertToDate(string value)
    {
        return ConvertFromDate(value);
    }

    public override string ConvertFromDate(DateTime value)
    {
        return string.Format(CultureInfo.InvariantCulture, "{0:0000}-{1:00}-{2:00}", value.Year, value.Month, value.Day);
    }

    public override void DoStep(int n)
    {
        var dt = ConvertFromDate(Input.Value);

        if (dt.HasValue)
        {
            var date = dt.Value.AddMilliseconds(GetStep() * n);
            var min = ConvertFromDate(Input.Minimum);
            var max = ConvertFromDate(Input.Maximum);

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
        return 1.0;
    }

    protected override double GetStepScaleFactor()
    {
        return 86400000.0;
    }

    #endregion

    #region Helper

    protected static DateTime? ConvertFromDate(string value)
    {
        if (value is { Length: > 0 })
        {
            var position = FetchDigits(value);

            if (IsLegalPosition(value, position))
            {
                var yearString = value.Substring(0, position);
                var year = int.Parse(yearString, CultureInfo.InvariantCulture);
                var monthString = value.Substring(position + 1, 2);
                var month = int.Parse(monthString, CultureInfo.InvariantCulture);
                var dayString = value.Substring(position + 4, 2);
                var day = int.Parse(dayString, CultureInfo.InvariantCulture);

                if (IsLegalDay(day, month, year))
                {
                    return new DateTime(year, month, day, 0, 0, 0, 0, DateTimeKind.Utc);
                }
            }
        }

        return null;
    }

    private static bool IsLegalPosition(string value, int position)
    {
        return position >= 4 && position == value.Length - 6 &&
                value[position + 0] == Symbols.Minus &&
                value[position + 1].IsDigit() &&
                value[position + 2].IsDigit() &&
                value[position + 3] == Symbols.Minus &&
                value[position + 4].IsDigit() &&
                value[position + 5].IsDigit();
    }

    #endregion
}
