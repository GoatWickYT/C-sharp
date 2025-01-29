namespace Solution.ValidationLibrary;

public interface IObjectValidator<TKey>
{
    public TKey Id { get; set; }
}
