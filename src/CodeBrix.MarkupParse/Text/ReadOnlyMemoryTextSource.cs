using CodeBrix.MarkupParse.Common;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Text;

/// <summary>
/// Represents a fully loaded immutable text source.
/// </summary>
public sealed class ReadOnlyMemoryTextSource : IReadOnlyTextSource
{
    private int _index;
    private string _content;
    private readonly ReadOnlyMemory<char> _memory;
    private readonly int _length;

    #region ctor

    /// <summary>
    ///
    /// </summary>
    /// <param name="memory"></param>
    public ReadOnlyMemoryTextSource(ReadOnlyMemory<char> memory)
    {
        _memory = memory;
        _length = memory.Length;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="str"></param>
    public ReadOnlyMemoryTextSource(string str)
    {
        _content = str;
        _memory = str.AsMemory();
        _length = _memory.Length;
    }

    #endregion

    #region Properties

    /// <ihneritdoc />
    public string Text
    {
        get
        {
            return _content ??= _memory.Span.ToString();
        }
    }

    /// <ihneritdoc />
    public char this[int index] => _content != null ? _content[index] : _memory.Span[index];

    /// <ihneritdoc />
    public int Length => _length;

    /// <ihneritdoc />
    public Encoding CurrentEncoding
    {
        get => TextEncoding.Utf8;
        set { }
    }

    /// <ihneritdoc />
    public int Index
    {
        get => _index;
        set => _index = value;
    }

    #endregion

    #region Disposable

    /// <ihneritdoc />
    public void Dispose()
    {
    }

    #endregion

    #region Text Methods

    /// <ihneritdoc />
    public char ReadCharacter()
    {
        if (_index < _length)
        {
            return _memory.Span[_index++];
        }

        _index += 1;
        return Symbols.EndOfFile;
    }

    /// <ihneritdoc />
    public string ReadCharacters(int characters)
    {
        return ReadMemory(characters).ToString();
    }

    /// <ihneritdoc />
    public StringOrMemory ReadMemory(int characters)
    {
        var start = _index;
        var end = start + characters;

        if (end <= _length)
        {
            _index += characters;
            return _memory.Slice(start, characters);
        }

        _index += characters;
        characters = Math.Min(characters, _length - start);
        return _memory.Slice(start, characters);
    }

    /// <ihneritdoc />
    public Task PrefetchAsync(int length, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <ihneritdoc />
    public Task PrefetchAllAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <ihneritdoc />
    public bool TryGetContentLength(out int length)
    {
        length = _length;
        return true;
    }

    #endregion
}
