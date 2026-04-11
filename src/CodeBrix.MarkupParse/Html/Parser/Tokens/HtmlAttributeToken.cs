using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Parser.Tokens; //Was previously: namespace AngleSharp.Html.Parser.Tokens

/// <summary>
/// The token representation of an HTML tag attribute.
/// </summary>
public readonly struct HtmlAttributeToken
{
    /// <summary>
    /// Creates a new attribute token using the provided information.
    /// </summary>
    /// <param name="position">The start position of the attribute's name.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    public HtmlAttributeToken(TextPosition position, string name, string value)
    {
        Position = position;
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Gets the attribute's name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the attribute's value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Gets the position of the token.
    /// </summary>
    public TextPosition Position { get; }
}
