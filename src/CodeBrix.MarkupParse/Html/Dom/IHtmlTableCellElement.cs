using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Reprsents the base for td / th HTML element.
/// </summary>
[DomName("HTMLTableCellElement")]
public interface IHtmlTableCellElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the number of columns spanned by cell. 
    /// </summary>
    [DomName("colSpan")]
    int ColumnSpan { get; set; }

    /// <summary>
    /// Gets or sets the number of rows spanned by cell. 
    /// </summary>
    [DomName("rowSpan")]
    int RowSpan { get; set; }

    /// <summary>
    /// Gets or sets the list of id attribute values for header cells. 
    /// </summary>
    [DomName("headers")]
    ISettableTokenList Headers { get; }

    /// <summary>
    /// Gets the index of this cell in the row, starting from 0.
    /// This index is in document tree order and not display order.
    /// </summary>
    [DomName("cellIndex")]
    int Index { get; }
}
