using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.Core.Models
{
    public class AdbDeviceInfo
    {
        public string? Name { get; set; }
        public string? Ip { get; set; }
        public int Port { get; set; }
        public override string ToString()
            => $"{Name} ({Ip}:{Port})";
    }
}
