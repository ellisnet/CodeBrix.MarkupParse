using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests9.dat
/// </summary>

public class HtmlWithMathMLTests
{
    [Fact]
    public void MathMLCheckAttributesCaseNormalUnchanged()
    {
        var doc = (@"<!DOCTYPE html><body><math attributeName='' attributeType='' baseFrequency='' baseProfile='' calcMode='' clipPathUnits='' contentScriptType='' contentStyleType='' diffuseConstant='' edgeMode='' externalResourcesRequired='' filterRes='' filterUnits='' glyphRef='' gradientTransform='' gradientUnits='' kernelMatrix='' kernelUnitLength='' keyPoints='' keySplines='' keyTimes='' lengthAdjust='' limitingConeAngle='' markerHeight='' markerUnits='' markerWidth='' maskContentUnits='' maskUnits='' numOctaves='' pathLength='' patternContentUnits='' patternTransform='' patternUnits='' pointsAtX='' pointsAtY='' pointsAtZ='' preserveAlpha='' preserveAspectRatio='' primitiveUnits='' refX='' refY='' repeatCount='' repeatDur='' requiredExtensions='' requiredFeatures='' specularConstant='' specularExponent='' spreadMethod='' startOffset='' stdDeviation='' stitchTiles='' surfaceScale='' systemLanguage='' tableValues='' targetX='' targetY='' textLength='' viewBox='' viewTarget='' xChannelSelector='' yChannelSelector='' zoomAndPan=''></math>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0.ChildNodes);
        Assert.Equal(62, dochtml1body1math0.Attributes.Length);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("attributename"));
        Assert.Equal("attributename", dochtml1body1math0.Attributes.GetNamedItem("attributename").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("attributename").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("attributetype"));
        Assert.Equal("attributetype", dochtml1body1math0.Attributes.GetNamedItem("attributetype").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("attributetype").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("basefrequency"));
        Assert.Equal("basefrequency", dochtml1body1math0.Attributes.GetNamedItem("basefrequency").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("basefrequency").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("baseprofile"));
        Assert.Equal("baseprofile", dochtml1body1math0.Attributes.GetNamedItem("baseprofile").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("baseprofile").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("calcmode"));
        Assert.Equal("calcmode", dochtml1body1math0.Attributes.GetNamedItem("calcmode").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("calcmode").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("clippathunits"));
        Assert.Equal("clippathunits", dochtml1body1math0.Attributes.GetNamedItem("clippathunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("clippathunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("contentscripttype"));
        Assert.Equal("contentscripttype", dochtml1body1math0.Attributes.GetNamedItem("contentscripttype").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("contentscripttype").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("contentstyletype"));
        Assert.Equal("contentstyletype", dochtml1body1math0.Attributes.GetNamedItem("contentstyletype").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("contentstyletype").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("diffuseconstant"));
        Assert.Equal("diffuseconstant", dochtml1body1math0.Attributes.GetNamedItem("diffuseconstant").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("diffuseconstant").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("edgemode"));
        Assert.Equal("edgemode", dochtml1body1math0.Attributes.GetNamedItem("edgemode").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("edgemode").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("externalresourcesrequired"));
        Assert.Equal("externalresourcesrequired", dochtml1body1math0.Attributes.GetNamedItem("externalresourcesrequired").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("externalresourcesrequired").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("filterres"));
        Assert.Equal("filterres", dochtml1body1math0.Attributes.GetNamedItem("filterres").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("filterres").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("filterunits"));
        Assert.Equal("filterunits", dochtml1body1math0.Attributes.GetNamedItem("filterunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("filterunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("glyphref"));
        Assert.Equal("glyphref", dochtml1body1math0.Attributes.GetNamedItem("glyphref").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("glyphref").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("gradienttransform"));
        Assert.Equal("gradienttransform", dochtml1body1math0.Attributes.GetNamedItem("gradienttransform").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("gradienttransform").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("gradientunits"));
        Assert.Equal("gradientunits", dochtml1body1math0.Attributes.GetNamedItem("gradientunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("gradientunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("kernelmatrix"));
        Assert.Equal("kernelmatrix", dochtml1body1math0.Attributes.GetNamedItem("kernelmatrix").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("kernelmatrix").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("kernelunitlength"));
        Assert.Equal("kernelunitlength", dochtml1body1math0.Attributes.GetNamedItem("kernelunitlength").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("kernelunitlength").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("keypoints"));
        Assert.Equal("keypoints", dochtml1body1math0.Attributes.GetNamedItem("keypoints").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("keypoints").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("keysplines"));
        Assert.Equal("keysplines", dochtml1body1math0.Attributes.GetNamedItem("keysplines").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("keysplines").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("keytimes"));
        Assert.Equal("keytimes", dochtml1body1math0.Attributes.GetNamedItem("keytimes").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("keytimes").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("lengthadjust"));
        Assert.Equal("lengthadjust", dochtml1body1math0.Attributes.GetNamedItem("lengthadjust").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("lengthadjust").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("limitingconeangle"));
        Assert.Equal("limitingconeangle", dochtml1body1math0.Attributes.GetNamedItem("limitingconeangle").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("limitingconeangle").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("markerheight"));
        Assert.Equal("markerheight", dochtml1body1math0.Attributes.GetNamedItem("markerheight").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("markerheight").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("markerunits"));
        Assert.Equal("markerunits", dochtml1body1math0.Attributes.GetNamedItem("markerunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("markerunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("markerwidth"));
        Assert.Equal("markerwidth", dochtml1body1math0.Attributes.GetNamedItem("markerwidth").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("markerwidth").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("maskcontentunits"));
        Assert.Equal("maskcontentunits", dochtml1body1math0.Attributes.GetNamedItem("maskcontentunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("maskcontentunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("maskunits"));
        Assert.Equal("maskunits", dochtml1body1math0.Attributes.GetNamedItem("maskunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("maskunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("numoctaves"));
        Assert.Equal("numoctaves", dochtml1body1math0.Attributes.GetNamedItem("numoctaves").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("numoctaves").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("pathlength"));
        Assert.Equal("pathlength", dochtml1body1math0.Attributes.GetNamedItem("pathlength").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("pathlength").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("patterncontentunits"));
        Assert.Equal("patterncontentunits", dochtml1body1math0.Attributes.GetNamedItem("patterncontentunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("patterncontentunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("patterntransform"));
        Assert.Equal("patterntransform", dochtml1body1math0.Attributes.GetNamedItem("patterntransform").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("patterntransform").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("patternunits"));
        Assert.Equal("patternunits", dochtml1body1math0.Attributes.GetNamedItem("patternunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("patternunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("pointsatx"));
        Assert.Equal("pointsatx", dochtml1body1math0.Attributes.GetNamedItem("pointsatx").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("pointsatx").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("pointsaty"));
        Assert.Equal("pointsaty", dochtml1body1math0.Attributes.GetNamedItem("pointsaty").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("pointsaty").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("pointsatz"));
        Assert.Equal("pointsatz", dochtml1body1math0.Attributes.GetNamedItem("pointsatz").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("pointsatz").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("preservealpha"));
        Assert.Equal("preservealpha", dochtml1body1math0.Attributes.GetNamedItem("preservealpha").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("preservealpha").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("preserveaspectratio"));
        Assert.Equal("preserveaspectratio", dochtml1body1math0.Attributes.GetNamedItem("preserveaspectratio").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("preserveaspectratio").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("primitiveunits"));
        Assert.Equal("primitiveunits", dochtml1body1math0.Attributes.GetNamedItem("primitiveunits").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("primitiveunits").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("refx"));
        Assert.Equal("refx", dochtml1body1math0.Attributes.GetNamedItem("refx").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("refx").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("refy"));
        Assert.Equal("refy", dochtml1body1math0.Attributes.GetNamedItem("refy").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("refy").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("repeatcount"));
        Assert.Equal("repeatcount", dochtml1body1math0.Attributes.GetNamedItem("repeatcount").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("repeatcount").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("repeatdur"));
        Assert.Equal("repeatdur", dochtml1body1math0.Attributes.GetNamedItem("repeatdur").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("repeatdur").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("requiredextensions"));
        Assert.Equal("requiredextensions", dochtml1body1math0.Attributes.GetNamedItem("requiredextensions").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("requiredextensions").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("requiredfeatures"));
        Assert.Equal("requiredfeatures", dochtml1body1math0.Attributes.GetNamedItem("requiredfeatures").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("requiredfeatures").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("specularconstant"));
        Assert.Equal("specularconstant", dochtml1body1math0.Attributes.GetNamedItem("specularconstant").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("specularconstant").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("specularexponent"));
        Assert.Equal("specularexponent", dochtml1body1math0.Attributes.GetNamedItem("specularexponent").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("specularexponent").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("spreadmethod"));
        Assert.Equal("spreadmethod", dochtml1body1math0.Attributes.GetNamedItem("spreadmethod").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("spreadmethod").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("startoffset"));
        Assert.Equal("startoffset", dochtml1body1math0.Attributes.GetNamedItem("startoffset").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("startoffset").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("stddeviation"));
        Assert.Equal("stddeviation", dochtml1body1math0.Attributes.GetNamedItem("stddeviation").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("stddeviation").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("stitchtiles"));
        Assert.Equal("stitchtiles", dochtml1body1math0.Attributes.GetNamedItem("stitchtiles").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("stitchtiles").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("surfacescale"));
        Assert.Equal("surfacescale", dochtml1body1math0.Attributes.GetNamedItem("surfacescale").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("surfacescale").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("systemlanguage"));
        Assert.Equal("systemlanguage", dochtml1body1math0.Attributes.GetNamedItem("systemlanguage").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("systemlanguage").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("tablevalues"));
        Assert.Equal("tablevalues", dochtml1body1math0.Attributes.GetNamedItem("tablevalues").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("tablevalues").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("targetx"));
        Assert.Equal("targetx", dochtml1body1math0.Attributes.GetNamedItem("targetx").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("targetx").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("targety"));
        Assert.Equal("targety", dochtml1body1math0.Attributes.GetNamedItem("targety").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("targety").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("textlength"));
        Assert.Equal("textlength", dochtml1body1math0.Attributes.GetNamedItem("textlength").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("textlength").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("viewbox"));
        Assert.Equal("viewbox", dochtml1body1math0.Attributes.GetNamedItem("viewbox").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("viewbox").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("viewtarget"));
        Assert.Equal("viewtarget", dochtml1body1math0.Attributes.GetNamedItem("viewtarget").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("viewtarget").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("xchannelselector"));
        Assert.Equal("xchannelselector", dochtml1body1math0.Attributes.GetNamedItem("xchannelselector").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("xchannelselector").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("ychannelselector"));
        Assert.Equal("ychannelselector", dochtml1body1math0.Attributes.GetNamedItem("ychannelselector").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("ychannelselector").Value);
        Assert.NotNull(dochtml1body1math0.Attributes.GetNamedItem("zoomandpan"));
        Assert.Equal("zoomandpan", dochtml1body1math0.Attributes.GetNamedItem("zoomandpan").Name);
        Assert.Equal("", dochtml1body1math0.Attributes.GetNamedItem("zoomandpan").Value);
    }

    [Fact]
    public void MathMLCheckTagCaseNormalUnchanged()
    {
        var doc = (@"<!DOCTYPE html><body><math><altGlyph /><altGlyphDef /><altGlyphItem /><animateColor /><animateMotion /><animateTransform /><clipPath /><feBlend /><feColorMatrix /><feComponentTransfer /><feComposite /><feConvolveMatrix /><feDiffuseLighting /><feDisplacementMap /><feDistantLight /><feFlood /><feFuncA /><feFuncB /><feFuncG /><feFuncR /><feGaussianBlur /><feImage /><feMerge /><feMergeNode /><feMorphology /><feOffset /><fePointLight /><feSpecularLighting /><feSpotLight /><feTile /><feTurbulence /><foreignObject /><glyphRef /><linearGradient /><radialGradient /><textPath /></math>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(36, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0altglyph0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0altglyph0.ChildNodes);
        Assert.Empty(dochtml1body1math0altglyph0.Attributes);
        Assert.Equal("altglyph", dochtml1body1math0altglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0altglyph0.NodeType);

        var dochtml1body1math0altglyphdef1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1math0altglyphdef1.ChildNodes);
        Assert.Empty(dochtml1body1math0altglyphdef1.Attributes);
        Assert.Equal("altglyphdef", dochtml1body1math0altglyphdef1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0altglyphdef1.NodeType);

        var dochtml1body1math0altglyphitem2 = dochtml1body1math0.ChildNodes[2] as Element;
        Assert.Empty(dochtml1body1math0altglyphitem2.ChildNodes);
        Assert.Empty(dochtml1body1math0altglyphitem2.Attributes);
        Assert.Equal("altglyphitem", dochtml1body1math0altglyphitem2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0altglyphitem2.NodeType);

        var dochtml1body1math0animatecolor3 = dochtml1body1math0.ChildNodes[3] as Element;
        Assert.Empty(dochtml1body1math0animatecolor3.ChildNodes);
        Assert.Empty(dochtml1body1math0animatecolor3.Attributes);
        Assert.Equal("animatecolor", dochtml1body1math0animatecolor3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0animatecolor3.NodeType);

        var dochtml1body1math0animatemotion4 = dochtml1body1math0.ChildNodes[4] as Element;
        Assert.Empty(dochtml1body1math0animatemotion4.ChildNodes);
        Assert.Empty(dochtml1body1math0animatemotion4.Attributes);
        Assert.Equal("animatemotion", dochtml1body1math0animatemotion4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0animatemotion4.NodeType);

        var dochtml1body1math0animatetransform5 = dochtml1body1math0.ChildNodes[5] as Element;
        Assert.Empty(dochtml1body1math0animatetransform5.ChildNodes);
        Assert.Empty(dochtml1body1math0animatetransform5.Attributes);
        Assert.Equal("animatetransform", dochtml1body1math0animatetransform5.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0animatetransform5.NodeType);

        var dochtml1body1math0clippath6 = dochtml1body1math0.ChildNodes[6] as Element;
        Assert.Empty(dochtml1body1math0clippath6.ChildNodes);
        Assert.Empty(dochtml1body1math0clippath6.Attributes);
        Assert.Equal("clippath", dochtml1body1math0clippath6.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0clippath6.NodeType);

        var dochtml1body1math0feblend7 = dochtml1body1math0.ChildNodes[7] as Element;
        Assert.Empty(dochtml1body1math0feblend7.ChildNodes);
        Assert.Empty(dochtml1body1math0feblend7.Attributes);
        Assert.Equal("feblend", dochtml1body1math0feblend7.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feblend7.NodeType);

        var dochtml1body1math0fecolormatrix8 = dochtml1body1math0.ChildNodes[8] as Element;
        Assert.Empty(dochtml1body1math0fecolormatrix8.ChildNodes);
        Assert.Empty(dochtml1body1math0fecolormatrix8.Attributes);
        Assert.Equal("fecolormatrix", dochtml1body1math0fecolormatrix8.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fecolormatrix8.NodeType);

        var dochtml1body1math0fecomponenttransfer9 = dochtml1body1math0.ChildNodes[9] as Element;
        Assert.Empty(dochtml1body1math0fecomponenttransfer9.ChildNodes);
        Assert.Empty(dochtml1body1math0fecomponenttransfer9.Attributes);
        Assert.Equal("fecomponenttransfer", dochtml1body1math0fecomponenttransfer9.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fecomponenttransfer9.NodeType);

        var dochtml1body1math0fecomposite10 = dochtml1body1math0.ChildNodes[10] as Element;
        Assert.Empty(dochtml1body1math0fecomposite10.ChildNodes);
        Assert.Empty(dochtml1body1math0fecomposite10.Attributes);
        Assert.Equal("fecomposite", dochtml1body1math0fecomposite10.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fecomposite10.NodeType);

        var dochtml1body1math0feconvolvematrix11 = dochtml1body1math0.ChildNodes[11] as Element;
        Assert.Empty(dochtml1body1math0feconvolvematrix11.ChildNodes);
        Assert.Empty(dochtml1body1math0feconvolvematrix11.Attributes);
        Assert.Equal("feconvolvematrix", dochtml1body1math0feconvolvematrix11.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feconvolvematrix11.NodeType);

        var dochtml1body1math0fediffuselighting12 = dochtml1body1math0.ChildNodes[12] as Element;
        Assert.Empty(dochtml1body1math0fediffuselighting12.ChildNodes);
        Assert.Empty(dochtml1body1math0fediffuselighting12.Attributes);
        Assert.Equal("fediffuselighting", dochtml1body1math0fediffuselighting12.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fediffuselighting12.NodeType);

        var dochtml1body1math0fedisplacementmap13 = dochtml1body1math0.ChildNodes[13] as Element;
        Assert.Empty(dochtml1body1math0fedisplacementmap13.ChildNodes);
        Assert.Empty(dochtml1body1math0fedisplacementmap13.Attributes);
        Assert.Equal("fedisplacementmap", dochtml1body1math0fedisplacementmap13.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fedisplacementmap13.NodeType);

        var dochtml1body1math0fedistantlight14 = dochtml1body1math0.ChildNodes[14] as Element;
        Assert.Empty(dochtml1body1math0fedistantlight14.ChildNodes);
        Assert.Empty(dochtml1body1math0fedistantlight14.Attributes);
        Assert.Equal("fedistantlight", dochtml1body1math0fedistantlight14.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fedistantlight14.NodeType);

        var dochtml1body1math0feflood15 = dochtml1body1math0.ChildNodes[15] as Element;
        Assert.Empty(dochtml1body1math0feflood15.ChildNodes);
        Assert.Empty(dochtml1body1math0feflood15.Attributes);
        Assert.Equal("feflood", dochtml1body1math0feflood15.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feflood15.NodeType);

        var dochtml1body1math0fefunca16 = dochtml1body1math0.ChildNodes[16] as Element;
        Assert.Empty(dochtml1body1math0fefunca16.ChildNodes);
        Assert.Empty(dochtml1body1math0fefunca16.Attributes);
        Assert.Equal("fefunca", dochtml1body1math0fefunca16.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fefunca16.NodeType);

        var dochtml1body1math0fefuncb17 = dochtml1body1math0.ChildNodes[17] as Element;
        Assert.Empty(dochtml1body1math0fefuncb17.ChildNodes);
        Assert.Empty(dochtml1body1math0fefuncb17.Attributes);
        Assert.Equal("fefuncb", dochtml1body1math0fefuncb17.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fefuncb17.NodeType);

        var dochtml1body1math0fefuncg18 = dochtml1body1math0.ChildNodes[18] as Element;
        Assert.Empty(dochtml1body1math0fefuncg18.ChildNodes);
        Assert.Empty(dochtml1body1math0fefuncg18.Attributes);
        Assert.Equal("fefuncg", dochtml1body1math0fefuncg18.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fefuncg18.NodeType);

        var dochtml1body1math0fefuncr19 = dochtml1body1math0.ChildNodes[19] as Element;
        Assert.Empty(dochtml1body1math0fefuncr19.ChildNodes);
        Assert.Empty(dochtml1body1math0fefuncr19.Attributes);
        Assert.Equal("fefuncr", dochtml1body1math0fefuncr19.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fefuncr19.NodeType);

        var dochtml1body1math0fegaussianblur20 = dochtml1body1math0.ChildNodes[20] as Element;
        Assert.Empty(dochtml1body1math0fegaussianblur20.ChildNodes);
        Assert.Empty(dochtml1body1math0fegaussianblur20.Attributes);
        Assert.Equal("fegaussianblur", dochtml1body1math0fegaussianblur20.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fegaussianblur20.NodeType);

        var dochtml1body1math0feimage21 = dochtml1body1math0.ChildNodes[21] as Element;
        Assert.Empty(dochtml1body1math0feimage21.ChildNodes);
        Assert.Empty(dochtml1body1math0feimage21.Attributes);
        Assert.Equal("feimage", dochtml1body1math0feimage21.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feimage21.NodeType);

        var dochtml1body1math0femerge22 = dochtml1body1math0.ChildNodes[22] as Element;
        Assert.Empty(dochtml1body1math0femerge22.ChildNodes);
        Assert.Empty(dochtml1body1math0femerge22.Attributes);
        Assert.Equal("femerge", dochtml1body1math0femerge22.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0femerge22.NodeType);

        var dochtml1body1math0femergenode23 = dochtml1body1math0.ChildNodes[23] as Element;
        Assert.Empty(dochtml1body1math0femergenode23.ChildNodes);
        Assert.Empty(dochtml1body1math0femergenode23.Attributes);
        Assert.Equal("femergenode", dochtml1body1math0femergenode23.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0femergenode23.NodeType);

        var dochtml1body1math0femorphology24 = dochtml1body1math0.ChildNodes[24] as Element;
        Assert.Empty(dochtml1body1math0femorphology24.ChildNodes);
        Assert.Empty(dochtml1body1math0femorphology24.Attributes);
        Assert.Equal("femorphology", dochtml1body1math0femorphology24.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0femorphology24.NodeType);

        var dochtml1body1math0feoffset25 = dochtml1body1math0.ChildNodes[25] as Element;
        Assert.Empty(dochtml1body1math0feoffset25.ChildNodes);
        Assert.Empty(dochtml1body1math0feoffset25.Attributes);
        Assert.Equal("feoffset", dochtml1body1math0feoffset25.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feoffset25.NodeType);

        var dochtml1body1math0fepointlight26 = dochtml1body1math0.ChildNodes[26] as Element;
        Assert.Empty(dochtml1body1math0fepointlight26.ChildNodes);
        Assert.Empty(dochtml1body1math0fepointlight26.Attributes);
        Assert.Equal("fepointlight", dochtml1body1math0fepointlight26.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fepointlight26.NodeType);

        var dochtml1body1math0fespecularlighting27 = dochtml1body1math0.ChildNodes[27] as Element;
        Assert.Empty(dochtml1body1math0fespecularlighting27.ChildNodes);
        Assert.Empty(dochtml1body1math0fespecularlighting27.Attributes);
        Assert.Equal("fespecularlighting", dochtml1body1math0fespecularlighting27.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fespecularlighting27.NodeType);

        var dochtml1body1math0fespotlight28 = dochtml1body1math0.ChildNodes[28] as Element;
        Assert.Empty(dochtml1body1math0fespotlight28.ChildNodes);
        Assert.Empty(dochtml1body1math0fespotlight28.Attributes);
        Assert.Equal("fespotlight", dochtml1body1math0fespotlight28.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fespotlight28.NodeType);

        var dochtml1body1math0fetile29 = dochtml1body1math0.ChildNodes[29] as Element;
        Assert.Empty(dochtml1body1math0fetile29.ChildNodes);
        Assert.Empty(dochtml1body1math0fetile29.Attributes);
        Assert.Equal("fetile", dochtml1body1math0fetile29.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0fetile29.NodeType);

        var dochtml1body1math0feturbulence30 = dochtml1body1math0.ChildNodes[30] as Element;
        Assert.Empty(dochtml1body1math0feturbulence30.ChildNodes);
        Assert.Empty(dochtml1body1math0feturbulence30.Attributes);
        Assert.Equal("feturbulence", dochtml1body1math0feturbulence30.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0feturbulence30.NodeType);

        var dochtml1body1math0foreignobject31 = dochtml1body1math0.ChildNodes[31] as Element;
        Assert.Empty(dochtml1body1math0foreignobject31.ChildNodes);
        Assert.Empty(dochtml1body1math0foreignobject31.Attributes);
        Assert.Equal("foreignobject", dochtml1body1math0foreignobject31.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0foreignobject31.NodeType);

        var dochtml1body1math0glyphref32 = dochtml1body1math0.ChildNodes[32] as Element;
        Assert.Empty(dochtml1body1math0glyphref32.ChildNodes);
        Assert.Empty(dochtml1body1math0glyphref32.Attributes);
        Assert.Equal("glyphref", dochtml1body1math0glyphref32.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0glyphref32.NodeType);

        var dochtml1body1math0lineargradient33 = dochtml1body1math0.ChildNodes[33] as Element;
        Assert.Empty(dochtml1body1math0lineargradient33.ChildNodes);
        Assert.Empty(dochtml1body1math0lineargradient33.Attributes);
        Assert.Equal("lineargradient", dochtml1body1math0lineargradient33.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0lineargradient33.NodeType);

        var dochtml1body1math0radialgradient34 = dochtml1body1math0.ChildNodes[34] as Element;
        Assert.Empty(dochtml1body1math0radialgradient34.ChildNodes);
        Assert.Empty(dochtml1body1math0radialgradient34.Attributes);
        Assert.Equal("radialgradient", dochtml1body1math0radialgradient34.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0radialgradient34.NodeType);

        var dochtml1body1math0textpath35 = dochtml1body1math0.ChildNodes[35] as Element;
        Assert.Empty(dochtml1body1math0textpath35.ChildNodes);
        Assert.Empty(dochtml1body1math0textpath35.Attributes);
        Assert.Equal("textpath", dochtml1body1math0textpath35.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0textpath35.NodeType);
    }

    [Fact]
    public void MathMLSingleElement()
    {
        var doc = (@"<!DOCTYPE html><math></math>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);
    }

    [Fact]
    public void MathMLSingleElementInBody()
    {
        var doc = (@"<!DOCTYPE html><body><math></math>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);
    }

    [Fact]
    public void MathMLElementWithDivAndObjectElements()
    {
        var doc = (@"<math><mi><div><object><div><span></span></div></object></div></mi><mi>").ToHtmlDocument();

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

        var dochtml0body1math0mi0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0.NodeType);

        var dochtml0body1math0mi0div0 = dochtml0body1math0mi0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0div0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0div0.Attributes);
        Assert.Equal("div", dochtml0body1math0mi0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0div0.NodeType);

        var dochtml0body1math0mi0div0object0 = dochtml0body1math0mi0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0div0object0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0div0object0.Attributes);
        Assert.Equal("object", dochtml0body1math0mi0div0object0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0div0object0.NodeType);

        var dochtml0body1math0mi0div0object0div0 = dochtml0body1math0mi0div0object0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0div0object0div0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0div0object0div0.Attributes);
        Assert.Equal("div", dochtml0body1math0mi0div0object0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0div0object0div0.NodeType);

        var dochtml0body1math0mi0div0object0div0span0 = dochtml0body1math0mi0div0object0div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mi0div0object0div0span0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0div0object0div0span0.Attributes);
        Assert.Equal("span", dochtml0body1math0mi0div0object0div0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0div0object0div0span0.NodeType);

        var dochtml0body1math0mi1 = dochtml0body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi1.NodeType);
    }

    [Fact]
    public void MathMLElementWithSvgChild()
    {
        var doc = (@"<math><mi><svg><foreignObject><div><div></div></div></foreignObject></svg></mi><mi>").ToHtmlDocument();

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

        var dochtml0body1math0mi0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0.NodeType);

        var dochtml0body1math0mi0svg0 = dochtml0body1math0mi0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0svg0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1math0mi0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0svg0.NodeType);

        var dochtml0body1math0mi0svg0foreignObject0 = dochtml0body1math0mi0svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0svg0foreignObject0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1math0mi0svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0svg0foreignObject0.NodeType);

        var dochtml0body1math0mi0svg0foreignObject0div0 = dochtml0body1math0mi0svg0foreignObject0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0svg0foreignObject0div0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0svg0foreignObject0div0.Attributes);
        Assert.Equal("div", dochtml0body1math0mi0svg0foreignObject0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0svg0foreignObject0div0.NodeType);

        var dochtml0body1math0mi0svg0foreignObject0div0div0 = dochtml0body1math0mi0svg0foreignObject0div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mi0svg0foreignObject0div0div0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0svg0foreignObject0div0div0.Attributes);
        Assert.Equal("div", dochtml0body1math0mi0svg0foreignObject0div0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0svg0foreignObject0div0div0.NodeType);

        var dochtml0body1math0mi1 = dochtml0body1math0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1math0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi1.NodeType);
    }

    [Fact]
    public void MathMLSingleElementWithChild()
    {
        var doc = (@"<!DOCTYPE html><math><mi>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);
    }

    [Fact]
    public void MathMLWithMiAndMglyphElements()
    {
        var doc = (@"<math><mi><mglyph>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mi0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0.NodeType);

        var dochtml0body1math0mi0mglyph0 = dochtml0body1math0mi0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mi0mglyph0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0mglyph0.Attributes);
        Assert.Equal("mglyph", dochtml0body1math0mi0mglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0mglyph0.NodeType);
    }

    [Fact]
    public void MathMLWithMiAndMalignmarkElements()
    {
        var doc = (@"<math><mi><malignmark>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mi0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mi0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml0body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0.NodeType);

        var dochtml0body1math0mi0malignmark0 = dochtml0body1math0mi0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mi0malignmark0.ChildNodes);
        Assert.Empty(dochtml0body1math0mi0malignmark0.Attributes);
        Assert.Equal("malignmark", dochtml0body1math0mi0malignmark0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mi0malignmark0.NodeType);
    }

    [Fact]
    public void MathMLWithMoAndMglyphElements()
    {
        var doc = (@"<math><mo><mglyph>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mo0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mo0.ChildNodes);
        Assert.Empty(dochtml0body1math0mo0.Attributes);
        Assert.Equal("mo", dochtml0body1math0mo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mo0.NodeType);

        var dochtml0body1math0mo0mglyph0 = dochtml0body1math0mo0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mo0mglyph0.ChildNodes);
        Assert.Empty(dochtml0body1math0mo0mglyph0.Attributes);
        Assert.Equal("mglyph", dochtml0body1math0mo0mglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mo0mglyph0.NodeType);
    }

    [Fact]
    public void MathMLWithMoAndMalignmarkElements()
    {
        var doc = (@"<math><mo><malignmark>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mo0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mo0.ChildNodes);
        Assert.Empty(dochtml0body1math0mo0.Attributes);
        Assert.Equal("mo", dochtml0body1math0mo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mo0.NodeType);

        var dochtml0body1math0mo0malignmark0 = dochtml0body1math0mo0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mo0malignmark0.ChildNodes);
        Assert.Empty(dochtml0body1math0mo0malignmark0.Attributes);
        Assert.Equal("malignmark", dochtml0body1math0mo0malignmark0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mo0malignmark0.NodeType);
    }

    [Fact]
    public void MathMLWithMnAndMglyphElements()
    {
        var doc = (@"<math><mn><mglyph>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mn0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mn0.ChildNodes);
        Assert.Empty(dochtml0body1math0mn0.Attributes);
        Assert.Equal("mn", dochtml0body1math0mn0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mn0.NodeType);

        var dochtml0body1math0mn0mglyph0 = dochtml0body1math0mn0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mn0mglyph0.ChildNodes);
        Assert.Empty(dochtml0body1math0mn0mglyph0.Attributes);
        Assert.Equal("mglyph", dochtml0body1math0mn0mglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mn0mglyph0.NodeType);
    }

    [Fact]
    public void MathMLWithMnAndMalignmarkElements()
    {
        var doc = (@"<math><mn><malignmark>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mn0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mn0.ChildNodes);
        Assert.Empty(dochtml0body1math0mn0.Attributes);
        Assert.Equal("mn", dochtml0body1math0mn0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mn0.NodeType);

        var dochtml0body1math0mn0malignmark0 = dochtml0body1math0mn0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mn0malignmark0.ChildNodes);
        Assert.Empty(dochtml0body1math0mn0malignmark0.Attributes);
        Assert.Equal("malignmark", dochtml0body1math0mn0malignmark0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mn0malignmark0.NodeType);
    }

    [Fact]
    public void MathMLWithMsAndMglyphElements()
    {
        var doc = (@"<math><ms><mglyph>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0ms0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0ms0.ChildNodes);
        Assert.Empty(dochtml0body1math0ms0.Attributes);
        Assert.Equal("ms", dochtml0body1math0ms0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0ms0.NodeType);

        var dochtml0body1math0ms0mglyph0 = dochtml0body1math0ms0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0ms0mglyph0.ChildNodes);
        Assert.Empty(dochtml0body1math0ms0mglyph0.Attributes);
        Assert.Equal("mglyph", dochtml0body1math0ms0mglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0ms0mglyph0.NodeType);
    }

    [Fact]
    public void MathMLWithMsAndMalignmarkElements()
    {
        var doc = (@"<math><ms><malignmark>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0ms0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0ms0.ChildNodes);
        Assert.Empty(dochtml0body1math0ms0.Attributes);
        Assert.Equal("ms", dochtml0body1math0ms0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0ms0.NodeType);

        var dochtml0body1math0ms0malignmark0 = dochtml0body1math0ms0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0ms0malignmark0.ChildNodes);
        Assert.Empty(dochtml0body1math0ms0malignmark0.Attributes);
        Assert.Equal("malignmark", dochtml0body1math0ms0malignmark0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0ms0malignmark0.NodeType);
    }

    [Fact]
    public void MathMLWithMtextAndMglyphElements()
    {
        var doc = (@"<math><mtext><mglyph>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mtext0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mtext0.ChildNodes);
        Assert.Empty(dochtml0body1math0mtext0.Attributes);
        Assert.Equal("mtext", dochtml0body1math0mtext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mtext0.NodeType);

        var dochtml0body1math0mtext0mglyph0 = dochtml0body1math0mtext0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mtext0mglyph0.ChildNodes);
        Assert.Empty(dochtml0body1math0mtext0mglyph0.Attributes);
        Assert.Equal("mglyph", dochtml0body1math0mtext0mglyph0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mtext0mglyph0.NodeType);
    }

    [Fact]
    public void MathMLWithMtextAndMalignmarkElements()
    {
        var doc = (@"<math><mtext><malignmark>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mtext0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mtext0.ChildNodes);
        Assert.Empty(dochtml0body1math0mtext0.Attributes);
        Assert.Equal("mtext", dochtml0body1math0mtext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mtext0.NodeType);

        var dochtml0body1math0mtext0malignmark0 = dochtml0body1math0mtext0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1math0mtext0malignmark0.ChildNodes);
        Assert.Empty(dochtml0body1math0mtext0malignmark0.Attributes);
        Assert.Equal("malignmark", dochtml0body1math0mtext0malignmark0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mtext0malignmark0.NodeType);
    }

    [Fact]
    public void MathMLAnnotationXmlWithSvgInside()
    {
        var doc = (@"<!DOCTYPE html><math><annotation-xml><svg><u>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);
        var dochtml1body1math0annotationxml0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0annotationxml0.ChildNodes);
        Assert.Empty(dochtml1body1math0annotationxml0.Attributes);
        Assert.Equal("annotation-xml", dochtml1body1math0annotationxml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0annotationxml0.NodeType);

        var dochtml1body1math0annotationxml0svg0 = dochtml1body1math0annotationxml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0annotationxml0svg0.ChildNodes);
        Assert.Empty(dochtml1body1math0annotationxml0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1math0annotationxml0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0annotationxml0svg0.NodeType);

        var dochtml1body1u1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1u1.ChildNodes);
        Assert.Empty(dochtml1body1u1.Attributes);
        Assert.Equal("u", dochtml1body1u1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1u1.NodeType);
    }

    [Fact]
    public void MathMLElementInSelect()
    {
        var doc = (@"<!DOCTYPE html><body><select><math></math></select>").ToHtmlDocument();

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
    public void MathMLInOptionOfSelect()
    {
        var doc = (@"<!DOCTYPE html><body><select><option><math></math></option></select>").ToHtmlDocument();

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
    public void MathMLInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><math></math></table>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void MathMLWithChildInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><math><mi>foo</mi></math></table>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void MathMLWithChildrenInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><math><mi>foo</mi><mi>bar</mi></math></table>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void MathMLInTBodySectionOfTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><math><mi>foo</mi><mi>bar</mi></math></tbody></table>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

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
    public void MathMLInRowOfTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><math><mi>foo</mi><mi>bar</mi></math></tr></tbody></table>").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

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
    public void MathMLInCellOfTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><td><math><mi>foo</mi><mi>bar</mi></math></td></tr></tbody></table>").ToHtmlDocument();

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

        var dochtml1body1table0tbody0tr0td0math0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0tbody0tr0td0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi0 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1table0tbody0tr0td0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mi0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi0Text0 = dochtml1body1table0tbody0tr0td0math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0tbody0tr0td0math0mi0Text0.TextContent);

        var dochtml1body1table0tbody0tr0td0math0mi1 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1table0tbody0tr0td0math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mi1.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi1Text0 = dochtml1body1table0tbody0tr0td0math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0tbody0tr0td0math0mi1Text0.TextContent);
    }

    [Fact]
    public void MathMLCompleteExampleInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><tbody><tr><td><math><mi>foo</mi><mi>bar</mi></math><p>baz</td></tr></tbody></table>").ToHtmlDocument();

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

        var dochtml1body1table0tbody0tr0td0math0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0tbody0tr0td0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi0 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1table0tbody0tr0td0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mi0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi0Text0 = dochtml1body1table0tbody0tr0td0math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0tbody0tr0td0math0mi0Text0.TextContent);

        var dochtml1body1table0tbody0tr0td0math0mi1 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1table0tbody0tr0td0math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mi1.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mi1Text0 = dochtml1body1table0tbody0tr0td0math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0tbody0tr0td0math0mi1Text0.TextContent);

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
    public void MathMLInCaptionOfTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><math><mi>foo</mi><mi>bar</mi></math><p>baz</caption></table>").ToHtmlDocument();

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

        var dochtml1body1table0caption0math0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0caption0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0.NodeType);

        var dochtml1body1table0caption0math0mi0 = dochtml1body1table0caption0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi0.NodeType);

        var dochtml1body1table0caption0math0mi0Text0 = dochtml1body1table0caption0math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0math0mi0Text0.TextContent);

        var dochtml1body1table0caption0math0mi1 = dochtml1body1table0caption0math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi1.NodeType);

        var dochtml1body1table0caption0math0mi1Text0 = dochtml1body1table0caption0math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0math0mi1Text0.TextContent);

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
    public void MathMLImplicitlyClosedInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><math><mi>foo</mi><mi>bar</mi><p>baz</table><p>quux").ToHtmlDocument();

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

        var dochtml1body1table0caption0math0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0caption0math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0caption0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0.NodeType);

        var dochtml1body1table0caption0math0mi0 = dochtml1body1table0caption0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi0.NodeType);

        var dochtml1body1table0caption0math0mi0Text0 = dochtml1body1table0caption0math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0math0mi0Text0.TextContent);

        var dochtml1body1table0caption0math0mi1 = dochtml1body1table0caption0math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi1.NodeType);

        var dochtml1body1table0caption0math0mi1Text0 = dochtml1body1table0caption0math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0math0mi1Text0.TextContent);

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
    public void MathMLInCaptionImplicitlyClosed()
    {
        var doc = (@"<!DOCTYPE html><body><table><caption><math><mi>foo</mi><mi>bar</mi>baz</table><p>quux").ToHtmlDocument();

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

        var dochtml1body1table0caption0math0 = dochtml1body1table0caption0.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml1body1table0caption0math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0caption0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0caption0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0.NodeType);

        var dochtml1body1table0caption0math0mi0 = dochtml1body1table0caption0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi0.NodeType);

        var dochtml1body1table0caption0math0mi0Text0 = dochtml1body1table0caption0math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1table0caption0math0mi0Text0.TextContent);

        var dochtml1body1table0caption0math0mi1 = dochtml1body1table0caption0math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0caption0math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1table0caption0math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1table0caption0math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0caption0math0mi1.NodeType);

        var dochtml1body1table0caption0math0mi1Text0 = dochtml1body1table0caption0math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1table0caption0math0mi1Text0.TextContent);

        var dochtml1body1table0caption0math0Text2 = dochtml1body1table0caption0math0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml1body1table0caption0math0Text2.NodeType);
        Assert.Equal("baz", dochtml1body1table0caption0math0Text2.TextContent);

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
    public void MathMLInColgroupOfTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><colgroup><math><mi>foo</mi><mi>bar</mi><p>baz</table><p>quux").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

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
    public void MathMLInSelectInTable()
    {
        var doc = (@"<!DOCTYPE html><body><table><tr><td><select><math><mi>foo</mi><mi>bar</mi><p>baz</table><p>quux").ToHtmlDocument();

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
    public void MathMLInSelectInTableImplicitlyClosed()
    {
        var doc = (@"<!DOCTYPE html><body><table><select><math><mi>foo</mi><mi>bar</mi><p>baz</table><p>quux").ToHtmlDocument();

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
    public void MathMLOutsideDocumentRoot()
    {
        var doc = (@"<!DOCTYPE html><body></body></html><math><mi>foo</mi><mi>bar</mi><p>baz").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

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
    public void MathMLOutsideDocumentImplicitlyClosed()
    {
        var doc = (@"<!DOCTYPE html><body></body><math><mi>foo</mi><mi>bar</mi><p>baz").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1math0mi0Text0.TextContent);

        var dochtml1body1math0mi1 = dochtml1body1math0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mi1.ChildNodes);
        Assert.Empty(dochtml1body1math0mi1.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi1.NodeType);

        var dochtml1body1math0mi1Text0 = dochtml1body1math0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1math0mi1Text0.TextContent);

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
    public void MathMLInFrameset()
    {
        var doc = (@"<!DOCTYPE html><frameset><math><mi></mi><mi></mi><p><span>").ToHtmlDocument();

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
    public void MathMLOutsideFrameset()
    {
        var doc = (@"<!DOCTYPE html><frameset></frameset><math><mi></mi><mi></mi><p><span>").ToHtmlDocument();

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
    public void MathMLWithXLinkAttributes()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo><math xlink:href=foo></math>").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml1body1.GetAttribute("xlink:href"));

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0.ChildNodes);
        Assert.Single(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var attr = dochtml1body1math0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr);
        Assert.Equal("foo", attr.Value);
        Assert.Null(attr.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr.NamespaceUri);
    }

    [Fact]
    public void MathMLInBodyWithLangAttribute()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><math><mi xml:lang=en xlink:href=foo></mi></math>").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml1body1.GetAttribute("xlink:href"));
        Assert.Equal("en", dochtml1body1.GetAttribute("xml:lang"));

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0mi0.ChildNodes);
        Assert.Equal(2, dochtml1body1math0mi0.Attributes.Length);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var attr1 = dochtml1body1math0mi0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1math0mi0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);
    }

    [Fact]
    public void MathMLWithMiChild()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><math><mi xml:lang=en xlink:href=foo /></math>").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml1body1.GetAttribute("xlink:href"));
        Assert.Equal("en", dochtml1body1.GetAttribute("xml:lang"));

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0mi0.ChildNodes);
        Assert.Equal(2, dochtml1body1math0mi0.Attributes.Length);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var attr1 = dochtml1body1math0mi0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1math0mi0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);
    }

    [Fact]
    public void MathMLWithTextNode()
    {
        var doc = (@"<!DOCTYPE html><body xlink:href=foo xml:lang=en><math><mi xml:lang=en xlink:href=foo />bar</math>").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml1body1.GetAttribute("xlink:href"));
        Assert.Equal("en", dochtml1body1.GetAttribute("xml:lang"));

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0mi0.ChildNodes);
        Assert.Equal(2, dochtml1body1math0mi0.Attributes.Length);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var attr1 = dochtml1body1math0mi0.Attributes.GetNamedItem("href");
        Assert.NotNull(attr1);
        Assert.Equal("foo", attr1.Value);
        Assert.Null(attr1.Prefix);
        Assert.Equal("http://www.w3.org/1999/xlink", attr1.NamespaceUri);

        var attr2 = dochtml1body1math0mi0.Attributes.GetNamedItem("xml:lang");
        Assert.NotNull(attr2);
        Assert.Equal("en", attr2.Value);
        Assert.Equal("xml", attr2.Prefix);
        Assert.Equal("http://www.w3.org/XML/1998/namespace", attr2.NamespaceUri);

        var dochtml1body1math0Text1 = dochtml1body1math0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1math0Text1.NodeType);
        Assert.Equal("bar", dochtml1body1math0Text1.TextContent);
    }
}
