using CodeBrix.MarkupParse.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A location object with information about a Url.
/// </summary>
sealed class Location : ILocation
{
    #region Fields

    private readonly Url _url;

    #endregion

    #region Events

    public event EventHandler<ChangedEventArgs> Changed;

    #endregion

    #region ctor

    internal Location(string url)
        : this(new Url(url))
    {
    }

    internal Location(Url url)
    {
        _url = url ?? new Url(string.Empty);
    }

    #endregion

    #region Properties

    public Url Original => _url;

    public string Origin => _url.Origin;

    public bool IsRelative => _url.IsRelative;

    public string UserName
    {
        get => _url.UserName;
        set => _url.UserName = value;
    }

    public string Password
    {
        get => _url.Password;
        set => _url.Password = value;
    }

    [AllowNull]
    public string Hash
    {
        get => NonEmptyPrefix(_url.Fragment, "#");
        set
        {
            var old = _url.Href;

            if (value != null)
            {
                if (value.Has(Symbols.Num))
                {
                    value = value.Substring(1);
                }
                else if (value.Length == 0)
                {
                    value = null!;
                }
            }

            if (!value.Is(_url.Fragment))
            {
                _url.Fragment = value;
                RaiseHashChanged(old);
            }
        }
    }

    public string Host
    {
        get => _url.Host;
        set
        {
            var old = _url.Href;

            if (!value.Isi(_url.Host))
            {
                _url.Host = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string HostName
    {
        get => _url.HostName;
        set
        {
            var old = _url.Href;

            if (!value.Isi(_url.HostName))
            {
                _url.HostName = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string Href
    {
        get => _url.Href;
        set
        {
            var old = _url.Href;

            if (!value.Is(_url.Href))
            {
                _url.Href = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string PathName
    {
        get
        {
            var data = _url.Data;
            return string.IsNullOrEmpty(data) ? "/" + _url.Path : data;
        }
        set
        {
            var old = _url.Href;

            if (!value.Is(_url.Path))
            {
                _url.Path = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string Port
    {
        get => _url.Port;
        set
        {
            var old = _url.Href;

            if (!value.Isi(_url.Port))
            {
                _url.Port = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string Protocol
    {
        get => NonEmptyPostfix(_url.Scheme, ":");
        set
        {
            var old = _url.Href;

            if (!value.Isi(_url.Scheme))
            {
                _url.Scheme = value;
                RaiseLocationChanged(old);
            }
        }
    }

    public string Search
    {
        get => NonEmptyPrefix(_url.Query, "?");
        set
        {
            var old = _url.Href;

            if (!value.Is(_url.Query))
            {
                _url.Query = value;
                RaiseLocationChanged(old);
            }
        }
    }

    #endregion

    #region Methods

    public void Assign(string url)
    {
        var old = _url.Href;

        if (!old.Is(url))
        {
            _url.Href = url;
            RaiseLocationChanged(old);
        }
    }

    public void Replace(string url)
    {
        var old = _url.Href;

        if (!old.Is(url))
        {
            _url.Href = url;
            RaiseLocationChanged(old);
        }
    }

    public void Reload() => Changed?.Invoke(this, new ChangedEventArgs(false, _url.Href, _url.Href));

    public override string ToString() => _url.Href;

    #endregion

    #region Helpers

    private void RaiseHashChanged(string oldAddress) =>
        Changed?.Invoke(this, new ChangedEventArgs(true, oldAddress, _url.Href));

    private void RaiseLocationChanged(string oldAddress) =>
        Changed?.Invoke(this, new ChangedEventArgs(false, oldAddress, _url.Href));

    private static string NonEmptyPrefix(string check, string prefix) =>
        string.IsNullOrEmpty(check) ? string.Empty : string.Concat(prefix, check);

    private static string NonEmptyPostfix(string check, string postfix) =>
        string.IsNullOrEmpty(check) ? string.Empty : string.Concat(check, postfix);

    #endregion

    #region Event Arguments

    public sealed class ChangedEventArgs : EventArgs
    {
        public ChangedEventArgs(bool hashChanged, string previousLocation, string currentLocation)
        {
            IsHashChanged = hashChanged;
            PreviousLocation = previousLocation;
            CurrentLocation = currentLocation;
        }

        public bool IsReloaded => PreviousLocation.Is(CurrentLocation);

        public bool IsHashChanged { get; }

        public string PreviousLocation { get; }

        public string CurrentLocation { get; }
    }

    #endregion
}
