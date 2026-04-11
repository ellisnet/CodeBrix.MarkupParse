using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class HtmlStyleTests
{
    [Fact]
    public void StyleWithCommentThatContainsClosingStyleTag()
    {
        var doc = (@"<!doctype html><style><!--...</style>...--></style>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--...", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("...-->", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void StyleWithCommentsAndText()
    {
        var doc = (@"<!doctype html><style><!--<br><html xmlns:v=""urn:schemas-microsoft-com:vml""><!--[if !mso]><style></style>X").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--<br><html xmlns:v=\"urn:schemas-microsoft-com:vml\"><!--[if !mso]><style>", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void StyleWithCommentsAndNestedStyles()
    {
        var doc = (@"<!doctype html><style><!--...<style><!--...--!></style>--></style>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--...<style><!--...--!>", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("-->", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void StyleWithNestedCommentAndOtherStyles()
    {
        var doc = (@"<!doctype html><style><!--...</style><!-- --><style>@import ...</style>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml1head0.ChildNodes.Length);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--...", dochtml1head0style0Text0.TextContent);

        var dochtml1head0Comment1 = dochtml1head0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml1head0Comment1.NodeType);
        Assert.Equal(@" ", dochtml1head0Comment1.TextContent);

        var dochtml1head0style2 = dochtml1head0.ChildNodes[2] as Element;
        Assert.Single(dochtml1head0style2.ChildNodes);
        Assert.Empty(dochtml1head0style2.Attributes);
        Assert.Equal("style", dochtml1head0style2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style2.NodeType);

        var dochtml1head0style2Text0 = dochtml1head0style2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style2Text0.NodeType);
        Assert.Equal("@import ...", dochtml1head0style2Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void StyleWithNestedElementAndComment()
    {
        var doc = (@"<!doctype html><style>...<style><!--...</style><!-- --></style>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1head0.ChildNodes.Length);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("...<style><!--...", dochtml1head0style0Text0.TextContent);

        var dochtml1head0Comment1 = dochtml1head0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml1head0Comment1.NodeType);
        Assert.Equal(@" ", dochtml1head0Comment1.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void StyleWithCommentInsideThatHostsIEConditional()
    {
        var doc = (@"<!doctype html><style>...<!--[if IE]><style>...</style>X").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("...<!--[if IE]><style>...", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void TitleWithCommentInsideThatHostsAnotherTitlePair()
    {
        var doc = (@"<!doctype html><title><!--<title></title>--></title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(dochtml1head0title0.Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("<!--<title>", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("-->", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void TitleWithEntityThatIsWronglyClosed()
    {
        var doc = (@"<!doctype html><title>&lt;/title></title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(dochtml1head0title0.Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("</title>", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void StyleWithCommentInsideThatContainsAnotherStylePair()
    {
        var doc = (@"<!doctype html><style><!--<style></style>--></style>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--<style>", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("-->", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void StyleWithOpeningCommentAndClosedStyleInside()
    {
        var doc = (@"<!doctype html><style><!--</style>X").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0style0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0style0.ChildNodes);
        Assert.Empty(dochtml1head0style0.Attributes);
        Assert.Equal("style", dochtml1head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0style0.NodeType);

        var dochtml1head0style0Text0 = dochtml1head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0style0Text0.NodeType);
        Assert.Equal("<!--", dochtml1head0style0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);
    }

}
