using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML button element.
/// </summary>
sealed class HtmlButtonElement : HtmlFormControlElement, IHtmlButtonElement
{
    #region ctor

    /// <summary>
    /// Creates a new HTML button element.
    /// </summary>
    public HtmlButtonElement(Document owner, string prefix = null)
        : base(owner, TagNames.Button, prefix)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the behavior of the button.
    /// </summary>
    public string Type
    {
        get => (this.GetOwnAttribute(AttributeNames.Type) ?? InputTypeNames.Submit).ToLowerInvariant();
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    /// <summary>
    /// Gets or sets the URI of a resource that processes information submitted by the button.
    /// If specified, this attribute overrides the action attribute of the form element that owns this element.
    /// </summary>
    public string FormAction
    {
        get => this.GetOwnAttribute(AttributeNames.FormAction) ?? Owner?.DocumentUri;
        set => this.SetOwnAttribute(AttributeNames.FormAction, value);
    }

    /// <summary>
    /// Gets or sets the type of content that is used to submit the form to the server. If specified, this
    /// attribute overrides the enctype attribute of the form element that owns this element.
    /// </summary>
    public string FormEncType
    {
        get => this.GetOwnAttribute(AttributeNames.FormEncType).ToEncodingType() ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormEncType, value);
    }

    /// <summary>
    /// Gets or sets the HTTP method that the browser uses to submit the form. If specified, this attribute
    /// overrides the method attribute of the form element that owns this element.
    /// </summary>
    public string FormMethod
    {
        get => this.GetOwnAttribute(AttributeNames.FormMethod).ToFormMethod() ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormMethod, value);
    }

    /// <summary>
    /// Gets or sets that the form is not to be validated when it is submitted. If specified, this attribute
    /// overrides the enctype attribute of the form element that owns this element.
    /// </summary>
    public bool FormNoValidate
    {
        get => this.GetBoolAttribute(AttributeNames.FormNoValidate);
        set => this.SetBoolAttribute(AttributeNames.FormNoValidate, value);
    }

    /// <summary>
    /// Gets or sets A name or keyword indicating where to display the response that is received after submitting
    /// the form. If specified, this attribute overrides the target attribute of the form element that owns this element.
    /// </summary>
    [AllowNull]
    public string FormTarget
    {
        get => this.GetOwnAttribute(AttributeNames.FormTarget) ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormTarget, value);
    }

    /// <summary>
    /// Gets or sets the current value of the control.
    /// </summary>
    public string Value
    {
        get => this.GetOwnAttribute(AttributeNames.Value) ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    #endregion

    #region Design properties

    /// <summary>
    /// Gets or sets if the link has been visited.
    /// </summary>
    internal bool IsVisited
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets if the link is currently active.
    /// </summary>
    internal bool IsActive
    {
        get;
        set;
    }

    #endregion

    #region Methods

    public override async void DoClick()
    {
        var cancelled = await IsClickedCancelled().ConfigureAwait(false);
        var form = Form;

        if (!cancelled && form != null)
        {
            var type = Type;

            if (type.Is(InputTypeNames.Submit))
            {
                await form.SubmitAsync(this).ConfigureAwait(false);
            }
            else if (type.Is(InputTypeNames.Reset))
            {
                form.Reset();
            }
        }
    }

    #endregion

    #region Helper

    protected override bool CanBeValidated()
    {
        return Type.Is(InputTypeNames.Submit) && !this.HasDataListAncestor();
    }

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
        var type = Type;

        if (object.ReferenceEquals(this, submitter) && type.IsOneOf(InputTypeNames.Submit, InputTypeNames.Reset))
        {
            dataSet.Append(Name!, Value, type);
        }
    }

    #endregion
}
