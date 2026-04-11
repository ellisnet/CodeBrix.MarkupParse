using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBrix.MarkupParse.Text; //Was previously: namespace AngleSharp.Text

/// <summary>
/// Represents a Punycode encoding helper class.
/// </summary>
public static class Punycode
{
    #region Constants

    private const int PunycodeBase = 36;
    private const int Tmin = 1;
    private const int Tmax = 26;

    private static readonly string acePrefix = "xn--";
    private static readonly char[] possibleDots = { '.', '\u3002', '\uFF0E', '\uFF61' };

    /// <summary>
    /// A list of available punycode character mappings.
    /// </summary>
    public static IDictionary<char, char> Symbols = new Dictionary<char, char>
    {
        { '。', '.' },
        { '．', '.' },
        { 'Ｇ', 'g' },
        { 'ｏ', 'o' },
        { 'ｃ', 'c' },
        { 'Ｘ', 'x' },
        { '０', '0' },
        { '１', '1' },
        { '２', '2' },
        { '５', '5' },
        { '⁰', '0' },
        { '¹', '1' },
        { '²', '2' },
        { '³', '3' },
        { '⁴', '4' },
        { '⁵', '5' },
        { '⁶', '6' },
        { '⁷', '7' },
        { '⁸', '8' },
        { '⁹', '9' },
        { '₀', '0' },
        { '₁', '1' },
        { '₂', '2' },
        { '₃', '3' },
        { '₄', '4' },
        { '₅', '5' },
        { '₆', '6' },
        { '₇', '7' },
        { '₈', '8' },
        { '₉', '9' },
        { 'ᵃ', 'a' },
        { 'ᵇ', 'b' },
        { 'ᶜ', 'c' },
        { 'ᵈ', 'd' },
        { 'ᵉ', 'e' },
        { 'ᶠ', 'f' },
        { 'ᵍ', 'g' },
        { 'ʰ', 'h' },
        { 'ⁱ', 'i' },
        { 'ʲ', 'j' },
        { 'ᵏ', 'k' },
        { 'ˡ', 'l' },
        { 'ᵐ', 'm' },
        { 'ⁿ', 'n' },
        { 'ᵒ', 'o' },
        { 'ᵖ', 'p' },
        { 'ʳ', 'r' },
        { 'ˢ', 's' },
        { 'ᵗ', 't' },
        { 'ᵘ', 'u' },
        { 'ᵛ', 'v' },
        { 'ʷ', 'w' },
        { 'ˣ', 'x' },
        { 'ʸ', 'y' },
        { 'ᶻ', 'z' },
        { 'ᴬ', 'A' },
        { 'ᴮ', 'B' },
        { 'ᴰ', 'D' },
        { 'ᴱ', 'E' },
        { 'ᴳ', 'G' },
        { 'ᴴ', 'H' },
        { 'ᴵ', 'I' },
        { 'ᴶ', 'J' },
        { 'ᴷ', 'K' },
        { 'ᴸ', 'L' },
        { 'ᴹ', 'M' },
        { 'ᴺ', 'N' },
        { 'ᴼ', 'O' },
        { 'ᴾ', 'P' },
        { 'ᴿ', 'R' },
        { 'ᵀ', 'T' },
        { 'ᵁ', 'U' },
        { 'ⱽ', 'V' },
        { 'ᵂ', 'W' },
    };

    #endregion

    #region Methods

    /// <summary>
    /// Encodes the given text using Punycode.
    /// </summary>
    public static string Encode(string text)
    {
        const int InitialBias = 72;
        const int InitialNumber = 0x80;
        const int MaxIntValue = 0x7ffffff;
        const int LabelLimit = 63;
        const int DefaultNameLimit = 255;

        // 0 length strings aren't allowed
        if (text.Length == 0)
        {
            return text;
        }

        var output = new StringBuilder(text.Length);
        var iNextDot = 0;
        var iAfterLastDot = 0;
        var iOutputAfterLastDot = 0;

        // Find the next dot
        while (iNextDot < text.Length)
        {
            // Find end of this segment
            iNextDot = text.IndexOfAny(possibleDots, iAfterLastDot);

            if (iNextDot < 0)
            {
                iNextDot = text.Length;
            }

            // Only allowed to have empty . section at end (www.microsoft.com.)
            if (iNextDot == iAfterLastDot)
            {
                break;
            }

            // We'll need an Ace prefix
            output.Append(acePrefix);

            var basicCount = 0;
            var numProcessed = 0;

            for (basicCount = iAfterLastDot; basicCount < iNextDot; basicCount++)
            {
                if (text[basicCount] < 0x80)
                {
                    output.Append(EncodeBasic(text[basicCount]));
                    numProcessed++;
                }
                else if (char.IsSurrogatePair(text, basicCount))
                {
                    basicCount++;
                }
            }

            var numBasicCodePoints = numProcessed;

            if (numBasicCodePoints == iNextDot - iAfterLastDot)
            {
                output.Remove(iOutputAfterLastDot, acePrefix.Length);
            }
            else
            {
                // If it has some non-basic code points the input cannot start with xn--
                if (text.Length - iAfterLastDot >= acePrefix.Length && text.Substring(iAfterLastDot, acePrefix.Length).Isi(acePrefix))
                {
                    break;
                }

                // Need to do ACE encoding
                var numSurrogatePairs = 0;

                // Add a delimiter (-) if we had any basic code points (between basic and encoded pieces)
                if (numBasicCodePoints > 0)
                {
                    output.Append(Text.Symbols.Minus);
                }

                // Initialize the state
                var n = InitialNumber;
                var delta = 0;
                var bias = InitialBias;

                // Main loop
                while (numProcessed < (iNextDot - iAfterLastDot))
                {
                    var j = 0;
                    var m = 0;
                    var test = 0;

                    for (m = MaxIntValue, j = iAfterLastDot; j < iNextDot; j += IsSupplementary(test) ? 2 : 1)
                    {
                        test = char.ConvertToUtf32(text, j);

                        if (test >= n && test < m)
                        {
                            m = test;
                        }
                    }

                    // Increase delta enough to advance the decoder's
                    // <n,i> state to <m,0>, but guard against overflow:
                    delta += (m - n) * ((numProcessed - numSurrogatePairs) + 1);
                    n = m;

                    for (j = iAfterLastDot; j < iNextDot; j += IsSupplementary(test) ? 2 : 1)
                    {
                        // Make sure we're aware of surrogates
                        test = char.ConvertToUtf32(text, j);

                        // Adjust for character position (only the chars in our string already, some
                        // haven't been processed.

                        if (test < n)
                        {
                            delta++;
                        }
                        else if (test == n)
                        {
                            // Represent delta as a generalized variable-length integer:
                            int q, k;

                            for (q = delta, k = PunycodeBase; ; k += PunycodeBase)
                            {
                                var t = k <= bias ? Tmin : k >= bias + Tmax ? Tmax : k - bias;

                                if (q < t)
                                {
                                    break;
                                }

                                output.Append(EncodeDigit(t + (q - t) % (PunycodeBase - t)));
                                q = (q - t) / (PunycodeBase - t);
                            }

                            output.Append(EncodeDigit(q));
                            bias = AdaptChar(delta, (numProcessed - numSurrogatePairs) + 1, numProcessed == numBasicCodePoints);
                            delta = 0;
                            numProcessed++;

                            if (IsSupplementary(m))
                            {
                                numProcessed++;
                                numSurrogatePairs++;
                            }
                        }
                    }

                    ++delta;
                    ++n;
                }
            }

            // Make sure its not too big
            if (output.Length - iOutputAfterLastDot > LabelLimit)
            {
                throw new ArgumentException();
            }

            // Done with this segment, add dot if necessary
            if (iNextDot != text.Length)
            {
                output.Append(possibleDots[0]);
            }

            iAfterLastDot = iNextDot + 1;
            iOutputAfterLastDot = output.Length;
        }

        var rest = IsDot(text[text.Length - 1]) ? 0 : 1;
        var maxlength = DefaultNameLimit - rest;

        // Throw if we're too long
        if (output.Length > maxlength)
        {
            output.Remove(maxlength, output.Length - maxlength);
        }

        return output.ToString();
    }

    #endregion

    #region Helpers

    private static bool IsSupplementary(int test)
    {
        return test >= 0x10000;
    }

    private static bool IsDot(char c)
    {
        for (var i = 0; i < possibleDots.Length; i++)
        {
            if (possibleDots[i] == c)
            {
                return true;
            }
        }

        return false;
    }

    private static char EncodeDigit(int digit)
    {
        const char NumberOffset = (char)('0' - 26);
        const char LetterOffset = 'a';

        if (digit > 25)
        {
            // 26-35 map to ASCII 0-9
            return (char)(digit + NumberOffset);
        }

        // 0-25 map to a-z or A-Z
        return (char)(digit + LetterOffset);
    }

    private static char EncodeBasic(char character)
    {
        const char CaseDifference = (char)('a' - 'A');

        if (char.IsUpper(character))
        {
            character += CaseDifference;
        }

        return character;
    }

    private static int AdaptChar(int delta, int numPoints, bool firstTime)
    {
        const int Skew = 38;
        const int Damp = 700;

        var k = 0u;

        delta = firstTime ? delta / Damp : delta / 2;
        delta += delta / numPoints;

        for (k = 0; delta > ((PunycodeBase - Tmin) * Tmax) / 2; k += PunycodeBase)
        {
            delta /= PunycodeBase - Tmin;
        }

        return (int)(k + PunycodeBase * delta / (delta + Skew));
    }

    #endregion
}
