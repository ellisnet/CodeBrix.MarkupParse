using CodeBrix.MarkupParse.Html;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class MinifyFormatterTests
{
    [Fact]
    public void MinifiesStandardHtmlRemoval()
    {
        var input = "<html><head></head><body><div>Hello!</div></body></html>";
        var output = Minify(input);
        Assert.Equal("<div>Hello!</div>", output);
    }

    [Fact]
    public void MinifiesStandardHtmlPreserveWithAttribute()
    {
        var input = "<html lang=\"en\"><head></head><body><div>Hello!</div></body></html>";
        var output = Minify(input);
        Assert.Equal("<html lang=en><div>Hello!</div></html>", output);
    }

    [Fact]
    public void MinifiesMultipleListItemsHtml()
    {
        var input = "<body><ul><li>1</li><li>2</li><li>3</li><li>4</li></ul></body>";
        var output = Minify(input);
        Assert.Equal("<ul><li>1<li>2<li>3<li>4</ul>", output);
    }

    [Fact]
    public void MinifiesAttributes()
    {
        var input = "<body><ul><li>1</li><li>2</li><li>3</li><li>4</li></ul></body>";
        var output = Minify(input);
        Assert.Equal("<ul><li>1<li>2<li>3<li>4</ul>", output);
    }

    [Fact]
    public void MinifiesRemovesComments()
    {
        var input = "<!-- foo --><div>baz</div><!-- bar\n\n moo -->";
        var output = Minify(input);
        Assert.Equal("<div>baz</div>", output);
    }

    [Fact]
    public void MinifiesRemovesBooleanAttributes()
    {
        var input = "<input disabled=\"disabled\" />";
        var output = Minify(input);
        Assert.Equal("<input disabled>", output);
    }

    [Fact]
    public void MinifiesRemovesStandardScriptType()
    {
        var input = "<script type=\"text/javascript\">  alert(  0  );  </script>";
        var output = Minify(input);
        Assert.Equal("<script>  alert(  0  );  </script>", output);
    }

    [Fact]
    public void MinifiesRemovesStandardStyleType()
    {
        var input = "<style type=\"text/css\">  foo {  color:  red; }  </style>";
        var output = Minify(input);
        Assert.Equal("<style>  foo {  color:  red; }  </style>", output);
    }

    [InlineData("=")]
    [InlineData("`")]
    [InlineData("<")]
    [InlineData(">")]
    [InlineData("'")]
    [InlineData("&quot;")]
    [Theory]
    public void MinifiesPreservesQuotesWhenNeeded(string attributeValue)
    {
        var input = $"<div a=\"{attributeValue}\"></div>";
        var output = Minify(input);
        Assert.Equal(input, output);
    }

    [Fact]
    public void MinifiesAddSpaceAfterAttributeValueWhenItEndsWithASlash()
    {
        var input = "<div a='abc/'></div>";
        var output = Minify(input);
        Assert.Equal("<div a=abc/ ></div>", output);
    }

    [Fact]
    public void MinifiesDoNotAddSpaceAfterAttributeValueWhenItEndsWithASlashIfItIsNotTheLastAttribute()
    {
        var input = "<div a='abc/' b=abc></div>";
        var output = Minify(input);
        Assert.Equal("<div a=abc/ b=abc></div>", output);
    }

    [Fact]
    public void MinifiesFullHtmlStripsOutComments()
    {
        var input = @"<html>

<head>

<!– This is the content that shows in the browser tab –>

<title>Homepage</title>

</head>

<body>

<!– This is a comment. –>

<H1>Hello, world!</H1>

</body>

</html>";
        var output = Minify(input);
        Assert.Equal("<title>Homepage</title> <h1>Hello, world!</h1>", output);
    }

    [Fact]
    public void MinifiesFullHomepage()
    {
        var input = @"<!doctype html>
<html class=""no-js"" lang=""en"">
<head>
<meta charset=""utf-8"" />
<meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
<title>Test</title>
<meta name=""keywords"" content=""Some Test, Another"" />
</head>
<body>
<header>
<div class=""tight"">
</div>
</header>
<aside>
<ul>
    <li><a href=""/filter/2019"">2019</a></li>
    <li><a href=""/filter/2019/5"">May 2019</a></li>
    <li><a href=""/filter/2019/3"">March 2019</a></li>
    <li><a href=""/filter/2019/2"">February 2019</a></li>
    <li><a href=""/filter/2019/1"">January 2019</a></li>
    <li><a href=""/filter/2018"">2018</a></li>
    <li><a href=""/filter/2018/11"">November 2018</a></li>
    <li><a href=""/filter/2017"">2017</a></li>
    <li><a href=""/filter/2016"">2016</a></li>
    <li><a href=""/filter/2015"">2015</a></li>
    <li><a href=""/filter/2014"">2014</a></li>
    <li><a href=""/filter/2013"">2013</a></li>
    <li><a href=""/filter/2012"">2012</a></li>
    <li><a href=""/filter/2011"">2011</a></li>
</ul>
</div>
<div id=""google"">
<div class=""side-header"">Advertisement</div>
<script>google_ad_client = ""ca-pub-7557828921398403"";google_ad_slot = ""8589914705"";google_ad_width = 180;google_ad_height = 90;</script>
<script src=""https://pagead2.googlesyndication.com/pagead/show_ads.js""></script>
</div>
</aside>
<footer>

<div id=""footer"">
        
            <a href=""/Account/LogOn"" target=""dialog"">Log On</a> |
            <a href=""/Account/Register"">Register</a>
</div>
</footer>
<script async defer src=""//s3.amazonaws.com/cc.silktide.com/cookieconsent.latest.min.js""></script>
</body>
</html>";
        var output = Minify(input);
        Assert.Equal(@"<!DOCTYPE html><html class=no-js lang=en><meta charset=utf-8><meta http-equiv=X-UA-Compatible content=""IE=edge,chrome=1""><title>Test</title><meta name=keywords content=""Some Test, Another""><header> <div class=tight> </div> </header> <aside> <ul> <li><a href=/filter/2019>2019</a> <li><a href=/filter/2019/5>May 2019</a> <li><a href=/filter/2019/3>March 2019</a> <li><a href=/filter/2019/2>February 2019</a> <li><a href=/filter/2019/1>January 2019</a> <li><a href=/filter/2018>2018</a> <li><a href=/filter/2018/11>November 2018</a> <li><a href=/filter/2017>2017</a> <li><a href=/filter/2016>2016</a> <li><a href=/filter/2015>2015</a> <li><a href=/filter/2014>2014</a> <li><a href=/filter/2013>2013</a> <li><a href=/filter/2012>2012</a> <li><a href=/filter/2011>2011</a> </ul> <div id=google> <div class=side-header>Advertisement</div> <script>google_ad_client = ""ca-pub-7557828921398403"";google_ad_slot = ""8589914705"";google_ad_width = 180;google_ad_height = 90;</script> <script src=https://pagead2.googlesyndication.com/pagead/show_ads.js></script> </div> </aside> <footer> <div id=footer> <a href=/Account/LogOn target=dialog>Log On</a> | <a href=/Account/Register>Register</a> </div> </footer> <script async defer src=//s3.amazonaws.com/cc.silktide.com/cookieconsent.latest.min.js></script></html>", output);
    }

    private static string Minify(string input, MinifyMarkupFormatter formatter = null)
    {
        var document = input.ToHtmlDocument();
        return document.ToHtml(formatter ?? new MinifyMarkupFormatter());
    }
}
