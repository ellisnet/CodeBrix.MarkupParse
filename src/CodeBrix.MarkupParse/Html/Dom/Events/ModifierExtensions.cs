using System;

namespace CodeBrix.MarkupParse.Html.Dom.Events; //Was previously: namespace AngleSharp.Html.Dom.Events

/// <summary>
/// A couple of useful extensions for the modifier list.
/// </summary>
static class ModifierExtensions
{
    public static bool IsCtrlPressed(this string modifierList)
    {
        return false;
    }

    public static bool IsMetaPressed(this string modifierList)
    {
        return false;
    }

    public static bool IsShiftPressed(this string modifierList)
    {
        return false;
    }

    public static bool IsAltPressed(this string modifierList)
    {
        return false;
    }

    public static bool ContainsKey(this string modifierList, string key)
    {
        return modifierList.Contains(key);
    }
}
