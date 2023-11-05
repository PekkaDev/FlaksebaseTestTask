namespace Transformers;

public class NumberModRule : ITranformerRule<string>
{
    public string Effect { get; }
    public uint Divider { get; }

    public NumberModRule(uint divider, string effect)
    {
        Divider = divider;
        Effect = effect;
    }

    public bool CheckRule(string input)
    {
        if (!uint.TryParse(input, out var number))
            return false;

        return number % Divider == 0;
    }
}