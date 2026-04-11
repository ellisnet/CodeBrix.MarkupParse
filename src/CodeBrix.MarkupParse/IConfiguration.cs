using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse; //Was previously: namespace AngleSharp

/// <summary>
/// Represents the interface for a general setup of CodeBrix.MarkupParse
/// or a particular CodeBrix.MarkupParse request.
/// </summary>
public interface IConfiguration
{
    /// <summary>
    /// Gets an enumeration over the available services.
    /// </summary>
    IEnumerable<object> Services { get; }
}
