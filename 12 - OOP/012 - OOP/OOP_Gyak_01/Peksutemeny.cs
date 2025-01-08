public abstract class Peksutemeny : IArlap
{
    protected double Mennyiseg { get; set; }

    private double alapAr = 0;

    public Peksutemeny(double mennyiseg, double alapAr)
    {
        Mennyiseg = mennyiseg;
        this.alapAr = alapAr;
    }

    public double MennyibeKerul() => Mennyiseg * this.alapAr;

    public abstract void Megkostol();


    public override string ToString()
    {
        return $"{Mennyiseg} db - {MennyibeKerul()} Ft";
    }
}
