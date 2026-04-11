using CodeBrix.MarkupParse.Attributes;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// The ValidityState interface represents the validity states that an element
/// can be in, with respect to constraint validation. Together, they help explain
/// why an element's value fails to validate, if it's not valid.
/// </summary>
[DomName("ValidityState")]
public interface IValidityState
{
    /// <summary>
    /// Gets if the element has a required attribute, but no value.
    /// </summary>
    [DomName("valueMissing")]
    bool IsValueMissing { get; }

    /// <summary>
    /// Gets if the value is not in the required syntax (when type is email or url).
    /// </summary>
    [DomName("typeMismatch")]
    bool IsTypeMismatch { get; }

    /// <summary>
    /// Gets if the value does not match the specified pattern.
    /// </summary>
    [DomName("patternMismatch")]
    bool IsPatternMismatch { get; }

    /// <summary>
    /// Gets if the value exceeds the specified maxlength.
    /// </summary>
    [DomName("tooLong")]
    bool IsTooLong { get; }

    /// <summary>
    /// Gets if the value is below the specified minlength.
    /// </summary>
    [DomName("tooShort")]
    bool IsTooShort { get; }

    /// <summary>
    /// Gets if the value is regarded is invalid input.
    /// </summary>
    [DomName("badInput")]
    bool IsBadInput { get; }

    /// <summary>
    /// Gets if the value is less than the minimum specified by the min attribute.
    /// </summary>
    [DomName("rangeUnderflow")]
    bool IsRangeUnderflow { get; }

    /// <summary>
    /// Gets if the value is greater than the maximum specified by the max attribute.
    /// </summary>
    [DomName("rangeOverflow")]
    bool IsRangeOverflow { get; }

    /// <summary>
    /// Gets if the value does not fit the rules determined by the step attribute
    /// (that is, it's not evenly divisible by the step value).
    /// </summary>
    [DomName("stepMismatch")]
    bool IsStepMismatch { get; }

    /// <summary>
    /// Gets the element's custom validity message.
    /// </summary>
    [DomName("customError")]
    bool IsCustomError { get; }

    /// <summary>
    /// Gets if the element meets all constraint validations, and is therefore
    /// considered to be valid.
    /// </summary>
    [DomName("valid")]
    bool IsValid { get; }
}
