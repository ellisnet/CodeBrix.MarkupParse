using CodeBrix.MarkupParse.Html.Dom;
using System;
using System.Text.RegularExpressions;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class EmailInputType : BaseInputType
{
    #region Fields

    static readonly Regex emailPattern = new("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.Compiled);

    #endregion

    #region ctor

    public EmailInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var value = Input.Value ?? string.Empty;
        var result = GetErrorsFrom(current);

        if (IsInvalidPattern(Input.Pattern, value))
        {
            result ^= ValidationErrors.PatternMismatch;
        }

        if (IsInvalidEmail(Input.IsMultiple, value) && !string.IsNullOrEmpty(value))
        {
            result ^= ValidationErrors.TypeMismatch | ValidationErrors.BadInput;
        }

        return result;
    }

    static bool IsInvalidEmail(bool multiple, string value)
    {
        if (multiple)
        {
            var mails = value.Split(',');

            foreach (var mail in mails)
            {
                if (!emailPattern.IsMatch(mail.Trim()))
                {
                    return true;
                }
            }

            return false;
        }

        return !emailPattern.IsMatch(value.Trim());
    }

    #endregion
}
