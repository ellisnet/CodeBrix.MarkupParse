using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public sealed class FormSetFieldValuesTests
{
    private static IHtmlDocument CreateSampleDocument()
    {
        const string formHtml = @"
<html>
<body>
    <form>
        <!-- text input -->
        <input type='text' name='user' id='user' value='X' />

        <!-- radio input -->
        <input type='radio' name='userType' id='memberOption' value='Member' />
        <input type='radio' name='userType' id='managerOption' value='Manager' checked='checked' />
        <input type='radio' name='userType' id='guestOption' value='Guest' />

        <!-- select -->
        <select name='city' id='city'>
            <option value='0' id='cityOption0'>Jerusalem</option>
            <option value='1' id='cityOption1' selected='selected'>New york</option>
            <option value='2' id='cityOption2'>London</option>
        </select>
    </form>
</body>
</html>";
        var parser = new HtmlParser();
        var document = parser.ParseDocument(formHtml);
        return document;
    }

    [Fact]
    public void SetValueOfTextInput()
    {
        const string inputId = "user";
        const string myName = "yehudah";

        var document = CreateSampleDocument();
        document.Forms[0].SetValues(new Dictionary<string, string>()
        {
            { inputId, myName }
        });

        var input = document.GetElementById(inputId) as IHtmlInputElement;
        Assert.Equal(myName, input.Value);
    }

    [Fact]
    public void SetValueOfSelect()
    {
        var document = CreateSampleDocument();
        document.Forms[0].SetValues(new Dictionary<string, string>()
        {
            { "city", "2" }
        });

        var jerusalemOption = document.GetElementById("cityOption0") as IHtmlOptionElement;
        var newYorkOption = document.GetElementById("cityOption1") as IHtmlOptionElement;
        var londonOption = document.GetElementById("cityOption2") as IHtmlOptionElement;

        Assert.False(jerusalemOption.IsSelected);
        Assert.False(newYorkOption.IsSelected);
        Assert.True(londonOption.IsSelected);
    }

    [Fact]
    public void SetValueOfRadioInput()
    {
        var document = CreateSampleDocument();
        document.Forms[0].SetValues(new Dictionary<string, string>()
        {
            { "userType", "Guest" }
        });

        var guestOption = document.GetElementById("guestOption") as IHtmlInputElement;
        var memberOption = document.GetElementById("memberOption") as IHtmlInputElement;
        var managerOption = document.GetElementById("managerOption") as IHtmlInputElement;

        Assert.True(guestOption.IsChecked);
        Assert.False(memberOption.IsChecked);
        Assert.False(managerOption.IsChecked);
    }

    [Fact]
    public void ThrowExcptionIfFieldNotFound()
    {
        var document = CreateSampleDocument();

        Assert.ThrowsAny<KeyNotFoundException>(() =>
        {
            document.Forms[0].SetValues(new Dictionary<string, string>()
            {
                { "noExistName", "X" }
            });
        });
    }

    [Fact]
    public void CreateNewInputIfFieldNotFound()
    {
        const string newFieldName = "phone";
        const string fieldValue = "1234";

        var document = CreateSampleDocument();
        document.Forms[0].SetValues(new Dictionary<string, string>()
        {
            { newFieldName, fieldValue }
        }, createMissing: true);

        var newField = document.Forms[0]
            .GetNodes<IHtmlInputElement>()
            .SingleOrDefault(x => x.Name == newFieldName);

        Assert.NotNull(newFieldName);
        Assert.Equal(fieldValue, newField.Value);
    }
}
