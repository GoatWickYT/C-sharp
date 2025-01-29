using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Solution.Core.Interfaces;
using Solution.Core.Models;
using Solution.Database.Entities;
using Solution.DataBase;
using System.ComponentModel;

namespace Solution.Services;

public class MotorcycleService(AppDbContext dbContext) : IMotorcycleService
{
    public async Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel motorcycle)
    {
        MotorcycleEntity motorcycleEntity = motorcycle.ToEntity();
        var motorcycles = await dbContext.Motorcycles.ToListAsync();

        if (motorcycle.Model.Value == null ||
            motorcycle.Cubic.Value == null ||
            motorcycle.Manufacturer == null ||
            motorcycle.CylindersNumber == null)
        {
            return Error.Conflict(description: "Model, Cubic, Manufacturer and Cylinders are required");
        }

        if (motorcycles.Any(m => m.Model == motorcycle.Model.Value &&
                                 m.Cubic == motorcycle.Cubic.Value &&
                                 m.Manufacturer.Id == motorcycle.Manufacturer.Value.Id &&
                                 m.Cylinders == motorcycle.CylindersNumber.Value))
        {
            return Error.Conflict(description: "Model already exists");
        }
        await dbContext.Motorcycles.AddAsync(motorcycleEntity);
        await dbContext.SaveChangesAsync();
        return new MotorcycleModel(motorcycleEntity);
    }
}
