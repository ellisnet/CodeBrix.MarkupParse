using System.Diagnostics.CodeAnalysis;
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
    //
    // CA2255 warns against [ModuleInitializer] in libraries because eager
    // execution at assembly load can surprise consumers. In this case the
    // behavior is deliberate and required: an HTML parser must be able to
    // decode legacy code pages, and Encoding.RegisterProvider is idempotent
    // and side-effect free for callers.
    [ModuleInitializer]
    [SuppressMessage("Usage", "CA2255:The 'ModuleInitializer' attribute should not be used in libraries",
        Justification = "Eager, idempotent registration of CodePagesEncodingProvider is required for correct HTML decoding and to avoid a parallel-init race.")]
    internal static void EnsureEncodingProviderRegistered()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
}
