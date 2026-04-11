using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Xhtml;
using System;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class XhtmlFormatter
{
    [Fact]
    public void XhtmlMarkupFormatter_DoesNotFormatEmptyElementsToSelfClosing_WhenEmptyTagsToSelfClosingIsFalse()
    {
        var formatter = new XhtmlMarkupFormatter(false);
        var input = "<html>" +
                        "<head></head>" +
                        "<body>" +
                            "<div>test</div>" +
                            "<div></div>" +
                            "<div class=\"test\"></div>" +
                        "</body>" +
                    "</html>";
        var doc = input.ToHtmlDocument();

        var res = doc.ToHtml(formatter);

        Assert.Equal(input, res);
    }

    [Fact]
    public void XhtmlMarkupFormatter_FormatsEmptyElementsToSelfClosing_WhenEmptyTagsToSelfClosingIsTrue()
    {
        var formatter = new XhtmlMarkupFormatter(true);
        var input = "<html>" +
                            "<head></head>" +
                            "<body>" +
                                "<div>test</div>" +
                                "<div></div>" +
                                "<div class=\"test\"></div>" +
                            "</body>" +
                        "</html>";
        var expected = "<html>" +
                               "<head />" +
                               "<body>" +
                                   "<div>test</div>" +
                                   "<div />" +
                                   "<div class=\"test\" />" +
                               "</body>" +
                           "</html>";
        var doc = input.ToHtmlDocument();

        var res = doc.ToHtml(formatter);

        Assert.Equal(expected, res);
    }

    [Fact]
    public void XhtmlMarkupFormatter_KeepsEntireNameOfXmlNamespacedAttributes()
    {
        var formatter = new XhtmlMarkupFormatter();
        var attributeName = string.Concat(NamespaceNames.XmlNsPrefix, ":", "pfx");
        var inputOnWhichToSetAttribute = "<html>" +
                            "<head></head>" +
                             "<body>" +
                                "<div>test</div>" +
                            "</body>" +
                        "</html>";
        var expected = "<html>" +
                                "<head />" +
                                "<body>" +
                                   "<div xmlns:pfx=\"http://www.foo.com\">test</div>" +
                                "</body>" +
                            "</html>";
        var doc = inputOnWhichToSetAttribute.ToHtmlDocument();
        doc.Body.FirstElementChild.SetAttribute(NamespaceNames.XmlNsUri, attributeName, "http://www.foo.com");
        var res = doc.ToHtml(formatter);
        Assert.Equal(expected, res);
    }

    [Fact]
    public void XhtmlMarkupFormatter_DoesNotDuplicatePrefixIfUnnecessary()
    {
        var formatter = new XhtmlMarkupFormatter();
        var attributeName = NamespaceNames.XmlNsPrefix;
        var inputOnWhichToSetAttribute = "<html>" +
                    "<head></head>" +
                    "<body>" +
                    "<div>test</div>" +
                    "</body>" +
                    "</html>";
        var expected = "<html>" +
                       "<head />" +
                       "<body>" +
                       "<div xmlns=\"http://www.foo.com\">test</div>" +
                       "</body>" +
                       "</html>";
        var doc = inputOnWhichToSetAttribute.ToHtmlDocument();

        doc.Body.FirstElementChild.SetAttribute(NamespaceNames.XmlNsUri, attributeName, "http://www.foo.com");
        var res = doc.ToHtml(formatter);
        Assert.Equal(expected, res);
    }
}
