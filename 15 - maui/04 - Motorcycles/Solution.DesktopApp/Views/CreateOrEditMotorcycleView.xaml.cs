namespace Solution.DesktopApp.Views;

public partial class CreateOrEditMotorcycleView : ContentPage
{
	public CreateOrEditMotorcycleViewModel ViewModel => this.BindingContext as CreateOrEditMotorcycleViewModel;

	public static string Name => nameof(CreateOrEditMotorcycleView);

    public CreateOrEditMotorcycleView(CreateOrEditMotorcycleViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}