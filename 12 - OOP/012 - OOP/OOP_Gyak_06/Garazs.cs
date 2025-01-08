public class Garazs : IBerelheto, IIngatlan
{

    private int terulet;
    private int negyzetMeterAr;
    private bool futott;
    private int foglaltHonapokSzama;
    private bool allBenneAuto;

    public Garazs(int terulet, int negyzetMeterAr, bool futott)
    {
        this.terulet = terulet;
        this.negyzetMeterAr = negyzetMeterAr;
        this.futott = futott;
        this.foglaltHonapokSzama = 0;
        this.allBenneAuto = false;
    }

    public bool Lefoglal(int honapokSzama)
    {
        if (LefoglaltE())
        {
            return false;
        }
        foglaltHonapokSzama = honapokSzama;
        return true;
    }

    public bool LefoglaltE()
    {
        return foglaltHonapokSzama != 0 || allBenneAuto;
    }

    public int MennyibeKerul(int honapokSzama)
    {
        return futott?(int)(terulet * negyzetMeterAr * 1.5 * honapokSzama):(int)(terulet * negyzetMeterAr * honapokSzama);
    }

    public int OsszesKoltseg()
    {
        return terulet * negyzetMeterAr;
    }

    public void AutoKiBeAll()
    {
        allBenneAuto = !allBenneAuto;
    }

    public override string ToString()
    {
        return $"Terulet: {terulet}, Négyzetméterár: {negyzetMeterAr}, Futott-e már: {futott}, Foglalt hónapok száma: {foglaltHonapokSzama}, Benne áll-e autó: {allBenneAuto}";
    }
}