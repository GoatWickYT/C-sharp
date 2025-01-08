public class Orszagut
{
    private static List<Jarmu> Jarmuvek = new List<Jarmu>();

    public static void Main(string filename)
    {
        JarmuvekJonnek(filename);
        KiketMertunkBe();
    }

    public static void JarmuvekJonnek(string filename)
    {
        string[] sorok = File.ReadAllLines("source/"+ filename);
        foreach (string sor in sorok)
        {
            string[] adatok = sor.Split(';');
            if (adatok[0] == "Robogo")
            {
                Jarmuvek.Add(new Robogo(adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3])));
            }
            else if (adatok[0] == "AudiS8")
            {
                Jarmuvek.Add(new AudiS8(adatok[1], int.Parse(adatok[2]), bool.Parse(adatok[3])));
            }
        }
    }
    
    public static void KiketMertunkBe()
    {
        using (StreamWriter sw = new StreamWriter("buntetes.txt"))
        {
            foreach (Jarmu jarmu in Jarmuvek)
            {
                sw.WriteLine(jarmu);
                if (jarmu is AudiS8)
                {
                    sw.WriteLine($"Gyorshajott : {((jarmu as AudiS8).GyorshajtottE(90)?"igen":"nem")}");
                }
                else if (jarmu is Robogo)
                {
                    sw.WriteLine($"Haladhat itt : {((jarmu as Robogo).HaladhatItt(90) ? "igen":"nem")}");
                }
            }
        }
    }
}