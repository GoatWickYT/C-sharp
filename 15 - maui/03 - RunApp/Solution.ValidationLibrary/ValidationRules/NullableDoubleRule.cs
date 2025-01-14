namespace MauiValidationLibrary.ValidationRules;

public class NullableDoubleRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if(value is not double data)
        { 
            return false;
        }
        
        return !string.IsNullOrEmpty(data.ToString());
    }
}
