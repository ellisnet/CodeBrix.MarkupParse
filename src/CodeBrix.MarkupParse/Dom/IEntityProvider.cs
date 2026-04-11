using CodeBrix.MarkupParse.Common;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Defines methods to create a custom entity service.
/// </summary>
public interface IEntityProvider
{
    /// <summary>
    /// Gets a symbol specified by its entity name usually trailed with
    /// the semicolon, if available.
    /// </summary>
    /// <param name="name">The name of the entity in the markup.</param>
    /// <returns>The string with the symbol or null.</returns>
    string GetSymbol(string name);
}

/// <summary>
/// Defines methods to create a custom entity service.
/// </summary>
public interface IEntityProviderExtended
{
    /// <summary>
    /// Gets a symbol specified by its entity name usually trailed with
    /// the semicolon, if available.
    /// </summary>
    /// <param name="name">The name of the entity in the markup presented as string or memory reference.</param>
    /// <returns>The string with the symbol or null.</returns>
    string GetSymbol(StringOrMemory name);
}
