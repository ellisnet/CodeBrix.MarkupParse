using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the keygen element.
/// </summary>
sealed class HtmlKeygenElement : HtmlFormControlElementWithState, IHtmlKeygenElement
{
    #region ctor

    /// <summary>
    /// Creates a new HTML keygen element.
    /// </summary>
    public HtmlKeygenElement(Document owner, string prefix = null)
        : base(owner, TagNames.Keygen, prefix, NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the challenge attribute.
    /// </summary>
    public string Challenge
    {
        get => this.GetOwnAttribute(AttributeNames.Challenge);
        set => this.SetOwnAttribute(AttributeNames.Challenge, value);
    }

    /// <summary>
    /// Gets or sets the type of key used.
    /// </summary>
    public string KeyEncryption
    {
        get => this.GetOwnAttribute(AttributeNames.Keytype);
        set => this.SetOwnAttribute(AttributeNames.Keytype, value);
    }

    /// <summary>
    /// Gets the type of input control (keygen).
    /// </summary>
    public string Type => TagNames.Keygen;

    #endregion

    #region Methods

    internal override FormControlState SaveControlState()
    {
        return new FormControlState(Name!, Type, Challenge!);
    }

    internal override void RestoreFormControlState(FormControlState state)
    {
        if (state.Type.Is(Type) && state.Name.Is(Name))
        {
            Challenge = state.Value;
        }
    }

    protected override bool CanBeValidated()
    {
        return false;
    }

    #endregion
}
