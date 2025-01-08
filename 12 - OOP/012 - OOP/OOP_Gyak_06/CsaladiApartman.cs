public class CsaladiApartman : Lakas
{

    public int GyerekekSzama { get; private set; }

    public CsaladiApartman(int terulet, int szobaSzam, int nmeterAr) : base(terulet, szobaSzam, 0, nmeterAr)
    {
        this.GyerekekSzama = 0;
    }

    public bool GyerekSzuletik()
    {
        if (Lakok >= 2)
        {
            Lakok++;
            GyerekekSzama++;
            return true;
        }
        return false;
    }

    public override bool Bekoltozik(int bekoltozok)
    {
        bekoltozok -= GyerekekSzama / 2;

        if (SzobaSzam * 2  <= bekoltozok && bekoltozok * 10 >= Terulet)
        {
            Lakok = bekoltozok;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{base.ToString()} , Gyerekek szama: {GyerekekSzama}";
    }
}
