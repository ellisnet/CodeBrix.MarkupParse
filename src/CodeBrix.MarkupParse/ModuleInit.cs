using System.Runtime.CompilerServices;
using System.Text;

namespace CodeBrix.MarkupParse;

internal static class ModuleInit
{
    // Registers CodePagesEncodingProvider once, eagerly, at assembly load --
    // before any other code in this assembly can run. Guarantees that all
    // legacy code pages (GB2312, Shift-JIS, Windows-125x, Big5, etc.) are
    // available without depending on any particular type being constructed
    // first. Fixes a parallel-test ordering race in CodeBrix.MarkupParse.Tests
    // that was exposed under CPU pressure.
    [ModuleInitializer]
    internal static void EnsureEncodingProviderRegistered()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
}
