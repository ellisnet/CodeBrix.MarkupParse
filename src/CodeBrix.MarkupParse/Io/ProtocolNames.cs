using CodeBrix.MarkupParse.Text;
using System;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Contains the known protocol names.
/// </summary>
public static class ProtocolNames
{
    /// <summary>
    /// The Hypertext Transfer Protocol.
    /// </summary>
    public static readonly string Http = "http";

    /// <summary>
    /// The Hypertext Transfer Protocol Secure.
    /// </summary>
    public static readonly string Https = "https";

    /// <summary>
    /// The File Transfer Protocol.
    /// </summary>
    public static readonly string Ftp = "ftp";

    /// <summary>
    /// The pseudo JavaScript protocol.
    /// </summary>
    public static readonly string JavaScript = "javascript";

    /// <summary>
    /// The pseudo Data protocol.
    /// </summary>
    public static readonly string Data = "data";

    /// <summary>
    /// The pseudo Mailto protocol.
    /// </summary>
    public static readonly string Mailto = "mailto";

    /// <summary>
    /// The pseudo File protocol.
    /// </summary>
    public static readonly string File = "file";

    /// <summary>
    /// The WebSocket protocol.
    /// </summary>
    public static readonly string Ws = "ws";

    /// <summary>
    /// The WebSocket Secure protocol.
    /// </summary>
    public static readonly string Wss = "wss";

    /// <summary>
    /// The Telnet protocol.
    /// </summary>
    public static readonly string Telnet = "telnet";

    /// <summary>
    /// The Secure Shell protocol.
    /// </summary>
    public static readonly string Ssh = "ssh";

    /// <summary>
    /// The legacy gopher protocol.
    /// </summary>
    public static readonly string Gopher = "gopher";
    
    /// <summary>
    /// The binary large object protocol.
    /// </summary>
    public static readonly string Blob = "blob";

    private static readonly string[] RelativeProtocols = new[]
    {
        Http,
        Https,
        Ftp,
        File,
        Ws,
        Wss,
        Gopher
    };

    private static readonly string[] OriginalableProtocols = new[]
    {
        Http,
        Https,
        Ftp,
        Ws,
        Wss,
        Gopher
    };

    /// <summary>
    /// Checks if the given protocol (without a colon in the end) is
    /// following a relative scheme.
    /// </summary>
    /// <param name="protocol">The protocol to examine.</param>
    /// <returns>
    /// True if the protocol is a relative scheme, otherwise false.
    /// </returns>
    public static bool IsRelative(string protocol)
    {
        return RelativeProtocols.Contains(protocol);
    }

    /// <summary>
    /// Checks if the given protocol (without a colon in the end) is
    /// suitable for deriving the origin.
    /// </summary>
    /// <param name="protocol">The protocol to examine.</param>
    /// <returns>
    /// True if the protocol is suited for origin, otherwise false.
    /// </returns>
    public static bool IsOriginable(string protocol)
    {
        return OriginalableProtocols.Contains(protocol);
    }
}
