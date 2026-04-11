using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class UrlInputType : BaseInputType
{
    #region ctor

    public UrlInputType(IHtmlInputElement input, string name)
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

        if (IsInvalidUrl(value) && !string.IsNullOrEmpty(value))
        {
            result ^= ValidationErrors.TypeMismatch | ValidationErrors.BadInput;
        }

        return result;
    }

    static bool IsInvalidUrl(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            var url = new Url(value);
            return url.IsInvalid || url.IsRelative;
        }

        return false;
    }

    #endregion
}
