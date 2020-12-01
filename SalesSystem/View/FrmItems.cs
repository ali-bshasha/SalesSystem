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

namespace SalesSystem.View
{
    public partial class FrmItems : Form
    {
        private static FrmItems frm;
        int x, y, p;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmItems CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmItems();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        public FrmItems()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }
        Items Item = new Items();
        Categorizations Cat = new Categorizations();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cat.OpenFormCategorizations();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (p == 1)
            {
            this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Item.CloseFormItems();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Item.CloseFormItems();
        }

        private void cmbCategorizations_DropDown(object sender, EventArgs e)
        {
            Item.GetAllCategorizations();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
        }
    }
}
