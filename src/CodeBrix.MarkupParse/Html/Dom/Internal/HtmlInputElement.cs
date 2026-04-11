using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Html.InputTypes;
using CodeBrix.MarkupParse.Io.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML input element.
/// </summary>
sealed class HtmlInputElement : HtmlTextFormControlElement, IHtmlInputElement
{
    #region Fields

    private BaseInputType _type;
    private bool? _checked;

    #endregion

    #region ctor

    public HtmlInputElement(Document owner, string prefix = null)
        : base(owner, TagNames.Input, prefix, NodeFlags.SelfClosing)
    {
    }

    #endregion

    #region Properties

    public override string DefaultValue
    {
        get => this.GetOwnAttribute(AttributeNames.Value) ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public bool IsDefaultChecked
    {
        get => this.GetBoolAttribute(AttributeNames.Checked);
        set => this.SetBoolAttribute(AttributeNames.Checked, value);
    }

    public bool IsChecked
    {
        get => _checked ?? IsDefaultChecked;
        set => _checked = value;
    }

    public string Type
    {
        get => _type!.Name;
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public bool IsIndeterminate
    {
        get;
        set;
    }

    public bool IsMultiple
    {
        get => this.GetBoolAttribute(AttributeNames.Multiple);
        set => this.SetBoolAttribute(AttributeNames.Multiple, value);
    }

    public DateTime? ValueAsDate
    {
        get => _type!.ConvertToDate(Value);
        set
        {
            if (value is null)
            {
                Value = string.Empty;
            }
            else
            {
                Value = _type!.ConvertFromDate(value.Value);
            }
        }
    }

    public double ValueAsNumber
    {
        get => _type!.ConvertToNumber(Value) ?? double.NaN;
        set
        {
            if (double.IsInfinity(value))
            {
                throw new DomException(DomError.TypeMismatch);
            }

            if (double.IsNaN(value))
            {
                Value = string.Empty;
            }
            else
            {
                Value = _type!.ConvertFromNumber(value);
            }
        }
    }

    public string FormAction
    {
        get => this.GetOwnAttribute(AttributeNames.FormAction) ?? Owner?.DocumentUri;
        set => this.SetOwnAttribute(AttributeNames.FormAction, value);
    }

    public string FormEncType
    {
        get => this.GetOwnAttribute(AttributeNames.FormEncType).ToEncodingType() ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormEncType, value);
    }

    public string FormMethod
    {
        get => this.GetOwnAttribute(AttributeNames.FormMethod).ToFormMethod() ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormMethod, value);
    }

    public bool FormNoValidate
    {
        get => this.GetBoolAttribute(AttributeNames.FormNoValidate);
        set => this.SetBoolAttribute(AttributeNames.FormNoValidate, value);
    }

    [AllowNull]
    public string FormTarget
    {
        get => this.GetOwnAttribute(AttributeNames.FormTarget) ?? string.Empty;
        set => this.SetOwnAttribute(AttributeNames.FormTarget, value);
    }

    public string Accept
    {
        get => this.GetOwnAttribute(AttributeNames.Accept);
        set => this.SetOwnAttribute(AttributeNames.Accept, value);
    }

    public Alignment Align
    {
        get => this.GetOwnAttribute(AttributeNames.Align).ToEnum(Alignment.Left);
        set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public string AlternativeText
    {
        get => this.GetOwnAttribute(AttributeNames.Alt);
        set => this.SetOwnAttribute(AttributeNames.Alt, value);
    }

    public string Autocomplete
    {
        get => this.GetOwnAttribute(AttributeNames.AutoComplete);
        set => this.SetOwnAttribute(AttributeNames.AutoComplete, value);
    }

    public IFileList Files
    {
        get
        {
            var type = _type as FileInputType;
            return type?.Files;
        }
    }

    public IHtmlDataListElement List
    {
        get
        {
            var list = this.GetOwnAttribute(AttributeNames.List);

            if (list is { Length: > 0 })
            {
                var element = Owner?.GetElementById(list);
                return element as IHtmlDataListElement;
            }

            return null;
        }
    }

    public string Maximum
    {
        get => this.GetOwnAttribute(AttributeNames.Max);
        set => this.SetOwnAttribute(AttributeNames.Max, value);
    }

    public string Minimum
    {
        get => this.GetOwnAttribute(AttributeNames.Min);
        set => this.SetOwnAttribute(AttributeNames.Min, value);
    }

    public string Pattern
    {
        get => this.GetOwnAttribute(AttributeNames.Pattern);
        set => this.SetOwnAttribute(AttributeNames.Pattern, value);
    }

    public int Size
    {
        get => this.GetOwnAttribute(AttributeNames.Size).ToInteger(20);
        set => this.SetOwnAttribute(AttributeNames.Size, value.ToString());
    }

    public string Source
    {
        get => this.GetOwnAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Step
    {
        get => this.GetOwnAttribute(AttributeNames.Step);
        set => this.SetOwnAttribute(AttributeNames.Step, value);
    }

    public string UseMap
    {
        get => this.GetOwnAttribute(AttributeNames.UseMap);
        set => this.SetOwnAttribute(AttributeNames.UseMap, value);
    }

    public int DisplayWidth
    {
        get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(OriginalWidth);
        set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
        get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(OriginalHeight);
        set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int OriginalWidth
    {
        get
        {
            var type = _type as ImageInputType;
            return type?.Width ?? 0;
        }
    }

    public int OriginalHeight
    {
        get
        {
            var type = _type as ImageInputType;
            return type?.Height ?? 0;
        }
    }

    #endregion

    #region Design properties

    internal bool IsVisited
    {
        get;
        set;
    }

    internal bool IsActive
    {
        get;
        set;
    }

    #endregion

    #region Methods

    public sealed override Node Clone(Document owner, bool deep)
    {
        var node = (HtmlInputElement)base.Clone(owner, deep);
        node._checked = _checked;
        node.UpdateType(_type!.Name);
        return node;
    }

    public override async void DoClick()
    {
        var cancelled = await IsClickedCancelled().ConfigureAwait(false);
        var form = Form;

        if (!cancelled && form != null)
        {
            var type = Type;

            if (type.Is(InputTypeNames.Submit))
            {
                await form.SubmitAsync().ConfigureAwait(false);
            }
            else if (type.Is(InputTypeNames.Reset))
            {
                form.Reset();
            }
        }
    }

    internal override FormControlState SaveControlState() =>
        new(Name!, Type, Value);

    internal override void RestoreFormControlState(FormControlState state)
    {
        if (state.Type.Is(Type) && state.Name.Is(Name))
        {
            Value = state.Value;
        }
    }

    public void StepUp(int n = 1) => _type!.DoStep(n);

    public void StepDown(int n = 1) => _type!.DoStep(-n);

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();
        var type = this.GetOwnAttribute(AttributeNames.Type);
        UpdateType(type!);
    }

    internal void UpdateType(string value) =>
        _type = Context.GetFactory<IInputTypeFactory>().Create(this, value);

    #endregion

    #region Helpers

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
        if (_type!.IsAppendingData(submitter))
        {
            _type.ConstructDataSet(dataSet);
        }
    }

    internal override void Reset()
    {
        base.Reset();
        _checked = null;
        UpdateType(Type);
    }

    protected override void Check(ValidityState state)
    {
        base.Check(state);
        var result = _type!.Check(state);
        state.Reset(result);
    }

    protected override bool CanBeValidated() =>
        _type!.CanBeValidated && base.CanBeValidated();

    #endregion
}
