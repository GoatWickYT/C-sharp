public class Batman : ISzuperhos, IMilliardos
{
    private double Lelemenyesseg;

    public Batman(int kutyukSzama)
    {
        for (int i = 1; i < kutyukSzama; i++)
        {
            KutyutKeszit();
        }
        Lelemenyesseg = 100;
    }

    public void KutyutKeszit()
    {
        Lelemenyesseg += 50;
    }

    public double Ero
    {
        get
        {
            return 2 * Lelemenyesseg;
        }
    }

    public bool LegyoziE(ISzuperhos szuperhos)
    {
        return szuperhos.MekkoraAzEreje() < Lelemenyesseg;
    }

    public override string ToString()
    {
        return $"Batman: {Lelemenyesseg}";
    }

    public int MekkoraAzEreje()
    {
        throw new NotImplementedException();
    }
}