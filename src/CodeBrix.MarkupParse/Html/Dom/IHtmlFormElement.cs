using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using System;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the form HTML element.
/// </summary>
[DomName("HTMLFormElement")]
public interface IHtmlFormElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the character encodings that are to be used for the submission.
    /// </summary>
    [DomName("acceptCharset")]
    string AcceptCharset { get; set; }

    /// <summary>
    /// Gets or sets the form's name within the forms collection.
    /// </summary>
    [DomName("action")]
    string Action { get; set; }

    /// <summary>
    /// Gets or sets if autocomplete is turned on or off.
    /// </summary>
    [DomName("autocomplete")]
    string Autocomplete { get; set; }

    /// <summary>
    /// Gets or sets the encoding to use for sending the form.
    /// </summary>
    [DomName("enctype")]
    string Enctype { get; set; }

    /// <summary>
    /// Gets or sets the encoding to use for sending the form.
    /// </summary>
    [DomName("encoding")]
    string Encoding { get; set; }

    /// <summary>
    /// Gets or sets the method to use for transmitting the form.
    /// </summary>
    [DomName("method")]
    string Method { get; set; }

    /// <summary>
    /// Gets or sets the value of the name attribute.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the indicator that the form is not to be validated during submission.
    /// </summary>
    [DomName("noValidate")]
    bool NoValidate { get; set; }

    /// <summary>
    /// Gets or sets the target name of the response to the request.
    /// </summary>
    [DomName("target")]
    string Target { get; set; }

    /// <summary>
    /// Gets the number of elements in the Elements collection.
    /// </summary>
    [DomName("length")]
    int Length { get; }

    /// <summary>
    /// Gets all the form controls belonging to this form element.
    /// </summary>
    [DomName("elements")]
    IHtmlFormControlsCollection Elements { get; }

    /// <summary>
    /// Submits the form element from the form element itself.
    /// </summary>
    [DomName("submit")]
    Task<IDocument> SubmitAsync();

    /// <summary>
    /// Submits the form element as triggered from another element.
    /// </summary>
    /// <param name="sourceElement">The form's submitter.</param>
    Task<IDocument> SubmitAsync(IHtmlElement sourceElement);

    /// <summary>
    /// Creates the document request from the form submitting itself.
    /// </summary>
    /// <returns>The resulting document (e.g., HTTP) request.</returns>
    DocumentRequest GetSubmission();

    /// <summary>
    /// Creates the document request from the form by submitting by
    /// some element.
    /// </summary>
    /// <param name="sourceElement">The form's submitter.</param>
    /// <returns>The resulting document (e.g., HTTP) request.</returns>
    DocumentRequest GetSubmission(IHtmlElement sourceElement);

    /// <summary>
    /// Resets the form to the previous (default) state.
    /// </summary>
    [DomName("reset")]
    void Reset();

    /// <summary>
    /// Checks if the form is valid, i.e. if all fields fulfill their requirements.
    /// </summary>
    /// <returns>True if the form is valid, otherwise false.</returns>
    [DomName("checkValidity")]
    bool CheckValidity();

    /// <summary>
    /// Reports the current validity state after checking the current state
    /// interactively the constraints of the form element.
    /// </summary>
    /// <returns>True if the form element is valid, otherwise false.</returns>
    [DomName("reportValidity")]
    bool ReportValidity();

    /// <summary>
    /// Gets the form element at the specified index.
    /// </summary>
    /// <param name="index">The index in the elements collection.</param>
    /// <returns>The element or null.</returns>
    [DomAccessor(Accessors.Getter)]
    IElement this[int index] { get; }

    /// <summary>
    /// Gets the form element(s) with the specified name.
    /// </summary>
    /// <param name="name">The name or id of the element.</param>
    /// <returns>A collection with elements, an element or null.</returns>
    [DomAccessor(Accessors.Getter)]
    IElement this[string name] { get; }

    /// <summary>
    /// Requests the input fields to be automatically filled with previous entries.
    /// </summary>
    [DomName("requestAutocomplete")]
    void RequestAutocomplete();
}
