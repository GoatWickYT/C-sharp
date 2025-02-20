namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MotorcycleListViewModel(IMotorcycleService motorcycleService) : MotorcycleModel(), IQueryAttributable
{
    #region life cycle commands

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    #endregion

    public IAsyncRelayCommand PreviousPageCommand => new AsyncRelayCommand(PreviousPage);

    public IAsyncRelayCommand FirstPageCommand => new AsyncRelayCommand(FirstPage);

    public IAsyncRelayCommand NextPageCommand => new AsyncRelayCommand(NextPage);

    public IAsyncRelayCommand LastPageCommand => new AsyncRelayCommand(LastPage);

    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<string>((id) => OnDeleteAsync(id));

    [ObservableProperty]
    private ObservableCollection<MotorcycleModel> motorcycles;

    [ObservableProperty]
    private string pageNumber = "page\n1";

    [ObservableProperty]
    private bool previousButtonEnabled = false;

    [ObservableProperty]
    private bool nextButtonEnabled = false;

    [ObservableProperty]
    private bool lastButtonEnabled = false;

    [ObservableProperty]
    private bool firstButtonEnabled = false;

    private int maxPageNumber;

    private int page = 1;

    private async Task OnAppearingAsync()
    {
        maxPageNumber = await motorcycleService.GetMaxPageNumberAsync();
        await LoadMotorcyclesAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    #region Page Buttons
    private async Task PreviousPage()
    {
        if (page > 1)
        {
            page--;
            PageNumber = $"page\n{page}";
            await LoadMotorcyclesAsync();
            return;
        }
    }

    private async Task FirstPage()
    {
        page = 1;
        PageNumber = $"page\n{page}";
        await LoadMotorcyclesAsync();
    }

    private async Task NextPage()
    {
        if (maxPageNumber < page + 1)
        {
            return;
        }
        page++;
        PageNumber = $"page\n{page}";

        await LoadMotorcyclesAsync();
    }

    private async Task LastPage()
    {
        LastButtonEnabled = false;
        page = await motorcycleService.GetMaxPageNumberAsync();
        PageNumber = $"page\n{page}";

        await LoadMotorcyclesAsync();
    }

    #endregion

    private async Task OnDeleteAsync(string? id)
    {
        var result = await motorcycleService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Motorcycle deleted";
        var title = result.IsError ? "Error" : "Success";

        if (!result.IsError)
        {
            var motorcycle = motorcycles.SingleOrDefault(x => x.Id == id);
            motorcycles.Remove(motorcycle);

            if (motorcycles.Count == 0)
            {
                await LoadMotorcyclesAsync();
            }
        }
        await Application.Current.MainPage.DisplayAlert(title, message, "Ok");
    }

    private async Task LoadMotorcyclesAsync()
    {


        var result = await motorcycleService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Motorcycles not loaded!", "OK");
            return;
        }
        var message = result.IsError ? result.FirstError.Description : "Done";

        await EnableButtonsAsync();

        Motorcycles = new ObservableCollection<MotorcycleModel>(result.Value);
    }

    private async Task EnableButtonsAsync()
    {
        LastButtonEnabled = page != maxPageNumber;
        FirstButtonEnabled = page != 1;
        NextButtonEnabled = page < await motorcycleService.GetMaxPageNumberAsync();
        PreviousButtonEnabled = page > 1;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        bool hasValue = query.TryGetValue("Id", out object result);

        if (!hasValue)
        {
            return;
        }
        await motorcycleService.DeleteAsync(result.ToString());
        await Application.Current.MainPage.DisplayAlert("Success", "Motorcycle deleted!", "Ok");
        await LoadMotorcyclesAsync();
    }
}
