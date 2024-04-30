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
            }
        };

        string markdown = document.ToString();

        Assert.Equal(@"aaa", markdown, ignoreLineEndingDifferences: true);
    }
}