using CodeBrix.MarkupParse.Attributes;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The DOMStringMap interface represents a set of name-value pairs.
/// </summary>
[DomName("DOMStringMap")]
public interface IStringMap : IEnumerable<KeyValuePair<string, string>>
{
    /// <summary>
    /// Gets or sets an item in the dictionary.
    /// </summary>
    /// <param name="name">The name of the item to get or set.</param>
    /// <returns>The item with the associated name.</returns>
    [DomAccessor(Accessors.Getter | Accessors.Setter)]
    string this[string name] { get; set; }

    /// <summary>
    /// Deletes the string with the given name from the map.
    /// </summary>
    /// <param name="name">The name of the string to remove.</param>
    [DomAccessor(Accessors.Deleter)]
    void Remove(string name);
}
