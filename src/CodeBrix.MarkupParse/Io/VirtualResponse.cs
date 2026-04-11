using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// The virtual response class.
/// </summary>
public class VirtualResponse : IResponse
{
    #region Fields

    private Url _address;
    private HttpStatusCode _status;
    private Dictionary<string, string> _headers;
    private Stream _content;
    private bool _dispose;

    #endregion

    #region ctor

    private VirtualResponse()
    {
        _address = Url.Create("http://localhost/");
        _status = HttpStatusCode.OK;
        _headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        _content = MemoryStream.Null;
        _dispose = false;
    }

    /// <summary>
    /// Creates a new virtual response.
    /// </summary>
    /// <param name="request">The request callback.</param>
    /// <returns>The resulted response.</returns>
    public static IResponse Create(Action<VirtualResponse> request)
    {
        var vr = new VirtualResponse();
        request.Invoke(vr);
        return vr;
    }

    #endregion

    #region Properties

    Url IResponse.Address => _address;

    Stream IResponse.Content => _content;

    IDictionary<string, string> IResponse.Headers => _headers;

    HttpStatusCode IResponse.StatusCode => _status;

    #endregion

    #region Methods

    /// <summary>
    /// Sets the location of the response to the given url.
    /// </summary>
    /// <param name="url">The imaginary url of the response.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Address(Url url)
    {
        _address = url;
        return this;
    }

    /// <summary>
    /// Sets the location of the response to the provided address.
    /// </summary>
    /// <param name="address">The string to use as an url.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Address(string address)
    {
        return Address(Url.Create(address ?? string.Empty));
    }

    /// <summary>
    /// Sets the location of the response to the uri's value.
    /// </summary>
    /// <param name="url">The Uri instance to convert.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Address(Uri url)
    {
        return Address(Url.Convert(url));
    }

    /// <summary>
    /// Sets the value of the cookie associated with the response.
    /// </summary>
    /// <param name="value">The cookie's value.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Cookie(string value)
    {
        return Header(HeaderNames.SetCookie, value);
    }

    /// <summary>
    /// Sets the status code.
    /// </summary>
    /// <param name="code">The status code to set.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Status(HttpStatusCode code)
    {
        _status = code;
        return this;
    }

    /// <summary>
    /// Sets the status code by providing the integer value.
    /// </summary>
    /// <param name="code">The integer representing the code.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Status(int code)
    {
        return Status((HttpStatusCode)code);
    }

    /// <summary>
    /// Sets the header with the given name and value.
    /// </summary>
    /// <param name="name">The header name to set.</param>
    /// <param name="value">The value for the key.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Header(string name, string value)
    {
        _headers[name] = value;
        return this;
    }

    /// <summary>
    /// Sets the headers with the name of the properties and their 
    /// assigned values.
    /// </summary>
    /// <param name="obj">The object to decompose.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Headers(object obj)
    {
        var headers = obj.ToDictionary();
        return Headers(headers);
    }

    /// <summary>
    /// Sets the headers with the name of the keys and their assigned
    /// values.
    /// </summary>
    /// <param name="headers">The dictionary to use.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Headers(IDictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            Header(header.Key, header.Value);
        }

        return this;
    }

    /// <summary>
    /// Sets the response's content from the provided string.
    /// </summary>
    /// <param name="text">The text to use as content.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Content(string text)
    {
        Release();
        var raw = TextEncoding.Utf8.GetBytes(text);
        _content = new MemoryStream(raw);
        _dispose = true;
        return this;
    }

    /// <summary>
    /// Sets the response's content from the provided stream.
    /// </summary>
    /// <param name="stream">The response's content stream.</param>
    /// <param name="shouldDispose">True to dispose afterwards.</param>
    /// <returns>The current instance.</returns>
    public VirtualResponse Content(Stream stream, bool shouldDispose = false)
    {
        Release();
        _content = stream;
        _dispose = shouldDispose;
        return this;
    }

    #endregion

    #region Helpers

    private void Release()
    {
        if (_dispose)
        {
            _content?.Dispose();
        }

        _dispose = false;
        _content = null;
    }

    void IDisposable.Dispose()
    {
        Release();
    }

    #endregion
}
