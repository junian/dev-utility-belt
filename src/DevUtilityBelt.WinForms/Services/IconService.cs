using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.WinForms.Services
{
    public class IconService
    {
        public byte[] IconToBytes(Icon icon)
        {
            using var ms = new System.IO.MemoryStream();
            icon?.Save(ms);
            return ms.ToArray();
        }

        public Icon? BytesToIcon(byte[] iconBytes)
        {
            if (iconBytes == null || iconBytes.Length == 0)
            {
                return null;
            }
            using var ms = new System.IO.MemoryStream(buffer: iconBytes);
            return new Icon(ms);
        }
    }
}
