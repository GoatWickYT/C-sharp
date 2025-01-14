namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class MainPageViewModel : RunModel
{
    public IAsyncRelayCommand OnSubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public IRelayCommand TimeValidationCommand => new RelayCommand(() => Time.Validate());
    public IRelayCommand DistanceValidationCommand => new RelayCommand(() => Distance.Validate());
    public IRelayCommand BurnedCaloriesValidationCommand => new RelayCommand(() => BurnedCalories.Validate());

    private readonly IRunService runService;

    private bool IsFormValid => Distance.IsValid &&
                                Time.IsValid &&
                                BurnedCalories.IsValid;

    public async Task OnSubmitAsync()
    {
        if (!IsFormValid)
        {
            return;
        }

        ErrorOr<RunModel> serviceResponse = await runService.CreateAsync(this);
        string alertMessage = serviceResponse.IsError ? serviceResponse.FirstError.Description : "Run saved!";
        await Application.Current!.MainPage.DisplayAlert("Alert", alertMessage, "Ok");
    }
}
