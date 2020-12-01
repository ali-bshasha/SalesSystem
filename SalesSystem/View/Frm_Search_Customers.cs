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
    public partial class Frm_Search_Customers : Form
    {
        int p, x, y;
        Search_Customers srcCust = new Search_Customers();
        private static Frm_Search_Customers frm;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Search_Customers CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new Frm_Search_Customers();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }


        public Frm_Search_Customers()
        {

            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void Frm_Search_Customers_Load(object sender, EventArgs e)
        {
            srcCust.search_Customers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            srcCust.search_Customers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            srcCust.CloseFrom();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (p==1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            srcCust.selectCsut();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
        }
    }
}
