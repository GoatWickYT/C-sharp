using Microsoft.Maui.Platform;
using Solution.Database.Entities;

namespace Solution.Services;

public class BookService(AppDbContext dbContext) : IBookService
{
    public async Task<ErrorOr<BookModel>> CreateAsync(BookModel book)
    {
        BookEntity bookEntity = book.ToEntity();
        var books = await dbContext.Books.ToListAsync();

        if (book.Publisher.Value == null ||
            book.ISBN.Value == null ||
            book.PublishYear.Value == null ||
            book.Title.Value == null ||
            book.Author.Value == null)
        {
            return Error.Conflict(description: $"All fields are required");
        }

        if (books.Any(x => x.ISBN == book.ISBN.Value &&
                      x.Publisher == book.Publisher.Value &&
                      x.PublishYear == book.PublishYear.Value &&
                      x.Title == book.Title.Value &&
                      x.Author == book.Author.Value))
        {
            return Error.Conflict(description: $"Book already exists");
        }
        else if (books.Any(x => x.ISBN == book.ISBN.Value))
        {
            return Error.Conflict(description: $"ISBN already exists");
        }

        await dbContext.Books.AddAsync(bookEntity);
        await dbContext.SaveChangesAsync();
        return new BookModel(bookEntity);
    }
}
