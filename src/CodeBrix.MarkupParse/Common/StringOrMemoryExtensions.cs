using System;

namespace CodeBrix.MarkupParse.Common;

static class StringOrMemoryExtensions
{
    public static bool Is(this StringOrMemory str, StringOrMemory other) => str == other;

    public static bool Is(this StringOrMemory str, string other) => str == other;

    public static bool Isi(this StringOrMemory str, StringOrMemory other) =>
        str.Memory.Span.Equals(other.Memory.Span, StringComparison.OrdinalIgnoreCase);

    public static bool Isi(this StringOrMemory str, string other) =>
        str.Memory.Span.Equals(other.AsSpan(), StringComparison.OrdinalIgnoreCase);

    public static bool IsOneOf(this StringOrMemory str, StringOrMemory a, StringOrMemory b, StringOrMemory c, StringOrMemory d) =>
        str.Is(a) || str.Is(b) || str.Is(c) || str.Is(d);

    public static bool IsOneOf(this StringOrMemory str, StringOrMemory a, StringOrMemory b, StringOrMemory c) =>
        str.Is(a) || str.Is(b) || str.Is(c);

    public static bool IsOneOf(this StringOrMemory str, StringOrMemory a, StringOrMemory b) => str.Is(a) || str.Is(b);

    public static bool StartsWith(this StringOrMemory str, string test, StringComparison comparison) =>
        str.Memory.Span.StartsWith(test.AsSpan(), comparison);

    public static bool Equals(this StringOrMemory str, string test, StringComparison comparison) =>
        str.Memory.Span.Equals(test.AsSpan(), comparison);
}