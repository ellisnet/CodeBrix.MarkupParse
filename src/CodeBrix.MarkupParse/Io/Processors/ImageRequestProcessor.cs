using CodeBrix.MarkupParse.Media;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io.Processors; //Was previously: namespace AngleSharp.Io.Processors

/// <summary>
/// For more information, see:
/// http://www.w3.org/html/wg/drafts/html/master/embedded-content.html#update-the-image-data
/// </summary>
sealed class ImageRequestProcessor : ResourceRequestProcessor<IImageInfo>
{
    #region ctor

    public ImageRequestProcessor(IBrowsingContext context)
        : base(context)
    {
    }

    #endregion

    #region Properties

    public int Width => IsReady ? Resource.Width : 0;

    public int Height => IsReady ? Resource.Height : 0;

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
