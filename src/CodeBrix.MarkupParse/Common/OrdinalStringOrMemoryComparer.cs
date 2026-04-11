using CodeBrix.MarkupParse.Common;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html;

internal class OrdinalStringOrMemoryComparer : IEqualityComparer<StringOrMemory>
{
    /// <summary>
    /// Gets the default instance of the comparer.
    /// </summary>
    public static OrdinalStringOrMemoryComparer Instance { get; } = new();

    /// <inheritdoc/>
    public int GetHashCode(StringOrMemory obj)
    {
        return obj.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(StringOrMemory x, StringOrMemory y)
    {
        return x.Equals(y);
    }
}
