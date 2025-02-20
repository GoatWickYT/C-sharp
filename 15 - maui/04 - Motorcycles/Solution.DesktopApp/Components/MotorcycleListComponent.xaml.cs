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

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(CommandParameter),
        returnType: typeof(string),
        declaringType: typeof(MotorcycleListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        propertyName: nameof(DeleteCommand),
        returnType: typeof(IAsyncRelayCommand),
        declaringType: typeof(MotorcycleListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }



    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

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
}