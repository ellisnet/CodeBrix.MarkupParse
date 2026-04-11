using System;

namespace CodeBrix.MarkupParse.Attributes; //Was previously: namespace AngleSharp.Attributes

/// <summary>
/// Represents a single instance object.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class DomInstanceAttribute : Attribute
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="name">The name to use.</param>
    public DomInstanceAttribute(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets the name of the variable.
    /// </summary>
    public string Name { get; }
}
