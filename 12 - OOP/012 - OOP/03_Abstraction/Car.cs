public class Car : Vehicle
{ 
    public override void Honk()
    {
        Console.Beep(2000, 800);
    }
    public override void Error()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(400, 300);
        }
    }
}
