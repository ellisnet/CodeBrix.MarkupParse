using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Construction;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Processors;
using CodeBrix.MarkupParse.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents an HTML script element.
/// http://www.w3.org/TR/html5/scripting-1.html#execute-the-script-block
/// </summary>
sealed class HtmlScriptElement : HtmlElement, IHtmlScriptElement, IConstructableScriptElement
{
    #region Fields

    private readonly bool _parserInserted;
    private readonly ScriptRequestProcessor _request;

    private bool _started;
    private bool _forceAsync;

    #endregion

    #region ctor

    public HtmlScriptElement(Document owner, string prefix = null, bool parserInserted = false, bool started = false)
        : base(owner, TagNames.Script, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
        _forceAsync = false;
        _started = started;
        _parserInserted = parserInserted;
        _request = new ScriptRequestProcessor(owner.Context, this);
    }

    #endregion

    #region Properties

    public IDownload CurrentDownload => _request?.Download;

    public string Source
    {
        get => this.GetOwnAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string CharacterSet
    {
        get => this.GetOwnAttribute(AttributeNames.Charset);
        set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string Text
    {
        get => TextContent;
        set => TextContent = value;
    }

    public string CrossOrigin
    {
        get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
        set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    public bool IsDeferred
    {
        get => this.GetBoolAttribute(AttributeNames.Defer);
        set => this.SetBoolAttribute(AttributeNames.Defer, value);
    }

    public bool IsAsync
    {
        get => this.GetBoolAttribute(AttributeNames.Async);
        set => this.SetBoolAttribute(AttributeNames.Async, value);
    }

    public string Integrity
    {
        get => this.GetOwnAttribute(AttributeNames.Integrity);
        set => this.SetOwnAttribute(AttributeNames.Integrity, value);
    }

    #endregion

    #region Methods

    public override Node Clone(Document owner, bool deep)
    {
        var node = new HtmlScriptElement(owner, Prefix, _parserInserted, _started);
        CloneElement(node, owner, deep);
        node._forceAsync = _forceAsync;
        return node;
    }

    #endregion

    #region Internal Methods

    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        if (!_parserInserted && Prepare(Owner))
        {
            RunAsync(CancellationToken.None);
        }
    }

    internal Task RunAsync(CancellationToken cancel)
    {
        return _request?.RunAsync(cancel)!;
    }

    /// <summary>
    /// More information available at:
    /// http://www.w3.org/TR/html5/scripting-1.html#prepare-a-script
    /// </summary>
    internal bool Prepare(Document document)
    {
        var eventAttr = this.GetOwnAttribute(AttributeNames.Event);
        var forAttr = this.GetOwnAttribute(AttributeNames.For);
        var src = Source;
        var wasParserInserted = _parserInserted;

        if (_started)
        {
            return false;
        }
        else if (wasParserInserted)
        {
            _forceAsync = !IsAsync;
        }

        if (string.IsNullOrEmpty(src) && string.IsNullOrEmpty(Text))
        {
            return false;
        }
        else if (_request.Engine is null)
        {
            return false;
        }
        else if (wasParserInserted)
        {
            _forceAsync = false;
        }

        _started = true;

        if (eventAttr is { Length: > 0 } && forAttr is { Length: >0 })
        {
            eventAttr = eventAttr.Trim();
            forAttr = forAttr.Trim();

            if (eventAttr.EndsWith("()"))
            {
                eventAttr = eventAttr.Substring(0, eventAttr.Length - 2);
            }

            var isWindow = forAttr.Isi(AttributeNames.Window);
            var isLoadEvent = eventAttr.Isi("onload");

            if (!isWindow || !isLoadEvent)
            {
                return false;
            }
        }

        if (src != null)
        {
            if (src.Length != 0)
            {
                return InvokeLoadingScript(document, this.HyperReference(src)!);
            }

            document.QueueTask(FireErrorEvent);
        }
        else
        {
            _request.Process(Text);
            return true;
        }

        return false;
    }

    #endregion

    #region Helpers

    private bool InvokeLoadingScript(Document document, Url url)
    {
        var executeDirectly = true;

        //Just add to the (end of) set of scripts
        if (_parserInserted && (IsDeferred || IsAsync))
        {
            document.AddScript(this);
            executeDirectly = false;
        }

        this.Process(_request, url);
        return executeDirectly;
    }

    private void FireErrorEvent() => Owner.QueueTask(() => this.FireSimpleEvent(EventNames.Error));

    #endregion

    #region Construction

    Task IConstructableScriptElement.RunAsync(CancellationToken cancel)
    {
        return RunAsync(cancel);
    }

    bool IConstructableScriptElement.Prepare(IConstructableDocument document)
    {
        return Prepare((Document)document);
    }

    #endregion
}
