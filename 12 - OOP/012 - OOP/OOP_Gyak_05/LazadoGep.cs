public abstract class LazadoGep : IUrhajo
{
    protected double Sebesseg;
    protected bool MeghibasodhatE;

    public LazadoGep(double sebesseg, bool meghibasodhatE)
    {
        this.Sebesseg = sebesseg;
        this.MeghibasodhatE = meghibasodhatE;
    }

    public abstract bool ElkapjaAVonosugar();

    public int MilyenGyors()
    {
        return (int)Sebesseg;
    }

    public bool LegyorsuljaE(IUrhajo urhajo)
    {
        if (urhajo is LazadoGep)
        {
            LazadoGep lazado = (LazadoGep)urhajo;
            if (lazado.MeghibasodhatE && lazado.Sebesseg < Sebesseg)
            {
                return true;
            }
        }
        else if (urhajo is MilleniumFalcon)
        {
            MilleniumFalcon millenium = (MilleniumFalcon)urhajo;
            if (Sebesseg > 2 * millenium.MilyenGyors())
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return "Sebesség: " + Sebesseg + ", meghibásodhat: " + MeghibasodhatE;
    }
}