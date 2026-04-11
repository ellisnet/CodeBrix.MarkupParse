# CodeBrix.MarkupParse

A fully managed, cross-platform HTML/markup parsing library for .NET.
CodeBrix.MarkupParse has no dependencies other than .NET, and is provided as a .NET 10 library and associated `CodeBrix.MarkupParse.MitLicenseForever` NuGet package.

CodeBrix.MarkupParse supports applications and assemblies that target Microsoft .NET version 10.0 and later.
Microsoft .NET version 10.0 is a Long-Term Supported (LTS) version of .NET, and was released on Nov 11, 2025; and will be actively supported by Microsoft until Nov 14, 2028.
Please update your C#/.NET code and projects to the latest LTS version of Microsoft .NET.

CodeBrix.MarkupParse is a fork of the code of the open source AngleSharp library - see below for licensing details.

## CodeBrix.MarkupParse supports:

* HTML parsing and DOM construction
* CSS selector queries (`QuerySelector`, `QuerySelectorAll`)
* Document manipulation (create, append, remove elements)
* HTML serialization (`OuterHtml`, `InnerHtml`, `TextContent`)
* Markup formatting (standard, pretty-print, minified, XHTML)
* Fragment parsing
* Source position tracking
* Asynchronous document loading and parsing
* SVG and MathML element support
* Form handling and validation
* Many more...

## Sample Code

### Parse an HTML String

```csharp
using CodeBrix.MarkupParse.Html.Parser;

var parser = new HtmlParser();
var document = parser.ParseDocument("<h1>Hello World</h1><p>This is a paragraph element");

Console.WriteLine(document.DocumentElement.OuterHtml);
```

### Query Elements with CSS Selectors

```csharp
using CodeBrix.MarkupParse.Html.Parser;
using System.Linq;

var parser = new HtmlParser();
var document = parser.ParseDocument(
    "<ul><li>First item<li>Second item<li class='blue'>Third item!<li class='blue red'>Last item!</ul>");

// Use CSS selectors to find elements
var blueItems = document.QuerySelectorAll("li.blue");
var titles = blueItems.Select(m => m.TextContent);
```

### Manipulate the DOM

```csharp
using CodeBrix.MarkupParse.Html.Parser;

var parser = new HtmlParser();
var document = parser.ParseDocument("<h1>Some example source</h1><p>This is a paragraph element");

var p = document.CreateElement("p");
p.TextContent = "This is another paragraph.";
document.Body.AppendChild(p);

Console.WriteLine(document.DocumentElement.OuterHtml);
```

### Track Source Positions

```csharp
using CodeBrix.MarkupParse.Html.Parser;

var parser = new HtmlParser(new HtmlParserOptions
{
    IsKeepingSourceReferences = true,
});
var document = parser.ParseDocument("<!doctype html><body>");
var bodyPos = document.Body.SourceReference.Position;
// bodyPos == TextPosition(Line: 1, Column: 16, Position: 16)
```

### Load a Document from a URL

```csharp
using CodeBrix.MarkupParse;
using System.Linq;

var config = Configuration.Default.WithDefaultLoader();
var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
var document = await BrowsingContext.New(config).OpenAsync(address);

var cells = document.QuerySelectorAll("tr.vevent td:nth-child(3)");
var titles = cells.Select(m => m.TextContent);
```

Note that additional sample code and usage examples are available in the `CodeBrix.MarkupParse.Tests` project.

## License

The project is licensed under the MIT License. see: https://en.wikipedia.org/wiki/MIT_License

All code originating from AngleSharp was included as allowed by the MIT License permissible open source software license - as of AngleSharp version 7.1.0.
This project (CodeBrix.MarkupParse) complies with all provisions of the source code license of AngleSharp v7.1.0 (MIT License).
