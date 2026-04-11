using System;

namespace CodeBrix.MarkupParse.Html; //Was previously: namespace AngleSharp.Html

/// <summary>
/// Class to store the state of a form control.
/// </summary>
sealed class FormControlState
{
    #region Fields

    private readonly string _name;
    private readonly string _type;
    private readonly string _value;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new form control state instance.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <param name="type">The type of the field.</param>
    /// <param name="value">The value of the field.</param>
    public FormControlState(string name, string type, string value)
	    {
        _name = name;
        _type = type;
        _value = value;
	    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the name of the field.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the field's value.
    /// </summary>
    public string Value => _value;

    /// <summary>
    /// Gets the type of the field.
    /// </summary>
    public string Type => _type;

    #endregion
}
