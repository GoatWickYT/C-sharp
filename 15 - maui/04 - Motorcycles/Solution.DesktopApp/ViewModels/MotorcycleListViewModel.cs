
namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MotorcycleListViewModel(IMotorcycleService motorcycleService)
{
    #region life cycle commands

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    #endregion

    [ObservableProperty]
    private ObservableCollection<MotorcycleModel> motorcycles;

    private int page = 1;

    private async Task OnAppearingAsync()
    {
        await LoadMotorcycles();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task LoadMotorcycles()
    {
        var result = await motorcycleService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Motorcycles not loaded!", "OK");
            return;
        }
        var message = result.IsError ? result.FirstError.Description : "Done";

        Motorcycles = new ObservableCollection<MotorcycleModel>(result.Value);
    }
}
