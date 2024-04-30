using FoggyBalrog.MarkdownGenerator.Model;

namespace FoggyBalrog.MarkdownGenerator.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Foo()
    {
        var document = new MarkdownDocument
        {
            new MarkdownHeading(1, "foo"),
            new MarkdownHeading(2, "bar"),
            new MarkdownParagraph("baz"),
            new MarkdownParagraph
            {
                new MarkdownTextSpan("qux", MarkdownTextDecorations.Bold),
                new MarkdownTextSpan("quux", MarkdownTextDecorations.Italic),
                new MarkdownTextSpan("corge", MarkdownTextDecorations.Strikethrough),
                new MarkdownTextSpan("grault", MarkdownTextDecorations.Bold | MarkdownTextDecorations.Italic)
            },
            new MarkdownCodeBlock("csharp", "Console.WriteLine(\"Hello, World!\");"),
            new MarkdownCodeBlock(null, "Console.WriteLine(\"Hello, World!\");")
        };

        string markdown = document.ToString();

        Assert.Equal(@"# foo

## bar

baz

**qux**
_quux_
~~corge~~
**_grault_**

```csharp
Console.WriteLine(""Hello, World!"");
```

```
Console.WriteLine(""Hello, World!"");
```", markdown, ignoreLineEndingDifferences: true);
    }
}