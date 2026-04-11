using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io.Processors;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class ImageInputType : BaseInputType
{
    #region Fields

    private readonly ImageRequestProcessor _request;

    #endregion

    #region ctor

    public ImageInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
        var inp = input as HtmlInputElement;
        var src = input.Source;

        if (src != null && inp != null)
        {
            var url = inp.HyperReference(src);
            _request = new ImageRequestProcessor(inp.Context);
            inp.Process(_request, url);
        }
    }

    #endregion

    #region Properties

    public int Width => _request?.Width ?? 0;

    public int Height =>  _request?.Height ?? 0;

    #endregion

    #region Methods

    public override bool IsAppendingData(IHtmlElement submitter)
    {
        return object.ReferenceEquals(submitter, Input) && !string.IsNullOrEmpty(Input.Name);
    }

    public override void ConstructDataSet(FormDataSet dataSet)
    {
        var name = Input.Name;
        var value = Input.Value;

        dataSet.Append(name + ".x", "0", Input.Type);
        dataSet.Append(name + ".y", "0", Input.Type);

        if (!string.IsNullOrEmpty(value))
        {
            dataSet.Append(name!, value, Input.Type);
        }
    }

    #endregion
}
