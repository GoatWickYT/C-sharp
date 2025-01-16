namespace Solution.DesktopApp;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel => this.BindingContext as MainPageViewModel;

    public string Name => nameof(MainPage);

    public MainPage(MainPageViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}
