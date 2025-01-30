﻿namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
	public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MotorcycleListViewModel>();
        builder.Services.AddTransient<CreateOrEditMotorcycleViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<MotorcycleListView>();
        builder.Services.AddTransient<CreateOrEditMotorcycleView>();

        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        // builder.Services.AddTransient<IGoogleDriveService, GoogleDriveService>();

        return builder;
	}
}
