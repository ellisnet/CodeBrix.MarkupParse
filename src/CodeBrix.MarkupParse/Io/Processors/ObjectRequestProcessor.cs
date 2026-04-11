using CodeBrix.MarkupParse.Media;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io.Processors; //Was previously: namespace AngleSharp.Io.Processors

sealed class ObjectRequestProcessor : ResourceRequestProcessor<IObjectInfo>
{
    #region ctor

    public ObjectRequestProcessor(IBrowsingContext context)
        : base(context)
    {
    }

    #endregion

    #region Properties

    public int Width => Resource?.Width ?? 0;

    public int Height => Resource?.Height ?? 0;

    #endregion

    #region Methods

    protected override async Task ProcessResponseAsync(IResponse response)
    {
        var service = GetService(response);

        if (service != null)
        {
            var cancel = CancellationToken.None;
            var result = await service.CreateAsync(response, cancel).ConfigureAwait(false);
            Resource = result;
        }
    }

    #endregion
}
