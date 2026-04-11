namespace CodeBrix.MarkupParse.Dom;

internal interface IPreInsert
{
    void PreInsert(Node parent, Node node, int index);
}
