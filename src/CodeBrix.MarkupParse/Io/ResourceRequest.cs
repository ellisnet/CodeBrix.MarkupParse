using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Represents the arguments to load a resource.
/// </summary>
public class ResourceRequest
{
    #region ctor

    /// <summary>
    /// Creates a new resource request for the given url.
    /// </summary>
    /// <param name="source">The request's source.</param>
    /// <param name="target">The resource's url.</param>
    public ResourceRequest(IElement source, Url target)
    {
        Source = source;
        Target = target;
        Origin = source.Owner!.Origin;
        IsManualRedirectDesired = false;
        IsSameOriginForced = false;
        IsCookieBlocked = false;
        IsCredentialOmitted = false;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the source of the request.
    /// </summary>
    public IElement Source
    {
        get;
    }

    /// <summary>
    /// Gets the target of the request.
    /// </summary>
    public Url Target
    {
        get;
    }

    /// <summary>
    /// Gets or sets the origin of the request, if any.
    /// </summary>
    public string Origin
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets if the manual redirect flag is active.
    /// </summary>
    public bool IsManualRedirectDesired
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets if the force same origin flag is active.
    /// </summary>
    public bool IsSameOriginForced
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets if the omit credentials flag is active.
    /// </summary>
    public bool IsCredentialOmitted
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets if the block cookies flag is active.
    /// </summary>
    public bool IsCookieBlocked
    {
        get;
        set;
    }

    #endregion
}
