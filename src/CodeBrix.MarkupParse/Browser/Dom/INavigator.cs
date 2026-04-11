using CodeBrix.MarkupParse.Attributes;

namespace CodeBrix.MarkupParse.Browser.Dom; //Was previously: namespace AngleSharp.Browser.Dom

/// <summary>
/// Represents the navigator information of a browsing context.
/// </summary>
[DomName("Navigator")]
public interface INavigator : INavigatorId, INavigatorContentUtilities, INavigatorStorageUtilities, INavigatorOnline
{
}
