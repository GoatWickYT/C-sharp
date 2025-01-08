public class Rocinante : Spaceship, IIonDrive
{
    private int gunPower = new Random().Next(100, 1000);

    public Rocinante(string name, Captain captain, int shield) : base(name, captain, shield)
    {
    }

    public override void Attack(Spaceship enemy)
    {
        if (enemy.Speed <= Speed)
        {
            Console.WriteLine($"{this.Name} has attacked {enemy.Name}");
            if (gunPower > enemy.Shield)
            {
                Console.WriteLine($"{this.Name} has defeated {enemy.Name}");
                enemy.SelfDestruct();
            }
            else
            {
                Console.WriteLine($"{enemy.Name} has survived the attack, damage dealt :{enemy.Shield - this.gunPower}/{enemy.Shield}");
                enemy.Shield -= this.gunPower;
            }
        }
        else
        {
            Console.WriteLine($"{enemy.Name} has fled");
        }
    }

    public void JumpToIonSpeed()
    {
        this.Speed += 5;
    }

    public override void SelfDestruct()
    {
        Console.WriteLine($"{this.Name} destroyed");
        this.Speed = 0;
        this.Shield = 0;
        gunPower = 0;
    }
}
