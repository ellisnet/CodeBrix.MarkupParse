using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Io;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class DOMActionsTests
{
    private static IDocument CreateEmpty(string url)
    {
        return BrowsingContext.New().OpenNewAsync(url).Result;
    }

    private static IDocument Create(string source)
    {
        return source.ToHtmlDocument();
    }

    [Fact]
    public void ChangeImageSourceWithRelativeUrlResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var img = document.CreateElement<IHtmlImageElement>();
        img.Source = "test.png";
        Assert.Equal("http://localhost/test.png", img.Source);
        var url = new Url(img.Source);
        Assert.Equal("test.png", url.Path);
    }

    [Fact]
    public void ChangeImageSourceWithAbsoluteUrlResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var img = document.CreateElement<IHtmlImageElement>();
        img.Source = "http://www.test.com/test.png";
        Assert.Equal("http://www.test.com/test.png", img.Source);
        var url = new Url(img.Source);
        Assert.Equal("test.png", url.Path);
    }

    [Fact]
    public void ChangeVideoSourceResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var video = document.CreateElement<IHtmlVideoElement>();
        video.Source = "test.mp4";
        Assert.Equal("http://localhost/test.mp4", video.Source);
        var url = new Url(video.Source);
        Assert.Equal("test.mp4", url.Path);
    }

    [Fact]
    public void ChangeVideoPosterResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var video = document.CreateElement<IHtmlVideoElement>();
        video.Poster = "test.jpg";
        Assert.Equal("http://localhost/test.jpg", video.Poster);
        var url = new Url(video.Poster);
        Assert.Equal("test.jpg", url.Path);
    }

    [Fact]
    public void ChangeAudioSourceResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var audio = document.CreateElement<IHtmlAudioElement>();
        audio.Source = "test.mp3";
        Assert.Equal("http://localhost/test.mp3", audio.Source);
        var url = new Url(audio.Source);
        Assert.Equal("test.mp3", url.Path);
    }

    [Fact]
    public void ChangeObjectSourceResultsInUpdatedAbsoluteUrl()
    {
        var document = CreateEmpty("http://localhost");
        var obj = document.CreateElement<IHtmlObjectElement>();
        obj.Source = "test.swv";
        Assert.Equal("http://localhost/test.swv", obj.Source);
        var url = new Url(obj.Source);
        Assert.Equal("test.swv", url.Path);
    }

    [Fact]
    public void InputTypeImageShouldNotBePresentInTheFormElementsCollection()
    {
        var document = Create(@"<form id=""form"">
<input type=""image"">
</form>");
        Assert.Empty(document.Forms[0].Elements);
    }

    [Fact]
    public void FormElementsShouldIncludeElementsWhoseNameStartsWithANumber()
    {
        var document = Create(@"<form id=""form"">
<input type=""image"">
</form>");
        var form = document.Forms[0];
        var two = document.CreateElement<IHtmlInputElement>();
        two.Name = "2";
        form.AppendChild(two);
        var othree = document.CreateElement<IHtmlInputElement>();
        othree.Name = "03";
        form.AppendChild(othree);
        Assert.Null(form.Elements["-1"]);
        Assert.Equal(two, form.Elements[0]);
        Assert.Equal(othree, form.Elements[1]);
        Assert.Equal(2, form.Elements.Length);
        Assert.Equal(two, form.Elements["2"]);
        Assert.Equal(othree, form.Elements["03"]);
        Assert.Equal(new IHtmlElement[] { two, othree }, form.Elements.ToArray());
        form.RemoveChild(two);
        form.RemoveChild(othree);
    }

    [Fact]
    public void ReplaceSingleNodeWithNothing()
    {
        var document = Create("<span></span><em></em>");
        document.QuerySelector("span").Replace();
        Assert.Equal("<em></em>", document.Body.InnerHtml);
    }

    [Fact]
    public void PassEmptyArrayToPrependNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Prepend();
        Assert.Equal(0, document.Body.ChildElementCount);
    }

    [Fact]
    public void PassSingleElementWithPrependNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        var newDiv = document.CreateElement<IHtmlDivElement>();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Prepend(newDiv);
        Assert.Equal(1, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.Children[0].GetTagName());
    }

    [Fact]
    public void PassTwoElementsWithPrependNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        var newDiv = document.CreateElement<IHtmlDivElement>();
        var newAnchor = document.CreateElement<IHtmlAnchorElement>();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Prepend(newDiv, newAnchor);
        Assert.Equal(2, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.Children[0].GetTagName());
        Assert.Equal("a", document.Body.Children[1].GetTagName());
    }

    [Fact]
    public void PassTwoElementsWithPrependNodesToNonEmptyElement()
    {
        var document = Create("<span></span>");
        var newDiv = document.CreateElement<IHtmlDivElement>();
        var newAnchor = document.CreateElement<IHtmlAnchorElement>();
        Assert.Equal(1, document.Body.ChildElementCount);
        document.Body.Prepend(newDiv, newAnchor);
        Assert.Equal(3, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.Children[0].GetTagName());
        Assert.Equal("a", document.Body.Children[1].GetTagName());
        Assert.Equal("span", document.Body.Children[2].GetTagName());
    }

    [Fact]
    public void PassEmptyArrayToAppendNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Append();
        Assert.Equal(0, document.Body.ChildElementCount);
    }

    [Fact]
    public void PassSingleElementWithAppendNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        var newDiv = document.CreateElement<IHtmlDivElement>();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Append(newDiv);
        Assert.Equal(1, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.Children[0].GetTagName());
    }

    [Fact]
    public void PassTwoElementsWithAppendNodes()
    {
        var document = string.Empty.ToHtmlDocument();
        var newDiv = document.CreateElement<IHtmlDivElement>();
        var newAnchor = document.CreateElement<IHtmlAnchorElement>();
        Assert.Equal(0, document.Body.ChildElementCount);
        document.Body.Append(newDiv, newAnchor);
        Assert.Equal(2, document.Body.ChildElementCount);
        Assert.Equal("div", document.Body.Children[0].GetTagName());
        Assert.Equal("a", document.Body.Children[1].GetTagName());
    }

    [Fact]
    public void PassTwoElementsWithAppendNodesToNonEmptyElement()
    {
        var document = Create("<span></span>");
        var newDiv = document.CreateElement<IHtmlDivElement>();
        var newAnchor = document.CreateElement<IHtmlAnchorElement>();
        Assert.Equal(1, document.Body.ChildElementCount);
        document.Body.Append(newDiv, newAnchor);
        Assert.Equal(3, document.Body.ChildElementCount);
        Assert.Equal("span", document.Body.Children[0].GetTagName());
        Assert.Equal("div", document.Body.Children[1].GetTagName());
        Assert.Equal("a", document.Body.Children[2].GetTagName());
    }

    [Fact]
    public void ParentReplacementByCloneWithChildrenExpectedToHaveAParent()
    {
        var document = Create(@"
<html>
<body>
    <div class='parent'>
        <div class='child'>
        </div>
    </div>
</body>
</html>
");
        var originalParent = document.QuerySelector(".parent");

        //clone the parent
        var clonedParent = originalParent.Clone();
        Assert.Null(clonedParent.Parent);

        //remove the original parent
        var grandparent = originalParent.Parent;
        originalParent.Remove();
        Assert.Null(originalParent.Parent);
        Assert.NotNull(grandparent);

        //replace the original parent with the cloned parent
        grandparent.AppendChild(clonedParent);
        //the clone itself has the correct parent
        Assert.Equal(grandparent, clonedParent.Parent);
        //Children on this one
        Assert.True(clonedParent.HasChildNodes);
        //all the children (and grandchildren) of the cloned element have no parent?
        var cloneElement = (IElement)clonedParent;
        Assert.NotNull(cloneElement.FirstChild.Parent);
    }

    [Fact]
    public void ParentReplacementByCloneWithNoChildren()
    {
        var document = Create(@"
<html>
<body>
    <div class='parent'>
        <div class='child'>
        </div>
    </div>
</body>
</html>
");
        var originalParent = document.QuerySelector(".parent");

        //clone the parent
        var clonedParent = originalParent.Clone(false);
        Assert.Null(clonedParent.Parent);

        //remove the original parent
        var grandparent = originalParent.Parent;
        originalParent.Remove();
        Assert.Null(originalParent.Parent);
        Assert.NotNull(grandparent);

        //replace the original parent with the cloned parent
        grandparent.AppendChild(clonedParent);
        //the clone itself has the correct parent
        Assert.Equal(grandparent, clonedParent.Parent);
        //No children on this one
        Assert.False(clonedParent.HasChildNodes);
    }

    [Fact]
    public void IsEqualNodesWithExactlyTheSameNodes()
    {
        var document = Create(@"
<html>
<body>
    <div class='parent'>
        <div class='child'>
        </div>
    </div>
</body>
</html>
");
        var divOne = document.QuerySelector(".parent");
        var divTwo = document.Body.FirstElementChild;
        var divThree = document.QuerySelectorAll("div")[0];

        Assert.Equal(divOne, divThree);
        Assert.Equal(divTwo, divThree);

        Assert.True(divOne.Equals(divTwo));
        Assert.True(divOne.Equals(divThree));
        Assert.True(divTwo.Equals(divThree));
    }

    [Fact]
    public void IsEqualNodesWithClonedNode()
    {
        var document = Create(@"
<html>
<body>
    <div class='parent'>
        <div class='child'>
        </div>
    </div>
</body>
</html>
");
        var original = document.QuerySelector(".parent");
        var clone = original.Clone();

        Assert.NotSame(original, clone);
        Assert.True(original.Equals(clone));
        Assert.False(original.Equals(document.Body));
    }

    [Fact]
    public void ContainsWithChildNodes()
    {
        var document = Create(@"
<html>
<body>
    <div class='parent'>
        <div class='child'>
            <div class='grandchild'></div>
        </div>
    </div>
</body>
</html>
");
        var parent = document.QuerySelector(".parent");
        var child = document.QuerySelector(".child");
        var grandchild = document.QuerySelector(".grandchild");

        Assert.False(parent.Contains(document.Body));
        Assert.True(parent.Contains(parent));
        Assert.True(parent.Contains(child));
        Assert.True(parent.Contains(grandchild));
    }

    [Fact]
    public void ReturnTextFromBody()
    {
        var test = "Some text";
        var html = $@"
<html>
<body>{test}</body></html>";
        var document = Create(html);
        Assert.Equal(test, document.Body.TextContent);
        Assert.Equal(test, document.Body.Text());
        Assert.Equal(test, document.Body.ChildNodes[0].TextContent);

        var text = document.Body.ChildNodes[0] as TextNode;
        Assert.NotNull(text);
        Assert.Equal(test, text.Data);
        Assert.Equal(test, text.Text);
    }

    [Fact]
    public void ReturnConcatTextFromBody()
    {
        var test1 = "Some text";
        var test2 = "Other text";
        var test3 = "Another test";
        var test = string.Concat(test1, test2, test3);
        var html = @"
<html>
<body></body></html>";
        var document = Create(html);
        var text1 = document.CreateTextNode(test1);
        var text2 = document.CreateTextNode(test2);
        var text3 = document.CreateTextNode(test3);
        document.Body.Append(text1);
        document.Body.Append(text2);
        document.Body.Append(text3);
        Assert.Equal(test, document.Body.TextContent);
        Assert.Equal(test, document.Body.Text());
        Assert.Equal(test1, document.Body.ChildNodes[0].TextContent);

        Assert.Equal(test1, text1.Data);
        Assert.Equal(test, text1.Text);
        Assert.Equal(test2, text2.Data);
        Assert.Equal(test, text2.Text);
        Assert.Equal(test3, text3.Data);
        Assert.Equal(test, text3.Text);
    }

    [Fact]
    public void GetRowsFromTable()
    {
        var document = Create("<table><tr></tr><tr></tr></table>");
        var table = document.QuerySelector("table") as IHtmlTableElement;

        Assert.NotNull(table);
        Assert.Equal(2, table.Rows.Length);
        Assert.Empty(table.Rows[0].Cells);
        Assert.Empty(table.Rows[1].Cells);
    }

    [Fact]
    public void GetRowsFromTableWithNesting()
    {
        var html = @"<table id=first><tr></tr><tr><td><table id=second><tr></tr></table></td></tr></table>";
        var document = Create(html);
        var first = document.QuerySelector("#first") as IHtmlTableElement;
        var second = document.QuerySelector("#second") as IHtmlTableElement;

        Assert.NotNull(first);
        Assert.NotNull(second);

        Assert.Equal(2, first.Rows.Length);
        Assert.Empty(first.Rows[0].Cells);
        Assert.Single(first.Rows[1].Cells);
        Assert.Single(second.Rows);
        Assert.Empty(second.Rows[0].Cells);
    }

    [Fact]
    public void PlainOutputElement()
    {
        var document = string.Empty.ToHtmlDocument();
        var output = document.CreateElement<IHtmlOutputElement>();
        Assert.Equal("output", output.Type);
        Assert.Equal("", output.TextContent);
        Assert.Equal("", output.Value);
        Assert.Equal("", output.DefaultValue);
    }

    [Fact]
    public void OutputElementWithTextContent()
    {
        var document = string.Empty.ToHtmlDocument();
        var output = document.CreateElement<IHtmlOutputElement>();
        output.TextContent = "5";
        Assert.Equal("output", output.Type);
        Assert.Equal("5", output.TextContent);
        Assert.Equal("5", output.Value);
        Assert.Equal("5", output.DefaultValue);
    }

    [Fact]
    public void OutputElementWithDefaultValueOverridesTextContent()
    {
        var document = string.Empty.ToHtmlDocument();
        var output = document.CreateElement<IHtmlOutputElement>();
        output.TextContent = "5";
        output.DefaultValue = "10";
        Assert.Equal("output", output.Type);
        Assert.Equal("10", output.TextContent);
        Assert.Equal("10", output.Value);
        Assert.Equal("10", output.DefaultValue);
    }

    [Fact]
    public void OutputElementWithCustomValueOverridesDefaultValue()
    {
        var document = string.Empty.ToHtmlDocument();
        var output = document.CreateElement<IHtmlOutputElement>();
        output.TextContent = "5";
        output.DefaultValue = "10";
        output.Value = "20";
        Assert.Equal("output", output.Type);
        Assert.Equal("20", output.TextContent);
        Assert.Equal("20", output.Value);
        Assert.Equal("10", output.DefaultValue);
    }

    [Fact]
    public void OutputElementWithCustomValueAndDefaultValue()
    {
        var document = string.Empty.ToHtmlDocument();
        var output = document.CreateElement<IHtmlOutputElement>();
        output.TextContent = "5";
        output.DefaultValue = "10";
        output.Value = "20";
        output.DefaultValue = "15";
        Assert.Equal("output", output.Type);
        Assert.Equal("20", output.TextContent);
        Assert.Equal("20", output.Value);
        Assert.Equal("15", output.DefaultValue);
    }

    [Fact]
    public void OptionWithId()
    {
        var document = Create(@"<select>
  <option id=op1>A</option>
  <option name=op2>B</option>
  <option id=op3 name=op4>C</option>
  <option id=>D</option>
  <option name=>D</option>
</select>");
        var select = document.QuerySelector("select") as IHtmlSelectElement;
        Assert.Equal(select.Options[0], select.Options["op1"]);
    }

    [Fact]
    public void OptionWithName()
    {
        var document = Create(@"<select>
  <option id=op1>A</option>
  <option name=op2>B</option>
  <option id=op3 name=op4>C</option>
  <option id=>D</option>
  <option name=>D</option>
</select>");
        var select = document.QuerySelector("select") as IHtmlSelectElement;
        Assert.Equal(select.Options[1], select.Options["op2"]);
    }

    [Fact]
    public void OptionWithNameAndId()
    {
        var document = Create(@"<select>
  <option id=op1>A</option>
  <option name=op2>B</option>
  <option id=op3 name=op4>C</option>
  <option id=>D</option>
  <option name=>D</option>
</select>");
        var select = document.QuerySelector("select") as IHtmlSelectElement;
        Assert.Equal(select.Options[2], select.Options["op3"]);
        Assert.Equal(select.Options[2], select.Options["op4"]);
    }

    [Fact]
    public void OptionEmptyStringName()
    {
        var document = Create(@"<select>
  <option id=op1>A</option>
  <option name=op2>B</option>
  <option id=op3 name=op4>C</option>
  <option id=>D</option>
  <option name=>D</option>
</select>");
        var select = document.QuerySelector("select") as IHtmlSelectElement;
        Assert.Null(select.Options[""]);
    }

    [Fact]
    public void SelectRemoveOptionShouldWork()
    {
        var document = string.Empty.ToHtmlDocument();
        var div = document.CreateElement<IHtmlDivElement>();
        var select = document.CreateElement<IHtmlSelectElement>();
        div.AppendChild(select);
        Assert.Equal(div, select.Parent);
        var options = new IHtmlOptionElement[3];

        for (var i = 0; i < options.Length; i++)
        {
            options[i] = document.CreateElement<IHtmlOptionElement>();
            options[i].TextContent = i.ToString();
            select.AppendChild(options[i]);
        }

        select.RemoveOptionAt(-1);
        Assert.Equal(options, select.Options);

        select.RemoveOptionAt(3);
        Assert.Equal(options, select.Options);

        select.RemoveOptionAt(0);
        Assert.Equal(new[] { options[1], options[2] }, select.Options);
    }

    [Fact]
    public void SelectOptionsRemoveOptionShouldWork()
    {
        var document = string.Empty.ToHtmlDocument();
        var div = document.CreateElement<IHtmlDivElement>();
        var select = document.CreateElement<IHtmlSelectElement>();
        div.AppendChild(select);
        Assert.Equal(div, select.Parent);
        var options = new IHtmlOptionElement[3];

        for (var i = 0; i < options.Length; i++)
        {
            options[i] = document.CreateElement<IHtmlOptionElement>();
            options[i].TextContent = i.ToString();
            select.AppendChild(options[i]);
        }

        select.Options.Remove(-1);
        Assert.Equal(options, select.Options);

        select.Options.Remove(3);
        Assert.Equal(options, select.Options);

        select.Options.Remove(0);
        Assert.Equal(new[] { options[1], options[2] }, select.Options);
    }

    [Fact]
    public void RemoveShouldWorkOnSelectElements()
    {
        var document = string.Empty.ToHtmlDocument();
        var div = document.CreateElement<IHtmlDivElement>();
        var select = document.CreateElement<IHtmlSelectElement>();
        div.AppendChild(select);
        Assert.Equal(div, select.Parent);
        Assert.Equal(select, div.FirstChild);
        select.Remove();
        Assert.Null(select.Parent);
        Assert.Null(div.FirstChild);
    }

    [Fact]
    public void HtmlTagShouldBeEqualToNodeNameAndUppercase()
    {
        var document = string.Empty.ToHtmlDocument();
        var div = document.CreateElement("div");
        Assert.Equal("div", div.LocalName);
        Assert.Null(div.Prefix);
        Assert.Equal("DIV", div.NodeName);
        Assert.Equal("DIV", div.TagName);
        Assert.Equal(NamespaceNames.HtmlUri, div.NamespaceUri);
    }

    [Fact]
    public void XmlTagShouldBeEqualToNodeNameAndPreserveCase()
    {
        var document = string.Empty.ToHtmlDocument();
        var myTag = document.CreateElement(NamespaceNames.XmlUri, "xml:myTag");
        Assert.Equal("myTag", myTag.LocalName);
        Assert.Equal("xml", myTag.Prefix);
        Assert.Equal("xml:myTag", myTag.NodeName);
        Assert.Equal("xml:myTag", myTag.TagName);
        Assert.Equal(NamespaceNames.XmlUri, myTag.NamespaceUri);
    }

    [Fact]
    public void SvgTagShouldBeEqualToNodeNameAndLowercase()
    {
        var document = string.Empty.ToHtmlDocument();
        var title = document.CreateElement(NamespaceNames.SvgUri, "title");
        Assert.Equal("title", title.LocalName);
        Assert.Null(title.Prefix);
        Assert.Equal("title", title.NodeName);
        Assert.Equal("title", title.TagName);
        Assert.Equal(NamespaceNames.SvgUri, title.NamespaceUri);
    }

    [Fact]
    public void MathMlTagShouldBeEqualToNodeNameAndLowercase()
    {
        var document = string.Empty.ToHtmlDocument();
        var mi = document.CreateElement(NamespaceNames.MathMlUri, "mi");
        Assert.Equal("mi", mi.LocalName);
        Assert.Null(mi.Prefix);
        Assert.Equal("mi", mi.NodeName);
        Assert.Equal("mi", mi.TagName);
        Assert.Equal(NamespaceNames.MathMlUri, mi.NamespaceUri);
    }

    [Fact]
    public void CustomTagShouldBeEqualToNodeNameAndPreserveCase()
    {
        var document = string.Empty.ToHtmlDocument();
        var element = document.CreateElement("", "fooBar");
        Assert.Equal("fooBar", element.LocalName);
        Assert.Null(element.Prefix);
        Assert.Equal("fooBar", element.NodeName);
        Assert.Equal("fooBar", element.TagName);
        Assert.Null(element.NamespaceUri);
    }

    [Fact]
    public void TheTypeAttributeMustReturnFieldset()
    {
        var source = (@"<form name=fm1>
  <fieldset id=fs_outer>
  <legend><input type=""checkbox"" name=""cb""></legend>
  <input type=text name=""txt"" id=""ctl1"">
  <button id=""ctl2"" name=""btn"">BUTTON</button>
    <fieldset id=fs_inner>
      <input type=text name=""txt_inner"">
      <progress name=""pg"" value=""0.5""></progress>
    </fieldset>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        var fm1 = document.Forms["fm1"];
        var fs_outer = document.GetElementById("fs_outer") as IHtmlFieldSetElement;
        var children_outer = fs_outer.Elements;
        Assert.Equal("fieldset", fs_outer.Type);
    }

    [Fact]
    public void TheFormAttributeMustReturnTheFieldsetsFormOwner()
    {
        var source = (@"<form name=fm1>
  <fieldset id=fs_outer>
  <legend><input type=""checkbox"" name=""cb""></legend>
  <input type=text name=""txt"" id=""ctl1"">
  <button id=""ctl2"" name=""btn"">BUTTON</button>
    <fieldset id=fs_inner>
      <input type=text name=""txt_inner"">
      <progress name=""pg"" value=""0.5""></progress>
    </fieldset>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        var fm1 = document.Forms["fm1"];
        var fs_outer = document.GetElementById("fs_outer") as IHtmlFieldSetElement;
        var children_outer = fs_outer.Elements;
        Assert.Equal(fm1, fs_outer.Form);
    }

    [Fact]
    public void TheElementsMustReturnAnHtmlFormControlsCollectionObject()
    {
        var source = (@"<form name=fm1>
  <fieldset id=fs_outer>
  <legend><input type=""checkbox"" name=""cb""></legend>
  <input type=text name=""txt"" id=""ctl1"">
  <button id=""ctl2"" name=""btn"">BUTTON</button>
    <fieldset id=fs_inner>
      <input type=text name=""txt_inner"">
      <progress name=""pg"" value=""0.5""></progress>
    </fieldset>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        var fm1 = document.Forms["fm1"];
        var fs_outer = document.GetElementById("fs_outer") as IHtmlFieldSetElement;
        var children_outer = fs_outer.Elements;
        Assert.IsAssignableFrom<IHtmlFormControlsCollection>(children_outer);
        Assert.NotNull(children_outer);
    }

    [Fact]
    public void TheControlsMustRootAtTheFieldsetElement()
    {
        var source = (@"<form name=fm1>
  <fieldset id=fs_outer>
  <legend><input type=""checkbox"" name=""cb""></legend>
  <input type=text name=""txt"" id=""ctl1"">
  <button id=""ctl2"" name=""btn"">BUTTON</button>
    <fieldset id=fs_inner>
      <input type=text name=""txt_inner"">
      <progress name=""pg"" value=""0.5""></progress>
    </fieldset>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        var fm1 = document.Forms["fm1"];
        var fs_outer = document.GetElementById("fs_outer") as IHtmlFieldSetElement;
        var children_outer = fs_outer.Elements;
        var fs_inner = document.GetElementById("fs_inner") as IHtmlFieldSetElement;
        var children_inner = fs_inner.Elements;
        Assert.Equal(new[] { fm1["txt_inner"] as IHtmlElement }, children_inner.ToArray());
        Assert.Equal(new[] { fm1["cb"], fm1["txt"], fm1["btn"], fm1["fs_inner"], fm1["txt_inner"] }.OfType<IHtmlElement>().ToArray(), children_outer.ToArray());
    }

    [Fact]
    public void TheDisabledAttributeCausesAllFormControlDescendantsOfTheFieldsetElementToBeDisabled()
    {
        var source = (@"<form>
  <fieldset disabled>
    <legend>
      <input type=checkbox id=clubc_l1>
      <input type=radio id=clubr_l1>
      <input type=text id=clubt_l1>
    </legend>
    <legend><input type=checkbox id=club_l2></legend>
    <p><label>Name on card: <input id=clubname required></label></p>
    <p><label>Card number: <input id=clubnum required pattern=""[-0-9]+""></label></p>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        Assert.True(document.QuerySelector<IHtmlFieldSetElement>("fieldset").IsDisabled);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubname").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubnum").WillValidate);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#clubc_l1").WillValidate);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#clubr_l1").WillValidate);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#clubt_l1").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#club_l2").WillValidate);
    }

    [Fact]
    public void TheFirstLegendElementIsNotAChildOfTheDisabledFieldsetDescendantsShouldBeDisabled()
    {
        var source = (@"<form>
  <fieldset disabled>
    <p><legend><input type=checkbox id=club2></legend></p>
    <p><label>Name on card: <input id=clubname2 required></label></p>
    <p><label>Card number: <input id=clubnum2 required pattern=""[-0-9]+""></label></p>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        Assert.True(document.QuerySelector<IHtmlFieldSetElement>("fieldset").IsDisabled);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubname2").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubnum2").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#club2").WillValidate);
    }

    [Fact]
    public void TheLegendElementIsNotAChildOfTheDisabledFieldsetDescendantsShouldBeDisabled()
    {
        var source = @"<form>
  <fieldset disabled>
    <fieldset>
      <legend><input type=checkbox id=club3></legend>
    </fieldset>
    <p><label>Name on card: <input id=clubname3 required></label></p>
    <p><label>Card number: <input id=clubnum3 required pattern=""[-0-9]+""></label></p>
  </fieldset>
</form>";
        var document = source.ToHtmlDocument();
        Assert.True(document.QuerySelector<IHtmlFieldSetElement>("fieldset").IsDisabled);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubname3").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubnum3").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#club3").WillValidate);
    }

    [Fact]
    public void TheLegendElementIsChildOfTheDisabledFieldsetDescendantsShouldNotBeDisabled()
    {
        var source = (@"<form>
  <fieldset disabled>
    <legend>
      <fieldset><input type=checkbox id=club4></fieldset>
    </legend>
    <p><label>Name on card: <input id=clubname4 required></label></p>
    <p><label>Card number: <input id=clubnum4 required pattern=""[-0-9]+""></label></p>
  </fieldset>
</form>");
        var document = source.ToHtmlDocument();
        Assert.True(document.QuerySelector<IHtmlFieldSetElement>("fieldset").IsDisabled);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubname4").WillValidate);
        Assert.False(document.QuerySelector<IHtmlInputElement>("#clubnum4").WillValidate);
        Assert.True(document.QuerySelector<IHtmlInputElement>("#club4").WillValidate);
    }

    [Fact]
    public async Task IframeWithDocumentViaDocSrc()
    {
        var cfg = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var html = @"<!doctype html><iframe id=myframe srcdoc='<span>Hello World!</span>'></iframe></script>";
        var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(html), TestContext.Current.CancellationToken);
        var iframe = document.QuerySelector<IHtmlInlineFrameElement>("#myframe");
        Assert.NotNull(iframe);
        Assert.NotNull(iframe.ContentDocument);
        Assert.Equal("Hello World!", iframe.ContentDocument.Body.TextContent);
        Assert.Equal(iframe.ContentDocument, iframe.ContentWindow.Document);
    }

    [Fact]
    public async Task IframeWithDocumentPreferDocSrcToDataSrc()
    {
        var cfg = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true });
        var html = @"<!doctype html><iframe id=myframe srcdoc='Green' src='data:text/html,Red'></iframe></script>";
        var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(html), TestContext.Current.CancellationToken);
        var iframe = document.QuerySelector<IHtmlInlineFrameElement>("#myframe");
        Assert.NotNull(iframe);
        Assert.NotNull(iframe.ContentDocument);
        Assert.Equal("Green", iframe.ContentDocument.Body.TextContent);
        Assert.Equal(iframe.ContentDocument, iframe.ContentWindow.Document);
    }

    [Fact]
    public async Task WindowTimeoutIsWorkingOnce()
    {
        var cfg = Configuration.Default;
        var count = 0;
        var document = await BrowsingContext.New(cfg).OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        document.DefaultView.SetTimeout(_ => count++, 10);
        await Task.Delay(100, TestContext.Current.CancellationToken);
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task WindowTimeoutCanBeCancelled()
    {
        var cfg = Configuration.Default;
        var count = 0;
        var document = await BrowsingContext.New(cfg).OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        var id = document.DefaultView.SetTimeout(_ => count++, 10);
        document.DefaultView.ClearTimeout(id);
        await Task.Delay(100, TestContext.Current.CancellationToken);
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task WindowIntervalIsWorkingMultipleTimes()
    {
        var cfg = Configuration.Default;
        var count = 0;
        var document = await BrowsingContext.New(cfg).OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        var id = document.DefaultView.SetInterval(_ => count++, 10);
        await Task.Delay(100, TestContext.Current.CancellationToken);
        Assert.True(count > 1);
        document.DefaultView.ClearInterval(id);
    }

    [Fact]
    public async Task WindowIntervalCanBeCancelled()
    {
        var cfg = Configuration.Default;
        var count = 0;
        var document = await BrowsingContext.New(cfg).OpenNewAsync(cancellation: TestContext.Current.CancellationToken);
        var id = document.DefaultView.SetInterval(_ => count++, 10);
        document.DefaultView.ClearInterval(id);
        await Task.Delay(100, TestContext.Current.CancellationToken);
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task ElementInsertBeforeBeginPrependsNewElement()
    {
        var source = "<div></div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector("div");

        Assert.NotNull(div);

        div.Insert(AdjacentPosition.BeforeBegin, "<span>Test</span>");

        var span = document.QuerySelector("span");

        Assert.NotNull(span);
        Assert.Equal("Test", span.TextContent);
        Assert.Equal(div, span.NextElementSibling);
    }

    [Fact]
    public async Task ElementInsertAfterEndAppendsNewElement()
    {
        var source = "<div></div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector("div");

        Assert.NotNull(div);

        div.Insert(AdjacentPosition.AfterEnd, "<span>Test</span>");

        var span = document.QuerySelector("span");

        Assert.NotNull(span);
        Assert.Equal("Test", span.TextContent);
        Assert.Equal(div, span.PreviousElementSibling);
    }

    [Fact]
    public async Task ElementInsertAfterBeginInsertsNewElement()
    {
        var source = "<div>After</div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector("div");

        Assert.NotNull(div);

        div.Insert(AdjacentPosition.AfterBegin, "<span>Test</span>");

        var span = document.QuerySelector("span");

        Assert.NotNull(span);
        Assert.Equal("TestAfter", div.TextContent);
        Assert.Equal(div, span.Parent);
    }

    [Fact]
    public async Task ElementInsertBeforeEndInsertsNewElement()
    {
        var source = "<div>Before</div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector("div");

        Assert.NotNull(div);

        div.Insert(AdjacentPosition.BeforeEnd, "<span>Test</span>");

        var span = document.QuerySelector("span");

        Assert.NotNull(span);
        Assert.Equal("BeforeTest", div.TextContent);
        Assert.Equal(div, span.Parent);
    }

    [Fact]
    public async Task TogglingOptionIsDisabledWorksAsExpected()
    {
        var source = "<option></option>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var option = document.QuerySelector<IHtmlOptionElement>("option");

        Assert.False(option.IsDisabled);

        option.IsDisabled = true;

        Assert.True(option.IsDisabled);

        option.IsDisabled = false;

        Assert.False(option.IsDisabled);
        Assert.Empty(option.Attributes);
    }

    [Fact]
    public async Task TogglingOptionIsSelectedWorksAsExpected()
    {
        var source = "<option></option>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var option = document.QuerySelector<IHtmlOptionElement>("option");

        Assert.False(option.IsSelected);

        option.IsSelected = true;

        Assert.True(option.IsSelected);

        option.IsSelected = false;

        Assert.False(option.IsSelected);
        Assert.Empty(option.Attributes);
    }

    [Fact]
    public async Task TogglingOptionIsDefaultSelectedWorksAsExpected()
    {
        var source = "<option></option>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var option = document.QuerySelector<IHtmlOptionElement>("option");

        Assert.False(option.IsDefaultSelected);

        option.IsDefaultSelected = true;

        Assert.True(option.IsDefaultSelected);

        option.IsDefaultSelected = false;

        Assert.False(option.IsDefaultSelected);
        Assert.Empty(option.Attributes);
    }

    [Fact]
    public async Task TogglingAnchorIsTranslatedWorksAsExpected()
    {
        var source = "<a></a>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var a = document.QuerySelector<IHtmlAnchorElement>("a");

        Assert.True(a.IsTranslated);

        a.IsTranslated = false;

        Assert.False(a.IsTranslated);

        a.IsTranslated = true;

        Assert.True(a.IsTranslated);
    }

    [Fact]
    public async Task TogglingDivIsDraggableWorksAsExpected()
    {
        var source = "<div></div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector<IHtmlElement>("div");

        Assert.False(div.IsDraggable);

        div.IsDraggable = true;

        Assert.True(div.IsDraggable);

        div.IsDraggable = false;

        Assert.False(div.IsDraggable);
    }

    [Fact]
    public async Task TogglingDivIsSpellCheckedWorksAsExpected()
    {
        var source = "<div></div>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var div = document.QuerySelector<IHtmlElement>("div");

        Assert.False(div.IsSpellChecked);

        div.IsSpellChecked = true;

        Assert.True(div.IsSpellChecked);

        div.IsSpellChecked = false;

        Assert.False(div.IsSpellChecked);
    }

    [Fact]
    public async Task TogglingSpanIsHiddenCheckedWorksAsExpected()
    {
        var source = "<span></span>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var span = document.QuerySelector<IHtmlElement>("span");

        Assert.False(span.IsHidden);

        span.IsHidden = true;

        Assert.True(span.IsHidden);

        span.IsHidden = false;

        Assert.False(span.IsHidden);
        Assert.Empty(span.Attributes);
    }

    [Fact]
    public async Task TogglingDetailsIsOpenCheckedWorksAsExpected()
    {
        var source = "<details></details>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var details = document.QuerySelector<IHtmlDetailsElement>("details");

        Assert.False(details.IsOpen);

        details.IsOpen = true;

        Assert.True(details.IsOpen);

        details.IsOpen = false;

        Assert.False(details.IsOpen);
        Assert.Empty(details.Attributes);
    }

    [Fact]
    public async Task TogglingInputAutoFocusWorksAsExpected()
    {
        var source = "<input></input>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var input = document.QuerySelector<IHtmlInputElement>("input");

        Assert.False(input.Autofocus);

        input.Autofocus = true;

        Assert.True(input.Autofocus);

        input.Autofocus = false;

        Assert.False(input.Autofocus);
        Assert.Empty(input.Attributes);
    }

    [Fact]
    public async Task TogglingInputFormNoValidateWorksAsExpected()
    {
        var source = "<form><input></input></form>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source), TestContext.Current.CancellationToken);
        var input = document.QuerySelector<IHtmlInputElement>("input");

        Assert.False(input.FormNoValidate);

        input.FormNoValidate = true;

        Assert.True(input.FormNoValidate);

        input.FormNoValidate = false;

        Assert.False(input.FormNoValidate);
    }

    [Fact]
    public void InsertAdjacentHtmlRequiresParentForBeforeBegin()
    {
        var document = CreateEmpty(string.Empty);
        var div = document.CreateElement("div") as IElement;
        Assert.ThrowsAny<DomException>(() =>
        {
            div.Insert(AdjacentPosition.BeforeBegin, "<span></span>");
        });
    }

    [Fact]
    public void InsertAdjacentHtmlWorksWithSpanElement()
    {
        var document = CreateEmpty(string.Empty);
        var div = document.CreateElement("div");
        var x = div.AppendChild(document.CreateElement("span")) as IElement;
        x.Insert(AdjacentPosition.AfterEnd, "<p class=\"cls\">Text</p>");
        Assert.Equal("<span></span><p class=\"cls\">Text</p>", div.InnerHtml);
    }

    [Fact]
    public void InsertAdjacentHtmlWorksWithSelectElement()
    {
        var document = CreateEmpty(string.Empty);
        var div = document.CreateElement("div");
        var x = div.AppendChild(document.CreateElement("select")) as IElement;
        x.Insert(AdjacentPosition.AfterEnd, "<p class=\"cls\">Text</p>");
        Assert.Equal("<select></select><p class=\"cls\">Text</p>", div.InnerHtml);
    }

    [Fact]
    public void CloningDocumentAlsoAdoptsClonedChildren()
    {
        var source = "<div>document</div>";
        var originalDocument = source.ToHtmlDocument();
        var newDocument = (IDocument)originalDocument.Clone(true);

        var div = newDocument.QuerySelector("div");
        Assert.Same(newDocument, div.Owner);

        div.TextContent = "cloned document";
        var newHtml = div.Owner.DocumentElement.OuterHtml;
        Assert.Contains("cloned document", newHtml);
    }

    [Fact]
    public void CloningBodyDoesNotAdoptsClonedChildren()
    {
        var source = "<div>document</div>";
        var originalDocument = source.ToHtmlDocument();
        var newBody = (IElement)originalDocument.Body.Clone(true);

        var div = newBody.QuerySelector("div");
        Assert.Same(originalDocument, div.Owner);

        div.TextContent = "cloned document";
        var newHtml = div.Owner.DocumentElement.OuterHtml;
        Assert.Contains("document", newHtml);
    }

    [Fact]
    public void ReplaceBodyNodeWithImportedNode()
    {
        var document = ("<html><body><div>abc</div></body></html>").ToHtmlDocument();
        var newdocument = string.Empty.ToHtmlDocument();
        var import = newdocument.Import(document.Body, true);

        newdocument.Body.Replace(import);
        Assert.Equal(import, newdocument.Body);
    }

    [Fact]
    public void ReplaceBodyNodeWithClonedNode()
    {
        var document = ("<html><body><div>abc</div></body></html>").ToHtmlDocument();
        var clone = document.Body.Clone(false);

        document.Body.Replace(clone);
        Assert.Equal(clone, document.Body);
    }

    [Fact]
    public void ReplaceBodyNodeWithImportedClonedNode()
    {
        var document = ("<html><body><div>abc</div></body></html>").ToHtmlDocument();
        var newdocument = string.Empty.ToHtmlDocument();
        var clone = document.Body.Clone(true);
        var import = newdocument.Import(clone, true);

        newdocument.Body.Replace(import);
        Assert.Equal(import, newdocument.Body);
    }

    [Fact]
    public async Task SettingLinksBackRemainsRelative_Issue659()
    {
        var source = @"<a href=""/home.htm"">Foo</a>";
        var cfg = Configuration.Default;
        var document = await BrowsingContext.New(cfg).OpenAsync(res => res.Content(source).Address("http://example.com"), TestContext.Current.CancellationToken);
        var a = document.QuerySelector<IHtmlAnchorElement>("a");

        Assert.Equal("http://example.com/home.htm", a.Href);
        Assert.Equal("/home.htm", a.GetAttribute("href"));

        a.Href = "/foo.htm";

        Assert.Equal("http://example.com/foo.htm", a.Href);
        Assert.Equal("/foo.htm", a.GetAttribute("href"));
    }

    [Fact]
    public void GetClosestAncestor()
    {
        var document = Create(@"<div id=""div1""><div id=""div2""><table><tr><td id=""exampletd""><div id=""div3""></div></td></tr><tr></tr></table></div></div>");
        var cell = document.QuerySelector("#exampletd") as IHtmlTableCellElement;

        Assert.NotNull(cell);
        Assert.Equal(cell.Closest("td"), cell);
        Assert.Null(cell.Closest("a"));
        Assert.Equal(cell.Closest("div"), document.QuerySelector("#div2"));
    }

    [Fact]
    public void OuterHtmlForFrame_Issue741()
    {
        var document = Create("<html><body><iframe src=\"https://google.com\"></iframe></body></html>");
        var iframe = document.QuerySelector("iframe");

        Assert.NotNull(iframe);

        iframe.OuterHtml = $"<div>{iframe.OuterHtml}</div>";

        var newContent = document.Body.InnerHtml;

        Assert.Equal("<div><iframe src=\"https://google.com\"></iframe></div>", newContent);
    }

    [Fact]
    public void OuterHtmlForParagraph_Issue741()
    {
        var parser = new HtmlParser();
        var document = parser.ParseDocument("<html><head></head><body></body></html>");
        var fragment = parser.ParseFragment("<p>some text</p>", document.Body);

        (fragment.First() as IHtmlElement).OuterHtml = $"<br/>";

        Assert.Equal("<br>", fragment.ToHtml());
    }

    [Fact]
    public async Task LinkWithoutAConfigurationShouldBeIgnored_Issue753()
    {
        var content = "<!DOCTYPE html>\n<html>\n<head>\n<link href=\"/style.css\" rel=\"stylesheet\" />\n\n</head></html>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        Assert.Null(doc.QuerySelector<IHtmlLinkElement>("link").Sheet);
    }

    [Fact]
    public async Task RemovingVideoSourceShouldWork_Issue914()
    {
        var content = "<video src=\"abc\"></video>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var el = doc.GetElementsByTagName("video")[0];
        el.RemoveAttribute("src");
    }

    [Fact]
    public async Task RemovingAudioSourceShouldWork_Issue914()
    {
        var content = "<audio src=\"abc\"></audio>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var el = doc.GetElementsByTagName("audio")[0];
        el.RemoveAttribute("src");
    }

    [Fact]
    public async Task RemovingEmbedSourceShouldWork_Issue914()
    {
        var content = "<embed src=\"abc\"></embed>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var el = doc.GetElementsByTagName("embed")[0];
        el.RemoveAttribute("src");
    }

    [Fact]
    public async Task RemovingObjectSourceShouldWork_Issue914()
    {
        var content = "<object data=\"abc\"></object>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var el = doc.GetElementsByTagName("object")[0];
        el.RemoveAttribute("data");
    }

    [Fact]
    public async Task RemovingIFrameSourceShouldWork_Issue914()
    {
        var content = "<iframe src=\"abc\"></iframe>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var el = doc.GetElementsByTagName("iframe")[0];
        el.RemoveAttribute("src");
    }

    [Fact]
    public async Task SettingTemplateContentUsingInnerHtmlWorks_Issue1072()
    {
        var content = "<body>";
        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(content);
        var template = doc.CreateElement<IHtmlTemplateElement>();
        template.InnerHtml = "<div></div>";
        Assert.NotNull(template.Content.FirstChild);
        Assert.Empty(template.ChildNodes);
    }

    [Fact]
    public void GetAttributeNode()
    {
        var ns = "http://anglesharp.com/ns";

        var parser = new HtmlParser();
        var document = parser.ParseDocument("<html><head></head><body></body></html>");

        var div = document.CreateElement("div");
        var attributeValue = "abc";
        div.SetAttribute(ns, "test:name", attributeValue);

        var attrByName = div.GetAttributeNode("name");
        var attrByPrefixAndName = div.GetAttributeNode("test:name");
        var attrByNamespaceAndName = div.GetAttributeNode(ns, "name");
        var attrByNamespaceAndPrefixAndName = div.GetAttributeNode(ns, "test:name");

        Assert.Null(attrByName);
        Assert.NotNull(attrByPrefixAndName);
        Assert.NotNull(attrByNamespaceAndName);
        Assert.Null(attrByNamespaceAndPrefixAndName);
        Assert.Equal(attributeValue, attrByPrefixAndName.Value);
        Assert.Equal(attrByPrefixAndName, attrByNamespaceAndName);
    }
}
