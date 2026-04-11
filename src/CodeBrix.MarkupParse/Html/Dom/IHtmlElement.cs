using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The HTMLElement interface represents any HTML element. Some elements directly
/// implement this interface, other implement it via an interface that inherit it.
/// </summary>
[DomName("HTMLElement")]
public interface IHtmlElement : IElement, IGlobalEventHandlers
{
    /// <summary>
    /// Gets or sets the value of the lang attribute.
    /// </summary>
    [DomName("lang")]
    string Language { get; set; }

    /// <summary>
    /// Gets or sets the value of the title attribute.
    /// </summary>
    [DomName("title")]
    string Title { get; set; }

    /// <summary>
    /// Gets or sets the value of the dir attribute.
    /// </summary>
    [DomName("dir")]
    string Direction { get; set; }

    /// <summary>
    /// Gets access to all the custom data attributes (data-*) set on the element. It is a map of DOMString,
    /// one entry for each custom data attribute.
    /// </summary>
    [DomName("dataset")]
    IStringMap Dataset { get; }

    /// <summary>
    /// Gets or sets if the element should be translated.
    /// </summary>
    [DomName("translate")]
    bool IsTranslated { get; set; }

    /// <summary>
    /// Gets or sets the position of the element in the tabbing order.
    /// </summary>
    [DomName("tabIndex")]
    int TabIndex { get; set; }

    /// <summary>
    /// Gets or sets if spell-checking is activated.
    /// </summary>
    [DomName("spellcheck")]
    bool IsSpellChecked { get; set; }

    /// <summary>
    /// Gets or sets whether or not the element is editable. This enumerated
    /// attribute can have the values true, false and inherited.
    /// </summary>
    [DomName("contentEditable")]
    string ContentEditable { get; set; }

    /// <summary>
    /// Gets if the element is currently contenteditable.
    /// </summary>
    [DomName("isContentEditable")]
    bool IsContentEditable { get; }

    /// <summary>
    /// Gets or sets if the element is hidden.
    /// </summary>
    [DomName("hidden")]
    bool IsHidden { get; set; }

    /// <summary>
    /// Gets or sets if the element is draggable.
    /// </summary>
    [DomName("draggable")]
    bool IsDraggable { get; set; }

    /// <summary>
    /// Gets or sets the access key assigned to the element.
    /// </summary>
    [DomName("accessKey")]
    string AccessKey { get; set; }

    /// <summary>
    /// Gets the element's assigned access key.
    /// </summary>
    [DomName("accessKeyLabel")]
    string AccessKeyLabel { get; }

    /// <summary>
    /// Gets or sets the assigned context menu.
    /// </summary>
    [DomName("contextMenu")]
    IHtmlMenuElement ContextMenu { get; set; }

    /// <summary>
    /// Gets the dropzone for this element.
    /// </summary>
    [DomName("dropzone")]
    [DomPutForwards("value")]
    ISettableTokenList DropZone { get; }

    /// <summary>
    /// Simulates a mouse click on an element.
    /// </summary>
    [DomName("click")]
    void DoClick();

    /// <summary>
    /// Puts the keyboard focus on the given element.
    /// </summary>
    [DomName("focus")]
    void DoFocus();

    /// <summary>
    /// Removes the keyboard focus on the given element.
    /// </summary>
    [DomName("blur")]
    void DoBlur();

    /// <summary>
    /// Forces the invocation of a spell check on the content.
    /// </summary>
    [DomName("forceSpellCheck")]
    void DoSpellCheck();

}
