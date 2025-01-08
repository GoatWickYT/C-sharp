public class Bomber : IPlanes
{
    public string Model { get; set; }
    
    public string Type { get; set; }

    public int Speed { get; private set; } = new Random().Next(100, 1000);

    public int Bombs { get; private set; } = new Random().Next(1, 100);

    public bool OutOfAmmo { get; set; }

    public void Attack()
    {
        if (this.Bombs > 0)
        {
            this.Bombs = this.Bombs - new Random().Next(1,Bombs);
            Console.WriteLine($"Bombs Away! {(this.Bombs != 0 ? $"Bombs left:{Bombs}" : "No more Bombs left")}");
            OutOfAmmo = false;
            if (Bombs <= 0)
            {
                OutOfAmmo = true;
            }
        }
        else
        {
            Console.WriteLine("Out of Bombs");
            OutOfAmmo = true;
        }
    }   
}
