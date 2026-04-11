using System;

namespace CodeBrix.MarkupParse.Attributes; //Was previously: namespace AngleSharp.Attributes

/// <summary>
/// This attribute is used to mark an enum as being just a collection of
/// constant string values (with the names being the strings).
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class DomLiteralsAttribute : Attribute
{
}
