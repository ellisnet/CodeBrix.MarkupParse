using CodeBrix.MarkupParse.Io.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Forms; //Was previously: namespace AngleSharp.Html.Forms

/// <summary>
/// Defines the visitor for form data set entries.
/// </summary>
public interface IFormDataSetVisitor
{
    /// <summary>
    /// Called by text form data set entries.
    /// </summary>
    /// <param name="entry">The entry to pass.</param>
    /// <param name="value">The contained text value.</param>
    void Text(FormDataSetEntry entry, string value);

    /// <summary>
    /// Called by file form data set entries.
    /// </summary>
    /// <param name="entry">The entry to pass.</param>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="contentType">The MIME-type.</param>
    /// <param name="content">The contained content.</param>
    void File(FormDataSetEntry entry, string fileName, string contentType, IFile content);
}
