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
    public partial class YarpForm : Form, IViewFor<YarpViewModel>
    {
        public YarpForm(YarpViewModel viewModel)
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

            this.OneWayBind(ViewModel, vm => vm.AppTitle, v => v.Text);

            this.Bind(ViewModel, vm => vm.LocalhostPort, v => v.numericUpstreamPort.Value);
            this.OneWayBind(ViewModel, vm => vm.IsConnected, v => v.numericUpstreamPort.Enabled, x => !x);
            this.Bind(ViewModel, vm => vm.PublicPort, v => v.numericPublicPort.Value);
            this.OneWayBind(ViewModel, vm => vm.IsConnected, v => v.numericPublicPort.Enabled, x => !x);

            this.OneWayBind(ViewModel, vm => vm.ConnectText, v => v.buttonConnect.Text);
            this.BindCommand(ViewModel, vm => vm.ConnectToggleCommand, v => v.buttonConnect);

            this.BindCommand(ViewModel, vm => vm.ClearLogCommand, v => v.buttonClearLog);
            
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public YarpViewModel? ViewModel { get; set; }
        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (YarpViewModel?) value; }
    }
}
