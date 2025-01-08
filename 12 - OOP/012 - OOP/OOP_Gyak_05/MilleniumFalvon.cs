public class MilleniumFalcon : IUrhajo, IHiperhajtomu
{
    private double tapasztalat;

    public MilleniumFalcon()
    {
        tapasztalat = 100;
    }

    public int MilyenGyors()
    {
        return (int)tapasztalat * 2;
    }

    public bool LegyorsuljaE(IUrhajo urhajo)
    {
        if (urhajo is LazadoGep)
        {
            LazadoGep lazado = (LazadoGep)urhajo;
            if (lazado.MilyenGyors() < MilyenGyors())
            {
                return true;
            }
        }
        return false;
    }


    public void HiperUgras()
    {
        tapasztalat += 500;
    }

    public override string ToString()
    {
        return "Millenium Falcon, tapasztalat: " + tapasztalat;
    }

}