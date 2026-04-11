using CodeBrix.MarkupParse.Browser;
using CodeBrix.MarkupParse.Css;
using CodeBrix.MarkupParse.Css.Parser;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Html.Construction;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Html.Forms.Submitters;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Mathml;
using CodeBrix.MarkupParse.Mathml.Dom;
using CodeBrix.MarkupParse.Svg;
using CodeBrix.MarkupParse.Svg.Dom;
using System;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse; //Was previously: namespace AngleSharp

/// <summary>
/// Represents context configuration for the CodeBrix.MarkupParse library. Custom
/// configurations can be made by deriving from this class, just
/// implementing IConfiguration or modifying an instance of this specific
/// class.
/// </summary>
public class Configuration : IConfiguration
{
    #region Fields

    private readonly IEnumerable<object> _services;

    private static T Instance<T>(T instance) => instance;

    private static Func<IBrowsingContext, T> Creator<T>(Func<IBrowsingContext, T> creator) => creator;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new immutable configuration.
    /// </summary>
    /// <param name="services">The services to expose.</param>
    public Configuration(IEnumerable<object> services = null)
    {
        _services = services ?? new object[]
        {
            Instance<IElementFactory<Document, HtmlElement>>(new HtmlElementFactory()),
            Instance<IElementFactory<Document, MathElement>>(new MathElementFactory()),
            Instance<IElementFactory<Document, SvgElement>>(new SvgElementFactory()),
            Instance<IEventFactory>(new DefaultEventFactory()),
            Instance<IInputTypeFactory>(new DefaultInputTypeFactory()),
            Instance<IAttributeSelectorFactory>(new DefaultAttributeSelectorFactory()),
            Instance<IPseudoElementSelectorFactory>(new DefaultPseudoElementSelectorFactory()),
            Instance<IPseudoClassSelectorFactory>(new DefaultPseudoClassSelectorFactory()),
            Instance<ILinkRelationFactory>(new DefaultLinkRelationFactory()),
            Instance<IDocumentFactory>(new DefaultDocumentFactory()),
            Instance<IAttributeObserver>(new DefaultAttributeObserver()),
            Instance<IMetaHandler>(new EncodingMetaHandler()),
            Instance<IHtmlEncoder>(new DefaultHtmlEncoder()),
            Creator<ICssSelectorParser>(ctx => new CssSelectorParser(ctx)),
            Creator<IHtmlParser>(ctx => new HtmlParser(ctx)),
            Creator<INavigationHandler>(ctx => new DefaultNavigationHandler(ctx)),
            Creator<IHtmlElementConstructionFactory>(ctx => new HtmlDomConstructionFactory(ctx)),
        };
    }

    #endregion

    #region Default

    /// <summary>
    /// Gets the default configuration to use. The default configuration
    /// can be overriden by calling the SetDefault method.
    /// </summary>
    public static IConfiguration Default => new Configuration();

    #endregion

    #region Properties

    /// <summary>
    /// Gets an enumeration over the registered services.
    /// </summary>
    public IEnumerable<object> Services => _services;

    #endregion
}
