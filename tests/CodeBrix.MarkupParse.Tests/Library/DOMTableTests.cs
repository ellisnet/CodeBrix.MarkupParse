using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class DOMTableTests
{
    private static readonly string HTMLNS = "http://www.w3.org/1999/xhtml";
    private static readonly string SectionRowIndexCode = @"<table>
  <thead>
    <tr id=ht1></tr>
  </thead>
  <tr id=t1></tr>
  <tr id=t2>
    <td>
      <table>
        <thead>
          <tr id=nht1></tr>
        </thead>
        <tr></tr>
        <tr id=nt1></tr>
        <tbody>
          <tr id=nbt1></tr>
        </tbody>
      </table>
    </td>
  </tr>
  <tbody>
    <tr></tr>
    <tr id=bt1></tr>
  </tbody>
  <tfoot>
    <tr></tr>
    <tr></tr>
    <tr id=ft1></tr>
  </tfoot>
</table> ";

    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void ChildrenOfTableDirectly()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        SimpleTableTest(document, table, table);
    }

    [Fact]
    public void ChildrenOfTableHead()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        var group = table.AppendChild(document.CreateElement("thead")) as IElement;
        SimpleTableTest(document, group, table);
    }

    [Fact]
    public void ChildrenOfTableFoot()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        var group = table.AppendChild(document.CreateElement("tfoot")) as IElement;
        SimpleTableTest(document, group, table);
    }

    [Fact]
    public void ChildrenOfTableBody()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        var group = table.AppendChild(document.CreateElement("tbody")) as IElement;
        SimpleTableTest(document, group, table);
    }

    [Fact]
    public void ChildrenOfTableAndVariousSections()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        var orphan1 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan1.Id = "orphan1";
        var foot1 = table.AppendChild(document.CreateElement("tfoot"));
        var orphan2 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan2.Id = "orphan2";
        var foot2 = table.AppendChild(document.CreateElement("tfoot"));
        var orphan3 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan3.Id = "orphan3";
        var body1 = table.AppendChild(document.CreateElement("tbody"));
        var orphan4 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan4.Id = "orphan4";
        var body2 = table.AppendChild(document.CreateElement("tbody"));
        var orphan5 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan5.Id = "orphan5";
        var head1 = table.AppendChild(document.CreateElement("thead"));
        var orphan6 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan6.Id = "orphan6";
        var head2 = table.AppendChild(document.CreateElement("thead"));
        var orphan7 = table.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        orphan7.Id = "orphan7";
        var foot1row1 = foot1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        foot1row1.Id = "foot1row1";
        var foot1row2 = foot1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        foot1row2.Id = "foot1row2";
        var foot2row1 = foot2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        foot2row1.Id = "foot2row1";
        var foot2row2 = foot2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        foot2row2.Id = "foot2row2";
        var body1row1 = body1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        body1row1.Id = "body1row1";
        var body1row2 = body1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        body1row2.Id = "body1row2";
        var body2row1 = body2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        body2row1.Id = "body2row1";
        var body2row2 = body2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        body2row2.Id = "body2row2";
        var head1row1 = head1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        head1row1.Id = "head1row1";
        var head1row2 = head1.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        head1row2.Id = "head1row2";
        var head2row1 = head2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        head2row1.Id = "head2row1";
        var head2row2 = head2.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
        head2row2.Id = "head2row2";

        // These elements should not end up in any collection.
        table.AppendChild(document.CreateElement("div"))
             .AppendChild(document.CreateElement("tr"));
        foot1.AppendChild(document.CreateElement("div"))
             .AppendChild(document.CreateElement("tr"));
        body1.AppendChild(document.CreateElement("div"))
             .AppendChild(document.CreateElement("tr"));
        head1.AppendChild(document.CreateElement("div"))
             .AppendChild(document.CreateElement("tr"));
        table.AppendChild(document.CreateElement("http://example.com/test", "tr"));
        foot1.AppendChild(document.CreateElement("http://example.com/test", "tr"));
        body1.AppendChild(document.CreateElement("http://example.com/test", "tr"));
        head1.AppendChild(document.CreateElement("http://example.com/test", "tr"));

        var rows = (table as IHtmlTableElement).Rows;
        Assert.NotNull(rows);

        Assert.Equal(new IHtmlTableRowElement[] {
            // thead
            head1row1,
            head1row2,
            head2row1,
            head2row2,
            // tbody + table
            orphan1,
            orphan2,
            orphan3,
            body1row1,
            body1row2,
            orphan4,
            body2row1,
            body2row2,
            orphan5,
            orphan6,
            orphan7,
            // tfoot
            foot1row1,
            foot1row2,
            foot2row1,
            foot2row2
        }, rows.ToArray());

        var ids = new[] {
            "orphan1",
            "orphan2",
            "orphan3",
            "orphan4",
            "orphan5",
            "orphan6",
            "orphan7",
            "foot1row1",
            "foot1row2",
            "foot2row1",
            "foot2row2",
            "body1row1",
            "body1row2",
            "body2row1",
            "body2row2",
            "head1row1",
            "head1row2",
            "head2row1",
            "head2row2"
        };

        foreach (var id in ids)
        {
            Assert.Equal(id, rows[id].Id);
        }

        while (table.FirstChild != null)
        {
            table.RemoveChild(table.FirstChild);
        }

        foreach (var id in ids)
        {
            Assert.Null(rows[id]);
        }
    }

    [Fact]
    public void MoveTableAndAppendCells()
    {
        var text =
          "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
          "  <head>" +
          "    <title>Virtual Library</title>" +
          "  </head>" +
          "  <body>" +
          "    <table id=\"mytable\" border=\"1\">" +
          "      <tbody>" +
          "        <tr><td>Cell 1</td><td>Cell 2</td></tr>" +
          "        <tr><td>Cell 3</td><td>Cell 4</td></tr>" +
          "      </tbody>" +
          "    </table>" +
          "  </body>" +
          "</html>";
        var document = Html("");
        var doc = text.ToHtmlDocument();
        // import <table>
        var table = doc.DocumentElement.GetElementsByTagName("table")[0];
        var mytable = document.Body.AppendChild(document.Import(table, true)) as IHtmlTableElement;
        Assert.NotNull(mytable);
        Assert.Single(mytable.Bodies);
        var tbody = document.CreateElement("tbody") as IHtmlTableSectionElement;
        mytable.AppendChild(tbody);
        var tr = tbody.InsertRowAt(-1);
        tr.InsertCellAt(-1).AppendChild(document.CreateTextNode("Cell 5"));
        tr.InsertCellAt(-1).AppendChild(document.CreateTextNode("Cell 6"));
        Assert.Equal(2, mytable.Bodies.Length);
        Assert.Equal(3, mytable.Rows.Length);
        Assert.Equal(2, tr.Index);
    }

    [Fact]
    public void TableBodyNoChildNodes()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var tbody = table.CreateBody();
        Assert.Equal(table.FirstChild, tbody);
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyOneTbodyChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        Assert.Equal(new[] { before }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new[] { before, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTwoTbodyChildNodes()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before1 = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        var before2 = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        Assert.Equal(new[] { before1, before2 }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new[] { before1, before2, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTheadAndTbodyChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before1 = table.AppendChild(document.CreateElement("thead")) as IHtmlTableSectionElement;
        var before2 = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        Assert.Equal(new[] { before1, before2 }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new[] { before1, before2, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTfootAndTbodyChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before1 = table.AppendChild(document.CreateElement("tfoot"));
        var before2 = table.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new[] { before1, before2 }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new[] { before1, before2, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTbodyAndTheadChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        var after = table.AppendChild(document.CreateElement("thead")) as IHtmlTableSectionElement;
        Assert.Equal(new INode[] { before, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTbodyAndTfootChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        var after = table.AppendChild(document.CreateElement("tfoot")) as IHtmlTableSectionElement;
        Assert.Equal(new INode[] { before, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTwoTbodyChildNodesAndADiv()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before1 = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        var before2 = table.AppendChild(document.CreateElement("tbody")) as IHtmlTableSectionElement;
        var after = table.AppendChild(document.CreateElement("div"));
        Assert.Equal(new INode[] { before1, before2, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before1, before2, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyOneHtmlOneNamespacedTBodyElement()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody"));
        var after = table.AppendChild(document.CreateElement("x", "tbody"));
        Assert.Equal(new[] { before, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new[] { before, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyTwoNestedTBodyChildNodes()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody"));
        before.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new INode[] { before }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyATBodyInsideATHead()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("thead"));
        before.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new INode[] { before }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyATBodyInsideATFoot()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tfoot"));
        before.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new INode[] { before }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyATBodyNodeInsideATHeadChildNodeAfterATBodyChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody"));
        var after = table.AppendChild(document.CreateElement("thead"));
        after.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new INode[] { before, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableBodyATBodyNodeInsideATFootChildNodeAfterATBodyChildNode()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var before = table.AppendChild(document.CreateElement("tbody"));
        var after = table.AppendChild(document.CreateElement("tfoot"));
        after.AppendChild(document.CreateElement("tbody"));
        Assert.Equal(new INode[] { before, after }, table.ChildNodes.ToArray());

        var tbody = table.CreateBody();
        Assert.Equal(new INode[] { before, tbody, after }, table.ChildNodes.ToArray());
        AssertTableBody(tbody);
    }

    [Fact]
    public void TableInsertRowShouldNotCopyPrefixes()
    {
        var document = Html("");
        var parentEl = document.CreateElement(HTMLNS, "html:table") as IHtmlTableElement;
        Assert.Equal(HTMLNS, parentEl.NamespaceUri);
        Assert.Equal("html", parentEl.Prefix);
        Assert.Equal("table", parentEl.LocalName);
        Assert.Equal("HTML:TABLE", parentEl.TagName);
        var row = parentEl.InsertRowAt(-1);
        Assert.Equal(HTMLNS, row.NamespaceUri);
        Assert.Null(row.Prefix);
        Assert.Equal("tr", row.LocalName);
        Assert.Equal("TR", row.TagName);
        var body = row.ParentElement;
        Assert.Equal(HTMLNS, body.NamespaceUri);
        Assert.Null(body.Prefix);
        Assert.Equal("tbody", body.LocalName);
        Assert.Equal("TBODY", body.TagName);
        Assert.Equal(new INode[] { body }, parentEl.ChildNodes.ToArray());
        Assert.Equal(new INode[] { row }, body.ChildNodes.ToArray());
        Assert.Equal(new IHtmlTableRowElement[] { row }, parentEl.Rows.ToArray());
    }

    [Fact]
    public void TableInsertRowShouldInsertIntoTbodyNotTheadIfTableRowsIsEmpty()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var head = table.AppendChild(document.CreateElement("thead"));
        Assert.Equal(Array.Empty<INode>(), table.Rows.ToArray());
        var row = table.InsertRowAt(-1);
        var body = row.Parent;
        Assert.Equal(new INode[] { head, body }, table.ChildNodes.ToArray());
        Assert.Equal(Array.Empty<INode>(), head.ChildNodes.ToArray());
        Assert.Equal(new INode[] { row }, body.ChildNodes.ToArray());
        Assert.Equal(new INode[] { row }, table.Rows.ToArray());
    }

    [Fact]
    public void TableInsertRowShouldInsertIntoTbodyNotTfootIfTableRowsIsEmpty()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var foot = table.AppendChild(document.CreateElement("tfoot"));
        Assert.Equal(Array.Empty<INode>(), table.Rows.ToArray());
        var row = table.InsertRowAt(-1);
        var body = row.Parent;
        Assert.Equal(new INode[] { foot, body }, table.ChildNodes.ToArray());
        Assert.Equal(Array.Empty<INode>(), foot.ChildNodes.ToArray());
        Assert.Equal(new INode[] { row }, body.ChildNodes.ToArray());
        Assert.Equal(new INode[] { row }, table.Rows.ToArray());
    }

    [Fact]
    public void TableCreateCaptionReturnsTheFirstCaptionElementChildOfTheTable()
    {
        var document = Html(@"<table>
		<caption>caption</caption>
		<tr>
			<td>cell</td>
			<td>cell</td>
		</tr>
	</table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        var testCaption = table.CreateCaption();
        var tableFirstCaption = table.Caption;
        Assert.Equal(tableFirstCaption, testCaption);
    }

    [Fact]
    public void TableCreateCaptionCreatesNewCaptionAndInsertsItAsTheFirstNodeOfTheTableElement()
    {
        var document = Html(@"<table>
		<tr>
			<td>cell</td>
			<td>cell</td>
		</tr>
	</table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        var testCaption = table.CreateCaption();
        var tableFirstNode = table.FirstChild;
        Assert.NotNull(testCaption);
        Assert.Equal(testCaption, tableFirstNode);
    }

    [Fact]
    public void TableDeleteCaptionRemovesTheFirstCaptionElementChildOfTheTableElement()
    {
        var document = Html(@"<table>
		<caption>caption</caption>
		<tr>
			<td>cell</td>
			<td>cell</td>
		</tr>
	</table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        Assert.Equal("caption", table.Caption.TextContent);
        table.DeleteCaption();
        Assert.Null(table.Caption);
    }

    [Fact]
    public void TableFirstCaptionElementChild()
    {
        var document = Html(@"<table>
      <tr><td></td></tr>
      <caption>first caption</caption>
      <caption>second caption</caption>
    </table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        Assert.Equal("first caption", table.Caption.InnerHtml);
    }

    [Fact]
    public void TableSettingCaption()
    {
        var document = Html(@"<table>
      <tr><td></td></tr>
      <caption>first caption</caption>
      <caption>second caption</caption>
    </table>");
        var caption = document.CreateElement("caption") as IHtmlTableCaptionElement;
        caption.InnerHtml = "new caption";
        var table = document.QuerySelector("table") as IHtmlTableElement;
        table.Caption = caption;
        Assert.Equal(table, caption.Parent);
        Assert.Equal("new caption", table.Caption.InnerHtml);
        var captions = table.GetElementsByTagName("caption");
        Assert.Equal(2, captions.Length);
        Assert.Equal("new caption", captions[0].InnerHtml);
        Assert.Equal("second caption", captions[1].InnerHtml);
    }

    [Fact]
    public void TableWithNoCaption()
    {
        var document = Html(@"<table>
      <tr><td></td></tr>
    </table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        Assert.Null(table.Caption);
    }

    [Fact]
    public void TableWithNestedCaption()
    {
        var document = Html(@"<table>
      <tr><td></td></tr>
    </table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        var caption = document.CreateElement("caption");
        table.Rows[0].AppendChild(caption);
        Assert.Null(table.Caption);
    }

    [Fact]
    public void TableDynamicallyRemovingTheCaption()
    {
        var document = Html(@"<table>
      <tr><td></td></tr>
      <caption>first caption</caption>
    </table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;
        Assert.NotNull(table.Caption);
        table.Caption.Remove();
        Assert.Null(table.Caption);
    }

    [Fact]
    public void TableRowIndexUndefinedInDiv()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("div"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexDefinedInTableHead()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("thead"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(0, row.Index);
    }

    [Fact]
    public void TableRowIndexDefinedInTableBody()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("tbody"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(0, row.Index);
    }

    [Fact]
    public void TableRowIndexDefinedInTableFoot()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("tfoot"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(0, row.Index);
    }

    [Fact]
    public void TableRowIndexDefinedInTable()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(0, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInTableHeadOfNamespacedTable()
    {
        var document = Html("");
        var row = document.CreateElement("", "table")
                          .AppendChild(document.CreateElement("thead"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInTableBodyOfNamespacedTable()
    {
        var document = Html("");
        var row = document.CreateElement("", "table")
                          .AppendChild(document.CreateElement("tbody"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInTableFootOfNamespacedTable()
    {
        var document = Html("");
        var row = document.CreateElement("", "table")
                          .AppendChild(document.CreateElement("tfoot"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInNamespacedTable()
    {
        var document = Html("");
        var row = document.CreateElement("", "table")
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInNamespacedTableHead()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("", "thead"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInNamespacedTableBody()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("", "tbody"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowIndexUndefinedInNamespacedTableFoot()
    {
        var document = Html("");
        var row = document.CreateElement("table")
                          .AppendChild(document.CreateElement("", "tfoot"))
                          .AppendElement(document.CreateElement<IHtmlTableRowElement>());
        Assert.Equal(-1, row.Index);
    }

    [Fact]
    public void TableRowInThead()
    {
        var document = Html(SectionRowIndexCode);
        var tHeadRow = document.GetElementById("ht1") as IHtmlTableRowElement;
        Assert.Equal(0, tHeadRow.IndexInSection);
    }

    [Fact]
    public void TableRowInImplicitTbody()
    {
        var document = Html(SectionRowIndexCode);
        var tRow1 = document.GetElementById("t1") as IHtmlTableRowElement;
        Assert.Equal(0, tRow1.IndexInSection);
    }

    [Fact]
    public void TableOtherRowInImplicitTbody()
    {
        var document = Html(SectionRowIndexCode);
        var tRow2 = document.GetElementById("t2") as IHtmlTableRowElement;
        Assert.Equal(1, tRow2.IndexInSection);
    }

    [Fact]
    public void TableRowInExplicitTbody()
    {
        var document = Html(SectionRowIndexCode);
        var tBodyRow = document.GetElementById("bt1") as IHtmlTableRowElement;
        Assert.Equal(1, tBodyRow.IndexInSection);
    }

    [Fact]
    public void TableRowInTfoot()
    {
        var document = Html(SectionRowIndexCode);
        var tFootRow = document.GetElementById("ft1") as IHtmlTableRowElement;
        Assert.Equal(2, tFootRow.IndexInSection);
    }

    [Fact]
    public void TableRowInTheadInNestedTable()
    {
        var document = Html(SectionRowIndexCode);
        var childHeadRow = document.GetElementById("nht1") as IHtmlTableRowElement;
        Assert.Equal(0, childHeadRow.IndexInSection);
    }

    [Fact]
    public void TableRowInImplicitTbodyInNestedTable()
    {
        var document = Html(SectionRowIndexCode);
        var childRow = document.GetElementById("nt1") as IHtmlTableRowElement;
        Assert.Equal(1, childRow.IndexInSection);
    }

    [Fact]
    public void TableRowInExplicitTbodyInNestedTable()
    {
        var document = Html(SectionRowIndexCode);
        var childBodyRow = document.GetElementById("nbt1") as IHtmlTableRowElement;
        Assert.Equal(0, childBodyRow.IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTable()
    {
        Assert.Equal(0, MakeRowElement().IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedDivInTable()
    {
        Assert.Equal(-1, MakeRowElement("div").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTheadInTable()
    {
        Assert.Equal(0, MakeRowElement("thead").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTbodyInTable()
    {
        Assert.Equal(0, MakeRowElement("tbody").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTfootInTable()
    {
        Assert.Equal(0, MakeRowElement("tfoot").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTrInTbodyInTable()
    {
        Assert.Equal(-1, MakeRowElement("tbody", "tr").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTdInTrInTbodyInTable()
    {
        Assert.Equal(-1, MakeRowElement("tbody", "tr", "td").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedNestedTable()
    {
        Assert.Equal(0, MakeRowElement("tbody", "tr", "td", "table").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTheadInNestedTable()
    {
        Assert.Equal(0, MakeRowElement("tbody", "tr", "td", "table", "thead").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTbodyInNestedTable()
    {
        Assert.Equal(0, MakeRowElement("tbody", "tr", "td", "table", "tbody").IndexInSection);
    }

    [Fact]
    public void TableRowInScriptCreatedTfootInNestedTable()
    {
        Assert.Equal(0, MakeRowElement("tbody", "tr", "td", "table", "tfoot").IndexInSection);
    }

    [Fact]
    public void TableForCellsWithoutAParentCellIndexShouldBeMissing()
    {
        var document = Html("");
        var th = document.CreateElement("th") as IHtmlTableHeaderCellElement;
        Assert.Equal(-1, th.Index);
        var td = document.CreateElement("td") as IHtmlTableDataCellElement;
        Assert.Equal(-1, td.Index);
    }
    
    [Fact]
    public void TableForCellsWhoseParentIsNotRowCellIndexShouldBeMissing()
    {
        var document = Html("");
        var table = document.CreateElement("table");
        var th = table.AppendChild(document.CreateElement("th")) as IHtmlTableHeaderCellElement;
        Assert.Equal(-1, th.Index);
        var td = table.AppendChild(document.CreateElement("td")) as IHtmlTableDataCellElement;
        Assert.Equal(-1, td.Index);
    }
    
    [Fact]
    public void TableForCellsWhoseParentIsNotARowCellIndexShouldBeMissing()
    {
        var document = Html("");
        var tr = document.CreateElement("", "tr");
        var th = tr.AppendChild(document.CreateElement("th")) as IHtmlTableHeaderCellElement;
        Assert.Equal(-1, th.Index);
        var td = tr.AppendChild(document.CreateElement("td")) as IHtmlTableDataCellElement;
        Assert.Equal(-1, td.Index);
    }
    
    [Fact]
    public void TableForCellsWhoseParentIsARowCellIndexShouldBeTheIndex()
    {
        var document = Html("");
        var tr = document.CreateElement("tr");
        var th = tr.AppendChild(document.CreateElement("th")) as IHtmlTableHeaderCellElement;
        Assert.Equal(0, th.Index);
        var td = tr.AppendChild(document.CreateElement("td")) as IHtmlTableDataCellElement;
        Assert.Equal(1, td.Index);
    }

    [Fact]
    public void TableCellRowSpanFollowsDefaultValue_Issue688()
    {
        var document = Html("");
        var tr = document.CreateElement("tr");
        var td = tr.AppendChild(document.CreateElement("td")) as IHtmlTableDataCellElement;
        Assert.Equal(1, td.RowSpan);
        td.RowSpan = 0;
        Assert.Equal(0, td.RowSpan);
        td.RowSpan = 100000;
        Assert.Equal(65534, td.RowSpan);
    }

    [Fact]
    public void TableCellColSpanFollowsDefaultValue_Issue689()
    {
        var document = Html("");
        var tr = document.CreateElement("tr");
        var td = tr.AppendChild(document.CreateElement("td")) as IHtmlTableDataCellElement;
        Assert.Equal(1, td.ColumnSpan);
        td.ColumnSpan = 0;
        Assert.Equal(1, td.ColumnSpan);
        td.ColumnSpan = 100000;
        Assert.Equal(1, td.ColumnSpan);
        td.ColumnSpan = 1000;
        Assert.Equal(1000, td.ColumnSpan);
    }

    [Fact]
    public void InsertCellsWithTableCellKind_Issue818()
    {
        var document = Html("");
        var table = document.CreateElement("table") as IHtmlTableElement;
        var row = table.InsertRowAt();
        row.InsertCellAt(tableCellKind: TableCellKind.Td);
        row.InsertCellAt(tableCellKind: TableCellKind.Th);

        Assert.Equal(TagNames.Td, row.Children[0].TagName, System.StringComparer.OrdinalIgnoreCase);
        Assert.Equal(TagNames.Th, row.Children[1].TagName, System.StringComparer.OrdinalIgnoreCase);
    }

    private static IHtmlTableRowElement MakeRowElement(params string[] names)
    {
        var document = Html("");
        var elm = document.CreateElement("table");

        foreach (var name in names)
        {
            var node = document.CreateElement(name);
            elm.AppendChild(node);
            elm = node;
        }

        return elm.AppendChild(document.CreateElement("tr")) as IHtmlTableRowElement;
    }

    private static void AssertTableBody(IHtmlTableSectionElement body)
    {
        Assert.Equal("tbody", body.LocalName);
        Assert.Equal(HTMLNS, body.NamespaceUri);
        Assert.Null(body.Prefix);
    }

    private static void SimpleTableTest(IDocument document, IElement group, IElement table)
    {
        var foo1 = group.AppendChild(document.CreateElement("tr")) as IElement;
        foo1.Id = "foo";
        var bar1 = group.AppendChild(document.CreateElement("tr")) as IElement;
        bar1.Id = "bar";
        var foo2 = group.AppendChild(document.CreateElement("tr")) as IElement;
        foo2.Id = "foo";
        var bar2 = group.AppendChild(document.CreateElement("tr")) as IElement;
        bar2.Id = "bar";
        var rows = (table as IHtmlTableElement).Rows;
        Assert.NotNull(rows);
        Assert.Equivalent(new[] { foo1, bar1, foo2, bar2 }, rows);
        Assert.Equal(foo1, rows["foo"]);
        Assert.Equal(bar1, rows["bar"]);
    }
}
