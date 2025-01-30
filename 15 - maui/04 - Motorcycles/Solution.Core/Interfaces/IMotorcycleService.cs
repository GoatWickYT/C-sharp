﻿
namespace Solution.Core.Interfaces;

public interface IMotorcycleService
{
    Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel model);
    Task<ErrorOr<MotorcycleModel>> UpdateAsync(MotorcycleModel model);
    Task<ErrorOr<Success>> DeleteAsync(string id);
    Task<ErrorOr<MotorcycleModel>> GetByIdAsync(string id);
    Task<ErrorOr<List<MotorcycleModel>>> GetAllAsync();
    Task<ErrorOr<List<MotorcycleModel>>> GetPagedAsync(int page = 0);
}
