namespace Solution.Services;

public class RunService(AppDbContext dbContext) : IRunService
{
    public Task<ErrorOr<RunModel>> CreateAsync(RunModel run)
    {
        throw new NotImplementedException();
    }
}
