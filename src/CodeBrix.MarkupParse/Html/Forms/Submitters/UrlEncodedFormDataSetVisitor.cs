using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters; //Was previously: namespace AngleSharp.Html.Forms.Submitters

sealed class UrlEncodedFormDataSetVisitor : IFormSubmitter
{
    #region Fields

    private readonly Encoding _encoding;
    private readonly List<string> _lines;
    private bool _first;
    private string _index;

    #endregion

    #region ctor

    public UrlEncodedFormDataSetVisitor(Encoding encoding)
    {
        _encoding = encoding;
        _lines = [];
        _first = true;
        _index = string.Empty;
    }

    #endregion

    #region Methods

    public void Text(FormDataSetEntry entry, string value)
    {
        if (_first && entry.HasName && entry.Name.Is(TagNames.IsIndex) && entry.Type.Isi(InputTypeNames.Text))
        {
            _index = value ?? string.Empty;
        }
        else if (entry.HasName && value != null)
        {
            var k = _encoding.GetBytes(entry.Name);
            var v = _encoding.GetBytes(value);
            Add(k, v);
        }

        _first = false;
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
        if (entry.HasName && content?.Name != null)
        {
            var k = _encoding.GetBytes(entry.Name);
            var v = _encoding.GetBytes(content.Name);
            Add(k, v);
        }

        _first = false;
    }

    public void Serialize(StreamWriter stream)
    {
        var content = string.Join("&", _lines);
        stream.Write(_index);
        stream.Write(content);
    }

    #endregion

    #region Helpers

    private void Add(byte[] name, byte[] value)
    {
        _lines.Add(string.Concat(name.UrlEncode(), "=", value.UrlEncode()));
    }

    #endregion
}
