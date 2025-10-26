using DevUtilityBelt.Core.Services;
using DevUtilityBelt.Core.ViewModels;
using DevUtilityBelt.WinForms.Forms;
using DevUtilityBelt.WinForms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevUtilityBelt.WinForms
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IconService>();

            // Register view models
            services.AddTransient<MainViewModel>();
            services.AddTransient<YarpViewModel>();
            services.AddTransient<WirelessAdbViewModel>();

            services.AddTransient<MainForm>();
            services.AddTransient<YarpForm>();
            services.AddTransient<WirelessAdbForm>();

            Services = services.BuildServiceProvider();

            Application.Run(Services.GetRequiredService<MainForm>());
        }
    }
}