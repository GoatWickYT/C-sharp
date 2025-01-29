namespace Solution.DataBase;

public class AppDbContext() : DbContext
{
	public DbSet<ManufacturerEntity> Manufacturers { get; set; }

	public DbSet<MotorcycleEntity> Motorcycles { get; set; }

	private static string connectionString = string.Empty;

	static AppDbContext()
	{
		connectionString = GetConnectionString();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		ArgumentNullException.ThrowIfNull(connectionString);

		base.OnConfiguring(optionsBuilder);

		optionsBuilder.UseSqlServer(connectionString);
	}

	private static string GetConnectionString()
	{
#if DEBUG
		var file = "appSettings.Development.json";
#else
        var file = "connectionString.Production.json";
#endif
		var stream = new MemoryStream(File.ReadAllBytes($"{file}"));

		var config = new ConfigurationBuilder()
					.AddJsonStream(stream)
					.Build();

		var cs = config.GetValue<string>("SqlConnectionString");
		return cs;
	}
}
