public class Error
{
    public string Reason { get; set; }

    public int Count { get; set; }

    public Error() { }

    public Error(string reason, int count)
    {
        Reason = reason;
        Count = count;
    }

    public override string ToString()
    {
        return $"Reason: {Reason}\nCount:{Count}";
    }
}