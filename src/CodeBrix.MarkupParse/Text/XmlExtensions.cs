using CodeBrix.MarkupParse.Common;
using System;

namespace CodeBrix.MarkupParse.Text; //Was previously: namespace AngleSharp.Text

/// <summary>
/// Useful helpers for the XML parser.
/// </summary>
public static class XmlExtensions
{
    /// <summary>
    /// Determines if the given character is a legal character for the public id field:
    /// http://www.w3.org/TR/REC-xml/#NT-PubidChar
    /// </summary>
    /// <param name="c">The character to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsPubidChar(this char c)
    {
        return c.IsAlphanumericAscii() || c == Symbols.Minus || c == Symbols.SingleQuote || c == Symbols.Plus ||
               c == Symbols.Comma || c == Symbols.Dot || c == Symbols.Solidus || c == Symbols.Colon ||
               c == Symbols.QuestionMark || c == Symbols.Equality || c == Symbols.ExclamationMark || c == Symbols.Asterisk ||
               c == Symbols.Num || c == Symbols.At || c == Symbols.Dollar || c == Symbols.Underscore ||
               c == Symbols.RoundBracketOpen || c == Symbols.RoundBracketClose || c == Symbols.Semicolon || c == Symbols.Percent ||
               c.IsSpaceCharacter();
    }

    /// <summary>
    /// Determines if the given character is a legal name start character for XML.
    /// http://www.w3.org/TR/REC-xml/#NT-NameStartChar
    /// </summary>
    /// <param name="c">The character to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsXmlNameStart(this char c)
    {
        return c.IsLetter() || c == Symbols.Colon || c == Symbols.Underscore || c.IsInRange(0xC0, 0xD6) ||
               c.IsInRange(0xD8, 0xF6) || c.IsInRange(0xF8, 0x2FF) || c.IsInRange(0x370, 0x37D) || c.IsInRange(0x37F, 0x1FFF) ||
               c.IsInRange(0x200C, 0x200D) || c.IsInRange(0x2070, 0x218F) || c.IsInRange(0x2C00, 0x2FEF) ||
               c.IsInRange(0x3001, 0xD7FF) || c.IsInRange(0xF900, 0xFDCF) || c.IsInRange(0xFDF0, 0xFFFD) ||
               c.IsInRange(0x10000, 0xEFFFF);
    }

    /// <summary>
    /// Determines if the given character is a name character for XML.
    /// http://www.w3.org/TR/REC-xml/#NT-NameChar
    /// </summary>
    /// <param name="c">The character to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsXmlName(this char c)
    {
        return c.IsXmlNameStart() || c.IsDigit() || c == Symbols.Minus || c == Symbols.Dot || c == 0xB7 ||
               c.IsInRange(0x300, 0x36F) || c.IsInRange(0x203F, 0x2040);
    }

    /// <summary>
    /// Determines if the given string is a valid (local or qualified) name.
    /// </summary>
    /// <param name="str">The string to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsXmlName(this string str)
    {
        return IsXmlName(new StringOrMemory(str));
    }

    /// <summary>
    /// Determines if the given string is a valid (local or qualified) name.
    /// </summary>
    /// <param name="str">The string to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsXmlName(this StringOrMemory str)
    {
        if (str.Length > 0 && str[0].IsXmlNameStart())
        {
            for (var i = 1; i < str.Length; i++)
            {
                if (!str[i].IsXmlName())
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines if the given string is a valid qualified name.
    /// </summary>
    /// <param name="str">The string to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsQualifiedName(this string str)
    {
        return IsQualifiedName(new StringOrMemory(str));
    }

    /// <summary>
    /// Determines if the given string is a valid qualified name.
    /// </summary>
    /// <param name="str">The string to examine.</param>
    /// <returns>The result of the test.</returns>
    public static bool IsQualifiedName(this StringOrMemory str)
    {
        var colon = str.Memory.Span.IndexOf(Symbols.Colon);

        if (colon == -1)
        {
            return str.IsXmlName();
        }

        if (colon > 0 && str[0].IsXmlNameStart())
        {
            for (var i = 1; i < colon; i++)
            {
                if (!str[i].IsXmlName())
                {
                    return false;
                }
            }

            colon++;
        }

        if (str.Length > colon && str[colon++].IsXmlNameStart())
        {
            for (var i = colon; i < str.Length; i++)
            {
                if (str[i] == Symbols.Colon || !str[i].IsXmlName())
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if the given char is a valid character.
    /// </summary>
    /// <param name="chr">The char to examine.</param>
    /// <returns>True if the char would indeed be valid.</returns>
    public static bool IsXmlChar(this char chr)
    {
        return chr == 0x9 || chr == 0xA || chr == 0xD || (chr >= 0x20 && chr <= 0xD7FF) ||
                (chr >= 0xE000 && chr <= 0xFFFD);
    }

    /// <summary>
    /// Checks if the given integer would be a valid character.
    /// </summary>
    /// <param name="chr">The integer to examine.</param>
    /// <returns>True if the integer would indeed be valid.</returns>
    public static bool IsValidAsCharRef(this int chr)
    {
        return  chr == 0x9 || chr == 0xA || chr == 0xD || (chr >= 0x20 && chr <= 0xD7FF) ||
                (chr >= 0xE000 && chr <= 0xFFFD) || (chr >= 0x10000 && chr <= 0x10FFFF);
    }
}
