using System.IO;

namespace CodeBrix.MarkupParse; //Was previously: namespace AngleSharp

/// <summary>
/// Allows basic serialization.
/// </summary>
public interface IMarkupFormattable
{
    /// <summary>
    /// Writes the serialization of the node guided by the formatter.
    /// </summary>
    /// <param name="writer">The output target of the serialization.</param>
    /// <param name="formatter">The formatter to use.</param>
    void ToHtml(TextWriter writer, IMarkupFormatter formatter);
}
