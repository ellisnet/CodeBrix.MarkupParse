using CodeBrix.MarkupParse.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Specifies what is stored when receiving data.
/// </summary>
public interface IResponse : IDisposable
{
    /// <summary>
    /// Gets the status code that has been send with the response.
    /// </summary>
    HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets the url of the response.
    /// </summary>
    Url Address { get; }

    /// <summary>
    /// Gets the headers that have been send with the response.
    /// </summary>
    IDictionary<string, string> Headers { get; }

    /// <summary>
    /// Gets the content that has been send with the response.
    /// </summary>
    Stream Content { get; }
}
