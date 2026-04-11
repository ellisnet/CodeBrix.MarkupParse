using CodeBrix.MarkupParse.Common;
using System;
using System.Linq;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library;

public class StringOrMemoryTests
{
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [Theory]
    public void SameStringsSameHash(int length)
    {
        var chars = Guid.NewGuid().ToString().ToCharArray();
        if (length >= 0)
        {
            chars = chars.Take(length).ToArray();
        }

        var strA = new StringOrMemory(new string(chars));
        var strB = new StringOrMemory(new string(chars));

        Assert.Equal(strA.GetHashCode(), strB.GetHashCode());
    }

    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [Theory]
    public void SameStringsValuesEquality(int length)
    {
        var chars = Guid.NewGuid().ToString().ToCharArray();
        if (length >= 0)
        {
            chars = chars.Take(length).ToArray();
        }
        var strA = new StringOrMemory(new string(chars));
        var strB = new StringOrMemory(new string(chars));

        Assert.True(strA.Equals(strB), "Input: " + new string(chars));
    }
}
