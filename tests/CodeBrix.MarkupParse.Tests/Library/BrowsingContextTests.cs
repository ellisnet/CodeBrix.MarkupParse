using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class BrowsingContextTests
{
    [Fact]
    public void BrowsingContextAbstractionShouldBeDisposable()
    {
        Assert.Contains(typeof(IDisposable), typeof(IBrowsingContext).GetInterfaces());
    }
}
