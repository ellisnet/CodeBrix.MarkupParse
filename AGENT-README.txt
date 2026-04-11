================================================================================
AGENT-README: CodeBrix.MarkupParse
A Comprehensive Guide for AI Coding Agents
================================================================================

OVERVIEW
--------

CodeBrix.MarkupParse is a fully managed, cross-platform HTML/markup parsing
library for .NET. It has ZERO external dependencies beyond .NET itself.

It is a fork of the open source AngleSharp (v7.1.0) library, licensed under
the MIT License.

IMPORTANT: If you are familiar with AngleSharp, the API surface of
CodeBrix.MarkupParse is very similar. However, ALL namespaces use
"CodeBrix.MarkupParse" instead of "AngleSharp". Do NOT mix the two libraries.

Source Repository: https://github.com/ellisnet/CodeBrix.MarkupParse
License: MIT License

================================================================================

INSTALLATION
------------

NuGet Package: CodeBrix.MarkupParse.MitLicenseForever
Dependencies: None
Requirements: .NET 10.0 or higher

To add to a .NET 10+ project:

    dotnet add package CodeBrix.MarkupParse.MitLicenseForever

Or in a .csproj file (NuGet will resolve the latest version):

    <PackageReference Include="CodeBrix.MarkupParse.MitLicenseForever" />

IMPORTANT: The package name is "CodeBrix.MarkupParse.MitLicenseForever"
(not just "CodeBrix.MarkupParse"). Always use this full package name when
installing.

================================================================================

KEY NAMESPACES
--------------

When writing code with CodeBrix.MarkupParse, these are the primary namespaces:

    using CodeBrix.MarkupParse;                   // Core types: Configuration, BrowsingContext, BrowsingContextExtensions
    using CodeBrix.MarkupParse.Html.Parser;        // HtmlParser, HtmlParserOptions, HtmlParserExtensions
    using CodeBrix.MarkupParse.Html.Dom;           // IHtmlDocument and all IHtml*Element interfaces
    using CodeBrix.MarkupParse.Dom;                // IDocument, IElement, INode, INodeList, QueryExtensions, SelectorExtensions, NodeExtensions, ElementExtensions
    using CodeBrix.MarkupParse.Html;               // HtmlMarkupFormatter, PrettyMarkupFormatter, MinifyMarkupFormatter
    using CodeBrix.MarkupParse.Xhtml;              // XhtmlMarkupFormatter
    using CodeBrix.MarkupParse.Css.Dom;            // ISelector and CSS selector types
    using CodeBrix.MarkupParse.Css.Parser;         // CssSelectorParser
    using CodeBrix.MarkupParse.Text;               // TextPosition, TextRange, TextSource
    using CodeBrix.MarkupParse.Io;                 // LoaderOptions, IRequester, DefaultHttpRequester

================================================================================

WHAT THIS LIBRARY DOES
======================

CodeBrix.MarkupParse is an HTML parser and DOM manipulation library. It parses
HTML strings, streams, or URLs into a fully navigable DOM (Document Object
Model) tree that you can query, traverse, modify, and serialize back to HTML.

Key capabilities:

  - Parse HTML strings, streams, char arrays, ReadOnlyMemory<char>, or URLs
    into a complete DOM tree (IHtmlDocument)
  - Query elements using CSS selectors (QuerySelector, QuerySelectorAll)
  - Query elements using LINQ on the document's All collection
  - Traverse the DOM tree (parent, children, siblings, descendants, ancestors)
  - Manipulate the DOM (create, append, remove, replace, clone elements)
  - Read and modify element attributes, classes, IDs, text content
  - Read InnerHtml, OuterHtml, TextContent of any element
  - Serialize the DOM back to HTML with multiple formatting options
    (standard, pretty-printed, minified, XHTML)
  - Parse HTML fragments (partial HTML without a full document)
  - Parse only the <head> section of a document
  - Track source positions of parsed elements (line, column, offset)
  - Register callbacks for element creation and token events during parsing
  - Load documents from URLs asynchronously (with WithDefaultLoader())
  - Handle cookies with WithDefaultCookies()
  - Support for SVG and MathML elements within HTML documents
  - Form handling and validation

================================================================================

WHAT THIS LIBRARY DOES NOT DO
==============================

Do NOT attempt to use CodeBrix.MarkupParse for the following - it will not work:

  - CSS stylesheet parsing or evaluation (it parses CSS selectors for
    querying, but does NOT parse or evaluate CSS stylesheets)
  - JavaScript/script execution
  - Rendering HTML to images or PDFs
  - HTTP client functionality (it can load documents from URLs, but is not
    a general-purpose HTTP client)
  - XML parsing (use System.Xml for that; this library is HTML-specific)
  - Markdown parsing
  - JSON parsing

This library IS for: parsing HTML into a DOM, querying the DOM with CSS
selectors, manipulating DOM nodes, and serializing the DOM back to HTML.

================================================================================

CORE API REFERENCE
==================

1. PARSING HTML (HtmlParser)
----------------------------

The primary entry point is the HtmlParser class. It can be instantiated
directly without any configuration.

    using CodeBrix.MarkupParse.Html.Parser;

    // Create a parser (can be reused for multiple documents)
    var parser = new HtmlParser();

    // Parse a string to a full document
    IHtmlDocument document = parser.ParseDocument("<html><body><p>Hello</p></body></html>");

    // Parse a stream
    using var stream = File.OpenRead("page.html");
    IHtmlDocument document = parser.ParseDocument(stream);

    // Parse a char array
    char[] chars = html.ToCharArray();
    IHtmlDocument document = parser.ParseDocument(chars);

    // Parse ReadOnlyMemory<char>
    ReadOnlyMemory<char> memory = html.AsMemory();
    IHtmlDocument document = parser.ParseDocument(memory);

    // Async parsing
    IHtmlDocument document = await parser.ParseDocumentAsync(htmlString);
    IHtmlDocument document = await parser.ParseDocumentAsync(stream);

IMPORTANT: HtmlParser does NOT implement IDisposable. You do NOT need
"using" statements for the parser itself. Parser instances can be reused.

IMPORTANT: IHtmlDocument implements IDisposable. You SHOULD dispose
documents when finished, especially when using BrowsingContext with
document loading. For simple string parsing, disposal is less critical
but still good practice.


2. PARSING FRAGMENTS
--------------------

Parse partial HTML without creating a full document structure:

    var parser = new HtmlParser();
    var document = parser.ParseDocument("");
    var body = document.Body;
    INodeList nodes = parser.ParseFragment("<li>Item 1</li><li>Item 2</li>", body);


3. PARSING ONLY THE HEAD
-------------------------

Parse just the <head> section for efficiency when you only need metadata:

    var parser = new HtmlParser();
    IHtmlHeadElement head = parser.ParseHead("<html><head><title>My Page</title></head><body>...</body></html>");
    // head.QuerySelector("title").TextContent == "My Page"


4. PARSER OPTIONS (HtmlParserOptions)
--------------------------------------

    var parser = new HtmlParser(new HtmlParserOptions
    {
        // Keep references to original source positions on elements
        IsKeepingSourceReferences = true,

        // Treat parse errors as exceptions
        IsStrictMode = false,

        // Preserve original attribute name casing (normally lowercased)
        IsPreservingAttributeNames = false,

        // Allow custom elements everywhere (not just where spec allows)
        IsAcceptingCustomElementsEverywhere = false,

        // Disable frame support (ignore <frame>, respect <noframes>)
        IsNotSupportingFrames = false,

        // Avoid consuming character references (e.g., &amp;)
        IsNotConsumingCharacterReferences = false,

        // Parse XML processing instructions into DOM nodes
        IsSupportingProcessingInstructions = false,

        // Callback when each element is created during parsing
        OnCreated = (IElement element, TextPosition position) =>
        {
            // Called for every element during parsing
        },

        // Callback when each token is read during tokenization
        OnToken = (HtmlToken token, TextRange range) =>
        {
            // Called for every token during parsing
        },
    });


5. LOADING DOCUMENTS FROM URLS (BrowsingContext)
-------------------------------------------------

To load documents from URLs, you need a BrowsingContext with a loader
configured:

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Dom;
    using System.Linq;

    // Configure with default HTTP loader
    var config = Configuration.Default.WithDefaultLoader();

    // Create a browsing context and load a URL
    var context = BrowsingContext.New(config);
    var document = await context.OpenAsync("https://example.com");

    // Query the loaded document
    var title = document.Title;
    var links = document.QuerySelectorAll("a").Select(a => a.GetAttribute("href"));

IMPORTANT: You MUST call .WithDefaultLoader() on the configuration to
enable document loading from URLs. Without it, OpenAsync() will fail or
return an empty document.

You can also configure cookies:

    var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();

You can create documents from virtual responses:

    var context = BrowsingContext.New();
    var document = await context.OpenAsync(req => req.Content("<h1>Hello</h1>"));

Or open a blank document:

    var document = await context.OpenNewAsync();

================================================================================

QUERYING THE DOM
================

1. CSS SELECTORS (QuerySelector / QuerySelectorAll)
-----------------------------------------------------

    // Returns the FIRST matching element, or null
    IElement element = document.QuerySelector("div.content");

    // Returns ALL matching elements
    IHtmlCollection<IElement> elements = document.QuerySelectorAll("li.blue");

    // Can be called on any element, not just the document
    var nav = document.QuerySelector("nav");
    var navLinks = nav.QuerySelectorAll("a");

    // Typed queries (cast results to specific element types)
    var form = document.QuerySelector<IHtmlFormElement>("form");
    var anchors = document.QuerySelectorAll<IHtmlAnchorElement>("a");

Supported CSS selector syntax includes:

  - Type selectors: div, p, span, a
  - Class selectors: .classname
  - ID selectors: #myid
  - Attribute selectors: [href], [type="text"], [class~="foo"],
    [lang|="en"], [href^="https"], [src$=".png"], [title*="hello"]
  - Pseudo-classes: :first-child, :last-child, :nth-child(2n+1),
    :nth-of-type(odd), :not(.excluded), :empty, :checked, :enabled,
    :disabled, :hover (always false - no renderer), :focus, :link,
    :visited, :scope, and more
  - Pseudo-elements: ::before, ::after, ::first-line, ::first-letter
  - Combinators: descendant (space), child (>), adjacent sibling (+),
    general sibling (~)
  - Compound selectors: div.class#id[attr]
  - Selector lists: h1, h2, h3 (comma-separated)
  - Universal selector: *
  - Namespace selectors


2. LINQ-BASED QUERYING
-----------------------

    using System.Linq;

    // The document.All collection contains every element in the document
    var allDivs = document.All.Where(e => e.LocalName == "div");

    // Find elements by class using ClassList
    var blueItems = document.All
        .Where(e => e.LocalName == "li" && e.ClassList.Contains("blue"));

    // Built-in DOM query methods
    var byId = document.GetElementById("myId");
    var byClass = document.GetElementsByClassName("highlight");
    var byTag = document.GetElementsByTagName("p");
    var byName = document.GetElementsByName("email");


3. SELECTOR EXTENSION METHODS
-------------------------------

The SelectorExtensions class provides jQuery-like helper methods:

    using CodeBrix.MarkupParse.Dom;

    var elements = document.QuerySelectorAll("li");

    // Get element at index
    var third = elements.Eq(2);

    // Get elements above/below an index
    var afterThird = elements.Gt(2);
    var beforeThird = elements.Lt(2);

    // Even/odd elements
    var evenItems = elements.Even();
    var oddItems = elements.Odd();

================================================================================

DOM TRAVERSAL
=============

Every INode provides navigation properties:

    // Parent
    INode parent = element.Parent;
    IElement parentEl = element.ParentElement;

    // Children
    INodeList children = element.ChildNodes;
    INode first = element.FirstChild;
    INode last = element.LastChild;

    // Siblings
    INode next = element.NextSibling;
    INode prev = element.PreviousSibling;

    // For IElement specifically (via IChildNode and INonDocumentTypeChildNode)
    IElement nextEl = element.NextElementSibling;
    IElement prevEl = element.PreviousElementSibling;

Extension methods in NodeExtensions:

    using CodeBrix.MarkupParse.Dom;

    // Get all descendants in tree order
    IEnumerable<INode> descendants = element.GetDescendants();
    IEnumerable<INode> withSelf = element.GetDescendantsAndSelf();

    // Get all ancestors up to the root
    IEnumerable<INode> ancestors = element.GetAncestors();

    // Get the root node
    INode root = element.GetRoot();

    // Relationship checks
    bool isDesc = node.IsDescendantOf(parent);
    bool isAnc = parent.IsAncestorOf(node);
    bool contains = parent.Contains(child);

================================================================================

DOM MANIPULATION
================

1. CREATING ELEMENTS
---------------------

    // Create elements via the document
    IElement p = document.CreateElement("p");
    IElement div = document.CreateElement("div");
    IText textNode = document.CreateTextNode("Hello World");
    IComment comment = document.CreateComment("This is a comment");

    // Create with namespace
    IElement svgEl = document.CreateElement("http://www.w3.org/2000/svg", "svg");


2. APPENDING AND INSERTING
---------------------------

    // Append a child to an element
    document.Body.AppendChild(p);

    // Insert before a reference node
    parent.InsertBefore(newNode, referenceNode);

    // Extension methods for convenience
    parent.PrependNodes(node1, node2);      // Prepend to beginning
    parent.AppendNodes(node1, node2);       // Append to end
    child.InsertBefore(node1, node2);       // Insert before child
    child.InsertAfter(node1, node2);        // Insert after child


3. REMOVING AND REPLACING
--------------------------

    // Remove a child
    parent.RemoveChild(child);

    // Replace a child
    parent.ReplaceChild(newChild, oldChild);

    // Remove self (via IChildNode extension)
    element.Remove();

    // Replace self with other nodes
    element.Replace(newNode1, newNode2);


4. MODIFYING ATTRIBUTES
-------------------------

    // Get/set attributes
    string href = element.GetAttribute("href");
    element.SetAttribute("class", "highlight active");
    element.RemoveAttribute("style");
    bool hasHref = element.HasAttribute("href");

    // ID and class shortcuts
    element.Id = "myElement";
    element.ClassName = "foo bar";
    element.ClassList.Add("baz");
    element.ClassList.Remove("foo");
    element.ClassList.Toggle("active");
    bool hasClass = element.ClassList.Contains("bar");

    // Access all attributes
    INamedNodeMap attrs = element.Attributes;
    foreach (var attr in attrs)
    {
        Console.WriteLine($"{attr.Name} = {attr.Value}");
    }


5. MODIFYING CONTENT
---------------------

    // Text content (strips all HTML, gets/sets plain text)
    string text = element.TextContent;
    element.TextContent = "New text content";

    // Inner HTML (gets/sets the HTML content inside the element)
    string inner = element.InnerHtml;
    element.InnerHtml = "<strong>Bold</strong> text";

    // Outer HTML (gets/sets the element itself including its tag)
    string outer = element.OuterHtml;

    // Insert adjacent HTML
    element.Insert(AdjacentPosition.BeforeBegin, "<p>Before</p>");
    element.Insert(AdjacentPosition.AfterBegin, "<p>First child</p>");
    element.Insert(AdjacentPosition.BeforeEnd, "<p>Last child</p>");
    element.Insert(AdjacentPosition.AfterEnd, "<p>After</p>");


6. CLONING
-----------

    // Deep clone (includes all descendants)
    INode deepClone = element.Clone(deep: true);

    // Shallow clone (element only, no children)
    INode shallowClone = element.Clone(deep: false);

================================================================================

HTML SERIALIZATION (OUTPUT FORMATTING)
======================================

CodeBrix.MarkupParse provides four built-in markup formatters for
serializing the DOM back to HTML:

1. HtmlMarkupFormatter (default) - Standard HTML5 serialization
2. PrettyMarkupFormatter - Indented, human-readable output
3. MinifyMarkupFormatter - Whitespace-minimized output
4. XhtmlMarkupFormatter - XHTML-compliant output

Using formatters:

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Html;
    using CodeBrix.MarkupParse.Xhtml;

    // Default HTML output (used by ToHtml(), OuterHtml, InnerHtml)
    string html = document.ToHtml();
    // or equivalently:
    string html = document.ToHtml(HtmlMarkupFormatter.Instance);

    // Pretty-printed output
    string pretty = document.ToHtml(new PrettyMarkupFormatter());

    // Minified output
    string minified = document.ToHtml(new MinifyMarkupFormatter());

    // XHTML output
    string xhtml = document.ToHtml(XhtmlMarkupFormatter.Instance);

    // Any IMarkupFormattable node can use ToHtml()
    string elementHtml = element.ToHtml();
    string prettyElement = element.ToHtml(new PrettyMarkupFormatter());

    // Write to a TextWriter or Stream
    document.ToHtml(textWriter);
    await document.ToHtmlAsync(stream);

PrettyMarkupFormatter options:

    var formatter = new PrettyMarkupFormatter
    {
        Indentation = "\t",    // or "  " for 2-space indent
        NewLine = "\n",
    };

MinifyMarkupFormatter options:

    var formatter = new MinifyMarkupFormatter
    {
        ShouldKeepStandardElements = false,    // Remove implied html/head/body
        ShouldKeepComments = false,            // Strip comments
        ShouldKeepAttributeQuotes = false,     // Remove unnecessary quotes
    };

XhtmlMarkupFormatter options:

    // Default: convert empty tags to self-closing
    var formatter = new XhtmlMarkupFormatter();                // <div /> for empty divs
    var formatter = new XhtmlMarkupFormatter(false);           // <div></div> for empty divs

================================================================================

SOURCE POSITION TRACKING
=========================

Track where each element appeared in the original source:

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Dom;
    using CodeBrix.MarkupParse.Text;

    // Option 1: Via ISourceReference (requires IsKeepingSourceReferences)
    var parser = new HtmlParser(new HtmlParserOptions
    {
        IsKeepingSourceReferences = true,
    });
    var document = parser.ParseDocument("<!doctype html><body>");
    var bodyPos = document.Body.SourceReference.Position;
    // bodyPos.Line == 1, bodyPos.Column == 16, bodyPos.Position == 16

    // Option 2: Via OnCreated callback
    var bodyPos = TextPosition.Empty;
    var parser = new HtmlParser(new HtmlParserOptions
    {
        OnCreated = (IElement element, TextPosition position) =>
        {
            if (element.TagName == "BODY")
            {
                bodyPos = position;
            }
        },
    });

    // Option 3: Via OnToken callback (gives start AND end positions)
    var parser = new HtmlParser(new HtmlParserOptions
    {
        OnToken = (HtmlToken token, TextRange range) =>
        {
            if (token.Name == "body")
            {
                var start = range.Start;  // TextPosition
                var end = range.End;      // TextPosition
            }
        },
    });

TextPosition properties:
  - Line: 1-based line number
  - Column: 1-based column number
  - Position: 1-based character offset from start of source

================================================================================

CONFIGURATION
=============

Configuration is immutable and fluent. Each With/Without call returns a
NEW configuration instance.

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Io;

    // Default configuration (no HTTP loading, no cookies)
    var config = Configuration.Default;

    // Enable HTTP document loading
    var config = Configuration.Default.WithDefaultLoader();

    // Enable HTTP loading with resource loading (images, stylesheets, etc.)
    var config = Configuration.Default.WithDefaultLoader(new LoaderOptions
    {
        IsResourceLoadingEnabled = true,
    });

    // Enable cookies
    var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();

    // Set culture/locale
    var config = Configuration.Default.WithCulture("en-US");

    // Enable meta refresh handling
    var config = Configuration.Default.WithMetaRefresh();

    // Enable locale-based encoding detection
    var config = Configuration.Default.WithLocaleBasedEncoding();

    // Add a custom service
    var config = Configuration.Default.With(myService);

    // Remove a service type
    var config = Configuration.Default.Without<IRequester>();

    // Check if a service is registered
    bool hasLoader = config.Has<IDocumentLoader>();

================================================================================

KEY DOCUMENT PROPERTIES
=======================

After parsing, the IDocument / IHtmlDocument provides:

    document.Title                    // The <title> text
    document.Head                     // The <head> element (IHtmlHeadElement)
    document.Body                     // The <body> element (IHtmlElement)
    document.DocumentElement          // The <html> root element
    document.All                      // All elements in the document
    document.Forms                    // All <form> elements
    document.Images                   // All <img> elements
    document.Scripts                  // All <script> elements
    document.Anchors                  // All <a name="..."> elements
    document.Links                    // All <a href="..."> and <area href="..."> elements
    document.Url                      // The document URL
    document.CharacterSet             // The character encoding
    document.ContentType              // The MIME type
    document.Doctype                  // The DOCTYPE declaration
    document.ReadyState               // Loading state
    document.Cookie                   // Document cookies
    document.Referrer                 // The referrer URL
    document.Source                   // The underlying TextSource

    // Query methods
    document.GetElementById("id")
    document.GetElementsByClassName("class")
    document.GetElementsByTagName("tag")
    document.GetElementsByName("name")
    document.QuerySelector("css-selector")
    document.QuerySelectorAll("css-selector")

    // Creation methods
    document.CreateElement("tag")
    document.CreateTextNode("text")
    document.CreateComment("comment")
    document.CreateDocumentFragment()
    document.CreateAttribute("name")

================================================================================

KEY ELEMENT PROPERTIES
======================

Every IElement provides:

    element.TagName                   // Tag name in uppercase (e.g., "DIV")
    element.LocalName                 // Tag name in lowercase (e.g., "div")
    element.Id                        // The id attribute value
    element.ClassName                 // The class attribute value (space-separated)
    element.ClassList                 // ITokenList of class names
    element.Attributes                // INamedNodeMap of all attributes
    element.InnerHtml                 // HTML content inside this element
    element.OuterHtml                 // This element's complete HTML
    element.TextContent               // All text content (no HTML tags)
    element.NamespaceUri              // The element's namespace
    element.Prefix                    // The namespace prefix, if any
    element.Parent                    // Parent INode
    element.ParentElement             // Parent IElement
    element.ChildNodes                // All child INodes
    element.Children                  // Child IElements only (IParentNode)
    element.FirstChild                // First child INode
    element.LastChild                 // Last child INode
    element.FirstElementChild         // First child IElement (IParentNode)
    element.LastElementChild          // Last child IElement (IParentNode)
    element.NextSibling               // Next sibling INode
    element.PreviousSibling           // Previous sibling INode
    element.NextElementSibling        // Next sibling IElement
    element.PreviousElementSibling    // Previous sibling IElement
    element.ChildElementCount         // Number of child elements (IParentNode)
    element.NodeType                  // NodeType enum value
    element.NodeName                  // Same as TagName for elements
    element.SourceReference           // ISourceReference (if tracking enabled)

================================================================================

EXTENSION METHODS REFERENCE
============================

The library provides several important extension method classes. Always
include the correct "using" directive to access them.

--- FormatExtensions (namespace: CodeBrix.MarkupParse) ---

    string html = node.ToHtml();                              // Serialize to HTML string
    string html = node.ToHtml(formatter);                     // Serialize with custom formatter
    node.ToHtml(textWriter);                                  // Write to TextWriter
    node.ToHtml(textWriter, formatter);                       // Write with formatter
    await node.ToHtmlAsync(stream);                           // Async write to stream

--- NodeExtensions (namespace: CodeBrix.MarkupParse.Dom) ---

    string text = element.Text();                             // Get text content (same as TextContent)
    elements.Text("new text");                                // Set text on multiple elements
    INode root = node.GetRoot();                              // Get root node
    IEnumerable<INode> desc = node.GetDescendants();          // All descendants
    IEnumerable<INode> anc = node.GetAncestors();             // All ancestors
    bool isDesc = node.IsDescendantOf(parent);                // Check descendant relationship
    bool isAnc = parent.IsAncestorOf(node);                   // Check ancestor relationship
    Url url = node.HyperReference("relative/path");           // Resolve relative URL

--- SelectorExtensions (namespace: CodeBrix.MarkupParse.Dom) ---

    elements.Eq(index)                                        // Element at index
    elements.Gt(index)                                        // Elements after index
    elements.Lt(index)                                        // Elements before index
    elements.Even()                                           // Even-indexed elements
    elements.Odd()                                            // Odd-indexed elements

--- BrowsingContextExtensions (namespace: CodeBrix.MarkupParse) ---

    await context.OpenAsync("https://example.com");           // Load from URL
    await context.OpenAsync(req => req.Content("<html>"));    // Load from virtual response
    await context.OpenNewAsync();                             // Open blank document

--- ConfigurationExtensions (namespace: CodeBrix.MarkupParse) ---

    config.WithDefaultLoader()                                // Enable HTTP loading
    config.WithDefaultLoader(new LoaderOptions { ... })       // With loader options
    config.WithDefaultCookies()                               // Enable cookies
    config.WithCulture("en-US")                               // Set culture
    config.WithMetaRefresh()                                  // Enable meta refresh
    config.WithLocaleBasedEncoding()                          // Locale-based encoding
    config.With(service)                                      // Add a service
    config.Without<TService>()                                // Remove a service type
    config.Has<TService>()                                    // Check for a service

--- HtmlParserExtensions (namespace: CodeBrix.MarkupParse.Html.Parser) ---

    await parser.ParseDocumentAsync(source);                  // Async parse (no cancellation token)
    await parser.ParseHeadAsync(source);                      // Async head parse

================================================================================

COMPLETE EXAMPLES
=================

Example 1: Parse HTML and Extract Data
---------------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using System.Linq;

    var parser = new HtmlParser();
    var document = parser.ParseDocument(@"
        <html>
        <body>
            <h1>Products</h1>
            <ul>
                <li class='product' data-price='10.99'>Widget</li>
                <li class='product' data-price='24.99'>Gadget</li>
                <li class='product sale' data-price='7.50'>Doohickey</li>
            </ul>
        </body>
        </html>");

    // Get all product names
    var products = document.QuerySelectorAll("li.product")
        .Select(el => new
        {
            Name = el.TextContent,
            Price = el.GetAttribute("data-price"),
            OnSale = el.ClassList.Contains("sale")
        });


Example 2: Manipulate the DOM
------------------------------

    using CodeBrix.MarkupParse.Html.Parser;

    var parser = new HtmlParser();
    var document = parser.ParseDocument("<h1>Hello</h1><p>World</p>");

    // Add a new paragraph
    var p = document.CreateElement("p");
    p.TextContent = "Added dynamically";
    p.SetAttribute("class", "dynamic");
    document.Body.AppendChild(p);

    // Modify existing elements
    var h1 = document.QuerySelector("h1");
    h1.TextContent = "Modified Title";
    h1.SetAttribute("id", "main-title");

    // Remove an element
    var oldP = document.QuerySelector("p");
    oldP.Remove();

    Console.WriteLine(document.Body.InnerHtml);


Example 3: Query with CSS Selectors
-------------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using System.Linq;

    var parser = new HtmlParser();
    var document = parser.ParseDocument(
        "<ul><li>First<li>Second<li class='blue'>Third<li class='blue red'>Fourth</ul>");

    // CSS selector query
    var blueItems = document.QuerySelectorAll("li.blue");
    var texts = blueItems.Select(m => m.TextContent).ToList();
    // texts == ["Third", "Fourth"]

    // Single element query
    var first = document.QuerySelector("li:first-child");
    // first.TextContent == "First"

    // Typed query
    var form = document.QuerySelector<IHtmlFormElement>("form");  // null if no form


Example 4: Pretty-Print HTML
-------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Html;

    var parser = new HtmlParser();
    var document = parser.ParseDocument("<div><p>Hello</p><p>World</p></div>");

    var pretty = document.ToHtml(new PrettyMarkupFormatter());
    Console.WriteLine(pretty);


Example 5: Minify HTML
-----------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Html;

    var parser = new HtmlParser();
    var document = parser.ParseDocument(@"
        <html>
            <head><title>Test</title></head>
            <body>
                <p>  Hello   World  </p>
            </body>
        </html>");

    var minified = document.ToHtml(new MinifyMarkupFormatter
    {
        ShouldKeepStandardElements = false,
        ShouldKeepComments = false,
    });


Example 6: Convert HTML to XHTML
----------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Xhtml;

    var parser = new HtmlParser();
    var document = parser.ParseDocument("<br><img src='photo.jpg'><input type='text'>");

    var xhtml = document.ToHtml(XhtmlMarkupFormatter.Instance);
    // Self-closing tags will be properly closed: <br />, <img ... />, <input ... />


Example 7: Load a Web Page and Scrape Data
--------------------------------------------

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Dom;
    using System.Linq;

    var config = Configuration.Default.WithDefaultLoader();
    var context = BrowsingContext.New(config);
    var document = await context.OpenAsync("https://en.wikipedia.org/wiki/Main_Page");

    var title = document.Title;
    var links = document.QuerySelectorAll("a[href]")
        .Select(a => a.GetAttribute("href"))
        .Where(href => href.StartsWith("http"))
        .Distinct()
        .ToList();


Example 8: Track Source Positions
-----------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Dom;
    using CodeBrix.MarkupParse.Text;

    var parser = new HtmlParser(new HtmlParserOptions
    {
        IsKeepingSourceReferences = true,
    });
    var document = parser.ParseDocument("<!doctype html>\n<body>\n  <p>Hello</p>\n</body>");

    var p = document.QuerySelector("p");
    var pos = p.SourceReference.Position;
    Console.WriteLine($"<p> found at Line {pos.Line}, Column {pos.Column}, Offset {pos.Position}");


Example 9: Extract All Links from HTML
-----------------------------------------

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Html.Dom;
    using System.Linq;

    var parser = new HtmlParser();
    var document = parser.ParseDocument(htmlString);

    var links = document.QuerySelectorAll<IHtmlAnchorElement>("a")
        .Select(a => new { Text = a.TextContent, Href = a.Href })
        .ToList();


Example 10: Create HTML from Scratch
--------------------------------------

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Html;

    var context = BrowsingContext.New();
    var document = await context.OpenNewAsync();

    document.Title = "My Page";

    var h1 = document.CreateElement("h1");
    h1.TextContent = "Welcome";
    document.Body.AppendChild(h1);

    var p = document.CreateElement("p");
    p.InnerHtml = "This is <strong>important</strong> content.";
    document.Body.AppendChild(p);

    Console.WriteLine(document.ToHtml(new PrettyMarkupFormatter()));

================================================================================

PERFORMANCE TIPS FOR CODING AGENTS
====================================

1. REUSE THE PARSER: HtmlParser instances are lightweight and can be
   reused across multiple ParseDocument() calls. Don't create a new
   parser for each document unless you need different options.

2. USE ParseHead() WHEN POSSIBLE: If you only need metadata from <head>
   (title, meta tags, link tags), use ParseHead() instead of
   ParseDocument(). It stops parsing once the head is complete.

3. USE SPECIFIC CSS SELECTORS: QuerySelector("div.content > p.intro")
   is faster than QuerySelectorAll("*") followed by LINQ filtering.
   Let the CSS selector engine do the filtering.

4. AVOID UNNECESSARY ToHtml() CALLS: Serializing the DOM to a string is
   relatively expensive. If you only need to read data, use TextContent
   or InnerHtml properties directly rather than serializing the entire
   document.

5. PREFER QuerySelector OVER QuerySelectorAll: If you only need the
   first matching element, use QuerySelector() which stops at the first
   match, rather than QuerySelectorAll() which finds all matches.

6. DISPOSE DOCUMENTS FROM BrowsingContext: When loading documents from
   URLs via BrowsingContext.OpenAsync(), dispose the document when done
   to release HTTP resources.

7. NO EXTERNAL DEPENDENCIES: This library is self-contained. You do NOT
   need to install any native libraries, platform-specific packages, or
   runtime dependencies. Just add the NuGet package and it works.

8. CROSS-PLATFORM: Code written with CodeBrix.MarkupParse works on
   Windows, Linux, and macOS without modification.

================================================================================

COMMON PITFALLS TO AVOID
=========================

1. DO NOT confuse the NuGet package name with the namespace.
   - Package:   CodeBrix.MarkupParse.MitLicenseForever
   - Namespace: CodeBrix.MarkupParse

2. DO NOT use AngleSharp namespaces. Even though this is a fork, all
   namespaces are CodeBrix.MarkupParse.*. There are no AngleSharp.*
   namespaces in this library.

3. DO NOT forget "using CodeBrix.MarkupParse.Dom;" when using
   QuerySelector, QuerySelectorAll, Text(), or other extension methods
   that live in that namespace.

4. DO NOT forget "using CodeBrix.MarkupParse.Html.Parser;" when using
   HtmlParser directly or when calling async parse extension methods.

5. DO NOT target .NET versions below 10.0. This library requires .NET 10+.

6. DO NOT forget to call .WithDefaultLoader() before using
   BrowsingContext.OpenAsync() with URLs. Without it, URL loading
   will not work.

7. DO NOT confuse TextContent and InnerHtml.
   - TextContent returns plain text (no HTML tags), recursively from all
     descendant text nodes.
   - InnerHtml returns the HTML markup of the element's children.
   - OuterHtml returns the element itself plus its InnerHtml.

8. DO NOT confuse TagName and LocalName.
   - TagName returns the tag in UPPERCASE (e.g., "DIV", "BODY").
   - LocalName returns the tag in lowercase (e.g., "div", "body").
   - When comparing tag names, use LocalName or case-insensitive comparison.

9. DO NOT expect QuerySelector to return a non-null value without
   checking. It returns null if no match is found. Always null-check
   the result.

10. DO NOT expect CSS selectors like :hover, :active, or :focus to
    match any elements. These are interaction-state pseudo-classes that
    require a rendering engine. CodeBrix.MarkupParse is a parser, not a
    browser, so these will always return no matches.

11. DO NOT try to use this library for CSS stylesheet parsing. It
    parses CSS selectors for QuerySelector/QuerySelectorAll operations,
    but it does NOT parse CSS property declarations, rules, or
    stylesheets.

12. DO NOT confuse the ToHtml() extension method with the OuterHtml
    property. They produce the same output when called on an element
    with the default formatter, but ToHtml() accepts a custom
    IMarkupFormatter parameter for alternative output formats (pretty,
    minified, XHTML).

================================================================================

COMMON USING STATEMENT COMBINATIONS
=====================================

For most HTML parsing tasks, copy this block:

    using CodeBrix.MarkupParse;
    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Dom;

For typed element access (IHtmlAnchorElement, IHtmlFormElement, etc.):

    using CodeBrix.MarkupParse.Html.Dom;

For custom formatting output, add one or more of:

    using CodeBrix.MarkupParse.Html;     // HtmlMarkupFormatter, PrettyMarkupFormatter, MinifyMarkupFormatter
    using CodeBrix.MarkupParse.Xhtml;    // XhtmlMarkupFormatter

For loading documents from URLs:

    using CodeBrix.MarkupParse;          // BrowsingContext, Configuration, ConfigurationExtensions
    using CodeBrix.MarkupParse.Io;       // LoaderOptions

For source position tracking:

    using CodeBrix.MarkupParse.Text;     // TextPosition, TextRange
    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Html.Parser.Tokens;   // HtmlToken (for OnToken callback)

================================================================================

MINIMUM VIABLE PROJECT TEMPLATE
=================================

To scaffold a new .NET 10 console project that uses CodeBrix.MarkupParse:

    dotnet new console -n MyHtmlParser --framework net10.0
    cd MyHtmlParser
    dotnet add package CodeBrix.MarkupParse.MitLicenseForever

Then in Program.cs:

    using CodeBrix.MarkupParse.Html.Parser;
    using CodeBrix.MarkupParse.Dom;
    using System.Linq;

    var parser = new HtmlParser();
    var html = "<ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul>";
    var document = parser.ParseDocument(html);

    var items = document.QuerySelectorAll("li")
        .Select(li => li.TextContent)
        .ToList();

    foreach (var item in items)
    {
        Console.WriteLine(item);
    }

Build and run:

    dotnet build
    dotnet run

================================================================================

DEEPER LEARNING: TEST FILE CROSS-REFERENCES
=============================================

The CodeBrix.MarkupParse.Tests project in the source repository contains
working code examples for virtually every feature. If the documentation
above is not sufficient for a specific task, fetch and read the relevant
test file from:
    https://github.com/ellisnet/CodeBrix.MarkupParse

Path: tests/CodeBrix.MarkupParse.Tests/

Feature-to-test-file mapping:

Complete usage examples (parsing, querying, DOM manipulation):
    -> tests/CodeBrix.MarkupParse.Tests/Examples/Wiki.cs

README example (loading from URL with BrowsingContext):
    -> tests/CodeBrix.MarkupParse.Tests/Examples/Readme.cs

Source position tracking (OnCreated, OnToken, SourceReference):
    -> tests/CodeBrix.MarkupParse.Tests/Examples/Questions.cs

Form submission:
    -> tests/CodeBrix.MarkupParse.Tests/Examples/Forms.cs

CSS selector querying (comprehensive W3C selector tests):
    -> tests/CodeBrix.MarkupParse.Tests/Css/CssW3CSelector.cs

CSS selector extensions (QuerySelector, QuerySelectorAll):
    -> tests/CodeBrix.MarkupParse.Tests/Css/QueryExtensions.cs

DOM manipulation (element creation, insertion, removal):
    -> tests/CodeBrix.MarkupParse.Tests/Html/DomManipulation.cs
    -> tests/CodeBrix.MarkupParse.Tests/Html/DOM.cs

HTML tokenization and parsing:
    -> tests/CodeBrix.MarkupParse.Tests/Html/HtmlTokenization.cs
    -> tests/CodeBrix.MarkupParse.Tests/Html/HtmlTree.cs

HTML formatting (pretty-print, minify, XHTML):
    -> tests/CodeBrix.MarkupParse.Tests/Library/PrettyMarkupPrinter.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/MinifyFormatter.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/XhtmlFormatter.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/MarkupFormatter.cs

Async parsing:
    -> tests/CodeBrix.MarkupParse.Tests/Library/AsyncParsing.cs

Configuration and BrowsingContext:
    -> tests/CodeBrix.MarkupParse.Tests/Library/BasicConfiguration.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/BrowsingContextTests.cs

Document creation and loading:
    -> tests/CodeBrix.MarkupParse.Tests/Library/DocumentCreation.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/ContextLoading.cs

Parser options:
    -> tests/CodeBrix.MarkupParse.Tests/Library/ParsingOptions.cs

DOM extensions and common operations:
    -> tests/CodeBrix.MarkupParse.Tests/Library/DOMExtensions.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/DOMActions.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/CommonExtensions.cs

Format extensions (ToHtml, Text):
    -> tests/CodeBrix.MarkupParse.Tests/Library/FormatExtensions.cs

Node iteration and tree walking:
    -> tests/CodeBrix.MarkupParse.Tests/Library/NodeIterator.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/TreeWalker.cs

HTML tables:
    -> tests/CodeBrix.MarkupParse.Tests/Html/HtmlTable.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/DOMTable.cs

HTML forms (field values, submission, reset):
    -> tests/CodeBrix.MarkupParse.Tests/Library/FormSetFieldValues.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/FormSubmission.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/FormSubmit.cs
    -> tests/CodeBrix.MarkupParse.Tests/Library/FormReset.cs

SVG and MathML within HTML:
    -> tests/CodeBrix.MarkupParse.Tests/Html/HtmlWithSVG.cs
    -> tests/CodeBrix.MarkupParse.Tests/Html/HtmlWithMathML.cs

URL parsing and validation:
    -> tests/CodeBrix.MarkupParse.Tests/Urls/Url.cs
    -> tests/CodeBrix.MarkupParse.Tests/Urls/UrlValidation.cs

HOW TO USE: Fetch the raw file content from GitHub using a URL like:
    https://raw.githubusercontent.com/ellisnet/CodeBrix.MarkupParse/main/{path}

For example:
    https://raw.githubusercontent.com/ellisnet/CodeBrix.MarkupParse/main/tests/CodeBrix.MarkupParse.Tests/Examples/Wiki.cs

================================================================================

QUICK REFERENCE CARD
=====================

Install:        dotnet add package CodeBrix.MarkupParse.MitLicenseForever
Parse string:   var doc = new HtmlParser().ParseDocument(html);
Parse stream:   var doc = new HtmlParser().ParseDocument(stream);
Parse async:    var doc = await new HtmlParser().ParseDocumentAsync(html);
Parse head:     var head = new HtmlParser().ParseHead(html);
Parse fragment: var nodes = new HtmlParser().ParseFragment(html, contextElement);
Load URL:       var doc = await BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(url);

Query first:    var el = doc.QuerySelector("css-selector");
Query all:      var els = doc.QuerySelectorAll("css-selector");
By ID:          var el = doc.GetElementById("id");
By class:       var els = doc.GetElementsByClassName("class");
By tag:         var els = doc.GetElementsByTagName("tag");

Get text:       string text = element.TextContent;
Get inner:      string inner = element.InnerHtml;
Get outer:      string outer = element.OuterHtml;
Set text:       element.TextContent = "new text";
Set inner:      element.InnerHtml = "<b>new</b>";

Get attr:       string val = element.GetAttribute("name");
Set attr:       element.SetAttribute("name", "value");
Has attr:       bool has = element.HasAttribute("name");
Remove attr:    element.RemoveAttribute("name");

Get class:      bool has = element.ClassList.Contains("cls");
Add class:      element.ClassList.Add("cls");
Remove class:   element.ClassList.Remove("cls");
Toggle class:   element.ClassList.Toggle("cls");

Create:         var el = doc.CreateElement("tag");
Append:         parent.AppendChild(child);
Remove:         parent.RemoveChild(child);
Replace:        parent.ReplaceChild(newChild, oldChild);
Clone:          var copy = element.Clone(deep: true);

To HTML:        string html = node.ToHtml();
Pretty:         string html = node.ToHtml(new PrettyMarkupFormatter());
Minified:       string html = node.ToHtml(new MinifyMarkupFormatter());
XHTML:          string html = node.ToHtml(XhtmlMarkupFormatter.Instance);

Target:         .NET 10.0+
Package:        CodeBrix.MarkupParse.MitLicenseForever
Namespaces:     CodeBrix.MarkupParse, CodeBrix.MarkupParse.Html.Parser, CodeBrix.MarkupParse.Dom

================================================================================
