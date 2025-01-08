public class Robogo : Jarmu, IKisGepjarmu
{
    private int MaxSebesseg;

    public Robogo(string rendszam, int sebesseg, int maxsebesseg) : base(sebesseg, rendszam)
    {
        MaxSebesseg = maxsebesseg;
    }

    public override bool GyorshajtottE(int sebessegkorlat)
    {
        return Sebesseg > sebessegkorlat;
    }

    public bool HaladhatItt(int sebesseg)
    {
        return MaxSebesseg >= sebesseg;
    }

    public override string ToString()
    {
        return $"Robogo: {base.ToString()}";
    }
}