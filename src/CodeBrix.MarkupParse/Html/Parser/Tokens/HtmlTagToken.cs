using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html.Parser.Tokens; //Was previously: namespace AngleSharp.Html.Parser.Tokens

/// <summary>
/// Class for StartTagToken and EndTagToken.
/// </summary>
public sealed class HtmlTagToken : HtmlToken
{
    #region Fields

    private readonly List<HtmlAttributeToken> _attributes = [];
    private bool _selfClosing;

    #endregion

    #region ctor

    /// <summary>
    /// Sets the default values.
    /// </summary>
    /// <param name="type">The type of the tag token.</param>
    /// <param name="position">The token's position.</param>
    public HtmlTagToken(HtmlTokenType type, TextPosition position)
        : this(type, position, string.Empty)
    {
    }

    /// <summary>
    /// Creates a new HTML TagToken with the defined name.
    /// </summary>
    /// <param name="type">The type of the tag token.</param>
    /// <param name="position">The token's position.</param>
    /// <param name="name">The name of the tag.</param>
    public HtmlTagToken(HtmlTokenType type, TextPosition position, string name)
        : base(type, position, name)
    {
    }

    #endregion

    #region Creators

    /// <summary>
    /// Creates a new opening HtmlTagToken for the given name.
    /// </summary>
    /// <param name="name">The name of the tag.</param>
    /// <returns>The new HTML tag token.</returns>
    public static HtmlTagToken Open(string name)
    {
        return new HtmlTagToken(HtmlTokenType.StartTag, TextPosition.Empty, name);
    }

    /// <summary>
    /// Creates a new closing HtmlTagToken for the given name.
    /// </summary>
    /// <param name="name">The name of the tag.</param>
    /// <returns>The new HTML tag token.</returns>
    public static HtmlTagToken Close(string name)
    {
        return new HtmlTagToken(HtmlTokenType.EndTag, TextPosition.Empty, name);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the state of the self-closing flag.
    /// </summary>
    public bool IsSelfClosing
    {
        get => _selfClosing;
        set => _selfClosing = value;
    }

    /// <summary>
    /// Gets the list of attributes.
    /// </summary>
    public List<HtmlAttributeToken> Attributes => _attributes;

    #endregion

    #region Methods

    /// <summary>
    /// Adds a new attribute to the list of attributes. The value will
    /// be set to an empty string.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="position">The starting position of the attribute.</param>
    public void AddAttribute(string name, TextPosition position)
    {
        _attributes.Add(new HtmlAttributeToken(position, name, string.Empty));
    }

    /// <summary>
    /// Adds a new attribute to the list of attributes.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    public void AddAttribute(string name, string value)
    {
        _attributes.Add(new HtmlAttributeToken(TextPosition.Empty, name, value));
    }

    /// <summary>
    /// Sets the value of the last added attribute.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAttributeValue(string value)
    {
        var last = _attributes.Count - 1;
        var attr = _attributes[last];
        _attributes[last] = new HtmlAttributeToken(attr.Position, attr.Name, value);
    }

    /// <summary>
    /// Gets the value of the attribute with the given name or an empty
    /// string if the attribute is not available.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>The value of the attribute.</returns>
    public string GetAttribute(string name)
    {
        for (var i = 0; i != _attributes.Count; i++)
        {
            var attr = _attributes[i];

            if (attr.Name.Is(name))
            {
                return attr.Value;
            }
        }

        return string.Empty;
    }

    #endregion
}
