using CodeBrix.MarkupParse.Text;
using System;
using System.Buffers;
using System.Text;

namespace CodeBrix.MarkupParse.Common;

/// <summary>
/// Delegates implementation to <see cref="StringBuilder"/> obtained from <see cref="StringBuilderPool"/>
/// </summary>
internal sealed class StringBuilderBuffer : IMutableCharBuffer
{
    private bool _disposed = false;
    internal StringBuilder _sb = StringBuilderPool.Obtain();

    public void Append(char c)
    {
        _sb.Append(c);
    }

    public void Discard()
    {
        _sb.Clear();
    }

    public int Length => _sb.Length;

    public int Capacity => _sb.Capacity;

    public IMutableCharBuffer Remove(int startIndex, int length)
    {
        _sb.Remove(startIndex, length);
        return this;
    }

    public void ReturnToPool()
    {
        if (_disposed)
        {
            StringBuilderPool.ReturnToPool(_sb);
            _sb = null!;
            _disposed = true;
        }
    }

    public void Dispose()
    {
        ReturnToPool();
    }

    public IMutableCharBuffer Insert(int index, char c)
    {
        _sb.Insert(index, c);
        return this;
    }

    public IMutableCharBuffer Append(ReadOnlySpan<char> str)
    {
_sb.Append(str);
        return this;
    }

    public char this[int i] => _sb[i];

    public ReadOnlyMemory<char>? TryCopyTo(char[] buffer)
    {
        if (_sb.Length > buffer.Length)
        {
            return null;
        }

        _sb.CopyTo(0, buffer, 0, _sb.Length);
        return buffer.AsMemory(0, _sb.Length);
    }

    private StringOrMemory GetData()
    {
        return new StringOrMemory(_sb.ToString());
    }

    public StringOrMemory GetDataAndClear()
    {
        var temp = GetData();
        Discard();
        return temp;
    }

    public bool HasText(ReadOnlySpan<char> test, StringComparison comparison)
    {
        var length = _sb.Length;
        using var lease = ArrayPool<char>.Shared.Borrow(length);
        _sb.CopyTo(0, lease.Data, 0, length);
        return MemoryExtensions.Equals(lease.Span.Slice(0, length), test, comparison);
    }

    public bool HasTextAt(ReadOnlySpan<char> test, int offset, int length, StringComparison comparison = StringComparison.Ordinal)
    {
        using var lease = ArrayPool<char>.Shared.Borrow(length);
        _sb.CopyTo(offset, lease.Data, 0, length);
        return MemoryExtensions.Equals(lease.Span.Slice(0, length), test, comparison);
    }

    public override string ToString()
    {
        return _sb.ToString();
    }
}
