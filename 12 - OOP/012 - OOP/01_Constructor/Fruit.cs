public class Fruit
{
    public string Name { get; set; }

    public int Calories { get; set; }

    public double Price { get; set; }

    public List<string> Importers { get; private set; } = new List<string>();

    public bool HasImporters => Importers.Any();

    public Fruit()
    {
        //Importers = new List<string>();
    }

    public Fruit(string name, int calories, double price)//: this()
    {
        this.Name = name;
        this.Calories = calories;
        this.Price = price;
    }

    public Fruit(Fruit fruit) : this(fruit.Name, fruit.Calories, fruit.Price)
    {
    }
}
