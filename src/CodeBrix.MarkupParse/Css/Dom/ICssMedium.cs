using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// Represents a CSS medium.
/// </summary>
public interface ICssMedium : IStyleFormattable
{
    /// <summary>
    /// Gets the type of medium that is represented.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Gets if the medium has been created using the only keyword.
    /// </summary>
    bool IsExclusive { get; }

    /// <summary>
    /// Gets if the medium has been created using the not keyword.
    /// </summary>
    bool IsInverse { get; }

    /// <summary>
    /// Gets a string describing the covered constraints.
    /// </summary>
    string Constraints { get; }

    /// <summary>
    /// Gets an enumerable of contained features.
    /// </summary>
    IEnumerable<IMediaFeature> Features { get; }
}
