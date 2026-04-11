using CodeBrix.MarkupParse.Html.Forms.Submitters;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Text;
using System;
using System.IO;
using System.Text;

namespace CodeBrix.MarkupParse.Html.Forms; //Was previously: namespace AngleSharp.Html.Forms

static class FormDataSetExtensions
{
    public static Stream CreateBody(this FormDataSet formDataSet, string enctype, string charset, IHtmlEncoder htmlEncoder)
    {
        var encoding = TextEncoding.Resolve(charset);
        return formDataSet.CreateBody(enctype, encoding, htmlEncoder ?? new DefaultHtmlEncoder());
    }

    public static Stream CreateBody(this FormDataSet formDataSet, string enctype, Encoding encoding, IHtmlEncoder htmlEncoder)
    {
        if (enctype.Isi(MimeTypeNames.UrlencodedForm))
        {
            return formDataSet.AsUrlEncoded(encoding);
        }
        else if (enctype.Isi(MimeTypeNames.MultipartForm))
        {
            return formDataSet.AsMultipart(htmlEncoder, encoding);
        }
        else if (enctype.Isi(MimeTypeNames.Plain))
        {
            return formDataSet.AsPlaintext(encoding);
        }
        else if (enctype.Isi(MimeTypeNames.ApplicationJson))
        {
            return formDataSet.AsJson();
        }

        return MemoryStream.Null;
    }
}
