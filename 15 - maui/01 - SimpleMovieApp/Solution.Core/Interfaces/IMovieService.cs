namespace Solution.Core.Interfaces;

public interface IMovieService
{
	Task<ErrorOr<MovieModel>> CreateAsync(MovieModel movie);
}
