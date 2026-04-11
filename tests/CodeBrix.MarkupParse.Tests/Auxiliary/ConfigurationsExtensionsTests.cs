using System;
using System.Linq;
using CodeBrix.MarkupParse.Io;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Auxiliary; //Was previously: namespace AngleSharp.Core.Tests.Auxiliary

public class ConfigurationsExtensionsTests
{
    [Fact]
    public void WithoutTServiceRemovesItems()
    {
        var config = new Configuration(Array.Empty<object>())
            .With((IRequester)new DefaultHttpRequester())
            .Without<IRequester>();

        Assert.Empty(config.Services);
    }
}
