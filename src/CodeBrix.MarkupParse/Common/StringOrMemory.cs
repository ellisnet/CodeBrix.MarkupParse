using System;

namespace CodeBrix.MarkupParse.Common;

/// <summary>
/// Represents a string and equivalent memory representation of this string.
/// Prevents multiple allocations of string by caching it
/// </summary>
public struct StringOrMemory
{
    private readonly ReadOnlyMemory<char> _memory;

    /// <summary>
    /// Creates new instance of <see cref="StringOrMemory"/> from string
    /// </summary>
    public StringOrMemory(string str)
    {
        _memory = str.AsMemory();
    }

    /// <summary>
    /// Creates new instance of <see cref="StringOrMemory"/> from read only memory
    /// </summary>
    public StringOrMemory(ReadOnlyMemory<char> memory)
    {
        _memory = memory;
    }

    /// <summary>
    /// Returns memory representation of string
    /// </summary>
    public readonly ReadOnlyMemory<char> Memory => _memory;

    /// <summary>
    /// Length of string
    /// </summary>
    public int Length => _memory.Length;

    /// <summary>
    /// Returns character at specified index
    /// </summary>
    public char this[int i] => _memory.Span[i];

    /// <summary>
    /// Checks if string is null or empty
    /// </summary>
    public bool IsNullOrEmpty => _memory.IsEmpty;

    /// <summary>
    /// Static empty string instance
    /// </summary>
    public static StringOrMemory Empty => new(string.Empty);

    /// <summary>
    /// Converts string to <see cref="StringOrMemory"/> implicitly
    /// </summary>
    public static implicit operator StringOrMemory(string str) => new(str);

    /// <summary>
    /// Converts <see cref="ReadOnlyMemory&lt;Char&gt;"/> to string implicitly
    /// </summary>
    public static implicit operator StringOrMemory(ReadOnlyMemory<char> memory) => new(memory);

    /// <summary>
    /// Converts <see cref="StringOrMemory"/> to <see cref="ReadOnlyMemory&lt;Char&gt;"/>
    /// </summary>
    public static implicit operator ReadOnlyMemory<char>(StringOrMemory str) => str.Memory;

    /// <summary>
    /// Converts <see cref="StringOrMemory"/> to <see cref="ReadOnlySpan&lt;Char&gt;"/>
    /// </summary>
    public static implicit operator ReadOnlySpan<char>(StringOrMemory str) => str.Memory.Span;

    /// <summary>
    /// Equality operator for <see cref="StringOrMemory"/> and <see cref="String"/>
    /// </summary>
    public static bool operator ==(StringOrMemory left, string right) =>
        left.Memory.Span.SequenceEqual(right.AsSpan());

    /// <summary>
    /// Equality operator for <see cref="StringOrMemory"/> and <see cref="StringOrMemory"/>
    /// </summary>
    public static bool operator ==(StringOrMemory left, StringOrMemory right) =>
        left.Memory.Span.SequenceEqual(right.Memory.Span);

    /// <summary>
    /// Equality operator for <see cref="StringOrMemory"/> and <see cref="ReadOnlyMemory&lt;Char&gt;"/>
    /// </summary>
    public static bool operator ==(StringOrMemory left, ReadOnlyMemory<char> right) =>
        left.Memory.Span.SequenceEqual(right.Span);

    /// <summary>
    /// Equality operator for <see cref="StringOrMemory"/> and <see cref="ReadOnlySpan&lt;Char&gt;"/>
    /// </summary>
    public static bool operator ==(StringOrMemory left, ReadOnlySpan<char> right) =>
        left.Memory.Span.SequenceEqual(right);

    /// <summary>
    /// Inequality operator for <see cref="StringOrMemory"/> and <see cref="String"/>
    /// </summary>
    public static bool operator !=(StringOrMemory left, string right) => !(left == right);

    /// <summary>
    /// Inequality operator for <see cref="StringOrMemory"/> and <see cref="StringOrMemory"/>
    /// </summary>
    public static bool operator !=(StringOrMemory left, StringOrMemory right) => !(left == right);

    /// <summary>
    /// Inequality operator for <see cref="StringOrMemory"/> and <see cref="ReadOnlyMemory&lt;Char&gt;"/>
    /// </summary>
    public static bool operator !=(StringOrMemory left, ReadOnlyMemory<char> right) => !(left == right);

    /// <summary>
    /// Inequality operator for <see cref="StringOrMemory"/> and <see cref="ReadOnlySpan&lt;Char&gt;"/>
    /// </summary>
    public static bool operator !=(StringOrMemory left, ReadOnlySpan<char> right) => !(left == right);

    /// <summary>
    /// CLR equals implementation
    /// </summary>
    public bool Equals(StringOrMemory other)
    {
        return
            _memory.Equals(other._memory) || // checks pointers (e.g. same string or array parts)
            _memory.Span.SequenceEqual(other._memory.Span);
    }

    /// <summary>
    /// CLR equals implementation
    /// </summary>
    public override bool Equals(object obj)
    {
        return obj is StringOrMemory other && Equals(other);
    }

    /// <summary>
    /// Gets hash code of string
    /// </summary>
    public override int GetHashCode()
    {
        return GetHashCode(_memory.Span);
    }

    /// <summary>
    /// Replace all occurrences of target character with replacement character
    /// </summary>
    public StringOrMemory Replace(char target, char replacement)
    {
if (_memory.Length < 128)
{
    Span<char> tmp = stackalloc char[_memory.Length];
    _memory.Span.Replace(tmp, target, replacement);
    return new StringOrMemory(tmp.ToString());
}

return new StringOrMemory(this.ToString().Replace(target, replacement));
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        if (_memory.IsEmpty)
        {
            return string.Empty;
        }

        // ToString here checks if pointer is already a string and also checks case when length is same as original string
        // important for cached string, usually from dictionaries
        return _memory.ToString();
    }

    private static int GetHashCode(ReadOnlySpan<char> span)
    {
        return string.GetHashCode(span);
    }
}