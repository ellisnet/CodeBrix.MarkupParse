using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// The default (ready-to-use) HTTP requester.
/// </summary>
public sealed class DefaultHttpRequester : BaseRequester
{
    #region Constants

    private static readonly string Version = typeof(DefaultHttpRequester).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
    private static readonly string AgentName = "CodeBrix.MarkupParse/" + Version;

    #endregion

    #region Fields

    private TimeSpan _timeOut;
    private readonly Action<HttpClientHandler> _setup;
    private readonly Dictionary<string, string> _headers;

    #endregion

    #region ctor

    /// <summary>
    /// Constructs a default HTTP requester with the information presented
    /// in the info object.
    /// </summary>
    /// <param name="userAgent">The user-agent name to use, if any.</param>
    /// <param name="setup">An optional setup function for the HttpClientHandler object.</param>
    public DefaultHttpRequester(string userAgent = null, Action<HttpClientHandler> setup = null)
    {
        _timeOut = new TimeSpan(0, 0, 0, 45);
        _setup = setup ?? (_ => { });
        _headers = new Dictionary<string, string>
        {
            { HeaderNames.UserAgent, userAgent ?? AgentName },
            { HeaderNames.AcceptEncoding, "gzip, deflate" }
        };
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the used headers.
    /// </summary>
    public IDictionary<string, string> Headers => _headers;

    /// <summary>
    /// Gets or sets the timeout value.
    /// </summary>
    public TimeSpan Timeout
    {
        get => _timeOut;
        set => _timeOut = value;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Checks if the given protocol is supported.
    /// </summary>
    /// <param name="protocol">
    /// The protocol to check for, e.g. http.
    /// </param>
    /// <returns>
    /// True if the protocol is supported, otherwise false.
    /// </returns>
    public override bool SupportsProtocol(string protocol) =>
        protocol.IsOneOf(ProtocolNames.Http, ProtocolNames.Https);

    /// <summary>
    /// Performs an asynchronous http request that can be cancelled.
    /// </summary>
    /// <param name="request">The options to consider.</param>
    /// <param name="cancellationToken">
    /// The token for cancelling the task.
    /// </param>
    /// <returns>
    /// The task that will eventually give the response data.
    /// </returns>
    protected override async Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancellationToken)
    {
        var cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            CookieContainer = cookieContainer
        };

        _setup(handler);

        var cookieHeader = request.Headers.GetOrDefault(HeaderNames.Cookie, string.Empty);

        if (!string.IsNullOrEmpty(cookieHeader))
        {
            cookieContainer.SetCookies((Uri)request.Address, cookieHeader.Replace(';', ',').Replace("$", ""));
        }

        var originalCookies = cookieContainer.GetCookies((Uri)request.Address);

        var client = new HttpClient(handler) { Timeout = _timeOut };
        var httpRequest = new HttpRequestMessage(MapHttpMethod(request.Method), (Uri)request.Address);

        SetRequestHeaders(httpRequest, request);

        if (request.Method is HttpMethod.Post or HttpMethod.Put && request.Content is not null)
        {
            httpRequest.Content = new StreamContent(request.Content);

            if (request.Headers.TryGetValue(HeaderNames.ContentType, out var contentType))
            {
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
            }
        }

        HttpResponseMessage response;

        try
        {
            response = await client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        }
        catch (HttpRequestException)
        {
            httpRequest.Dispose();
            client.Dispose();
            return null;
        }
        catch (TaskCanceledException)
        {
            httpRequest.Dispose();
            client.Dispose();
            return null;
        }

        return await BuildResponseAsync(response, request, cookieContainer, originalCookies, httpRequest, client).ConfigureAwait(false);
    }

    #endregion

    #region Helpers

    private static System.Net.Http.HttpMethod MapHttpMethod(HttpMethod method) => method switch
    {
        HttpMethod.Get => System.Net.Http.HttpMethod.Get,
        HttpMethod.Post => System.Net.Http.HttpMethod.Post,
        HttpMethod.Put => System.Net.Http.HttpMethod.Put,
        HttpMethod.Delete => System.Net.Http.HttpMethod.Delete,
        HttpMethod.Options => System.Net.Http.HttpMethod.Options,
        HttpMethod.Head => System.Net.Http.HttpMethod.Head,
        HttpMethod.Trace => System.Net.Http.HttpMethod.Trace,
        HttpMethod.Connect => System.Net.Http.HttpMethod.Connect,
        _ => new System.Net.Http.HttpMethod(method.ToString().ToUpperInvariant())
    };

    private void SetRequestHeaders(HttpRequestMessage httpRequest, Request request)
    {
        foreach (var header in _headers)
        {
            if (!header.Key.Is(HeaderNames.Cookie))
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        foreach (var header in request.Headers)
        {
            if (!header.Key.Is(HeaderNames.Cookie))
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
    }

    private static async Task<DefaultResponse> BuildResponseAsync(
        HttpResponseMessage response,
        Request request,
        CookieContainer cookieContainer,
        CookieCollection originalCookies,
        HttpRequestMessage httpRequest,
        HttpClient client)
    {
        var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var content = new OwningStream(contentStream, response, httpRequest, client);

        var responseUri = response.RequestMessage?.RequestUri ?? (Uri)request.Address;
        var result = new DefaultResponse
        {
            Content = content,
            StatusCode = response.StatusCode,
            Address = Url.Convert(responseUri)
        };

        foreach (var header in response.Headers)
        {
            result.Headers[header.Key] = string.Join(", ", header.Value);
        }

        foreach (var header in response.Content.Headers)
        {
            var value = string.Join(", ", header.Value);
            result.Headers[header.Key] = value;

            if (header.Key.Isi(HeaderNames.ContentEncoding))
            {
                switch (value)
                {
                    case "":
                    case "gzip":
                    case "deflate":
                        break;
                    default:
                        throw new InvalidOperationException($"The given server response is invalid. The encoding '{value}' is not supported.");
                }
            }
        }

        var newCookies = cookieContainer.GetCookies(responseUri);
        var cookies = newCookies.OfType<Cookie>().Except(originalCookies.OfType<Cookie>()).ToArray();

        if (cookies.Length > 0)
        {
            result.Headers[HeaderNames.SetCookie] = string.Join(", ", cookies.Select(c => c.ToString()));
        }

        return result;
    }

    /// <summary>
    /// A stream wrapper that takes ownership of the HTTP response, request, and client,
    /// disposing them when this stream is disposed.
    /// </summary>
    private sealed class OwningStream : Stream
    {
        private readonly Stream _inner;
        private readonly HttpResponseMessage _response;
        private readonly HttpRequestMessage _request;
        private readonly HttpClient _client;

        public OwningStream(Stream inner, HttpResponseMessage response, HttpRequestMessage request, HttpClient client)
        {
            _inner = inner;
            _response = response;
            _request = request;
            _client = client;
        }

        public override bool CanRead => _inner.CanRead;
        public override bool CanSeek => _inner.CanSeek;
        public override bool CanWrite => _inner.CanWrite;
        public override long Length => _inner.Length;

        public override long Position
        {
            get => _inner.Position;
            set => _inner.Position = value;
        }

        public override void Flush() => _inner.Flush();
        public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);
        public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);
        public override void SetLength(long value) => _inner.SetLength(value);
        public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => _inner.ReadAsync(buffer, offset, count, cancellationToken);
        public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default) => _inner.ReadAsync(buffer, cancellationToken);
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) => _inner.CopyToAsync(destination, bufferSize, cancellationToken);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _inner.Dispose();
                _response.Dispose();
                _request.Dispose();
                _client.Dispose();
            }

            base.Dispose(disposing);
        }
    }

    #endregion
}
