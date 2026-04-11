using CodeBrix.MarkupParse.Dom;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Represents the default cookie service. This class can be inherited.
/// </summary>
public class MemoryCookieProvider : ICookieProvider
{
    private readonly CookieContainer _container;

    /// <summary>
    /// Creates a new cookie service for non-persistent cookies.
    /// </summary>
    public MemoryCookieProvider()
    {
        _container = new CookieContainer();
    }

    /// <summary>
    /// Gets the associated cookie container.
    /// </summary>
    public CookieContainer Container => _container;

    /// <summary>
    /// Gets the cookie value of the given address.
    /// </summary>
    /// <param name="url">The origin of the cookie.</param>
    /// <returns>The value of the cookie.</returns>
    public string GetCookie(Url url)
    {
        return _container.GetCookieHeader(url);
    }

    /// <summary>
    /// Sets the cookie value for the given address.
    /// </summary>
    /// <param name="url">The origin of the cookie.</param>
    /// <param name="value">The value of the cookie.</param>
    public void SetCookie(Url url, string value)
    {
        var cookies = Sanatize(url.HostName, value);

        try
        {
            _container.SetCookies(url, cookies);
        }
        catch (CookieException ex)
        {
            Debug.WriteLine("Cookie exception, see {0} for details.", ex);
        }
    }

    private static string Sanatize(string host, string cookie)
    {
        var expires = "expires=";
        var domain = string.Concat("Domain=", host, ";");
        var start = 0;

        while (start < cookie.Length)
        {
            var index = cookie.IndexOf(expires, start, StringComparison.OrdinalIgnoreCase);

            if (index != -1)
            {
                var position = index + expires.Length;
                var end = cookie.IndexOfAny(new[] { ';', ',' }, position + 4);

                if (end == -1)
                {
                    end = cookie.Length;
                }

                var front = cookie.Substring(0, position);
                var middle = cookie.Substring(position, end - position);
                var back = cookie.Substring(end);

                if (DateTime.TryParse(middle.Replace("UTC", "GMT"), out var utc))
                {
                    var time = utc.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture);
                    cookie = $"{front}{time}{back}";
                }

                start = end;
            }
            else
            {
                break;
            }
        }

        return cookie.Replace(domain, string.Empty);
    }
}
