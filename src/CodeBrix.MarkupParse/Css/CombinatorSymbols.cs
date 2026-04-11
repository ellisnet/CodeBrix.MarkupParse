using System;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// The collection of known CSS selector combinator symbols.
/// </summary>
public static class CombinatorSymbols
{
    /// <summary>
    /// The "=" attribute combinator.
    /// </summary>
    public static readonly string Exactly = "=";

    /// <summary>
    /// The "!=" attribute combinator.
    /// </summary>
    public static readonly string Unlike = "!=";

    /// <summary>
    /// The "~=" attribute combinator.
    /// </summary>
    public static readonly string InList = "~=";

    /// <summary>
    /// The "|=" attribute combinator.
    /// </summary>
    public static readonly string InToken = "|=";

    /// <summary>
    /// The "^=" attribute combinator.
    /// </summary>
    public static readonly string Begins = "^=";

    /// <summary>
    /// The "$=" attribute combinator.
    /// </summary>
    public static readonly string Ends = "$=";

    /// <summary>
    /// The "*=" attribute combinator.
    /// </summary>
    public static readonly string InText = "*=";

    /// <summary>
    /// The "||" combinator.
    /// </summary>
    public static readonly string Column = "||";

    /// <summary>
    /// The "|" combinator.
    /// </summary>
    public static readonly string Pipe = "|";

    /// <summary>
    /// The "+" combinator.
    /// </summary>
    public static readonly string Adjacent = "+";

    /// <summary>
    /// The " " combinator.
    /// </summary>
    [Obsolete("Use CombinatorSymbols.Descendant")]
    public static readonly string Descendent = " ";

    /// <summary>
    /// The " " combinator.
    /// </summary>
    public static readonly string Descendant = " ";

    /// <summary>
    /// The ">>>" combinator.
    /// </summary>
    public static readonly string Deep = ">>>";

    /// <summary>
    /// The ">" combinator.
    /// </summary>
    public static readonly string Child = ">";

    /// <summary>
    /// The "~" combinator.
    /// </summary>
    public static readonly string Sibling = "~";
}
