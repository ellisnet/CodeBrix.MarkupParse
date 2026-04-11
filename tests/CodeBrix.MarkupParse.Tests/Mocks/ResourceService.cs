using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Media;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class ResourceService<TResource> : IResourceService<TResource>
    where TResource : IResourceInfo
{
    private readonly string _mimeType;
    private readonly Func<IResponse, TResource> _creator;

    public ResourceService(string mimeType, Func<IResponse, TResource> creator)
    {
        _mimeType = mimeType;
        _creator = creator;
    }

    public bool SupportsType(string mimeType)
    {
        return mimeType.Equals(_mimeType, StringComparison.OrdinalIgnoreCase);
    }

    public Task<TResource> CreateAsync(IResponse response, CancellationToken cancel)
    {
        var result = _creator(response);
        return Task.FromResult(result);
    }
}
