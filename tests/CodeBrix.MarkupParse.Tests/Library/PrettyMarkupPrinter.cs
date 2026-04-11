using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using Xunit;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class PrettyMarkupPrinter
{
    [Fact]
    public void ElementsArePrintedWithAdditionalWhitespaceInPrettyFormatter()
    {
        var output = Print("<html><head></head><body><i></i></body></html>");
        var result = @"<html>
	<head></head>
	<body>
		<i></i>
	</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void ElementsWithAttributesArePrintedLikeNormalElementsInPrettyFormatter()
    {
        var output = Print("<html><head></head><body><script src=\"//ajax.aspnetcdn.com/ajax/bootstrap/3.0.1/bootstrap.min.js\"></script><script src=\"//ajax.aspnetcdn.com/ajax/jquery/1.9.1/jquery.min.js\"></script></body></html>");
        var result = @"<html>
	<head></head>
	<body>
		<script src=""//ajax.aspnetcdn.com/ajax/bootstrap/3.0.1/bootstrap.min.js""></script>
		<script src=""//ajax.aspnetcdn.com/ajax/jquery/1.9.1/jquery.min.js""></script>
	</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }
    
    [Fact]
    public void SelfClosedElementsArePrintedLikeNormalElementsInPrettyFormatter()
    {
        var output = Print("<html><head><meta name=\"this\" content=\"that\"><meta name=\"this\" content=\"that\"></head><body></body></html>");
        var result = @"<html>
	<head>
		<meta name=""this"" content=""that"">
		<meta name=""this"" content=""that"">
	</head>
	<body></body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void StandardWhitespaceIsMergedIntoSerializationOfPrettyFormatter()
    {
        var output = Print(@"
<html>
	<head>
		<meta name=""this"" content=""that"">
		<meta name=""this"" content=""that"">
	</head>
	<body>
	</body>
</html>
");
        var result = @"<html>
	<head>
		<meta name=""this"" content=""that"">
		<meta name=""this"" content=""that"">
	</head>
	<body>
	</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }
    [Fact]
    public void CommentsArePlacedCorrectlyInPrettyFormatter()
    {
        var output = Print("<html><head><!--First--></head><!--Second--><body><!--Third--></body></html><!--Fourth-->");
        var result = @"<html>
	<head>
		<!--First-->
	</head>
	<!--Second-->
	<body>
		<!--Third-->
	</body>
</html>
<!--Fourth-->";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void TextAndElementsAreMixedWithTightSpacingInPrettyFormatter()
    {
        var output = Print(@"<html><head></head><body>hello <i>my</i> friend<u>!</u> How are <strong>you</strong>?</body></html>");
        var result = @"<html>
	<head></head>
	<body>hello
		<i>my</i>
		friend<u>!</u>
		How are
		<strong>you</strong>?</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void TextAndElementsAreMixedWithInsertedSpacingInPrettyFormatter()
    {
        var output = Print(@"<html><head></head><body> hello <i>my</i> friend<u>!</u> How are <strong>you</strong>? </body></html>");
        var result = @"<html>
	<head></head>
	<body>
		hello
		<i>my</i>
		friend<u>!</u>
		How are
		<strong>you</strong>?
	</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void SpacedConsecutiveAppendedTextNodesKeepSpace_Issue759()
    {
        var document = "<!DOCTYPE html><html><body></body></html>".ToHtmlDocument();
        var body = document.QuerySelector("body");
        body.AppendChild(document.CreateTextNode("To "));  // With a trailing space
        body.AppendChild(document.CreateTextNode("get ")); // With a trailing space
        body.AppendChild(document.CreateTextNode("her."));
        var output = Print(document);
        var result = @"<!DOCTYPE html>
<html>
	<head></head>
	<body>To get her.</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void SpacedConsecutivePrependedTextNodesKeepSpace()
    {
        var document = "<!DOCTYPE html><html><body></body></html>".ToHtmlDocument();
        var body = document.QuerySelector("body");
        body.AppendChild(document.CreateTextNode("To"));
        body.AppendChild(document.CreateTextNode(" get"));
        body.AppendChild(document.CreateTextNode(" her."));
        var output = Print(document);
        var result = @"<!DOCTYPE html>
<html>
	<head></head>
	<body>To get her.</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    [Fact]
    public void PreservingFormatting_Issue1131()
    {
        var document = "<!DOCTYPE html><html lang=\"en\"><head><title>Some Title</title></head><body><h1>Test</h1><pre><code class=\"language-F#\">let a = \"something\"\nlet b = \"something else\"\nlet c = \"something completely different\"\n</code></pre></body></html>".ToHtmlDocument();
        IEnumerable<INode> toPreserve=new List<INode>() { document.QuerySelector("code")};
        var output = Print(document, toPreserve);
        var result = @"<!DOCTYPE html>
<html lang=""en"">
	<head>
		<title>Some Title</title>
	</head>
	<body>
		<h1>Test</h1>
		<pre>
			<code class=""language-F#"">let a = ""something""
			let b = ""something else""
			let c = ""something completely different""
			</code>
		</pre>
	</body>
</html>";

        Assert.Equal(result.Replace(Environment.NewLine, "\n"), output);
    }

    private static string Print(IDocument document, IEnumerable<INode> toPreserve)
    {
        return document.ToHtml(new PrettyMarkupFormatter(toPreserve));
    }

    private static string Print(string html)
    {
        return Print(html.ToHtmlDocument());
    }

    private static string Print(IDocument document)
    {
        return document.ToHtml(new PrettyMarkupFormatter());
    }
}
