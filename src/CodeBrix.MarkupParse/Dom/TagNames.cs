using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Html;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The collection of (known / used) tags.
/// </summary>
public static class TagNames
{
    #region General / Special

    /// <summary>
    /// Gets the DOCTYPE constant.
    /// </summary>
    public static readonly string Doctype = "DOCTYPE";

    #endregion

    #region HTML Tags

    /// <summary>
    /// The html tag.
    /// </summary>
    public static readonly string Html = "html";

    /// <summary>
    /// The body tag.
    /// </summary>
    public static readonly string Body = "body";

    /// <summary>
    /// The head tag.
    /// </summary>
    public static readonly string Head = "head";

    /// <summary>
    /// The meta tag.
    /// </summary>
    public static readonly string Meta = "meta";

    /// <summary>
    /// The title tag.
    /// </summary>
    public static readonly string Title = "title";

    /// <summary>
    /// The bgsound tag.
    /// </summary>
    public static readonly string Bgsound = "bgsound";

    /// <summary>
    /// The script tag.
    /// </summary>
    public static readonly string Script = "script";

    /// <summary>
    /// The style tag.
    /// </summary>
    public static readonly string Style = "style";

    /// <summary>
    /// The noembed tag.
    /// </summary>
    public static readonly string NoEmbed = "noembed";

    /// <summary>
    /// The noscript tag.
    /// </summary>
    public static readonly string NoScript = "noscript";

    /// <summary>
    /// The noframes tag.
    /// </summary>
    public static readonly string NoFrames = "noframes";

    /// <summary>
    /// The menu tag.
    /// </summary>
    public static readonly string Menu = "menu";

    /// <summary>
    /// The menuitem tag.
    /// </summary>
    public static readonly string MenuItem = "menuitem";

    /// <summary>
    /// The var tag.
    /// </summary>
    public static readonly string Var = "var";

    /// <summary>
    /// The ruby tag.
    /// </summary>
    public static readonly string Ruby = "ruby";

    /// <summary>
    /// The sub tag.
    /// </summary>
    public static readonly string Sub = "sub";

    /// <summary>
    /// The sup tag.
    /// </summary>
    public static readonly string Sup = "sup";

    /// <summary>
    /// The rp tag.
    /// </summary>
    public static readonly string Rp = "rp";

    /// <summary>
    /// The rt tag.
    /// </summary>
    public static readonly string Rt = "rt";

    /// <summary>
    /// The rb tag.
    /// </summary>
    public static readonly string Rb = "rb";

    /// <summary>
    /// The rtc tag.
    /// </summary>
    public static readonly string Rtc = "rtc";

    /// <summary>
    /// The applet tag.
    /// </summary>
    public static readonly string Applet = "applet";

    /// <summary>
    /// The embed tag.
    /// </summary>
    public static readonly string Embed = "embed";

    /// <summary>
    /// The marquee tag.
    /// </summary>
    public static readonly string Marquee = "marquee";

    /// <summary>
    /// The param tag.
    /// </summary>
    public static readonly string Param = "param";

    /// <summary>
    /// The object tag.
    /// </summary>
    public static readonly string Object = "object";

    /// <summary>
    /// The canvas tag.
    /// </summary>
    public static readonly string Canvas = "canvas";

    /// <summary>
    /// The font tag.
    /// </summary>
    public static readonly string Font = "font";

    /// <summary>
    /// The ins tag.
    /// </summary>
    public static readonly string Ins = "ins";

    /// <summary>
    /// The del tag.
    /// </summary>
    public static readonly string Del = "del";

    /// <summary>
    /// The template tag.
    /// </summary>
    public static readonly string Template = "template";

    /// <summary>
    /// The slot tag.
    /// </summary>
    public static readonly string Slot = "slot";

    /// <summary>
    /// The caption tag.
    /// </summary>
    public static readonly string Caption = "caption";

    /// <summary>
    /// The col tag.
    /// </summary>
    public static readonly string Col = "col";

    /// <summary>
    /// The colgroup tag.
    /// </summary>
    public static readonly string Colgroup = "colgroup";

    /// <summary>
    /// The table tag.
    /// </summary>
    public static readonly string Table = "table";

    /// <summary>
    /// The thead tag.
    /// </summary>
    public static readonly string Thead = "thead";

    /// <summary>
    /// The tbody tag.
    /// </summary>
    public static readonly string Tbody = "tbody";

    /// <summary>
    /// The tfoot tag.
    /// </summary>
    public static readonly string Tfoot = "tfoot";

    /// <summary>
    /// The th tag.
    /// </summary>
    public static readonly string Th = "th";

    /// <summary>
    /// The td tag.
    /// </summary>
    public static readonly string Td = "td";

    /// <summary>
    /// The tr tag.
    /// </summary>
    public static readonly string Tr = "tr";

    /// <summary>
    /// The input tag.
    /// </summary>
    public static readonly string Input = "input";

    /// <summary>
    /// The keygen tag.
    /// </summary>
    public static readonly string Keygen = "keygen";

    /// <summary>
    /// The textarea tag.
    /// </summary>
    public static readonly string Textarea = "textarea";

    /// <summary>
    /// The p tag.
    /// </summary>
    public static readonly string P = "p";

    /// <summary>
    /// The span tag.
    /// </summary>
    public static readonly string Span = "span";

    /// <summary>
    /// The dialog tag.
    /// </summary>
    public static readonly string Dialog = "dialog";

    /// <summary>
    /// The fieldset tag.
    /// </summary>
    public static readonly string Fieldset = "fieldset";

    /// <summary>
    /// The legend tag.
    /// </summary>
    public static readonly string Legend = "legend";

    /// <summary>
    /// The label tag.
    /// </summary>
    public static readonly string Label = "label";

    /// <summary>
    /// The details tag.
    /// </summary>
    public static readonly string Details = "details";

    /// <summary>
    /// The form tag.
    /// </summary>
    public static readonly string Form = "form";

    /// <summary>
    /// The isindex tag.
    /// </summary>
    public static readonly string IsIndex = "isindex";

    /// <summary>
    /// The pre tag.
    /// </summary>
    public static readonly string Pre = "pre";

    /// <summary>
    /// The data tag.
    /// </summary>
    public static readonly string Data = "data";

    /// <summary>
    /// The datalist tag.
    /// </summary>
    public static readonly string Datalist = "datalist";

    /// <summary>
    /// The ol tag.
    /// </summary>
    public static readonly string Ol = "ol";

    /// <summary>
    /// The tag ul.
    /// </summary>
    public static readonly string Ul = "ul";

    /// <summary>
    /// The dl tag.
    /// </summary>
    public static readonly string Dl = "dl";

    /// <summary>
    /// The li tag.
    /// </summary>
    public static readonly string Li = "li";

    /// <summary>
    /// The dd tag.
    /// </summary>
    public static readonly string Dd = "dd";

    /// <summary>
    /// The dt tag.
    /// </summary>
    public static readonly string Dt = "dt";

    /// <summary>
    /// The b tag.
    /// </summary>
    public static readonly string B = "b";

    /// <summary>
    /// The big tag.
    /// </summary>
    public static readonly string Big = "big";

    /// <summary>
    /// The strike tag.
    /// </summary>
    public static readonly string Strike = "strike";

    /// <summary>
    /// The code tag.
    /// </summary>
    public static readonly string Code = "code";

    /// <summary>
    /// The em tag.
    /// </summary>
    public static readonly string Em = "em";

    /// <summary>
    /// The i tag.
    /// </summary>
    public static readonly string I = "i";

    /// <summary>
    /// The s tag.
    /// </summary>
    public static readonly string S = "s";

    /// <summary>
    /// The small tag.
    /// </summary>
    public static readonly string Small = "small";

    /// <summary>
    /// The strong tag.
    /// </summary>
    public static readonly string Strong = "strong";

    /// <summary>
    /// The u tag.
    /// </summary>
    public static readonly string U = "u";

    /// <summary>
    /// The tt tag.
    /// </summary>
    public static readonly string Tt = "tt";

    /// <summary>
    /// The nobr tag.
    /// </summary>
    public static readonly string NoBr = "nobr";

    /// <summary>
    /// The select tag.
    /// </summary>
    public static readonly string Select = "select";

    /// <summary>
    /// The select tag.
    /// </summary>
    public static readonly string SelectedContent = "selectedcontent";

    /// <summary>
    /// The option tag.
    /// </summary>
    public static readonly string Option = "option";

    /// <summary>
    /// The optgroup tag.
    /// </summary>
    public static readonly string Optgroup = "optgroup";

    /// <summary>
    /// The link tag.
    /// </summary>
    public static readonly string Link = "link";

    /// <summary>
    /// The frameset tag.
    /// </summary>
    public static readonly string Frameset = "frameset";

    /// <summary>
    /// The frame tag.
    /// </summary>
    public static readonly string Frame = "frame";

    /// <summary>
    /// The iframe tag.
    /// </summary>
    public static readonly string Iframe = "iframe";

    /// <summary>
    /// The audio tag.
    /// </summary>
    public static readonly string Audio = "audio";

    /// <summary>
    /// The video tag.
    /// </summary>
    public static readonly string Video = "video";

    /// <summary>
    /// The source tag.
    /// </summary>
    public static readonly string Source = "source";

    /// <summary>
    /// The track tag.
    /// </summary>
    public static readonly string Track = "track";

    /// <summary>
    /// The h1 tag.
    /// </summary>
    public static readonly string H1 = "h1";

    /// <summary>
    /// The h2 tag.
    /// </summary>
    public static readonly string H2 = "h2";

    /// <summary>
    /// The h3 tag.
    /// </summary>
    public static readonly string H3 = "h3";

    /// <summary>
    /// The h4 tag.
    /// </summary>
    public static readonly string H4 = "h4";

    /// <summary>
    /// The h5 tag.
    /// </summary>
    public static readonly string H5 = "h5";

    /// <summary>
    /// The h6 tag.
    /// </summary>
    public static readonly string H6 = "h6";

    /// <summary>
    /// The div tag.
    /// </summary>
    public static readonly string Div = "div";

    /// <summary>
    /// The quote tag.
    /// </summary>
    public static readonly string Quote = "quote";

    /// <summary>
    /// The blockquote tag.
    /// </summary>
    public static readonly string BlockQuote = "blockquote";

    /// <summary>
    /// The q tag.
    /// </summary>
    public static readonly string Q = "q";

    /// <summary>
    /// The base tag.
    /// </summary>
    public static readonly string Base = "base";

    /// <summary>
    /// The basefont tag.
    /// </summary>
    public static readonly string BaseFont = "basefont";

    /// <summary>
    /// The a tag.
    /// </summary>
    public static readonly string A = "a";

    /// <summary>
    /// The area tag.
    /// </summary>
    public static readonly string Area = "area";

    /// <summary>
    /// The button tag.
    /// </summary>
    public static readonly string Button = "button";

    /// <summary>
    /// The cite tag.
    /// </summary>
    public static readonly string Cite = "cite";

    /// <summary>
    /// The main tag.
    /// </summary>
    public static readonly string Main = "main";

    /// <summary>
    /// The summary tag.
    /// </summary>
    public static readonly string Summary = "summary";

    /// <summary>
    /// The xmp tag.
    /// </summary>
    public static readonly string Xmp = "xmp";

    /// <summary>
    /// The br tag.
    /// </summary>
    public static readonly string Br = "br";

    /// <summary>
    /// The wbr tag.
    /// </summary>
    public static readonly string Wbr = "wbr";

    /// <summary>
    /// The hr tag.
    /// </summary>
    public static readonly string Hr = "hr";

    /// <summary>
    /// The dir tag.
    /// </summary>
    public static readonly string Dir = "dir";

    /// <summary>
    /// The center tag.
    /// </summary>
    public static readonly string Center = "center";

    /// <summary>
    /// The listing tag.
    /// </summary>
    public static readonly string Listing = "listing";

    /// <summary>
    /// The img tag.
    /// </summary>
    public static readonly string Img = "img";

    /// <summary>
    /// The image tag (this is not the right tag).
    /// </summary>
    public static readonly string Image = "image";

    /// <summary>
    /// The nav tag.
    /// </summary>
    public static readonly string Nav = "nav";

    /// <summary>
    /// The address tag.
    /// </summary>
    public static readonly string Address = "address";

    /// <summary>
    /// The article tag.
    /// </summary>
    public static readonly string Article = "article";

    /// <summary>
    /// The aside tag.
    /// </summary>
    public static readonly string Aside = "aside";

    /// <summary>
    /// The figcaption tag.
    /// </summary>
    public static readonly string Figcaption = "figcaption";

    /// <summary>
    /// The figure tag.
    /// </summary>
    public static readonly string Figure = "figure";

    /// <summary>
    /// The section tag.
    /// </summary>
    public static readonly string Section = "section";

    /// <summary>
    /// The footer tag.
    /// </summary>
    public static readonly string Footer = "footer";

    /// <summary>
    /// The header tag.
    /// </summary>
    public static readonly string Header = "header";

    /// <summary>
    /// The hgroup tag.
    /// </summary>
    public static readonly string Hgroup = "hgroup";

    /// <summary>
    /// The plaintext tag.
    /// </summary>
    public static readonly string Plaintext = "plaintext";

    /// <summary>
    /// The time tag.
    /// </summary>
    public static readonly string Time = "time";

    /// <summary>
    /// The progress tag.
    /// </summary>
    public static readonly string Progress = "progress";

    /// <summary>
    /// The meter tag.
    /// </summary>
    public static readonly string Meter = "meter";

    /// <summary>
    /// The output tag.
    /// </summary>
    public static readonly string Output = "output";

    /// <summary>
    /// The map tag.
    /// </summary>
    public static readonly string Map = "map";

    /// <summary>
    /// The picture tag.
    /// </summary>
    public static readonly string Picture = "picture";

    /// <summary>
    /// The mark tag.
    /// </summary>
    public static readonly string Mark = "mark";

    /// <summary>
    /// The dfn tag.
    /// </summary>
    public static readonly string Dfn = "dfn";

    /// <summary>
    /// The kbd tag.
    /// </summary>
    public static readonly string Kbd = "kbd";

    /// <summary>
    /// The samp tag.
    /// </summary>
    public static readonly string Samp = "samp";

    /// <summary>
    /// The abbr tag.
    /// </summary>
    public static readonly string Abbr = "abbr";

    /// <summary>
    /// The bdi tag.
    /// </summary>
    public static readonly string Bdi = "bdi";

    /// <summary>
    /// The bdo tag.
    /// </summary>
    public static readonly string Bdo = "bdo";

    #endregion

    #region MathML Tags

    /// <summary>
    /// The math tag.
    /// </summary>
    public static readonly string Math = "math";

    /// <summary>
    /// The mi tag.
    /// </summary>
    public static readonly string Mi = "mi";

    /// <summary>
    /// The mo tag.
    /// </summary>
    public static readonly string Mo = "mo";

    /// <summary>
    /// The mn tag.
    /// </summary>
    public static readonly string Mn = "mn";

    /// <summary>
    /// The ms tag.
    /// </summary>
    public static readonly string Ms = "ms";

    /// <summary>
    /// The mtext tag.
    /// </summary>
    public static readonly string Mtext = "mtext";

    /// <summary>
    /// The annotation-xml tag.
    /// </summary>
    public static readonly string AnnotationXml = "annotation-xml";

    #endregion

    #region SVG Tags

    /// <summary>
    /// The svg tag.
    /// </summary>
    public static readonly string Svg = "svg";

    /// <summary>
    /// The foreignObject tag.
    /// </summary>
    public static readonly string ForeignObject = "foreignObject";

    /// <summary>
    /// The desc tag.
    /// </summary>
    public static readonly string Desc = "desc";

    /// <summary>
    /// The circle tag.
    /// </summary>
    public static readonly string Circle = "circle";

    #endregion

    #region XML Tags

    /// <summary>
    /// The xml tag.
    /// </summary>
    public static readonly string Xml = "xml";

    #endregion

    #region Combinations

    internal static readonly HashSet<StringOrMemory> AllForeignExceptions = new (OrdinalStringOrMemoryComparer.Instance)
    {
        B, Big, BlockQuote, Body, Br, Center, Code, Dd, Div, Dl, Dt, Em, Embed, Head,
        Hr, I, Img, Li, Ul, H3, H2, H4, H1, H6, H5, Listing, Menu, Meta, NoBr, Ol, P,
        Pre, Ruby, S, Small, Span, Strike, Strong, Sub, Sup, Table, Tt, U, Var
    };

    internal static readonly HashSet<StringOrMemory> AllBeforeHead = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Html, Body, Br, Head
    };

    internal static readonly HashSet<StringOrMemory> AllNoShadowRoot = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Button, Details, Input, Marquee, Meter, Progress, Select, Textarea, Keygen
    };

    internal static readonly HashSet<StringOrMemory> AllHead = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Style, Link, Meta, Title, NoFrames, Template, Base, BaseFont, Bgsound
    };

    internal static readonly HashSet<StringOrMemory> AllHeadNoTemplate = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Link, Meta, Script, Style, Title, Base, BaseFont, Bgsound, NoFrames
    };

    internal static readonly HashSet<StringOrMemory> AllHeadBase = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Link, Base, BaseFont, Bgsound
    };

    internal static readonly HashSet<StringOrMemory> AllBodyBreakrow = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Br, Area, Embed, Keygen, Wbr
    };

    internal static readonly HashSet<StringOrMemory> AllBodyClosed = new (OrdinalStringOrMemoryComparer.Instance)
    {
        MenuItem, Param, Source, Track
    };

    internal static readonly HashSet<StringOrMemory> AllNoScript = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Style, Link, BaseFont, Meta, NoFrames, Bgsound
    };

    internal static readonly HashSet<StringOrMemory> AllHeadings = new (OrdinalStringOrMemoryComparer.Instance)
    {
        H3, H2, H4, H1, H6, H5
    };

    internal static readonly HashSet<StringOrMemory> AllBlocks = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Ol, Ul, Dl, Fieldset, Button, Figcaption, Figure, Article, Aside, BlockQuote,
        Center, Address, Dialog, Dir, Summary, Details, Listing, Footer, Header, Nav,
        Section, Menu, Hgroup, Main, Pre
    };

    internal static readonly HashSet<StringOrMemory> AllBody = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Ol, Dl, Fieldset, Figcaption, Figure, Article, Aside, BlockQuote, Center, Address,
        Dialog, Dir, Summary, Details, Main, Footer, Header, Nav, Section, Menu, Hgroup
    };

    internal static readonly HashSet<StringOrMemory> AllBodyObsolete = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Applet, Marquee, Object
    };

    internal static readonly HashSet<StringOrMemory> AllInput = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Input, Keygen, Textarea
    };

    internal static readonly HashSet<StringOrMemory> AllBasicBlocks = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Address, Div, P
    };

    internal static readonly HashSet<StringOrMemory> AllSemanticFormatting = new (OrdinalStringOrMemoryComparer.Instance)
    {
        B, Strong, Code, Em, U, I
    };

    internal static readonly HashSet<StringOrMemory> AllClassicFormatting = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Font, S, Small, Strike, Big, Tt
    };

    internal static readonly HashSet<StringOrMemory> AllFormatting = new (OrdinalStringOrMemoryComparer.Instance)
    {
        B, Strong, Code, Em, U, I, NoBr, Font, S, Small, Strike, Big, Tt
    };

    internal static readonly HashSet<StringOrMemory> AllNested = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Td, Tfoot, Th, Thead, Tr, Caption, Col, Colgroup, Frame, Head
    };

    internal static readonly HashSet<StringOrMemory> AllCaptionEnd = new(OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Col, Tfoot, Td, Thead, Caption, Th, Colgroup, Tr
    };

    internal static readonly HashSet<StringOrMemory> AllCaptionStart = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Col, Tfoot, Td, Thead, Tr, Body, Th, Colgroup, Html
    };

    internal static readonly HashSet<StringOrMemory> AllTable = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Col, Tfoot, Td, Thead, Tr
    };

    internal static readonly HashSet<StringOrMemory> AllTableRoot = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Caption, Colgroup, Tbody, Tfoot, Thead
    };

    internal static readonly HashSet<StringOrMemory> AllTableGeneral = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Caption, Colgroup, Col, Tbody, Tfoot, Thead
    };

    internal static readonly HashSet<StringOrMemory> AllTableSections = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Tfoot, Thead
    };

    internal static readonly HashSet<StringOrMemory> AllTableMajor = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Tfoot, Thead, Table, Tr
    };

    internal static readonly HashSet<StringOrMemory> AllTableSpecial = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Td, Th,  Body, Caption, Col, Colgroup, Html
    };

    internal static readonly HashSet<StringOrMemory> AllTableCore = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tr, Table, Tbody, Tfoot, Thead
    };

    internal static readonly HashSet<StringOrMemory> AllTableInner = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tbody, Tr, Thead, Th, Tfoot, Td
    };

    internal static readonly HashSet<StringOrMemory> AllTableSelects = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tr, Table, Tbody, Tfoot, Thead, Td, Th, Caption
    };

    internal static readonly HashSet<StringOrMemory> AllTableCells = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Td, Th
    };

    internal static readonly HashSet<StringOrMemory> AllTableCellsRows = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Tr, Td, Th
    };

    internal static readonly HashSet<StringOrMemory> AllTableHead = new (OrdinalStringOrMemoryComparer.Instance)
    {
        Script, Style, Template
    };

    internal static readonly HashSet<StringOrMemory> DisallowedCustomElementNames = new (OrdinalStringOrMemoryComparer.Instance)
    {
        "annotation-xml",
        "color-profile",
        "font-face",
        "font-face-src",
        "font-face-uri",
        "font-face-format",
        "font-face-name",
        "missing-glyph"
    };
    
    #endregion
}
