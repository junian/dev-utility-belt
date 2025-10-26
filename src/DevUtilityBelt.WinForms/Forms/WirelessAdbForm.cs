using DevUtilityBelt.Core.ViewModels;
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
        public WirelessAdbForm()
        {
            InitializeComponent();

            ViewModel = new WirelessAdbViewModel();

            this.Bind(ViewModel, vm => vm.AppTitle, v => v.Text);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WirelessAdbViewModel? ViewModel { get; set; }
        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (WirelessAdbViewModel?) value; }
    }
}
