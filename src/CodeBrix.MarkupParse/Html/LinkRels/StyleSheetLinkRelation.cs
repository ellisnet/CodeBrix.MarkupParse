using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io.Processors;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Html.LinkRels; //Was previously: namespace AngleSharp.Html.LinkRels

class StyleSheetLinkRelation : BaseLinkRelation
{
    #region ctor

    public StyleSheetLinkRelation(IHtmlLinkElement link)
        : base(link, new StyleSheetRequestProcessor(link.Owner!.Context, link))
    {
    }

    #endregion

    #region Properties

    public IStyleSheet Sheet => (Processor as StyleSheetRequestProcessor)?.Sheet;

    #endregion

    #region Methods

    public override async Task LoadAsync()
    {
        if (Url != null)
        {
            var request = Link.CreateRequestFor(Url);
            await Processor.ProcessAsync(request).ConfigureAwait(false)!;
        }
    }

    #endregion
}
