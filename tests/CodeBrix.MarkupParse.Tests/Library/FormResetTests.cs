using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class FormResetTests
{
    private static readonly string documentSource = @"<!DOCTYPE html>
<meta charset=""utf-8"">
<form name=fm1>
  <input value=""abc"" id=""ipt1"" />
  <input id=""ipt2"" />
  <input type=""radio"" id=""rd1"" checked=""checked"" />
  <input type=""radio"" id=""rd2""/>
  <input type=""checkbox"" id=""cb1"" checked=""checked"" />
  <input type=""checkbox"" id=""cb2"" />
  <textarea id=""ta"">abc</textarea>
  <!--<keygen id=""kg""></keygen>-->
  <output id=""opt"">5</output>
  <select id=""slt1"">
    <option value=""1"">ITEM1</option>
    <option value=""2"">ITEM2</option>
  </select>
  <select id=""slt2"">
    <option value=""1"">ITEM1</option>
    <option value=""2"" selected>ITEM2</option>
  </select>
  <select id=""slt3"" multiple>
    <option value=""1"">ITEM1</option>
    <option value=""2"" selected>ITEM2</option>
    <option value=""3"" selected>ITEM3</option>
  </select>
  <button  id=""rst1"" type=""reset"">Reset1</button>
  <input id=""rst2"" type=""reset"" value=""Reset2"" />
</form>";

    [Fact]
    public void MutateFormByChangingValues()
    {
        var document = documentSource.ToHtmlDocument();
        document.QuerySelector<IHtmlInputElement>("#ipt1").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#ipt2").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked = true;
        document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked = true;
        document.QuerySelector<IHtmlTextAreaElement>("#ta").Value = "123";
        document.QuerySelector<IHtmlOutputElement>("#opt").TextContent = "abc";
        document.QuerySelector<IHtmlSelectElement>("#slt1").Value = "2";
        document.QuerySelector<IHtmlSelectElement>("#slt2").Value = "1";
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected = true;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected = false;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected = false;

        Assert.Equal("123", document.QuerySelector<IHtmlInputElement>("#ipt1").Value);
        Assert.Equal("123", document.QuerySelector<IHtmlInputElement>("#ipt2").Value);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked);
        Assert.Equal("123", document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal("abc", document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[1].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected);
    }

    [Fact]
    public void ResetFormByCallingTheResetMethod()
    {
        var document = documentSource.ToHtmlDocument();
        document.QuerySelector<IHtmlInputElement>("#ipt1").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#ipt2").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked = true;
        document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked = true;
        document.QuerySelector<IHtmlTextAreaElement>("#ta").Value = "123";
        document.QuerySelector<IHtmlOutputElement>("#opt").TextContent = "abc";
        document.QuerySelector<IHtmlSelectElement>("#slt1").Value = "2";
        document.QuerySelector<IHtmlSelectElement>("#slt2").Value = "1";
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected = true;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected = false;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected = false;

        document.Forms[0].Reset();

        Assert.Equal("abc", document.QuerySelector<IHtmlInputElement>("#ipt1").Value);
        Assert.Equal("", document.QuerySelector<IHtmlInputElement>("#ipt2").Value);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked);
        Assert.Equal(document.QuerySelector<IHtmlTextAreaElement>("#ta").TextContent, document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal("abc", document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal(document.QuerySelector<IHtmlOutputElement>("#opt").DefaultValue, document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.Equal("abc", document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[0].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected);
    }

    [Fact]
    public void ResetFormByClickingButtonInResetStatus()
    {
        var document = documentSource.ToHtmlDocument();
        document.QuerySelector<IHtmlInputElement>("#ipt1").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#ipt2").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked = true;
        document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked = true;
        document.QuerySelector<IHtmlTextAreaElement>("#ta").Value = "123";
        document.QuerySelector<IHtmlOutputElement>("#opt").TextContent = "abc";
        document.QuerySelector<IHtmlSelectElement>("#slt1").Value = "2";
        document.QuerySelector<IHtmlSelectElement>("#slt2").Value = "1";
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected = true;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected = false;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected = false;

        document.QuerySelector<IHtmlButtonElement>("#rst1").DoClick();

        Assert.Equal("abc", document.QuerySelector<IHtmlInputElement>("#ipt1").Value);
        Assert.Equal("", document.QuerySelector<IHtmlInputElement>("#ipt2").Value);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked);
        Assert.Equal(document.QuerySelector<IHtmlTextAreaElement>("#ta").TextContent, document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal("abc", document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal(document.QuerySelector<IHtmlOutputElement>("#opt").DefaultValue, document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.Equal("abc", document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[0].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected);
    }

    [Fact]
    public void ResetFormByClickingResetButton()
    {
        var document = documentSource.ToHtmlDocument();
        document.QuerySelector<IHtmlInputElement>("#ipt1").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#ipt2").Value = "123";
        document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked = true;
        document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked = false;
        document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked = true;
        document.QuerySelector<IHtmlTextAreaElement>("#ta").Value = "123";
        document.QuerySelector<IHtmlOutputElement>("#opt").TextContent = "abc";
        document.QuerySelector<IHtmlSelectElement>("#slt1").Value = "2";
        document.QuerySelector<IHtmlSelectElement>("#slt2").Value = "1";
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected = true;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected = false;
        document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected = false;

        document.QuerySelector<IHtmlInputElement>("#rst2").DoClick();

        Assert.Equal("abc", document.QuerySelector<IHtmlInputElement>("#ipt1").Value);
        Assert.Equal("", document.QuerySelector<IHtmlInputElement>("#ipt2").Value);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#rd1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#rd2").IsChecked);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#cb1").IsChecked);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#cb2").IsChecked);
        Assert.Equal(document.QuerySelector<IHtmlTextAreaElement>("#ta").TextContent, document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal("abc", document.QuerySelector<IHtmlTextAreaElement>("#ta").Value);
        Assert.Equal(document.QuerySelector<IHtmlOutputElement>("#opt").DefaultValue, document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.Equal("abc", document.QuerySelector<IHtmlOutputElement>("#opt").TextContent);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[0].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt1").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt2").Options[1].IsSelected);
        Assert.False(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[0].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[1].IsSelected);
        Assert.True(document.QuerySelector<IHtmlSelectElement>("#slt3").Options[2].IsSelected);
    }
}
