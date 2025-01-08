public class Uralkodo : IEroErzekeny, Sith
{
    private double gonoszsag;

    public Uralkodo()
    {
        gonoszsag = 100;
    }

    public bool LegyoziE(IEroErzekeny ellenfel)
    {
        Jedi jedi = (Jedi)ellenfel;
        return jedi.MekkoraAzEreje() < this.MekkoraAzEreje();
    }

    public int MekkoraAzEreje()
    {
        return (int)gonoszsag*2;
    }

    public void EngeddElAHaragod()
    {
        gonoszsag += 50;
    }

    public override string ToString()
    {
        return $"Uralkodó, gonoszság: {gonoszsag}";
    }
}