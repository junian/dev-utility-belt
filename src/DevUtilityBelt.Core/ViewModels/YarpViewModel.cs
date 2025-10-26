using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevUtilityBelt.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarp.ReverseProxy.Configuration;

namespace DevUtilityBelt.Core.ViewModels
{
    public partial class YarpViewModel : ObservableObject
    {
        private WebApplication? _app;

        [ObservableProperty]
        private string _appTitle = "Reverse Proxy";

        [ObservableProperty]
        private decimal _localhostPort = 5101;

        [ObservableProperty]
        private decimal _publicPort = 6101;

        public Action<string?>? AppendLogAction { get; set; } = null;
        public Action? ClearLogAction { get;set; } = null;

        public bool IsConnected => _app != null;

        [ObservableProperty]
        private string _connectText = "Connect";

        private readonly IMessageBoxService _messageBoxService;

        public YarpViewModel(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        private WebApplication PrepareYarp(int localhostPort, int publicPort)
        {
            var builder = WebApplication.CreateBuilder();

            var routeId = Guid.NewGuid().ToString();
            var clusterId = Guid.NewGuid().ToString();

            builder.Services.AddReverseProxy()
                .LoadFromMemory(
                    [
                        new RouteConfig
                        {
                            RouteId = routeId,
                            ClusterId = clusterId,
                            Match = new RouteMatch { Path = "{**catch-all}" },
                            Transforms =
                            [
                                // Forward *all* request headers as-is
                                new Dictionary<string, string>
                                {
                                    { "RequestHeadersCopy", "true" }
                                }
                            ]
                        }
                    ],
                    [
                        new ClusterConfig
                        {
                            ClusterId = clusterId,
                            Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
                            {
                                ["upstream-api"] = new DestinationConfig
                                {
                                    Address = $"http://localhost:{localhostPort}"
                                }
                            }
                        }
                    ]
                );

            builder.Logging.AddProvider(new TextBoxLoggerProvider((s) => AppendLogAction?.Invoke(s)));

            var app = builder.Build();

            app.Urls.Clear();
            app.Urls.Add($"http://0.0.0.0:{publicPort}");

            app.MapReverseProxy();

            return app;
        }

        [RelayCommand]
        private async Task ConnectToggleAsync()
        {
            if (!IsConnected)
            {
                await StartReverseProxy();
            }
            else
            {
                await StopReverseProxy();
            }
        }

        [RelayCommand]
        private void ClearLog()
        {
            ClearLogAction?.Invoke();
        }

        private async Task StartReverseProxy()
        {
            var localhostPort = (int)LocalhostPort;
            var publicPort = (int)PublicPort;

            _app = PrepareYarp(localhostPort, publicPort);
            await _app.StartAsync();

            ConnectText = "Disconnect";
            OnPropertyChanged(nameof(IsConnected));
        }

        private async Task StopReverseProxy()
        {
            try
            {
                if (_app != null)
                {
                    await _app.StopAsync();
                    await _app.DisposeAsync();
                }
            }
            catch (Exception ex)
            {
                _messageBoxService.Show($"Error stopping the proxy: {ex.Message}");
            }
            finally
            {
                _app = null;

                ConnectText = "Connect";
                OnPropertyChanged(nameof(IsConnected));
            }
        }

    }
}
