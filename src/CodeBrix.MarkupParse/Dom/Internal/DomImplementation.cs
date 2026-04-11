using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Provides a number of methods for performing operations that are
/// independent of any particular instance of the DOM.
/// </summary>
sealed class DomImplementation : IImplementation
{
    #region Features

    static readonly Dictionary<string, string[]> features = new(StringComparer.OrdinalIgnoreCase)
    {
        { "XML", new[] { "1.0", "2.0" } },
        { "HTML", new[] { "1.0", "2.0" } },
        { "Core", new[] { "2.0" } },
        { "Views", new[] { "2.0" } },
        { "StyleSheets", new[] { "2.0" } },
        { "CSS", new[] { "2.0" } },
        { "CSS2", new[] { "2.0" } },
        { "Traversal", new[] { "2.0" } },
        { "Events", new[] { "2.0" } },
        { "UIEvents", new[] { "2.0" } },
        { "HTMLEvents", new[] { "2.0" } },
        { "Range", new[] { "2.0" } },
        { "MutationEvents", new[] { "2.0" } },
    };

    #endregion

    #region Fields

    readonly Document _owner;

    #endregion

    #region ctor

    public DomImplementation(Document owner)
    {
        _owner = owner;
    }

    #endregion

    #region Methods

    public IDocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId)
    {
        if (qualifiedName is null)
        {
            throw new ArgumentNullException(nameof(qualifiedName));
        }

        if (!qualifiedName.IsXmlName())
        {
            throw new DomException(DomError.InvalidCharacter);
        }

        if (!qualifiedName.IsQualifiedName())
        {
            throw new DomException(DomError.Namespace);
        }

        return new DocumentType(_owner, qualifiedName) 
        { 
            PublicIdentifier = publicId, 
            SystemIdentifier = systemId 
        };
    }

    public IDocument CreateHtmlDocument(string title)
    {
        var document = new HtmlDocument();
        document.AppendChild(new DocumentType(document, TagNames.Html));
        document.AppendChild(document.CreateElement(TagNames.Html));
        document.DocumentElement.AppendChild(document.CreateElement(TagNames.Head));

        if (!string.IsNullOrEmpty(title))
        {
            var titleElement = document.CreateElement(TagNames.Title);
            titleElement.AppendChild(document.CreateTextNode(title));
            document.Head!.AppendChild(titleElement);
        }

        document.DocumentElement.AppendChild(document.CreateElement(TagNames.Body));
        document.BaseUrl = _owner.BaseUrl;
        return document;
    }

    public bool HasFeature(string feature, string version = null)
    {
        if (feature is null)
        {
            throw new ArgumentNullException(nameof(feature));
        }

        if (features.TryGetValue(feature, out var versions))
        {
            return versions.Contains(version ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }

    #endregion
}
