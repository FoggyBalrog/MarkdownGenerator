using FoggyBalrog.MarkdownGenerator.Model;

namespace FoggyBalrog.MarkdownGenerator.Rendering;

public interface IMarkdownRenderer
{
    string Render(MarkdownHeading heading);
    string Render(MarkdownParagraph paragraph);
    string Render(MarkdownTextSpan span);
}
