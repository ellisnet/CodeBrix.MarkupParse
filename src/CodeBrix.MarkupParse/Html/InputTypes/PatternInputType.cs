using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class PatternInputType : BaseInputType
{
    #region ctor

    public PatternInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override ValidationErrors Check(IValidityState current)
    {
        var result = GetErrorsFrom(current);

        if (IsInvalidPattern(Input.Pattern, Input.Value ?? string.Empty))
        {
            result ^= ValidationErrors.PatternMismatch;
        }

        return result;
    }

    #endregion
}
