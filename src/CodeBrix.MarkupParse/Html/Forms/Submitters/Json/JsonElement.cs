using System;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters.Json; //Was previously: namespace AngleSharp.Html.Forms.Submitters.Json

abstract class JsonElement
{
    public virtual JsonElement this[string key]
    {
        get => throw new InvalidOperationException();
        set => throw new InvalidOperationException();
    }
}
