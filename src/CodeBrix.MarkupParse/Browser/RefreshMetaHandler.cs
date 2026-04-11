using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Implementation of a refresh handler.
/// </summary>
public class RefreshMetaHandler : IMetaHandler
{
    private readonly Predicate<Url> _shouldRefresh;

    /// <summary>
    /// Creates a new instance of the refresh meta handler.
    /// </summary>
    /// <param name="shouldRefresh">Optionally defines a predicate.</param>
    public RefreshMetaHandler(Predicate<Url> shouldRefresh = null)
    {
        _shouldRefresh = shouldRefresh ?? AlwaysRefresh;
    }

    void IMetaHandler.HandleContent(IHtmlMetaElement element)
    {
        var metaValue = element.HttpEquivalent;

        if (metaValue.Isi("refresh"))
        {
            var document = element.Owner!;
            var content = element.Content!;
            var baseUrl = new Url(document.DocumentUri);
            var redirectUrl = baseUrl;
            var delay = content;
            var sepIndex = content.IndexOf(';');

            if (sepIndex >= 0)
            {
                delay = content.Substring(0, sepIndex);
                var rest = content.Substring(sepIndex + 1).Trim();

                if (rest.StartsWith("url=", StringComparison.OrdinalIgnoreCase))
                {
                    var relativeUrl = rest.Substring(4);

                    if (relativeUrl.Length > 0)
                    {
                        redirectUrl = new Url(baseUrl, relativeUrl);
                    }
                }
            }

            if (int.TryParse(delay, out var delaySeconds))
            {
                var delayTime = TimeSpan.FromSeconds(delaySeconds);

                Task.Delay(delayTime)
                    .ContinueWith(_ => document.Location.Assign(redirectUrl.Href));
            }
        }
    }

    private static bool AlwaysRefresh(Url url) => true;
}
