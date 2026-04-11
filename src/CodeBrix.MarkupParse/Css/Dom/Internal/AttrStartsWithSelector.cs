using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class AttrStartsWithSelector : BaseAttrSelector, ISelector
{
    private readonly string _value;
    private readonly StringComparison _comparison;

    public AttrStartsWithSelector(string name, string value, string prefix = null, bool insensitive = false)
        : base(name, prefix)
    {
        _value = value;
        _comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }

    public string Text => string.Concat("[", Attribute, "^=", _value.CssString(), "]");

    public void Accept(ISelectorVisitor visitor) => visitor.Attribute(Attribute, "^=", _value);

    public bool Match(IElement element, IElement scope)
    {
        if (!string.IsNullOrEmpty(_value))
        {
            var actual = element.GetAttribute(Name) ?? string.Empty;
            return actual.StartsWith(_value, _comparison);
        }

        return false;
    }
}
