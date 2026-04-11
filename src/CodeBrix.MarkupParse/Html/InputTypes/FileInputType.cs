using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.InputTypes; //Was previously: namespace AngleSharp.Html.InputTypes

class FileInputType : BaseInputType
{
    #region Fields

    private readonly FileList _files;

    #endregion

    #region ctor

    public FileInputType(IHtmlInputElement input, string name)
        : base(input, name, validate: true)
    {
        _files = [];
    }

    #endregion

    #region Properties

    public FileList Files => _files;

    #endregion

    #region Methods

    public override void ConstructDataSet(FormDataSet dataSet)
    {
        if (_files.Length == 0)
        {
            dataSet.Append(Input.Name!, default(IFile)!, Input.Type);
        }

        foreach (var file in _files)
        {
            dataSet.Append(Input.Name!, file, Input.Type);
        }
    }

    #endregion
}
