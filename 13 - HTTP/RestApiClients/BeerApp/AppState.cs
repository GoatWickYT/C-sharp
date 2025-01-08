namespace BeerApp;

public static class AppState
{
    private static Beer selectedBeer;

    public static void SetBeer(Beer beer)
    {
        selectedBeer = beer;
    }

    public static void Clear() => selectedBeer = null;

    public static Beer GetBeer() => selectedBeer;

    public static void Update(Beer beer)
    {
        selectedBeer.Image = string.IsNullOrEmpty(beer.Image) ? selectedBeer.Image : beer.Image;
        selectedBeer.Name = string.IsNullOrEmpty(beer.Name) ? selectedBeer.Name : beer.Name;
        selectedBeer.Price = string.IsNullOrEmpty(beer.Price) ? selectedBeer.Price : beer.Price;
    }

    public static int GetId() => selectedBeer.Id;
}
