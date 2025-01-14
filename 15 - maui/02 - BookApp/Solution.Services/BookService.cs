namespace Solution.Services;

public class BookService(AppDbContext dbContext) : IBookService
{
    public Task<ErrorOr<BookModel>> CreateAsync(BookModel book)
    {
        throw new NotImplementedException();
    }
}
