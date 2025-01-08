public class Tarsashaz
{
    private ICollection<IIngatlan> ingatlanok = new List<IIngatlan>();

    private int maxLakas;

    private int maxGarazs;



    public Tarsashaz(int maxLakas, int maxGarazs)
    {
        this.maxLakas = maxLakas;
        this.maxGarazs = maxGarazs;
    }

    public bool LakasHozzaad(Lakas lakas)
    {
        if (maxLakas > ingatlanok.Count)
        {
            ingatlanok.Add(lakas);
            return true;
        }
        return false;
    }

    public bool GarazsHozzaad(Garazs garazs)
    {
        if (maxGarazs > ingatlanok.Count)
        {
            ingatlanok.Add(garazs);
            return true;
        }
        return false;
    }

    public int OsszesLako()
    {
        int osszLako = 0;
        foreach (var ingatlan in ingatlanok)
        {
            if (ingatlan is Lakas)
            {
                osszLako += (ingatlan as Lakas).LakokSzama();
            }
        }
        return osszLako;
    }

    public int IngatlanErtek()
    {
        int ertek = 0;
        foreach (var ingatlan in ingatlanok)
        {
            if (ingatlan is Lakas)
            {
                if ((ingatlan as Lakas).LakokSzama() > 0)
                {
                    ertek += (ingatlan as Lakas).OsszesKoltseg();
                }
            }
            else
            {
                if ((ingatlan as Garazs).LefoglaltE())
                {
                    ertek += (ingatlan as Garazs).OsszesKoltseg();
                }
            }
        }
        return ertek;
    }
}