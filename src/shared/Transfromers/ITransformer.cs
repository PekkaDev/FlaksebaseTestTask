namespace Transformers;

public interface ITranformer<T>
{
    IReadOnlyList<ITranformerRule<T>> Rules { get; }
    T Transform(T input);
}