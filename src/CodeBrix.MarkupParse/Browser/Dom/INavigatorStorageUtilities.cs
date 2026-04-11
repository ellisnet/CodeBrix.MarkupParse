using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Browser.Dom; //Was previously: namespace AngleSharp.Browser.Dom

/// <summary>
/// Defines a set of methods for working with IO.
/// </summary>
[DomName("NavigatorStorageUtils")]
[DomNoInterfaceObject]
public interface INavigatorStorageUtilities
{
    /// <summary>
    /// Blocks the current operation until storage operations have completed.
    /// </summary>
    [DomName("yieldForStorageUpdates")]
    void WaitForStorageUpdates();
}
