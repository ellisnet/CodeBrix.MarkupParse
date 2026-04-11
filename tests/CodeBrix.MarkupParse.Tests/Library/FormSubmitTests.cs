using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html;
using CodeBrix.MarkupParse.Html.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Dom;
using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class FormSubmitTests
{
    private const string BaseUrl = "http://anglesharp.azurewebsites.net/";

    private static Task<IDocument> LoadDocumentAsync(DocumentRequest request)
    {
        var config = new Configuration().WithDefaultLoader();
        return BrowsingContext.New(config).OpenAsync(request);
    }

    private static Task<IDocument> LoadDocumentAsync(string url)
    {
        var request = DocumentRequest.Get(Url.Create(url));
        return LoadDocumentAsync(request);
    }

    private static Task<IDocument> PostDocumentAsync(Dictionary<string, string> fields, string encType = null)
    {
        return PostDocumentAsync((document, form) =>
        {
            if (encType != null)
            {
                form.Enctype = encType;
            }

            foreach (var field in fields)
            {
                var input = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                input.Name = field.Key;
                input.Value = field.Value;
            }
        });
    }

    private static Task<IDocument> PostDocumentAsync(string content, string encType = null, bool fromButton = false)
    {
        return PostDocumentAsync((_, form) =>
        {
            if (encType != null)
            {
                form.Enctype = encType;
            }

            form.InnerHtml = content;
        }, fromButton);
    }

    private static async Task<IDocument> PostDocumentAsync(Action<IDocument, IHtmlFormElement> fill, bool fromButton = false)
    {
        var config = new Configuration().WithDefaultLoader();
        var document = await BrowsingContext.New(config).OpenNewAsync();
        var form = document.Body.AppendElement(document.CreateElement<IHtmlFormElement>());
        form.Method = "POST";
        form.Action = BaseUrl + "echo";
        fill(document, form);

        if (fromButton)
        {
            var submitter = form.QuerySelector<IHtmlElement>("button") ??
                form.QuerySelector<IHtmlElement>("input[type=submit]") ??
                form.QuerySelector<IHtmlElement>("input[type=image]");
            return await form.SubmitAsync(submitter);
        }

        return await form.SubmitAsync();
    }

    private static Task<IDocument> LoadWithMockAsync(string content, string url, Action<Request> onRequest = null)
    {
        var config = Configuration.Default.With(new MockRequester { OnRequest = onRequest }).WithDefaultLoader();
        return BrowsingContext.New(config).OpenAsync(m => m.Content(content).Address(url));
    }

    private static FileEntry GenerateFile()
    {
        var content = Enumerable.Range(0, 32).Select(m => (byte)m).ToArray();
        var body = new MemoryStream(content);
        return new FileEntry("Filename.txt", body);
    }

    private static FileEntry GenerateFile(int index)
    {
        var content = Enumerable.Range(0, index * 5 + 10).Select(m => (byte)m).ToArray();
        var body = new MemoryStream(content);
        return new FileEntry($"Filename{index + 1}.txt", body);
    }

    private static string Utf8StreamToString(Stream s)
    {
        var data = new byte[s.Length];
        s.ReadExactly(data, 0, data.Length);
        return Encoding.UTF8.GetString(data);
    }

    [Fact]
    public async Task AsUrlEncodedProducesRightAmountOfAmpersands()
    {
        var url = "http://localhost/";
        var document = await LoadWithMockAsync(@"<form method=get>
<input type=button />
<input name=other type=text value=something /><input type=text value=something /><input name=another type=text value=test />
</form>", url);
        var form = document.Forms.OfType<IHtmlFormElement>().FirstOrDefault();
        var result = await form.SubmitAsync();
        Assert.NotNull(result);
        Assert.Equal(url + "?other=something&another=test", result.Url);
    }

    [Fact]
    public async Task PostDoNotEncounterNullReferenceExceptionWithoutName()
    {
        var url = "http://localhost/";
        var document = await LoadWithMockAsync(@"
<form method=""post"">
<input type=""button"" />
</form>", url);
        var form = document.Forms.OfType<IHtmlFormElement>().FirstOrDefault();
        var result = await form.SubmitAsync();
        Assert.NotNull(result);
        Assert.Equal(url, result.Url);
    }

    [Fact]
    public async Task PostUrlencodeNormal()
    {
        if (Helper.IsNetworkAvailable())
        {
            var url = BaseUrl + "PostUrlencodeNormal";
            var document = await LoadDocumentAsync(url);
            Assert.Single(document.Forms);
            var form = document.Forms[0] as HtmlFormElement;
            var name = form.Elements["Name"] as HtmlInputElement;
            var number = form.Elements["Number"] as HtmlInputElement;
            var isactive = form.Elements["IsActive"] as HtmlInputElement;
            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);
            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;
            var response = await form.SubmitAsync();
            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostUrlencodeFile()
    {
        if (Helper.IsNetworkAvailable())
        {
            var url = BaseUrl + "PostUrlencodeFile";
            var document = await LoadDocumentAsync(url);
            Assert.Single(document.Forms);
            var form = document.Forms[0] as HtmlFormElement;
            var name = form.Elements["Name"] as HtmlInputElement;
            var number = form.Elements["Number"] as HtmlInputElement;
            var isactive = form.Elements["IsActive"] as HtmlInputElement;
            var file = form.Elements["File"] as HtmlInputElement;
            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.NotNull(file);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);
            Assert.Equal("file", file.Type);
            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;
            (file.Files as FileList).Add(GenerateFile());
            var response = await form.SubmitAsync();
            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostMultipartNormal()
    {
        if (Helper.IsNetworkAvailable())
        {
            var url = BaseUrl + "PostMultipartNormal";
            var document = await LoadDocumentAsync(url);
            Assert.Single(document.Forms);
            var form = document.Forms[0] as HtmlFormElement;
            var name = form.Elements["Name"] as HtmlInputElement;
            var number = form.Elements["Number"] as HtmlInputElement;
            var isactive = form.Elements["IsActive"] as HtmlInputElement;
            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);
            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;
            var response = await form.SubmitAsync();
            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostMultipartFile()
    {
        if (Helper.IsNetworkAvailable())
        {
            var url = BaseUrl + "PostMultipartFile";
            var document = await LoadDocumentAsync(url);
            Assert.Single(document.Forms);
            var form = document.Forms[0] as HtmlFormElement;
            var name = form.Elements["Name"] as HtmlInputElement;
            var number = form.Elements["Number"] as HtmlInputElement;
            var isactive = form.Elements["IsActive"] as HtmlInputElement;
            var file = form.Elements["File"] as HtmlInputElement;
            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.NotNull(file);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);
            Assert.Equal("file", file.Type);
            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;
            (file.Files as FileList).Add(GenerateFile());
            var response = await form.SubmitAsync();
            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostMultipartFile_DocumentRequest_1173()
    {
        if (Helper.IsNetworkAvailable())
        {
            var address = BaseUrl + "PostMultipartFile";
            var fds = new FormDataSet();

            fds.Append("Name", "Test", "text");
            fds.Append("Number", "1", "number");
            fds.Append("IsActive", "true", "checkbox");
            fds.Append("File", GenerateFile(), "file");

            var request = DocumentRequest.PostAsMultipart(Url.Create(address), fds);
            var response = await LoadDocumentAsync(request);

            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostMultipartFiles()
    {
        if (Helper.IsNetworkAvailable())
        {
            var url = BaseUrl + "PostMultipartFiles";
            var document = await LoadDocumentAsync(url);
            Assert.Single(document.Forms);
            var form = document.Forms[0] as HtmlFormElement;
            var name = form.Elements["Name"] as HtmlInputElement;
            var number = form.Elements["Number"] as HtmlInputElement;
            var isactive = form.Elements["IsActive"] as HtmlInputElement;
            var files = form.Elements["Files"] as HtmlInputElement;
            Assert.NotNull(name);
            Assert.NotNull(number);
            Assert.NotNull(isactive);
            Assert.NotNull(files);
            Assert.Equal("text", name.Type);
            Assert.Equal("number", number.Type);
            Assert.Equal("checkbox", isactive.Type);
            Assert.Equal("file", files.Type);
            Assert.True(files.IsMultiple);
            name.Value = "Test";
            number.Value = "1";
            isactive.IsChecked = true;

            for (var i = 0; i < 5; i++)
            {
                (files.Files as FileList).Add(GenerateFile(i));
            }

            var response = await form.SubmitAsync();
            Assert.NotNull(response);
            Assert.Equal("okay", response.Body.TextContent);
        }
    }

    [Fact]
    public async Task PostStandardTypeShouldEchoAllValuesCorrectly()
    {
        if (Helper.IsNetworkAvailable())
        {
            var fields = new Dictionary<string, string>
            {
                { "myname", "foo" },
                { "bar", "this is some longer text" },
                { "yeti", "0" },
            };
            var result = await PostDocumentAsync(fields);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("myname", rows[0].QuerySelector("th").TextContent);
            Assert.Equal(fields["myname"], rows[0].QuerySelector("td").TextContent);

            Assert.Equal("bar", rows[1].QuerySelector("th").TextContent);
            Assert.Equal(fields["bar"], rows[1].QuerySelector("td").TextContent);

            Assert.Equal("yeti", rows[2].QuerySelector("th").TextContent);
            Assert.Equal(fields["yeti"], rows[2].QuerySelector("td").TextContent);

            Assert.Equal("\nmyname=foo&bar=this+is+some+longer+text&yeti=0\n", raw);
        }
    }

    [Fact]
    public async Task PostTextPlainShouldEchoAllValuesCorrectly()
    {
        if (Helper.IsNetworkAvailable())
        {
            var fields = new Dictionary<string, string>
            {
                { "myname", "foo" },
                { "bar", "this is some longer text" },
                { "yeti", "0" },
            };
            var result = await PostDocumentAsync(fields, MimeTypeNames.Plain);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Empty(rows);
            Assert.Equal("\nmyname=foo\nbar=this is some longer text\nyeti=0\n", raw);
        }
    }

    [Fact]
    public async Task PostMulipartFormdataShouldEchoAllValuesCorrectly()
    {
        if (Helper.IsNetworkAvailable())
        {
            var fields = new Dictionary<string, string>
            {
                { "myname", "foo" },
                { "bar", "this is some longer text" },
                { "yeti", "0" },
            };
            var result = await PostDocumentAsync(fields, MimeTypeNames.MultipartForm);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("myname", rows[0].QuerySelector("th").TextContent);
            Assert.Equal(fields["myname"], rows[0].QuerySelector("td").TextContent);

            Assert.Equal("bar", rows[1].QuerySelector("th").TextContent);
            Assert.Equal(fields["bar"], rows[1].QuerySelector("td").TextContent);

            Assert.Equal("yeti", rows[2].QuerySelector("th").TextContent);
            Assert.Equal(fields["yeti"], rows[2].QuerySelector("td").TextContent);

            var lines = raw.Split('\n');

            Assert.Equal(15, lines.Length);

            var emptyLines = new[] { 0, 3, 7, 11, 14 };
            var sameLines = new[] { 1, 5, 9 };
            var nameLines = new[] { 2, 6, 10 };
            var valueLines = new[] { 4, 8, 12 };

            foreach (var emptyLine in emptyLines)
            {
                Assert.Equal(string.Empty, lines[emptyLine]);
            }

            for (var i = 1; i < sameLines.Length; i++)
            {
                Assert.Equal(lines[sameLines[0]], lines[sameLines[i]]);
            }

            Assert.Equal(lines[sameLines[0]] + "--", lines[lines.Length - 2]);

            for (var i = 0; i < nameLines.Length; i++)
            {
                var field = fields.Skip(i).First();
                Assert.Equal("Content-Disposition: form-data; name=\"" + field.Key + "\"", lines[nameLines[i]]);
                Assert.Equal(field.Value, lines[valueLines[i]]);
            }
        }
    }

    [Fact]
    public async Task PostStandardTypeWithModifiedButtonValueShouldNotEchoTheButtonValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var user = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var pass = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var btn = form.AppendElement(document.CreateElement<IHtmlButtonElement>());
                user.Type = "text";
                user.Name = "username";
                user.Value = "foo";
                pass.Type = "password";
                pass.Name = "password";
                pass.Value = "bar";
                btn.Name = "login";
                btn.Value = "Login";
            }, fromButton: false);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithInitialButtonValueShouldNotEchoTheButtonValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = "<input type=text name=username value='foo'><input type=password name=password value='bar'><button type=submit name=login value=Login>";
            var result = await PostDocumentAsync(source, fromButton: false);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeFromButtonWithModifiedValueShouldEchoTheButtonValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var user = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var pass = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var btn = form.AppendElement(document.CreateElement<IHtmlButtonElement>());
                user.Type = "text";
                user.Name = "username";
                user.Value = "foo";
                pass.Type = "password";
                pass.Name = "password";
                pass.Value = "bar";
                btn.Name = "login";
                btn.Value = "Login";
            }, fromButton: true);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("login", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("Login", rows[2].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar&login=Login\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeFromButtonWithInitialValueShouldEchoTheButtonValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = "<input type=text name=username value='foo'><input type=password name=password value='bar'><button type=submit name=login value=Login>";
            var result = await PostDocumentAsync(source, fromButton: true);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("login", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("Login", rows[2].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar&login=Login\n", raw);
        }
    }

    [Fact]
    public async Task PostFormWithCheckboxArrayAndDefaultRadioValueShouldYieldStandardValues()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = @"<input name=name size=15 type=text value=abc /><TEXTAREA NAME=Address ROWS=3 COLS=30 >
</TEXTAREA><select multiple=multiple name=colors>
<option> RED </option>
<option selected> GREEN </option>
<option> YELLOW </option>
<option> BLUE </option>
<option> ORANGE </option>
</select><input name=""color[]"" type=checkbox value=green checked /> green
<input name=""color[]"" type=checkbox value=red checked /> red
<input name=""color[]"" type=checkbox value=blue checked /> blue<input checked=checked name=answer type=radio /> True
<input name=answer type=radio value=off /> False";
            var result = await PostDocumentAsync(source);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(5, rows.Length);

            Assert.Equal("name", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("abc", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("Address", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("colors", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("GREEN", rows[2].QuerySelector("td").TextContent);

            Assert.Equal("color[]", rows[3].QuerySelector("th").TextContent);
            Assert.Equal("green,red,blue", rows[3].QuerySelector("td").TextContent);

            Assert.Equal("answer", rows[4].QuerySelector("th").TextContent);
            Assert.Equal("on", rows[4].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostFormWithEmptyRadioElementValueShouldYieldEmptyValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = @"<input name=answer type=radio /> On
<input checked=checked name=answer type=radio value='' /> Nothing
<input name=answer type=radio value=false /> False";
            var result = await PostDocumentAsync(source);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Single(rows);

            Assert.Equal("answer", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("", rows[0].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostFormWithEmptyCheckboxElementValueShouldYieldEmptyValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = @"<input checked name=answer type=checkbox /> On
<input checked name=answer type=checkbox value='' /> Nothing
<input name=answer type=checkbox value=false /> False";
            var result = await PostDocumentAsync(source);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Single(rows);

            Assert.Equal("answer", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("on,", rows[0].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostFormWithNoFileShouldSendInputEmptyFileName()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = @"<input type=file name=image>";
            var result = await PostDocumentAsync(source, encType: MimeTypeNames.MultipartForm);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Empty(rows);

            var lines = raw.Split('\n');

            Assert.Equal(8, lines.Length);

            var emptyLines = new[] { 0, 4, 5, 7 };

            foreach (var emptyLine in emptyLines)
            {
                Assert.Equal(string.Empty, lines[emptyLine]);
            }

            Assert.Equal(lines[1] + "--", lines[lines.Length - 2]);
            Assert.Equal("Content-Disposition: form-data; name=\"image\"; filename=\"\"", lines[2]);
            Assert.Equal("Content-Type: application/octet-stream", lines[3]);
        }
    }

    [Fact]
    public async Task PostFormWithSimpleFileShouldSendFileContent()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = Encoding.UTF8.GetBytes("test");
            var result = await PostDocumentAsync((document, form) =>
            {
                var input = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                form.Enctype = MimeTypeNames.MultipartForm;
                input.Name = "image";
                input.Type = "file";
                input.Files.Add(new FileEntry("test.txt", new MemoryStream(content)));
            });
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Empty(rows);

            var lines = raw.Split('\n');

            Assert.Equal(8, lines.Length);

            var emptyLines = new[] { 0, 4, 7 };

            foreach (var emptyLine in emptyLines)
            {
                Assert.Equal(string.Empty, lines[emptyLine]);
            }

            Assert.Equal(lines[1] + "--", lines[lines.Length - 2]);
            Assert.Equal("Content-Disposition: form-data; name=\"image\"; filename=\"test.txt\"", lines[2]);
            Assert.Equal("Content-Type: text/plain", lines[3]);
            Assert.Equal("test", lines[5]);
        }
    }

    [Fact]
    public async Task PostFormWithFileFieldWithoutNameShouldNotSendAnything()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = Encoding.UTF8.GetBytes("test");
            var result = await PostDocumentAsync((document, form) =>
            {
                var input = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                form.Enctype = MimeTypeNames.MultipartForm;
                input.Type = "file";
                input.Files.Add(new FileEntry("test.txt", new MemoryStream(content)));
            });
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Empty(rows);

            var lines = raw.Split('\n');

            Assert.Equal(3, lines.Length);

            var emptyLines = new[] { 0, 2 };

            foreach (var emptyLine in emptyLines)
            {
                Assert.Equal(string.Empty, lines[emptyLine]);
            }
        }
    }

    [Fact]
    public async Task PostStandardTypeWithInitialInputSubmitShouldNotEchoTheInputValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var source = "<input type=text name=username value='foo'><input type=password name=password value='bar'><input type=submit name=login value=Login>";
            var result = await PostDocumentAsync(source, fromButton: false);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeFromInputSubmitWithModifiedValueShouldEchoTheInputValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var user = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var pass = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                var btn = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                user.Type = "text";
                user.Name = "username";
                user.Value = "foo";
                pass.Type = "password";
                pass.Name = "password";
                pass.Value = "bar";
                btn.Name = "login";
                btn.Type = "submit";
                btn.Value = "Login";
            }, fromButton: true);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("login", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("Login", rows[2].QuerySelector("td").TextContent);

            Assert.Equal("\nusername=foo&password=bar&login=Login\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithAttributeEmptyCheckboxValueShouldSendEmptyValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var check = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                check.Type = "checkbox";
                check.Name = "test";
                check.SetAttribute("checked", "");
                check.SetAttribute("value", "");
            });
            var rows = result.QuerySelectorAll("tr");

            Assert.Single(rows);

            Assert.Equal("test", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("", rows[0].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithSetNonEmptyCheckboxValueShouldSendNonEmptyValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var check = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                check.Type = "checkbox";
                check.Name = "test";
                check.SetAttribute("checked", "");
                check.Value = "foo";
            });
            var rows = result.QuerySelectorAll("tr");

            Assert.Single(rows);

            Assert.Equal("test", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithSetEmptyCheckboxValueShouldSendEmptyValue()
    {
        if (Helper.IsNetworkAvailable())
        {
            var result = await PostDocumentAsync((document, form) =>
            {
                var check = form.AppendElement(document.CreateElement<IHtmlInputElement>());
                check.Type = "checkbox";
                check.Name = "test";
                check.IsChecked = true;
                check.SetAttribute("value", "foo");
                check.Value = "";
            });
            var rows = result.QuerySelectorAll("tr");

            Assert.Single(rows);

            Assert.Equal("test", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("", rows[0].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithNamesButMissingValueShouldOmitRedundantAmpersand()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input name=foo value><input name=nothing><input name=bar value>";
            var result = await PostDocumentAsync(content);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("foo", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("nothing", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("bar", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("", rows[2].QuerySelector("td").TextContent);

            Assert.Equal("\nfoo=&nothing=&bar=\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithoutNamesShouldOmitRedundantAmpersand()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input name=foo><input><input name=bar>";
            var result = await PostDocumentAsync(content);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("foo", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("bar", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("\nfoo=&bar=\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithoutFileShouldSkipRedundantAmpersand()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input type=hidden name=status1 value=1><input type=file name=photo><input type=hidden name=status2 value=1>";
            var result = await PostDocumentAsync(content);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("status1", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("1", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("status2", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("1", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("\nstatus1=1&status2=1\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithImageTypeNotPressedShouldSupressEverything()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input type=image name=foo value=bar>";
            var result = await PostDocumentAsync(content);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Empty(rows);

            Assert.Equal("\n\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithImageTypePressedShouldShowEverything()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input type=image name=foo value=bar>";
            var result = await PostDocumentAsync(content, fromButton: true);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(3, rows.Length);

            Assert.Equal("\nfoo.x=0&foo.y=0&foo=bar\n", raw);
        }
    }

    [Fact]
    public async Task PostStandardTypeWithImageTypeWithoutValuePressedShouldShowXy()
    {
        if (Helper.IsNetworkAvailable())
        {
            var content = "<input type=image name=foo>";
            var result = await PostDocumentAsync(content, fromButton: true);
            var rows = result.QuerySelectorAll("tr");
            var raw = result.QuerySelector("#input").TextContent;

            Assert.Equal(2, rows.Length);

            Assert.Equal("\nfoo.x=0&foo.y=0\n", raw);
        }
    }

    [Fact]
    public async Task AsJsonExample1BasicKeys()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='name' value='Bender'>
  <select name='hind'>
    <option selected>Bitable</option>
    <option>Kickable</option>
  </select>
  <input type='checkbox' name='shiny' checked>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"name\":\"Bender\",\"hind\":\"Bitable\",\"shiny\":true}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample2MultipleValues()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input type='number' name='bottle-on-wall' value='1'>
  <input type='number' name='bottle-on-wall' value='2'>
  <input type='number' name='bottle-on-wall' value='3'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"bottle-on-wall\":[1,2,3]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample3DeeperStructure()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='pet[species]' value='Dahut'>
  <input name='pet[name]' value='Hypatia'>
  <input name='kids[1]' value='Thelma'>
  <input name='kids[0]' value='Ashley'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"pet\":{\"species\":\"Dahut\",\"name\":\"Hypatia\"},\"kids\":[\"Ashley\",\"Thelma\"]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample4SparseArrays()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='hearbeat[0]' value='thunk'>
  <input name='hearbeat[2]' value='thunk'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"hearbeat\":[\"thunk\",null,\"thunk\"]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample5EvenDeeper()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='pet[0][species]' value='Dahut'>
  <input name='pet[0][name]' value='Hypatia'>
  <input name='pet[1][species]' value='Felis Stultus'>
  <input name='pet[1][name]' value='Billie'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"pet\":[{\"species\":\"Dahut\",\"name\":\"Hypatia\"},{\"species\":\"Felis Stultus\",\"name\":\"Billie\"}]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample6SuchDeep()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='wow[such][deep][3][much][power][!]' value='Amaze'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"wow\":{\"such\":{\"deep\":[null,null,null,{\"much\":{\"power\":{\"!\":\"Amaze\"}}}]}}}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample7MergeBehaviour()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='mix' value='scalar'>
  <input name='mix[0]' value='array 1'>
  <input name='mix[2]' value='array 2'>
  <input name='mix[key]' value='key key'>
  <input name='mix[car]' value='car key'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"mix\":{\"\":\"scalar\",\"0\":\"array 1\",\"2\":\"array 2\",\"key\":\"key key\",\"car\":\"car key\"}}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample8Append()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='highlander[]' value='one'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"highlander\":[\"one\"]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample9Files()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input type='file' name='file' multiple>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        var file = form.Elements["file"] as HtmlInputElement;
        Assert.NotNull(file);
        Assert.Equal("file", file.Type);

        var files = file.Files as FileList;
        files.Add(new FileEntry("dahut.txt", new MemoryStream(Convert.FromBase64String("REFBQUFBQUFIVVVVVVVVVVVVVCEhIQo="))));
        files.Add(new FileEntry("litany.txt", new MemoryStream(Convert.FromBase64String("SSBtdXN0IG5vdCBmZWFyLlxuRmVhciBpcyB0aGUgbWluZC1raWxsZXIuCg=="))));

        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"file\":[{\"type\":\"text/plain\",\"name\":\"dahut.txt\",\"body\":\"REFBQUFBQUFIVVVVVVVVVVVVVCEhIQo=\"},{\"type\":\"text/plain\",\"name\":\"litany.txt\",\"body\":\"SSBtdXN0IG5vdCBmZWFyLlxuRmVhciBpcyB0aGUgbWluZC1raWxsZXIuCg==\"}]}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task AsJsonExample10BadInput()
    {
        var request = default(Request);
        var onRequest = new Action<Request>(r => request = r);
        var url = "http://localhost/";

        var document = await LoadWithMockAsync(@"<form enctype='application/json' method='post'>
  <input name='error[good]' value='BOOM!'>
  <input name='error[bad' value='BOOM BOOM!'>
</form>", url, onRequest);

        var form = document.Forms[0] as HtmlFormElement;
        await form.SubmitAsync();
        Assert.NotNull(request);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("{\"error\":{\"good\":\"BOOM!\"},\"error[bad\":\"BOOM BOOM!\"}", Utf8StreamToString(request.Content));
    }

    [Fact]
    public async Task PostStandardTypeFromButtonViaExtensionMethodWithoutFields()
    {
        if (Helper.IsNetworkAvailable())
        {
            var target = BaseUrl + "echo";
            var source = "<form method=POST action='" + target + "'><input type=text name=username value='foo'><input type=password name=password value='bar'><button type=submit name=login value=Login></form>";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(res => res.Content(source).Address(target), TestContext.Current.CancellationToken);
            var result = await document.QuerySelector<IHtmlButtonElement>("button").SubmitAsync();

            var rows = result.QuerySelectorAll("tr");
            Assert.Equal(3, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("foo", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("bar", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("login", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("Login", rows[2].QuerySelector("td").TextContent);
        }
    }

    [Fact]
    public async Task PostStandardTypeFromButtonViaExtensionMethodWithFields()
    {
        if (Helper.IsNetworkAvailable())
        {
            var target = BaseUrl + "echo";
            var source = "<form method=POST action='" + target + "'><input type=text name=username value='foo'><input type=password name=password value='bar'><button type=submit name=login value=Login></form>";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(res => res.Content(source).Address(target), TestContext.Current.CancellationToken);
            var result = await document.QuerySelector<IHtmlButtonElement>("button").SubmitAsync(new
            {
                username = "Test",
                password = "Baz"
            });

            var rows = result.QuerySelectorAll("tr");
            Assert.Equal(3, rows.Length);

            Assert.Equal("username", rows[0].QuerySelector("th").TextContent);
            Assert.Equal("Test", rows[0].QuerySelector("td").TextContent);

            Assert.Equal("password", rows[1].QuerySelector("th").TextContent);
            Assert.Equal("Baz", rows[1].QuerySelector("td").TextContent);

            Assert.Equal("login", rows[2].QuerySelector("th").TextContent);
            Assert.Equal("Login", rows[2].QuerySelector("td").TextContent);
        }
    }
}
