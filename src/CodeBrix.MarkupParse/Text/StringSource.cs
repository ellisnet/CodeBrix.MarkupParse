using System;

namespace CodeBrix.MarkupParse.Text; //Was previously: namespace AngleSharp.Text

/// <summary>
/// A string abstraction for micro parsers.
/// </summary>
public sealed class StringSource
{
    #region Fields

    private readonly string _content;
    private readonly int _last;
    private int _index;
    private char _current;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new string source from the given content.
    /// </summary>
    public StringSource(string content)
    {
        _content = content ?? string.Empty;
        _last = _content.Length - 1;
        _index = 0;
        _current = _last == -1 ? Symbols.EndOfFile : content![0];
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current character.
    /// </summary>
    public char Current => _current;

    /// <summary>
    /// Gets if the content has been fully scanned.
    /// </summary>
    public bool IsDone => _current == Symbols.EndOfFile;

    /// <summary>
    /// Gets the current index.
    /// </summary>
    public int Index => _index;

    /// <summary>
    /// Gets the underlying content.
    /// </summary>
    public string Content => _content;

    #endregion

    #region Methods

    /// <summary>
    /// Advances by one character and returns the character.
    /// </summary>
    /// <returns>The next character.</returns>
    public char Next()
    {
        if (_index == _last)
        {
            _current = Symbols.EndOfFile;
            _index = _content.Length;
        }
        else if (_index < _content.Length)
        {
            _current = _content[++_index];
        }

        return _current;
    }

    /// <summary>
    /// Goes back by one character and returns the character.
    /// </summary>
    /// <returns>The previous character.</returns>
    public char Back()
    {
        if (_index > 0)
        {
            _current = _content[--_index];
        }

        return _current;
    }

    #endregion
}
