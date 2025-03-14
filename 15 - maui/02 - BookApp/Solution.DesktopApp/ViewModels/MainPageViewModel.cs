﻿namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MainPageViewModel : BookModel
{
    public IAsyncRelayCommand OnSubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public IRelayCommand ISBNValidationCommand => new RelayCommand(() => ISBN.Validate());
    public IRelayCommand AuthorValidationCommand => new RelayCommand(() => Author.Validate());
    public IRelayCommand TitleValidationCommand => new RelayCommand(() => Title.Validate());
    public IRelayCommand PublishYearValidationCommand => new RelayCommand(() => PublishYear.Validate());
    public IRelayCommand PublisherValidationCommand => new RelayCommand(() => Publisher.Validate());

    private readonly IBookService bookService;

    public MainPageViewModel(IBookService bookService) : base()
    {
        this.bookService = bookService;
    }

    private bool IsFormValid => ISBN.IsValid &&
                                Author.IsValid &&
                                Title.IsValid &&
                                PublishYear.IsValid &&
                                Publisher.IsValid;

    public async Task OnSubmitAsync()
    {
        if (!IsFormValid)
        {
            await Application.Current!.MainPage.DisplayAlert("Alert", "All fields must be filled", "Ok");
            return;
        }

        ErrorOr<BookModel> serviceResponse = await bookService.CreateAsync(this);
        string alertMessage = serviceResponse.IsError ? serviceResponse.FirstError.Description : "Book saved!";
        await Application.Current!.MainPage.DisplayAlert("Alert", alertMessage, "Ok");
    }
}
