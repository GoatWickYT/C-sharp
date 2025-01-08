public class AnakinSkywalker : Jedi, Sith
{
    public AnakinSkywalker() :
        base(150, true)
    {
    }

    public void EngeddElAHaragod()
    {
        Ero += new Random().NextDouble() * 10;
    }

    public override bool MegteremtiAzEgyensulyt()
    {
        return Ero > 1000;
    }

    public override string ToString()
    {
        return $"Anakin Skywalker: Ero: {Ero}, Atallhat-e: {AtallhatE}";
    }
}