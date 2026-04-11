using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML option element.
/// </summary>
sealed class HtmlOptionElement : HtmlElement, IHtmlOptionElement
{
    #region Fields

    private bool? _selected;

    #endregion

    #region ctor

    public HtmlOptionElement(Document owner, string prefix = null)
        : base(owner, TagNames.Option, prefix, NodeFlags.ImplicitlyClosed | NodeFlags.ImpliedEnd | NodeFlags.HtmlSelectScoped)
    {
    }

    #endregion           
    
    #region Properties

    public bool IsDisabled
    {
        get => this.GetBoolAttribute(AttributeNames.Disabled);
        set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public IHtmlFormElement Form => GetAssignedForm();

    [AllowNull]
    public string Label
    {
        get => this.GetOwnAttribute(AttributeNames.Label) ?? Text;
        set => this.SetOwnAttribute(AttributeNames.Label, value);
    }

    public string Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value) ?? Text;
        set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public int Index
    {
        get
        {

            if (Parent is HtmlOptionsGroupElement group)
            {
                var i = 0;

                foreach (var child in group.ChildNodes)
                {
                    if (object.ReferenceEquals(child, this))
                    {
                        return i;
                    }

                    i++;
                }
            }

            return 0;
        }
    }

    public string Text
    {
        get => TextContent.CollapseAndStrip();
        set => TextContent = value;
    }

    public bool IsDefaultSelected
    {
        get => this.GetBoolAttribute(AttributeNames.Selected);
        set => this.SetBoolAttribute(AttributeNames.Selected, value);
    }

    public bool IsSelected
    {
        get => _selected ?? IsDefaultSelected;
        set => _selected = value;
    }

    #endregion
}
