namespace Solution.DesktopApp;

    public partial class App : Application
    {
        public App()
        {
			ExceptionHandler.UnhandledException += OnException;

			InitializeComponent();
		}

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

	private void OnException(object sender, UnhandledExceptionEventArgs e)
	{
		var exception = e.ExceptionObject as Exception;
		
	}
}