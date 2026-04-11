using CodeBrix.MarkupParse.Io.Dom;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters; //Was previously: namespace AngleSharp.Html.Forms.Submitters

sealed class PlaintextFormDataSetVisitor : IFormSubmitter
{
    #region Fields

    private readonly List<string> _lines;

    #endregion

    #region ctor

    public PlaintextFormDataSetVisitor()
    {
        _lines = [];
    }

    #endregion

    #region Methods

    public void Text(FormDataSetEntry entry, string value)
    {
        if (entry.HasName && value != null)
        {
            Add(entry.Name, value);
        }
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
        if (entry.HasName && content?.Name != null)
        {
            Add(entry.Name, content.Name);
        }
    }

    public void Serialize(StreamWriter stream)
    {
        var content = string.Join("\r\n", _lines);
        stream.Write(content);
    }

    #endregion

    #region Helpers

    private void Add(string name, string value)
    {
        _lines.Add(string.Concat(name, "=", value));
    }

    #endregion
}
