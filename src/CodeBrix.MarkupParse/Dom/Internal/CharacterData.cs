using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The base class for all characterdata implementations.
/// </summary>
abstract class CharacterData : Node, ICharacterData
{
    #region Fields

    private string _content;

    #endregion

    #region ctor

    internal CharacterData(Document owner, string name, NodeType type)
        : this(owner, name, type, string.Empty)
    {
    }

    internal CharacterData(Document owner, string name, NodeType type, string content)
        : base(owner, name, type)
    {
        _content = content;
    }

    #endregion

    #region Properties

    public IElement PreviousElementSibling
    {
        get
        {
            var parent = Parent;

            if (parent != null)
            {
                var found = false;

                for (var i = parent.ChildNodes.Length - 1; i >= 0; i--)
                {
                    if (object.ReferenceEquals(parent.ChildNodes[i], this))
                    {
                        found = true;
                    }
                    else if (found && parent.ChildNodes[i] is IElement childEl)
                    {
                        return childEl;
                    }
                }
            }

            return null;
        }
    }

    public IElement NextElementSibling
    {
        get
        {
            var parent = Parent;

            if (parent != null)
            {
                var n = parent.ChildNodes.Length;
                var found = false;

                for (var i = 0; i < n; i++)
                {
                    if (object.ReferenceEquals(parent.ChildNodes[i], this))
                    {
                        found = true;
                    }
                    else if (found && parent.ChildNodes[i] is IElement childEl)
                    {
                        return childEl;
                    }
                }
            }

            return null;
        }
    }

    internal char this[int index]
    {
        get => _content[index];
        set
        {
            if (index >= 0)
            {
                if (index >= Length)
                {
                    _content = _content.PadRight(index) + value.ToString();
                }
                else
                {
                    var chrs = _content.ToCharArray();
                    chrs[index] = value;
                    _content = new string(chrs);
                }
            }
        }
    }

    public int Length => _content.Length;

    public sealed override string NodeValue
    {
        get => Data;
        set => Data = value;
    }

    public sealed override string TextContent
    {
        get => Data;
        set => Data = value;
    }

    public string Data
    {
        get => _content;
        set => Replace(0, Length, value);
    }

    #endregion

    #region Methods

    public string Substring(int offset, int count)
    {
        var length = _content.Length;

        if (offset > length)
        {
            throw new DomException(DomError.IndexSizeError);
        }

        if (offset + count > length)
        {
            return _content.Substring(offset);
        }

        return _content.Substring(offset, count);
    }

    public void Append(string value) => Replace(_content.Length, 0, value);

    public void Insert(int offset, string data) => Replace(offset, 0, data);

    public void Delete(int offset, int count) => Replace(offset, count, string.Empty);

    public void Replace(int offset, int count, string data)
    {
        var owner = Owner;
        var length = _content.Length;

        if (offset > length)
        {
            throw new DomException(DomError.IndexSizeError);
        }

        if (offset + count > length)
        {
            count = length - offset;
        }

        var previous = _content;
        var deleteOffset = offset + data.Length;
        _content = _content.Insert(offset, data);

        if (count > 0)
        {
            _content = _content.Remove(deleteOffset, count);
        }

        owner.QueueMutation(MutationRecord.CharacterData(target: this, previousValue: previous));
        foreach (var m in owner.GetAttachedReferences<Range>())
        {
            if (m.Head == this && m.Start > offset && m.Start <= offset + count)
            {
                m.StartWith(this, offset);
            }
            if (m.Tail == this && m.End > offset && m.End <= offset + count)
            {
                m.EndWith(this, offset);
            }
            if (m.Head == this && m.Start > offset + count)
            {
                m.StartWith(this, m.Start + data.Length - count);
            }
            if (m.Tail == this && m.End > offset + count)
            {
                m.EndWith(this, m.End + data.Length - count);
            }
        }
    }

    public void Before(params INode[] nodes) => this.InsertBefore(nodes);

    public void After(params INode[] nodes) => this.InsertAfter(nodes);

    public void Replace(params INode[] nodes) => this.ReplaceWith(nodes);

    public void Remove() => this.RemoveFromParent();

    #endregion
}
