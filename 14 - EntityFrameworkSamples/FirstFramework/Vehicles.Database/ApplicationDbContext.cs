namespace Vehicles.Database;

public class ApplicationDbContext : DbContext
{

    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<OwnerEntity> Owners { get; set; }
    public DbSet<StreetEntity> Streets { get; set; }
    public DbSet<CityEntity> Cities { get; set; }

    public ApplicationDbContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VehicleDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;")
            .LogTo(a => Console.WriteLine(a));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ColorEntity>().HasData
            (
                new ColorEntity { Id = 1, Name = "White", Code = "ffffff" },
                new ColorEntity { Id = 2, Name = "Black", Code = "000000" },
                new ColorEntity { Id = 3, Name = "Red", Code = "ff0000" },
                new ColorEntity { Id = 4, Name = "Yellow", Code = "ffff00"}
            );

        builder.Entity<VehicleUsageEntity>().HasData(
            new VehicleUsageEntity { Id=1, Name = "Normal" },
            new VehicleUsageEntity { Id = 2, Name = "Taxi" },
            new VehicleUsageEntity { Id = 3, Name = "Freight" },
            new VehicleUsageEntity { Id = 4, Name = "Company" }
            );

        builder.Entity<VehicleTypeEntity>().HasData(
                new VehicleTypeEntity { Id = 1, Name = "Car" },
                new VehicleTypeEntity { Id = 2, Name = "Truck" },
                new VehicleTypeEntity { Id = 3, Name = "Motorcycle" },
                new VehicleTypeEntity { Id = 4, Name = "Van" }
            );

        /*
        builder.Entity<VehicleEntity>()
            .HasIndex(x => x.LisencePlate)
            .IsUnique();
        */
    }
 
}