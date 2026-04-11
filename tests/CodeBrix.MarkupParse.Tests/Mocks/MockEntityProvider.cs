using CodeBrix.MarkupParse.Common;
using CodeBrix.MarkupParse.Dom;
using System;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class MockEntityProvider : IEntityProvider, IEntityProviderExtended
{
    readonly Func<string, string> _resolver;

    public MockEntityProvider(Func<string, string> resolver)
    {
        _resolver = resolver;
    }

    public string GetSymbol(string name)
    {
        return _resolver.Invoke(name);
    }

    public string GetSymbol(StringOrMemory name)
    {
        return _resolver.Invoke(name.ToString());
    }
}
