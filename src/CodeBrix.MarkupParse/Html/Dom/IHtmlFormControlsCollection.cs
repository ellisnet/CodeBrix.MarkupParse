using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a collection of HTML form controls.
/// </summary>
[DomName("HTMLFormControlsCollection")]
public interface IHtmlFormControlsCollection : IHtmlCollection<IHtmlElement>
{
}
