using System.Globalization;

static class ConsoleExtensions
{

    private static string input;

    public static int ReadInt(string prompt, int minimum = int.MinValue, int maximum = int.MaxValue)
    {
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int _);
            if (!isNumber)
            {
                Console.WriteLine("Please enter a valid number.");
                Thread.Sleep(1000);
                continue;
            }
        } while (!int.TryParse(input, out int value) || value < minimum || value > maximum);
        return int.Parse(input);
    }

    public static double ReadDouble(string prompt, double minimum = double.MinValue, double maximum = double.MaxValue)
    {
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            bool isNumber = double.TryParse(input.Replace(',','.'), new CultureInfo("en-US"), out double _);
            if (!isNumber)
            {
                Console.WriteLine("Please enter a valid number.");
                Thread.Sleep(1000);
                continue;
            }
        } while (!double.TryParse(input, out double value) || value < minimum || value > maximum);
        return double.Parse(input.Replace(',','.'), new CultureInfo("en-US"));
    }

    public static string ReadString(string prompt, bool canLeaveEmpty = false)
    {
        if (canLeaveEmpty)
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            return input;
        }
        else
        {
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid string.");
                    Thread.Sleep(1000);
                    continue;
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }
    }

}