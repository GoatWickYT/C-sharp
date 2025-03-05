namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class CreateOrEditMotorcycleViewModel(
    AppDbContext dbContext,
    IMotorcycleService motorcycleService,
    IGoogleDriveService googleDriveService) : MotorcycleModel(), IQueryAttributable
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
    public IRelayCommand TypeIndexChangedCommand => new RelayCommand(() => this.Type.Validate());
    public IRelayCommand CylinderIndexChangedCommand => new RelayCommand(() => this.CylindersNumber.Validate());

    #endregion

    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public IAsyncRelayCommand ImageSelectCommand => new AsyncRelayCommand(OnImageSelectAsync);

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private ICollection<ManufacturerModel> manufacturers = [];

    [ObservableProperty]
    private ICollection<TypeModel> types = [];

    [ObservableProperty]
    private IList<uint> cylinders = [1, 2, 3, 4, 6, 8];

    [ObservableProperty]
    private ImageSource image;

    private FileResult selectedFile = null;

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

        await UploadImageAsync();

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

        await UploadImageAsync();

        var result = await motorcycleService.UpdateAsync(this);

        if (result.IsError)
        {
            await Application.Current!.MainPage.DisplayAlert("Error", result.FirstError.Description, "Ok");
            return;
        }
        await Application.Current!.MainPage.DisplayAlert("Success", "Motorcycle updated!", "Ok");
    }

    private async Task OnImageSelectAsync()
    {
        selectedFile = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Please select the motorcycle image"
        });

        if (selectedFile is null)
        {
            return;
        }

        var stream = await selectedFile.OpenReadAsync();
        Image = ImageSource.FromStream(() => stream);
    }

    private async Task UploadImageAsync()
    {
        if (selectedFile is not null)
        {
            var imageUploadResult = await googleDriveService.UploadFileAsync(selectedFile);

            var message = imageUploadResult.IsError ? imageUploadResult.FirstError.Description : "Motorcycle image uploaded";
            var title = imageUploadResult.IsError ? "Error" : "Information";

            await Application.Current.MainPage.DisplayAlert(title, message, "OK");

            this.ImageId = imageUploadResult.IsError ? null : imageUploadResult.Value.Id;
            this.WebContentLink = imageUploadResult.IsError ? null : imageUploadResult.Value.WebContentLink;
        }
    }

    private void ClearForm()
    {
        this.Manufacturer.Value = null;
        this.Model.Value = string.Empty;
        this.Cubic.Value = null;
        this.ReleaseYear.Value = null;
        this.CylindersNumber.Value = null;
        this.Type.Value = null;
    }

    private bool IsFormValid()
    {
        this.Manufacturer.Validate();
        this.Model.Validate();
        this.Cubic.Validate();
        this.ReleaseYear.Validate();
        this.CylindersNumber.Validate();
        this.Type.Validate();

        return (this.Manufacturer?.IsValid ?? false) &&
               this.Model.IsValid &&
               this.Cubic.IsValid &&
               this.ReleaseYear.IsValid &&
               this.CylindersNumber.IsValid&&
               (this.Type?.IsValid ?? false);
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(LoadManufacturers);
        await Task.Run(LoadTypes);

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
        this.Type.Value = motorcycle.Type.Value;
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

    private async Task LoadTypes()
    {
        Types = await dbContext.Types.AsNoTracking()
                                                     .OrderBy(x => x.Name)
                                                     .Select(x => new TypeModel(x))
                                                     .ToListAsync();
    }
}
