namespace Solution.ValidationLibrary.ValidationRules;

public class ISBNRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is not ulong data)
        {
            return false;
        }
        if (data.ToString().Length != 10 && data.ToString().Length != 13)
        {
            return false;
        }
        return data.ToString().All(char.IsDigit);
    }
}
