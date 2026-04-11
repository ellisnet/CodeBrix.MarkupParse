using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Html; //Was previously: namespace AngleSharp.Html

/// <summary>
/// Represents the an HTML5 markup formatter with inserted indents.
/// </summary>
public class PrettyMarkupFormatter : HtmlMarkupFormatter
{
    #region Fields

    private string _indentString;
    private string _newLineString;
    private int _indentCount;
    private IEnumerable<INode> _preserveTextFormatting;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new instance of the pretty markup formatter.
    /// </summary>
    public PrettyMarkupFormatter()
    {
        _indentCount = 0;
        _indentString = "\t";
        _newLineString = "\n";
    }

    /// <summary>
    ///  Creates a new instance of the pretty markup formatter,
    ///  along with nodes where formatting of text shall be ignored
    /// </summary>
    /// <param name="preserveTextFormatting">Nodes in which the structure of the
    ///  text content should be preserved</param>
    public PrettyMarkupFormatter(IEnumerable<INode> preserveTextFormatting)
    {
        _indentCount = 0;
        _indentString = "\t";
        _newLineString = "\n";
        _preserveTextFormatting = preserveTextFormatting.SelectMany(x => (IEnumerable<INode>)x.ChildNodes).Where(y => y is ICharacterData);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the indentation string.
    /// </summary>
    public string Indentation
    {
        get => _indentString;
        set => _indentString = value;
    }

    /// <summary>
    /// Gets or sets the newline string.
    /// </summary>
    public string NewLine
    {
        get => _newLineString;
        set => _newLineString = value;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override string Comment(IComment comment) =>
        IndentBefore() + base.Comment(comment);

    /// <inheritdoc />
    public override string Doctype(IDocumentType doctype)
    {
        var before = string.Empty;

        if (doctype.ParentElement != null)
        {
            before = IndentBefore();
        }

        return before + base.Doctype(doctype) + NewLine;
    }

    /// <inheritdoc />
    public override string Processing(IProcessingInstruction processing) =>
        IndentBefore() + base.Processing(processing);

    /// <inheritdoc />
    public override string Text(ICharacterData text)
    {
        if (_preserveTextFormatting?.Contains(text) == true)
        {
            return text.Data.TrimEnd('\n').Replace("\n", IndentBefore(1));
        }
        var content = text.Data;
        var before = string.Empty;
        var singleLine = content.Replace(Symbols.LineFeed, Symbols.Space);

        if (text.NextSibling is ICharacterData == false)
        {
            singleLine = singleLine.TrimEnd();
        }

        if (singleLine.Length > 0 && text.PreviousSibling is ICharacterData == false && singleLine[0].IsSpaceCharacter())
        {
            singleLine = singleLine.TrimStart();
            before = IndentBefore();
        }

        return before + EscapeText(singleLine);
    }

    /// <inheritdoc />
    public override string OpenTag(IElement element, bool selfClosing)
    {
        var before = string.Empty;
        var previousSibling = element.PreviousSibling as IText;

        if (element.ParentElement != null && (previousSibling is null || EndsWithSpace(previousSibling)))
        {
            before = IndentBefore();
        }            

        _indentCount++;
        return before + base.OpenTag(element, selfClosing);
    }

    /// <inheritdoc />
    public override string CloseTag(IElement element, bool selfClosing)
    {
        _indentCount--;
        var before = string.Empty;
        var lastChild = element.LastChild as IText;

        if (element.HasChildNodes && (lastChild is null || EndsWithSpace(lastChild)))
        {
            before = IndentBefore();
        }
        
        return before + base.CloseTag(element, selfClosing);
    }

    #endregion

    #region Helpers

    private static bool EndsWithSpace(ICharacterData text)
    {
        var content = text.Data;
        return content.Length > 0 && content[content.Length - 1].IsSpaceCharacter();
    }

    private string IndentBefore(int i =0) => _newLineString + string.Join(string.Empty, Enumerable.Repeat(_indentString, _indentCount-i));

    #endregion
}
