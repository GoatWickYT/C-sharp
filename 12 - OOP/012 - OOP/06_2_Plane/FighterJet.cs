public class FighterJet : IPlanes
{
    public string Model { get; set; }
    
    public string Type { get; set; }

    public int Speed { get; private set; } = new Random().Next(100, 1000);

    public int Missiles { get; private set; } = new Random().Next(1, 6);

    public bool OutOfAmmo { get; set; }

    public void Attack()
    {
        if (this.Missiles > 0)
        {
            this.Missiles--;
            Console.WriteLine($"Missiles Fired! {(this.Missiles != 0? $"Missiles left:{Missiles}": "No more Missiles left")}");
            OutOfAmmo = false;
            if (Missiles == 0)
            {
                OutOfAmmo = true;
            }
        }
        else
        {
            Console.WriteLine("Out of Missiles");
            OutOfAmmo = true;
        }
    }
}
