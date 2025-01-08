public class XWing : LazadoGep, IHiperhajtomu
{
    public XWing() : base(150, true) { }

    public override bool ElkapjaAVonosugar()
    {
        return Sebesseg < 10000 && MeghibasodhatE;
    }

    public void HiperUgras()
    {
        Sebesseg += new Random().NextDouble() * 100;
    }

    public override string ToString()
    {
        return "X-Wing" + base.ToString();
    }
}