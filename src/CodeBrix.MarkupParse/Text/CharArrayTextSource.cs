using CodeBrix.MarkupParse.Common;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Text;

/// <summary>
/// Char array based immutable text source
/// </summary>
public sealed class CharArrayTextSource : IReadOnlyTextSource
{
    private int _index;
    private string _content;

    private readonly char[] _array;
    private readonly ReadOnlyMemory<char> _memory;
    private readonly int _length;

    /// <summary>
    ///
    /// </summary>
    /// <param name="array"></param>
    /// <param name="length"></param>
    public CharArrayTextSource(char[] array, int length)
    {
        _array = array;
        _length = length;
        _memory = array.AsMemory(0, length);
    }

    #region Properties

    /// <ihneritdoc />
    public string Text
    {
        get
        {
            return _content ??= new string(_array, 0, _length);
        }
    }

    /// <ihneritdoc />
    public char this[int index] => _array[index];

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
            return _array[_index++];
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
