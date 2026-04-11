using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Media;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io.Processors; //Was previously: namespace AngleSharp.Io.Processors

abstract class ResourceRequestProcessor<TResource> : BaseRequestProcessor
    where TResource : IResourceInfo
{
    #region Fields

    private readonly IBrowsingContext _context;

    #endregion

    #region ctor

    public ResourceRequestProcessor(IBrowsingContext context)
        : base(context?.GetService<IResourceLoader>()!)
    {
        _context = context!;
    }

    #endregion

    #region Properties

    public string Source => Resource?.Source.Href ?? string.Empty;

    [MemberNotNullWhen(true, nameof(Resource))]
    public bool IsReady => Resource is not null;

    public TResource Resource
    {
        get;
        protected set;
    }

    #endregion

    #region Methods

    public override Task ProcessAsync(ResourceRequest request)
    {
        if (IsAvailable && IsDifferentToCurrentResourceUrl(request.Target))
        {
            return base.ProcessAsync(request);
        }

        return Task.CompletedTask;
    }

    #endregion

    #region Helpers

    protected IResourceService<TResource> GetService(IResponse response)
    {
        var type = response.GetContentType();
        return _context.GetResourceService<TResource>(type.Content);
    }

    private bool IsDifferentToCurrentResourceUrl(Url target)
    {
        var resource = Resource;
        return resource is null || !target.Equals(resource.Source);
    }

    #endregion
}
