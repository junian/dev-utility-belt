using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevUtilityBelt.Core.Models;
using DevUtilityBelt.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace DevUtilityBelt.Core.ViewModels
{
    public partial class WirelessAdbViewModel: ObservableObject
    {
        [ObservableProperty]
        private string _appTitle = "Wireless ADB";

        [ObservableProperty]
        private bool _isScanning = false;

        public Action<string?>? AppendLogAction { get; set; } = null;
        public Action? ClearLogAction { get; set; } = null;

        public ObservableCollection<AdbDeviceInfo> Devices { get; private set; } = new ObservableCollection<AdbDeviceInfo>();

        [ObservableProperty]
        private AdbDeviceInfo? _selectedDevice = null;

        private readonly IMessageBoxService _messageBoxService;

        public WirelessAdbViewModel(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        async Task<List<AdbDeviceInfo>> DiscoverAdbDevicesAsync()
        {
            var results = new List<AdbDeviceInfo>();

            // The exact service type depends on how the wireless ADB is advertised.
            string serviceType = "_adb-tls-connect._tcp.local.";

            IReadOnlyList<IZeroconfHost> hosts = await ZeroconfResolver.ResolveAsync(serviceType);

            foreach (var host in hosts)
            {
                foreach (var svc in host.Services)
                {
                    if (svc.Value.Name == serviceType)
                    {
                        var device = new AdbDeviceInfo
                        {
                            Name = host.DisplayName,  // maybe svc.Value.TXTRecords contain a nicer name
                            Ip = host.IPAddress,
                            Port = svc.Value.Port
                        };
                        results.Add(device);
                    }
                }
            }

            return results;
        }

        [RelayCommand]
        private async Task ScanDevicesAsync()
        {
            IsScanning = true;
            AppendLogAction?.Invoke("Starting scan for ADB devices...");

            try
            {
                var devices = await DiscoverAdbDevicesAsync();
                if (devices != null)
                    Devices = new ObservableCollection<AdbDeviceInfo>(devices);
                else
                    Devices = new ObservableCollection<AdbDeviceInfo>();
            }
            catch (Exception ex)
            {
                _messageBoxService.Show("Error during scan: " + ex.Message);
            }
            finally
            {
                IsScanning = false;
                AppendLogAction?.Invoke("Scan completed.");
            }
        }

        void ConnectToDevice(AdbDeviceInfo dev)
        {
            string adbExe = "adb";  // or full path to adb.exe
            string args = $"connect {dev.Ip}:{dev.Port}";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = adbExe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                AppendLogAction?.Invoke($"Connecting with {dev.ToString()}");

                var proc = Process.Start(psi);
                var stdout = proc?.StandardOutput?.ReadToEnd();
                var stderr = proc?.StandardError?.ReadToEnd();
                proc?.WaitForExit();

                if (!string.IsNullOrWhiteSpace(stdout))
                    AppendLogAction?.Invoke($"[STDOUT] {stdout}");

                if (!string.IsNullOrWhiteSpace(stderr))
                    AppendLogAction?.Invoke($"[STDERR] {stderr}");
            }
            catch (Exception ex)
            {
                _messageBoxService.Show("Failed to invoke adb: " + ex.Message);
            }
        }

        [RelayCommand]
        private void ConnectDevice()
        {
            if (SelectedDevice == null)
                return;

            ConnectToDevice(SelectedDevice);
        }
    }
}
