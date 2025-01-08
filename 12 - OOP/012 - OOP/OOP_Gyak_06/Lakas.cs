public abstract class Lakas : IIngatlan
{
    protected int Terulet;
    protected int SzobaSzam;
    protected int Lakok;
    protected int NegyzetMeterAr;

    public Lakas(int terulet, int szobaSzam, int lakok, int nmeterAr)
    {
        Terulet = terulet;
        SzobaSzam = szobaSzam;
        Lakok = lakok;
        NegyzetMeterAr = nmeterAr;
    }

    public abstract bool Bekoltozik(int bekoltozok);

    public int OsszesKoltseg()
    {
        return Terulet * NegyzetMeterAr;
    }

    public int LakokSzama()
    {
        return Lakok;
    }

    public override string ToString()
    {
        return $"Terulet: {Terulet}, Szobak szama: {SzobaSzam}, Lakok szama: {Lakok}, Nm/Ar: {NegyzetMeterAr}";
    }
}
