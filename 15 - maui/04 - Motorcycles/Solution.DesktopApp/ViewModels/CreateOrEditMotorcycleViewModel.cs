namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class CreateOrEditMotorcycleViewModel(
    AppDbContext dbContext,
    IMotorcycleService motorcycleService/*,
    IGoogleDriveService googleDriveService*/) : MotorcycleModel(), IQueryAttributable
{
    #region life cycle commands

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

    #endregion

    #region validation commands

    public IRelayCommand CubicValidationCommand => new RelayCommand(() => this.Cubic.Validate());
    public IRelayCommand ReleaseYearValidationCommand => new RelayCommand(() => this.ReleaseYear.Validate());
    public IRelayCommand ModelValidationCommand => new RelayCommand(() => this.Model.Validate());

    public IRelayCommand ManufacturerIndexChangedCommand => new RelayCommand(() => this.Manufacturer.Validate());
    public IRelayCommand CylinderIndexChangedCommand => new RelayCommand(() => this.CylindersNumber.Validate());

    #endregion

    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private ICollection<ManufacturerModel> manufacturers = [];

    [ObservableProperty]
    private IList<uint> cylinders = [1, 2, 3, 4, 6, 8];

    private async Task OnAppearingAsync()
    { }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSubmitAsync() => await asyncButtonAction();

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

    private async Task OnUpdateAsync()
    {
        if (!IsFormValid())
        {
            await Application.Current!.MainPage.DisplayAlert("Alert", "All fields must be filled", "Ok");
            return;
        }

        var result = await motorcycleService.UpdateAsync(this);

        if (result.IsError)
        {
            await Application.Current!.MainPage.DisplayAlert("Error", result.FirstError.Description, "Ok");
            return;
        }
        await Application.Current!.MainPage.DisplayAlert("Success", "Motorcycle updated!", "Ok");
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

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(() => LoadManufacturers());

        bool hasValue = query.TryGetValue("Motorcycle", out object result);

        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Create Motorcycle";
            return;
        }

        MotorcycleModel motorcycle = result as MotorcycleModel;

        this.Id = motorcycle.Id ;
        this.Manufacturer.Value = motorcycle.Manufacturer.Value;
        this.Model.Value = motorcycle.Model.Value;
        this.Cubic.Value = motorcycle.Cubic.Value;
        this.ReleaseYear.Value = motorcycle.ReleaseYear.Value;
        this.CylindersNumber.Value = motorcycle.CylindersNumber.Value;
        asyncButtonAction = OnUpdateAsync;
        Title = "Update Motorcycle";
    }

    private async Task LoadManufacturers()
    {
        Manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                     .OrderBy(x => x.Name)
                                                     .Select(x => new ManufacturerModel(x))
                                                     .ToListAsync();
    }
}
