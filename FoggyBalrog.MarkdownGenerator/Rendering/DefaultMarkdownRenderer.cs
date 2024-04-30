using System;
using System.Text;
using FoggyBalrog.MarkdownGenerator.Model;

namespace FoggyBalrog.MarkdownGenerator.Rendering;

public class DefaultMarkdownRenderer : IMarkdownRenderer
{
    public string Render(MarkdownDocument document)
    {
        var builder = new StringBuilder();

        foreach (var element in document)
        {
            builder.AppendLine(element.Accept(this));
        }

        // Trim all trailing newlines (\r and \n) from the end of the document
        while (builder.Length > 0 && (builder[^1] == '\r' || builder[^1] == '\n'))
        {
            builder.Length--;
        }

        return builder.ToString();
    }

    public string Render(MarkdownHeading heading)
    {
        if (heading.Level < 1 || heading.Level > 6)
        {
            throw new InvalidOperationException($"Heading level must be between 1 and 6 included (was {heading.Level})");
        }

        return $"{new string('#', heading.Level)} {heading.Text}{Environment.NewLine}";
    }

    public string Render(MarkdownParagraph paragraph)
    {
        var builder = new StringBuilder();

        foreach (var span in paragraph)
        {
            builder.AppendLine(span.Accept(this));
        }

        return builder.ToString();
    }

    public string Render(MarkdownTextSpan span)
    {
        string boldDecorator = "**";
        string italicDecorator = "_";
        string strikethroughDecorator = "~~";

        var builder = new StringBuilder();

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Bold))
        {
            builder.Append(boldDecorator);
        }

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Italic))
        {
            builder.Append(italicDecorator);
        }

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Strikethrough))
        {
            builder.Append(strikethroughDecorator);
        }

        builder.Append(span.Text);

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Strikethrough))
        {
            builder.Append(strikethroughDecorator);
        }

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Italic))
        {
            builder.Append(italicDecorator);
        }

        if (span.Decorations.HasFlag(MarkdownTextDecorations.Bold))
        {
            builder.Append(boldDecorator);
        }

        return builder.ToString();
    }

    public string Render(MarkdownCodeBlock codeBlock)
    {
        return $"```{codeBlock.Language}{Environment.NewLine}{codeBlock.Content}{Environment.NewLine}```{Environment.NewLine}";
    }
}
