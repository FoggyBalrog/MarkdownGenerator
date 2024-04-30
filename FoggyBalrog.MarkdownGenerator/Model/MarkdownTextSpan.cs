using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public record MarkdownTextSpan(string Text, MarkdownTextDecorations Decorations = MarkdownTextDecorations.None) : IMarkdownSpan
{
    string IMarkdownElement.Accept(IMarkdownRenderer renderer)
    {
        return renderer.Render(this);
    }
}

public enum MarkdownTextDecorations
{
    None = 0,
    Bold = 1 << 0,
    Italic = 1 << 1,
    Strikethrough = 1 << 2,
}