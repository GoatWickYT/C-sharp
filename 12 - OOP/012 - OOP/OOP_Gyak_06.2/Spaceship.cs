public abstract class Spaceship
{
    public string Name { get; private set; }

    public Captain Captain { get; private set; }

    public int Speed { get; set; }

    public int Shield { get; set; }


    public Spaceship(string name, Captain captain, int shield)
    {
        Name = name;
        Captain = captain;
        Speed = new Random().Next(100-1000);
        Shield = shield;
    }

    public abstract void Attack(Spaceship enemy);

    public abstract void SelfDestruct();
}
