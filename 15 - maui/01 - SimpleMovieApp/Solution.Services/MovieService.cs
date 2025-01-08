namespace Solution.Services;

public class MovieService(AppDbContext dbContext) : IMovieService
{
	public async Task<ErrorOr<MovieModel>> CreateAsync(MovieModel movie)
	{
		var isMovieExists = await dbContext.Movies.AnyAsync(x => 
			x.Title.ToLower() == movie.Title.Value.ToLower() &&
			x.Length == movie.Length.Value &&
			x.Release.Date == movie.Release.Value.Date
		);

		if(isMovieExists)
		{
			return Error.Conflict(description: $"Movie withe the same data already exists");
		}

    movie.Id = Guid.NewGuid().ToString();
    MovieEntity entity = movie.ToEntity();

		await dbContext.Movies.AddAsync(entity);
		await dbContext.SaveChangesAsync();

		return new MovieModel(entity);
	}
}
