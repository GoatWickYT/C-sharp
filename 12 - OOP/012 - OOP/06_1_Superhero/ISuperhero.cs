public interface ISuperhero
{
    String Name { get; }

    int Power { get; }

    bool Fight(ISuperhero opponent);
}
