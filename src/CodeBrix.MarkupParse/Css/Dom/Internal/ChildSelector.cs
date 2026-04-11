using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Css.Dom; //Was previously: namespace AngleSharp.Css.Dom

/// <summary>
/// Base class for all nth-child (or related) selectors.
/// </summary>
abstract class ChildSelector
{
    #region Fields

    private readonly string _name;
    private readonly int _step;
    private readonly int _offset;
    private readonly ISelector _kind;

    #endregion

    #region ctor

    public ChildSelector(string name, int step, int offset, ISelector kind)
    {
        _name = name;
        _step = step;
        _offset = offset;
        _kind = kind;
    }

    #endregion

    #region Properties

    public Priority Specificity
    {
        get
        {
            var specificity = Priority.OneClass;

            if (IncludeParameterInSpecificity)
            {
                specificity += Kind is ListSelector list
                    ? list.Max(x => x.Specificity)
                    : Kind.Specificity;
            }

            return specificity;
        }
    }

    protected virtual bool IncludeParameterInSpecificity => false;

    public string Text
    {
        get
        {
            var a = _step.ToString();
            var b = string.Empty;
            var c = string.Empty;

            if (_offset > 0)
            {
                b = "+";
                c = (+_offset).ToString();
            }
            else if (_offset < 0)
            {
                b = "-";
                c = (-_offset).ToString();
            }

            return $":{_name}({a}n{b}{c})";
        }
    }

    public string Name => _name;

    public int Step => _step;

    public int Offset => _offset;

    public ISelector Kind => _kind;

    #endregion

    #region Methods

    public void Accept(ISelectorVisitor visitor)
    {
        visitor.Child(_name, _step, _offset, _kind);
    }

    #endregion
}
