using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesSystem.Controle;
namespace SalesSystem.View
{
    public partial class Frm_Customers : Form
    {
        Cust cust = new Cust();
        private static Frm_Customers frm;
        int p, x, y;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Customers CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new Frm_Customers();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }

        public Frm_Customers()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void Frm_Customers_Load(object sender, EventArgs e)
        {
            cust.Get_Last_Record();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cust.Get_Last_Record();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cust.CheckValue("add");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cust.CloseFormCustomers();
        }

        private void CustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cust.CheckValue("edit");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cust.CheckValue("delete");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cust.open_frm_search();
            
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            cust.SelectImage();
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
            this.Opacity = 100;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (p==1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
                this.Opacity = 10;
            }
        }
    }
}
