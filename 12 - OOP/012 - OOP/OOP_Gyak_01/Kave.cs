public class Kave : IArlap
{
    private bool habosE = false;

    private const int CSESZEKAVE = 180;

    public Kave(bool habosE)
    {
        this.habosE = habosE;
    }

    public double MennyibeKerul() => habosE ? CSESZEKAVE * 1.5  : CSESZEKAVE;

    public override string ToString()
    {
        return $"{(habosE ? "Habos" : "Nem habos")} kávé - {MennyibeKerul()} Ft";
    }
}