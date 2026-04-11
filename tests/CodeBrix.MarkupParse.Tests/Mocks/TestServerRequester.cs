using CodeBrix.MarkupParse.Io;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class TestServerRequester : BaseRequester
{
    private readonly IDictionary<string, string> _mapping;

    public TestServerRequester(IDictionary<string, string> mapping)
    {
        _mapping = mapping;
    }

    public override bool SupportsProtocol(string protocol)
    {
        return true;
    }

    protected override async Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancel)
    {
        var value = default(string);
        var status = HttpStatusCode.NotFound;
        var content = Stream.Null;

        if (_mapping.TryGetValue(request.Address.Path, out value))
        {
            status = HttpStatusCode.OK;
            content = new MemoryStream(Encoding.UTF8.GetBytes(value));
        }

        await Task.Delay(1);

        return new DefaultResponse
        {
            Address = request.Address,
            Content = content,
            StatusCode = status
        };
    }
}
