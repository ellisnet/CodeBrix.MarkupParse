using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

/// <summary>
/// Base type for the all input field types. Primarily from:
/// http://www.w3.org/TR/html5/forms.html#range-state-(type=range)
/// </summary>
public abstract class BaseInputType
{
    #region Fields

    /// <summary>
    /// The start of the unix epoch (1st of January 1970).
    /// </summary>
    protected static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Simple regular expression for floating point numbers.
    /// </summary>
    protected static readonly Regex NumberPattern = new("^\\-?\\d+(\\.\\d+)?([eE][\\-\\+]?\\d+)?$", RegexOptions.Compiled);

    private readonly IHtmlInputElement _input;
    private readonly bool _validate;
    private readonly string _name;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new base input type.
    /// </summary>
    public BaseInputType(IHtmlInputElement input, string name, bool validate)
    {
        _input = input;
        _validate = validate;
        _name = name;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the name of the input type.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets if the input type can be validated.
    /// </summary>
    public bool CanBeValidated => _validate;

    /// <summary>
    /// Gets the associated input element.
    /// </summary>
    public IHtmlInputElement Input => _input;

    #endregion

    #region Methods

    /// <summary>
    /// Checks if the given type wants to append data.
    /// </summary>
    public virtual bool IsAppendingData(IHtmlElement submitter)
    {
        return true;
    }

    /// <summary>
    /// Checks the current input for its validity.
    /// </summary>
    public virtual ValidationErrors Check(IValidityState current)
    {
        return GetErrorsFrom(current);
    }

    /// <summary>
    /// Tries to convert the given string to a number.
    /// </summary>
    public virtual double? ConvertToNumber(string value)
    {
        return null;
    }

    /// <summary>
    /// Tries to convert the given number to a string.
    /// </summary>
    public virtual string ConvertFromNumber(double value)
    {
        throw new DomException(DomError.InvalidState);
    }

    /// <summary>
    /// Tries to convert the given string to a date time.
    /// </summary>
    public virtual DateTime? ConvertToDate(string value)
    {
        return null;
    }

    /// <summary>
    /// Tries to convert the given date time to a string.
    /// </summary>
    public virtual string ConvertFromDate(DateTime value)
    {
        throw new DomException(DomError.InvalidState);
    }

    /// <summary>
    /// Populates the form data set with the current input.
    /// </summary>
    public virtual void ConstructDataSet(FormDataSet dataSet)
    {
        dataSet.Append(_input.Name!, _input.Value, _input.Type);
    }

    /// <summary>
    /// Changes the value by n steps.
    /// </summary>
    public virtual void DoStep(int n)
    {
        throw new DomException(DomError.InvalidState);
    }

    #endregion

    #region Step

    /// <summary>
    /// Checks if the current value does not match the steps.
    /// </summary>
    protected bool IsStepMismatch()
    {
        var step = (decimal)GetStep();
        var value = (decimal)(ConvertToNumber(_input.Value) ?? 0);
        var offset = (decimal)GetStepBase();

        return step != decimal.Zero && (value - offset) % step != decimal.Zero;
    }

    /// <summary>
    /// Gets the current step size.
    /// </summary>
    protected double GetStep()
    {
        var step = _input.Step;

        if (string.IsNullOrEmpty(step))
        {
            return GetDefaultStep() * GetStepScaleFactor();
        }
        else if (step.Isi(Keywords.Any))
        {
            return 0.0;
        }

        var num = ToNumber(step);

        if (num.HasValue == false || num <= 0.0)
        {
            return GetDefaultStep() * GetStepScaleFactor();
        }

        return num.Value * GetStepScaleFactor();
    }

    private double GetStepBase()
    {
        var num = ConvertToNumber(_input.Minimum);

        if (num.HasValue)
        {
            return num.Value;
        }

        num = ConvertToNumber(_input.DefaultValue);

        if (num.HasValue)
        {
            return num.Value;
        }

        return GetDefaultStepBase();
    }

    /// <summary>
    /// Gets the default step offset.
    /// </summary>
    protected virtual double GetDefaultStepBase()
    {
        return 0.0;
    }

    /// <summary>
    /// Gets the default step size.
    /// </summary>
    protected virtual double GetDefaultStep()
    {
        return 1.0;
    }

    /// <summary>
    /// Gets the step scaling factor.
    /// </summary>
    protected virtual double GetStepScaleFactor()
    {
        return 1.0;
    }

    #endregion

    #region Helper

    /// <summary>
    /// Converts the given validity state to a validation error enum.
    /// </summary>
    protected static ValidationErrors GetErrorsFrom(IValidityState state)
    {
        var result = ValidationErrors.None;

        if (state.IsBadInput)
        {
            result ^= ValidationErrors.BadInput;
        }

        if (state.IsTooShort)
        {
            result ^= ValidationErrors.TooShort;
        }

        if (state.IsTooLong)
        {
            result ^= ValidationErrors.TooLong;
        }

        if (state.IsValueMissing)
        {
            result ^= ValidationErrors.ValueMissing;
        }

        if (state.IsCustomError)
        {
            result ^= ValidationErrors.Custom;
        }

        return result;
    }

    /// <summary>
    /// Validates the time using the given parameters.
    /// </summary>
    protected ValidationErrors CheckTime(IValidityState state, string value, DateTime? date, DateTime? min, DateTime? max)
    {
        var result = state.IsCustomError ?
            ValidationErrors.Custom :
            ValidationErrors.None;

        if (date.HasValue)
        {
            if (min.HasValue && date < min.Value)
            {
                result ^= ValidationErrors.RangeUnderflow;
            }

            if (max.HasValue && date > max.Value)
            {
                result ^= ValidationErrors.RangeOverflow;
            }

            if (IsStepMismatch())
            {
                result ^= ValidationErrors.StepMismatch;
            }
        }
        else
        {
            if (Input.IsRequired)
            {
                result ^= ValidationErrors.ValueMissing;
            }

            if (!string.IsNullOrEmpty(value))
            {
                result ^= ValidationErrors.BadInput;
            }
        }

        return result;
    }

    /// <summary>
    /// Checks if the string does not follow the pattern.
    /// </summary>
    protected static bool IsInvalidPattern(string pattern, string value)
    {
        if (!string.IsNullOrEmpty(pattern) && !string.IsNullOrEmpty(value))
        {
            try
            {
                var regex = new Regex(pattern, RegexOptions.ECMAScript | RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100));
                return !regex.IsMatch(value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while matching the pattern: {0}.", ex);
            }
        }

        return false;
    }

    /// <summary>
    /// Tries to convert the value to a number using the default expression.
    /// </summary>
    protected static double? ToNumber(string value)
    {
        if (!string.IsNullOrEmpty(value) && NumberPattern.IsMatch(value))
        {
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        return null;
    }

    /// <summary>
    /// Tries to convert the value to a time starting at the given position.
    /// </summary>
    protected static TimeSpan? ToTime(string value, ref int position)
    {
        var offset = position;
        var second = 0;
        var ms = 0;

        if (value.Length >= 5 + offset && 
            value[position++].IsDigit() && 
            value[position++].IsDigit() && 
            value[position++] == Symbols.Colon)
        {
            var hour = int.Parse(value.Substring(offset, 2), CultureInfo.InvariantCulture);

            if (!IsLegalHour(hour) || !value[position++].IsDigit() || !value[position++].IsDigit())
            {
                return null;
            }

            var minute = int.Parse(value.Substring(3 + offset, 2), CultureInfo.InvariantCulture);

            if (!IsLegalMinute(minute))
            {
                return null;
            }

            if (value.Length >= 8 + offset && value[position] == Symbols.Colon)
            {
                position++;

                if (!value[position++].IsDigit() || !value[position++].IsDigit())
                {
                    return null;
                }

                second = int.Parse(value.Substring(6 + offset, 2), CultureInfo.InvariantCulture);

                if (!IsLegalSecond(second))
                {
                    return null;
                }

                if (position + 1 < value.Length && value[position] == Symbols.Dot)
                {
                    position++;
                    var start = position;

                    while (position < value.Length && value[position].IsDigit())
                    {
                        position++;
                    }

                    var fraction = value.Substring(start, position - start);
                    ms = int.Parse(fraction, CultureInfo.InvariantCulture) * (int)Math.Pow(10, 3 - fraction.Length);
                }
            }

            return new TimeSpan(0, hour, minute, second, ms);
        }

        return null;
    }

    /// <summary>
    /// Tries to convert the value to a week.
    /// </summary>
    protected static int GetWeekOfYear(DateTime value)
    {
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }

    /// <summary>
    /// Checks if the given value is a legal hour.
    /// </summary>
    protected static bool IsLegalHour(int value)
    {
        return value >= 0 && value <= 23;
    }

    /// <summary>
    /// Checks if the given value is a legal second.
    /// </summary>
    protected static bool IsLegalSecond(int value)
    {
        return value >= 0 && value <= 59;
    }

    /// <summary>
    /// Checks if the given value is a legal minute.
    /// </summary>
    protected static bool IsLegalMinute(int value)
    {
        return value >= 0 && value <= 59;
    }

    /// <summary>
    /// Checks if the given value is a legal month.
    /// </summary>
    protected static bool IsLegalMonth(int value)
    {
        return value >= 1 && value <= 12;
    }

    /// <summary>
    /// Checks if the given value is a legal year.
    /// </summary>
    protected static bool IsLegalYear(int value)
    {
        return value >= 0 && value <= 9999;
    }

    /// <summary>
    /// Checks if the given values form a legal date.
    /// </summary>
    protected static bool IsLegalDay(int day, int month, int year)
    {
        if (IsLegalYear(year) && IsLegalMonth(month))
        {
            var cal = CultureInfo.InvariantCulture.Calendar;
            return day >= 1 && day <= cal.GetDaysInMonth(year, month);
        }

        return false;
    }

    /// <summary>
    /// Checks if the given values form a legal week.
    /// </summary>
    protected static bool IsLegalWeek(int week, int year)
    {
        if (IsLegalYear(year))
        {
            var endOfYear = new DateTime(year, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc);
            var numOfWeeks = GetWeekOfYear(endOfYear);
            return week >= 0 && week < numOfWeeks;
        }

        return false;
    }

    /// <summary>
    /// Checks if the given character is a valid time separator.
    /// </summary>
    protected static bool IsTimeSeparator(char chr)
    {
        return chr == ' ' || chr == 'T';
    }

    /// <summary>
    /// Skips all legit digits while returning the final position.
    /// </summary>
    protected static int FetchDigits(string value)
    {
        var position = 0;

        while (position < value.Length && value[position].IsDigit())
        {
            position++;
        }

        return position;
    }

    /// <summary>
    /// Checks the assumption that the string continues with a date time.
    /// </summary>
    protected static bool PositionIsValidForDateTime(string value, int position)
    {
        return position >= 4 && position <= value.Length - 13 &&
                value[position + 0] == Symbols.Minus &&
                value[position + 1].IsDigit() &&
                value[position + 2].IsDigit() &&
                value[position + 3] == Symbols.Minus &&
                value[position + 4].IsDigit() &&
                value[position + 5].IsDigit();
    }

    #endregion
}
