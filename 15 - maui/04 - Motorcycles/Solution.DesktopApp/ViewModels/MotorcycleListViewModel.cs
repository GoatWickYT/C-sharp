
using System.Runtime.CompilerServices;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MotorcycleListViewModel(IMotorcycleService motorcycleService)
{
    #region life cycle commands

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    #endregion

    public IAsyncRelayCommand PreviousPageCommand => new AsyncRelayCommand(PreviousPage);

    public IAsyncRelayCommand NextPageCommand => new AsyncRelayCommand(NextPage);

    [ObservableProperty]
    private ObservableCollection<MotorcycleModel> motorcycles;

    [ObservableProperty]
    private string pageNumber = "page\n1";

    [ObservableProperty]
    private bool previousButtonEnabled = false;

    [ObservableProperty]
    private bool nextButtonEnabled = false;


    private int page = 1;

    private async Task OnAppearingAsync()
    {
        await LoadMotorcycles();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task PreviousPage()
    {
        if (page > 1)
        {
            page--;
            PageNumber = $"page\n{page}";
            await LoadMotorcycles();
            return;
        }

        
    }

    private async Task NextPage()
    {
        int maxPageNumber = await motorcycleService.GetMaxPageNumberAsync();
        if (maxPageNumber < page + 1)
        {
            return;
        }
        page++;
        PageNumber = $"page\n{page}";

        await LoadMotorcycles();
    }

    private async Task LoadMotorcycles()
    {
        var result = await motorcycleService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Motorcycles not loaded!", "OK");
            return;
        }
        var message = result.IsError ? result.FirstError.Description : "Done";

        NextButtonEnabled = page < await motorcycleService.GetMaxPageNumberAsync();
        PreviousButtonEnabled = page > 1;

        Motorcycles = new ObservableCollection<MotorcycleModel>(result.Value);
    }
}
