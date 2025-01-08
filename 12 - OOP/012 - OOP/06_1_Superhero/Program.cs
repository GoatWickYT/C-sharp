List<ISuperhero> superheroes = new List<ISuperhero>
{
    new WonderWoman("Diana Prince"),
    new Batman("Bruce Wayne"),
    new BlackWidow("Natasha Romanoff"),
};

for (int i = 0; i < superheroes.Count; i++)
{
    await Task.Delay(1000);
    for (int j = i + 1; j < superheroes.Count; j++)
    {
        ISuperhero attacker = superheroes[i];
        ISuperhero attacked = superheroes[j];
        Console.WriteLine($"\n{attacker.Name} vs. {attacked.Name}");
        Console.WriteLine(attacker.Fight(attacked) ? $"{attacker.Name} wins!" : $"{attacked.Name} wins!");
    }
}