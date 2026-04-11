using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Represents a command that can be executed from the document.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// The id of the command.
    /// </summary>
    string CommandId { get; }
    
    /// <summary>
    /// Executes the command for the given document.
    /// </summary>
    /// <param name="document">The document to alter.</param>
    /// <param name="showUserInterface">Should the UI be shown?</param>
    /// <param name="value">The argument value.</param>
    /// <returns>A boolean if the command could be run.</returns>
    bool Execute(IDocument document, bool showUserInterface, string value);

    /// <summary>
    /// Checks if the command is currently enabled.
    /// </summary>
    /// <param name="document">The document to apply to.</param>
    /// <returns>A boolean if the command is enabled.</returns>
    bool IsEnabled(IDocument document);

    /// <summary>
    /// Checks if the command is currently neither enabled nor disabled.
    /// </summary>
    /// <param name="document">The document to apply to.</param>
    /// <returns>A boolean if the command is indeterminate.</returns>
    bool IsIndeterminate(IDocument document);

    /// <summary>
    /// Checks if the command has been run already.
    /// </summary>
    /// <param name="document">The document to apply to.</param>
    /// <returns>A boolean if the command has already been applied.</returns>
    bool IsExecuted(IDocument document);

    /// <summary>
    /// Checks if the command is currently supported at all.
    /// </summary>
    /// <param name="document">The document to apply to.</param>
    /// <returns>A boolean if the command is supported.</returns>
    bool IsSupported(IDocument document);

    /// <summary>
    /// Gets the value that would be changed at the moment.
    /// </summary>
    /// <param name="document">The document to apply to.</param>
    /// <returns>The value that would be used by the command.</returns>
    string GetValue(IDocument document);
}
