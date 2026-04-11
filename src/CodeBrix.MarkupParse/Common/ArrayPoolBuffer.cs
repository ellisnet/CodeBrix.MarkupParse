using System;
using System.Buffers;

namespace CodeBrix.MarkupParse.Common;

/// <summary>
/// A buffer that uses an array pool to store the characters.
/// Usage of this buffer assumes that the max capacity is known upfront
/// Maintains an append only contiguous chunk of characters.
/// Created <see cref="StringOrMemory"/> instances lifetime is tied to the buffer.
/// Works under assumption that the buffer will be disposed after use
/// and max capacity can't be larger than char count in the source.
/// </summary>
internal sealed class ArrayPoolBuffer(int length) : IMutableCharBuffer
{
    private char[] _buffer = ArrayPool<char>.Shared.Rent(length);
    private int _start;
    private int _idx;
    private bool _disposed;

    private int Pointer => _start + _idx;

    public void Append(char c)
    {
        _buffer[_start + _idx] = c;
        _idx++;
    }

    public void Discard()
    {
        Clear(false);
    }

    private void Clear(bool commit)
    {
        if (commit)
        {
            _start += _idx;
        }
        _idx = 0;
    }

    public int Length => _idx;

    public int Capacity => _buffer.Length;

    public IMutableCharBuffer Remove(int startIndex, int length)
    {
        var source = _buffer.AsSpan(_start + startIndex + length, length);
        var destination = _buffer.AsSpan(_start + startIndex, length);
        source.CopyTo(destination);
        _idx -= length;
        return this;
    }

    public void ReturnToPool()
    {
        if (!_disposed)
        {
            ArrayPool<char>.Shared.Return(_buffer, false);
            _buffer = null!;
            _disposed = true;
        }
    }

    public IMutableCharBuffer Insert(int idx, char c)
    {
        if ((uint)idx > Length)
        {
            throw new ArgumentOutOfRangeException(nameof(idx));
        }

        if (Pointer + 1 > Capacity)
        {
            throw new InvalidOperationException("Buffer is full.");
        }

        Array.Copy(
            _buffer, _start + idx,
            _buffer, _start + idx + 1,
            Length - idx);

        _buffer[_start + idx] = c;
        _idx++;

        return this;
    }

    public IMutableCharBuffer Append(ReadOnlySpan<char> str)
    {
        if (Pointer + str.Length > Capacity)
        {
            throw new InvalidOperationException("Buffer is full.");
        }

        str.CopyTo(_buffer.AsSpan(Pointer));
        _idx += str.Length;
        return this;
    }

    public char this[int i] => _buffer[_start + i];

    public ReadOnlyMemory<char>? TryCopyTo(char[] buffer)
    {
        var data = GetData();
        if (data.Length > buffer.Length)
        {
            return null;
        }

        data.Memory.Span.CopyTo(buffer);
        return buffer.AsMemory(0, data.Length);
    }

    private StringOrMemory GetData() => new(_buffer.AsMemory(_start, Length));

    public StringOrMemory GetDataAndClear()
    {
        var result = GetData();
        Clear(true);
        return result;
    }

    public bool HasText(ReadOnlySpan<char> test, StringComparison comparison = StringComparison.Ordinal)
    {
        var actual = _buffer.AsSpan(_start, Length);
        return MemoryExtensions.Equals(actual, test, comparison);
    }

    public bool HasTextAt(ReadOnlySpan<char> test, int offset, int length, StringComparison comparison = StringComparison.Ordinal)
    {
        var actual = _buffer.AsSpan(_start + offset, length);
        return MemoryExtensions.Equals(actual, test, comparison);
    }

    string IMutableCharBuffer.ToString() => _buffer.AsMemory(_start, Length).ToString();

    public void Dispose()
    {
        ReturnToPool();
    }
}