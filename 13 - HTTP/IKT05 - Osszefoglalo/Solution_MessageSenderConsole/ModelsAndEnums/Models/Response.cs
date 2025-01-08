public class Response
{
    [JsonPropertyName("success")]
    public bool IsSuccessful { get; set; }

    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; }

    [JsonPropertyName("dateTime")]
    public DateTime DateTime { get; set; }

    override public string ToString()
    {
        return $"Was Successful: {IsSuccessful}, ErrorMessage: {ErrorMessage}, DateTime: {DateTime}";
    }
}