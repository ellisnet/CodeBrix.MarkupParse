using CodeBrix.MarkupParse.Io;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests; //Was previously: namespace AngleSharp.Core.Tests

/// <summary>
/// Requests a DTD file from an embedded resource.
/// </summary>
public class DtdRequester : BaseRequester
{
    public IResponse Request(Request request)
    {
        var name = request.Address.Path;
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"CodeBrix.MarkupParse.Tests.Resources.{name}") ?? throw new ArgumentException($"The DTD {name} could not be found! Check the name and the availability of this DTD.");
        return new DefaultResponse { Content = stream };
    }

    public Task<IResponse> RequestAsync(Request request)
    {
        return RequestAsync(request, CancellationToken.None);
    }

    protected override Task<IResponse> PerformRequestAsync(Request request, CancellationToken cancellationToken)
    {
        return Task.Run(() => Request(request));
    }

    public Dictionary<string, string> Headers
    {
        get;
        set;
    }

    public TimeSpan Timeout
    {
        get;
        set;
    }

    public override bool SupportsProtocol(string protocol)
    {
        return true;
    }
}
