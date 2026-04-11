using System;

namespace CodeBrix.MarkupParse.Text; //Was previously: namespace AngleSharp.Text

/// <summary>
/// Contains useful information from the specification.
/// </summary>
public static class Symbols
{
    /// <summary>
    /// The end of file marker (Char.MaxValue).
    /// </summary>
    public const char EndOfFile = char.MaxValue;

    /// <summary>
    /// The tilde character ( ~ ).
    /// </summary>
    public const char Tilde = (char)0x7e;

    /// <summary>
    /// The pipe character ( | ).
    /// </summary>
    public const char Pipe = (char)0x7c;

    /// <summary>
    /// The null character.
    /// </summary>
    public const char Null = (char)0x0;

    /// <summary>
    /// The ampersand character ( &amp; ).
    /// </summary>
    public const char Ampersand = (char)0x26;

    /// <summary>
    /// The number sign character ( # ).
    /// </summary>
    public const char Num = (char)0x23;

    /// <summary>
    /// The dollar sign character ( $ ).
    /// </summary>
    public const char Dollar = (char)0x24;

    /// <summary>
    /// The semicolon sign ( ; ).
    /// </summary>
    public const char Semicolon = (char)0x3b;

    /// <summary>
    /// The asterisk character ( * ).
    /// </summary>
    public const char Asterisk = (char)0x2a;

    /// <summary>
    /// The equals sign ( = ).
    /// </summary>
    public const char Equality = (char)0x3d;

    /// <summary>
    /// The plus sign ( + ).
    /// </summary>
    public const char Plus = (char)0x2b;

    /// <summary>
    /// The dash ( hypen minus, - ) character.
    /// </summary>
    public const char Minus = (char)0x2d;

    /// <summary>
    /// The comma character ( , ).
    /// </summary>
    public const char Comma = (char)0x2c;

    /// <summary>
    /// The full stop ( . ).
    /// </summary>
    public const char Dot = (char)0x2e;

    /// <summary>
    /// The circumflex accent ( ^ ) character.
    /// </summary>
    public const char Accent = (char)0x5e;

    /// <summary>
    /// The commercial at ( @ ) character.
    /// </summary>
    public const char At = (char)0x40;

    /// <summary>
    /// The opening angle bracket ( LESS-THAN-SIGN ).
    /// </summary>
    public const char LessThan = (char)0x3c;

    /// <summary>
    /// The closing angle bracket ( GREATER-THAN-SIGN ).
    /// </summary>
    public const char GreaterThan = (char)0x3e;

    /// <summary>
    /// The single quote / quotation mark ( ' ).
    /// </summary>
    public const char SingleQuote = (char)0x27;

    /// <summary>
    /// The (double) quotation mark ( " ).
    /// </summary>
    public const char DoubleQuote = (char)0x22;

    /// <summary>
    /// The (curved) quotation mark ( ` ).
    /// </summary>
    public const char CurvedQuote = (char)0x60;

    /// <summary>
    /// The question mark ( ? ).
    /// </summary>
    public const char QuestionMark = (char)0x3f;

    /// <summary>
    /// The tab character.
    /// </summary>
    public const char Tab = (char)0x09;

    /// <summary>
    /// The line feed character.
    /// </summary>
    public const char LineFeed = (char)0x0a;

    /// <summary>
    /// The carriage return character.
    /// </summary>
    public const char CarriageReturn = (char)0x0d;

    /// <summary>
    /// The form feed character.
    /// </summary>
    public const char FormFeed = (char)0x0c;

    /// <summary>
    /// The space character.
    /// </summary>
    public const char Space = (char)0x20;

    /// <summary>
    /// The slash (solidus, /) character.
    /// </summary>
    public const char Solidus = (char)0x2f;

    /// <summary>
    /// The no break space character.
    /// </summary>
    public const char NoBreakSpace = (char)0xa0;

    /// <summary>
    /// The backslash ( reverse-solidus, \ ) character.
    /// </summary>
    public const char ReverseSolidus = (char)0x5c;

    /// <summary>
    /// The colon ( : ) character.
    /// </summary>
    public const char Colon = (char)0x3a;

    /// <summary>
    /// The exclamation mark ( ! ) character.
    /// </summary>
    public const char ExclamationMark = (char)0x21;

    /// <summary>
    /// The replacement character in case of errors.
    /// </summary>
    public const char Replacement = (char)0xfffd;

    /// <summary>
    /// The low line ( _ ) character.
    /// </summary>
    public const char Underscore = (char)0x5f;

    /// <summary>
    /// The round bracket open ( ( ) character.
    /// </summary>
    public const char RoundBracketOpen = (char)0x28;

    /// <summary>
    /// The round bracket close ( ) ) character.
    /// </summary>
    public const char RoundBracketClose = (char)0x29;

    /// <summary>
    /// The square bracket open ( [ ) character.
    /// </summary>
    public const char SquareBracketOpen = (char)0x5b;

    /// <summary>
    /// The square bracket close ( ] ) character.
    /// </summary>
		public const char SquareBracketClose = (char)0x5d;

		/// <summary>
		/// The curly bracket open ( { ) character.
		/// </summary>
		public const char CurlyBracketOpen = (char)0x7b;

		/// <summary>
		/// The curly bracket close ( } ) character.
		/// </summary>
		public const char CurlyBracketClose = (char)0x7d;

    /// <summary>
    /// The percent ( % ) character.
    /// </summary>
    public const char Percent = (char)0x25;

    /// <summary>
    /// The maximum allowed codepoint (defined in Unicode).
    /// </summary>
    public const int MaximumCodepoint = 0x10FFFF;
}
