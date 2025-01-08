public class Vasember : Bosszuallo, IMilliardos
{
    private Random rnd = new Random();

    public Vasember(int kutyukSzama) : base(150, true)
    {
        for (int i = 1; i < kutyukSzama; i++)
        {
            KutyutKeszit();
        }
    }

    public void KutyutKeszit()
    {
        Superero += (double)rnd.NextDouble() * 10;
    }

    public override bool MegmentiAVilagot()
    {
        return Superero > 1000;
    }

    public override string ToString()
    {
        return $"Vasember: {base.ToString()}";
    }
}