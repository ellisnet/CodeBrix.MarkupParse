using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Html.InputTypes;
using System;

namespace CodeBrix.MarkupParse.Html; //Was previously: namespace AngleSharp.Html

/// <summary>
/// Represents the interface for producing input validation.
/// </summary>
public interface IInputTypeFactory
{
    /// <summary>
    /// Creates an input type for the input element.
    /// </summary>
    /// <param name="input">The input element.</param>
    /// <param name="type">The name of the type.</param>
    /// <returns>The new instance of the type or text.</returns>
    BaseInputType Create(IHtmlInputElement input, string type);
}
