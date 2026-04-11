using System;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Defines the methods to perform an integrity check.
/// </summary>
public interface IIntegrityProvider
{
    /// <summary>
    /// Checks if the given content satisfies the provided integrity
    /// attribute.
    /// </summary>
    /// <param name="content">The content to hash.</param>
    /// <param name="integrity">The value of the integrity attribute.</param>
    /// <returns>True if integrity is preserved, otherwise false.</returns>
    bool IsSatisfied(byte[] content, string integrity);
}
