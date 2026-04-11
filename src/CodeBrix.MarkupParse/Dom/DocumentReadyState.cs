using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Defines the document readiness.
/// </summary>
public enum DocumentReadyState : byte
{
    /// <summary>
    /// The document is still loading.
    /// </summary>
    [DomName("loading")]
    Loading,
    /// <summary>
    /// The document is interactive, i.e. interaction possible.
    /// </summary>
    [DomName("interactive")]
    Interactive,
    /// <summary>
    /// Loading is complete.
    /// </summary>
    [DomName("complete")]
    Complete
}
