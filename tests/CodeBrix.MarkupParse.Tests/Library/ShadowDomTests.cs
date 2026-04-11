using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class ShadowDomTests
{
    private static Task<IDocument> CreateStandardDom()
    {
        var source = @"<!doctype html>
<div id=host>
    <div slot=example>Example</div>
    <span>Other</span>
</div>";
        return BrowsingContext.New().OpenAsync(response =>
            response.Address("http://localhost").
                     Content(source));
    }

    [Fact]
    public async Task AttachShadowTreeToOrdinaryElement()
    {
        var document = await CreateStandardDom();
        var shadowRoot = document.QuerySelector("#host").AttachShadow(mode: ShadowRootMode.Open);
        Assert.Equal(shadowRoot, document.QuerySelector("#host").ShadowRoot);
    }

    [Fact]
    public async Task AppendChildrenToAttachedShadowRoot()
    {
        var document = await CreateStandardDom();
        var shadowRoot = document.QuerySelector("#host").AttachShadow(mode: ShadowRootMode.Open);
        var div = document.CreateElement("div");
        var span = document.CreateElement("span");
        shadowRoot.AppendChild(div);
        shadowRoot.AppendChild(span);
        Assert.Equal(2, shadowRoot.ChildElementCount);
    }

    [Fact]
    public async Task DefaultSlotOfShadowRootShouldContainUnassignedNodes()
    {
        var document = await CreateStandardDom();
        var shadowRoot = document.QuerySelector("#host").AttachShadow(mode: ShadowRootMode.Open);
        var slot = document.CreateElement("slot") as IHtmlSlotElement;
        Assert.NotNull(slot);
        shadowRoot.AppendChild(slot);
        Assert.Equal(1, shadowRoot.ChildElementCount);
        var nodes = slot.GetDistributedNodes().ToArray();
        Assert.Equal(4, nodes.Length);
        Assert.Equal(NodeType.Text, nodes[0].NodeType);
        Assert.Equal(NodeType.Text, nodes[1].NodeType);
        Assert.Equal(NodeType.Element, nodes[2].NodeType);
        Assert.Equal(NodeType.Text, nodes[3].NodeType);
        Assert.Equal(document.QuerySelector("#host > span"), nodes[2]);
    }

    [Fact]
    public async Task NamedSlotOfShadowRootShouldNotContainNoAssignedNodes()
    {
        var document = await CreateStandardDom();
        var shadowRoot = document.QuerySelector("#host").AttachShadow(mode: ShadowRootMode.Open);
        var slot = document.CreateElement("slot") as IHtmlSlotElement;
        Assert.NotNull(slot);
        shadowRoot.AppendChild(slot);
        slot.Name = "other";
        Assert.Equal(1, shadowRoot.ChildElementCount);
        var nodes = slot.GetDistributedNodes().ToArray();
        Assert.Empty(nodes);
    }

    [Fact]
    public async Task NamedSlotOfShadowRootShouldContainAssignedNodes()
    {
        var document = await CreateStandardDom();
        var shadowRoot = document.QuerySelector("#host").AttachShadow(mode: ShadowRootMode.Open);
        var slot = document.CreateElement("slot") as IHtmlSlotElement;
        Assert.NotNull(slot);
        shadowRoot.AppendChild(slot);
        slot.Name = "example";
        Assert.Equal(1, shadowRoot.ChildElementCount);
        var nodes = slot.GetDistributedNodes().ToArray();
        Assert.Single(nodes);
        Assert.Equal(document.QuerySelector("#host > div"), nodes[0]);
    }
}
