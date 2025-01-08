public class Pekseg
{
    private static ICollection<IArlap> Arlapok = new List<IArlap>();

    public static async Task Main(string filename)
    {
        await VasarlokAsync(filename);
        await EtelLeltarAsync();
    }

    public static async Task VasarlokAsync(string filename)
    {
        try
        {
            foreach (var sor in await File.ReadAllLinesAsync("source/"+filename))
            {
                string[] adatok = sor.Split(' ');

                IArlap arlap = PeksutemenyFactory.AruEloallitas(adatok);

                /*
                if (adatok[0] == "Pogacsa")
                {
                    Pogacsa p = new Pogacsa(double.Parse(adatok[1]), double.Parse(adatok[2]));
                    Arlapok.Add(p);
                }
                else if (adatok[0] == "Kave")
                {
                    Kave k = new Kave(adatok[1] == "habos");
                    Arlapok.Add(k);
                }
                */
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static async Task EtelLeltarAsync()
    {
        try
        {
            IEnumerable<string?> pogacsak = Arlapok.Where(x => x.GetType() == typeof (Pogacsa))
                                                   .Select(x => x.ToString());
            await File.WriteAllLinesAsync("leltar.txt", pogacsak);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
