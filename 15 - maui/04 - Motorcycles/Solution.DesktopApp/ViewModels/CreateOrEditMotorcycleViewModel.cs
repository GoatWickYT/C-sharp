namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class CreateOrEditMotorcycleViewModel(
    AppDbContext dbContext,
    IMotorcycleService motorcycleService/*,
    IGoogleDriveService googleDriveService*/) : MotorcycleModel()
{
    #region life cycle commands

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingkAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    #endregion

    #region validation commands

    public IRelayCommand CubicValidationCommand => new RelayCommand(() => this.Cubic.Validate());
    public IRelayCommand ReleaseYearValidationCommand => new RelayCommand(() => this.ReleaseYear.Validate());
    public IRelayCommand ModelValidationCommand => new RelayCommand(() => this.Model.Validate());

    public IRelayCommand ManufacturerIndexChangedCommand => new RelayCommand(() => this.Manufacturer.Validate());
    public IRelayCommand CylinderIndexChangedCommand => new RelayCommand(() => this.CylindersNumber.Validate());
    public IAsyncRelayCommand SaveCommand => new AsyncRelayCommand(OnSaveAsync);

    #endregion

    [ObservableProperty]
    private ICollection<ManufacturerModel> manufacturers;

    [ObservableProperty]
    private IList<uint> cylinders = [1, 2, 3, 4, 6, 8];

    private async Task OnAppearingkAsync()
    {
        Manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                     .OrderBy(x => x.Name)
                                                     .Select(x => new ManufacturerModel(x))
                                                     .ToListAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSaveAsync()
    {
        if (!IsFormValid())
        {
            await Application.Current!.MainPage.DisplayAlert("Alert", "All fields must be filled", "Ok");
            return;
        }

        ErrorOr<MotorcycleModel> serviceResponse = await motorcycleService.CreateAsync(this);
        string alertMessage = serviceResponse.IsError ? serviceResponse.FirstError.Description : "Motorcycle saved!";
        string title = serviceResponse.IsError ? "Error" : "Success";

        if (!serviceResponse.IsError)
        {
            ClearForm();
        }

        await Application.Current!.MainPage.DisplayAlert(title, alertMessage, "Ok");
    }

    private void ClearForm()
    {
        this.Manufacturer.Value = null;
        this.Model.Value = string.Empty;
        this.Cubic.Value = null;
        this.ReleaseYear.Value = null;
        this.CylindersNumber.Value = null;
    }

    private bool IsFormValid()
    {
        this.Manufacturer.Validate();
        this.Model.Validate();
        this.Cubic.Validate();
        this.ReleaseYear.Validate();
        this.CylindersNumber.Validate();

        return this.Manufacturer?.IsValid ?? false &&
               this.Model.IsValid &&
               this.Cubic.IsValid &&
               this.ReleaseYear.IsValid &&
               this.CylindersNumber.IsValid;
    }
}
