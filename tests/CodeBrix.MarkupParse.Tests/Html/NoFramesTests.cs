using CodeBrix.MarkupParse.Html.Parser;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class NoFramesTests
{
    [Fact]
    public void ParsingWithNoSupportForFramesShouldRespectNoFrames()
    {
        var source = @"  <frameset cols=""30%,*"">
    <frame src=""frame1.php"" name=""frame1"">
    <frame src=""frame2.php"" name=""frame2"">
    <noframes>
      <body>
        <p>This text will appear only if the browser does not support frames.</p>
        <p><img src=""..\..\assets\img\city10.png"" alt=""city10""></p>
      </body>
    </noframes>
  </frameset>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsNotSupportingFrames = true
        });
        var document = parser.ParseDocument(source);
        var noFramesParagraphs = document.QuerySelectorAll("p");
        Assert.Equal(2, noFramesParagraphs.Length);
    }

    [Fact]
    public void ParsingWithSupportForFramesShouldIgnoreNoFrames()
    {
        var source = @"  <frameset cols=""30%,*"">
    <frame src=""frame1.php"" name=""frame1"">
    <frame src=""frame2.php"" name=""frame2"">
    <noframes>
      <body>
        <p>This text will appear only if the browser does not support frames.</p>
        <p><img src=""..\..\assets\img\city10.png"" alt=""city10""></p>
      </body>
    </noframes>
  </frameset>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsNotSupportingFrames = false
        });
        var document = parser.ParseDocument(source);
        var noFramesParagraphs = document.QuerySelectorAll("p");
        Assert.Empty(noFramesParagraphs);
    }

    [Fact]
    public void ParsingWithNoSupportForFramesShouldPlaceContentInBody()
    {
        var source = @"  <frameset>
    <noframes>
      <p>This text will appear only if the browser does not support frames.</p>
      <p><img src=""..\..\assets\img\city10.png"" alt=""city10""></p>
    </noframes>
  </frameset>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsNotSupportingFrames = true
        });
        var document = parser.ParseDocument(source);
        var noFramesParagraphs = document.QuerySelectorAll("p");
        Assert.Equal(2, noFramesParagraphs.Length);
    }
}
