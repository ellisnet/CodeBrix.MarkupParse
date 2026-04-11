using CodeBrix.MarkupParse.Io;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class VirtualRequester : BaseRequester
{
    private readonly Func<Request, IResponse> _onRequest;

    public VirtualRequester(Func<Request, IResponse> onRequest)
    {
        _onRequest = onRequest;
    }

    protected override Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancel)
    {
        var response = _onRequest.Invoke(request);
        return Task.FromResult(response);
    }

    public override bool SupportsProtocol(string protocol)
    {
        return true;
    }
}
