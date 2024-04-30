using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public interface IMarkdownElement
{
    internal string Accept(IMarkdownRenderer renderer);
}