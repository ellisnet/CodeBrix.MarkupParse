using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Media;
using System;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

class MockImageInfo : IImageInfo
{
    public int Width => 0;

    public int Height => 0;

    public Url Source
    {
        get;
        set;
    }
}
