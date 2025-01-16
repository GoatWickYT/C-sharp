namespace Solution.Core.Interface;

public interface IMotorcycleService
{
    Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel manufacturer);
}
