using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public record MarkdownHeading(int Level, string Text) : IMarkdownElement
{
    string IMarkdownElement.Accept(IMarkdownRenderer renderer)
    {
        return renderer.Render(this);
    }
}
