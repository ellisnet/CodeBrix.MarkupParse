using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the select HTML element.
/// </summary>
[DomName("HTMLSelectElement")]
public interface IHtmlSelectElement : IHtmlElement, IValidation
{
    /// <summary>
    /// Gets or sets the autofocus HTML attribute, which indicates whether the
    /// control should have input focus when the page loads.
    /// </summary>
    [DomName("autofocus")]
    bool Autofocus { get; set; }

    /// <summary>
    /// Gets or sets if the button is enabled or disabled.
    /// </summary>
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    /// <summary>
    /// Gets the associated HTML form element.
    /// </summary>
    [DomName("form")]
    IHtmlFormElement Form { get; }

    /// <summary>
    /// Gets the list of assigned labels.
    /// </summary>
    [DomName("labels")]
    INodeList Labels { get; }

    /// <summary>
    /// Gets or sets the name of the element.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    [DomName("value")]
    string Value { get; set; }

    /// <summary>
    /// Gets the type of input element (select).
    /// </summary>
    [DomName("type")]
    string Type { get; }

    /// <summary>
    /// Gets or sets if the field is required.
    /// </summary>
    [DomName("required")]
    bool IsRequired { get; set; }

    /// <summary>
    /// Gets the set of options that are selected.
    /// </summary>
    [DomName("selectedOptions")]
    IHtmlCollection<IHtmlOptionElement> SelectedOptions { get; }

    /// <summary>
    /// Gets or sets the display size of the element.
    /// </summary>
    [DomName("size")]
    int Size { get; set; }
    
    /// <summary>
    /// Gets the set of option elements contained by this element. 
    /// </summary>
    [DomName("options")]
    IHtmlOptionsCollection Options { get; }
    
    /// <summary>
    /// Gets the number of option elements in this select element.
    /// </summary>
    [DomName("length")]
    int Length { get; }
    
    /// <summary>
    /// Gets or sets the multiple HTML attribute, whichindicates whether multiple items can be selected.
    /// </summary>
    [DomName("multiple")]
    bool IsMultiple { get; set; }

    /// <summary>
    /// Gets the index of the first selected option element.
    /// </summary>
    [DomName("selectedIndex")]
    int SelectedIndex { get; }

    /// <summary>
    /// Gets or sets an HTML option element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <returns>The option at the given position.</returns>
    [DomAccessor(Accessors.Getter | Accessors.Setter)]
    IHtmlOptionElement this[int index] { get; set; }

    /// <summary>
    /// Adds an option element to the options collection.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <param name="before">The optional reference element for inserting.</param>
    [DomName("add")]
    void AddOption(IHtmlOptionElement element, IHtmlElement before = null);

    /// <summary>
    /// Adds an options group element to the options collection.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <param name="before">The optional reference element for inserting.</param>
    [DomName("add")]
    void AddOption(IHtmlOptionsGroupElement element, IHtmlElement before = null);

    /// <summary>
    /// Removes an element from the options collection.
    /// </summary>
    /// <param name="index">The index of the element of remove.</param>
    [DomName("remove")]
    void RemoveOptionAt(int index);
}
