public abstract class Jarmu
{
    protected int Sebesseg;
    private string Rendszam;

    public Jarmu(int sebesseg, string rendszam)
    {
        Sebesseg = sebesseg;
        Rendszam = rendszam;
    }

    public abstract bool GyorshajtottE(int sebessegkorlat);

    public override string ToString()
    {
        return $"{Rendszam} - {Sebesseg} km/h";
    }
}