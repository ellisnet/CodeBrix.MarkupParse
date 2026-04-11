using System;

namespace CodeBrix.MarkupParse.Text; //Was previously: namespace AngleSharp.Text

/// <summary>
/// Extensions for the string source helper.
/// </summary>
public static class StringSourceExtensions
{
    /// <summary>
    /// Skips all spaces starting at the current character.
    /// </summary>
    public static char SkipSpaces(this StringSource source)
    {
        var current = source.Current;

        while (current.IsSpaceCharacter())
        {
            current = source.Next();
        }

        return current;
    }

    /// <summary>
    /// Goes back n characters.
    /// </summary>
    public static char Next(this StringSource source, int n)
    {
        for (var i = 0; i < n; i++)
        {
            source.Next();
        }

        return source.Current;
    }

    /// <summary>
    /// Goes back n characters.
    /// </summary>
    public static char Back(this StringSource source, int n)
    {
        for (var i = 0; i < n; i++)
        {
            source.Back();
        }

        return source.Current;
    }

    /// <summary>
    /// Gets the upcoming character without advancing.
    /// </summary>
    public static char Peek(this StringSource source)
    {
        var c = source.Next();
        source.Back();
        return c;
    }
}
