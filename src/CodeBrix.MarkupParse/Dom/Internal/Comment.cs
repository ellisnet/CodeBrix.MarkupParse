using System;
using System.IO;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a node that contains a comment.
/// </summary>
sealed class Comment : CharacterData, IComment
{
    #region ctor

    internal Comment(Document owner)
        : this(owner, string.Empty)
    {
    }

    internal Comment(Document owner, string data)
        : base(owner, "#comment", NodeType.Comment, data)
    {
    }

    #endregion

    #region Methods

    public override Node Clone(Document owner, bool deep)
    {
        var node = new Comment(owner, Data);
        CloneNode(node, owner, deep);
        return node;
    }

    #endregion
}
