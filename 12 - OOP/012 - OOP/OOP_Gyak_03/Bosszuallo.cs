public abstract class Bosszuallo : ISzuperhos
{
    protected double Superero;
    protected bool VanEGyengesege;

    public Bosszuallo(double superero, bool vanEGyengesege)
    {
        this.Superero = superero;
        this.VanEGyengesege = vanEGyengesege;
    }

    public abstract bool MegmentiAVilagot();

    public double Ero
    {
        get
        {
            return Superero;
        }
    }

    public bool LegyoziE(ISzuperhos szuperhos)
    {
        if (szuperhos is Bosszuallo)
        {
            Bosszuallo bosszuallo = (Bosszuallo)szuperhos;
            if (bosszuallo.VanEGyengesege && bosszuallo.Superero < Superero)
            {
                return true;
            }
            else if (bosszuallo is Batman && Superero > 2 * bosszuallo.Superero)
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return $"Superero: {Superero}, Van-e gyengesege: {VanEGyengesege}";
    }

    public int MekkoraAzEreje() {
        return (int)Superero;
    }
}