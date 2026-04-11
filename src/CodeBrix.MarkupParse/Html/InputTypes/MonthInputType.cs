using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class MonthInputType : BaseInputType
{
    #region ctor

    public MonthInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var value = Input.Value;
        var date = ConvertFromMonth(value);
        var min = ConvertFromMonth(Input.Minimum);
        var max = ConvertFromMonth(Input.Maximum);
        return CheckTime(current, value, date, min, max);
    }

    public override double? ConvertToNumber(string value)
    {
        var dt = ConvertFromMonth(value);

        if (dt.HasValue)
        {
            return (dt.Value.Year - 1970) * 12 + dt.Value.Month - 1;
        }

        return null;
    }

    public override string ConvertFromNumber(double value)
    {
        var dt = UnixEpoch.AddMonths((int)value);
        return ConvertFromDate(dt);
    }

    public override DateTime? ConvertToDate(string value)
    {
        return ConvertFromMonth(value);
    }

    public override string ConvertFromDate(DateTime value)
    {
        return string.Format(CultureInfo.InvariantCulture, "{0:0000}-{1:00}", value.Year, value.Month);
    }

    public override void DoStep(int n)
    {
        var dt = ConvertFromMonth(Input.Value);

        if (dt.HasValue)
        {
            var date = dt.Value.AddMilliseconds(GetStep() * n);
            var min = ConvertFromMonth(Input.Minimum);
            var max = ConvertFromMonth(Input.Maximum);

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
        return 1.0;
    }

    #endregion

    #region Helper

    protected static DateTime? ConvertFromMonth(string value)
    {
        if (value is { Length: > 0 })
        {
            var position = FetchDigits(value);

            if (IsLegalPosition(value, position))
            {
                var yearString = value.Substring(0, position);
                var year = int.Parse(yearString, CultureInfo.InvariantCulture);
                var monthString = value.Substring(position + 1);
                var month = int.Parse(monthString, CultureInfo.InvariantCulture);

                if (IsLegalDay(1, month, year))
                {
                    return new DateTime(year, month, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                }
            }
        }

        return null;
    }

    private static bool IsLegalPosition(string value, int position)
    {
        return position >= 4 && position == value.Length - 3 &&
                value[position + 0] == Symbols.Minus &&
                value[position + 1].IsDigit() &&
                value[position + 2].IsDigit();
    }

    #endregion
}
