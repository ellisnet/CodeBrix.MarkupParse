using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Examples; //Was previously: namespace AngleSharp.Core.Tests.Examples

public class FormsTests
{
    [Fact(Skip = "Google may show an altered version - we should not depend on externals for such tests")]
    public async Task SubmittingToGoogleWithCookiesShouldWork()
    {
        var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader().WithDefaultCookies());
        var queryDocument = await context.OpenAsync("https://google.com", TestContext.Current.CancellationToken);
        var form = queryDocument.QuerySelector<IHtmlFormElement>("form");
        var resultDocument = await form.SubmitAsync(new { q = "CodeBrix.MarkupParse" });
        var itemCount = resultDocument.QuerySelectorAll<IHtmlAnchorElement>("a").Select(m => m.Href).Count();

        Assert.True(itemCount > 0);
    }
}
