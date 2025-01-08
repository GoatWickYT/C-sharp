public class Hazmester
{
    public static void Karbantart(string fajl)
    {
        Tarsashaz tarsashaz = new Tarsashaz(20, 20);
        try
        {
            StreamReader sr = new StreamReader("source/"+fajl);
            string sor;
            while ((sor = sr.ReadLine()) != null)
            {
                string[] adatok = sor.Split(' ');
                if (adatok[0] == "Alberlet")
                {
                    tarsashaz.LakasHozzaad(new Alberlet((int)double.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3])));
                } else if (adatok[0] == "CsaladiApartman")
                {
                    tarsashaz.LakasHozzaad(new CsaladiApartman((int)double.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3])));
                } else if (adatok[0] == "Garazs")
                {
                    tarsashaz.GarazsHozzaad(new Garazs((int)double.Parse(adatok[1]), int.Parse(adatok[2]), adatok[3] == "futott"));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Hiba a fájl olvasása közben! {e.ToString()}");
        }
        Console.WriteLine($"A társasház összes értéke: {tarsashaz.IngatlanErtek()}");
    }
}