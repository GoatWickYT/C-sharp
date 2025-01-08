public abstract class Superhero : ISuperhero
{
    public string Name { get; protected set; }

    public int Power { get; private set; } = new Random().Next(0, 99);

    public bool Fight(ISuperhero opponent)
    {
        return this.Power > opponent.Power;
    }
}
