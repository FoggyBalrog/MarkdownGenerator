using System.Collections.Generic;
using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public class MarkdownParagraph : List<IMarkdownSpan>, IMarkdownElement
{
    public MarkdownParagraph()
    {
    }
    public MarkdownParagraph(string text)
    {
        Add(new MarkdownTextSpan(text));
    }

    public MarkdownParagraph(params IMarkdownSpan[] spans)
    {
        AddRange(spans);
    }

    string IMarkdownElement.Accept(IMarkdownRenderer renderer)
    {
        return renderer.Render(this);
    }
}
