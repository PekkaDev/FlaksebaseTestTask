using System.Text;

namespace Transformers;

public class StringTransformer : ITranformer<string>
{
    public IReadOnlyList<ITranformerRule<string>> Rules { get; }

    public StringTransformer(params ITranformerRule<string>[] rules)
    {
        Rules = rules;
    }

    public string Transform(string input)
    {
        var result = new StringBuilder(input.Length);
        foreach (var element in input.Split(", "))
        {
            result.Append(TransformElement(element));
            result.Append(", ");
        }
        return result.ToString(0, result.Length - 2);
    }

    private string TransformElement(string element)
    {
        var effects = Rules
            .Where(it => it.CheckRule(element))
            .Select(it => it.Effect);
        var joined = string.Join('-', effects);
        return string.IsNullOrEmpty(joined)
            ? element
            : joined;
    }
}
