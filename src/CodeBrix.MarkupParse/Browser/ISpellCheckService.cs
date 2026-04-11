using System;
using System.Collections.Generic;
using System.Globalization;

namespace CodeBrix.MarkupParse.Browser; //Was previously: namespace AngleSharp.Browser

/// <summary>
/// Provides a spell correction service.
/// </summary>
public interface ISpellCheckService
{
    /// <summary>
    /// Gets the culture for the spell check service.
    /// </summary>
    CultureInfo Culture { get; }

    /// <summary>
    /// Ignores the word.
    /// </summary>
    /// <param name="word">The word to ignore.</param>
    /// <param name="persistent">If true, should be added to dictionary. Otherwise false.</param>
    void Ignore(string word, bool persistent);

    /// <summary>
    /// Checks if the given word is correct.
    /// </summary>
    /// <param name="word">The word to check.</param>
    /// <returns>True if the word is correctly spelled, otherwise false.</returns>
    bool IsCorrect(string word);

    /// <summary>
    /// Suggests correct spellings for the given word.
    /// </summary>
    /// <param name="word">The base word.</param>
    /// <returns>An enumeration over possibly right variants.</returns>
    IEnumerable<string> SuggestFor(string word);
}
