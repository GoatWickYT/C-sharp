public class StoredMessage
{
    [JsonPropertyName("system")]
    public string System { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    public StoredMessage() { }

    public StoredMessage(string system, string firstName, string lastName, string mobileNumber, string message)
    {
        System = system;
        FirstName = firstName;
        LastName = lastName;
        MobileNumber = mobileNumber;
        Message = message;
    }
}