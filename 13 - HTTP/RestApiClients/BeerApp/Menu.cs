using System.Text;

namespace BeerApp;

public static class Menu
{
    public static async Task Main()
    {
        char option = Selector();
        await Action(option);
    }

    private static char Selector()
    {

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Add new beer");
        sb.AppendLine("Update existing beer");
        sb.AppendLine("Get beer by ID");
        sb.AppendLine("Flip through 5 beers");
        sb.AppendLine("Get all beers");
        sb.AppendLine("Remove beer");
        sb.AppendLine("Exit");

        Console.WriteLine("Select the operation you want to perform");
        Console.WriteLine("navigate with the arrows (up/down) and enter");

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Add new beer");
        Console.ResetColor();
        foreach (string line in sb.ToString().Split('\n').Skip(1))
        {
            Console.WriteLine(line);
        }


        int choice = 1;
        bool leave = false;


        do
        {
            var input = Console.ReadKey().Key;

            switch (input) {
                case ConsoleKey.UpArrow:
                    choice--;
                    break;
                case ConsoleKey.DownArrow:
                    choice++;
                    break;
                case ConsoleKey.Enter:
                    leave = true;
                    break;
            }

            if (choice < 1)
            {
                choice = 7;
            }
            else if (choice > 7)
            {
                choice = 1;
            }

            Console.Clear();
            Console.WriteLine("Select the operation you want to perform");
            Console.WriteLine("navigate with the arrows (up/down) and enter");

            string[] options = sb.ToString().Split('\n');
            foreach (string line in options)
            {
                if (options[choice-1] == line)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(line);
                Console.ResetColor();
            }
        } while (!leave);       

        return choice.ToString()[0];
    }

    private static async Task Action(char option) {
        Console.Clear();
        int id;
        Beer beer;
        List<Beer> beers;

        beers = await BeerService.GetAllBeersAsync();
        int maxId = beers.Max(x => x.Id);
        int minId = beers.Min(x => x.Id);
        beers = null;
        switch (option)
        {
            case '1': //Add new beer
                beer = CreateBeer();
                await BeerService.AddBeerAsync(beer);
                break;
            case '2': //Update beer
                id = ReadIdFromConsole("update");
                beer = await BeerService.GetBeerByIdAsync(id);
                await UpdateAsync(id,beer);
                await Console.Out.WriteLineAsync("Beer updated Successfully");
                break;
            case '3': //Get by ID
                id = ReadIdFromConsole("get");
                beer = await BeerService.GetBeerByIdAsync(id);
                await Console.Out.WriteLineAsync(beer is null ? "Beer not found" : beer.ToString());
                break;
            case '4': //Flip by 5
                await FlipThroughFiveAsync(minId,maxId);
                break;
            case '5': //Get all beers
                beers = await BeerService.GetAllBeersAsync();
                beers.ForEach(beer => Console.WriteLine(beer.ToString()));
                break;
            case '6': //Remove beer
                id = ReadIdFromConsole("remove");
                bool removed = await BeerService.RemoveBeerByIdAsync(id);
                Console.WriteLine($"{(removed ? "Beer removed successfully" : "Beer not found")}");
                break;
            default: //Exit
                Console.Write("Exiting.");
                await Task.Delay(1000);
                Console.Write(".");
                await Task.Delay(1000);
                Console.Write(".");
                await Task.Delay(1000);
                Environment.Exit(0);
                break;
        }
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any button to continue");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        await Main();
    }

    private static int ReadIdFromConsole(string action) => ExtendedConsole.ReadInteger($"Enter the ID of the beer you want to {action}: ",0);

    private static Beer CreateBeer()
    {
        Beer beer = new Beer();
        beer.Name = ExtendedConsole.ReadString("Enter the name of the beer: ");
        beer.Price = "$" + (ExtendedConsole.ReadDouble("Enter the price of the beer: ",0)).ToString();
        Console.Write("Enter the URL of the image of the beer (skip with enter): ");
        beer.Image = Console.ReadLine();
        return beer;
    }

    private static Beer UpdateBeer()
    {
        Beer beer = new Beer();

        Console.Write("Enter the name of the beer (enter to skip): ");
        beer.Name = Console.ReadLine();

        Console.Write("Enter the price of the beer in USD (enter to skip): ");
        beer.Price = "$" + (Console.ReadLine().Replace(",","."));

        Console.Write("Enter the image url of the beer (enter to skip): ");
        beer.Image = Console.ReadLine();

        AppState.Update(beer);

        return AppState.GetBeer();
    }

    private static async Task FlipThroughFiveAsync(int minId, int maxId)
    {

        int id = ReadIdFromConsole("start flipping from");
        bool leave = false;
        do
        {
            if (id < minId)
            { id = minId; }
            else if (id > maxId - 5)
            { id = maxId - 4; }
            List<Beer> beers = await BeerService.GetFiveBeersAsync(id);
            beers.ForEach(beer => Console.WriteLine(beer?.ToString()));
            Console.Write("Use arrows to flip through pages (hit enter to leave): ");
            var input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    id -= 5;
                    break;
                case ConsoleKey.UpArrow:
                    id -= 5;
                    break;
                case ConsoleKey.RightArrow:
                    id += 5;
                    break;
                case ConsoleKey.DownArrow:
                    id += 5;
                    break;
                case ConsoleKey.Enter:
                    leave = true;
                    break;
                default:
                    break;
            }
            Console.Clear();
        } while (!leave);
        await Main();
    }

    private static async Task UpdateAsync(int id, Beer beer)
    {
        AppState.SetBeer(beer);

        Beer newBeer = UpdateBeer();

        newBeer.Id = id;

        await BeerService.UpdateBeerByIdAsync(newBeer);
    }
}