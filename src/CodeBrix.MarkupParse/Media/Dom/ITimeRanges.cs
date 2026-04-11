using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Represents a media time range.
/// </summary>
[DomName("TimeRanges")]
public interface ITimeRanges
{
    /// <summary>
    /// Gets the length of the range in frames.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Returns the time offset at which a specified time range begins.
    /// </summary>
    /// <param name="index">The range number to return the starting time for.</param>
    /// <returns>The time offset.</returns>
    [DomName("start")]
    double Start(int index);

    /// <summary>
    /// Returns the time offset at which a specified time range ends.
    /// </summary>
    /// <param name="index">The range number to return the ending time for.</param>
    /// <returns>The time offset.</returns>
    [DomName("end")]
    double End(int index);
}
