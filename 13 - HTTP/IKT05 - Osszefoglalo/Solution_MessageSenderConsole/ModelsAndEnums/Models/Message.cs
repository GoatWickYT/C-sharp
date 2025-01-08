public class Message
{
    public string Content { get; set; }
    public int System { get; set; }

    public Message()
    { }

    public Message(string content, int system)
    {
        Content = content;
        System = system;
    }
}