using CommunityToolkit.Mvvm.Input;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewMotorcycleCommand => new AsyncRelayCommand(OnAddNewMotorcycleAsync);
    public IAsyncRelayCommand ListAllMotorcyclesCommand => new AsyncRelayCommand(OnListAllMotorcyclesAsync);


    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewMotorcycleAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditMotorcycleView.Name);
    }

    private async Task OnListAllMotorcyclesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(MotorcycleListView.Name);
    }
}
