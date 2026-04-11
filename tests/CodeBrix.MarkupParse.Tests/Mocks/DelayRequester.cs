using CodeBrix.MarkupParse.Io;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class DelayRequester : BaseRequester
{
    private readonly int _timeout;
    private int _count;

    public DelayRequester(int timeout)
    {
        _timeout = timeout;
        _count = 0;
    }

    public int RequestCount => _count;

    public override bool SupportsProtocol(string protocol)
    {
        return true;
    }

    protected override async Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancel)
    {
        await Task.Delay(_timeout, cancel);
        _count++;
        return new DefaultResponse
        {
            Address  = request.Address,
            Content = MemoryStream.Null,
            StatusCode = HttpStatusCode.OK
        };
    }
}
