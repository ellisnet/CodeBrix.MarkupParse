using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class TextInputType : BaseInputType
{
    #region ctor

    public TextInputType(IHtmlInputElement input, string name)
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

    public override void ConstructDataSet(FormDataSet dataSet)
    {
        base.ConstructDataSet(dataSet);
        var dirname = Input.GetAttribute(null, AttributeNames.DirName);

        if (dirname is { Length: > 0 })
        {
            dataSet.Append(dirname, Input.Direction?.ToLowerInvariant()!, "Direction");
        }
    }

    #endregion
}
