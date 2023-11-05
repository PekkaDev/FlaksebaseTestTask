namespace Transformers;

public interface ITranformerRule<T>
{
    T Effect { get; }
    bool CheckRule(T input);
}