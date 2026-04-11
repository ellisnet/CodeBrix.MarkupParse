using System;

namespace CodeBrix.MarkupParse.Attributes; //Was previously: namespace AngleSharp.Attributes

/// <summary>
/// This attribute is used to determine the hosting interface.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, 
    AllowMultiple = true, Inherited = false)]
public sealed class DomExposedAttribute : Attribute
{
    /// <summary>
    /// Creates a new DomExposedAttribute.
    /// </summary>
    /// <param name="target">
    /// The official name of the target interface.
    /// </param>
    public DomExposedAttribute(string target)
    {
        Target = target;
    }

    /// <summary>
    /// Gets the official name of the target interface.
    /// </summary>
    public string Target { get; }
}
