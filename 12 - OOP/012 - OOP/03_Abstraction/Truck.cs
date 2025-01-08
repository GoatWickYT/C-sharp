public class Truck : Vehicle
{
    public override void Honk()
    {
        Console.Beep(200, 800);
    }
    public override void Error()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Beep(500, 500);
        }
    }
}
