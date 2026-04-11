using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class ButtonInputType : BaseInputType
{
    #region ctor

    public ButtonInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: false)
    {
    }

    #endregion

    #region Methods

    public override bool IsAppendingData(IHtmlElement submitter)
    {
        return !Name.Is(InputTypeNames.Reset) || object.ReferenceEquals(submitter, Input);
    }

    #endregion
}
