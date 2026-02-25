using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_System
{
    public class clsCommonFormMethods
    {
        static public void CenterPanel(Panel centerPanel , Form form)
        {
            centerPanel.Left = (form.ClientSize.Width - centerPanel.Width) / 2;
            centerPanel.Top = (form.ClientSize.Height - centerPanel.Height) / 2;
        }
    }
}
