namespace Solution.Core.Interfaces;

public interface IMotorcycleService
{
    Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel model);
    Task<ErrorOr<Success>> UpdateAsync(MotorcycleModel model);
    Task<ErrorOr<Success>> DeleteAsync(string motorcycleId);
    Task<ErrorOr<MotorcycleModel>> GetByIdAsync(string motorcycleId);
    Task<ErrorOr<List<MotorcycleModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<MotorcycleModel>>> GetPagedAsync(int page = 0);
}
