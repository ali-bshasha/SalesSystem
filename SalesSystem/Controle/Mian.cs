using SalesSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace SalesSystem.Controle
{
    
    class Mian
    {
        public FormWindowState WindowState { get; private set; }

        public void ControleSizeNormelAndMax()
        {
            if (WindowState == FormWindowState.Normal)
            {
                Frm_Mian.CV.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Frm_Mian.CV.WindowState = FormWindowState.Normal;

            }
        }
        
    }
}
