using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Scripting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

class CallbackScriptEngine : IScriptingService
{
    private string _type;

    public CallbackScriptEngine(Action<ScriptOptions> callback, string type = null)
    {
        Callback = callback;
        _type = type ?? "c-sharp";
    }

    public string Type => _type;

    public bool SupportsType(string mimeType)
    {
        return mimeType.Equals(_type, StringComparison.OrdinalIgnoreCase);
    }

    public Action<ScriptOptions> Callback
    {
        get;
        private set;
    }

    public Task EvaluateScriptAsync(IResponse response, ScriptOptions options, CancellationToken cancel)
    {
        Callback?.Invoke(options);
        return Task.FromResult(true);
    }
}
