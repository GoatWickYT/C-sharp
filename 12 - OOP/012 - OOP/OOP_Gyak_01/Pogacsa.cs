public class Pogacsa : Peksutemeny
{
    public Pogacsa(double mennyiseg, double alapAr) : base(mennyiseg, alapAr)
    {

    }

    public override void Megkostol() => Mennyiseg /= 2;

    public override string ToString() => $"Pogácsa: {base.ToString()}";
}
