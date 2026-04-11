using System;

namespace CodeBrix.MarkupParse.Common;

internal static class BufferExtensions
{
    #region String

    public static bool Is(this IMutableCharBuffer buffer, string test) => buffer.HasText(test.AsSpan());

    public static bool Is(this IMutableCharBuffer buffer, int start, int length, string test) =>
        buffer.HasTextAt(test.AsSpan(), start, length);

    public static bool Isi(this IMutableCharBuffer buffer, string test) =>
        buffer.HasText(test.AsSpan(), StringComparison.OrdinalIgnoreCase);

    public static bool Isi(this IMutableCharBuffer buffer, int start, int length, string test) =>
        buffer.HasTextAt(test.AsSpan(), start, length, StringComparison.OrdinalIgnoreCase);

    #endregion

    #region StringOrMemory

    public static bool Is(this IMutableCharBuffer buffer, StringOrMemory test) => buffer.HasText(test.Memory.Span);

    public static bool Is(this IMutableCharBuffer buffer, int start, int length, StringOrMemory test) =>
        buffer.HasTextAt(test.Memory.Span, start, length);

    public static bool Isi(this IMutableCharBuffer buffer, StringOrMemory test) =>
        buffer.HasText(test.Memory.Span, StringComparison.OrdinalIgnoreCase);

    public static bool Isi(this IMutableCharBuffer buffer, int start, int length, StringOrMemory test) =>
        buffer.HasTextAt(test.Memory.Span, start, length, StringComparison.OrdinalIgnoreCase);

    #endregion

    #region ReadOnlyMemory<Char>

    public static bool Isi(this IMutableCharBuffer buffer, ReadOnlyMemory<char> test) =>
        buffer.HasText(test.Span, StringComparison.OrdinalIgnoreCase);

    public static bool Isi(this IMutableCharBuffer buffer, int start, int length, ReadOnlyMemory<char> test) =>
        buffer.HasTextAt(test.Span, start, length, StringComparison.OrdinalIgnoreCase);

    public static bool Is(this IMutableCharBuffer buffer, ReadOnlyMemory<char> test) => buffer.HasText(test.Span);

    public static bool Is(this IMutableCharBuffer buffer, int start, int length, ReadOnlyMemory<char> test) =>
        buffer.HasTextAt(test.Span, start, length);

    #endregion

    #region ReadOnlySpan<Char>

    public static bool Is(this IMutableCharBuffer buffer, ReadOnlySpan<char> test) => buffer.HasText(test);

    public static bool Is(this IMutableCharBuffer buffer, int start, int length, ReadOnlySpan<char> test) =>
        buffer.HasTextAt(test, start, length);

    public static bool Isi(this IMutableCharBuffer buffer, ReadOnlySpan<char> test) =>
        buffer.HasText(test, StringComparison.OrdinalIgnoreCase);

    public static bool Isi(this IMutableCharBuffer buffer, int start, int length, ReadOnlySpan<char> test) =>
        buffer.HasTextAt(test, start, length, StringComparison.OrdinalIgnoreCase);

    #endregion
}