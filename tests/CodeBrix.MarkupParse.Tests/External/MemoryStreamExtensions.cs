using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeBrix.MarkupParse.Tests.External; //Was previously: namespace AngleSharp.Core.Tests.External

static class MemoryStreamExtensions
{
    public static int ReadInt(this MemoryStream ms)
    {
        var buffer = new byte[4];
        ms.Read(buffer, 0, 4);
        return BitConverter.ToInt32(buffer, 0);
    }

    public static string ReadString(this MemoryStream ms)
    {
        var length = ReadInt(ms);
        var buffer = new byte[length];
        ms.Read(buffer, 0, length);
        return Encoding.UTF8.GetString(buffer);
    }

    public static Dictionary<string, string> ReadDictionary(this MemoryStream ms)
    {
        var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var headers = ms.ReadInt();

        for (var i = 0; i < headers; i++)
        {
            var key = ms.ReadString();
            var val = ms.ReadString();
            dictionary.Add(key, val);
        }

        return dictionary;
    }

    public static void Write(this MemoryStream ms, int value)
    {
        ms.Write(BitConverter.GetBytes(value));
    }

    public static void Write(this MemoryStream ms, byte[] buffer)
    {
        ms.Write(buffer, 0, buffer.Length);
    }

    public static void Write(this MemoryStream ms, string content)
    {
        var buffer = Encoding.UTF8.GetBytes(content);
        Write(ms, BitConverter.GetBytes(buffer.Length));
        Write(ms, buffer);
    }

    public static void Write(this MemoryStream ms, IDictionary<string, string> dict)
    {
        ms.Write(dict.Count);

        foreach (var pair in dict)
        {
            ms.Write(pair.Key);
            ms.Write(pair.Value);
        }
    }
}
