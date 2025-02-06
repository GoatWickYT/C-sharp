namespace Solution.DesktopApp.Components;

public partial class MotorcycleListComponent : ContentView
{
	public static readonly BindableProperty MotorcycleProperty = BindableProperty.Create(
        propertyName: nameof(Motorcycle),
        returnType: typeof(MotorcycleModel),
        declaringType: typeof(MotorcycleListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );

    public MotorcycleModel Motorcycle
    {
        get => (MotorcycleModel)GetValue(MotorcycleProperty);
        set => SetValue(MotorcycleProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand(OnDeleteAsync);

    public MotorcycleListComponent()
	{
		InitializeComponent();
    }

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            {"Motorcycle", this.Motorcycle }
        };
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditMotorcycleView.Name, navigationQueryParameter);
    }

    private async Task OnDeleteAsync()
    {
        var result = await Application.Current.MainPage.DisplayAlert("Delete", "Are you sure?", "Yes", "No");
    }
}