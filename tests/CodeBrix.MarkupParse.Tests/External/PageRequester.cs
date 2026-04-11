using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.External; //Was previously: namespace AngleSharp.Core.Tests.External

sealed class PageRequester : BaseRequester
{
    private readonly static DefaultHttpRequester _default = new DefaultHttpRequester();
    private readonly static string _directory = "Resources";
    private readonly static SiteMapping _mapping = new SiteMapping(Path.Combine(_directory, "content.xml"));

    public override bool SupportsProtocol(string protocol)
    {
        return _default.SupportsProtocol(protocol);
    }

    protected override async Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancel)
    {
        var url = request.Address.Href;

        if (_mapping.Contains(url) == false)
        {
            var response = await _default.RequestAsync(request, cancel).ConfigureAwait(false);
            var fileName = await AddResourceAsync(url, response).ConfigureAwait(false);
            _mapping.Add(url, fileName);
        }

        return await ReadResourceAsync(url).ConfigureAwait(false);
    }

    private Task<IResponse> ReadResourceAsync(string url)
    {
        var fileName = _mapping[url];
        var path = Path.Combine(_directory, fileName);
        var content = File.ReadAllBytes(path);
        return GetResponseAsync(content);
    }

    private async Task<string> AddResourceAsync(string url, IResponse response)
    {
        var counter = 1;
        var file = default(string);
        var path = default(string);

        do
        {
            file = $"{response.Address.HostName}-{counter++}.res";
            path = Path.Combine(_directory, file);
        }
        while (File.Exists(path));

        var content = await GetContentAsync(response).ConfigureAwait(false);
        File.WriteAllBytes(path, content);
        return file;
    }

    private async Task<byte[]> GetContentAsync(IResponse response)
    {
        var code = (int)response.StatusCode;
        var addr = response.Address.Href;
        var hdrs = response.Headers;
        var ctnt = response.Content;
        var ms = new MemoryStream();
        ms.Write(code);
        ms.Write(addr);
        ms.Write(hdrs);
        await ctnt.CopyToAsync(ms).ConfigureAwait(false);
        return ms.ToArray();
    }

    private async Task<IResponse> GetResponseAsync(byte[] content)
    {
        var ms = new MemoryStream(content);
        var code = ms.ReadInt();
        var addr = ms.ReadString();
        var hdrs = ms.ReadDictionary();
        var ctnt = new MemoryStream();
        await ms.CopyToAsync(ctnt).ConfigureAwait(false);
        ctnt.Position = 0;
        return new DefaultResponse
        {
            StatusCode = (HttpStatusCode)code,
            Address = new Url(addr),
            Headers = hdrs,
            Content = ctnt
        };
    }
}
