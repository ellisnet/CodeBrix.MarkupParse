using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the base for a / area elements.
/// </summary>
abstract class HtmlUrlBaseElement : HtmlElement, IUrlUtilities
{
    #region Fields

    private TokenList _relList;
    private SettableTokenList _ping;

    #endregion

    #region ctor
    
    public HtmlUrlBaseElement(Document owner, string name, string prefix, NodeFlags flags)
        : base(owner, name, prefix, flags)
    {
    }

    #endregion

    #region Properties

    public string Download
    {
        get => this.GetOwnAttribute(AttributeNames.Download);
        set => this.SetOwnAttribute(AttributeNames.Download, value);
    }

    public string Href
    {
        get => this.GetUrlAttribute(AttributeNames.Href);
        set => SetAttribute(AttributeNames.Href, value);
    }

    public string Hash
    {
        get => GetLocationPart(m => m.Hash)!;
        set => SetLocationPart(m => m.Hash = value);
    }

    public string Host
    {
        get => GetLocationPart(m => m.Host)!;
        set => SetLocationPart(m => m.Host = value);
    }

    public string HostName
    {
        get => GetLocationPart(m => m.HostName)!;
        set => SetLocationPart(m => m.HostName = value);
    }

    public string PathName
    {
        get => GetLocationPart(m => m.PathName)!;
        set => SetLocationPart(m => m.PathName = value);
    }

    public string Port
    {
        get => GetLocationPart(m => m.Port)!;
        set => SetLocationPart(m => m.Port = value);
    }

    public string Protocol
    {
        get => GetLocationPart(m => m.Protocol)!;
        set => SetLocationPart(m => m.Protocol = value);
    }

    public string UserName
    {
        get => GetLocationPart(m => m.UserName);
        set => SetLocationPart(m => m.UserName = value);
    }

    public string Password
    {
        get => GetLocationPart(m => m.Password);
        set => SetLocationPart(m => m.Password = value);
    }

    public string Search
    {
        get => GetLocationPart(m => m.Search)!;
        set => SetLocationPart(m => m.Search = value);
    }

    public string Origin => GetLocationPart(m => m.Origin);

    public string TargetLanguage
    {
        get => this.GetOwnAttribute(AttributeNames.HrefLang);
        set => this.SetOwnAttribute(AttributeNames.HrefLang, value);
    }

    public string Media
    {
        get => this.GetOwnAttribute(AttributeNames.Media);
        set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Relation
    {
        get => this.GetOwnAttribute(AttributeNames.Rel);
        set => this.SetOwnAttribute(AttributeNames.Rel, value);
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

    public ISettableTokenList Ping
    {
        get
        {
            if (_ping is null)
            {
                _ping = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Ping));
                _ping.Changed += value => UpdateAttribute(AttributeNames.Ping, value);
            }

            return _ping;
        }
    }

    public string Target
    {
        get => this.GetOwnAttribute(AttributeNames.Target);
        set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    #endregion

    #region Methods

    public override async void DoClick()
    {
        var cancelled = await IsClickedCancelled().ConfigureAwait(false);

        if (!cancelled)
        {
            await this.NavigateAsync().ConfigureAwait(false);
        }
    }

    #endregion

    #region Internal Methods

    internal void UpdateRel(string value)
    {
        _relList?.Update(value);
    }

    internal void UpdatePing(string value)
    {
        _ping?.Update(value);
    }

    #endregion

    #region Helpers

    private string GetLocationPart(Func<ILocation, string> getter)
    {
        var href = this.GetOwnAttribute(AttributeNames.Href);
        var url = href != null ? new Url(BaseUrl!, href) : null;

        if (url != null && !url.IsInvalid)
        {
            var location = new Location(url);
            return getter.Invoke(location);
        }

        return string.Empty;
    }

    private void SetLocationPart(Action<ILocation> setter)
    {
        var href = this.GetOwnAttribute(AttributeNames.Href);
        var url = href != null ? new Url(BaseUrl!, href) : null;

        if (url is null || url.IsInvalid)
        {
            url = new Url(BaseUrl!);
        }

        var location = new Location(url);
        setter.Invoke(location);
        this.SetOwnAttribute(AttributeNames.Href, location.Href);
    }

    #endregion
}
