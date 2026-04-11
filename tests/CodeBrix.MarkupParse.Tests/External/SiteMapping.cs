using System;
using System.IO;
using System.Xml;

namespace CodeBrix.MarkupParse.Tests.External; //Was previously: namespace AngleSharp.Core.Tests.External

sealed class SiteMapping
{
    private readonly string _fileName;
    private readonly XmlDocument _xml;

    public SiteMapping(string fileName)
    {
        _fileName = fileName;
        _xml = new XmlDocument();
        var content = File.Exists(fileName) ? File.ReadAllText(_fileName) : "<entries></entries>";
        _xml.LoadXml(content);
    }

    public string this[string url]
    {
        get
        {
            var element = _xml.SelectSingleNode($"//entry[@url='{url}']");
            return element != null ? element.InnerText : null;
        }
    }

    public bool Contains(string url)
    {
        return this[url] != null;
    }

    public void Add(string url, string fileName)
    {
        if (Contains(url) == false)
        {
            var element = _xml.CreateElement("entry");
            element.SetAttribute("url", url);
            element.InnerText = fileName;
            _xml.DocumentElement.AppendChild(element);

            using var writer = File.CreateText(_fileName);
            _xml.Save(writer);
        }
    }
}
