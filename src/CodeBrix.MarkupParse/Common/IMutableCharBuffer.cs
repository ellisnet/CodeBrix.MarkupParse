using System;

namespace CodeBrix.MarkupParse.Common;

/// <summary>
/// Represents a sequence of characters.
/// </summary>
public interface ICharBuffer
{
    /// <summary>
    /// Gets the length of the buffer.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Returns the character at the given index.
    /// </summary>
    char this[int i] { get; }

    /// <summary>
    ///
    /// </summary>
    ReadOnlyMemory<char>? TryCopyTo(char[] buffer);
}

/// <summary>
/// Represents a mutable sequence of characters.
/// </summary>
internal interface IMutableCharBuffer : ICharBuffer, IDisposable
{
    /// <summary>
    /// Appends the given character to the buffer.
    /// </summary>
    void Append(char c);

    /// <summary>
    /// Clears the buffer.
    /// </summary>
    void Discard();

    /// <summary>
    /// Current capacity of the buffer.
    /// </summary>
    int Capacity { get; }

    /// <summary>
    /// Removes the given amount of characters from the buffer.
    /// </summary>
    IMutableCharBuffer Remove(int start, int length);

    /// <summary>
    /// Returns the buffer to the pool.
    /// </summary>
    void ReturnToPool();

    /// <summary>
    /// Inserts the given character at the specified index.
    /// </summary>
    IMutableCharBuffer Insert(int index, char c);

    /// <summary>
    /// Appends the given char span to the buffer.
    /// </summary>
    IMutableCharBuffer Append(ReadOnlySpan<char> str);

    /// <summary>
    /// Materializes the buffer to a <see cref="StringOrMemory"/> instance and resets it
    /// </summary>
    /// <returns></returns>
    StringOrMemory GetDataAndClear();

    /// <summary>
    /// Checks if the buffer contains the given text.
    /// </summary>
    public bool HasText(ReadOnlySpan<char> test, StringComparison comparison = StringComparison.Ordinal);

    /// <summary>
    /// Checks if the buffer contains the given text at the specified offset.
    /// </summary>
    public bool HasTextAt(ReadOnlySpan<char> test, int offset, int length, StringComparison comparison = StringComparison.Ordinal);

    /// <summary>
    /// Creates a CLR String instance from the buffer.
    /// </summary>
    public string ToString();
}