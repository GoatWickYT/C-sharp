public class Alberlet : Lakas, IBerelheto
{
    private int foglaltHonapokSzama;

    public Alberlet(int terulet, int szobaSzam, int nmeterAr) : base(terulet, szobaSzam, 0, nmeterAr)
    {
        this.foglaltHonapokSzama = 0;
    }

    public bool LefoglaltE()
    {
        return foglaltHonapokSzama != 0;
    }

    public bool Lefoglal(int honapokSzama)
    {
        if (LefoglaltE())
        {
            return false;
        }
        else
        {
            foglaltHonapokSzama = honapokSzama;
            return true;
        }
    }

    public int MennyibeKerul(int honapokSzama)
    {
        return (int)Math.Ceiling( (double)OsszesKoltseg() / (double)LakokSzama() );
    }

    public override bool Bekoltozik(int bekoltozok)
    {
        if( SzobaSzam *8 <= bekoltozok && Terulet >= bekoltozok * 2)
        {
            Lakok = bekoltozok;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Lefoglalt hónapok száma: {foglaltHonapokSzama}\n{base.ToString()}";
    }
}