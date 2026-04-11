using CodeBrix.MarkupParse.Common;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Text;

/// <summary>
/// Char array based immutable text source
/// </summary>
public sealed class StringTextSource : IReadOnlyTextSource
{
    private readonly string _string;
    private readonly ReadOnlyMemory<char> _memory;
    private readonly int _length;

    private int _index;

    /// <summary>
    /// Creates a new text source from a string
    /// </summary>
    public StringTextSource(string source)
    {
        _string = source;
        _length = source.Length;
        _memory = source.AsMemory();
    }

    #region Properties

    /// <ihneritdoc />
    public string Text => _string;

    /// <ihneritdoc />
    public char this[int index] => _string[index];

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
            return _string[_index++];
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
