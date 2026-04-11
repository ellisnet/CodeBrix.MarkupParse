using CodeBrix.MarkupParse.Css;
using CodeBrix.MarkupParse.Css.Dom;
using CodeBrix.MarkupParse.Css.Parser;
using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class CssSelectorTests
{
    private static IHtmlCollection<IElement> RunQuery(IDocument document, string query)
    {
        return document.QuerySelectorAll(query);
    }

    private static IHtmlCollection<IElement> RunQuery(string query)
    {
        var document = Assets.selectors.ToHtmlDocument();
        return RunQuery(document, query);
    }

    [Fact]
    public void PseudoSelectorFirstChild()
    {
        Assert.Equal(7, RunQuery("*:first-child").Length);
        Assert.Single(RunQuery("p:first-child"));
    }

    [Fact]
    public void StrangeDashSelector()
    {
        var source = @"<ul>
  <li id=""-a-b-c-"">The background of this list item should be green</li>
  <li>The background of this second list item should be also green</li>
</ul>";
        var doc = source.ToHtmlDocument();

        var selector = doc.QuerySelectorAll("#-a-b-c-");
        Assert.Single(selector);
    }

    [Fact]
    public void PseudoSelectorLastChild()
    {
        Assert.Equal(7, RunQuery("*:last-child").Length);
        Assert.Equal(2, RunQuery("p:last-child").Length);
    }

    [Fact]
    public void PseudoSelectorOnlyChild()
    {
        Assert.Equal(3, RunQuery("*:only-child").Length);
        Assert.Single(RunQuery("p:only-child"));
    }

    [Fact]
    public void PseudoSelectorEmpty()
    {
        var results = RunQuery("*:empty");
        Assert.Equal(2, results.Length);
        Assert.Equal("head", results[0].GetTagName());
        Assert.Equal("input", results[1].GetTagName());
    }

    [Fact]
    public void NthChildNoPrefixWithDigit()
    {
        var result = RunQuery(":nth-child(2)");

        Assert.Equal(4, result.Length);
        Assert.Equal("body", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("p", result[3].GetTagName());
    }

    [Fact]
    public void NthChildWithOfSyntax()
    {
        var document = Assets.moreselectors.ToHtmlDocument();
        var highlightClassThatIsSecondChild = RunQuery(document, ".highlight:nth-child(2)");
        var secondChildThatHasHighlight = RunQuery(document, ":nth-child(2 of .highlight)");

        Assert.Single(highlightClassThatIsSecondChild);
        Assert.Single(secondChildThatHasHighlight);
        Assert.NotEqual(highlightClassThatIsSecondChild[0], secondChildThatHasHighlight[0]);
        Assert.Equal("li", secondChildThatHasHighlight[0].GetTagName());
        Assert.Equal("highlight", secondChildThatHasHighlight[0].ClassName);
    }

    [Fact]
    public void NthChildStarPrefixWithDigit()
    {
        var result = RunQuery("*:nth-child(2)");

        Assert.Equal(4, result.Length);
        Assert.Equal("body", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("p", result[3].GetTagName());
    }

    [Fact]
    public void NthChildElementPrefixWithDigit()
    {
        var result = RunQuery("p:nth-child(2)");

        Assert.Equal(2, result.Length);
        Assert.Equal("p", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void NthLastChildNoPrefixWithDigit()
    {
        var result = RunQuery(":nth-last-child(2)");

        Assert.Equal(4, result.Length);
        Assert.Equal("head", result[0].GetTagName());
        Assert.Equal("div", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("div", result[3].GetTagName());
    }

    [Fact]
    public void NthLastChildIdPrefixWithDigit()
    {
        var result = RunQuery("#myDiv :nth-last-child(2)");

        Assert.Equal(2, result.Length);
        Assert.Equal("div", result[0].GetTagName());
        Assert.Equal("span", result[1].GetTagName());
    }

    [Fact]
    public void NthLastChildElementPrefixWithDigit()
    {
        var result = RunQuery("span:nth-last-child(3)");

        Assert.Empty(result);
    }

    [Fact]
    public void NthLastChildElementPrefixWithDigit2()
    {
        var result = RunQuery("span:nth-last-child(2)");

        Assert.Single(result);
        Assert.Equal("span", result[0].GetTagName());
    }

    [Fact]
    public void MultipleSelectorsCommaSupportWithNoSpace()
    {
        var result = RunQuery("p.hiclass,a");

        Assert.Equal(3, result.Length);
        Assert.Equal("a", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void MultipleSelectorsCommaSupportWithPostPendedSpace()
    {
        var result = RunQuery("p.hiclass, a");

        Assert.Equal(3, result.Length);
        Assert.Equal("a", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void MultipleSelectorsCommaSupportWithPrepostpendedSpace()
    {
        var result = RunQuery("p.hiclass , a");

        Assert.Equal(3, result.Length);
        Assert.Equal("a", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void MultipleSelectorsCommaSupportWithPrependedSpace()
    {
        var result = RunQuery("p.hiclass ,a");

        Assert.Equal(3, result.Length);
        Assert.Equal("a", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void IdSelectorBasicSelector()
    {
        var result = RunQuery("#myDiv");

        Assert.Single(result);
        Assert.Equal("div", result[0].GetTagName());
    }

    [Fact]
    public void IdSelectorWithElement()
    {
        var result = RunQuery("div#myDiv");

        Assert.Single(result);
        Assert.Equal("div", result[0].GetTagName());
    }

    [Fact]
    public void IdSelectorWithExistingIdDescendant()
    {
        var result = RunQuery("#theBody #myDiv");

        Assert.Single(result);
        Assert.Equal("div", result[0].GetTagName());
    }

    [Fact]
    public void IdSelectorWithNonExistantIdDescendant()
    {
        var result = RunQuery("#theBody #whatwhatwhat");

        Assert.Empty(result);
    }

    [Fact]
    public void IdSelectorWithNonExistantIdAncestor()
    {
        var result = RunQuery("#whatwhatwhat #someOtherDiv");

        Assert.Empty(result);
    }

    [Fact]
    public void IdSelectorAllDescendantsOfId()
    {
        var result = RunQuery("#myDiv *");

        Assert.Equal(5, result.Length);
        Assert.Equal("div", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void IdSelectorChildId()
    {
        var result = RunQuery("#theBody>#myDiv");

        Assert.Single(result);
        Assert.Equal("div", result[0].GetTagName());
    }

    [Fact]
    public void IdSelectorNotAChildId()
    {
        var result = RunQuery("#theBody>#someOtherDiv");

        Assert.Empty(result);
    }

    [Fact]
    public void IdSelectorAllChildrenOfId()
    {
        var result = RunQuery("#myDiv>*");

        Assert.Equal(2, result.Length);
        Assert.Equal("div", result[0].GetTagName());
        Assert.Equal("p", result[1].GetTagName());
    }

    [Fact]
    public void IdSelectorAllChildrenofIdWithNoChildren()
    {
        var result = RunQuery("#someOtherDiv>*");

        Assert.Empty(result);
    }

    [Fact]
    public void ElementSelectorStar()
    {
        Assert.Equal(16, RunQuery("*").Length);
    }

    [Fact]
    public void ElementSelectorSingleTagName()
    {
        Assert.Single(RunQuery("body"));
        Assert.Equal("body", RunQuery("body")[0].GetTagName());
    }

    [Fact]
    public void ElementSelectorSingleTagNameMatchingMultipleElements()
    {
        Assert.Equal(3, RunQuery("p").Length);
        Assert.Equal("p", RunQuery("p")[0].GetTagName());
        Assert.Equal("p", RunQuery("p")[1].GetTagName());
        Assert.Equal("p", RunQuery("p")[2].GetTagName());
    }

    [Fact]
    public void ElementSelectorBasicNegativePrecedence()
    {
        Assert.Empty(RunQuery("head p"));
    }

    [Fact]
    public void ElementSelectorBasicPositivePrecedenceTwoTags()
    {
        Assert.Equal(2, RunQuery("div p").Length);
    }

    [Fact]
    public void ElementSelectorBasicPositivePrecedenceTwoTagsWithGrandchildDescendant()
    {
        Assert.Equal(2, RunQuery("div a").Length);
    }

    [Fact]
    public void ElementSelectorBasicPositivePrecedenceThreeTags()
    {
        Assert.Single(RunQuery("div p a"));
        Assert.Equal("a", RunQuery("div p a")[0].GetTagName());
    }

    [Fact]
    public void ElementSelectorBasicPositivePrecedenceWithSameTags()
    {
        Assert.Single(RunQuery("div div"));
    }

    [Fact]
    public void ElementSelectorBasicPositivePrecedenceWithinForm()
    {
        Assert.Single(RunQuery("form input"));
    }

    [Fact]
    public void ClassSelectorBasic()
    {
        var result = RunQuery(".checkit");

        Assert.Equal(2, result.Length);
        Assert.Equal("div", result[0].GetTagName());
        Assert.Equal("div", result[1].GetTagName());
    }

    [Fact]
    public void ClassSelectorChained()
    {
        var result = RunQuery(".omg.ohyeah");

        Assert.Single(result);
        Assert.Equal("p", result[0].GetTagName());
        Assert.Equal("eeeee", result[0].TextContent);
    }

    [Fact]
    public void ClassSelectorWithElement()
    {
        var result = RunQuery("p.ohyeah");

        Assert.Single(result);
        Assert.Equal("p", result[0].GetTagName());
        Assert.Equal("eeeee", result[0].TextContent);
    }

    [Fact]
    public void ClassSelectorParentClassSelector()
    {
        var result = RunQuery("div .ohyeah");

        Assert.Single(result);
        Assert.Equal("p", result[0].GetTagName());
        Assert.Equal("eeeee", result[0].TextContent);
    }

    [Fact]
    public void ComplexSelectorChildWithPreAndPostSpace()
    {
        Assert.Equal(2, RunQuery("div > p").Length);
    }

    [Fact]
    public void ComplexSelectorChildWithPostSpace()
    {
        Assert.Equal(2, RunQuery("div> p").Length);
    }

    [Fact]
    public void ComplexSelectorChildWithPreSpace()
    {
        Assert.Equal(2, RunQuery("div >p").Length);
    }

    [Fact]
    public void ComplexSelectorChildWithNoSpace()
    {
        Assert.Equal(2, RunQuery("div>p").Length);
    }

    [Fact]
    public void ComplexSelectorChildWithClass()
    {
        Assert.Single(RunQuery("div > p.ohyeah"));
    }

    [Fact]
    public void ComplexSelectorAllChildren()
    {
        Assert.Equal(3, RunQuery("p > *").Length);
    }

    [Fact]
    public void ComplexSelectorAllGrandChildren()
    {
        Assert.Equal(3, RunQuery("div > * > *").Length);
    }

    [Fact]
    public void ComplexSelectorAdjacentWithPreAndPostSpace()
    {
        Assert.Single(RunQuery("a + span"));
    }

    [Fact]
    public void ComplexSelectorAdjacentWithPostSpace()
    {
        Assert.Single(RunQuery("a+ span"));
    }

    [Fact]
    public void ComplexSelectorAdjacentWithPreSpace()
    {
        Assert.Single(RunQuery("a +span"));
    }

    [Fact]
    public void ComplexSelectorAdjacentWithNoSpace()
    {
        Assert.Single(RunQuery("a+span"));
    }

    [Fact]
    public void ComplexSelectorCommaChildAndAdjacent()
    {
        Assert.Equal(3, RunQuery("a + span, div > p").Length);
    }

    [Fact]
    public void ComplexSelectorGeneralSiblingCombinator()
    {
        var result = RunQuery("div ~ form");
        Assert.Single(result);
        Assert.Equal("form", result[0].GetTagName());
    }

    [Fact]
    public void AttributeSelectorElementAttrExists()
    {
        var results = RunQuery("div[id]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("div", results[1].GetTagName());
    }

    [Fact]
    public void AttributeSelectorElementAttrEqualsWithDoubleQuotes()
    {
        var results = RunQuery("div[id=\"someOtherDiv\"]");

        Assert.Single(results);
        Assert.Equal("div", results[0].GetTagName());
    }

    [Fact]
    public void AttributeSelectorElementAttrSpaceSeparatedWithDoubleQuotes()
    {
        var results = RunQuery("p[class~=\"ohyeah\"]");

        Assert.Single(results);
        Assert.Equal("p", results[0].GetTagName());
        Assert.Equal("eeeee", results[0].TextContent);
    }

    [Fact]
    public void AttributeSelectorElementAttrSpaceSeparatedWithEmptyValue()
    {
        Assert.Empty(RunQuery("p[class~='']"));
    }

    [Fact]
    public void AttributeSelectorElementAttrHyphenSeparatedWithDoubleQuotes()
    {
        var results = RunQuery("span[class|=\"separated\"]");
        Assert.Empty(results);
    }

    [Fact]
    public void AttributeSelectorImplicitStarAttrExactWithDoubleQuotes()
    {
        var results = RunQuery("[class=\"checkit\"]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("woooeeeee", results[0].TextContent);
        Assert.Equal("div", results[1].GetTagName());
        Assert.Equal("woootooowe", results[1].TextContent);
    }

    [Fact]
    public void AttributeSelectorStarAttrExactWithDoubleQuotes()
    {
        var results = RunQuery("*[class=\"checkit\"]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("woooeeeee", results[0].TextContent);
        Assert.Equal("div", results[1].GetTagName());
        Assert.Equal("woootooowe", results[1].TextContent);
    }

    [Fact]
    public void AttributeSelectorStarAttrPrefix()
    {
        var results = RunQuery("*[class^=check]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("woooeeeee", results[0].TextContent);
        Assert.Equal("div", results[1].GetTagName());
        Assert.Equal("woootooowe", results[1].TextContent);
    }

    [Fact]
    public void AttributeSelectorStarAttrPrefixWithEmptyValue()
    {
        Assert.Empty(RunQuery("*[class^='']"));
    }

    [Fact]
    public void AttributeSelectorStarAttrSuffix()
    {
        var results = RunQuery("*[class$=it]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("woooeeeee", results[0].TextContent);
        Assert.Equal("div", results[1].GetTagName());
        Assert.Equal("woootooowe", results[1].TextContent);
    }

    [Fact]
    public void AttributeSelectorStarAttrSuffixWithEmptyValue()
    {
        Assert.Empty(RunQuery("*[class$='']"));
    }

    [Fact]
    public void AttributeSelectorStarAttrSubstring()
    {
        var results = RunQuery("*[class*=heck]");

        Assert.Equal(2, results.Length);
        Assert.Equal("div", results[0].GetTagName());
        Assert.Equal("woooeeeee", results[0].TextContent);
        Assert.Equal("div", results[1].GetTagName());
        Assert.Equal("woootooowe", results[1].TextContent);
    }

    [Fact]
    public void AttributeSelectorStarAttrSubstringWithEmptyValue()
    {
        Assert.Empty(RunQuery("*[class*='']"));
    }

    [Fact]
    public void AttributeSelectorElementAttrNotEqual()
    {
        var results = RunQuery("p[class!='hiclass']");
        Assert.Equal(2, results.Length);
        var value = results[0].GetAttribute("class");
        Assert.Null(value);
        Assert.Equal("eeeee", results[1].TextContent);
    }

    [Fact]
    public void ScopeSelectorChild()
    {
        var source = @"<p>First paragraph</p><div><p>Hello in a paragraph</p></div>";

        var document = source.ToHtmlDocument();
        var selector = ":scope > p";
        var result = document.Body.Children[1].QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal(document.Body.ChildNodes[1].ChildNodes[0], result[0]);
    }

    [Fact]
    public void HasSelectorSimple()
    {
        var source = @"<div><p>Hello in a paragraph</p></div>
<div>Hello again! (with no paragraph)</div>";

        var document = source.ToHtmlDocument();
        var selector = "div:has(p)";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal(document.Body.ChildNodes[0], result[0]);
    }

    [Fact]
    public void HasSelectorChild()
    {
        var source = @"<div><div><p>Hello in a paragraph</p></div></div>";

        var document = source.ToHtmlDocument();
        var selector = "div:has(> p)";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal(document.Body.ChildNodes[0].ChildNodes[0], result[0]);
    }

    [Fact]
    public void HasSelectorFollowing()
    {
        var source = @"<div><div><p>Hello in a paragraph</p><p>Another paragraph</p></div></div>";

        var document = source.ToHtmlDocument();
        var selector = "p:has(+ p)";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal(document.Body.ChildNodes[0].ChildNodes[0].ChildNodes[0], result[0]);
    }

    [Fact]
    public void HasSelectorFollowingWithoutRelative()
    {
        var source = @"<div></div><div><p>Hello in a paragraph</p><p>Another paragraph</p></div>";

        var document = source.ToHtmlDocument();
        var selector = "div:has(p + p)";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal(document.Body.ChildNodes[1], result[0]);
    }

    [Fact]
    public void HasSelectorNegated()
    {
        var source = @"<div><section id=first><div><h1></h1></div></section><section id=second></section><section><h5></h5></section></div>";

        var document = source.ToHtmlDocument();
        var selector = "section:not(:has(h1, h2, h3, h4, h5, h6))";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal("second", result[0].Id);
    }

    [Fact]
    public void HasSelectorNegatedSwapped()
    {
        var source = @"<div><section id=first><div><h1></h1></div></section><section id=second></section><section><h5></h5></section></div>";

        var document = source.ToHtmlDocument();
        var selector = "section:has(:not(h1, h2, h3, h4, h5, h6))";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal("first", result[0].Id);
    }

    [InlineData("is")]
    [InlineData("matches")]
    [Theory]
    public void MatchesWithTwoElements(string variant)
    {
        var source = @"<div><h1></h1></div><main><h1></h1></main><section><h1></h1></section><footer><h1></h1></footer>";

        var document = source.ToHtmlDocument();
        var selector = $":{variant}(div, section) > h1";
        var result = document.QuerySelectorAll(selector);
        Assert.Equal(2, result.Length);
        Assert.Equal("h1", result[0].GetTagName());
        Assert.Equal("h1", result[1].GetTagName());
        Assert.Equal("div", result[0].Parent.GetTagName());
        Assert.Equal("section", result[1].Parent.GetTagName());
    }

    [InlineData("is")]
    [InlineData("matches")]
    [Theory]
    public void MatchesWithClasses(string variant)
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = $"span:{variant}(.this, .that)";
        var result = document.QuerySelectorAll(selector);
        Assert.Equal(3, result.Length);
        Assert.Equal("span", result[0].GetTagName());
        Assert.Equal("span", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("this", result[0].ClassName);
        Assert.Equal("that", result[1].ClassName);
        Assert.Equal("this", result[2].ClassName);
        Assert.Equal("3", result[0].TextContent);
        Assert.Equal("5", result[1].TextContent);
        Assert.Equal("6", result[2].TextContent);
    }

    [InlineData("is")]
    [InlineData("matches")]
    [Theory]
    public void MatchesDoubleElements(string variant)
    {
        var source = @"<div><h1></h1></div><article><h2></h2></article><section><h2></h2><article><h3></h3></article></section><aside><h3></h3><h3></h3></aside><nav><div><h4></h4></div></nav>";
        var selector = $@":{variant}(section, article, aside, nav) :{variant}(h1, h2, h3, h4, h5, h6)";
        var equivalent = @"section h1, section h2, section h3, section h4, section h5, section h6,
article h1, article h2, article h3, article h4, article h5, article h6,
aside h1, aside h2, aside h3, aside h4, aside h5, aside h6,
nav h1, nav h2, nav h3, nav h4, nav h5, nav h6";

        var document = source.ToHtmlDocument();
        var actual = document.QuerySelectorAll(selector);
        var expected = document.QuerySelectorAll(equivalent);
        Assert.Equal(6, actual.Length);
        Assert.Equal(expected.Length, actual.Length);

        for (var i = 0; i < 6; i++)
        {
            Assert.Same(expected[i], actual[i]);
        }
    }

    [Fact]
    public void NthChildEvenWorking()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "span:nth-child(even)";
        var result = document.QuerySelectorAll(selector);
        Assert.Equal(3, result.Length);
        Assert.Equal("span", result[0].GetTagName());
        Assert.Equal("span", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("italic", result[0].ClassName);
        Assert.Null(result[1].ClassName);
        Assert.Equal("this", result[2].ClassName);
        Assert.Equal("2", result[0].TextContent);
        Assert.Equal("4", result[1].TextContent);
        Assert.Equal("6", result[2].TextContent);
    }

    [Fact]
    public void NthChildNegativeOffsetLargeSlopeWorking()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "span:nth-child(10n-1) ";
        var result = document.QuerySelectorAll(selector);
        Assert.Empty(result);
    }

    [Fact]
    public void NthChildPositiveOffsetLargeSlopeWorking()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "span:nth-child(10n+1) ";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal("span", result[0].GetTagName());
        Assert.Null(result[0].ClassName);
        Assert.Equal("1", result[0].TextContent);
    }

    [Fact]
    public void NthChildInvalidSelector()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "span:nth-child(10n+-1) ";

        Assert.ThrowsAny<DomException>(() => document.QuerySelectorAll(selector));
    }

    [Fact]
    public void NthChildAllNegativeN()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "*:nth-child(-n+3)";
        var result = document.QuerySelectorAll(selector);
        Assert.Equal(5, result.Length);
        Assert.Equal("head", result[0].GetTagName());
        Assert.Equal("body", result[1].GetTagName());
        Assert.Equal("span", result[2].GetTagName());
        Assert.Equal("span", result[3].GetTagName());
        Assert.Equal("span", result[4].GetTagName());
        Assert.Equal("1", result[2].TextContent);
        Assert.Equal("2", result[3].TextContent);
        Assert.Equal("3", result[4].TextContent);
    }

    [Fact]
    public void NthChildOfSpanThis()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "*:nth-child(-n+3 of span.this)";
        var result = document.QuerySelectorAll(selector);
        Assert.Equal(2, result.Length);
        Assert.Equal("span", result[0].GetTagName());
        Assert.Equal("this", result[0].ClassName);
        Assert.Equal("3", result[0].TextContent);

        Assert.Equal("span", result[1].GetTagName());
        Assert.Equal("this", result[1].ClassName);
        Assert.Equal("6", result[1].TextContent);
    }

    [Fact]
    public void NthChildSpanThisApplied()
    {
        var source = @"<span>1</span><span class=italic>2</span><span class=this>3</span><span>4</span><span class=that>5</span><span class=this>6</span>";

        var document = source.ToHtmlDocument();
        var selector = "span.this:nth-child(-n+3)";
        var result = document.QuerySelectorAll(selector);
        Assert.Single(result);
        Assert.Equal("span", result[0].GetTagName());
        Assert.Equal("this", result[0].ClassName);
        Assert.Equal("3", result[0].TextContent);
    }

    [Fact]
    public void FindDeepElement()
    {
        var count = 10000;
        var doc = string.Empty.ToHtmlDocument();

        var node = (IElement)doc.Body;
        for (var i = 0; i < count; i++)
        {
            var newNode = doc.CreateElement("div");
            node.AppendChild(newNode);
            node = newNode;
        }
        node.AppendChild(doc.CreateElement("a"));

        var result = doc.QuerySelector("a");
        Assert.NotNull(result);
    }

    [Fact]
    public void FindDeepElements()
    {
        var count = 10000;
        var doc = string.Empty.ToHtmlDocument();

        var node = (IElement)doc.Body;
        for (var i = 0; i < count; i++)
        {
            var newNode = doc.CreateElement("div");
            node.AppendChild(newNode);
            node = newNode;
        }
        node.AppendChild(doc.CreateElement("a"));
        node.AppendChild(doc.CreateElement("a"));

        var result = doc.QuerySelectorAll("a");
        Assert.Equal(2, result.Length);
    }

    internal void EmptySelectorShouldThrow()
    {
        var source = @"";

        var document = source.ToHtmlDocument();
        var selector = string.Empty;

        Assert.Throws<DomException>(() => document.QuerySelectorAll(selector));
    }

    [Fact]
    public void CaseInsensitiveSelector_Issue666()
    {
        var source = @"<span style='display: none'>foo</span>";

        var document = source.ToHtmlDocument();
        var hiddens = document.QuerySelectorAll("*[style*='display: none' i],*[style*='display:none' i]");

        Assert.Single(hiddens);
    }

    [Fact]
    public void MaximumRecursionDepth_Issue763()
    {
        var depth = 10000;
        var open = string.Join("", Enumerable.Repeat("<div>", depth));
        var inner = string.Join("", Enumerable.Repeat("<a></a>", depth));
        var close = string.Join("", Enumerable.Repeat("</div", depth));
        var source = $"{open}{inner}{close}";
        var document = source.ToHtmlDocument();
        var result = document.All;
        Assert.Equal(2 * depth + 3, result.Length);
    }

    [Fact]
    public void DivNthChildSelectorUseSelector_Issue835()
    {
        var html = @"<dd>
<span>
    <span>Sub1</span>
</span>
<div>First</div>
<div>
    <div>
        <a>Second</a>
    </div>
</div>
<div>Third</div>
<div>Fourth</div>
<div>
    <span>Fifth</span>
</div>
</dd>";
        var document = html.ToHtmlDocument();
        var link = document.Body.QuerySelector("dd:nth-child(1)>div:nth-child(3)>div:nth-child(1)>a");
        Assert.NotNull(link);
        Assert.Equal("Second", link.TextContent);
    }

    [Fact]
    public void DivNthChildSelectorGetSelector_Issue835()
    {
        var html = @"<dd>
<span>
    <span>Sub1</span>
</span>
<div>First</div>
<div>
    <div>
        <a>Second</a>
    </div>
</div>
<div>Third</div>
<div>Fourth</div>
<div>
    <span>Fifth</span>
</div>
</dd>";
        var document = html.ToHtmlDocument();
        var link = document.Body.QuerySelector("dd:nth-child(1)>div:nth-child(3)>div:nth-child(1)>a");
        var selector = link.GetSelector();
        Assert.Equal("body>dd>div:nth-child(3)>div>a", selector);
    }

    [Fact]
    public void AlwaysCaseInsensitiveInValueOfTypeAttribute_Issue864()
    {
        var html = @"<input type='teXt'>";
        var document = html.ToHtmlDocument();
        var input1 = document.Body.QuerySelector("input[type='text']");
        var input2 = document.Body.QuerySelector("input[type='TEXT']");
        Assert.NotNull(input1);
        Assert.NotNull(input2);
    }

    [Fact]
    public void UsuallyCaseSensitiveInValueOfIdAttribute_Issue864()
    {
        var html = @"<input id='teXt'>";
        var document = html.ToHtmlDocument();
        var input1 = document.Body.QuerySelector("input[id='text']");
        var input2 = document.Body.QuerySelector("input[id='TEXT']");
        Assert.Null(input1);
        Assert.Null(input2);
    }

    [Fact]
    public void GetSelector_Issue910_ShouldReturnUniqueSelectorsForDivAndSpanWithSameId()
    {
        var html = @"<dd>
                        <div id=""first"">First</div>
                        <div>
                            <div id=""second"">
                                <a>Second</a>
                            </div>
                        </div>
                        <span>
                            <span id=""second"">Sub1</span>
                        </span>
                        </dd>";
        var document = html.ToHtmlDocument();

        var bothMatchingElements = document.QuerySelectorAll("#second").ToList();
        Assert.Equal(bothMatchingElements?.Count(), 2);

        var div = bothMatchingElements[0];
        var span = bothMatchingElements[1];
        var divSelector = div.GetSelector();
        var spanSelector = span.GetSelector();

        Assert.NotEqual(spanSelector, divSelector);
        Assert.Equal("body>dd>div:nth-child(2)>div", divSelector);
        Assert.Equal("body>dd>span>span", spanSelector);
    }

    [Fact]
    public void GetSelector_Issue909_DivNumericLeadingDigitIdSelector()
    {
        var html = @"<dd>
                        <span>
                            <span>Sub1</span>
                        </span>
                        <div id=""first"">First</div>
                        <div id=""2nd"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        <div id=""3"">Third</div>
                        <div>Fourth</div>
                        <div>
                            <span>Fifth</span>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();
        var linkParentDiv = document.QuerySelector("[id='2nd']"); //valid css selector
        var selector = linkParentDiv?.GetSelector();

        Assert.Equal("#\\32 nd", selector);
    }

    [Fact]
    public void GetSelector_Issue909_DivNumericLeadingDigitIdChildSelector()
    {
        var html = @"<dd>
                        <span>
                            <span>Sub1</span>
                        </span>
                        <div id=""first"">First</div>
                        <div id=""2nd"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var link = document.QuerySelector("[id='2nd']>div>a");
        var selector = link?.GetSelector();

        Assert.Equal("#\\32 nd>div>a", selector);
    }

    [Fact]
    public void GetSelector_Issue909_DivPlaintextIdTagSelector()
    {
        var html = @"<dd>
                        <span>
                            <span>Sub1</span>
                        </span>
                        <div id=""first"">First</div>
                        <div id=""2nd"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var div = document.QuerySelector("#first");
        var selector = div?.GetSelector();

        Assert.Equal("#first", selector);
    }

    [Fact]
    public void GetSelector_Issue909_DivPlaintextIdAttributeSelector()
    {
        var html = @"<dd>
                        <span>
                            <span>Sub1</span>
                        </span>
                        <div id=""first"">First</div>
                        <div id=""2nd"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var div = document.QuerySelector("[id='first']");
        var selector = div?.GetSelector();

        Assert.Equal("#first", selector);
    }

    // The following characters have a special meaning in CSS: !, ", #, $, %, &, ', (, ), *, +, ,, -, ., /, :, ;, <, =, >, ?, @, [, \, ], ^, `, {, |, }, and ~.
    [Fact] // mathiasbynens.be/notes/css-escapes
    public void GetSelector_Issue909_SomeCharactersNeedToBeEscaped()
    {
        var html = @"<dd>
                        <span id=""something"">
                            <span>Sub1</span>
                        </span>
                        <div id=""some!thing"">First</div>
                        <div id=""some+thing"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var invalidSelectorDiv = document.QuerySelector("#some+thing");
        var validSelectorDiv = document.QuerySelector("[id='some+thing']");

        Assert.Null(invalidSelectorDiv);
        Assert.NotNull(validSelectorDiv);
    }

    [Fact]
    public void GetSelector_Issue909_SpecialCharacterDivIdSelector()
    {
        var html = @"<dd>
                        <span id=""something"">
                            <span>Sub1</span>
                        </span>
                        <div id=""some!thing"">First</div>
                        <div id=""some+thing"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var div = document.QuerySelector("[id='some+thing']");
        var selector = div?.GetSelector();

        Assert.Equal("#some\\+thing", selector);
    }

    [Fact]
    public void GetSelector_Issue909_SpecialCharacterDivIdChildSelector()
    {
        var html = @"<dd>
                        <span id=""something"">
                            <span>Sub1</span>
                        </span>
                        <div id=""some!thing"">First</div>
                        <div id=""some+thing"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var link = document.QuerySelector(@"[id='some+thing']>div>a");
        var selector = link?.GetSelector();

        Assert.Equal("#some\\+thing>div>a", selector);
    }

    [Fact]
    public void GetSelector_Issue909_SpecialCharacterDivIdExclaim()
    {
        var html = @"<dd>
                        <span id=""something"">
                            <span>Sub1</span>
                        </span>
                        <div id=""some!thing"">First</div>
                        <div id=""some+thing"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var div = document.QuerySelector(@"[id='some!thing']");
        var selector = div?.GetSelector();

        Assert.Equal("#some\\!thing", selector);
    }

    [Fact]
    public void GetSelector_Issue909_SpecialCharacterDivIdNegativeNumber()
    {
        var html = @"<dd>
                        <span id=""something"">
                            <span>Sub1</span>
                        </span>
                        <div id=""1"">First</div>
                        <div id=""-1"">
                            <div>
                                <a>Second</a>
                            </div>
                        </div>
                        </dd>";
        var document = html.ToHtmlDocument();

        var div = document.QuerySelector(@"[id='-1']");
        var selector = div?.GetSelector();

        Assert.Equal("#-\\31 ", selector);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_ClassSelector()
    {
        var selectorText = @".\@\$\!\.\%";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<ClassSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_IdSelector()
    {
        var selectorText = @"#\@\$\!\.\%";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<IdSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_AttrAvailableSelector()
    {
        var selectorText = @"[\@\$\!\.\%]";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<AttrAvailableSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_AttrMatchSelector()
    {
        var selectorText = @"[\@\$\!\.\%=""some text""]";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<AttrMatchSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_AttrContainsSelector()
    {
        var selectorText = @"[\@\$\!\.\%*=""some text""]";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<AttrContainsSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_AttrInListSelector()
    {
        var selectorText = @"[\@\$\!\.\%~=""some text""]";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<AttrInListSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [Fact]
    public void SelectorText_EscapeCssSpecialCharacters_NamespaceSelector()
    {
        var selectorText = @"\@\$\!\.\%|node";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        Assert.IsAssignableFrom<ComplexSelector>(selector);
        Assert.NotNull(selector);
        Assert.Equal(selectorText, selector.Text);
    }

    [InlineData("nth-child")]
    [InlineData("nth-last-child")]
    [Theory]
    public void PseudoClassSpecificityExceptions_NthChild_ContributesSpecificity(string pseudoClass)
    {
        var selectorText = $@"foo:{pseudoClass}(even of .bar, #bar)";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 1, 1, 1);

        Assert.Equal(expected, selector.Specificity);
    }

    [InlineData("nth-child")]
    [InlineData("nth-last-child")]
    [Theory]
    public void PseudoClassSpecificityExceptions_EmptyNthChild_ContributesSingleClassSpecificity(string pseudoClass)
    {
        var selectorText = $@"foo:{pseudoClass}(even)";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 0, 1, 1);

        Assert.Equal(expected, selector.Specificity);
    }

    [InlineData("has")]
    [InlineData("matches")]
    [InlineData("is")]
    [InlineData("not")]
    [Theory]
    public void PseudoClassSpecificityExceptions_Matchers_ContributesSpecificity(string pseudoClass)
    {
        var selectorText = $@"foo:{pseudoClass}(.bar, #bar)";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 1, 0, 1);

        Assert.Equal(expected, selector.Specificity);
    }

    [Fact]
    public void PseudoClassSpecificityExceptions_Where_DoesNotContributeSpecificity()
    {
        var selectorText = $@"foo:where(.bar, #bar)";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 0, 0, 1);

        Assert.Equal("foo:where(.bar, #bar)", selector.Text);
        Assert.Equal(expected, selector.Specificity);
    }

    [Fact]
    public void PseudoClassFocusVisible_Issue1121()
    {
        var selectorText = $@"foo:focus-visible";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 0, 1, 1);

        Assert.Equal("foo:focus-visible", selector.Text);
        Assert.Equal(expected, selector.Specificity);
    }

    [Fact]
    public void PseudoClassFocusWithin_Issue1121()
    {
        var selectorText = $@"foo:focus-within";
        var parser = new CssSelectorParser();

        var selector = parser.ParseSelector(selectorText);

        var expected = new Priority(0, 0, 1, 1);

        Assert.Equal("foo:focus-within", selector.Text);
        Assert.Equal(expected, selector.Specificity);
    }
}
