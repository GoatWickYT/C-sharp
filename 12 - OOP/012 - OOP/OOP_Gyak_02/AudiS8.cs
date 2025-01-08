public class AudiS8 : Jarmu
{
    private bool Lezerblokkolo;

    public AudiS8(string rendszam, int sebesseg, bool lezerblokkolo) : base(sebesseg, rendszam)
    {
        Lezerblokkolo = lezerblokkolo;
    }

    public override bool GyorshajtottE(int sebessegkorlat)
    {
        return Sebesseg > sebessegkorlat && !Lezerblokkolo;
    }

    public override string ToString()
    {
        return $"AudiS8: {base.ToString()}";
    }
}