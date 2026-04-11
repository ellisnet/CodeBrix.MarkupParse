using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters.Json; //Was previously: namespace AngleSharp.Html.Forms.Submitters.Json

sealed class JsonObject : JsonElement
{
    private readonly Dictionary<string, JsonElement> _properties = [];

    public override JsonElement this[string key]
    {
        get
        {
            _properties.TryGetValue(key.ToString(), out var tmp);
            return tmp;
        }
        set => _properties[key] = value;
    }

    public override string ToString()
    {
        var sb = StringBuilderPool.Obtain().Append(Symbols.CurlyBracketOpen);
        var needsComma = false;

        foreach (var property in _properties)
        {
            if (needsComma)
            {
                sb.Append(Symbols.Comma);
            }

            sb.Append(Symbols.DoubleQuote).Append(property.Key).Append(Symbols.DoubleQuote);
            sb.Append(Symbols.Colon).Append(property.Value!.ToString());
            needsComma = true;
        }

        return sb.Append(Symbols.CurlyBracketClose).ToPool();
    }
}
