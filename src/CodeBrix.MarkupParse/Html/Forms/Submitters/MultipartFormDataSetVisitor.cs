using CodeBrix.MarkupParse.Io.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters; //Was previously: namespace AngleSharp.Html.Forms.Submitters

sealed class MultipartFormDataSetVisitor : IFormSubmitter
{
    #region Fields

    private static readonly string DashDash = "--";

    private readonly IHtmlEncoder _htmlEncoder;
    private readonly Encoding _encoding;
    private readonly List<Action<StreamWriter>> _writers;
    private readonly string _boundary;

    #endregion

    #region ctor

    public MultipartFormDataSetVisitor(IHtmlEncoder htmlEncoder, Encoding encoding, string boundary)
    {
        _htmlEncoder = htmlEncoder;
        _encoding = encoding;
        _writers = [];
        _boundary = boundary;
    }

    #endregion

    #region Methods

    public void Text(FormDataSetEntry entry, string value)
    {
        if (entry.HasName && value != null)
        {
            _writers.Add(stream =>
            {
                stream.WriteLine("Content-Disposition: form-data; name=\"{0}\"", _htmlEncoder.Encode(entry.Name, _encoding));
                stream.WriteLine();
                stream.WriteLine(_htmlEncoder.Encode(value, _encoding));
            });
        }
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
        if (entry.HasName)
        {
            _writers.Add(stream =>
            {
                var hasContent = content != null && content?.Name != null && content.Type != null && content.Body != null;

                stream.WriteLine("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"",
                    _htmlEncoder.Encode(entry.Name, _encoding), _htmlEncoder.Encode(fileName, _encoding));
                stream.WriteLine("Content-Type: {0}", contentType);
                stream.WriteLine();

                if (hasContent)
                {
                    stream.Flush();
                    content!.Body!.CopyTo(stream.BaseStream);
                }

                stream.WriteLine();
            });
        }
    }

    public void Serialize(StreamWriter stream)
    {
        stream.NewLine = "\r\n";    // multipart/form-data linefeed must be CRLF

        foreach (var writer in _writers)
        {
            stream.Write(DashDash);
            stream.WriteLine(_boundary);
            writer(stream);
        }

        stream.Write(DashDash);
        stream.Write(_boundary);
        stream.Write(DashDash);
    }

    #endregion
}
