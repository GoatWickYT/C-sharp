namespace Solution.ValidationLibrary.ValidationRules;

public class ISBNRule<T> : IValidationRule<T>
{
    private readonly Regex regex = new Regex(@"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$");

    public string ValidationMessage { get; set; }

    public bool Check(T value) => value is string str && regex.IsMatch(str);
}
