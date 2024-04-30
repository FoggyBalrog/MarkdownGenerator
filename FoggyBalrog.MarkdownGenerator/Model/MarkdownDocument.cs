using System.Collections.Generic;
using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public class MarkdownDocument : List<IMarkdownElement>, IMarkdownElement
{
    public override string ToString()
    {
        return ToString(new DefaultMarkdownRenderer());
    }

    public string ToString(IMarkdownRenderer renderer)
    {
        return ((IMarkdownElement)this).Accept(renderer);
    }

    string IMarkdownElement.Accept(IMarkdownRenderer renderer)
    {
        return renderer.Render(this);
    }
}
