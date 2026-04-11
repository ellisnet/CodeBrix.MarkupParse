using System;

namespace CodeBrix.MarkupParse.Tests;

public static class TestRuntime
{
    public static bool UsePrefetchedTextSource { get; set; } =
        Environment.GetEnvironmentVariable("prefetched") == "true";
}