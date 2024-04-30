using System;
using System.Text;
using FoggyBalrog.MarkdownGenerator.Model;

namespace FoggyBalrog.MarkdownGenerator.Rendering;

public class DefaultMarkdownRenderer : IMarkdownRenderer
{
    public string Render(MarkdownHeading heading)
    {
        if (heading.Level < 1 || heading.Level > 6)
        {
            throw new InvalidOperationException($"Heading level must be between 1 and 6 included (was {heading.Level})");
        }

        return $"{new string('#', heading.Level)} {heading.Text}";
    }

    public string Render(MarkdownParagraph paragraph)
    {
        var builder = new StringBuilder();

        foreach (var span in paragraph.Spans)
        {
            builder.Append(span.Accept(this));
        }

        return builder.ToString();
    }

    public string Render(MarkdownTextSpan span)
    {
        return span.Text;
    }
}
