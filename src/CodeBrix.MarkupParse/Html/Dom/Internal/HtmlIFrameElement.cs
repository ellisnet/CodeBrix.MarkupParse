using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML iframe element.
/// </summary>
sealed class HtmlIFrameElement : HtmlFrameElementBase, IHtmlInlineFrameElement
{
    #region Fields

    private SettableTokenList _sandbox;
    
    #endregion

    #region ctor
    
    public HtmlIFrameElement(Document owner, string prefix = null)
        : base(owner, TagNames.Iframe, prefix, NodeFlags.LiteralText)
    {
    }

    #endregion

    #region Properties

    public Alignment Align
    {
        get => this.GetOwnAttribute(AttributeNames.Align).ToEnum(Alignment.Bottom);
        set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public string ContentHtml
    {
        get => this.GetOwnAttribute(AttributeNames.SrcDoc);
        set => this.SetOwnAttribute(AttributeNames.SrcDoc, value);
    }

    public ISettableTokenList Sandbox
    {
        get
        { 
            if (_sandbox is null)
            {
                _sandbox = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Sandbox));
                _sandbox.Changed += value => UpdateAttribute(AttributeNames.Sandbox, value);
            }

            return _sandbox;
        }
    }

    public bool IsSeamless
    {
        get => this.GetBoolAttribute(AttributeNames.SrcDoc);
        set => this.SetBoolAttribute(AttributeNames.SrcDoc, value);
    }

    public bool IsFullscreenAllowed
    {
        get => this.GetBoolAttribute(AttributeNames.AllowFullscreen);
        set => this.SetBoolAttribute(AttributeNames.AllowFullscreen, value);
    }

    public bool IsPaymentRequestAllowed
    {
        get => this.GetBoolAttribute(AttributeNames.AllowPaymentRequest);
        set => this.SetBoolAttribute(AttributeNames.AllowPaymentRequest, value);
    }

    public string ReferrerPolicy
    {
        get => this.GetOwnAttribute(AttributeNames.ReferrerPolicy);
        set => this.SetOwnAttribute(AttributeNames.ReferrerPolicy, value);
    }

    public IWindow ContentWindow => NestedContext.Current;

    #endregion

    #region Internal Methods

    internal override string GetContentHtml()
    {
        return ContentHtml!;
    }

    internal override void SetupElement()
    {
        base.SetupElement();
        
        if (this.GetOwnAttribute(AttributeNames.SrcDoc) != null)
        {
            UpdateSource();
        }
    }

    internal void UpdateSandbox(string value)
    {
        _sandbox?.Update(value);
    }

    #endregion
}
