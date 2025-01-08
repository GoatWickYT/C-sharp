public class StarWars
{
    private static List<IEroErzekeny> characters = new List<IEroErzekeny>();

    public static void Szereplok(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader("source/"+path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length == 2)
                    {
                        if (parts[0] == "Anakin")
                        {
                            characters.Add(new AnakinSkywalker());
                            for (int i = 0; i < int.Parse(parts[1]); i++)
                            {
                                Sith sith = (Sith)characters[characters.Count - 1];
                                sith.EngeddElAHaragod();
                            }
                        }
                        else if (parts[0] == "Uralkodo")
                        {
                            characters.Add(new Uralkodo());
                            for (int i = 0; i < int.Parse(parts[1]); i++)
                            {
                                Uralkodo uralkodo = (Uralkodo)characters[characters.Count - 1];
                                uralkodo.EngeddElAHaragod();
                            }
                        }
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Sithek()
    {
        foreach (IEroErzekeny character in characters)
        {
            Console.WriteLine(character);
        }
    }
}