namespace Solution.Core.Models;

public class BookModel
{
    public uint Id { get; set; }

    public ValidatableObject<ulong> ISBN { get; set; }

    public ValidatableObject<string> Author { get; set; }

    public ValidatableObject<string> Title { get; set; }

    public ValidatableObject<uint> PublishDate { get; set; }

    public ValidatableObject<string> Publisher { get; set; }

    public BookModel()
    {
        this.ISBN = new ValidatableObject<ulong>();
        this.Author = new ValidatableObject<string>();
        this.Title = new ValidatableObject<string>();
        this.PublishDate = new ValidatableObject<uint>();
        this.Publisher = new ValidatableObject<string>();

        AddValidators();
    }

    public BookModel(BookEntity entity) : this()
    {
        Id = entity.Id;
        ISBN.Value = entity.ISBN;
        Author.Value = entity.Author;
        Title.Value = entity.Title;
        PublishDate.Value = entity.PublishYear;
        Publisher.Value = entity.Publisher;
    }

    public BookEntity ToEntity()
    {
        return new BookEntity
        {
            Id = Id,
            ISBN = ISBN.Value,
            Author = Author.Value,
            Title = Title.Value,
            PublishYear = PublishDate.Value,
            Publisher = Publisher.Value
        };
    }

    public void ToEntity(BookEntity entity)
    {
        entity.Id = Id;
        entity.ISBN = ISBN.Value;
        entity.Author = Author.Value;
        entity.Title = Title.Value;
        entity.PublishYear = PublishDate.Value;
        entity.Publisher = Publisher.Value;
    }

    private void AddValidators()
    {
        ISBN.Validations.Add(new IsNotNullOrEmptyRule<ulong> { ValidationMessage = "ISBN is required." });
        ISBN.Validations.Add(new ISBNRule<ulong> { ValidationMessage = "ISBN must be between 10 and 13 characters."});
        Author.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Author is required." });
        Title.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Title is required." });
        PublishDate.Validations.Add(new IsNotNullOrEmptyRule<uint> { ValidationMessage = "Publish date is required." });
        Publisher.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Publisher is required." });
    }
}
