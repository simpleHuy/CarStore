using System.Net.WebSockets;
using CarStore.Activation;
using CarStore.Contracts.Services;
using CarStore.Core;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Core.Repository;
using CarStore.Core.Services;
using CarStore.Models;
using CarStore.Services;
using CarStore.ViewModels;
using CarStore.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace CarStore;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar
    {
        get; set;
    }

    public App()
    {
        InitializeComponent();
        this.RequestedTheme = ApplicationTheme.Light;
        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginPage>();
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<RegisterPage>();
            services.AddTransient<FilterViewModel>();
            services.AddTransient<FilterPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            services.AddTransient<ForgotPasswordViewModel>();
            services.AddTransient<ForgotPasswordPage>();
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<ScheduleFormViewModel>();
            services.AddTransient<VerifyViewModel>();
            services.AddTransient<VerifyPage>();
            services.AddTransient<AccountPageViewModel>();
            services.AddTransient<Account>();
            services.AddTransient<CarDetailViewModel>();
            services.AddTransient<CarDetailPage>();

            services.AddTransient<CarDetailViewModel>();
            services.AddTransient<CarDetailPage>();
            services.AddTransient<SearchingViewModel>();
            services.AddTransient<SearchingPage>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));

            //var envFile = "D:\\Study\\timeForCoding\\GitHub\\CarStore\\CarStore.Core\\.env";
            var basePath = AppContext.BaseDirectory;
            var curDir = new DirectoryInfo(basePath);
            var corePath = curDir.Parent.Parent.Parent.Parent.Parent.Parent.FullName;
            var envFile = Path.Combine(corePath, "CarStore.Core", ".env");
            DotNetEnv.Env.Load(envFile);
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // add repository, dao
            services.AddScoped<ICarRepository, EfCoreCarRepository>();
            services.AddScoped<IDao<Car>, EfCoreDao<Car>>();
            services.AddScoped<IDao<TypeOfCar>, EfCoreDao<TypeOfCar>>();
            services.AddScoped<IDao<EngineType>, EfCoreDao<EngineType>>();
            services.AddScoped<IDao<Manufacturer>, EfCoreDao<Manufacturer>>();
            //services.AddScoped<IDao<>, EfCoreDao<>>();
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        await App.GetService<IActivationService>().ActivateAsync(args);
    }

}
