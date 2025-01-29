namespace Solution.DesktopApp.Views;

public partial class MotorcycleListView : ContentPage
{
	public MotorcycleListViewModel ViewModel => this.BindingContext as MotorcycleListViewModel;

	public static string Name => nameof(MotorcycleListView);

    public MotorcycleListView(MotorcycleListViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}