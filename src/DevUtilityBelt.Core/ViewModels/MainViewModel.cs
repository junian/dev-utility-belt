using CommunityToolkit.Mvvm.ComponentModel;
using DevUtilityBelt.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.Core.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _appTitle = "Dev Utility Belt";

        [ObservableProperty]
        private byte[] _appIcon = Resources.Favicon;

        [ObservableProperty]
        private string _menuItemShow = "Show";

        [ObservableProperty]
        private string _menuItemExit = "Exit";
    }
}
