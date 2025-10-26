using DevUtilityBelt.Core.ViewModels;
using DevUtilityBelt.WinForms.Forms;
using DevUtilityBelt.WinForms.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUtilityBelt.WinForms
{
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        private ContextMenuStrip _trayMenu;
        private IconService _iconService;

        public MainForm()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();
            _iconService = new Services.IconService();

            // Create the tray menu
            _trayMenu = new ContextMenuStrip();
            _trayMenu.Items.Add("Show", null, ShowWindow);
            _trayMenu.Items.Add("Exit", null, ExitApplication);

            notifyIconMain.Icon = _iconService.BytesToIcon(ViewModel.AppIcon)!;
            notifyIconMain.ContextMenuStrip = _trayMenu;

            this.Icon = _iconService.BytesToIcon(ViewModel.AppIcon)!;

            this.Bind(ViewModel, vm => vm.AppTitle, v => v.Text);

            var hostForms = new List<Form>
            {
                new YarpForm(),
                new WirelessAdbForm()
            };

            foreach (var hostForm in hostForms)
            {
                var tabPage = new TabPage();

                hostForm.TopLevel = false;
                hostForm.FormBorderStyle = FormBorderStyle.None;
                hostForm.Dock = DockStyle.Fill;

                tabPage.Text = hostForm.Text;

                tabPage.Controls.Add(hostForm);
                hostForm.Show();

                tabControlMain.TabPages.Add(tabPage);
            }
        }


        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (MainViewModel?)value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MainViewModel? ViewModel { get; set; }
        private void ShowWindow(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private async void ExitApplication(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //await StopReverseProxy();
            await Task.CompletedTask;
            notifyIconMain.Visible = false; // Hide tray icon before exit
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
