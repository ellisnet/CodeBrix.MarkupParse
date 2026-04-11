using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML output element.
/// </summary>
sealed class HtmlOutputElement : HtmlFormControlElement, IHtmlOutputElement
{
    #region Fields

    private string _defaultValue;
    private string _value;
    private SettableTokenList _for;

    #endregion

    #region ctor
    
    public HtmlOutputElement(Document owner, string prefix = null)
        : base(owner, TagNames.Output, prefix)
    {
    }

    #endregion

    #region Properties

    public string DefaultValue
    {
        get => _defaultValue ?? TextContent;
        set => _defaultValue = value;
    }

    public override string TextContent
    {
        get => _value ?? _defaultValue ?? base.TextContent;
        set => base.TextContent = value;
    }

    public string Value
    {
        get => TextContent;
        set => _value = value;
    }

    public ISettableTokenList HtmlFor
    {
        get
        { 
            if (_for is null)
            {
                _for = new SettableTokenList(this.GetOwnAttribute(AttributeNames.For));
                _for.Changed += value => UpdateAttribute(AttributeNames.For, value);
            }

            return _for; 
        }
    }

    public string Type => TagNames.Output;

    #endregion

    #region Internal Methods

    internal override void Reset()
    {
        _value = null;
    }

    internal void UpdateFor(string value)
    {
        _for?.Update(value);
    }

    #endregion

    #region Helpers

    protected override bool CanBeValidated()
    {
        return true;
    }

    #endregion
}
