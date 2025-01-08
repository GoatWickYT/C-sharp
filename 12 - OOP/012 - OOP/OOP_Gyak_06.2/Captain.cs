public class Captain
{
    public string Name { get; set; }

    public Rank Rank { get; set; }

    public Captain()
    {
    }

    public Captain(string name, Rank rank)
    {
        Name = name;
        Rank = rank;
    }
}
