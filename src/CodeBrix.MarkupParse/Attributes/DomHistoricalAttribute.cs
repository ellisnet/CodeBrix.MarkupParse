using System;

namespace CodeBrix.MarkupParse.Attributes; //Was previously: namespace AngleSharp.Attributes

/// <summary>
/// This attribute decorates official DOM objects that should no longer be
/// used and are therefore considered deprecated.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | 
    AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Method | 
    AttributeTargets.Field | AttributeTargets.Delegate)]
public sealed class DomHistoricalAttribute : Attribute
{
}
