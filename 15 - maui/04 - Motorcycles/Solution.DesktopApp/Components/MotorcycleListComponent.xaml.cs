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

    public MotorcycleListComponent()
	{
		InitializeComponent();
    }
}