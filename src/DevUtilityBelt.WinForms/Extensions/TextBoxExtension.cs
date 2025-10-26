using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.WinForms.Extensions
{
    public static class TextBoxExtension
    {
        public static void SafeAppendText(this System.Windows.Forms.TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => textBox.AppendText(text)));
            }
            else
            {
                textBox.AppendText(text);
            }
        }

        public static void SafeClear(this System.Windows.Forms.TextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => textBox.Clear()));
            }
            else
            {
                textBox.Clear();
            }
        }
    }
}
