using System;
using System.Collections.Generic;
using System.Text;
using FoggyBalrog.MarkdownGenerator.Rendering;

namespace FoggyBalrog.MarkdownGenerator.Model;

public class MarkdownDocument : List<IMarkdownElement>
{
    public override string ToString()
    {
        return ToString(new DefaultMarkdownRenderer());
    }

    public string ToString(IMarkdownRenderer renderer)
    {
        if (Count == 0)
        {
            return string.Empty;
        }

        var builder = new StringBuilder();

        foreach (var element in this)
        {
            builder.AppendLine(element.Accept(renderer));
        }

        // Remove the last newline
        builder.Length -= Environment.NewLine.Length;

        return builder.ToString();
    }
}
