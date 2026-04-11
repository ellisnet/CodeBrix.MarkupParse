using CodeBrix.MarkupParse.Html.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class SubmitInputType : BaseInputType
{
    #region ctor

    public SubmitInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
    }

    #endregion

    #region Methods

    public override bool IsAppendingData(IHtmlElement submitter)
    {
        return object.ReferenceEquals(submitter, Input);
    }

    #endregion
}
