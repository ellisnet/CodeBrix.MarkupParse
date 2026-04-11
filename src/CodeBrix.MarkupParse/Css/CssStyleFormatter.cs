using CodeBrix.MarkupParse.Text;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeBrix.MarkupParse.Css; //Was previously: namespace AngleSharp.Css

/// <summary>
/// Represents the standard CSS3 style formatter.
/// </summary>
public sealed class CssStyleFormatter : IStyleFormatter
{
    #region Instance

    /// <summary>
    /// An instance of the CssStyleFormatter.
    /// </summary>
    public static readonly IStyleFormatter Instance = new CssStyleFormatter();

    #endregion

    #region Methods

    string IStyleFormatter.Sheet(IEnumerable<IStyleFormattable> rules)
    {
        var sb = StringBuilderPool.Obtain();
        var sep = Environment.NewLine;

        using (var writer = new StringWriter(sb))
        {
            foreach (var rule in rules)
            {
                rule.ToCss(writer, this);
                writer.Write(sep);
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - sep.Length, sep.Length);
            }
        }
        
        return sb.ToPool();
    }

    string IStyleFormatter.BlockRules(IEnumerable<IStyleFormattable> rules)
    {
        var sb = StringBuilderPool.Obtain().Append(Symbols.CurlyBracketOpen);

        using (var writer = new StringWriter(sb))
        {
            foreach (var rule in rules)
            {
                writer.Write(Symbols.Space);
                rule.ToCss(writer, this);
            }
        }

        return sb.Append(Symbols.Space).Append(Symbols.CurlyBracketClose).ToPool();
    }

    string IStyleFormatter.Declaration(string name, string value, bool important) => string.Concat(name, ": ", string.Concat(value, important ? " !important" : string.Empty));

    string IStyleFormatter.BlockDeclarations(IEnumerable<IStyleFormattable> declarations)
    {
        var sb = StringBuilderPool.Obtain().Append(Symbols.CurlyBracketOpen);

        using (var writer = new StringWriter(sb))
        {
            foreach (var declaration in declarations)
            {
                writer.Write(Symbols.Space);
                declaration.ToCss(writer, this);
                writer.Write(Symbols.Semicolon);
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        return sb.Append(Symbols.Space).Append(Symbols.CurlyBracketClose).ToPool();
    }

    string IStyleFormatter.Rule(string name, string value) => string.Concat(name, " ", value, ";");

    string IStyleFormatter.Rule(string name, string prelude, string rules) => string.Concat(name, " ", string.IsNullOrEmpty(prelude) ? string.Empty : prelude + " ", rules);

    string IStyleFormatter.Comment(string data) => string.Join("/*", data, "*/");

    #endregion
}
