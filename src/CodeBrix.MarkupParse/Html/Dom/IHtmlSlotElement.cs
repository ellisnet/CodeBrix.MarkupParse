using CodeBrix.MarkupParse.Attributes;
using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents a slot in the shadow tree.
/// </summary>
[DomName("HTMLSlotElement")]
public interface IHtmlSlotElement : IHtmlElement
{
    /// <summary>
    /// Gets or sets the name attribute.
    /// </summary>
    [DomName("name")]
    string Name { get; set; }

    /// <summary>
    /// Gets the nodes from the distributed nodes of the context.
    /// </summary>
    /// <returns>The sequence of distributed nodes.</returns>
    [DomName("getDistributedNodes")]
    IEnumerable<INode> GetDistributedNodes();
}
