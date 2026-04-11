using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

abstract class BaseAttrSelector
{
    private readonly string _name;
    private readonly string _prefix;
    private readonly string _attr;

    public BaseAttrSelector(string name, string prefix)
    {
        _name = name;
        _prefix = prefix;

        if (!string.IsNullOrEmpty(prefix) && prefix is not "*")
        {
            _attr = string.Concat(prefix, ":", name);
        }
        else
        {
            _attr = name;
        }
    }

    public Priority Specificity => Priority.OneClass;

    protected string Attribute => !string.IsNullOrEmpty(_prefix) ? string.Concat(CssUtilities.Escape(_prefix!), "|", CssUtilities.Escape(_name)) : CssUtilities.Escape(_name);

    protected string Name => _attr;
}
