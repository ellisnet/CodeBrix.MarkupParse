using System;
using System.Text;

namespace CodeBrix.MarkupParse.Html.Forms; //Was previously: namespace AngleSharp.Html.Forms

/// <summary>
/// A text entry in a form.
/// </summary>
sealed class TextDataSetEntry : FormDataSetEntry
{
    private readonly string _value;

    public TextDataSetEntry(string name, string value, string type)
        : base(name, type)
    {
        _value = value;
    }

    public override bool Contains(string boundary, Encoding encoding)
    {
        return _value != null && _value.Contains(boundary);
    }

    public override void Accept(IFormDataSetVisitor visitor)
    {
        visitor.Text(this, _value);
    }
}
