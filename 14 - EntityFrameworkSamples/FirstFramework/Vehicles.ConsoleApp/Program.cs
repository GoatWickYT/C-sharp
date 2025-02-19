/*
select * from [Manufacturer]

select * from [Model]

select * from [Vehicle]

select * from [Color]
*/

using var dbContext = new ApplicationDbContext();

#region new record
/*
var vehicle = new VehicleEntity
{
    LisencePlate = "RAP-603",
    ChassisNumber = "28345106790235647",
    EngineNumber = "df",
    NumberOfDoors = 5,
    Weight = 1350,
    Power = 110,
    ColorId = 2
};

await dbContext.Vehicles.AddAsync(vehicle);
await dbContext.SaveChangesAsync();
*/
#endregion

#region edit record
/*
var color = await dbContext.Colors.FindAsync((uint)6);
color.Code = "00ff00";
await dbContext.SaveChangesAsync();
*/
#endregion

#region delete record
/*
var vehicle = await dbContext.Vehicles.FindAsync((uint)1);
dbContext.Vehicles.Remove(vehicle);
await dbContext.SaveChangesAsync();
*/
#endregion

// await AddSecondVehicleToDbAsync();
/*
var vehicles = await dbContext.Vehicles.Include(vehicle => vehicle.Color)
                                       .Include(vehicle => vehicle.Model)
                                           .ThenInclude(model => model.Manufacturer)
                                       .ToListAsync();
*/
/*
var vehicle = await dbContext.Vehicles.Include(vehicle => vehicle.Color)
                                      .Include(vehicle => vehicle.Model)
                                        .ThenInclude(model => model.Manufacturer)
                                      .FirstAsync(x => x.Id == (uint)2);
*/

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.Write("Press any key to clear console");
Console.ResetColor();
Console.ReadKey();
Console.Clear();

await AddFirstCityAsync();
await AddSecondCityAsync();

// PrintVehicleToConsole(vehicle);
// PrintVehiclesToConsole(vehicles);

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Done");
Console.ResetColor();
Console.ReadKey();
Console.Clear();


async Task AddFirstCityAsync()
{
    CityEntity cityEntity = new CityEntity
    {
        Name = "Budapest",
        PostalCode = 1011
    };

    await dbContext.Cities.AddAsync(cityEntity);
    await dbContext.SaveChangesAsync();

    StreetEntity streetEntity = new StreetEntity
    {
        Name = "Budafoki út",
        CityPostalCode = cityEntity.PostalCode
    };

    await dbContext.Streets.AddAsync(streetEntity);
    await dbContext.SaveChangesAsync();
}

async Task AddSecondCityAsync()
{
    CityEntity cityEntity = new CityEntity
    {
        Name = "Szeged",
        PostalCode = 6725
    };

    await dbContext.Cities.AddAsync(cityEntity);
    await dbContext.SaveChangesAsync();

    StreetEntity streetEntity = new StreetEntity
    {
        Name = "Kossuth Lajos sugárút",
        CityPostalCode = cityEntity.PostalCode
    };

    await dbContext.Streets.AddAsync(streetEntity);
    await dbContext.SaveChangesAsync();
}

async Task AddFirstVehicleToDbAsync()
{
    ManufacturerEntity manufacturer = new ManufacturerEntity {
        Name = "Volvo",
        ISOCountryCode = "SE"
    };

    await dbContext.Manufacturers.AddAsync(manufacturer);
    await dbContext.SaveChangesAsync();
    
    ModelEntity model = new ModelEntity {
        Name = "XC90",
        ManufacturerId = manufacturer.Id
    };

    await dbContext.Models.AddAsync(model);
    await dbContext.SaveChangesAsync();

    VehicleEntity vehicle = new VehicleEntity
    {
        LisencePlate = "ABC135",
        ChassisNumber = "15293564012245607",
        EngineNumber = "12",
        NumberOfDoors = 5,
        Weight = 2095,
        Power = 250,
        ColorId = 1,
        ModelId = model.Id
    };

    await dbContext.Vehicles.AddAsync(vehicle);
    await dbContext.SaveChangesAsync();
    
}


async Task AddSecondVehicleToDbAsync()
{
    VehicleEntity vehicleEntity = new VehicleEntity
    {
        LisencePlate = "DEF246",
        ChassisNumber = "15293564012245607",
        EngineNumber = "F4",
        NumberOfDoors = 3,
        Weight = 1245,
        Power = 345,
        Color = new ColorEntity
        {
            Name = "green",
            Code = "00FF00"
        },
        Model = new ModelEntity
        {
            Name = "Imprezza 22b",
            Manufacturer = new ManufacturerEntity
            {
                Name = "Subaru",
                ISOCountryCode = "JP"
            }
        }
    };

    await dbContext.Vehicles.AddAsync(vehicleEntity);
    await dbContext.SaveChangesAsync();
}

void PrintVehiclesToConsole(ICollection<VehicleEntity> vehicles)
{
    foreach (var vehicle in vehicles)
    {
        PrintVehicleToConsole(vehicle);
    }
}

void PrintVehicleToConsole(VehicleEntity vehicle)
{
    Console.WriteLine(
        $"{vehicle?.LisencePlate}".PadRight(20) +
        $"{vehicle?.Model?.Manufacturer?.Name}".PadRight(20) +
        $"{vehicle?.Model?.Name}".PadRight(20) +
        $"({vehicle?.Color?.Name})"
    );
}