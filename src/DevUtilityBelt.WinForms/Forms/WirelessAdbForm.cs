using DevUtilityBelt.Core.ViewModels;
using DevUtilityBelt.WinForms.Extensions;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtilityBelt.WinForms.Forms
{
    public partial class WirelessAdbForm : Form, IViewFor<WirelessAdbViewModel>
    {
        public WirelessAdbForm(WirelessAdbViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            ViewModel.AppendLogAction = log =>
            {
                if (string.IsNullOrWhiteSpace(log))
                    return;

                textBoxLog.SafeAppendText($"{log}{Environment.NewLine}");
            };
            ViewModel.ClearLogAction = () =>
            {
                textBoxLog.SafeClear();
            };

            this.Bind(ViewModel, vm => vm.AppTitle, v => v.Text);

            this.OneWayBind(ViewModel, vm => vm.IsScanning, v => v.buttonScan.Enabled, x => !x);
            this.BindCommand(ViewModel, vm => vm.ScanDevicesCommand, v => v.buttonScan);

            this.OneWayBind(ViewModel, vm => vm.IsScanning, v => v.buttonConnect.Enabled, x => !x);
            this.BindCommand(ViewModel, vm => vm.ConnectDeviceCommand, v => v.buttonConnect);

            this.OneWayBind(ViewModel, vm => vm.Devices, v => v.listBoxDeviceList.DataSource);
            this.Bind(ViewModel, vm => vm.SelectedDevice, v => v.listBoxDeviceList.SelectedItem);
            
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WirelessAdbViewModel? ViewModel { get; set; }
        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (WirelessAdbViewModel?) value; }
    }
}
