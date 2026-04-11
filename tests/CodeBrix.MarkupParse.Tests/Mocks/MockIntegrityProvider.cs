using CodeBrix.MarkupParse.Io;
using System;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class MockIntegrityProvider : IIntegrityProvider
{
    private readonly Func<byte[], string, bool> _validator;

    public MockIntegrityProvider(Func<byte[], string, bool> validator)
    {
        _validator = validator;
    }

    public bool IsSatisfied(byte[] content, string integrity)
    {
        return _validator.Invoke(content, integrity);
    }
}
