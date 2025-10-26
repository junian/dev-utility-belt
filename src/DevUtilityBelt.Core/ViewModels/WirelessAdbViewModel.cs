using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.Core.ViewModels
{
    public partial class WirelessAdbViewModel: ObservableObject
    {
        [ObservableProperty]
        private string _appTitle = "Wireless ADB";
    }
}
