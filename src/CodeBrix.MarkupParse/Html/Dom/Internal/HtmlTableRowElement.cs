using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the HTML tr element.
/// </summary>
sealed class HtmlTableRowElement : HtmlElement, IHtmlTableRowElement
{
    #region Fields

    private HtmlCollection<IHtmlTableCellElement> _cells;

    #endregion

    #region ctor

    public HtmlTableRowElement(Document owner, string prefix = null)
        : base(owner, TagNames.Tr, prefix, NodeFlags.Special | NodeFlags.ImplicitlyClosed)
    {
    }

    #endregion

    #region Properties

    public HorizontalAlignment Align
    {
        get => this.GetOwnAttribute(AttributeNames.Align).ToEnum(HorizontalAlignment.Left);
        set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public VerticalAlignment VAlign
    {
        get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum(VerticalAlignment.Middle);
        set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    public string BgColor
    {
        get => this.GetOwnAttribute(AttributeNames.BgColor);
        set => this.SetOwnAttribute(AttributeNames.BgColor, value);
    }

    public IHtmlCollection<IHtmlTableCellElement> Cells => _cells ??= new HtmlCollection<IHtmlTableCellElement>(this, deep: false);

    public int Index
    {
        get
        {
            var table = this.GetAncestor<IHtmlTableElement>();
            return table?.Rows.Index(this) ?? -1;
        }
    }

    public int IndexInSection
    {
        get
        {
            var parent = ParentElement as IHtmlTableSectionElement;
            return parent?.Rows.Index(this) ?? Index;
        }
    }

    #endregion

    #region Methods

    public IHtmlTableCellElement InsertCellAt(int index = -1, TableCellKind tableCellKind = TableCellKind.Td)
    {
        var cells = Cells;
        var newCell = (IHtmlTableCellElement)Owner.CreateElement(tableCellKind == TableCellKind.Td ? TagNames.Td : TagNames.Th);

        if (index >= 0 && index < cells.Length)
        {
            InsertBefore(newCell, cells[index]);
        }
        else
        {
            AppendChild(newCell);
        }

        return newCell;
    }

    public void RemoveCellAt(int index)
    {
        var cells = Cells;

        if (index < 0)
        {
            index = cells.Length + index;
        }

        if (index >= 0 && index < cells.Length)
        {
            cells[index].Remove();
        }
    }

    #endregion
}
