using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Css.Parser;
using CodeBrix.MarkupParse.Dom.Events;
using CodeBrix.MarkupParse.Html.Construction;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Html.Parser.Tokens.Struct;
using CodeBrix.MarkupParse.Text;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Represents an element node.
/// </summary>
public abstract class Element : Node, IElement, IConstructableElement
{
    #region Fields

    private readonly NamedNodeMap _attributes;
    private readonly string _namespace;
    private readonly string _prefix;
    private readonly string _localName;
    private HtmlCollection<IElement> _elements;
    private TokenList _classList;
    private IShadowRoot _shadowRoot;

    #endregion

    #region ctor

    /// <inheritdoc />
    public Element(Document owner, string localName, string prefix, string namespaceUri, NodeFlags flags = NodeFlags.None)
        : this(owner, prefix != null ? string.Concat(prefix, ":", localName) : localName, localName, prefix, namespaceUri!, flags)
    {
    }

    /// <inheritdoc />
    public Element(Document owner, string name, string localName, string prefix, string namespaceUri, NodeFlags flags = NodeFlags.None)
        : base(owner, name, NodeType.Element, flags)
    {
        _localName = localName;
        _prefix = prefix;
        _namespace = namespaceUri;
        _attributes = new NamedNodeMap(this);
    }

    #endregion

    #region Internal Properties

    internal IBrowsingContext Context => Owner?.Context!;

    internal NamedNodeMap Attributes => _attributes;

    #endregion

    #region Properties

    /// <inheritdoc />
    public IElement AssignedSlot => ParentElement?.ShadowRoot?.GetAssignedSlot(Slot);

    /// <inheritdoc />
    public string Slot
    {
        get => this.GetOwnAttribute(AttributeNames.Slot);
        set => this.SetOwnAttribute(AttributeNames.Slot, value);
    }

    /// <inheritdoc />
    public IShadowRoot ShadowRoot => _shadowRoot;

    /// <inheritdoc />
    public string Prefix => _prefix;

    /// <inheritdoc />
    public string LocalName => _localName;

    /// <inheritdoc />
    public string NamespaceUri => _namespace ?? this.GetNamespaceUri();

    /// <inheritdoc />
    public string GivenNamespaceUri => _namespace;

    /// <inheritdoc />
    public override string TextContent
    {
        get
        {
            var sb = StringBuilderPool.Obtain();

            foreach (var child in this.GetDescendants().OfType<IText>())
            {
                sb.Append(child.Data);
            }

            return sb.ToPool();
        }
        set
        {
            var node = !string.IsNullOrEmpty(value) ? new TextNode(Owner, value) : null;
            ReplaceAll(node, false);
        }
    }

    /// <inheritdoc />
    public ITokenList ClassList
    {
        get
        {
            if (_classList is null)
            {
                _classList = new TokenList(this.GetOwnAttribute(AttributeNames.Class));
                _classList.Changed += value => UpdateAttribute(AttributeNames.Class, value);
            }

            return _classList;
        }
    }

    /// <inheritdoc />
    public string ClassName
    {
        get => this.GetOwnAttribute(AttributeNames.Class);
        set => this.SetOwnAttribute(AttributeNames.Class, value);
    }

    /// <inheritdoc />
    public string Id
    {
        get => this.GetOwnAttribute(AttributeNames.Id);
        set => this.SetOwnAttribute(AttributeNames.Id, value);
    }

    /// <inheritdoc />
    public string TagName => NodeName;

    /// <inheritdoc />
    public ISourceReference SourceReference { get; set; }

    /// <inheritdoc />
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
                    else if (found && parent.ChildNodes[i] is IElement previousElementSibling)
                    {
                        return previousElementSibling;
                    }
                }
            }

            return null;
        }
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public int ChildElementCount
    {
        get
        {
            var children = ChildNodes;
            var n = children.Length;
            var count = 0;

            for (var i = 0; i < n; i++)
            {
                if (children[i].NodeType == NodeType.Element)
                {
                    count++;
                }
            }

            return count;
        }
    }

    /// <inheritdoc />
    public IHtmlCollection<IElement> Children => _elements ??= new HtmlCollection<IElement>(this, deep: false);

    /// <inheritdoc />
    public IElement FirstElementChild
    {
        get
        {
            var children = ChildNodes;
            var n = children.Length;

            for (var i = 0; i < n; i++)
            {
                if (children[i] is IElement child)
                {
                    return child;
                }
            }

            return null;
        }
    }

    /// <inheritdoc />
    public IElement LastElementChild
    {
        get
        {
            var children = ChildNodes;

            for (var i = children.Length - 1; i >= 0; i--)
            {

                if (children[i] is IElement child)
                {
                    return child;
                }
            }

            return null;
        }
    }

    /// <inheritdoc />
    public string InnerHtml
    {
        get => ChildNodes.ToHtml();
        set => ReplaceAll(new DocumentFragment(this, value), false);
    }

    /// <inheritdoc />
    public string OuterHtml
    {
        get => this.ToHtml();
        set
        {
            var parentNode = Parent;

            if (parentNode != null)
            {
                switch (parentNode.NodeType)
                {
                    case NodeType.Document:
                        throw new DomException(DomError.NoModificationAllowed);
                    case NodeType.DocumentFragment:
                        parentNode = new Html.Dom.HtmlBodyElement(Owner);
                        break;
                }
            }

            var parent = parentNode as Element ?? throw new DomException(DomError.NotSupported);
            parent.InsertChild(parent.IndexOf(this), new DocumentFragment(parent, value));
            parent.RemoveChild(this);
        }
    }

    INamedNodeMap IElement.Attributes => _attributes;

    /// <inheritdoc />
    public bool IsFocused
    {
        get => object.ReferenceEquals(Owner?.FocusElement, this);
        protected set
        {
            var document = Owner;
            document?.QueueTask(() =>
            {
                if (value)
                {
                    document.SetFocus(this);
                    this.Fire<FocusEvent>(m => m.Init(EventNames.Focus, false, false));
                }
                else
                {
                    document.SetFocus(null);
                    this.Fire<FocusEvent>(m => m.Init(EventNames.Blur, false, false));
                }
            });
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Takes a given string source and parses it into a subtree
    /// using the current element as context.
    /// Follows the fragment parsing strategy for the given namespace.
    /// </summary>
    /// <param name="source">The source to parse into a subtree.</param>
    /// <returns>The documentElement of the new subtree.</returns>
    public abstract IElement ParseSubtree(string source);

    /// <inheritdoc />
    public IShadowRoot AttachShadow(ShadowRootMode mode = ShadowRootMode.Open)
    {
        if (TagNames.AllNoShadowRoot.Contains(_localName))
        {
            throw new DomException(DomError.NotSupported);
        }

        if (ShadowRoot != null)
        {
            throw new DomException(DomError.InvalidState);
        }

        _shadowRoot = new ShadowRoot(this, mode);
        return _shadowRoot;
    }

    /// <inheritdoc />
    public IElement QuerySelector(string selectors) => ChildNodes.QuerySelector(selectors, this);

    /// <inheritdoc />
    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => ChildNodes.QuerySelectorAll(selectors, this);

    /// <inheritdoc />
    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => ChildNodes.GetElementsByClassName(classNames);

    /// <inheritdoc />
    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => ChildNodes.GetElementsByTagName(tagName);

    /// <inheritdoc />
    public IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceURI, string tagName) => ChildNodes.GetElementsByTagName(namespaceURI, tagName);

    /// <inheritdoc />
    public bool Matches(string selectorText)
    {
        var parser = Context.GetService<ICssSelectorParser>()!;
        var sg = parser.ParseSelector(selectorText) ?? throw new DomException(DomError.Syntax);
        return sg.Match(this, this);
    }

    /// <inheritdoc />
    public IElement Closest(string selectorText)
    {
        var parser = Context.GetService<ICssSelectorParser>()!;
        var sg = parser.ParseSelector(selectorText) ?? throw new DomException(DomError.Syntax);
        var node = (IElement)this;

        while (node != null)
        {
            if (sg.Match(node, node))
            {
                return node;
            }
            else
            {
                node = node.ParentElement;
            }
        }

        return null;
    }

    /// <inheritdoc />
    public bool HasAttribute(string name)
    {
        if (_namespace.Is(NamespaceNames.HtmlUri))
        {
            name = name.HtmlLower();
        }

        return _attributes.GetNamedItem(name) != null;
    }

    /// <inheritdoc />
    public bool HasAttribute(StringOrMemory name)
    {
        if (_namespace.Is(NamespaceNames.HtmlUri))
        {
            name = name.HtmlLower();
        }

        return _attributes.GetNamedItem(name) != null;
    }

    /// <inheritdoc />
    public bool HasAttribute(string namespaceUri, string localName)
    {
        if (string.IsNullOrEmpty(namespaceUri))
        {
            namespaceUri = null;
        }

        return _attributes.GetNamedItem(namespaceUri, localName) != null;
    }

    /// <inheritdoc />
    public string GetAttribute(string name)
    {
        if (_namespace.Is(NamespaceNames.HtmlUri))
        {
            name = name.HtmlLower();
        }

        return _attributes.GetNamedItem(name)?.Value;
    }

    /// <inheritdoc />
    public string GetAttribute(string namespaceUri, string localName)
    {
        if (string.IsNullOrEmpty(namespaceUri))
        {
            namespaceUri = null;
        }

        return _attributes.GetNamedItem(namespaceUri, localName)?.Value;
    }

    /// <inheritdoc />
    public void SetAttribute(string name, string value)
    {
        if (value != null)
        {
            if (!name.IsXmlName())
            {
                throw new DomException(DomError.InvalidCharacter);
            }

            if (_namespace.Is(NamespaceNames.HtmlUri))
            {
                name = name.HtmlLower();
            }

            this.SetOwnAttribute(name, value);
        }
        else
        {
            RemoveAttribute(name);
        }
    }

    /// <inheritdoc />
    public void SetAttribute(string namespaceUri, string name, string value)
    {
        if (value != null)
        {
            GetPrefixAndLocalName(name, ref namespaceUri, out var prefix, out var localName);
            _attributes.SetNamedItem(new Attr(prefix, localName, value, namespaceUri));
        }
        else
        {
            RemoveAttribute(namespaceUri, name);
        }
    }

    /// <summary>
    /// Adds an attribute.
    /// </summary>
    /// <param name="attr">The attribute to add.</param>
    public void AddAttribute(Attr attr)
    {
        attr.Container = _attributes;
        _attributes.FastAddItem(attr);
    }

    /// <inheritdoc />
    public bool RemoveAttribute(string name)
    {
        if (_namespace.Is(NamespaceNames.HtmlUri))
        {
            name = name.HtmlLower();
        }

        return _attributes.RemoveNamedItemOrDefault(name) != null;
    }

    /// <inheritdoc />
    public bool RemoveAttribute(string namespaceUri, string localName)
    {
        if (string.IsNullOrEmpty(namespaceUri))
        {
            namespaceUri = null;
        }

        return _attributes.RemoveNamedItemOrDefault(namespaceUri, localName) != null;
    }

    /// <inheritdoc />
    public void Prepend(params INode[] nodes)
    {
        this.PrependNodes(nodes);
    }

    /// <inheritdoc />
    public void Append(params INode[] nodes)
    {
        this.AppendNodes(nodes);
    }

    /// <inheritdoc />
    public override bool Equals(INode otherNode)
    {
        if (otherNode is IElement otherElement)
        {
            return NamespaceUri.Is(otherElement.NamespaceUri) &&
                _attributes.SameAs(otherElement.Attributes) &&
                base.Equals(otherNode);
        }

        return false;
    }

    /// <inheritdoc />
    public void Before(params INode[] nodes) => this.InsertBefore(nodes);

    /// <inheritdoc />
    public void After(params INode[] nodes) => this.InsertAfter(nodes);

    /// <inheritdoc />
    public void Replace(params INode[] nodes) => this.ReplaceWith(nodes);

    /// <inheritdoc />
    public void Remove() => this.RemoveFromParent();

    /// <inheritdoc />
    public void Insert(AdjacentPosition position, string html)
    {
        var useThis = position == AdjacentPosition.AfterBegin || position == AdjacentPosition.BeforeEnd;
        var context = useThis ? this : Parent as Element ?? throw new DomException("The element has no parent.");
        var nodes = new DocumentFragment(context, html);

        switch (position)
        {
            case AdjacentPosition.BeforeBegin:
                Parent!.InsertBefore(nodes, this);
                break;

            case AdjacentPosition.AfterEnd:
                Parent!.InsertChild(Parent.IndexOf(this) + 1, nodes);
                break;

            case AdjacentPosition.AfterBegin:
                InsertChild(0, nodes);
                break;

            case AdjacentPosition.BeforeEnd:
                AppendChild(nodes);
                break;
        }
    }

    /// <inheritdoc />
    public override Node Clone(Document owner, bool deep)
    {
        var node = new AnyElement(owner, LocalName, _prefix, _namespace, Flags);
        CloneElement(node, owner, deep);
        return node;
    }

    #endregion

    #region Internal Methods

    internal virtual void SetupElement()
    {
        var attrs = _attributes;

        if (attrs.Length > 0)
        {
            var observers = Context.GetServices<IAttributeObserver>();

            foreach (var attr in attrs)
            {
                var name = attr.LocalName;
                var value = attr.Value;

                foreach (var observer in observers)
                {
                    observer.NotifyChange(this, name, value);
                }
            }
        }
    }

    internal void AttributeChanged(string localName, string namespaceUri, string oldValue, string newValue)
    {
        if (namespaceUri is null)
        {
            var observers = Context.GetServices<IAttributeObserver>();

            foreach (var observer in observers)
            {
                observer.NotifyChange(this, localName, newValue);
            }
        }

        Owner.QueueMutation(MutationRecord.Attributes(
            target: this,
            attributeName: localName,
            attributeNamespace: namespaceUri,
            previousValue: oldValue));
    }

    internal void UpdateClassList(string value) => _classList?.Update(value);

    #endregion

    #region Helpers

    /// <inheritdoc />
    protected void UpdateAttribute(string name, string value) => this.SetOwnAttribute(name, value, suppressCallbacks: true);

    /// <inheritdoc />
    protected sealed override string LocateNamespace(string prefix) => this.LocateNamespaceFor(prefix);

    /// <inheritdoc />
    protected sealed override string LocatePrefix(string namespaceUri) => this.LocatePrefixFor(namespaceUri);

    /// <inheritdoc />
    protected void CloneElement(Element element, Document owner, bool deep)
    {
        CloneNode(element, owner, deep);

        foreach (var attribute in _attributes)
        {
            var attr = new Attr(attribute.Prefix, attribute.LocalName, attribute.Value, attribute.NamespaceUri);
            attr.Container = element._attributes;
            element._attributes.FastAddItem(attr);
        }

        element.SetupElement();
    }

    #endregion

    #region Construction

    StringOrMemory IConstructableElement.LocalName => _localName;

    IConstructableNamedNodeMap IConstructableElement.Attributes => _attributes;

    StringOrMemory IConstructableElement.NamespaceUri => NamespaceUri ?? "";

    void IConstructableElement.SetAttribute(string ns, StringOrMemory name, StringOrMemory value)
    {
        SetAttribute(ns, name.ToString(), value.ToString());
    }

    void IConstructableElement.SetOwnAttribute(StringOrMemory name, StringOrMemory value)
    {
        this.SetOwnAttribute(name.ToString(), value.ToString());
    }

    StringOrMemory IConstructableElement.GetAttribute(StringOrMemory @namespace, StringOrMemory name)
    {
        var result = GetAttribute(@namespace.ToString(), name.ToString());
        return result ?? StringOrMemory.Empty;
    }

    void IConstructableElement.SetAttributes(StructAttributes tagAttributes)
    {
        var container = Attributes;

        for (var i = 0; i < tagAttributes.Count; i++)
        {
            var attribute = tagAttributes[i];
            var item = new Attr(attribute.Name.ToString(), attribute.Value.ToString());
            item.Container = container;
            container.FastAddItem(item);
        }
    }

    void IConstructableElement.SetupElement() => SetupElement();

    void IConstructableElement.AddComment(ref StructHtmlToken token) => this.AddComment(ref token);

    IConstructableNode IConstructableElement.ShallowCopy() => Clone(Owner, false);

    StringOrMemory IConstructableElement.Prefix => Prefix ?? StringOrMemory.Empty;

    #endregion
}
