using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a HTML textarea element.
/// </summary>
sealed class HtmlTextAreaElement : HtmlTextFormControlElement, IHtmlTextAreaElement
{
    #region ctor

    /// <summary>
    /// Creates a new HTML textarea element.
    /// </summary>
    public HtmlTextAreaElement(Document owner, string prefix = null)
        : base(owner, TagNames.Textarea, prefix, NodeFlags.LineTolerance)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the wrap HTML attribute, indicating how the control wraps text.
    /// </summary>
    public string Wrap
    {
        get => this.GetOwnAttribute(AttributeNames.Wrap);
        set => this.SetOwnAttribute(AttributeNames.Wrap, value);
    }

    /// <summary>
    /// Gets or sets the default value of the input field.
    /// </summary>
    public override string DefaultValue
    {
        get => TextContent;
        set => TextContent = value;
    }

    /// <summary>
    /// Gets the codepoint length of the control's value.
    /// </summary>
    public int TextLength => Value.Length;

    /// <summary>
    /// Gets or sets the rows HTML attribute, indicating
    /// the number of visible text lines for the control.
    /// </summary>
    public int Rows
    {
        get => this.GetOwnAttribute(AttributeNames.Rows).ToInteger(2);
        set => this.SetOwnAttribute(AttributeNames.Rows, value.ToString());
    }

    /// <summary>
    /// Gets or sets the cols HTML attribute, indicating
    /// the visible width of the text area.
    /// </summary>
    public int Columns
    {
        get => this.GetOwnAttribute(AttributeNames.Cols).ToInteger(20);
        set => this.SetOwnAttribute(AttributeNames.Cols, value.ToString());
    }

    /// <summary>
    /// Gets the type of input control (texarea).
    /// </summary>
    public string Type => TagNames.Textarea;

    #endregion

    #region Helpers

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
        ConstructDataSet(dataSet, Type);
    }

    internal override FormControlState SaveControlState()
    {
        return new FormControlState(Name!, Type, Value);
    }

    internal override void RestoreFormControlState(FormControlState state)
    {
        if (state.Type.Is(Type) && state.Name.Is(Name!))
        {
            Value = state.Value;
        }
    }

    #endregion
}
