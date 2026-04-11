using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

sealed class AttrContainsSelector : BaseAttrSelector, ISelector
{
    private readonly string _value;
    private readonly StringComparison _comparison;

    public AttrContainsSelector(string name, string value, string prefix = null, bool insensitive = false)
        : base(name, prefix)
    {
        _value = value;
        _comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }

    public string Text => string.Concat("[", Attribute, "*=", _value.CssString(), "]");

    public void Accept(ISelectorVisitor visitor) => visitor.Attribute(Attribute, "*=", _value);

    public bool Match(IElement element, IElement scope)
    {
        if (!string.IsNullOrEmpty(_value))
        {
            var actual = element.GetAttribute(Name) ?? string.Empty;
            return actual.IndexOf(_value, _comparison) != -1;
        }

        return false;
    }
}
