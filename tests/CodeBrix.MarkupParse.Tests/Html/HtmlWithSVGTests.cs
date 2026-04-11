using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests10.dat
/// tree-construction/tests11.dat
/// </summary>

public class HtmlWithSVGTests
{
    [Fact]
    public void SvgCheckAttributesCaseNormalUnchanged()
    {
        var doc = (@"<!DOCTYPE html><body><svg attributeName='' attributeType='' baseFrequency='' baseProfile='' calcMode='' clipPathUnits='' contentScriptType='' contentStyleType='' diffuseConstant='' edgeMode='' externalResourcesRequired='' filterRes='' filterUnits='' glyphRef='' gradientTransform='' gradientUnits='' kernelMatrix='' kernelUnitLength='' keyPoints='' keySplines='' keyTimes='' lengthAdjust='' limitingConeAngle='' markerHeight='' markerUnits='' markerWidth='' maskContentUnits='' maskUnits='' numOctaves='' pathLength='' patternContentUnits='' patternTransform='' patternUnits='' pointsAtX='' pointsAtY='' pointsAtZ='' preserveAlpha='' preserveAspectRatio='' primitiveUnits='' refX='' refY='' repeatCount='' repeatDur='' requiredExtensions='' requiredFeatures='' specularConstant='' specularExponent='' spreadMethod='' startOffset='' stdDeviation='' stitchTiles='' surfaceScale='' systemLanguage='' tableValues='' targetX='' targetY='' textLength='' viewBox='' viewTarget='' xChannelSelector='' yChannelSelector='' zoomAndPan=''></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Equal(62, dochtml1body1svg0.Attributes.Length);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeName"));
        Assert.Equal("attributeName", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeType"));
        Assert.Equal("attributeType", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency"));
        Assert.Equal("baseFrequency", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseProfile"));
        Assert.Equal("baseProfile", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("calcMode"));
        Assert.Equal("calcMode", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits"));
        Assert.Equal("clipPathUnits", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType"));
        Assert.Equal("contentScriptType", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType"));
        Assert.Equal("contentStyleType", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant"));
        Assert.Equal("diffuseConstant", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("edgeMode"));
        Assert.Equal("edgeMode", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired"));
        Assert.Equal("externalResourcesRequired", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterRes"));
        Assert.Equal("filterRes", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterUnits"));
        Assert.Equal("filterUnits", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("glyphRef"));
        Assert.Equal("glyphRef", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform"));
        Assert.Equal("gradientTransform", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits"));
        Assert.Equal("gradientUnits", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix"));
        Assert.Equal("kernelMatrix", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength"));
        Assert.Equal("kernelUnitLength", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyPoints"));
        Assert.Equal("keyPoints", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keySplines"));
        Assert.Equal("keySplines", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyTimes"));
        Assert.Equal("keyTimes", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust"));
        Assert.Equal("lengthAdjust", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle"));
        Assert.Equal("limitingConeAngle", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerHeight"));
        Assert.Equal("markerHeight", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerUnits"));
        Assert.Equal("markerUnits", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerWidth"));
        Assert.Equal("markerWidth", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits"));
        Assert.Equal("maskContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskUnits"));
        Assert.Equal("maskUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("numOctaves"));
        Assert.Equal("numOctaves", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pathLength"));
        Assert.Equal("pathLength", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits"));
        Assert.Equal("patternContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternTransform"));
        Assert.Equal("patternTransform", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternUnits"));
        Assert.Equal("patternUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX"));
        Assert.Equal("pointsAtX", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY"));
        Assert.Equal("pointsAtY", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ"));
        Assert.Equal("pointsAtZ", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha"));
        Assert.Equal("preserveAlpha", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio"));
        Assert.Equal("preserveAspectRatio", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits"));
        Assert.Equal("primitiveUnits", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refX"));
        Assert.Equal("refX", dochtml1body1svg0.Attributes.GetNamedItem("refX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refY"));
        Assert.Equal("refY", dochtml1body1svg0.Attributes.GetNamedItem("refY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatCount"));
        Assert.Equal("repeatCount", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatDur"));
        Assert.Equal("repeatDur", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions"));
        Assert.Equal("requiredExtensions", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures"));
        Assert.Equal("requiredFeatures", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularConstant"));
        Assert.Equal("specularConstant", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularExponent"));
        Assert.Equal("specularExponent", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod"));
        Assert.Equal("spreadMethod", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("startOffset"));
        Assert.Equal("startOffset", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation"));
        Assert.Equal("stdDeviation", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles"));
        Assert.Equal("stitchTiles", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale"));
        Assert.Equal("surfaceScale", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage"));
        Assert.Equal("systemLanguage", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("tableValues"));
        Assert.Equal("tableValues", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetX"));
        Assert.Equal("targetX", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetY"));
        Assert.Equal("targetY", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("textLength"));
        Assert.Equal("textLength", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewBox"));
        Assert.Equal("viewBox", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewTarget"));
        Assert.Equal("viewTarget", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector"));
        Assert.Equal("xChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector"));
        Assert.Equal("yChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan"));
        Assert.Equal("zoomAndPan", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Value);
    }

    [Fact]
    public void SvgCheckAttributesCaseUppercaseModified()
    {
        var doc = (@"<!DOCTYPE html><BODY><SVG ATTRIBUTENAME='' ATTRIBUTETYPE='' BASEFREQUENCY='' BASEPROFILE='' CALCMODE='' CLIPPATHUNITS='' CONTENTSCRIPTTYPE='' CONTENTSTYLETYPE='' DIFFUSECONSTANT='' EDGEMODE='' EXTERNALRESOURCESREQUIRED='' FILTERRES='' FILTERUNITS='' GLYPHREF='' GRADIENTTRANSFORM='' GRADIENTUNITS='' KERNELMATRIX='' KERNELUNITLENGTH='' KEYPOINTS='' KEYSPLINES='' KEYTIMES='' LENGTHADJUST='' LIMITINGCONEANGLE='' MARKERHEIGHT='' MARKERUNITS='' MARKERWIDTH='' MASKCONTENTUNITS='' MASKUNITS='' NUMOCTAVES='' PATHLENGTH='' PATTERNCONTENTUNITS='' PATTERNTRANSFORM='' PATTERNUNITS='' POINTSATX='' POINTSATY='' POINTSATZ='' PRESERVEALPHA='' PRESERVEASPECTRATIO='' PRIMITIVEUNITS='' REFX='' REFY='' REPEATCOUNT='' REPEATDUR='' REQUIREDEXTENSIONS='' REQUIREDFEATURES='' SPECULARCONSTANT='' SPECULAREXPONENT='' SPREADMETHOD='' STARTOFFSET='' STDDEVIATION='' STITCHTILES='' SURFACESCALE='' SYSTEMLANGUAGE='' TABLEVALUES='' TARGETX='' TARGETY='' TEXTLENGTH='' VIEWBOX='' VIEWTARGET='' XCHANNELSELECTOR='' YCHANNELSELECTOR='' ZOOMANDPAN=''></SVG>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Equal(62, dochtml1body1svg0.Attributes.Length);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeName"));
        Assert.Equal("attributeName", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeType"));
        Assert.Equal("attributeType", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency"));
        Assert.Equal("baseFrequency", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseProfile"));
        Assert.Equal("baseProfile", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("calcMode"));
        Assert.Equal("calcMode", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits"));
        Assert.Equal("clipPathUnits", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType"));
        Assert.Equal("contentScriptType", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType"));
        Assert.Equal("contentStyleType", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant"));
        Assert.Equal("diffuseConstant", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("edgeMode"));
        Assert.Equal("edgeMode", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired"));
        Assert.Equal("externalResourcesRequired", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterRes"));
        Assert.Equal("filterRes", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterUnits"));
        Assert.Equal("filterUnits", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("glyphRef"));
        Assert.Equal("glyphRef", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform"));
        Assert.Equal("gradientTransform", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits"));
        Assert.Equal("gradientUnits", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix"));
        Assert.Equal("kernelMatrix", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength"));
        Assert.Equal("kernelUnitLength", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyPoints"));
        Assert.Equal("keyPoints", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keySplines"));
        Assert.Equal("keySplines", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyTimes"));
        Assert.Equal("keyTimes", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust"));
        Assert.Equal("lengthAdjust", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle"));
        Assert.Equal("limitingConeAngle", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerHeight"));
        Assert.Equal("markerHeight", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerUnits"));
        Assert.Equal("markerUnits", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerWidth"));
        Assert.Equal("markerWidth", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits"));
        Assert.Equal("maskContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskUnits"));
        Assert.Equal("maskUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("numOctaves"));
        Assert.Equal("numOctaves", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pathLength"));
        Assert.Equal("pathLength", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits"));
        Assert.Equal("patternContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternTransform"));
        Assert.Equal("patternTransform", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternUnits"));
        Assert.Equal("patternUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX"));
        Assert.Equal("pointsAtX", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY"));
        Assert.Equal("pointsAtY", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ"));
        Assert.Equal("pointsAtZ", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha"));
        Assert.Equal("preserveAlpha", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio"));
        Assert.Equal("preserveAspectRatio", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits"));
        Assert.Equal("primitiveUnits", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refX"));
        Assert.Equal("refX", dochtml1body1svg0.Attributes.GetNamedItem("refX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refY"));
        Assert.Equal("refY", dochtml1body1svg0.Attributes.GetNamedItem("refY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatCount"));
        Assert.Equal("repeatCount", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatDur"));
        Assert.Equal("repeatDur", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions"));
        Assert.Equal("requiredExtensions", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures"));
        Assert.Equal("requiredFeatures", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularConstant"));
        Assert.Equal("specularConstant", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularExponent"));
        Assert.Equal("specularExponent", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod"));
        Assert.Equal("spreadMethod", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("startOffset"));
        Assert.Equal("startOffset", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation"));
        Assert.Equal("stdDeviation", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles"));
        Assert.Equal("stitchTiles", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale"));
        Assert.Equal("surfaceScale", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage"));
        Assert.Equal("systemLanguage", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("tableValues"));
        Assert.Equal("tableValues", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetX"));
        Assert.Equal("targetX", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetY"));
        Assert.Equal("targetY", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("textLength"));
        Assert.Equal("textLength", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewBox"));
        Assert.Equal("viewBox", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewTarget"));
        Assert.Equal("viewTarget", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector"));
        Assert.Equal("xChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector"));
        Assert.Equal("yChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan"));
        Assert.Equal("zoomAndPan", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Value);
    }

    [Fact]
    public void SvgCheckAttributesCaseLowercaseModified()
    {
        var doc = (@"<!DOCTYPE html><body><svg attributename='' attributetype='' basefrequency='' baseprofile='' calcmode='' clippathunits='' contentscripttype='' contentstyletype='' diffuseconstant='' edgemode='' externalresourcesrequired='' filterres='' filterunits='' glyphref='' gradienttransform='' gradientunits='' kernelmatrix='' kernelunitlength='' keypoints='' keysplines='' keytimes='' lengthadjust='' limitingconeangle='' markerheight='' markerunits='' markerwidth='' maskcontentunits='' maskunits='' numoctaves='' pathlength='' patterncontentunits='' patterntransform='' patternunits='' pointsatx='' pointsaty='' pointsatz='' preservealpha='' preserveaspectratio='' primitiveunits='' refx='' refy='' repeatcount='' repeatdur='' requiredextensions='' requiredfeatures='' specularconstant='' specularexponent='' spreadmethod='' startoffset='' stddeviation='' stitchtiles='' surfacescale='' systemlanguage='' tablevalues='' targetx='' targety='' textlength='' viewbox='' viewtarget='' xchannelselector='' ychannelselector='' zoomandpan=''></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Equal(62, dochtml1body1svg0.Attributes.Length);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeName"));
        Assert.Equal("attributeName", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeName").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("attributeType"));
        Assert.Equal("attributeType", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("attributeType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency"));
        Assert.Equal("baseFrequency", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseFrequency").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("baseProfile"));
        Assert.Equal("baseProfile", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("baseProfile").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("calcMode"));
        Assert.Equal("calcMode", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("calcMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits"));
        Assert.Equal("clipPathUnits", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("clipPathUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType"));
        Assert.Equal("contentScriptType", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentScriptType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType"));
        Assert.Equal("contentStyleType", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("contentStyleType").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant"));
        Assert.Equal("diffuseConstant", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("diffuseConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("edgeMode"));
        Assert.Equal("edgeMode", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("edgeMode").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired"));
        Assert.Equal("externalResourcesRequired", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("externalResourcesRequired").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterRes"));
        Assert.Equal("filterRes", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterRes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("filterUnits"));
        Assert.Equal("filterUnits", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("filterUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("glyphRef"));
        Assert.Equal("glyphRef", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("glyphRef").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform"));
        Assert.Equal("gradientTransform", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits"));
        Assert.Equal("gradientUnits", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("gradientUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix"));
        Assert.Equal("kernelMatrix", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelMatrix").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength"));
        Assert.Equal("kernelUnitLength", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("kernelUnitLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyPoints"));
        Assert.Equal("keyPoints", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyPoints").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keySplines"));
        Assert.Equal("keySplines", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keySplines").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("keyTimes"));
        Assert.Equal("keyTimes", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("keyTimes").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust"));
        Assert.Equal("lengthAdjust", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("lengthAdjust").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle"));
        Assert.Equal("limitingConeAngle", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("limitingConeAngle").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerHeight"));
        Assert.Equal("markerHeight", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerHeight").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerUnits"));
        Assert.Equal("markerUnits", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("markerWidth"));
        Assert.Equal("markerWidth", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("markerWidth").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits"));
        Assert.Equal("maskContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("maskUnits"));
        Assert.Equal("maskUnits", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("maskUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("numOctaves"));
        Assert.Equal("numOctaves", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("numOctaves").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pathLength"));
        Assert.Equal("pathLength", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pathLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits"));
        Assert.Equal("patternContentUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternContentUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternTransform"));
        Assert.Equal("patternTransform", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternTransform").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("patternUnits"));
        Assert.Equal("patternUnits", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("patternUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX"));
        Assert.Equal("pointsAtX", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY"));
        Assert.Equal("pointsAtY", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ"));
        Assert.Equal("pointsAtZ", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("pointsAtZ").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha"));
        Assert.Equal("preserveAlpha", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAlpha").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio"));
        Assert.Equal("preserveAspectRatio", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("preserveAspectRatio").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits"));
        Assert.Equal("primitiveUnits", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("primitiveUnits").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refX"));
        Assert.Equal("refX", dochtml1body1svg0.Attributes.GetNamedItem("refX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("refY"));
        Assert.Equal("refY", dochtml1body1svg0.Attributes.GetNamedItem("refY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("refY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatCount"));
        Assert.Equal("repeatCount", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatCount").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("repeatDur"));
        Assert.Equal("repeatDur", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("repeatDur").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions"));
        Assert.Equal("requiredExtensions", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredExtensions").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures"));
        Assert.Equal("requiredFeatures", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("requiredFeatures").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularConstant"));
        Assert.Equal("specularConstant", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularConstant").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("specularExponent"));
        Assert.Equal("specularExponent", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("specularExponent").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod"));
        Assert.Equal("spreadMethod", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("spreadMethod").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("startOffset"));
        Assert.Equal("startOffset", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("startOffset").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation"));
        Assert.Equal("stdDeviation", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stdDeviation").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles"));
        Assert.Equal("stitchTiles", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("stitchTiles").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale"));
        Assert.Equal("surfaceScale", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("surfaceScale").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage"));
        Assert.Equal("systemLanguage", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("systemLanguage").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("tableValues"));
        Assert.Equal("tableValues", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("tableValues").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetX"));
        Assert.Equal("targetX", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetX").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("targetY"));
        Assert.Equal("targetY", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("targetY").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("textLength"));
        Assert.Equal("textLength", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("textLength").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewBox"));
        Assert.Equal("viewBox", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewBox").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("viewTarget"));
        Assert.Equal("viewTarget", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("viewTarget").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector"));
        Assert.Equal("xChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("xChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector"));
        Assert.Equal("yChannelSelector", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("yChannelSelector").Value);
        Assert.NotNull(dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan"));
        Assert.Equal("zoomAndPan", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Name);
        Assert.Equal("", dochtml1body1svg0.Attributes.GetNamedItem("zoomAndPan").Value);

    }

    [Fact]
    public void SvgCheckTagCaseNormalUnchanged()
    {
        var doc = (@"<!DOCTYPE html><body><svg><altGlyph /><altGlyphDef /><altGlyphItem /><animateColor /><animateMotion /><animateTransform /><clipPath /><feBlend /><feColorMatrix /><feComponentTransfer /><feComposite /><feConvolveMatrix /><feDiffuseLighting /><feDisplacementMap /><feDistantLight /><feFlood /><feFuncA /><feFuncB /><feFuncG /><feFuncR /><feGaussianBlur /><feImage /><feMerge /><feMergeNode /><feMorphology /><feOffset /><fePointLight /><feSpecularLighting /><feSpotLight /><feTile /><feTurbulence /><foreignObject /><glyphRef /><linearGradient /><radialGradient /><textPath /></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(36, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0altGlyph0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0altGlyph0.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyph0.Attributes);
        Assert.Equal("altGlyph", dochtml1body1svg0altGlyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyph0.NodeType);

        var dochtml1body1svg0altGlyphDef1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphDef1.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphDef1.Attributes);
        Assert.Equal("altGlyphDef", dochtml1body1svg0altGlyphDef1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphDef1.NodeType);

        var dochtml1body1svg0altGlyphItem2 = dochtml1body1svg0.ChildNodes[2] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphItem2.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphItem2.Attributes);
        Assert.Equal("altGlyphItem", dochtml1body1svg0altGlyphItem2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphItem2.NodeType);

        var dochtml1body1svg0animateColor3 = dochtml1body1svg0.ChildNodes[3] as Element;
        Assert.Empty(dochtml1body1svg0animateColor3.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateColor3.Attributes);
        Assert.Equal("animateColor", dochtml1body1svg0animateColor3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateColor3.NodeType);

        var dochtml1body1svg0animateMotion4 = dochtml1body1svg0.ChildNodes[4] as Element;
        Assert.Empty(dochtml1body1svg0animateMotion4.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateMotion4.Attributes);
        Assert.Equal("animateMotion", dochtml1body1svg0animateMotion4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateMotion4.NodeType);

        var dochtml1body1svg0animateTransform5 = dochtml1body1svg0.ChildNodes[5] as Element;
        Assert.Empty(dochtml1body1svg0animateTransform5.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateTransform5.Attributes);
        Assert.Equal("animateTransform", dochtml1body1svg0animateTransform5.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateTransform5.NodeType);

        var dochtml1body1svg0clipPath6 = dochtml1body1svg0.ChildNodes[6] as Element;
        Assert.Empty(dochtml1body1svg0clipPath6.ChildNodes);
        Assert.Empty(dochtml1body1svg0clipPath6.Attributes);
        Assert.Equal("clipPath", dochtml1body1svg0clipPath6.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0clipPath6.NodeType);

        var dochtml1body1svg0feBlend7 = dochtml1body1svg0.ChildNodes[7] as Element;
        Assert.Empty(dochtml1body1svg0feBlend7.ChildNodes);
        Assert.Empty(dochtml1body1svg0feBlend7.Attributes);
        Assert.Equal("feBlend", dochtml1body1svg0feBlend7.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feBlend7.NodeType);

        var dochtml1body1svg0feColorMatrix8 = dochtml1body1svg0.ChildNodes[8] as Element;
        Assert.Empty(dochtml1body1svg0feColorMatrix8.ChildNodes);
        Assert.Empty(dochtml1body1svg0feColorMatrix8.Attributes);
        Assert.Equal("feColorMatrix", dochtml1body1svg0feColorMatrix8.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feColorMatrix8.NodeType);

        var dochtml1body1svg0feComponentTransfer9 = dochtml1body1svg0.ChildNodes[9] as Element;
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.Attributes);
        Assert.Equal("feComponentTransfer", dochtml1body1svg0feComponentTransfer9.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComponentTransfer9.NodeType);

        var dochtml1body1svg0feComposite10 = dochtml1body1svg0.ChildNodes[10] as Element;
        Assert.Empty(dochtml1body1svg0feComposite10.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComposite10.Attributes);
        Assert.Equal("feComposite", dochtml1body1svg0feComposite10.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComposite10.NodeType);

        var dochtml1body1svg0feConvolveMatrix11 = dochtml1body1svg0.ChildNodes[11] as Element;
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.ChildNodes);
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.Attributes);
        Assert.Equal("feConvolveMatrix", dochtml1body1svg0feConvolveMatrix11.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feConvolveMatrix11.NodeType);

        var dochtml1body1svg0feDiffuseLighting12 = dochtml1body1svg0.ChildNodes[12] as Element;
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.Attributes);
        Assert.Equal("feDiffuseLighting", dochtml1body1svg0feDiffuseLighting12.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDiffuseLighting12.NodeType);

        var dochtml1body1svg0feDisplacementMap13 = dochtml1body1svg0.ChildNodes[13] as Element;
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.Attributes);
        Assert.Equal("feDisplacementMap", dochtml1body1svg0feDisplacementMap13.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDisplacementMap13.NodeType);

        var dochtml1body1svg0feDistantLight14 = dochtml1body1svg0.ChildNodes[14] as Element;
        Assert.Empty(dochtml1body1svg0feDistantLight14.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDistantLight14.Attributes);
        Assert.Equal("feDistantLight", dochtml1body1svg0feDistantLight14.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDistantLight14.NodeType);

        var dochtml1body1svg0feFlood15 = dochtml1body1svg0.ChildNodes[15] as Element;
        Assert.Empty(dochtml1body1svg0feFlood15.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFlood15.Attributes);
        Assert.Equal("feFlood", dochtml1body1svg0feFlood15.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFlood15.NodeType);

        var dochtml1body1svg0feFuncA16 = dochtml1body1svg0.ChildNodes[16] as Element;
        Assert.Empty(dochtml1body1svg0feFuncA16.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncA16.Attributes);
        Assert.Equal("feFuncA", dochtml1body1svg0feFuncA16.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncA16.NodeType);

        var dochtml1body1svg0feFuncB17 = dochtml1body1svg0.ChildNodes[17] as Element;
        Assert.Empty(dochtml1body1svg0feFuncB17.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncB17.Attributes);
        Assert.Equal("feFuncB", dochtml1body1svg0feFuncB17.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncB17.NodeType);

        var dochtml1body1svg0feFuncG18 = dochtml1body1svg0.ChildNodes[18] as Element;
        Assert.Empty(dochtml1body1svg0feFuncG18.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncG18.Attributes);
        Assert.Equal("feFuncG", dochtml1body1svg0feFuncG18.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncG18.NodeType);

        var dochtml1body1svg0feFuncR19 = dochtml1body1svg0.ChildNodes[19] as Element;
        Assert.Empty(dochtml1body1svg0feFuncR19.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncR19.Attributes);
        Assert.Equal("feFuncR", dochtml1body1svg0feFuncR19.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncR19.NodeType);

        var dochtml1body1svg0feGaussianBlur20 = dochtml1body1svg0.ChildNodes[20] as Element;
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.ChildNodes);
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.Attributes);
        Assert.Equal("feGaussianBlur", dochtml1body1svg0feGaussianBlur20.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feGaussianBlur20.NodeType);

        var dochtml1body1svg0feImage21 = dochtml1body1svg0.ChildNodes[21] as Element;
        Assert.Empty(dochtml1body1svg0feImage21.ChildNodes);
        Assert.Empty(dochtml1body1svg0feImage21.Attributes);
        Assert.Equal("feImage", dochtml1body1svg0feImage21.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feImage21.NodeType);

        var dochtml1body1svg0feMerge22 = dochtml1body1svg0.ChildNodes[22] as Element;
        Assert.Empty(dochtml1body1svg0feMerge22.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMerge22.Attributes);
        Assert.Equal("feMerge", dochtml1body1svg0feMerge22.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMerge22.NodeType);

        var dochtml1body1svg0feMergeNode23 = dochtml1body1svg0.ChildNodes[23] as Element;
        Assert.Empty(dochtml1body1svg0feMergeNode23.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMergeNode23.Attributes);
        Assert.Equal("feMergeNode", dochtml1body1svg0feMergeNode23.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMergeNode23.NodeType);

        var dochtml1body1svg0feMorphology24 = dochtml1body1svg0.ChildNodes[24] as Element;
        Assert.Empty(dochtml1body1svg0feMorphology24.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMorphology24.Attributes);
        Assert.Equal("feMorphology", dochtml1body1svg0feMorphology24.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMorphology24.NodeType);

        var dochtml1body1svg0feOffset25 = dochtml1body1svg0.ChildNodes[25] as Element;
        Assert.Empty(dochtml1body1svg0feOffset25.ChildNodes);
        Assert.Empty(dochtml1body1svg0feOffset25.Attributes);
        Assert.Equal("feOffset", dochtml1body1svg0feOffset25.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feOffset25.NodeType);

        var dochtml1body1svg0fePointLight26 = dochtml1body1svg0.ChildNodes[26] as Element;
        Assert.Empty(dochtml1body1svg0fePointLight26.ChildNodes);
        Assert.Empty(dochtml1body1svg0fePointLight26.Attributes);
        Assert.Equal("fePointLight", dochtml1body1svg0fePointLight26.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0fePointLight26.NodeType);

        var dochtml1body1svg0feSpecularLighting27 = dochtml1body1svg0.ChildNodes[27] as Element;
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.Attributes);
        Assert.Equal("feSpecularLighting", dochtml1body1svg0feSpecularLighting27.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpecularLighting27.NodeType);

        var dochtml1body1svg0feSpotLight28 = dochtml1body1svg0.ChildNodes[28] as Element;
        Assert.Empty(dochtml1body1svg0feSpotLight28.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpotLight28.Attributes);
        Assert.Equal("feSpotLight", dochtml1body1svg0feSpotLight28.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpotLight28.NodeType);

        var dochtml1body1svg0feTile29 = dochtml1body1svg0.ChildNodes[29] as Element;
        Assert.Empty(dochtml1body1svg0feTile29.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTile29.Attributes);
        Assert.Equal("feTile", dochtml1body1svg0feTile29.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTile29.NodeType);

        var dochtml1body1svg0feTurbulence30 = dochtml1body1svg0.ChildNodes[30] as Element;
        Assert.Empty(dochtml1body1svg0feTurbulence30.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTurbulence30.Attributes);
        Assert.Equal("feTurbulence", dochtml1body1svg0feTurbulence30.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTurbulence30.NodeType);

        var dochtml1body1svg0foreignObject31 = dochtml1body1svg0.ChildNodes[31] as Element;
        Assert.Empty(dochtml1body1svg0foreignObject31.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject31.Attributes);
        Assert.Equal("foreignObject", dochtml1body1svg0foreignObject31.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject31.NodeType);

        var dochtml1body1svg0glyphRef32 = dochtml1body1svg0.ChildNodes[32] as Element;
        Assert.Empty(dochtml1body1svg0glyphRef32.ChildNodes);
        Assert.Empty(dochtml1body1svg0glyphRef32.Attributes);
        Assert.Equal("glyphRef", dochtml1body1svg0glyphRef32.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0glyphRef32.NodeType);

        var dochtml1body1svg0linearGradient33 = dochtml1body1svg0.ChildNodes[33] as Element;
        Assert.Empty(dochtml1body1svg0linearGradient33.ChildNodes);
        Assert.Empty(dochtml1body1svg0linearGradient33.Attributes);
        Assert.Equal("linearGradient", dochtml1body1svg0linearGradient33.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0linearGradient33.NodeType);

        var dochtml1body1svg0radialGradient34 = dochtml1body1svg0.ChildNodes[34] as Element;
        Assert.Empty(dochtml1body1svg0radialGradient34.ChildNodes);
        Assert.Empty(dochtml1body1svg0radialGradient34.Attributes);
        Assert.Equal("radialGradient", dochtml1body1svg0radialGradient34.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0radialGradient34.NodeType);

        var dochtml1body1svg0textPath35 = dochtml1body1svg0.ChildNodes[35] as Element;
        Assert.Empty(dochtml1body1svg0textPath35.ChildNodes);
        Assert.Empty(dochtml1body1svg0textPath35.Attributes);
        Assert.Equal("textPath", dochtml1body1svg0textPath35.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0textPath35.NodeType);
    }

    [Fact]
    public void SvgCheckTagCaseLowercaseModified()
    {
        var doc = (@"<!DOCTYPE html><body><svg><altglyph /><altglyphdef /><altglyphitem /><animatecolor /><animatemotion /><animatetransform /><clippath /><feblend /><fecolormatrix /><fecomponenttransfer /><fecomposite /><feconvolvematrix /><fediffuselighting /><fedisplacementmap /><fedistantlight /><feflood /><fefunca /><fefuncb /><fefuncg /><fefuncr /><fegaussianblur /><feimage /><femerge /><femergenode /><femorphology /><feoffset /><fepointlight /><fespecularlighting /><fespotlight /><fetile /><feturbulence /><foreignobject /><glyphref /><lineargradient /><radialgradient /><textpath /></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(36, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0altGlyph0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0altGlyph0.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyph0.Attributes);
        Assert.Equal("altGlyph", dochtml1body1svg0altGlyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyph0.NodeType);

        var dochtml1body1svg0altGlyphDef1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphDef1.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphDef1.Attributes);
        Assert.Equal("altGlyphDef", dochtml1body1svg0altGlyphDef1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphDef1.NodeType);

        var dochtml1body1svg0altGlyphItem2 = dochtml1body1svg0.ChildNodes[2] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphItem2.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphItem2.Attributes);
        Assert.Equal("altGlyphItem", dochtml1body1svg0altGlyphItem2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphItem2.NodeType);

        var dochtml1body1svg0animateColor3 = dochtml1body1svg0.ChildNodes[3] as Element;
        Assert.Empty(dochtml1body1svg0animateColor3.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateColor3.Attributes);
        Assert.Equal("animateColor", dochtml1body1svg0animateColor3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateColor3.NodeType);

        var dochtml1body1svg0animateMotion4 = dochtml1body1svg0.ChildNodes[4] as Element;
        Assert.Empty(dochtml1body1svg0animateMotion4.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateMotion4.Attributes);
        Assert.Equal("animateMotion", dochtml1body1svg0animateMotion4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateMotion4.NodeType);

        var dochtml1body1svg0animateTransform5 = dochtml1body1svg0.ChildNodes[5] as Element;
        Assert.Empty(dochtml1body1svg0animateTransform5.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateTransform5.Attributes);
        Assert.Equal("animateTransform", dochtml1body1svg0animateTransform5.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateTransform5.NodeType);

        var dochtml1body1svg0clipPath6 = dochtml1body1svg0.ChildNodes[6] as Element;
        Assert.Empty(dochtml1body1svg0clipPath6.ChildNodes);
        Assert.Empty(dochtml1body1svg0clipPath6.Attributes);
        Assert.Equal("clipPath", dochtml1body1svg0clipPath6.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0clipPath6.NodeType);

        var dochtml1body1svg0feBlend7 = dochtml1body1svg0.ChildNodes[7] as Element;
        Assert.Empty(dochtml1body1svg0feBlend7.ChildNodes);
        Assert.Empty(dochtml1body1svg0feBlend7.Attributes);
        Assert.Equal("feBlend", dochtml1body1svg0feBlend7.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feBlend7.NodeType);

        var dochtml1body1svg0feColorMatrix8 = dochtml1body1svg0.ChildNodes[8] as Element;
        Assert.Empty(dochtml1body1svg0feColorMatrix8.ChildNodes);
        Assert.Empty(dochtml1body1svg0feColorMatrix8.Attributes);
        Assert.Equal("feColorMatrix", dochtml1body1svg0feColorMatrix8.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feColorMatrix8.NodeType);

        var dochtml1body1svg0feComponentTransfer9 = dochtml1body1svg0.ChildNodes[9] as Element;
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.Attributes);
        Assert.Equal("feComponentTransfer", dochtml1body1svg0feComponentTransfer9.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComponentTransfer9.NodeType);

        var dochtml1body1svg0feComposite10 = dochtml1body1svg0.ChildNodes[10] as Element;
        Assert.Empty(dochtml1body1svg0feComposite10.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComposite10.Attributes);
        Assert.Equal("feComposite", dochtml1body1svg0feComposite10.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComposite10.NodeType);

        var dochtml1body1svg0feConvolveMatrix11 = dochtml1body1svg0.ChildNodes[11] as Element;
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.ChildNodes);
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.Attributes);
        Assert.Equal("feConvolveMatrix", dochtml1body1svg0feConvolveMatrix11.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feConvolveMatrix11.NodeType);

        var dochtml1body1svg0feDiffuseLighting12 = dochtml1body1svg0.ChildNodes[12] as Element;
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.Attributes);
        Assert.Equal("feDiffuseLighting", dochtml1body1svg0feDiffuseLighting12.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDiffuseLighting12.NodeType);

        var dochtml1body1svg0feDisplacementMap13 = dochtml1body1svg0.ChildNodes[13] as Element;
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.Attributes);
        Assert.Equal("feDisplacementMap", dochtml1body1svg0feDisplacementMap13.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDisplacementMap13.NodeType);

        var dochtml1body1svg0feDistantLight14 = dochtml1body1svg0.ChildNodes[14] as Element;
        Assert.Empty(dochtml1body1svg0feDistantLight14.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDistantLight14.Attributes);
        Assert.Equal("feDistantLight", dochtml1body1svg0feDistantLight14.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDistantLight14.NodeType);

        var dochtml1body1svg0feFlood15 = dochtml1body1svg0.ChildNodes[15] as Element;
        Assert.Empty(dochtml1body1svg0feFlood15.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFlood15.Attributes);
        Assert.Equal("feFlood", dochtml1body1svg0feFlood15.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFlood15.NodeType);

        var dochtml1body1svg0feFuncA16 = dochtml1body1svg0.ChildNodes[16] as Element;
        Assert.Empty(dochtml1body1svg0feFuncA16.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncA16.Attributes);
        Assert.Equal("feFuncA", dochtml1body1svg0feFuncA16.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncA16.NodeType);

        var dochtml1body1svg0feFuncB17 = dochtml1body1svg0.ChildNodes[17] as Element;
        Assert.Empty(dochtml1body1svg0feFuncB17.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncB17.Attributes);
        Assert.Equal("feFuncB", dochtml1body1svg0feFuncB17.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncB17.NodeType);

        var dochtml1body1svg0feFuncG18 = dochtml1body1svg0.ChildNodes[18] as Element;
        Assert.Empty(dochtml1body1svg0feFuncG18.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncG18.Attributes);
        Assert.Equal("feFuncG", dochtml1body1svg0feFuncG18.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncG18.NodeType);

        var dochtml1body1svg0feFuncR19 = dochtml1body1svg0.ChildNodes[19] as Element;
        Assert.Empty(dochtml1body1svg0feFuncR19.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncR19.Attributes);
        Assert.Equal("feFuncR", dochtml1body1svg0feFuncR19.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncR19.NodeType);

        var dochtml1body1svg0feGaussianBlur20 = dochtml1body1svg0.ChildNodes[20] as Element;
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.ChildNodes);
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.Attributes);
        Assert.Equal("feGaussianBlur", dochtml1body1svg0feGaussianBlur20.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feGaussianBlur20.NodeType);

        var dochtml1body1svg0feImage21 = dochtml1body1svg0.ChildNodes[21] as Element;
        Assert.Empty(dochtml1body1svg0feImage21.ChildNodes);
        Assert.Empty(dochtml1body1svg0feImage21.Attributes);
        Assert.Equal("feImage", dochtml1body1svg0feImage21.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feImage21.NodeType);

        var dochtml1body1svg0feMerge22 = dochtml1body1svg0.ChildNodes[22] as Element;
        Assert.Empty(dochtml1body1svg0feMerge22.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMerge22.Attributes);
        Assert.Equal("feMerge", dochtml1body1svg0feMerge22.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMerge22.NodeType);

        var dochtml1body1svg0feMergeNode23 = dochtml1body1svg0.ChildNodes[23] as Element;
        Assert.Empty(dochtml1body1svg0feMergeNode23.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMergeNode23.Attributes);
        Assert.Equal("feMergeNode", dochtml1body1svg0feMergeNode23.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMergeNode23.NodeType);

        var dochtml1body1svg0feMorphology24 = dochtml1body1svg0.ChildNodes[24] as Element;
        Assert.Empty(dochtml1body1svg0feMorphology24.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMorphology24.Attributes);
        Assert.Equal("feMorphology", dochtml1body1svg0feMorphology24.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMorphology24.NodeType);

        var dochtml1body1svg0feOffset25 = dochtml1body1svg0.ChildNodes[25] as Element;
        Assert.Empty(dochtml1body1svg0feOffset25.ChildNodes);
        Assert.Empty(dochtml1body1svg0feOffset25.Attributes);
        Assert.Equal("feOffset", dochtml1body1svg0feOffset25.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feOffset25.NodeType);

        var dochtml1body1svg0fePointLight26 = dochtml1body1svg0.ChildNodes[26] as Element;
        Assert.Empty(dochtml1body1svg0fePointLight26.ChildNodes);
        Assert.Empty(dochtml1body1svg0fePointLight26.Attributes);
        Assert.Equal("fePointLight", dochtml1body1svg0fePointLight26.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0fePointLight26.NodeType);

        var dochtml1body1svg0feSpecularLighting27 = dochtml1body1svg0.ChildNodes[27] as Element;
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.Attributes);
        Assert.Equal("feSpecularLighting", dochtml1body1svg0feSpecularLighting27.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpecularLighting27.NodeType);

        var dochtml1body1svg0feSpotLight28 = dochtml1body1svg0.ChildNodes[28] as Element;
        Assert.Empty(dochtml1body1svg0feSpotLight28.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpotLight28.Attributes);
        Assert.Equal("feSpotLight", dochtml1body1svg0feSpotLight28.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpotLight28.NodeType);

        var dochtml1body1svg0feTile29 = dochtml1body1svg0.ChildNodes[29] as Element;
        Assert.Empty(dochtml1body1svg0feTile29.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTile29.Attributes);
        Assert.Equal("feTile", dochtml1body1svg0feTile29.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTile29.NodeType);

        var dochtml1body1svg0feTurbulence30 = dochtml1body1svg0.ChildNodes[30] as Element;
        Assert.Empty(dochtml1body1svg0feTurbulence30.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTurbulence30.Attributes);
        Assert.Equal("feTurbulence", dochtml1body1svg0feTurbulence30.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTurbulence30.NodeType);

        var dochtml1body1svg0foreignObject31 = dochtml1body1svg0.ChildNodes[31] as Element;
        Assert.Empty(dochtml1body1svg0foreignObject31.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject31.Attributes);
        Assert.Equal("foreignObject", dochtml1body1svg0foreignObject31.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject31.NodeType);

        var dochtml1body1svg0glyphRef32 = dochtml1body1svg0.ChildNodes[32] as Element;
        Assert.Empty(dochtml1body1svg0glyphRef32.ChildNodes);
        Assert.Empty(dochtml1body1svg0glyphRef32.Attributes);
        Assert.Equal("glyphRef", dochtml1body1svg0glyphRef32.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0glyphRef32.NodeType);

        var dochtml1body1svg0linearGradient33 = dochtml1body1svg0.ChildNodes[33] as Element;
        Assert.Empty(dochtml1body1svg0linearGradient33.ChildNodes);
        Assert.Empty(dochtml1body1svg0linearGradient33.Attributes);
        Assert.Equal("linearGradient", dochtml1body1svg0linearGradient33.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0linearGradient33.NodeType);

        var dochtml1body1svg0radialGradient34 = dochtml1body1svg0.ChildNodes[34] as Element;
        Assert.Empty(dochtml1body1svg0radialGradient34.ChildNodes);
        Assert.Empty(dochtml1body1svg0radialGradient34.Attributes);
        Assert.Equal("radialGradient", dochtml1body1svg0radialGradient34.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0radialGradient34.NodeType);

        var dochtml1body1svg0textPath35 = dochtml1body1svg0.ChildNodes[35] as Element;
        Assert.Empty(dochtml1body1svg0textPath35.ChildNodes);
        Assert.Empty(dochtml1body1svg0textPath35.Attributes);
        Assert.Equal("textPath", dochtml1body1svg0textPath35.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0textPath35.NodeType);
    }

    [Fact]
    public void SvgCheckTagCaseUppercaseModified()
    {
        var doc = (@"<!DOCTYPE html><BODY><SVG><ALTGLYPH /><ALTGLYPHDEF /><ALTGLYPHITEM /><ANIMATECOLOR /><ANIMATEMOTION /><ANIMATETRANSFORM /><CLIPPATH /><FEBLEND /><FECOLORMATRIX /><FECOMPONENTTRANSFER /><FECOMPOSITE /><FECONVOLVEMATRIX /><FEDIFFUSELIGHTING /><FEDISPLACEMENTMAP /><FEDISTANTLIGHT /><FEFLOOD /><FEFUNCA /><FEFUNCB /><FEFUNCG /><FEFUNCR /><FEGAUSSIANBLUR /><FEIMAGE /><FEMERGE /><FEMERGENODE /><FEMORPHOLOGY /><FEOFFSET /><FEPOINTLIGHT /><FESPECULARLIGHTING /><FESPOTLIGHT /><FETILE /><FETURBULENCE /><FOREIGNOBJECT /><GLYPHREF /><LINEARGRADIENT /><RADIALGRADIENT /><TEXTPATH /></SVG>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(36, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0altGlyph0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0altGlyph0.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyph0.Attributes);
        Assert.Equal("altGlyph", dochtml1body1svg0altGlyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyph0.NodeType);

        var dochtml1body1svg0altGlyphDef1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphDef1.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphDef1.Attributes);
        Assert.Equal("altGlyphDef", dochtml1body1svg0altGlyphDef1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphDef1.NodeType);

        var dochtml1body1svg0altGlyphItem2 = dochtml1body1svg0.ChildNodes[2] as Element;
        Assert.Empty(dochtml1body1svg0altGlyphItem2.ChildNodes);
        Assert.Empty(dochtml1body1svg0altGlyphItem2.Attributes);
        Assert.Equal("altGlyphItem", dochtml1body1svg0altGlyphItem2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0altGlyphItem2.NodeType);

        var dochtml1body1svg0animateColor3 = dochtml1body1svg0.ChildNodes[3] as Element;
        Assert.Empty(dochtml1body1svg0animateColor3.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateColor3.Attributes);
        Assert.Equal("animateColor", dochtml1body1svg0animateColor3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateColor3.NodeType);

        var dochtml1body1svg0animateMotion4 = dochtml1body1svg0.ChildNodes[4] as Element;
        Assert.Empty(dochtml1body1svg0animateMotion4.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateMotion4.Attributes);
        Assert.Equal("animateMotion", dochtml1body1svg0animateMotion4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateMotion4.NodeType);

        var dochtml1body1svg0animateTransform5 = dochtml1body1svg0.ChildNodes[5] as Element;
        Assert.Empty(dochtml1body1svg0animateTransform5.ChildNodes);
        Assert.Empty(dochtml1body1svg0animateTransform5.Attributes);
        Assert.Equal("animateTransform", dochtml1body1svg0animateTransform5.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0animateTransform5.NodeType);

        var dochtml1body1svg0clipPath6 = dochtml1body1svg0.ChildNodes[6] as Element;
        Assert.Empty(dochtml1body1svg0clipPath6.ChildNodes);
        Assert.Empty(dochtml1body1svg0clipPath6.Attributes);
        Assert.Equal("clipPath", dochtml1body1svg0clipPath6.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0clipPath6.NodeType);

        var dochtml1body1svg0feBlend7 = dochtml1body1svg0.ChildNodes[7] as Element;
        Assert.Empty(dochtml1body1svg0feBlend7.ChildNodes);
        Assert.Empty(dochtml1body1svg0feBlend7.Attributes);
        Assert.Equal("feBlend", dochtml1body1svg0feBlend7.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feBlend7.NodeType);

        var dochtml1body1svg0feColorMatrix8 = dochtml1body1svg0.ChildNodes[8] as Element;
        Assert.Empty(dochtml1body1svg0feColorMatrix8.ChildNodes);
        Assert.Empty(dochtml1body1svg0feColorMatrix8.Attributes);
        Assert.Equal("feColorMatrix", dochtml1body1svg0feColorMatrix8.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feColorMatrix8.NodeType);

        var dochtml1body1svg0feComponentTransfer9 = dochtml1body1svg0.ChildNodes[9] as Element;
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComponentTransfer9.Attributes);
        Assert.Equal("feComponentTransfer", dochtml1body1svg0feComponentTransfer9.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComponentTransfer9.NodeType);

        var dochtml1body1svg0feComposite10 = dochtml1body1svg0.ChildNodes[10] as Element;
        Assert.Empty(dochtml1body1svg0feComposite10.ChildNodes);
        Assert.Empty(dochtml1body1svg0feComposite10.Attributes);
        Assert.Equal("feComposite", dochtml1body1svg0feComposite10.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feComposite10.NodeType);

        var dochtml1body1svg0feConvolveMatrix11 = dochtml1body1svg0.ChildNodes[11] as Element;
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.ChildNodes);
        Assert.Empty(dochtml1body1svg0feConvolveMatrix11.Attributes);
        Assert.Equal("feConvolveMatrix", dochtml1body1svg0feConvolveMatrix11.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feConvolveMatrix11.NodeType);

        var dochtml1body1svg0feDiffuseLighting12 = dochtml1body1svg0.ChildNodes[12] as Element;
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDiffuseLighting12.Attributes);
        Assert.Equal("feDiffuseLighting", dochtml1body1svg0feDiffuseLighting12.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDiffuseLighting12.NodeType);

        var dochtml1body1svg0feDisplacementMap13 = dochtml1body1svg0.ChildNodes[13] as Element;
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDisplacementMap13.Attributes);
        Assert.Equal("feDisplacementMap", dochtml1body1svg0feDisplacementMap13.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDisplacementMap13.NodeType);

        var dochtml1body1svg0feDistantLight14 = dochtml1body1svg0.ChildNodes[14] as Element;
        Assert.Empty(dochtml1body1svg0feDistantLight14.ChildNodes);
        Assert.Empty(dochtml1body1svg0feDistantLight14.Attributes);
        Assert.Equal("feDistantLight", dochtml1body1svg0feDistantLight14.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feDistantLight14.NodeType);

        var dochtml1body1svg0feFlood15 = dochtml1body1svg0.ChildNodes[15] as Element;
        Assert.Empty(dochtml1body1svg0feFlood15.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFlood15.Attributes);
        Assert.Equal("feFlood", dochtml1body1svg0feFlood15.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFlood15.NodeType);

        var dochtml1body1svg0feFuncA16 = dochtml1body1svg0.ChildNodes[16] as Element;
        Assert.Empty(dochtml1body1svg0feFuncA16.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncA16.Attributes);
        Assert.Equal("feFuncA", dochtml1body1svg0feFuncA16.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncA16.NodeType);

        var dochtml1body1svg0feFuncB17 = dochtml1body1svg0.ChildNodes[17] as Element;
        Assert.Empty(dochtml1body1svg0feFuncB17.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncB17.Attributes);
        Assert.Equal("feFuncB", dochtml1body1svg0feFuncB17.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncB17.NodeType);

        var dochtml1body1svg0feFuncG18 = dochtml1body1svg0.ChildNodes[18] as Element;
        Assert.Empty(dochtml1body1svg0feFuncG18.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncG18.Attributes);
        Assert.Equal("feFuncG", dochtml1body1svg0feFuncG18.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncG18.NodeType);

        var dochtml1body1svg0feFuncR19 = dochtml1body1svg0.ChildNodes[19] as Element;
        Assert.Empty(dochtml1body1svg0feFuncR19.ChildNodes);
        Assert.Empty(dochtml1body1svg0feFuncR19.Attributes);
        Assert.Equal("feFuncR", dochtml1body1svg0feFuncR19.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feFuncR19.NodeType);

        var dochtml1body1svg0feGaussianBlur20 = dochtml1body1svg0.ChildNodes[20] as Element;
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.ChildNodes);
        Assert.Empty(dochtml1body1svg0feGaussianBlur20.Attributes);
        Assert.Equal("feGaussianBlur", dochtml1body1svg0feGaussianBlur20.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feGaussianBlur20.NodeType);

        var dochtml1body1svg0feImage21 = dochtml1body1svg0.ChildNodes[21] as Element;
        Assert.Empty(dochtml1body1svg0feImage21.ChildNodes);
        Assert.Empty(dochtml1body1svg0feImage21.Attributes);
        Assert.Equal("feImage", dochtml1body1svg0feImage21.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feImage21.NodeType);

        var dochtml1body1svg0feMerge22 = dochtml1body1svg0.ChildNodes[22] as Element;
        Assert.Empty(dochtml1body1svg0feMerge22.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMerge22.Attributes);
        Assert.Equal("feMerge", dochtml1body1svg0feMerge22.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMerge22.NodeType);

        var dochtml1body1svg0feMergeNode23 = dochtml1body1svg0.ChildNodes[23] as Element;
        Assert.Empty(dochtml1body1svg0feMergeNode23.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMergeNode23.Attributes);
        Assert.Equal("feMergeNode", dochtml1body1svg0feMergeNode23.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMergeNode23.NodeType);

        var dochtml1body1svg0feMorphology24 = dochtml1body1svg0.ChildNodes[24] as Element;
        Assert.Empty(dochtml1body1svg0feMorphology24.ChildNodes);
        Assert.Empty(dochtml1body1svg0feMorphology24.Attributes);
        Assert.Equal("feMorphology", dochtml1body1svg0feMorphology24.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feMorphology24.NodeType);

        var dochtml1body1svg0feOffset25 = dochtml1body1svg0.ChildNodes[25] as Element;
        Assert.Empty(dochtml1body1svg0feOffset25.ChildNodes);
        Assert.Empty(dochtml1body1svg0feOffset25.Attributes);
        Assert.Equal("feOffset", dochtml1body1svg0feOffset25.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feOffset25.NodeType);

        var dochtml1body1svg0fePointLight26 = dochtml1body1svg0.ChildNodes[26] as Element;
        Assert.Empty(dochtml1body1svg0fePointLight26.ChildNodes);
        Assert.Empty(dochtml1body1svg0fePointLight26.Attributes);
        Assert.Equal("fePointLight", dochtml1body1svg0fePointLight26.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0fePointLight26.NodeType);

        var dochtml1body1svg0feSpecularLighting27 = dochtml1body1svg0.ChildNodes[27] as Element;
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpecularLighting27.Attributes);
        Assert.Equal("feSpecularLighting", dochtml1body1svg0feSpecularLighting27.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpecularLighting27.NodeType);

        var dochtml1body1svg0feSpotLight28 = dochtml1body1svg0.ChildNodes[28] as Element;
        Assert.Empty(dochtml1body1svg0feSpotLight28.ChildNodes);
        Assert.Empty(dochtml1body1svg0feSpotLight28.Attributes);
        Assert.Equal("feSpotLight", dochtml1body1svg0feSpotLight28.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feSpotLight28.NodeType);

        var dochtml1body1svg0feTile29 = dochtml1body1svg0.ChildNodes[29] as Element;
        Assert.Empty(dochtml1body1svg0feTile29.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTile29.Attributes);
        Assert.Equal("feTile", dochtml1body1svg0feTile29.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTile29.NodeType);

        var dochtml1body1svg0feTurbulence30 = dochtml1body1svg0.ChildNodes[30] as Element;
        Assert.Empty(dochtml1body1svg0feTurbulence30.ChildNodes);
        Assert.Empty(dochtml1body1svg0feTurbulence30.Attributes);
        Assert.Equal("feTurbulence", dochtml1body1svg0feTurbulence30.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0feTurbulence30.NodeType);

        var dochtml1body1svg0foreignObject31 = dochtml1body1svg0.ChildNodes[31] as Element;
        Assert.Empty(dochtml1body1svg0foreignObject31.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject31.Attributes);
        Assert.Equal("foreignObject", dochtml1body1svg0foreignObject31.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject31.NodeType);

        var dochtml1body1svg0glyphRef32 = dochtml1body1svg0.ChildNodes[32] as Element;
        Assert.Empty(dochtml1body1svg0glyphRef32.ChildNodes);
        Assert.Empty(dochtml1body1svg0glyphRef32.Attributes);
        Assert.Equal("glyphRef", dochtml1body1svg0glyphRef32.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0glyphRef32.NodeType);

        var dochtml1body1svg0linearGradient33 = dochtml1body1svg0.ChildNodes[33] as Element;
        Assert.Empty(dochtml1body1svg0linearGradient33.ChildNodes);
        Assert.Empty(dochtml1body1svg0linearGradient33.Attributes);
        Assert.Equal("linearGradient", dochtml1body1svg0linearGradient33.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0linearGradient33.NodeType);

        var dochtml1body1svg0radialGradient34 = dochtml1body1svg0.ChildNodes[34] as Element;
        Assert.Empty(dochtml1body1svg0radialGradient34.ChildNodes);
        Assert.Empty(dochtml1body1svg0radialGradient34.Attributes);
        Assert.Equal("radialGradient", dochtml1body1svg0radialGradient34.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0radialGradient34.NodeType);

        var dochtml1body1svg0textPath35 = dochtml1body1svg0.ChildNodes[35] as Element;
        Assert.Empty(dochtml1body1svg0textPath35.ChildNodes);
        Assert.Empty(dochtml1body1svg0textPath35.Attributes);
        Assert.Equal("textPath", dochtml1body1svg0textPath35.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0textPath35.NodeType);
    }

    [Fact]
    public void SvgSingleNodeInBody()
    {
        var doc = (@"<!DOCTYPE html><body><svg><solidColor /></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0solidcolor0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0solidcolor0.ChildNodes);
        Assert.Empty(dochtml1body1svg0solidcolor0.Attributes);
        Assert.Equal("solidcolor", dochtml1body1svg0solidcolor0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0solidcolor0.NodeType);
    }

    [Fact]
    public void SvgSingleElement()
    {
        var doc = (@"<!DOCTYPE html><svg></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);
    }

    [Fact]
    public void SvgSingleElementFollowedByCdata()
    {
        var doc = (@"<!DOCTYPE html><svg></svg><![CDATA[a]]>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1Comment1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml1body1Comment1.NodeType);
        Assert.Equal(@"[CDATA[a]]", dochtml1body1Comment1.TextContent);
    }

    [Fact]
    public void SvgSingleElementInBody()
    {
        var doc = (@"<!DOCTYPE html><body><svg></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);
    }

    [Fact]
    public void SvgSingleElementInSelect()
    {
        var doc = (@"<!DOCTYPE html><body><select><svg></svg></select>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);
    }

    [Fact]
    public void SvgSingleElementInOptionInSelect()
    {
        var doc = (@"<!DOCTYPE html><body><select><option><svg></svg></option></select>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1select0option0 = dochtml1body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1select0option0.ChildNodes);
        Assert.Empty(dochtml1body1select0option0.Attributes);
        Assert.Equal("option", dochtml1body1select0option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0option0.NodeType);
    }

    [Fact]
    public void SvgSingleElementInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><svg></svg></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void SvgElementWithGroupInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><svg><g>foo</g></svg></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void SvgElementWithGroupAndTextInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><svg><g>foo</g><g>bar</g></svg></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

    }

    [Fact]
    public void SvgElementWithGroupInTbody()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><svg><g>foo</g><g>bar</g></svg></tbody></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1tbody0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0.NodeType);
    }

    [Fact]
    public void SvgElementWithGroupAndTextInTbody()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><svg><g>foo</g><g>bar</g></svg></tr></tbody></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1tbody0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0.NodeType);

        var dochtml1body1table1tbody0tr0 = dochtml1body1table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0.NodeType);
    }

    [Fact]
    public void SvgElementWithGroupInTableCell()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><td><svg><g>foo</g><g>bar</g></svg></td></tr></tbody></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0tbody0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0.NodeType);

        var dochtml1body1table0tbody0tr0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0.NodeType);

        var dochtml1body1table0tbody0tr0td0 = dochtml1body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0tbody0tr0td0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g0 = dochtml1body1table0tbody0tr0td0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1table0tbody0tr0td0svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0g0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g0Text0 = dochtml1body1table0tbody0tr0td0svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0tbody0tr0td0svg0g0Text0.TextContent);

        var dochtml1body1table0tbody0tr0td0svg0g1 = dochtml1body1table0tbody0tr0td0svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1table0tbody0tr0td0svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0g1.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g1Text0 = dochtml1body1table0tbody0tr0td0svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0tbody0tr0td0svg0g1Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithGroupAndTextInTableCell()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><td><svg><g>foo</g><g>bar</g></svg><p>baz</td></tr></tbody></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0tbody0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0.NodeType);

        var dochtml1body1table0tbody0tr0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0.NodeType);

        var dochtml1body1table0tbody0tr0td0 = dochtml1body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0tbody0tr0td0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g0 = dochtml1body1table0tbody0tr0td0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1table0tbody0tr0td0svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0g0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g0Text0 = dochtml1body1table0tbody0tr0td0svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0tbody0tr0td0svg0g0Text0.TextContent);

        var dochtml1body1table0tbody0tr0td0svg0g1 = dochtml1body1table0tbody0tr0td0svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1table0tbody0tr0td0svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0g1.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0g1Text0 = dochtml1body1table0tbody0tr0td0svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0tbody0tr0td0svg0g1Text0.TextContent);

        var dochtml1body1table0tbody0tr0td0p1 = dochtml1body1table0tbody0tr0td0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0p1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0p1.Attributes);
        Assert.Equal("p", dochtml1body1table0tbody0tr0td0p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0p1.NodeType);

        var dochtml1body1table0tbody0tr0td0p1Text0 = dochtml1body1table0tbody0tr0td0p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1table0tbody0tr0td0p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithGroupAndTextInTableCaption()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><svg><g>foo</g><g>bar</g></svg><p>baz</caption></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0caption0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0.Attributes);
        Assert.Equal("caption", dochtml1body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0.NodeType);

        var dochtml1body1table0caption0svg0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0caption0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0.NodeType);

        var dochtml1body1table0caption0svg0g0 = dochtml1body1table0caption0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g0.NodeType);

        var dochtml1body1table0caption0svg0g0Text0 = dochtml1body1table0caption0svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0svg0g0Text0.TextContent);

        var dochtml1body1table0caption0svg0g1 = dochtml1body1table0caption0svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g1.NodeType);

        var dochtml1body1table0caption0svg0g1Text0 = dochtml1body1table0caption0svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0svg0g1Text0.TextContent);

        var dochtml1body1table0caption0p1 = dochtml1body1table0caption0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0p1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0p1.Attributes);
        Assert.Equal("p", dochtml1body1table0caption0p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0p1.NodeType);

        var dochtml1body1table0caption0p1Text0 = dochtml1body1table0caption0p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1table0caption0p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithGroupInTableCaption()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><svg><g>foo</g><g>bar</g><p>baz</table><p>quux").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0caption0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0.Attributes);
        Assert.Equal("caption", dochtml1body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0.NodeType);

        var dochtml1body1table0caption0svg0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0caption0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0.NodeType);

        var dochtml1body1table0caption0svg0g0 = dochtml1body1table0caption0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g0.NodeType);

        var dochtml1body1table0caption0svg0g0Text0 = dochtml1body1table0caption0svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0svg0g0Text0.TextContent);

        var dochtml1body1table0caption0svg0g1 = dochtml1body1table0caption0svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g1.NodeType);

        var dochtml1body1table0caption0svg0g1Text0 = dochtml1body1table0caption0svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0svg0g1Text0.TextContent);

        var dochtml1body1table0caption0p1 = dochtml1body1table0caption0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0p1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0p1.Attributes);
        Assert.Equal("p", dochtml1body1table0caption0p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0p1.NodeType);

        var dochtml1body1table0caption0p1Text0 = dochtml1body1table0caption0p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1table0caption0p1Text0.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("quux", dochtml1body1p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementInCaptionWithMisclosedEnding()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><svg><g>foo</g><g>bar</g>baz</table><p>quux").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0caption0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0.Attributes);
        Assert.Equal("caption", dochtml1body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0.NodeType);

        var dochtml1body1table0caption0svg0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml1body1table0caption0svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0caption0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0.NodeType);

        var dochtml1body1table0caption0svg0g0 = dochtml1body1table0caption0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g0.NodeType);

        var dochtml1body1table0caption0svg0g0Text0 = dochtml1body1table0caption0svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0svg0g0Text0.TextContent);

        var dochtml1body1table0caption0svg0g1 = dochtml1body1table0caption0svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1table0caption0svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0svg0g1.NodeType);

        var dochtml1body1table0caption0svg0g1Text0 = dochtml1body1table0caption0svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0svg0g1Text0.TextContent);

        var dochtml1body1table0caption0svg0Text2 = dochtml1body1table0caption0svg0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0svg0Text2.NodeType);
        Assert.Equal("baz", dochtml1body1table0caption0svg0Text2.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("quux", dochtml1body1p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementInColgroupWithMisclosedEnding()
    {
        var doc = (@"<!DOCTYPE html><body><table><colgroup><svg><g>foo</g><g>bar</g><p>baz</table><p>quux").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(4, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1p1Text0.TextContent);

        var dochtml1body1table2 = dochtml1body1.ChildNodes[2] as Element;
        Assert.Single(dochtml1body1table2.ChildNodes);
        Assert.Empty(dochtml1body1table2.Attributes);
        Assert.Equal("table", dochtml1body1table2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table2.NodeType);

        var dochtml1body1table2colgroup0 = dochtml1body1table2.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table2colgroup0.ChildNodes);
        Assert.Empty(dochtml1body1table2colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml1body1table2colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table2colgroup0.NodeType);

        var dochtml1body1p3 = dochtml1body1.ChildNodes[3] as Element;
        Assert.Single(dochtml1body1p3.ChildNodes);
        Assert.Empty(dochtml1body1p3.Attributes);
        Assert.Equal("p", dochtml1body1p3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p3.NodeType);

        var dochtml1body1p3Text0 = dochtml1body1p3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p3Text0.NodeType);
        Assert.Equal("quux", dochtml1body1p3Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithGroupInSelectMisclosed()
    {
        var doc = (@"<!DOCTYPE html><body><table><tr><td><select><svg><g>foo</g><g>bar</g><p>baz</table><p>quux").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0tbody0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0.NodeType);

        var dochtml1body1table0tbody0tr0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0.NodeType);

        var dochtml1body1table0tbody0tr0td0 = dochtml1body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

        var dochtml1body1table0tbody0tr0td0select0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0select0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0select0.Attributes);
        Assert.Equal("select", dochtml1body1table0tbody0tr0td0select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0select0.NodeType);

        var dochtml1body1table0tbody0tr0td0select0Text0 = dochtml1body1table0tbody0tr0td0select0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0select0Text0.NodeType);
        Assert.Equal("foobarbaz", dochtml1body1table0tbody0tr0td0select0Text0.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("quux", dochtml1body1p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithGroupInSelectAndTableMisclosed()
    {
        var doc = (@"<!DOCTYPE html><body><table><select><svg><g>foo</g><g>bar</g><p>baz</table><p>quux").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(3, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1select0Text0 = dochtml1body1select0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1select0Text0.NodeType);
        Assert.Equal("foobarbaz", dochtml1body1select0Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1p2 = dochtml1body1.ChildNodes[2] as Element;
        Assert.Single(dochtml1body1p2.ChildNodes);
        Assert.Empty(dochtml1body1p2.Attributes);
        Assert.Equal("p", dochtml1body1p2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p2.NodeType);

        var dochtml1body1p2Text0 = dochtml1body1p2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p2Text0.NodeType);
        Assert.Equal("quux", dochtml1body1p2Text0.TextContent);
    }

    [Fact]
    public void SvgElementOutsideDocumentRoot()
    {
        var doc = (@"<!DOCTYPE html><body></body></html><svg><g>foo</g><g>bar</g><p>baz").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementOutsideBody()
    {
        var doc = (@"<!DOCTYPE html><body></body><svg><g>foo</g><g>bar</g><p>baz").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0g0.ChildNodes);
        Assert.Empty(dochtml1body1svg0g0.Attributes);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var dochtml1body1svg0g0Text0 = dochtml1body1svg0g0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1svg0g0Text0.TextContent);

        var dochtml1body1svg0g1 = dochtml1body1svg0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0g1.ChildNodes);
        Assert.Empty(dochtml1body1svg0g1.Attributes);
        Assert.Equal("g", dochtml1body1svg0g1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g1.NodeType);

        var dochtml1body1svg0g1Text0 = dochtml1body1svg0g1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0g1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1svg0g1Text0.TextContent);

        var dochtml1body1p1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1p1.ChildNodes);
        Assert.Empty(dochtml1body1p1.Attributes);
        Assert.Equal("p", dochtml1body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p1.NodeType);

        var dochtml1body1p1Text0 = dochtml1body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1p1Text0.TextContent);
    }

    [Fact]
    public void SvgElementInFrameset()
    {
        var doc = (@"<!DOCTYPE html><frameset><svg><g></g><g></g><p><span>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1frameset1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1frameset1.ChildNodes);
        Assert.Empty(dochtml1frameset1.Attributes);
        Assert.Equal("frameset", dochtml1frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1frameset1.NodeType);
    }

    [Fact]
    public void SvgElementOutsideFrameset()
    {
        var doc = (@"<!DOCTYPE html><frameset></frameset><svg><g></g><g></g><p><span>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1frameset1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1frameset1.ChildNodes);
        Assert.Empty(dochtml1frameset1.Attributes);
        Assert.Equal("frameset", dochtml1frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1frameset1.NodeType);
    }

    [Fact]
    public void SvgElementInBodyWithXlinkAttribute()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo><svg xlink:href=foo></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Single(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xlink:href"));
        Assert.Equal("xlink:href", dochtml1body1.Attributes.GetNamedItem("xlink:href").Name);
        Assert.Equal("foo", dochtml1body1.Attributes.GetNamedItem("xlink:href").Value);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0.ChildNodes);
        Assert.Single(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var attr = dochtml1body1svg0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr);
        Assert.Equal("foo", attr.Value);
        Assert.Null(attr.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr.NamespaceUri);
    }

    [Fact]
    public void SvgElementWithGroupThatHasXlinkAttribute()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><svg><g xml:lang=en xlink:href=foo></g></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Equal(2, dochtml1body1.Attributes.Length);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xlink:href"));
        Assert.Equal("xlink:href", dochtml1body1.Attributes.GetNamedItem("xlink:href").Name);
        Assert.Equal("foo", dochtml1body1.Attributes.GetNamedItem("xlink:href").Value);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xml:lang"));
        Assert.Equal("xml:lang", dochtml1body1.Attributes.GetNamedItem("xml:lang").Name);
        Assert.Equal("en", dochtml1body1.Attributes.GetNamedItem("xml:lang").Value);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0g0.ChildNodes);
        Assert.Equal(2, dochtml1body1svg0g0.Attributes.Length);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var attr1 = dochtml1body1svg0g0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1svg0g0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);
    }

    [Fact]
    public void SvgElementWithGroupThatHasNamespacedAttributes()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><svg><g xml:lang=en xlink:href=foo /></svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Equal(2, dochtml1body1.Attributes.Length);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xlink:href"));
        Assert.Equal("xlink:href", dochtml1body1.Attributes.GetNamedItem("xlink:href").Name);
        Assert.Equal("foo", dochtml1body1.Attributes.GetNamedItem("xlink:href").Value);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xml:lang"));
        Assert.Equal("xml:lang", dochtml1body1.Attributes.GetNamedItem("xml:lang").Name);
        Assert.Equal("en", dochtml1body1.Attributes.GetNamedItem("xml:lang").Value);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0g0.ChildNodes);
        Assert.Equal(2, dochtml1body1svg0g0.Attributes.Length);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var attr1 = dochtml1body1svg0g0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1svg0g0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);
    }

    [Fact]
    public void SvgElementWithSelfClosingGroup()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><svg><g xml:lang=en xlink:href=foo />bar</svg>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Equal(2, dochtml1body1.Attributes.Length);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xlink:href"));
        Assert.Equal("xlink:href", dochtml1body1.Attributes.GetNamedItem("xlink:href").Name);
        Assert.Equal("foo", dochtml1body1.Attributes.GetNamedItem("xlink:href").Value);
        Assert.NotNull(dochtml1body1.Attributes.GetNamedItem("xml:lang"));
        Assert.Equal("xml:lang", dochtml1body1.Attributes.GetNamedItem("xml:lang").Name);
        Assert.Equal("en", dochtml1body1.Attributes.GetNamedItem("xml:lang").Value);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0g0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0g0.ChildNodes);
        Assert.Equal(2, dochtml1body1svg0g0.Attributes.Length);
        Assert.Equal("g", dochtml1body1svg0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0g0.NodeType);

        var attr1 = dochtml1body1svg0g0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1svg0g0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);

        var dochtml1body1svg0Text1 = dochtml1body1svg0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1svg0Text1.NodeType);
        Assert.Equal("bar", dochtml1body1svg0Text1.TextContent);
    }

    [Fact]
    public void SvgElementWithMisclosedPath()
    {
        var doc = (@"<svg></path>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);
    }

    [Fact]
    public void SvgElementInDivMisclosed()
    {
        var doc = (@"<div><svg></div>a").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("a", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void SvgElementWithPathInDivMisclosed()
    {
        var doc = (@"<div><svg><path></div>a").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1div0svg0path0 = dochtml0body1div0svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0svg0path0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0.Attributes);
        Assert.Equal("path", dochtml0body1div0svg0path0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0.NodeType);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("a", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void SvgElementWithMisclosedPathInDiv()
    {
        var doc = (@"<div><svg><path></svg><path>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1div0svg0path0 = dochtml0body1div0svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0svg0path0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0.Attributes);
        Assert.Equal("path", dochtml0body1div0svg0path0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0.NodeType);

        var dochtml0body1div0path1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0path1.ChildNodes);
        Assert.Empty(dochtml0body1div0path1.Attributes);
        Assert.Equal("path", dochtml0body1div0path1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0path1.NodeType);
    }

    [Fact]
    public void SvgElementWithPathAndMathInDiv()
    {
        var doc = (@"<div><svg><path><foreignObject><math></div>a").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1div0svg0path0 = dochtml0body1div0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0.Attributes);
        Assert.Equal("path", dochtml0body1div0svg0path0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0 = dochtml0body1div0svg0path0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0foreignObject0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1div0svg0path0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0math0 = dochtml0body1div0svg0path0foreignObject0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0foreignObject0math0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0math0.Attributes);
        Assert.Equal("math", dochtml0body1div0svg0path0foreignObject0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0math0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0math0Text0 = dochtml0body1div0svg0path0foreignObject0math0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0svg0path0foreignObject0math0Text0.NodeType);
        Assert.Equal("a", dochtml0body1div0svg0path0foreignObject0math0Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithPathAndForeignObjectInDiv()
    {
        var doc = (@"<div><svg><path><foreignObject><p></div>a").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1div0svg0path0 = dochtml0body1div0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0.Attributes);
        Assert.Equal("path", dochtml0body1div0svg0path0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0 = dochtml0body1div0svg0path0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0foreignObject0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1div0svg0path0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0p0 = dochtml0body1div0svg0path0foreignObject0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0foreignObject0p0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0p0.Attributes);
        Assert.Equal("p", dochtml0body1div0svg0path0foreignObject0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0p0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0p0Text0 = dochtml0body1div0svg0path0foreignObject0p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0svg0path0foreignObject0p0Text0.NodeType);
        Assert.Equal("a", dochtml0body1div0svg0path0foreignObject0p0Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithDescDivAndAnotherSvg()
    {
        var doc = (@"<!DOCTYPE html><svg><desc><div><svg><ul>a").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0desc0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0desc0.ChildNodes);
        Assert.Empty(dochtml1body1svg0desc0.Attributes);
        Assert.Equal("desc", dochtml1body1svg0desc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0.NodeType);

        var dochtml1body1svg0desc0div0 = dochtml1body1svg0desc0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0desc0div0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0desc0div0.Attributes);
        Assert.Equal("div", dochtml1body1svg0desc0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0div0.NodeType);

        var dochtml1body1svg0desc0div0svg0 = dochtml1body1svg0desc0div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0desc0div0svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0desc0div0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0desc0div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0div0svg0.NodeType);

        var dochtml1body1svg0desc0div0ul1 = dochtml1body1svg0desc0div0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0desc0div0ul1.ChildNodes);
        Assert.Empty(dochtml1body1svg0desc0div0ul1.Attributes);
        Assert.Equal("ul", dochtml1body1svg0desc0div0ul1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0div0ul1.NodeType);

        var dochtml1body1svg0desc0div0ul1Text0 = dochtml1body1svg0desc0div0ul1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0desc0div0ul1Text0.NodeType);
        Assert.Equal("a", dochtml1body1svg0desc0div0ul1Text0.TextContent);
    }

    [Fact]
    public void SvgElementWithDescAndAnotherSvgElement()
    {
        var doc = (@"<!DOCTYPE html><svg><desc><svg><ul>a").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0desc0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0desc0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0desc0.Attributes);
        Assert.Equal("desc", dochtml1body1svg0desc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0.NodeType);

        var dochtml1body1svg0desc0svg0 = dochtml1body1svg0desc0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0desc0svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0desc0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0desc0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0svg0.NodeType);

        var dochtml1body1svg0desc0ul1 = dochtml1body1svg0desc0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0desc0ul1.ChildNodes);
        Assert.Empty(dochtml1body1svg0desc0ul1.Attributes);
        Assert.Equal("ul", dochtml1body1svg0desc0ul1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0desc0ul1.NodeType);

        var dochtml1body1svg0desc0ul1Text0 = dochtml1body1svg0desc0ul1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0desc0ul1Text0.NodeType);
        Assert.Equal("a", dochtml1body1svg0desc0ul1Text0.TextContent);
    }

    [Fact]
    public void SvgElementInParagraph()
    {
        var doc = (@"<!DOCTYPE html><p><svg><desc><p>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1p0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0.ChildNodes);
        Assert.Empty(dochtml1body1p0.Attributes);
        Assert.Equal("p", dochtml1body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0.NodeType);

        var dochtml1body1p0svg0 = dochtml1body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0svg0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1p0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0.NodeType);

        var dochtml1body1p0svg0desc0 = dochtml1body1p0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0svg0desc0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0desc0.Attributes);
        Assert.Equal("desc", dochtml1body1p0svg0desc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0desc0.NodeType);

        var dochtml1body1p0svg0desc0p0 = dochtml1body1p0svg0desc0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1p0svg0desc0p0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0desc0p0.Attributes);
        Assert.Equal("p", dochtml1body1p0svg0desc0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0desc0p0.NodeType);
    }

    [Fact]
    public void SvgElementWithTitleInSvgNamespace()
    {
        var doc = (@"<!DOCTYPE html><p><svg><title><p>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1p0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0.ChildNodes);
        Assert.Empty(dochtml1body1p0.Attributes);
        Assert.Equal("p", dochtml1body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0.NodeType);

        var dochtml1body1p0svg0 = dochtml1body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0svg0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1p0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0.NodeType);

        var dochtml1body1p0svg0title0 = dochtml1body1p0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0svg0title0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0title0.Attributes);
        Assert.Equal("title", dochtml1body1p0svg0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0title0.NodeType);

        var dochtml1body1p0svg0title0p0 = dochtml1body1p0svg0title0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1p0svg0title0p0.ChildNodes);
        Assert.Empty(dochtml1body1p0svg0title0p0.Attributes);
        Assert.Equal("p", dochtml1body1p0svg0title0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0svg0title0p0.NodeType);
    }

    [Fact]
    public void SvgElementInDivWithForeignObject()
    {
        var doc = (@"<div><svg><path><foreignObject><p></foreignObject><p>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0svg0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1div0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0.NodeType);

        var dochtml0body1div0svg0path0 = dochtml0body1div0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0svg0path0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0.Attributes);
        Assert.Equal("path", dochtml0body1div0svg0path0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0 = dochtml0body1div0svg0path0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1div0svg0path0foreignObject0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1div0svg0path0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0p0 = dochtml0body1div0svg0path0foreignObject0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0p0.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0p0.Attributes);
        Assert.Equal("p", dochtml0body1div0svg0path0foreignObject0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0p0.NodeType);

        var dochtml0body1div0svg0path0foreignObject0p1 = dochtml0body1div0svg0path0foreignObject0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0p1.ChildNodes);
        Assert.Empty(dochtml0body1div0svg0path0foreignObject0p1.Attributes);
        Assert.Equal("p", dochtml0body1div0svg0path0foreignObject0p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0svg0path0foreignObject0p1.NodeType);
    }

    [Fact]
    public void SvgWithScriptAndPathElement()
    {
        var doc = (@"<svg><script></script><path>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1svg0.ChildNodes.Length);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0script0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0script0.ChildNodes);
        Assert.Empty(dochtml0body1svg0script0.Attributes);
        Assert.Equal("script", dochtml0body1svg0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0script0.NodeType);

        var dochtml0body1svg0path1 = dochtml0body1svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1svg0path1.ChildNodes);
        Assert.Empty(dochtml0body1svg0path1.Attributes);
        Assert.Equal("path", dochtml0body1svg0path1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0path1.NodeType);
    }

    [Fact]
    public void SvgInsideTableWithRow()
    {
        var doc = (@"<table><svg></svg><tr>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);
    }

    [Fact]
    public void SvgInsideMathMLWithAnnotationXml()
    {
        var doc = (@"<math><annotation-xml><svg></svg></annotation-xml><mi>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1math0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0annotationxml0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0.Attributes);
        Assert.Equal("annotation-xml", dochtml0body1math0annotationxml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0.NodeType);

        var dochtml0body1math0annotationxml0svg0 = dochtml0body1math0annotationxml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1math0annotationxml0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0.NodeType);

        var dochtml0body1math0mi1 = dochtml0body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi1.NodeType);
    }

    [Fact]
    public void SvgInsideMathMLWithAnnotationXmlAndForeignObject()
    {
        var doc = (@"<math><annotation-xml><svg><foreignObject><div><math><mi></mi></math><span></span></div></foreignObject><path></path></svg></annotation-xml><mi>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1math0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0annotationxml0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0.Attributes);
        Assert.Equal("annotation-xml", dochtml0body1math0annotationxml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0.NodeType);

        var dochtml0body1math0annotationxml0svg0 = dochtml0body1math0annotationxml0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0annotationxml0svg0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0annotationxml0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1math0annotationxml0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0 = dochtml0body1math0annotationxml0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0svg0foreignObject0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1math0annotationxml0svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0div0 = dochtml0body1math0annotationxml0svg0foreignObject0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0annotationxml0svg0foreignObject0div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0.Attributes);
        Assert.Equal("div", dochtml0body1math0annotationxml0svg0foreignObject0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0div0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0div0math0 = dochtml0body1math0annotationxml0svg0foreignObject0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0svg0foreignObject0div0math0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0math0.Attributes);
        Assert.Equal("math", dochtml0body1math0annotationxml0svg0foreignObject0div0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0div0math0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0div0math0mi0 = dochtml0body1math0annotationxml0svg0foreignObject0div0math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0annotationxml0svg0foreignObject0div0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0div0math0mi0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0div0span1 = dochtml0body1math0annotationxml0svg0foreignObject0div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0span1.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0div0span1.Attributes);
        Assert.Equal("span", dochtml0body1math0annotationxml0svg0foreignObject0div0span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0div0span1.NodeType);

        var dochtml0body1math0annotationxml0svg0path1 = dochtml0body1math0annotationxml0svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0path1.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0path1.Attributes);
        Assert.Equal("path", dochtml0body1math0annotationxml0svg0path1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0path1.NodeType);

        var dochtml0body1math0mi1 = dochtml0body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi1.NodeType);
    }

    [Fact]
    public void SvgInsideMathMLWithAnnotationXmlAndOthers()
    {
        var doc = (@"<math><annotation-xml><svg><foreignObject><math><mi><svg></svg></mi><mo></mo></math><span></span></foreignObject><path></path></svg></annotation-xml><mi>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1math0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0annotationxml0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0.Attributes);
        Assert.Equal("annotation-xml", dochtml0body1math0annotationxml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0.NodeType);

        var dochtml0body1math0annotationxml0svg0 = dochtml0body1math0annotationxml0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0annotationxml0svg0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0annotationxml0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1math0annotationxml0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0 = dochtml0body1math0annotationxml0svg0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0annotationxml0svg0foreignObject0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1math0annotationxml0svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0math0 = dochtml0body1math0annotationxml0svg0foreignObject0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0annotationxml0svg0foreignObject0math0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0.Attributes);
        Assert.Equal("math", dochtml0body1math0annotationxml0svg0foreignObject0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0math0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0math0mi0 = dochtml0body1math0annotationxml0svg0foreignObject0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0annotationxml0svg0foreignObject0math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0annotationxml0svg0foreignObject0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0math0mi0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0math0mi0svg0 = dochtml0body1math0annotationxml0svg0foreignObject0math0mi0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0mi0svg0.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0mi0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1math0annotationxml0svg0foreignObject0math0mi0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0math0mi0svg0.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0math0mo1 = dochtml0body1math0annotationxml0svg0foreignObject0math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0mo1.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0math0mo1.Attributes);
        Assert.Equal("mo", dochtml0body1math0annotationxml0svg0foreignObject0math0mo1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0math0mo1.NodeType);

        var dochtml0body1math0annotationxml0svg0foreignObject0span1 = dochtml0body1math0annotationxml0svg0foreignObject0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0span1.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0foreignObject0span1.Attributes);
        Assert.Equal("span", dochtml0body1math0annotationxml0svg0foreignObject0span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0foreignObject0span1.NodeType);

        var dochtml0body1math0annotationxml0svg0path1 = dochtml0body1math0annotationxml0svg0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0annotationxml0svg0path1.ChildNodes);
        Assert.Empty(dochtml0body1math0annotationxml0svg0path1.Attributes);
        Assert.Equal("path", dochtml0body1math0annotationxml0svg0path1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0annotationxml0svg0path1.NodeType);

        var dochtml0body1math0mi1 = dochtml0body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi1.NodeType);
    }
}
