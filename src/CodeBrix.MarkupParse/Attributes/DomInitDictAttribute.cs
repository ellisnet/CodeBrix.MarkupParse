using System;

namespace CodeBrix.MarkupParse.Attributes; //Was previously: namespace AngleSharp.Attributes

/// <summary>
/// This attribute decorates official DOM methods as specified by the W3C.
/// It tells scripting engines that bags with objects should be provided,
/// which have to be expanded to be used as arguments.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
public sealed class DomInitDictAttribute : Attribute
{
    /// <summary>
    /// Creates a new DomInitDict attribute.
    /// </summary>
    /// <param name="offset">The start index of the dictionary.</param>
    /// <param name="optional">Has a dictionary to be present?</param>
    public DomInitDictAttribute(int offset = 0, bool optional = false)
    {
        Offset = offset;
        IsOptional = optional;
    }

    /// <summary>
    /// Gets the offset of the passed arguments. Arguments before the offset
    /// will be skipped and are not part of the dictionary.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets if the dictionary is completely optional and does not have to
    /// be present.
    /// </summary>
    public bool IsOptional { get; }
}
