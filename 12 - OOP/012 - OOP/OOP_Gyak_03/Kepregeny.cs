public class Kepregeny
{
    private static List<ISzuperhos> szuperhosok = new List<ISzuperhos>();

    public static void Szereplok(string filename)
    {
        try
        {
            StreamReader sr = new StreamReader("source/"+filename);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                if (sor[0] == "Vasember")
                {
                    Vasember vasember = new Vasember(Convert.ToInt32(sor[1]));
                    for (int i = 0; i < Convert.ToInt32(sor[1]); i++)
                    {
                        vasember.KutyutKeszit();
                    }
                    szuperhosok.Add(vasember);
                }
                else if (sor[0] == "Batman")
                {
                    Batman batman = new Batman(Convert.ToInt32(sor[1]));
                    for (int i = 0; i < Convert.ToInt32(sor[1]); i++)
                    {
                        batman.KutyutKeszit();
                    }
                    szuperhosok.Add(batman);
                }
            }
            sr.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Szuperhosok()
    {
        foreach (ISzuperhos szuperhos in szuperhosok)
        {
            Console.WriteLine(szuperhos);
        }
    }

    public static void Main(string filename)
    {
        Szereplok(filename);
        Szuperhosok();
    }
}