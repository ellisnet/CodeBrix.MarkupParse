using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Media.Dom; //Was previously: namespace AngleSharp.Media.Dom

/// <summary>
/// Stores information about media errors.
/// </summary>
[DomName("MediaError")]
public interface IMediaError
{
    /// <summary>
    /// Gets the code that represents the media error.
    /// </summary>
    [DomName("code")]
    MediaErrorCode Code { get; }
}
