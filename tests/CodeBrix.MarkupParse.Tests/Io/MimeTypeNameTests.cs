using CodeBrix.MarkupParse.Io;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Io; //Was previously: namespace AngleSharp.Core.Tests.Io

public class MimeTypeNameTests
{
    [Fact]
    public void CommonMimeTypesAreCorrectlyDefined()
    {
        Assert.Equal("image/apng", MimeTypeNames.FromExtension(".apng"));
        Assert.Equal("image/avif", MimeTypeNames.FromExtension(".avif"));
        Assert.Equal("image/gif", MimeTypeNames.FromExtension(".gif"));
        Assert.Equal("image/jpeg", MimeTypeNames.FromExtension(".jpeg"));
        Assert.Equal("image/jpeg", MimeTypeNames.FromExtension(".jpg"));
        Assert.Equal("image/jxl", MimeTypeNames.FromExtension(".jxl"));
        Assert.Equal("image/png", MimeTypeNames.FromExtension(".png"));
        Assert.Equal("image/svg+xml", MimeTypeNames.FromExtension(".svg"));
        Assert.Equal("image/webp", MimeTypeNames.FromExtension(".webp"));
    }
}
