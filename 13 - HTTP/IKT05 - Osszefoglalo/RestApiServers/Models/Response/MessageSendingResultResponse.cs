public class MessageSendingResultResponse
{
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public DateTime DateTime => DateTime.Now;
}
