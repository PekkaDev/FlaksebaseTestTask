namespace Transformers;

public class ComplexNumberModeRule : ITranformerRule<string>
{
    public string Effect => _matchedRuleEffects.Count == Rules.Count
                            ? _allMatchingEffect
                            : string.Join("-", _matchedRuleEffects);
    public IReadOnlyCollection<ITranformerRule<string>> Rules { get; }

    private string _allMatchingEffect;
    private IList<string> _matchedRuleEffects;

    public ComplexNumberModeRule(string effect, params ITranformerRule<string>[] rules)
    {
        _allMatchingEffect = effect;
        Rules = rules;
        _matchedRuleEffects = new List<string>();
    }

    public bool CheckRule(string input)
    {
        _matchedRuleEffects = Rules
            .Where(it => it.CheckRule(input))
            .Select(it => it.Effect)
            .ToList();
        return _matchedRuleEffects.Count > 0;
    }
}