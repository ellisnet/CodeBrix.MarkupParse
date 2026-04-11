using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Implemented by elements that can be validated.
/// </summary>
[DomNoInterfaceObject]
public interface IValidation
{
    /// <summary>
    /// Gets a value if the current element validates.
    /// </summary>
    [DomName("willValidate")]
    bool WillValidate { get; }

    /// <summary>
    /// Gets the current validation state of the current element.
    /// </summary>
    [DomName("validity")]
    IValidityState Validity { get; }

    /// <summary>
    /// Gets the current validation message.
    /// </summary>
    [DomName("validationMessage")]
    string ValidationMessage { get; }

    /// <summary>
    /// Checks the validity of the current element.
    /// </summary>
    /// <returns>True if the object is valid, otherwise false.</returns>
    [DomName("checkValidity")]
    bool CheckValidity();

    /// <summary>
    /// Sets a custom validation error. If this is not the empty string,
    /// then the element is suffering from a custom validation error.
    /// </summary>
    /// <param name="error">The error message to use.</param>
    [DomName("setCustomValidity")]
    void SetCustomValidity(string error);
}
