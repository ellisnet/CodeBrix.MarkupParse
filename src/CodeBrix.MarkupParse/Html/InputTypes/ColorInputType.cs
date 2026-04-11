using CodeBrix.MarkupParse.Html.Dom;
using System;
using System.Text.RegularExpressions;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class ColorInputType : BaseInputType
{
    #region Fields

    static readonly Regex hexColorPattern = new("^\\#[0-9A-Fa-f]{6}$", RegexOptions.Compiled);

    #endregion

    #region ctor

    public ColorInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var result = GetErrorsFrom(current);

        if (!hexColorPattern.IsMatch(Input.Value ?? string.Empty))
        {
            result ^= ValidationErrors.BadInput;

            if (Input.IsRequired)
            {
                result ^= ValidationErrors.ValueMissing;
            }

            return result;
        }

        return ValidationErrors.None;
    }

    #endregion
}
