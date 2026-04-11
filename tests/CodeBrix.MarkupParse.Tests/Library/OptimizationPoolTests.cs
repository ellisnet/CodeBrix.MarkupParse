using CodeBrix.MarkupParse.Text;
using Xunit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class OptimizationPoolTests : IDisposable
{
    private int _defaultCount;
    private int _defaultLimit;

    public OptimizationPoolTests()
    {
        _defaultCount = StringBuilderPool.MaxCount;
        _defaultLimit = StringBuilderPool.SizeLimit;
    }

    public void Dispose()
    {
        var builderField = typeof(StringBuilderPool).GetField("_builder", BindingFlags.Static | BindingFlags.NonPublic);
        var builder = builderField.GetValue(null) as Stack<StringBuilder>;
        builder.Clear();

        StringBuilderPool.MaxCount = _defaultCount;
        StringBuilderPool.SizeLimit = _defaultLimit;
        StringBuilderPool.IsPoolingDisabled = false;
    }

    [Fact]
    public void RecycleStringBuilderReused()
    {
        var str = "Test";
        var sb1 = StringBuilderPool.Obtain();
        sb1.Append(str);
        Assert.Equal(str, sb1.ToString());
        var sb2 = StringBuilderPool.Obtain();
        Assert.Equal(string.Empty, sb2.ToString());
        Assert.NotSame(sb1, sb2);
        sb1.ToPool();
        sb2.ToPool();
    }

    [Fact]
    public void RecycleStringBuilderGetString()
    {
        var str = "Test";
        var sb1 = StringBuilderPool.Obtain();
        sb1.Append(str);
        Assert.Equal(str, sb1.ToPool());
        var sb2 = StringBuilderPool.Obtain();
        Assert.Equal(string.Empty, sb2.ToPool());
        Assert.Same(sb1, sb2);
    }

    [Fact]
    public void RecycleStringBuilderGetString_DisabledPooling()
    {
        StringBuilderPool.IsPoolingDisabled = true;
        var str = "Test";
        var sb1 = StringBuilderPool.Obtain();
        sb1.Append(str);
        Assert.Equal(str, sb1.ToPool());
        var sb2 = StringBuilderPool.Obtain();
        Assert.Equal(string.Empty, sb2.ToPool());
        Assert.NotSame(sb1, sb2);
    }

    [Fact]
    public void RecycleStringBuilderGetStringReturned()
    {
        var str = "Test";
        var sb1 = StringBuilderPool.Obtain();
        sb1.Append(str);
        Assert.Equal(str, sb1.ToPool());
        var sb2 = StringBuilderPool.Obtain();
        Assert.Same(sb1, sb2);
        sb2.Append(str);
        Assert.Equal(str, sb2.ToString());
        var sb3 = StringBuilderPool.Obtain();
        Assert.NotEqual(sb1, sb3);
        Assert.Equal(string.Empty, sb3.ToPool());
        sb2.ToPool();
    }

    [Fact]
    public void DiscardLargeStringBuilderInstances()
    {
        var newLimit = _defaultLimit / 2;
        var sbO = StringBuilderPool.Obtain();
        var defaultCapacity = sbO.Capacity;
        sbO.Capacity = newLimit;
        sbO.ToPool();
        var sbR = StringBuilderPool.Obtain();
        Assert.Equal(newLimit, sbR.Capacity);
        sbR.Capacity = _defaultLimit * 2;
        sbR.ToPool();
        var sbF = StringBuilderPool.Obtain();
        Assert.Equal(defaultCapacity, sbF.Capacity);
    }

    [Fact]
    public void StringBuilderPoolMaxInstancesIsRespected()
    {
        StringBuilderPool.MaxCount = 2;
        var sb1 = StringBuilderPool.Obtain();
        var sb2 = StringBuilderPool.Obtain();
        var sb3 = StringBuilderPool.Obtain();
        sb1.ToPool();
        sb2.ToPool();
        sb3.ToPool();
        Assert.Equal(sb2, StringBuilderPool.Obtain());
        Assert.Equal(sb1, StringBuilderPool.Obtain());
        Assert.NotEqual(sb3, StringBuilderPool.Obtain());
    }

    [Fact]
    public void StringBuilderDropsOneWithLeastCapacity()
    {
        StringBuilderPool.MaxCount = 4;
        var sb1 = StringBuilderPool.Obtain();
        var sb2 = StringBuilderPool.Obtain();
        var sb3 = StringBuilderPool.Obtain();
        var sb4 = StringBuilderPool.Obtain();
        var sb5 = StringBuilderPool.Obtain();
        sb1.Capacity = 1024;
        sb1.ToPool();
        sb2.Capacity = 512;
        sb2.ToPool();
        sb3.Capacity = 2048;
        sb3.ToPool();
        sb4.Capacity = 8192;
        sb4.ToPool();
        sb5.Capacity = 16384;
        sb5.ToPool();
        Assert.Equal(16384, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(8192, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(2048, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(1024, StringBuilderPool.Obtain().Capacity);
    }

    [Fact]
    public void StringBuilderDoesNotAddSmallerInstances()
    {
        StringBuilderPool.MaxCount = 4;
        var sb1 = StringBuilderPool.Obtain();
        var sb2 = StringBuilderPool.Obtain();
        var sb3 = StringBuilderPool.Obtain();
        var sb4 = StringBuilderPool.Obtain();
        sb1.Capacity = 1024;
        sb1.ToPool();
        sb2.Capacity = 2048;
        sb2.ToPool();
        sb3.Capacity = 8192;
        sb3.ToPool();
        sb4.Capacity = 4096;
        sb4.ToPool();
        Assert.Equal(8192, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(2048, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(1024, StringBuilderPool.Obtain().Capacity);
    }

    [Fact]
    public void StringBuilderPreservesOrderWhenRebuilding()
    {
        StringBuilderPool.MaxCount = 4;
        var sb0 = StringBuilderPool.Obtain();
        var sb1 = StringBuilderPool.Obtain();
        var sb2 = StringBuilderPool.Obtain();
        var sb3 = StringBuilderPool.Obtain();
        var sb4 = StringBuilderPool.Obtain();
        sb0.Capacity = 512;
        sb0.ToPool();
        sb1.Capacity = 1024;
        sb1.ToPool();
        sb2.Capacity = 2048;
        sb2.ToPool();
        sb3.Capacity = 4096;
        sb3.ToPool();
        sb4.Capacity = 8192;
        sb4.ToPool();
        Assert.Equal(8192, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(4096, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(2048, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(1024, StringBuilderPool.Obtain().Capacity);
    }

    [Fact]
    public void StringBuilderDoesNotRebuildIfLeastOneIsAdded()
    {
        StringBuilderPool.MaxCount = 4;
        var sb1 = StringBuilderPool.Obtain();
        var sb2 = StringBuilderPool.Obtain();
        var sb3 = StringBuilderPool.Obtain();
        var sb4 = StringBuilderPool.Obtain();
        var sb5 = StringBuilderPool.Obtain();
        sb1.Capacity = 1024;
        sb1.ToPool();
        sb2.Capacity = 2048;
        sb2.ToPool();
        sb3.Capacity = 4096;
        sb3.ToPool();
        sb4.Capacity = 8192;
        sb4.ToPool();
        sb5.Capacity = 512;
        sb5.ToPool();
        Assert.Equal(8192, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(4096, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(2048, StringBuilderPool.Obtain().Capacity);
        Assert.Equal(1024, StringBuilderPool.Obtain().Capacity);
    }
}
