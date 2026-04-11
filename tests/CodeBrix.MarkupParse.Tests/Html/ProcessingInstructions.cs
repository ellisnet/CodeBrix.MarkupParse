using CodeBrix.MarkupParse.Html.Parser;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class ProcessingInstructions
{
    [Fact]
    public void ParsingWithSupportForProcessingInstructionsShouldProduceNode()
    {
        var source = @"<?foo bar>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsSupportingProcessingInstructions = true
        });
        var document = parser.ParseDocument(source);
        Assert.Equal(Dom.NodeType.ProcessingInstruction, document.ChildNodes[0].NodeType);
    }

    [Fact]
    public void ParsingWithoutSupportForProcessingInstructionsShouldCommentThemOut()
    {
        var source = @"<?foo bar>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsSupportingProcessingInstructions = false
        });
        var document = parser.ParseDocument(source);
        Assert.Equal(Dom.NodeType.Comment, document.ChildNodes[0].NodeType);
    }
}
