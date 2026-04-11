using CodeBrix.MarkupParse.Css;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class PriorityTests
{
    [Fact]
    public void PriorityIdHigherThanClassAndTag()
    {
        var a = Priority.OneId;
        var b = Priority.OneClass;
        var c = Priority.OneTag;
        var d = new Priority(uint.MaxValue);
        var e = Priority.Inline;

        Assert.True(a > b);
        Assert.True(a > c);
        Assert.True(a < d);
        Assert.True(a < e);

        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.True(a <= d);
        Assert.True(a <= e);

        Assert.True(a == Priority.OneId);
        Assert.Equal(Priority.OneId, a);
    }

    [Fact]
    public void PriorityInlineHigherThanIdAndClassAndTag()
    {
        var a = Priority.Inline;
        var b = Priority.OneId;
        var c = Priority.OneClass;
        var d = Priority.OneTag;
        var e = new Priority(uint.MaxValue);

        Assert.True(a > b);
        Assert.True(a > c);
        Assert.True(a > d);
        Assert.True(a < e);

        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.True(a >= d);
        Assert.True(a <= e);

        Assert.True(a == Priority.Inline);
        Assert.Equal(Priority.Inline, a);
    }

    [Fact]
    public void PriorityCustomHigherAll()
    {
        var a = new Priority(uint.MaxValue);
        var b = Priority.OneId;
        var c = Priority.OneClass;
        var d = Priority.OneTag;
        var e = Priority.Inline;

        Assert.True(a > b);
        Assert.True(a > c);
        Assert.True(a > d);
        Assert.True(a > e);

        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.True(a >= d);
        Assert.True(a >= e);

        Assert.True(a == new Priority(uint.MaxValue));
    }

    [Fact]
    public void PriorityImportantHigherAllExcludedCustom()
    {
        var a = new Priority(uint.MaxValue - 1);
        var b = Priority.OneId;
        var c = Priority.OneClass;
        var d = Priority.OneTag;
        var e = Priority.Inline;
        var f = new Priority(uint.MaxValue);

        Assert.True(a > b);
        Assert.True(a > c);
        Assert.True(a > d);
        Assert.True(a > e);
        Assert.True(a < f);

        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.True(a >= d);
        Assert.True(a >= e);
        Assert.True(a <= f);

        Assert.True(a == new Priority(uint.MaxValue - 1));
    }

    [Fact]
    public void PriorityAddSeveralWithoutInline()
    {
        var a = Priority.Zero;
        a += Priority.OneClass;
        a += Priority.OneId;
        a += Priority.OneId;
        a += Priority.OneTag;

        Assert.True(a >= Priority.OneClass);
        Assert.True(a >= Priority.OneId);
        Assert.True(a >= Priority.OneTag);
        Assert.True(a >= Priority.Zero);

        var result = new Priority(0, 2, 1, 1);
        Assert.True(a == result);
        Assert.Equal(result, a);
    }

    [Fact]
    public void PriorityAddSeveralWithInline()
    {
        var a = Priority.Inline;
        a += Priority.OneClass;
        a += Priority.OneId;
        a += Priority.OneId;
        a += Priority.OneTag;

        Assert.True(a > Priority.Inline);
        Assert.True(a > Priority.OneClass);
        Assert.True(a > Priority.OneId);
        Assert.True(a > Priority.OneTag);
        Assert.True(a > Priority.Zero);

        var result = new Priority(1, 2, 1, 1);
        Assert.True(a == result);
        Assert.Equal(result, a);
    }

    [Fact]
    public void PriorityCheckProperties()
    {
        var a = Priority.Inline;
        a += Priority.OneClass;
        a += Priority.OneId;
        a += Priority.OneId;

        byte inlines = 1;
        byte ids = 2;
        byte classes = 1;
        byte tags = 0;

        var result = new Priority(inlines, ids, classes, tags);
        Assert.True(a == result);

        Assert.Equal(inlines, a.Inlines);
        Assert.Equal(ids, a.Ids);
        Assert.Equal(classes, a.Classes);
        Assert.Equal(tags, a.Tags);
        Assert.Equal(result, a);
    }
}
