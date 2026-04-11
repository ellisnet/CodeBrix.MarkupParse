using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Scripting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

class ContentScriptEngine : IScriptingService
{
    private readonly List<Tuple<string, ScriptOptions>> _requests;
    private readonly string _type; 

    public ContentScriptEngine(string type = null)
    {
        _requests = new List<Tuple<string, ScriptOptions>>();
        _type = type ?? MimeTypeNames.DefaultJavaScript;
    }

    public bool SupportsType(string mimeType)
    {
        return mimeType.Equals(_type, StringComparison.OrdinalIgnoreCase);
    }

    public List<Tuple<string, ScriptOptions>> Requests => _requests;

    public Task EvaluateScriptAsync(IResponse response, ScriptOptions options, CancellationToken cancel)
    {
        using (var sr = new StreamReader(response.Content, options.Encoding))
        {
            var source = sr.ReadToEnd();
            _requests.Add(Tuple.Create(source, options));
        }

        return Task.FromResult(false);
    }
}
