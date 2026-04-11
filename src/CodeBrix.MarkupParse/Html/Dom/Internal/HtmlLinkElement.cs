using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.LinkRels;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML link element.
/// </summary>
sealed class HtmlLinkElement : HtmlElement, IHtmlLinkElement
{
    #region Fields

    private BaseLinkRelation _relation;
    private TokenList _relList;
    private SettableTokenList _sizes;

    private string _source;
    private bool _relationLoaded;

    #endregion

    #region ctor

    public HtmlLinkElement(Document owner, string prefix = null)
        : base(owner, TagNames.Link, prefix, NodeFlags.Special | NodeFlags.SelfClosing)
    {
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

    #region Properties

    public IDownload CurrentDownload => _relation?.Processor?.Download;

    public string Href
    {
        get => this.GetUrlAttribute(AttributeNames.Href);
        set => this.SetOwnAttribute(AttributeNames.Href, value);
    }

    public string TargetLanguage
    {
        get => this.GetOwnAttribute(AttributeNames.HrefLang);
        set => this.SetOwnAttribute(AttributeNames.HrefLang, value);
    }

    public string Charset
    {
        get => this.GetOwnAttribute(AttributeNames.Charset);
        set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string Relation
    {
        get => this.GetOwnAttribute(AttributeNames.Rel);
        set => this.SetOwnAttribute(AttributeNames.Rel, value);
    }

    public string ReverseRelation
    {
        get => this.GetOwnAttribute(AttributeNames.Rev);
        set => this.SetOwnAttribute(AttributeNames.Rev, value);
    }

    public string NumberUsedOnce
    {
        get => this.GetOwnAttribute(AttributeNames.Nonce);
        set => this.SetOwnAttribute(AttributeNames.Nonce, value);
    }

    public ITokenList RelationList
    {
        get
        {
            if (_relList is null)
            {
                _relList = new TokenList(this.GetOwnAttribute(AttributeNames.Rel));
                _relList.Changed += value => UpdateAttribute(AttributeNames.Rel, value);
            }

            return _relList;
        }
    }

    public ISettableTokenList Sizes
    {
        get
        {
            if (_sizes is null)
            {
                _sizes = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Sizes));
                _sizes.Changed += value => UpdateAttribute(AttributeNames.Sizes, value);
            }

            return _sizes;
        }
    }

    public string Rev
    {
        get => this.GetOwnAttribute(AttributeNames.Rev);
        set => this.SetOwnAttribute(AttributeNames.Rev, value);
    }

    public bool IsDisabled
    {
        get => this.GetBoolAttribute(AttributeNames.Disabled);
        set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public string Target
    {
        get => this.GetOwnAttribute(AttributeNames.Target);
        set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    public string Media
    {
        get => this.GetOwnAttribute(AttributeNames.Media);
        set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string Integrity
    {
        get => this.GetOwnAttribute(AttributeNames.Integrity);
        set => this.SetOwnAttribute(AttributeNames.Integrity, value);
    }

    public IStyleSheet Sheet
    {
        get
        {
            var sheetRelation = _relation as StyleSheetLinkRelation;
            return sheetRelation?.Sheet;
        }
    }

    public IDocument Import
    {
        get
        {
            var importRelation = _relation as ImportLinkRelation;
            return importRelation?.Import;
        }
    }

    public string CrossOrigin
    {
        get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
        set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    #endregion

    #region Internal Methods

    internal void UpdateRel(string value)
    {
        _relList?.Update(value);
        _relation = CreateFirstLegalRelation();

        LoadRelation();
    }

    internal void UpdateSizes(string value)
    {
        _sizes?.Update(value);
    }

    internal void UpdateMedia(string value)
    {
        var sheet = Sheet;

        if (sheet != null)
        {
            sheet.Media.MediaText = value;
        }
    }

    internal void UpdateDisabled(string value)
    {
        var sheet = Sheet;

        if (sheet != null)
        {
            sheet.IsDisabled = value != null;
        }
    }

    internal void UpdateSource(string value)
    {
        if (!value.Isi(_source))
        {
            _source = value;
            _relationLoaded = false;
        }
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        LoadRelation();
    }

    internal void LoadRelation()
    {
        if (_relationLoaded || _relation == null || Href == null)
        {
            return;
        }

        _relationLoaded = true;

        var task = _relation.LoadAsync();
        Owner?.DelayLoad(task);
    }

    #endregion

    #region Helpers

    private BaseLinkRelation CreateFirstLegalRelation()
    {
        var relations = RelationList;
        var factory = Context?.GetFactory<ILinkRelationFactory>();

        foreach (var relation in relations)
        {
            var rel = factory?.Create(this, relation);

            if (rel != null)
            {
                return rel;
            }
        }

        return null;
    }

    #endregion
}
