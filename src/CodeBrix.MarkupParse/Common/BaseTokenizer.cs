using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBrix.MarkupParse.Common; //Was previously: namespace AngleSharp.Common

/// <summary>
/// Common methods and variables of all tokenizers.
/// </summary>
public abstract class BaseTokenizer: IDisposable
{
    #region Fields

    private readonly Stack<ushort> _columns;

    private readonly IReadOnlyTextSource _source;
    private readonly WritableTextSource _wts;
    private readonly CharArrayTextSource _cats;

    private StringBuilder _stringBuilder;
    private IMutableCharBuffer _charBuffer;
    private readonly ArrayPoolBuffer _apb;
    private readonly StringBuilderBuffer _sbb;

    private ushort _column;
    private ushort _row;
    private char _current;
    private bool _normalized;
    private bool _disableElementPositionTracking;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new instance of the base tokenizer.
    /// </summary>
    /// <param name="source">The source to tokenize.</param>
    public BaseTokenizer(TextSource source)
    {
        _stringBuilder = StringBuilderPool.Obtain();

        if (source.TryGetContentLength(out var length))
        {
            _charBuffer = _apb = new ArrayPoolBuffer(length);
        }
        else
        {
            _charBuffer = _sbb = new StringBuilderBuffer();
        }

        _source = source.GetUnderlyingTextSource();

        if (_source is WritableTextSource wts)
        {
            _wts = wts;
        }
        else if (_source is CharArrayTextSource cats)
        {
            _cats = cats;
        }

        _current = Symbols.Null;
        _column = 0;
        _row = 1;
        _columns = new Stack<ushort>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current insertion point.
    /// </summary>
    public int InsertionPoint
    {
        get => _source.Index;
        protected set
        {
            var delta = _source.Index - value;

            while (delta > 0)
            {
                BackUnsafe();
                delta--;
            }

            while (delta < 0)
            {
                AdvanceUnsafe();
                delta++;
            }
        }
    }

    /// <summary>
    /// Gets the current source index.
    /// </summary>
    public int Position => _source.Index  - (_normalized ? 1 : 0);

    /// <summary>
    /// Gets the current character.
    /// </summary>
    protected char Current => _current;

    /// <summary>
    /// Gets the allocated string buffer.
    /// </summary>
    protected StringBuilder StringBuffer => _stringBuilder;

    /// <summary>
    /// Gets the allocated string buffer.
    /// </summary>
    private protected IMutableCharBuffer CharBuffer => _charBuffer;

    /// <summary>
    /// Gets if the current index has been normalized (CRLF -> LF).
    /// </summary>
    protected bool IsNormalized => _normalized;

    /// <summary>
    ///
    /// </summary>
    public bool DisableElementPositionTracking
    {
        get => _disableElementPositionTracking;
        set => _disableElementPositionTracking = value;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Flushes the buffer.
    /// </summary>
    /// <returns>The content of the buffer.</returns>
    public string FlushBuffer()
    {
        var result = StringBuffer.ToString();
        StringBuffer.Clear();
        return result;
    }

    /// <summary>
    /// Flushes the buffer. Will return the reference to the memory without creating a new string if possible.
    /// </summary>
    /// <returns></returns>
    internal StringOrMemory FlushBufferFast()
    {
        return _charBuffer.GetDataAndClear();
    }

    internal StringOrMemory FlushBufferFast(Func<IMutableCharBuffer, string> stringResolver)
    {
        var resolved = stringResolver(CharBuffer);
        if (resolved != null)
        {
            _charBuffer.Discard();
            return new StringOrMemory(resolved);
        }

        return _charBuffer.GetDataAndClear();
    }

    /// <summary>
    /// Disposes the tokenizer by releasing the buffer.
    /// </summary>
    public void Dispose()
    {
        var isDisposed = _charBuffer is null;
        if (!isDisposed)
        {
            _source.Dispose();

            _stringBuilder.Clear();
            _stringBuilder.ReturnToPool();
            _stringBuilder = null!;

            _charBuffer!.Discard();
            _charBuffer.Dispose();
            _charBuffer = null!;
        }
    }

    /// <summary>
    /// Gets the current text position in the source.
    /// </summary>
    /// <returns>The (row, col) position.</returns>
    public TextPosition GetCurrentPosition() => new(_row, _column, Position);

    /// <summary>
    /// Checks if the source continues with the given string.
    /// The comparison is case-insensitive.
    /// </summary>
    /// <param name="s">The string to compare to.</param>
    /// <returns>True if the source continues with the given string.</returns>
    protected bool ContinuesWithInsensitive(string s)
    {
        var content = PeekStringFast(s.Length);
        return content.Length == s.Length && content.Isi(s);
    }

    /// <summary>
    /// Checks if the source continues with the given string.
    /// The comparison is case-sensitive.
    /// </summary>
    /// <param name="s">The string to compare to.</param>
    /// <returns>True if the source continues with the given string.</returns>
    protected bool ContinuesWithSensitive(string s)
    {
        var content = PeekStringFast(s.Length);
        return content.Length == s.Length && content.Is(s);
    }

    /// <summary>
    /// Gets the string formed by the next characters.
    /// </summary>
    /// <param name="length">The length of the string.</param>
    /// <returns>The upcoming string.</returns>
    protected string PeekString(int length)
    {
        var mark = _source.Index;
        _source.Index--;
        var content = _source.ReadCharacters(length);
        _source.Index = mark;
        return content;
    }

    /// <summary>
    /// Will try to get the reference to the memory or will create new string formed by the next characters.
    /// </summary>
    /// <param name="length">The length of the string.</param>
    /// <returns>The upcoming string.</returns>
    protected StringOrMemory PeekStringFast(int length)
    {
        var mark = _source.Index;
        _source.Index--;
        var content = _source.ReadMemory(length);
        _source.Index = mark;
        return content;
    }

    /// <summary>
    /// Skips the next space character(s).
    /// </summary>
    /// <returns>The upcoming first non-space.</returns>
    protected char SkipSpaces()
    {
        var c = GetNext();

        while (c.IsSpaceCharacter())
        {
            c = GetNext();
        }

        return c;
    }

    #endregion

    #region Source Management

    /// <summary>
    /// Gets the next character in the source by advancing.
    /// </summary>
    /// <returns>The next char.</returns>
    protected char GetNext()
    {
        Advance();
        return _current;
    }

    /// <summary>
    /// Gets the previous character in the source by going back.
    /// </summary>
    /// <returns>The previous char.</returns>
    protected char GetPrevious()
    {
        Back();
        return _current;
    }

    /// <summary>
    /// Advances in the source by 1 character if possible.
    /// </summary>
    protected void Advance()
    {
        if (_current != Symbols.EndOfFile)
        {
            AdvanceUnsafe();
        }
    }

    /// <summary>
    /// Advances in the source by n characters or less if possible.
    /// </summary>
    /// <param name="n">The positive number of characters.</param>
    protected void Advance(int n)
    {
        while (n-- > 0 && _current != Symbols.EndOfFile)
        {
            AdvanceUnsafe();
        }
    }

    /// <summary>
    /// Goes back in the source by 1 character if possible.
    /// </summary>
    protected void Back()
    {
        if (InsertionPoint > 0)
        {
            BackUnsafe();
        }
    }

    /// <summary>
    /// Goes back in the source by n characters or less if possible.
    /// </summary>
    /// <param name="n">The positive number of characters.</param>
    protected void Back(int n)
    {
        while (n-- > 0 && InsertionPoint > 0)
        {
            BackUnsafe();
        }
    }

    /// <summary>
    /// Appends the given character to the buffer.
    /// </summary>
    private protected void Append(char c)
    {
        if (_sbb != null)
        {
            _sbb._sb.Append(c);
        }
        else
        {
            _apb!.Append(c);
        }
    }

    private protected void Append(char a, char b)
    {
        if (_sbb != null)
        {
            _sbb._sb.Append(a).Append(b);
        }
        else
        {
            _apb!.Append(a);
            _apb!.Append(b);
        }
    }

    private protected void Append(char a, char b, char c)
    {
        if (_sbb != null)
        {
            _sbb._sb.Append(a).Append(b).Append(c);
        }
        else
        {
            _apb!.Append(a);
            _apb!.Append(b);
            _apb!.Append(c);
        }
    }

    private protected void Append(char a, char b, char c, char d)
    {
        if (_sbb != null)
        {
            _sbb._sb.Append(a).Append(b).Append(c).Append(d);
        }
        else
        {
            _apb!.Append(a);
            _apb!.Append(b);
            _apb!.Append(c);
            _apb!.Append(d);
        }
    }

    #endregion

    #region Helpers

    private void AdvanceUnsafe()
    {
        if (!_disableElementPositionTracking)
        {
            Track();
        }

        var c = ReadCharFromSource();
        _current = NormalizeForward(c);
    }

    private void Track()
    {
        if (_current == Symbols.LineFeed)
        {
            _columns.Push(_column);
            _column = 1;
            _row++;
        }
        else
        {
            _column++;
        }
    }

    private void BackUnsafe()
    {
        _source.Index -= 1;

        if (_source.Index == 0)
        {
            _column = 0;
            _current = Symbols.Null;
            return;
        }

        var c = NormalizeBackward(_source[_source.Index - 1]);
        _current = c;

        if (!_disableElementPositionTracking)
        {
            if (c == Symbols.LineFeed)
            {
                _column = _columns.Count != 0 ? _columns.Pop() : (ushort)1;
                _row--;
            }
            else if (c != Symbols.Null)
            {
                _column--;
            }
        }
    }

    private char NormalizeForward(char p)
    {
        if (p != Symbols.CarriageReturn)
        {
            _normalized = false;
            return p;
        }
        else if (ReadCharFromSource() != Symbols.LineFeed)
        {
            _source.Index--;
        }
        else
        {
            _normalized = true;
        }

        return Symbols.LineFeed;
    }

    private char NormalizeBackward(char p)
    {
        if (p != Symbols.CarriageReturn)
        {
            _normalized = false;
            return p;
        }
        else if (_source.Index < _source.Length && _source[_source.Index] == Symbols.LineFeed)
        {
            BackUnsafe();
            return _current;
        }
        else
        {
            _normalized = true;
        }

        return Symbols.LineFeed;
    }

    private char ReadCharFromSource()
    {
        if (_wts is not null)
        {
            return _wts.ReadCharacter();
        }

        if (_cats is not null)
        {
            return _cats.ReadCharacter();
        }

        return _source.ReadCharacter();
    }

    #endregion
}
