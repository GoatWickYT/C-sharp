public abstract class Vehicle
{
    public virtual void Honk()
    {
        Console.Beep(1000, 800);
    }
    public abstract void Error();
}
