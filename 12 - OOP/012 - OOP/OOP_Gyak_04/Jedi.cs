public abstract class Jedi : IEroErzekeny
{
    protected double Ero { get; set; }
    protected bool AtallhatE { get; set; }

    public Jedi(double Ero, bool atallhatE)
    {
        this.Ero = Ero;
        this.AtallhatE = atallhatE;
    }

    public abstract bool MegteremtiAzEgyensulyt();

    public bool LegyoziE(IEroErzekeny ellenfel)
    {
        if (ellenfel is Jedi)
        {
            Jedi jedi = (Jedi)ellenfel;
            if (jedi.AtallhatE && jedi.Ero < this.Ero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Uralkodo uralkodo = (Uralkodo)ellenfel;
            if (this.Ero > 2 * uralkodo.MekkoraAzEreje())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public int MekkoraAzEreje()
    {
        return (int)Ero;
    }

    public override string ToString()
    {
        return $"Ero: {Ero}, Atallhat-e: {AtallhatE}";
    }
}