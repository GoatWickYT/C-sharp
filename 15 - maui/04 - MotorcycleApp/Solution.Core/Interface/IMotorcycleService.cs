namespace Solution.Core.Interface;

public interface IMotorcycleService
{
    Task<ErrorOr<MotorcycleModel>> CreateAsync(MotorcycleModel manufacturer);
}
