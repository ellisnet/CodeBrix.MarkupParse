using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents a recording of DOM changes.
/// </summary>
sealed class MutationRecord : IMutationRecord
{
    #region Fields

    static readonly string CharacterDataType = "characterData";
    static readonly string AttributesType = "attributes";
    static readonly string ChildListType = "childList";

    #endregion

    #region ctor

    MutationRecord() { }
    #endregion

    #region Methods

    public static MutationRecord CharacterData(INode target, string previousValue = null)
    {
        return new MutationRecord
        {
            Type = CharacterDataType,
            Target = target,
            PreviousValue = previousValue
        };
    }

    public static MutationRecord ChildList(INode target, INodeList addedNodes = null, INodeList removedNodes = null, INode previousSibling = null, INode nextSibling = null)
    {
        return new MutationRecord
        {
            Type = ChildListType,
            Target = target,
            Added = addedNodes,
            Removed = removedNodes,
            PreviousSibling = previousSibling,
            NextSibling = nextSibling
        };
    }

    public static MutationRecord Attributes(INode target, string attributeName = null, string attributeNamespace = null, string previousValue = null)
    {
        return new MutationRecord
        {
            Type = AttributesType,
            Target = target,
            AttributeName = attributeName,
            AttributeNamespace = attributeNamespace,
            PreviousValue = previousValue
        };
    }

    public MutationRecord Copy(bool clearPreviousValue)
    {
        return new MutationRecord
        {
            Type = Type,
            Target = Target,
            PreviousSibling = PreviousSibling,
            NextSibling = NextSibling,
            AttributeName = AttributeName,
            AttributeNamespace = AttributeNamespace,
            PreviousValue = clearPreviousValue ? null : PreviousValue,
            Added = Added,
            Removed = Removed
        };
    }

    #endregion

    #region Properties

    public bool IsAttribute => Type.Is(AttributesType);

    public bool IsCharacterData => Type.Is(CharacterDataType);

    public bool IsChildList => Type.Is(ChildListType);

    public string Type
    {
        get;
        private set;
    }

    public INode Target
    {
        get;
        private set;
    }

    public INodeList Added
    {
        get;
        private set;
    }

    public INodeList Removed
    {
        get;
        private set;
    }

    public INode PreviousSibling
    {
        get;
        private set;
    }

    public INode NextSibling
    {
        get;
        private set;
    }

    public string AttributeName
    {
        get;
        private set;
    }

    public string AttributeNamespace
    {
        get;
        private set;
    }

    public string PreviousValue
    {
        get;
        private set;
    }

    #endregion
}
