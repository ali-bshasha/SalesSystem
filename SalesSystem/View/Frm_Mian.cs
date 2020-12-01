using SalesSystem.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace SalesSystem.View
{
    public partial class Frm_Mian : Form
    {
        int p0, x, y;
        private static Frm_Mian frm;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Mian CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new Frm_Mian();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        public Frm_Mian()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }
        Controle.Cust cust = new Controle.Cust();
        Suppliers Sup = new Suppliers();
        Items Item = new Items();
        private void button1_Click(object sender, EventArgs e)
        {
            cust.OpenFormCustomers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (panel4.Width==159)
            {
                panel4.Width = 60;
                button18.Text = "<";
            }
            else
            {
                panel4.Width = 159;
                button18.Text = ">";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sup.OpenFormSuppliers();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p0 = 1;
            x = e.X;
            y = e.Y;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Item.OpenFormItems();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (p0 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
            
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            p0 = 0;
        }
    }
}
