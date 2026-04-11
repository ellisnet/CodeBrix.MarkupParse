using System;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// Represents a CSS media feature.
/// </summary>
public interface IMediaFeature : IStyleFormattable
{
    /// <summary>
    /// Gets the name of the feature.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets if the feature represents the minimum.
    /// </summary>
    bool IsMinimum { get; }

    /// <summary>
    /// Gets if the feature represents the maximum.
    /// </summary>
    bool IsMaximum { get; }

    /// <summary>
    /// Gets the value of the feature, if any.
    /// </summary>
    string Value { get; }

    /// <summary>
    /// Gets if a value has been set for this feature.
    /// </summary>
    bool HasValue { get; }
}
