public class StarWars()
{
    private static List<IUrhajo> ships = new List<IUrhajo>();

    public static void Űrhajók(string path)
    {
        try
        {
            StreamReader sr = new StreamReader("source/"+path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                if (parts[0] == "XWing")
                {
                    ships.Add(new XWing());
                    for (int i = 0; i < int.Parse(parts[1]); i++)
                    {
                        XWing xWing = (XWing)ships[ships.Count - 1];
                        xWing.HiperUgras();
                    }
                }
                else if (parts[0] == "MilleniumFalcon")
                {
                    ships.Add(new MilleniumFalcon());
                    for (int i = 0; i < int.Parse(parts[1]); i++)
                    {
                        MilleniumFalcon milleniumFalcon = (MilleniumFalcon)ships[ships.Count - 1];
                        milleniumFalcon.HiperUgras();
                    }
                }
            }
            sr.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Hiba történt: " + e.Message);
        }
    }

    public static void Hangar()
    {
        foreach (var item in ships)
        {
            Console.WriteLine(item);
        }
    }
}