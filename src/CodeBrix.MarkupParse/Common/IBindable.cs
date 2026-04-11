using System;

namespace CodeBrix.MarkupParse.Common; //Was previously: namespace AngleSharp.Common

/// <summary>
/// Implemented by OM classes that may change internal state reflected with
/// a changed string representation.
/// </summary>
public interface IBindable
{
    /// <summary>
    /// Triggered when the internal state changed.
    /// </summary>
    event Action<string> Changed;

    /// <summary>
    /// Update the string representation without calling Changed.
    /// </summary>
    /// <param name="value">The representation's new value.</param>
    void Update(string value);
}
