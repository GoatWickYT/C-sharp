List<IPlanes> planes = new List<IPlanes>()
{
    new FighterJet() { Model = "F-22", Type = "Fighter" },
    new FighterJet() { Model = "A-10 Warthog", Type = "Fighter" },
    new FighterJet() { Model = "F-22 Raptor", Type = "Fighter"},
    new FighterJet() { Model = "F-15", Type = "Fighter"},
    new FighterJet() { Model = "F-35", Type = "Fighter" },
    new Bomber() { Model = "B-2", Type = "Bomber" },
    new Bomber() { Model = "B-52", Type = "Bomber" }
};

char choice = '0';
bool[] outOfAmmo = new bool[planes.Count];
do
{
    Console.WriteLine("Press any button to Attack (Press 'E' to leave)");
    choice = Console.ReadKey().KeyChar;
    Console.Clear();
    int pilotNumber = 0;
    if (choice == 'E' || choice == 'e')
    {
        break;
    }
    if (!outOfAmmo.Any(outOfAmmo => outOfAmmo == false)){
        Console.WriteLine("All Pilots are out of Ammo, returning to base!");
        break;
    }
    foreach (var plane in planes)
    {
        pilotNumber++;
        Console.WriteLine($"Pilot-{plane.Type[0]}{pilotNumber} ({plane.Model} {plane.Type}):");
        plane.Attack();
        outOfAmmo[pilotNumber-1] = plane.OutOfAmmo;
        Console.WriteLine();
    }
} while (true);