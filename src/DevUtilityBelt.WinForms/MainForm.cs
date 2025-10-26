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

namespace DevUtilityBelt.WinForms
{
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        public MainForm()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            this.Bind(ViewModel, vm => vm.AppIcon, v => v.Icon, 
                vmToViewConverter: iconBytes => 
                {
                    if(iconBytes == null || iconBytes.Length == 0)
                    {
                        return null;
                    }

                    using var ms = new System.IO.MemoryStream(buffer: iconBytes);
                    return new Icon(ms);
                },
                viewToVmConverter: icon => 
                {
                    using var ms = new System.IO.MemoryStream();
                    icon?.Save(ms);
                    return ms.ToArray();
                });
            this.Bind(ViewModel, vm => vm.AppTitle, v => v.Text);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MainViewModel? ViewModel { get; set; }

        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (MainViewModel?) value; }
    }
}
