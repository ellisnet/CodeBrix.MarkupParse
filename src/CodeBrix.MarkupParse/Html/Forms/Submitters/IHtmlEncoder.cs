using System;
using System.Text;

namespace CodeBrix.MarkupParse.Html.Forms.Submitters; //Was previously: namespace AngleSharp.Html.Forms.Submitters

/// <summary>
/// Represents the HTML encoder.
/// </summary>
public interface IHtmlEncoder
{
    /// <summary>
    /// Replaces characters in names and values that cannot be expressed by using the given
    /// encoding with &amp;#...; base-10 unicode point.
    /// </summary>
    /// <param name="value">The value to sanatize.</param>
    /// <param name="encoding">The encoding to consider.</param>
    /// <returns>The sanatized value.</returns>
    string Encode(string value, Encoding encoding);
}
