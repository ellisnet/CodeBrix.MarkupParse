using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents an Url class according to RFC3986. This is the base for all
/// internal Url manipulation.
/// Specification for the API used from https://url.spec.whatwg.org/#api.
/// </summary>
[DomName("URL")]
[DomExposed("Window")]
[DomExposed("Worker")]
public sealed class Url : IEquatable<Url>
{
    #region Fields

    private static readonly string CurrentDirectory = ".";
    private static readonly string CurrentDirectoryAlternative = "%2e";
    private static readonly string UpperDirectory = "..";
    private static readonly string[] UpperDirectoryAlternatives = new[] { "%2e%2e", ".%2e", "%2e." };
    private static readonly Url DefaultBase = new(string.Empty, string.Empty, string.Empty);
    private static readonly char[] C0ControlAndSpace = Enumerable.Range(0x00, 0x21).Select(c => (char)c).ToArray();

    // Remark: `UseStd3AsciiRules = false` is against spec
    // https://anglesharp.github.io/Specification-Url/#concept-domain-to-ascii
    // > UseSTD3ASCIIRules set to beStrict
    // But if UseStd3AsciiRules it set to true, _ (underscore) will be considered invalid in host name
    // Set to false here to do loose validation
    private static readonly IdnMapping DefaultIdnMapping = new () { AllowUnassigned = false, UseStd3AsciiRules = false };

    private string _fragment;
    private string _query;
    private string _path;
    private string _scheme;
    private string _port;
    private string _host;
    private string _username;
    private string _password;
    private bool _relative;
    private string _schemeData;
    private UrlSearchParams _params;
    private bool _error;

    #endregion

    #region ctor

    private Url(string scheme, string host, string port)
    {
        _schemeData = string.Empty;
        _path = string.Empty;
        _scheme = scheme;
        _host = host;
        _port = port;
        _relative = ProtocolNames.IsRelative(_scheme);
    }

    /// <summary>
    /// Creates a new Url from the given string.
    /// </summary>
    /// <param name="url">The address to represent.</param>
    /// <param name="baseAddress">The base address, if any.</param>
    [DomConstructor]
    public Url(string url, string baseAddress = null)
    {
        if (baseAddress is not null)
        {
            var baseUrl = new Url(baseAddress);
            _error = ParseUrl(url, baseUrl);
        }
        else
        {
            _error = ParseUrl(url);
        }
    }

    /// <summary>
    /// Creates a new Url from the given string.
    /// </summary>
    /// <param name="address">The address to represent.</param>
    public Url(string address)
    {
        _error = ParseUrl(address);
    }

    /// <summary>
    /// Creates a new absolute Url from the relative Url with the given
    /// base address.
    /// </summary>
    /// <param name="baseAddress">The base address to use.</param>
    /// <param name="relativeAddress">
    /// The relative address to represent.
    /// </param>
    public Url(Url baseAddress, string relativeAddress)
    {
        _error = ParseUrl(relativeAddress, baseAddress);
    }

    /// <summary>
    /// Creates a new Url by copying the other Url.
    /// </summary>
    /// <param name="address">The address to copy.</param>
    public Url(Url address)
    {
        _fragment = address._fragment;
        _query = address._query;
        _path = address._path;
        _scheme = address._scheme;
        _port = address._port;
        _host = address._host;
        _username = address._username;
        _password = address._password;
         _relative = address._relative;
        _schemeData = address._schemeData;;
    }

    #endregion

    #region Creators

    /// <summary>
    /// Creates an Url from an absolute url transported in a string.
    /// </summary>
    /// <param name="address">The address to use.</param>
    /// <returns>The new Url.</returns>
    public static Url Create(string address)
    {
        return new Url(address);
    }

    /// <summary>
    /// Creates an Url from an url transported in an Uri.
    /// </summary>
    /// <param name="uri">The url to use.</param>
    /// <returns>The new Url.</returns>
    public static Url Convert(Uri uri)
    {
        return new Url(uri.OriginalString);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the origin of the stored url.
    /// </summary>
    [DomName("origin")]
    public string Origin
    {
        get
        {
            if (_scheme.Is(ProtocolNames.Blob))
            {
                var url = new Url(_schemeData);

                if (!url.IsInvalid)
                {
                    return url.Origin;
                }
            }
            else if (ProtocolNames.IsOriginable(_scheme))
            {
                var output = StringBuilderPool.Obtain();

                if (!string.IsNullOrEmpty(_host))
                {
                    if (!string.IsNullOrEmpty(_scheme))
                    {
                        output.Append(_scheme).Append(Symbols.Colon);
                    }

                    output.Append(Symbols.Solidus).Append(Symbols.Solidus).Append(_host);

                    if (!string.IsNullOrEmpty(_port))
                    {
                        output.Append(Symbols.Colon).Append(_port);
                    }
                }

                return output.ToPool();
            }

            return null;
        }
    }

    /// <summary>
    /// Gets if the URL parsing resulted in an error.
    /// </summary>
    public bool IsInvalid => _error;

    /// <summary>
    /// Gets if the stored url is relative.
    /// </summary>
    public bool IsRelative => _relative && string.IsNullOrEmpty(_scheme);

    /// <summary>
    /// Gets if the stored url is absolute.
    /// </summary>
    public bool IsAbsolute => !IsRelative;

    /// <summary>
    /// Gets or sets the username for authorization.
    /// </summary>
    [DomName("username")]
    public string UserName
    {
        get => _username ?? string.Empty;
        set => _username = value;
    }

    /// <summary>
    /// Gets or sets the password for authorization.
    /// </summary>
    [DomName("password")]
    public string Password
    {
        get => _password ?? string.Empty;
        set => _password = value;
    }

    /// <summary>
    /// Gets the additional stored data of the URL. This is data that could
    /// not be assigned.
    /// </summary>
    public string Data => _schemeData;

    /// <summary>
    /// Gets or sets the fragment, e.g., "first-section".
    /// </summary>
    public string Fragment
    {
        get => _fragment;
        set
        {
            if (value is null)
            {
                _fragment = null;
            }
            else
            {
                ParseFragment(value, 0, value.Length);
            }
        }
    }

    /// <summary>
    /// Gets or sets the hash, e.g., "#first-section".
    /// </summary>
    [DomName("hash")]
    public string Hash
    {
        get => string.IsNullOrEmpty(_fragment) ? string.Empty : $"#{_fragment}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Fragment = null;
            }
            else if (value[0] is Symbols.Num)
            {
                Fragment = value.Substring(1);
            }
            else
            {
                Fragment = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the host, e.g. "localhost:8800" or "www.w3.org".
    /// </summary>
    [DomName("host")]
    public string Host
    {
        get => HostName + (string.IsNullOrEmpty(_port) ? string.Empty : ":" + _port);
        set
        {
            var input = value ?? string.Empty;
            ParseHostName(input, 0, input.Length, false, true);
        }
    }

    /// <summary>
    /// Gets or sets the host name, e.g. "localhost" or "www.w3.org".
    /// </summary>
    [DomName("hostname")]
    public string HostName
    {
        get => _host;
        set
        {
            var input = value ?? string.Empty;
            ParseHostName(input, 0, input.Length, true);
        }
    }

    /// <summary>
    /// Gets or sets the hyper reference, i.e. the full URL.
    /// </summary>
    [DomName("href")]
    public string Href
    {
        get => Serialize();
        set => _error = ParseUrl(value ?? string.Empty, this);
    }

    /// <summary>
    /// Gets or sets the path, e.g. "mypath".
    /// </summary>
    public string Path
    {
        get => _path;
        set
        {
            var input = value ?? string.Empty;
            ParsePath(input, 0, input.Length, true);
        }
    }

    /// <summary>
    /// Gets or sets the pathname, e.g. "/mypath".
    /// </summary>
    [DomName("pathname")]
    public string PathName
    {
        get => $"/{_path}";
        set => Path = value;
    }

    /// <summary>
    /// Gets or sets the port, e.g. "8800".
    /// </summary>
    [DomName("port")]
    public string Port
    {
        get => _port;
        set
        {
            var input = value ?? string.Empty;
            ParsePort(input, 0, input.Length, true);
        }
    }

    /// <summary>
    /// Gets or sets the scheme, e.g. "http".
    /// </summary>
    public string Scheme
    {
        get => _scheme;
        set
        {
            var input = value ?? string.Empty;
            ParseScheme(input, input.Length, true);
        }
    }

    /// <summary>
    /// Gets or sets the protocol, e.g. "http:".
    /// </summary>
    [DomName("protocol")]
    public string Protocol
    {
        get => $"{_scheme}:";
        set => Scheme = value;
    }

    /// <summary>
    /// Gets or sets the query part, e.g., "foo=bar".
    /// </summary>
    public string Query
    {
        get => _query;
        set
        {
            if(value == null)
            {
                _query = null;
                _params?.Reset();
            }
            else
            {
                ParseQuery(value, 0, value.Length, true, false);
            }
        }
    }

    /// <summary>
    /// Gets or sets the search part, e.g., "?foo=bar".
    /// </summary>
    [DomName("search")]
    public string Search
    {
        get => string.IsNullOrEmpty(_query) ? string.Empty : $"?{_query}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Query = null;
            }
            else if (value[0] is Symbols.QuestionMark)
            {
                Query = value.Substring(1);
            }
            else
            {
                Query = value;
            }
        }
    }

    /// <summary>
    /// Obtains an advanced view on the provided query parameter.
    /// </summary>
    [DomName("searchParams")]
    public UrlSearchParams SearchParams => _params ??= new UrlSearchParams(this);

    #endregion

    #region Equality

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current url.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode =  _fragment != null ? StringComparer.Ordinal.GetHashCode(_fragment) : 0;
            hashCode = (hashCode * 397) ^ (_query != null ? StringComparer.Ordinal.GetHashCode(_query) : 0);
            hashCode = (hashCode * 397) ^ (_path != null ? StringComparer.Ordinal.GetHashCode(_path) : 0);
            hashCode = (hashCode * 397) ^ (_scheme != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(_scheme) : 0);
            hashCode = (hashCode * 397) ^ (_port != null ? StringComparer.Ordinal.GetHashCode(_port) : 0);
            hashCode = (hashCode * 397) ^ (_host != null ?  StringComparer.OrdinalIgnoreCase.GetHashCode(_host) : 0);
            hashCode = (hashCode * 397) ^ (_username != null ? StringComparer.Ordinal.GetHashCode(_username) : 0);
            hashCode = (hashCode * 397) ^ (_password != null ? StringComparer.Ordinal.GetHashCode(_password) : 0);
            hashCode = (hashCode * 397) ^ (_schemeData != null ? StringComparer.Ordinal.GetHashCode(_schemeData) : 0);
            return hashCode;
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current
    /// object.
    /// </summary>
    /// <param name="obj">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// True if the object is equal to the current object, otherwise false.
    /// </returns>
    public override bool Equals(object obj)
    {
        return ReferenceEquals(this, obj) || obj is Url other && Equals(other);
    }

    /// <summary>
    /// Determines whether the specified url is equal to the current
    /// object.
    /// </summary>
    /// <param name="other">
    /// The url to compare with the current one.
    /// </param>
    /// <returns>
    /// True if the given url is equal to the current url, otherwise false.
    /// </returns>
    public bool Equals(Url other)
    {
        return other != null && _fragment.Is(other._fragment) && _query.Is(other._query) &&
               _path.Is(other._path) && _scheme.Isi(other._scheme) &&
               _port.Is(other._port) && _host.Isi(other._host) &&
               _username.Is(other._username) && _password.Is(other._password) &&
               _schemeData.Is(other._schemeData);
    }

    #endregion

    #region Conversion

    /// <summary>
    /// Converts the given Url to an Uri.
    /// </summary>
    /// <param name="value">The Url to convert.</param>
    /// <returns>The Uri instance.</returns>
    public static implicit operator Uri(Url value)
    {
        return new Uri(value.Serialize(), value.IsRelative ? UriKind.Relative : UriKind.Absolute);
    }

    #endregion

    #region Serialization

    /// <summary>
    /// Serializes the URL string to a JSON compatible string representation.
    /// </summary>
    /// <returns>The currently stored url.</returns>
    [DomName("toJSON")]
    public string ToJson() => Serialize();

    /// <summary>
    /// Returns a string that represents the current url.
    /// </summary>
    /// <returns>The currently stored url.</returns>
    public override string ToString() => Serialize();

    /// <summary>
    /// Returns the string representation of the current location.
    /// </summary>
    /// <returns>The string that equals the hyper reference.</returns>
    private string Serialize()
    {
        var output = StringBuilderPool.Obtain();

        if (!string.IsNullOrEmpty(_scheme))
        {
            output.Append(_scheme).Append(Symbols.Colon);
        }

        if (_relative)
        {
            if (!string.IsNullOrEmpty(_host) || !string.IsNullOrEmpty(_scheme))
            {
                output.Append(Symbols.Solidus).Append(Symbols.Solidus);

                if (!string.IsNullOrEmpty(_username) || _password != null)
                {
                    output.Append(_username);

                    if (_password != null)
                    {
                        output.Append(Symbols.Colon).Append(_password);
                    }

                    output.Append(Symbols.At);
                }

                output.Append(_host);

                if (!string.IsNullOrEmpty(_port))
                {
                    output.Append(Symbols.Colon).Append(_port);
                }

                output.Append(Symbols.Solidus);
            }

            output.Append(_path);
        }
        else
        {
            output.Append(_schemeData);
        }

        if (_query != null)
        {
            output.Append(Symbols.QuestionMark).Append(_query);
        }

        if (_fragment != null)
        {
            output.Append(Symbols.Num).Append(_fragment);
        }

        return output.ToPool();
    }

    #endregion

    #region Parsing

    private bool ParseUrl(string input, Url baseUrl = null)
    {
        Reset(baseUrl ?? DefaultBase);
        var normalizedInput = NormalizeInput(input);
        var length = normalizedInput.Length;
        return !ParseScheme(normalizedInput, length);
    }

    private void Reset(Url baseUrl)
    {
        _schemeData = string.Empty;
        _scheme = baseUrl._scheme;
        _host = baseUrl._host;
        _path = baseUrl._path;
        _query = baseUrl._query;
        _port = baseUrl._port;
        _relative = ProtocolNames.IsRelative(_scheme);
    }

    private bool ParseScheme(string input, int length, bool onlyScheme = false)
    {
        if (length > 0 && input[0].IsLetter())
        {
            var index = 1;

            while (index < length)
            {
                var c = input[index];

                if (c.IsAlphanumericAscii() || c == Symbols.Plus || c == Symbols.Minus || c == Symbols.Dot)
                {
                    index++;
                }
                else if (c == Symbols.Colon)
                {
                    var originalScheme = _scheme;
                    _scheme = input.Substring(0, index).ToLowerInvariant();

                    if (!onlyScheme)
                    {
                        _relative = ProtocolNames.IsRelative(_scheme);

                        if (_scheme.Is(ProtocolNames.File))
                        {
                            _host = string.Empty;
                            _port = string.Empty;
                            _query = null;
                            return RelativeState(input, index + 1, length);
                        }
                        else if (!_relative)
                        {
                            _host = string.Empty;
                            _port = string.Empty;
                            _path = string.Empty;
                            _query = null;
                            return ParseSchemeData(input, index + 1, length);
                        }
                        else if (_scheme.Is(originalScheme))
                        {
                            if (++index < length)
                            {
                                c = input[index];

                                if (c == Symbols.Solidus && index + 2 < length && input[index + 1] == Symbols.Solidus)
                                {
                                    return IgnoreSlashesState(input, index + 2, length);
                                }

                                return RelativeState(input, index, length);
                            }

                            return false;
                        }
                        else if (index + 1 < length && input[++index] == Symbols.Solidus && ++index < length && input[index] == Symbols.Solidus)
                        {
                            index++;
                        }

                        return IgnoreSlashesState(input, index, length);
                    }

                    return true;
                }
                else
                {
                    break;
                }
            }
        }

        return !onlyScheme && RelativeState(input, 0, length);
    }

    private bool ParseSchemeData(string input, int index, int length)
    {
        var buffer = StringBuilderPool.Obtain();

        while (index < length)
        {
            var c = input[index];

            if (c == Symbols.QuestionMark)
            {
                _schemeData = buffer.ToPool();
                return ParseQuery(input, index + 1, length);
            }
            else if (c == Symbols.Num)
            {
                _schemeData = buffer.ToPool();
                return ParseFragment(input, index + 1, length);
            }
            else if (c == Symbols.Percent && index + 2 < length && input[index + 1].IsHex() && input[index + 2].IsHex())
            {
                buffer.Append(input[index++]);
                buffer.Append(input[index++]);
                buffer.Append(input[index]);
            }
            else if (c.IsInRange(0x20, 0x7e))
            {
                buffer.Append(c);
            }

            index++;
        }

        _schemeData = buffer.ToPool();
        return true;
    }

    private bool RelativeState(string input, int index, int length)
    {
        _relative = true;

        if (index != length)
        {
            switch (input[index])
            {
                case Symbols.QuestionMark:
                    return ParseQuery(input, index + 1, length);

                case Symbols.Num:
                    return ParseFragment(input, index + 1, length);

                case Symbols.Solidus:
                case Symbols.ReverseSolidus:
                    if (index != length - 1)
                    {
                        var c = input[++index];

                        if (c is Symbols.Solidus or Symbols.ReverseSolidus)
                        {
                            if (_scheme.Is(ProtocolNames.File))
                            {
                                return ParseFileHost(input, index + 1, length);
                            }

                            return IgnoreSlashesState(input, index + 1, length);
                        }
                        else if (_scheme.Is(ProtocolNames.File))
                        {
                            _host = string.Empty;
                            _port = string.Empty;
                        }

                        return ParsePath(input, index - 1, length);
                    }

                    return ParsePath(input, index, length);
            }

            if (input[index].IsLetter() && _scheme.Is(ProtocolNames.File) && index + 1 < length &&
               (input[index + 1] is Symbols.Colon or Symbols.Solidus) &&
               (index + 2 == length || input[index + 2] is Symbols.Solidus or Symbols.ReverseSolidus or Symbols.Num or Symbols.QuestionMark))
            {
                _host = string.Empty;
                _path = string.Empty;
                _port = string.Empty;
            }

            return ParsePath(input, index, length);
        }

        return true;
    }

    private bool IgnoreSlashesState(string input, int index, int length)
    {
        while (index < length)
        {
            if (!(input[index] is Symbols.ReverseSolidus or Symbols.Solidus))
            {
                return ParseAuthority(input, index, length);
            }

            index++;
        }

        return false;
    }

    private bool ParseAuthority(string input, int index, int length)
    {
        var start = index;
        var buffer = StringBuilderPool.Obtain();
        var user = default(string);
        var pass = default(string);

        while (index < length)
        {
            var c = input[index];

            if (c == Symbols.At)
            {
                if (user is null)
                {
                    user = buffer.ToString();
                }
                else
                {
                    pass = buffer.ToString();
                }

                _username = user;
                _password = pass;
                buffer.Append("%40");
                start = index + 1;
            }
            else if (c == Symbols.Colon && user is null)
            {
                user = buffer.ToString();
                pass = string.Empty;
                buffer.Clear();
            }
            else if (c == Symbols.Percent && index + 2 < length && input[index + 1].IsHex() && input[index + 2].IsHex())
            {
                buffer.Append(input[index++]).Append(input[index++]).Append(input[index]);
            }
            else if (c is Symbols.Solidus or Symbols.ReverseSolidus or Symbols.Num or Symbols.QuestionMark)
            {
                break;
            }
            else if (c != Symbols.Colon && (c == Symbols.Num || c == Symbols.QuestionMark || c.IsNormalPathCharacter()))
            {
                buffer.Append(c);
            }
            else
            {
                index += Utf8PercentEncode(buffer, input, index);
            }

            index++;
        }

        buffer.ReturnToPool();
        return ParseHostName(input, start, length);
    }

    private bool ParseFileHost(string input, int index, int length)
    {
        var start = index;
        _path = string.Empty;

        while (index < length)
        {
            var c = input[index];

            if (c is Symbols.Solidus or Symbols.ReverseSolidus or Symbols.Num or Symbols.QuestionMark)
            {
                break;
            }

            index++;
        }

        var span = index - start;

        if (span == 2 && input[start].IsLetter() && input[start + 1] is Symbols.Pipe or Symbols.Colon)
        {
            return ParsePath(input, index - 2, length);
        }
        else if (span != 0)
        {
            if (!TrySanatizeHost(input, start, span, out _host))
            {
                return false;
            }
        }

        return ParsePath(input, index, length);
    }

    private bool ParseHostName(string input, int index, int length, bool onlyHost = false, bool onlyPort = false)
    {
        var inBracket = false;
        var start = index;

        while (index < length)
        {
            var c = input[index];

            switch (c)
            {
                case Symbols.SquareBracketClose:
                    inBracket = false;
                    break;

                case Symbols.SquareBracketOpen:
                    inBracket = true;
                    break;

                case Symbols.Colon:
                    if (inBracket)
                    {
                        break;
                    }

                    if (!TrySanatizeHost(input, start, index - start, out _host))
                    {
                        return false;
                    }

                    if (!onlyHost)
                    {
                        return ParsePort(input, index + 1, length, onlyPort);
                    }

                    return true;

                case Symbols.Solidus:
                case Symbols.ReverseSolidus:
                case Symbols.Num:
                case Symbols.QuestionMark:
                    if (!TrySanatizeHost(input, start, index - start, out _host))
                    {
                        return false;
                    }

                    var error = string.IsNullOrEmpty(_host);

                    if (!onlyHost)
                    {
                        _port = string.Empty;
                        return ParsePath(input, index, length) && !error;
                    }

                    return !error;
            }

            index++;
        }

        if (!TrySanatizeHost(input, start, index - start, out _host))
        {
            return false;
        }

        if (!onlyHost)
        {
            _path = string.Empty;
            _port = string.Empty;
            _query = null;
            _fragment = null;
            _params?.Reset();
        }

        return true;
    }

    private bool ParsePort(string input, int index, int length, bool onlyPort = false)
    {
        var start = index;

        while (index < length)
        {
            var c = input[index];

            if (c == Symbols.QuestionMark || c == Symbols.Solidus || c == Symbols.ReverseSolidus || c == Symbols.Num)
            {
                break;
            }
            else if (c.IsDigit())
            {
                index++;
            }
            else
            {
                return false;
            }
        }

        _port = SanatizePort(input, start, index - start);

        if (PortNumbers.GetDefaultPort(_scheme) == _port)
        {
            _port = string.Empty;
        }

        if (!onlyPort)
        {
            _path = string.Empty;
            return ParsePath(input, index, length);
        }

        return true;
    }

    private bool ParsePath(string input, int index, int length, bool onlyPath = false)
    {
        var init = index;

        if (index < length && (input[index] == Symbols.Solidus || input[index] == Symbols.ReverseSolidus))
        {
            index++;
        }

        var paths = new List<string>();

        if (!onlyPath && !string.IsNullOrEmpty(_path) && index - init == 0)
        {
            var split = _path.Split(Symbols.Solidus);

            if (split.Length > 1)
            {
                paths.AddRange(split);
                paths.RemoveAt(split.Length - 1);
            }
        }

        var originalCount = paths.Count;
        var buffer = StringBuilderPool.Obtain();

        while (index <= length)
        {
            var c = index == length ? Symbols.EndOfFile : input[index];
            var breakNow = !onlyPath && (c == Symbols.Num || c == Symbols.QuestionMark);

            if (c == Symbols.EndOfFile || c == Symbols.Solidus || c == Symbols.ReverseSolidus || breakNow)
            {
                var path = buffer.ToString();
                var close = false;
                buffer.Clear();

                if (path.Isi(CurrentDirectoryAlternative))
                {
                    path = CurrentDirectory;
                }
                else if (path.Isi(UpperDirectoryAlternatives[0]) ||
                         path.Isi(UpperDirectoryAlternatives[1]) ||
                         path.Isi(UpperDirectoryAlternatives[2]))
                {
                    path = UpperDirectory;
                }

                if (path.Is(UpperDirectory))
                {
                    if (paths.Count > 0)
                    {
                        paths.RemoveAt(paths.Count - 1);
                    }

                    close = true;
                }
                else if (!path.Is(CurrentDirectory))
                {
                    if (_scheme.Is(ProtocolNames.File) &&
                        paths.Count == originalCount &&
                        path.Length == 2 &&
                        path[0].IsLetter() &&
                        path[1] == Symbols.Pipe)
                    {
                        path = path.Replace(Symbols.Pipe, Symbols.Colon);
                        paths.Clear();
                    }

                    paths.Add(path);
                }
                else
                {
                    close = true;
                }

                if (close && c != Symbols.Solidus && c != Symbols.ReverseSolidus)
                {
                    paths.Add(string.Empty);
                }

                if (breakNow)
                {
                    break;
                }
            }
            else if (c == Symbols.Percent &&
                     index + 2 < length &&
                     input[index + 1].IsHex() &&
                     input[index + 2].IsHex())
            {
                buffer.Append(input[index++]);
                buffer.Append(input[index++]);
                buffer.Append(input[index]);
            }
            else if (c.IsNormalPathCharacter())
            {
                buffer.Append(c);
            }
            else
            {
                index += Utf8PercentEncode(buffer, input, index);
            }

            index++;
        }

        buffer.ReturnToPool();
        _path = string.Join("/", paths);
        _query = null;

        if (index < length)
        {
            if (input[index] == Symbols.QuestionMark)
            {
                return ParseQuery(input, index + 1, length);
            }

            return ParseFragment(input, index + 1, length);
        }

        return true;
    }

    internal bool ParseQuery(string input, int index, int length, bool onlyQuery = false, bool fromParams = false)
    {
        var buffer = StringBuilderPool.Obtain();
        var fragment = false;

        while (index < length)
        {
            var c = input[index];
            fragment = !onlyQuery && input[index] == Symbols.Num;

            if (fragment)
            {
                break;
            }

            if (c.IsNormalQueryCharacter())
            {
                buffer.Append(c);
            }
            else
            {
                index += Utf8PercentEncode(buffer, input, index);
            }

            index++;
        }

        _query = buffer.ToPool();

        if (!fromParams)
        {
            _params?.ChangeTo(_query, true);
        }

        return fragment ? ParseFragment(input, index + 1, length) : true;
    }

    private bool ParseFragment(string input, int index, int length)
    {
        var buffer = StringBuilderPool.Obtain();

        while (index < length)
        {
            var c = input[index];

            switch (c)
            {
                case Symbols.EndOfFile:
                case Symbols.Null:
                    break;
                default:
                    buffer.Append(c);
                    break;
            }

            index++;
        }

        _fragment = buffer.ToPool();
        return true;
    }

    #endregion

    #region Helpers

    private static string NormalizeInput(string input)
    {
        var trimmedInput = input.Trim(C0ControlAndSpace);
        var buffer = StringBuilderPool.Obtain();
        foreach (var c in trimmedInput)
        {
            switch (c)
            {
                case Symbols.Tab:
                case Symbols.LineFeed:
                case Symbols.CarriageReturn:
                    // parse error
                    break;
                default:
                    buffer.Append(c);
                    break;
            }
        }
        return buffer.ToPool();
    }

    private static string Utf8PercentDecode(string source)
    {
        // https://anglesharp.github.io/Specification-Url/#string-percent-decode
        // 1. Let bytes be the UTF-8 encoding of input.
        var bytes = TextEncoding.Utf8.GetBytes(source);
        var length = bytes.Length;

        // 2. Return the percent decoding of bytes.
        // in-place
        for (int i = 0, insertIndex = 0; i < bytes.Length; i++, insertIndex++)
        {
            var cc = (char)bytes[i];
            switch (cc)
            {
                case Symbols.Percent:
                    if (i + 2 < bytes.Length && ((char)bytes[i + 1]).IsHex() && ((char)bytes[i + 2]).IsHex())
                    {
                        var weight = ((char)bytes[i + 1]).FromHex() * 16 + ((char)bytes[i + 2]).FromHex();
                        cc = (char)weight;
                        i += 2;
                        length -= 2;
                    }

                    goto default;
                default:
                    bytes[insertIndex] = (byte)cc;
                    break;
            }
        }

        return TextEncoding.Utf8.GetString(bytes, 0, length);
    }

    private static int Utf8PercentEncode(StringBuilder buffer, string source, int index)
    {
        var length = char.IsSurrogatePair(source, index) ? 2 : 1;
        var bytes = TextEncoding.Utf8.GetBytes(source.Substring(index, length));

        for (var i = 0; i < bytes.Length; i++)
        {
            buffer.Append(Symbols.Percent).Append(bytes[i].ToString("X2"));
        }

        return length - 1;
    }

    private static bool TrySanatizeHost(string hostName, int start, int length, out string sanatizedHostName)
    {
        if (length == 0)
        {
            sanatizedHostName = string.Empty;
            return true;
        }

        // TODO: IPv6 Parsing
        if (length > 1 && hostName[start] == Symbols.SquareBracketOpen && hostName[start + length - 1] == Symbols.SquareBracketClose)
        {
            sanatizedHostName = hostName.Substring(start, length);
            return true;
        }

        // https://anglesharp.github.io/Specification-Url/#host-parsing 3.5.4
        // string utf 8 percent decoding of input.
        var percentDecoded = Utf8PercentDecode(hostName.Substring(start, length));

        // https://anglesharp.github.io/Specification-Url/#host-parsing 3.5.5
        // domain to ASCII
        string domainToAscii;

        try
        {
            domainToAscii = DefaultIdnMapping.GetAscii(percentDecoded);
        }
        catch (ArgumentException)
        {
            sanatizedHostName = hostName.Substring(start, length);
            return false;
        }

        var buffer = StringBuilderPool.Obtain();

        // https://anglesharp.github.io/Specification-Url/#host-parsing 3.5.7
        // forbidden host code point check
        foreach (var cc in domainToAscii)
        {
            switch (cc)
            {
                // U+0000, U+0009, U+000A, U+000D, U+0020, "#", "%", "/", ":", "?", "@", "[", "\", and "]"'
                case Symbols.Null:
                case Symbols.Tab:
                case Symbols.Space:
                case Symbols.LineFeed:
                case Symbols.CarriageReturn:
                case Symbols.Num:
                case Symbols.Percent:
                case Symbols.Solidus:
                case Symbols.Colon:
                case Symbols.QuestionMark:
                case Symbols.At:
                case Symbols.SquareBracketOpen:
                case Symbols.SquareBracketClose:
                case Symbols.ReverseSolidus:
                    buffer.ReturnToPool();
                    sanatizedHostName = hostName.Substring(start, length);
                    return false;
                default:
                    buffer.Append(char.ToLowerInvariant(cc));
                    break;
            }
        }

        sanatizedHostName = buffer.ToPool();

        // TODO: IPv4 parsing
        return true;
    }

    private static string SanatizePort(string port, int start, int length)
    {
        if (length < 128)
        {
            return Go(stackalloc char[length]);
        }
        else
        {
            return Go(new char[length]);
        }

        string Go(Span<char> chars)
        {
            var count = 0;
            var n = start + length;
            for (var i = start; i < n; i++)
            {
                if (count == 1 && chars[0] == '0')
                {
                    chars[0] = port[i];
                }
                else
                {
                    chars[count++] = port[i];
                }
            }
            return chars.Slice(0, count).ToString();
        }
    }
#endregion
}
