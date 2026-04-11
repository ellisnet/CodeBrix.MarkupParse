using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// A list of possible quirks mode states.
/// </summary>
public enum QuirksMode : byte
{
    /// <summary>
    /// The quirks mode is deactivated.
    /// </summary>
    Off,
    /// <summary>
    /// The quirks mode is partly activated.
    /// </summary>
    Limited,
    /// <summary>
    /// The quirks mode is activated.
    /// </summary>
    [DomDescription("BackCompat")]
    On
}
