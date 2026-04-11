using CodeBrix.MarkupParse.Css;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Svg.Dom; //Was previously: namespace AngleSharp.Svg.Dom

/// <summary>
/// Represents the SVG style element.
/// </summary>
sealed class SvgStyleElement : SvgElement, ISvgStyleElement
{
    #region Fields

    private IStyleSheet _sheet;

    #endregion

    #region ctor

    public SvgStyleElement(Document owner, string prefix = null)
        : base(owner, TagNames.Style, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }

    #endregion

    #region Properties

    public IStyleSheet Sheet => _sheet;

    public bool IsDisabled
    {
        get => this.GetBoolAttribute(AttributeNames.Disabled);
        set
        {
            this.SetBoolAttribute(AttributeNames.Disabled, value);

            if (_sheet != null)
            {
                _sheet.IsDisabled = value;
            }
        }
    }

    public string Media
    {
        get => this.GetOwnAttribute(AttributeNames.Media);
        set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
        get => this.GetOwnAttribute(AttributeNames.Type);
        set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();
        UpdateSheet();
    }

    internal void UpdateMedia(string value)
    {
        if (_sheet != null)
        {
            _sheet.Media.MediaText = value;
        }
    }

    #endregion

    #region Helpers

    protected override void NodeIsInserted(Node newNode)
    {
        base.NodeIsInserted(newNode);
        UpdateSheet();
    }

    protected override void NodeIsRemoved(Node removedNode, Node oldPreviousSibling)
    {
        base.NodeIsRemoved(removedNode, oldPreviousSibling);
        UpdateSheet();
    }

    private void UpdateSheet()
    {
        var document = Owner;

        if (document != null)
        {
            var context = Context;
            var type = Type ?? MimeTypeNames.Css;
            var engine = context.GetStyling(type);

            if (engine != null)
            {
                var task = CreateSheetAsync(engine, document);
                document.DelayLoad(task);
            }
        }
    }

    private async Task CreateSheetAsync(IStylingService engine, IDocument document)
    {
        var cancel = CancellationToken.None;
        var response = VirtualResponse.Create(res => res.Content(TextContent).Address(default(Url)));
        var options = new StyleOptions(document)
        {
            Element = this,
            IsDisabled = IsDisabled,
            IsAlternate = false,
        };
        var task = engine.ParseStylesheetAsync(response, options, cancel);
        _sheet = await task.ConfigureAwait(false);
        UpdateMedia(Media!);
    }

    #endregion
}
