using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class MeterElementTests
{
    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void MeterDefaultValues()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 0;
        Assert.Equal(0.0, meter.Value);
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(1.0, meter.Maximum);
        Assert.Equal(0.0, meter.Low);
        Assert.Equal(1.0, meter.High);
        Assert.Equal(0.5, meter.Optimum);
    }

    [Fact]
    public void MeterSettingValuesToMinMaxLowHighAndOpt()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 3;
        meter.Minimum = -10.1;
        meter.Maximum = 10.1;
        meter.Low = -9.1;
        meter.High = 9.1;
        meter.Optimum = 3.0;
        Assert.Equal(3.0, meter.Value);
        Assert.Equal(-10.1, meter.Minimum);
        Assert.Equal(10.1, meter.Maximum);
        Assert.Equal(-9.1, meter.Low);
        Assert.Equal(9.1, meter.High);
        Assert.Equal(3.0, meter.Optimum);
    }

    [Fact]
    public void MeterInvalidFloatingPointNumberValues()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.SetAttribute("value", "foobar");
        meter.SetAttribute("min", "foobar");
        meter.SetAttribute("max", "foobar");
        meter.SetAttribute("low", "foobar");
        meter.SetAttribute("high", "foobar");
        meter.SetAttribute("optimum", "foobar");
        Assert.Equal(0.0, meter.Value);
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(1.0, meter.Maximum);
        Assert.Equal(0.0, meter.Low);
        Assert.Equal(1.0, meter.High);
        Assert.Equal(0.5, meter.Optimum);
    }

    [Fact]
    public void MeterMaxLessThanMin()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 0.0;
        meter.Minimum = 0.0;
        meter.Maximum = -1.0;
        Assert.Equal(0.0, meter.Value);
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(0.0, meter.Maximum);
        Assert.Equal(0.0, meter.Low);
        Assert.Equal(0.0, meter.High);
        Assert.Equal(0.0, meter.Optimum);
    }

    [Fact]
    public void MeterValueLessThanMin()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 0.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        Assert.Equal(10.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterValueGreaterThanMax()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 30.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        Assert.Equal(20.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterLowLessThanMin()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 5.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterLowGreaterThanMax()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 25.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(20.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterHighLessThanLow()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 12.0;
        meter.High = 10.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(12.0, meter.Low);
        Assert.Equal(12.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterHighGreaterThanMax()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 10.0;
        meter.High = 22.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(15.0, meter.Optimum);
    }

    [Fact]
    public void MeterOptimumLessThanMin()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 10.0;
        meter.High = 20.0;
        meter.Optimum = 9.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(10.0, meter.Optimum);
    }

    [Fact]
    public void MeterOptimumGreaterThanMax()
    {
        var document = Html("");
        var meter = document.CreateElement<IHtmlMeterElement>();
        meter.Value = 15.0;
        meter.Minimum = 10.0;
        meter.Maximum = 20.0;
        meter.Low = 10.0;
        meter.High = 20.0;
        meter.Optimum = 21.0;
        Assert.Equal(15.0, meter.Value);
        Assert.Equal(10.0, meter.Minimum);
        Assert.Equal(20.0, meter.Maximum);
        Assert.Equal(10.0, meter.Low);
        Assert.Equal(20.0, meter.High);
        Assert.Equal(20.0, meter.Optimum);
    }

    [Fact]
    public void MeterValueMustBeZeroWhenAStringIsGiven()
    {
        var document = Html("<meter value=abc></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(0.0, meter.Value);
    }

    [Fact]
    public void MeterDefaultValueOfMinIsZero()
    {
        var document = Html("<meter value=-10></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(0.0, meter.Value);
    }

    [Fact]
    public void MeterDefaultValueOfMaxIsOne()
    {
        var document = Html("<meter value=10></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(1.0, meter.Maximum);
        Assert.Equal(1.0, meter.Value);
    }

    [Fact]
    public void MeterValueSmallerThanOneGivenMinAndMaxNotSpecifiedSameAsDefaultMax()
    {
        var document = Html("<meter value=10 min=-3.1></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(1.0, meter.Maximum);
        Assert.Equal(1.0, meter.Value);
    }

    [Fact]
    public void MeterValueLargerThanOrEqualToOneGivenToMinAndMaxNotSpecified()
    {
        var document = Html("<meter value=210 min=12.1></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(12.1, meter.Maximum);
        Assert.Equal(12.1, meter.Value);
    }

    [Fact]
    public void MeterValueSmallerThanZeroGivenToMaxAndMinNotSpecifiedSameAsDefault()
    {
        var document = Html("<meter value=-10 max=-5342.55></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(0.0, meter.Value);
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(0.0, meter.Maximum);
    }

    [Fact]
    public void MeterValueLargerThanOrEqualToZeroGivenToMaxAndMinNoSpecifiedSameAsDefault()
    {
        var document = Html("<meter value=210 max=-9.9></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(0.0, meter.Value);
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(0.0, meter.Maximum);
    }

    [Fact]
    public void MeterMinMustBeZeroWhenAStringIsGiven()
    {
        var document = Html("<meter value=-2 min=hugfe></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(0.0, meter.Minimum);
        Assert.Equal(0.0, meter.Value);
    }

    [Fact]
    public void MeterMaxMustBeOneWhenAStringIsGiven()
    {
        var document = Html("<meter value=2.4 max=min></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(1.0, meter.Maximum);
        Assert.Equal(1.0, meter.Value);
    }

    [Fact]
    public void MeterIllegalLowWithMinNotAffectTheActualValue()
    {
        var document = Html("<meter value=-20 min=-10.3 low=ahuge></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(-10.3, meter.Low);
    }

    [Fact]
    public void MeterIllegalHighWithMaxNotAffectTheActualValue()
    {
        var document = Html("<meter value=2.4 high=old max=1.5></meter>");
        var meter = document.QuerySelector("meter") as IHtmlMeterElement;
        Assert.Equal(1.5, meter.High);
        Assert.Equal(1.5, meter.Value);
    }
}
