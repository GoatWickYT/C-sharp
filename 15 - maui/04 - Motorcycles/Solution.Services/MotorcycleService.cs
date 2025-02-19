namespace Solution.Services;

public class MotorcycleService(AppDbContext dbContext) : IMotorcycleService
{
    private int ROW_COUNT = 10;

    public async Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel model)
    {
        bool exists = await dbContext.Motorcycles.AnyAsync(m => m.Model.ToLower() == model.Model.Value.ToLower().Trim() &&
                                           m.ManufacturerId == model.Manufacturer.Value.Id &&
                                           m.ReleaseYear == model.ReleaseYear.Value);

        if (exists)
        {
            return Error.Conflict(description: "Motorcycle already exists");
        }

        var motorcycle = model.ToEntity();

        motorcycle.PublicId = Guid.NewGuid().ToString();

        await dbContext.Motorcycles.AddAsync(motorcycle);
        await dbContext.SaveChangesAsync();

        return new MotorcycleModel(motorcycle)
        {
            Manufacturer = model.Manufacturer
        };
    }

    public async Task<ErrorOr<Success>> UpdateAsync(MotorcycleModel model)
    {
        var result = await dbContext.Motorcycles.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Include(X => X.Type)
                                                .Where(x => x.PublicId == model.Id)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.PublicId, model.Id)
                                                                          .SetProperty(p => p.ManufacturerId, model.Manufacturer.Value.Id)
                                                                          .SetProperty(p => p.TypeId, model.Type.Value.Id)
                                                                          .SetProperty(p => p.Model, model.Model.Value)
                                                                          .SetProperty(p => p.Cubic, model.Cubic.Value)
                                                                          .SetProperty(p => p.ReleaseYear, model.ReleaseYear.Value)
                                                                          .SetProperty(p => p.Cylinders, model.CylindersNumber.Value));

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string id)
    {
        var result = await dbContext.Motorcycles.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Include(X => X.Type)
                                                .Where(x => x.PublicId == id)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<MotorcycleModel>> GetByIdAsync(string id)
    {
        var motorcycle = await dbContext.Motorcycles.Include(x => x.Manufacturer)
                                            .FirstOrDefaultAsync(x => x.PublicId == id);

        if (motorcycle is null)
        {
            return Error.NotFound(description: "Motorcycle not found");
        }

        return new MotorcycleModel(motorcycle);
    }

    public async Task<ErrorOr<List<MotorcycleModel>>> GetAllAsync() => 
        await dbContext.Motorcycles.AsNoTracking()
                           .Include(x => x.Manufacturer)
                           .Include(X => X.Type)
                           .Select(x => new MotorcycleModel(x))
                           .ToListAsync();

    public async Task<ErrorOr<List<MotorcycleModel>>> GetPagedAsync(int page = 0)
    {
        page = page < 0 ? 0 : page - 1;

        return await dbContext.Motorcycles.AsNoTracking()
                           .Include(x => x.Manufacturer)
                           .Include(X => X.Type)
                           .Skip(page * ROW_COUNT)
                           .Take(ROW_COUNT)
                           .Select(x => new MotorcycleModel(x))
                           .ToListAsync();
    }

    public Task<int> GetMaxPageNumberAsync()
    {
        return dbContext.Motorcycles.AsNoTracking()
                           .CountAsync()
                           .ContinueWith(t => (int)Math.Ceiling(t.Result / (double)ROW_COUNT));
    }
}