using CodeBrix.MarkupParse.Dom;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base class for all HTML form control elements.
/// </summary>
abstract class HtmlFormControlElement : HtmlElement, ILabelabelElement, IValidation
{
    #region Fields

    private readonly NodeList _labels;
    private readonly ValidityState _vstate;
    private string _error;

    #endregion

    #region ctor

    public HtmlFormControlElement(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
        : base(owner, name, prefix, flags | NodeFlags.Special)
    {
        _vstate = new ValidityState();
        _labels = [];
    }

    #endregion

    #region Properties

    public string Name
    {
        get => this.GetOwnAttribute(AttributeNames.Name);
        set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public IHtmlFormElement Form => GetAssignedForm();

    public bool IsDisabled
    {
        get => this.GetBoolAttribute(AttributeNames.Disabled) || IsFieldsetDisabled();
        set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public bool Autofocus
    {
        get => this.GetBoolAttribute(AttributeNames.AutoFocus);
        set => this.SetBoolAttribute(AttributeNames.AutoFocus, value);
    }

    public INodeList Labels => _labels;

    public string ValidationMessage => _vstate.IsCustomError ? _error : string.Empty;

    public bool WillValidate => !IsDisabled && CanBeValidated();

    public IValidityState Validity
    {
        get { Check(_vstate); return _vstate; }
    }

    #endregion

    #region Methods

    public override Node Clone(Document owner, bool deep)
    {
        var node = (HtmlFormControlElement)base.Clone(owner, deep);
        node.SetCustomValidity(_error);
        return node;
    }

    public bool CheckValidity()
    {
        return WillValidate && Validity.IsValid;
    }

    public void SetCustomValidity(string error)
    {
        _error = error;
        ResetValidity(_vstate);
    }

    #endregion

    #region Helpers

    protected virtual bool IsFieldsetDisabled()
    {
        var fieldSets = this.GetAncestors().OfType<IHtmlFieldSetElement>();

        foreach (var fieldSet in fieldSets)
        {
            if (fieldSet.IsDisabled)
            {
                var firstLegend = fieldSet.ChildNodes.FirstOrDefault(m => m is IHtmlLegendElement);
                return firstLegend == null || !this.IsDescendantOf(firstLegend);
            }
        }

        return false;
    }

    internal virtual void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    { }

    internal virtual void Reset()
    { }

    protected virtual void Check(ValidityState state)
    {
        ResetValidity(state);
    }

    protected void ResetValidity(ValidityState state)
    {
        state.IsCustomError = !string.IsNullOrEmpty(_error);
    }

    protected abstract bool CanBeValidated();

    #endregion
}
