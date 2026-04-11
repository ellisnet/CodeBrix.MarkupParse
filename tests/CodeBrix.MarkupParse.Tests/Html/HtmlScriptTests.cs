using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Text;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests16.dat
/// </summary>

public class HtmlScriptTests
{
    [Fact]
    public void ScriptElementAfterDoctype()
    {
        var doc = (@"<!doctype html><script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithTextAfterDoctype()
    {
        var doc = (@"<!doctype html><script>a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

    }
 
    [Fact]
    public void ScriptWithOpenClosingBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script></").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingUppercaseLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script></S").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</S", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingTwoUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SC").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</SC", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingThreeUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SCR").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</SCR", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingFourUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SCRI").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</SCRI", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingFiveUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SCRIP").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</SCRIP", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingSixUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SCRIPT").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</SCRIPT", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingSevenUppercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></SCRIPT ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingLowercaseLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script></s").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</s", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingTwoLowercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></sc").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</sc", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingThreeLowercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></scr").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</scr", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingFourLowercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></scri").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</scri", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingFiveLowercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></scrip").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</scrip", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingSixLowercaseLettersAfterDoctype()
    {
        var doc = (@"<!doctype html><script></script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("</script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenClosingSixLowercaseLettersAndSpaceAfterDoctype()
    {
        var doc = (@"<!doctype html><script></script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenBogusCommentAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenBogusCommentAndLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenBogusCommentAndDashAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!-").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!-", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenBogusCommentAndDashLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!-a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!-a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenSlashAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--</").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--</", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashClosingScriptUnfinishedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--</script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--</script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashClosingScriptUnfinishedSpacesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--</script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenLetterSAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<s").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<s", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenScriptUnfinishedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenScriptUnfinishedSpacesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script ", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenScriptUnfinishedSpacesOpenAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script <").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script <", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndDashDashOpenScriptUnfinishedSpacesOpenLetterAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script <a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script <a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentScriptTagInsideAndClosingAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosingSTagAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </s").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </s", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosingScriptTagUnfinishedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosingScriptMisspelledUnfinishedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </scripta").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </scripta", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosingScriptUnfinishedSpacesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosedScriptAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script>", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenScriptTagAndTrailingSlashWhenClosingScriptAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script/").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script/", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenScriptTagAndOpenBracketAfterSpaceAfterClosingScriptAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script <").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script <", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndOpenLowercaseAAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script <a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script <a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndClosingTagAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script </").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script </", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndClosingScriptTagAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script </script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script </script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndClosingScriptTagUnfinishedWithSpacesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script </script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndClosingScriptTagUnfinishedTrailingSlashAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script </script/").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagUnfinishedSpaceAndClosedScriptTagAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script </script </script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndOneFinalDashAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script -").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndOneFinalDashAndLowercaseAAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script -a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndOneFinalDashAndOpenBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script -<").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -<", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndTwoFinalDashesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndTwoFinalDashesLowercaseAAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --a").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --a", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptElementAndTwoFinalDashesOpenBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --<").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --<", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatHostsScriptElementAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script -->").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatHostsScriptElementAndOpenBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --><").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --><", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatHostsScriptElementAndOpenClosingBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --></").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --></", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatHostsScriptElementUnfinishedClosingBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --></script").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script --></script", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatHostsScriptElementUnfinishedClosingBracketWithSpacesAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --></script ").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosedCommentThatHostsUnfinishedScriptElementAndClosingUnfinishedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --></script/").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosedCommentThatHostsUnfinishedScriptElementClosedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script --></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script -->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosedCommentThatHostsScriptPairWithMistakeClosedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script><\/script>--></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal(@"<!--<script><\/script>-->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosedCommentThatHostsScriptPairWithMistakesClosedAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script></scr'+'ipt>--></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></scr'+'ipt>-->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptPairAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptPairAndClosingBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script>--><!--</script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>--><!--", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentThatHostsScriptPairAndHasASpaceBeforeClosingBracketAfterDoctype()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script>-- ></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>-- >", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithMultipleEscapedCommentsWrongBarelyClosed()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script>- -></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>- ->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithMultipleEscapedCommentsWrongClearlyClosed()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script>- - ></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>- - >", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithMultipleEscapedCommentsWrongWronglyClosed()
    {
        var doc = (@"<!doctype html><script><!--<script></script><script></script>-></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>->", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithEscapedOpenedScriptTagFollowedByText()
    {
        var doc = (@"<!doctype html><script><!--<script>--!></script>X").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script>--!></script>X", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithSpecialCharactersInWronglyEscapedScriptTag()
    {
        var doc = (@"<!doctype html><script><!--<scr'+'ipt></script>--></script>").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<scr'+'ipt>", dochtml1head0script0Text0.TextContent);

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
    public void ScriptWithEscapedScriptTagClosedWrongWithSpecialCharacters()
    {
        var doc = (@"<!doctype html><script><!--<script></scr'+'ipt></script>X").ToHtmlDocument();
  
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

        var dochtml1head0script0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0script0.ChildNodes);
        Assert.Empty(dochtml1head0script0.Attributes);
        Assert.Equal("script", dochtml1head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0script0.NodeType);

        var dochtml1head0script0Text0 = dochtml1head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0script0Text0.NodeType);
        Assert.Equal("<!--<script></scr'+'ipt></script>X", dochtml1head0script0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptNoScriptWithClosedCommentThatContainsAnotherClosedNoScriptElement()
    {
        var source = "<!doctype html><noscript><!--<noscript></noscript>--></noscript>";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);
  
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

        var dochtml1head0noscript0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0noscript0.ChildNodes);
        Assert.Empty(dochtml1head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml1head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0noscript0.NodeType);

        var dochtml1head0noscript0Text0 = dochtml1head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0noscript0Text0.NodeType);
        Assert.Equal("<!--<noscript>", dochtml1head0noscript0Text0.TextContent);

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
    public void ScriptNoScriptWithCommentStartAndTextInsideBeforeClosing()
    {
        var source = "<!doctype html><noscript><!--</noscript>X<noscript>--></noscript>";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);
  
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

        var dochtml1head0noscript0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0noscript0.ChildNodes);
        Assert.Empty(dochtml1head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml1head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0noscript0.NodeType);

        var dochtml1head0noscript0Text0 = dochtml1head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0noscript0Text0.NodeType);
        Assert.Equal("<!--", dochtml1head0noscript0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);

        var dochtml1body1noscript1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1noscript1.ChildNodes);
        Assert.Empty(dochtml1body1noscript1.Attributes);
        Assert.Equal("noscript", dochtml1body1noscript1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1noscript1.NodeType);

        var dochtml1body1noscript1Text0 = dochtml1body1noscript1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1noscript1Text0.NodeType);
        Assert.Equal("-->", dochtml1body1noscript1Text0.TextContent);
    }
 
    [Fact]
    public void ScriptNoScriptAfterDoctypeWithIFrameContentAndTextAfter()
    {
        var source = "<!doctype html><noscript><iframe></noscript>X";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);
  
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

        var dochtml1head0noscript0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0noscript0.ChildNodes);
        Assert.Empty(dochtml1head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml1head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0noscript0.NodeType);

        var dochtml1head0noscript0Text0 = dochtml1head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0noscript0Text0.NodeType);
        Assert.Equal("<iframe>", dochtml1head0noscript0Text0.TextContent);

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
    public void ScriptWithinBodyThatisInsideNoframes()
    {
        var doc = (@"<!doctype html><noframes><body><script><!--...</script></body></noframes></html>").ToHtmlDocument();
  
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

        var dochtml1head0noframes0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0noframes0.ChildNodes);
        Assert.Empty(dochtml1head0noframes0.Attributes);
        Assert.Equal("noframes", dochtml1head0noframes0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0noframes0.NodeType);

        var dochtml1head0noframes0Text0 = dochtml1head0noframes0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0noframes0Text0.NodeType);
        Assert.Equal("<body><script><!--...</script></body>", dochtml1head0noframes0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }
 
    [Fact]
    public void ScriptStandalone()
    {
        var doc = (@"<script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithTextLowercaseA()
    {
        var doc = (@"<script>a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithTextLt()
    {
        var doc = (@"<script><").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithTextLtSlash()
    {
        var doc = (@"<script></").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagSpace()
    {
        var doc = (@"<script></SCRIPT ").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseS()
    {
        var doc = (@"<script></s").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</s", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseSC()
    {
        var doc = (@"<script></sc").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</sc", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseSCR()
    {
        var doc = (@"<script></scr").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</scr", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseSCRI()
    {
        var doc = (@"<script></scri").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</scri", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseSCRIP()
    {
        var doc = (@"<script></scrip").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</scrip", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptTagLowercaseSCRIPT()
    {
        var doc = (@"<script></script").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("</script", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithClosingScriptSpaceInsteadOfGt()
    {
        var doc = (@"<script></script ").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEm()
    {
        var doc = (@"<script><!").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmLowercaseA()
    {
        var doc = (@"<script><!a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDash()
    {
        var doc = (@"<script><!-").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!-", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashLowercaseA()
    {
        var doc = (@"<script><!-a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!-a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDash()
    {
        var doc = (@"<script><!--").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDashLowercaseA()
    {
        var doc = (@"<script><!--a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDashLt()
    {
        var doc = (@"<script><!--<").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDashLtLowercaseA()
    {
        var doc = (@"<script><!--<a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDashLtSlash()
    {
        var doc = (@"<script><!--</").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--</", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptLtEmDashDashLtSlashLowercaseSCRIPT()
    {
        var doc = (@"<script><!--</script").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--</script", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithStartCommentScriptInside()
    {
        var doc = (@"<script><!--<script </s").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script </s", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithStartCommentAndThreeEscapes()
    {
        var doc = (@"<script><!--<script </script </script ").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithStartCommentAndEffectivelyClosed()
    {
        var doc = (@"<script><!--<script </script </script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script </script ", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpeningCommentAndDashLowercaseA()
    {
        var doc = (@"<script><!--<script -a").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script -a", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptThatTriesToEscapeAnotherScriptTag()
    {
        var doc = (@"<script><!--<script --").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script --", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptThatContainsAnotherScriptTagInsideCommentAndIsNotFinished()
    {
        var doc = (@"<script><!--<script --><").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script --><", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptThatContainsAnotherScriptTagInsideAComment()
    {
        var doc = (@"<script><!--<script --></script").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script --></script", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithCommentThatTriesToOpenCloseButMisspells()
    {
        var doc = (@"<script><!--<script><\/script>--></script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal(@"<!--<script><\/script>-->", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithScriptsInCommentCommentBeforeClosing()
    {
        var doc = (@"<script><!--<script></script><script></script>--><!--</script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>--><!--", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithScriptsInCommentSpaceBeforeBracket()
    {
        var doc = (@"<script><!--<script></script><script></script>-- ></script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>-- >", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithScriptsInCommentSpaceBetweenDash()
    {
        var doc = (@"<script><!--<script></script><script></script>- -></script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>- ->", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithScriptsInCommentDashMissing()
    {
        var doc = (@"<script><!--<script></script><script></script>-></script>").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script></script><script></script>->", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithValidCommentAndTextAfter()
    {
        var doc = (@"<script><!--<script>--!></script>X").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script>--!></script>X", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
 
    [Fact]
    public void ScriptWithOpenCommentAndClosingMisspelledTextAfter()
    {
        var doc = (@"<script><!--<script></scr'+'ipt></script>X").ToHtmlDocument();
  
        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(dochtml0head0script0.Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal("<!--<script></scr'+'ipt></script>X", dochtml0head0script0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void LargeInlineScriptShouldNotExceedStack()
    {
        var bytes = Assets.longscript;
        var content = TextEncoding.Utf8.GetString(bytes);
        var doc = (content).ToHtmlDocument();
        Assert.NotNull(doc);
    }
}
