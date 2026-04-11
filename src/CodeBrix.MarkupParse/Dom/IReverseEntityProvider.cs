using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Defines methods to create a custom reverse entity service.
/// </summary>
public interface IReverseEntityProvider
{
    /// <summary>
    /// Gets the name of a symbol specified by its value.
    /// </summary>
    /// <param name="symbol">The symbol's value.</param>
    /// <returns>The name of the symbol or null.</returns>
    string GetName(string symbol);
}
