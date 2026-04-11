using CodeBrix.MarkupParse.Text;
using System;
using System.Globalization;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters.Json; //Was previously: namespace AngleSharp.Html.Forms.Submitters.Json

sealed class JsonValue : JsonElement
{
    private readonly string _value;

    public JsonValue(string value)
    {
        _value = value.CssString();
    }

    public JsonValue(double value)
    {
        _value = value.ToString(CultureInfo.InvariantCulture);
    }

    public JsonValue(bool value)
    {
        _value = value ? "true" : "false";
    }

    public override string ToString()
    {
        return _value;
    }
}
