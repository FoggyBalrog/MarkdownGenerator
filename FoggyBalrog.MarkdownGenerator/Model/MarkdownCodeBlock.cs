using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public record MarkdownCodeBlock(string? Language, string Content) : IMarkdownElement
{
    string IMarkdownElement.Accept(IMarkdownRenderer renderer)
    {
        return renderer.Render(this);
    }
}
