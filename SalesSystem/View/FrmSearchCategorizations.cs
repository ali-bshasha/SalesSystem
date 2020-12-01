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
    public partial class FrmSearchCategorizations : Form
    {
        private static FrmSearchCategorizations frm;
        SearchCategorizations SCat = new SearchCategorizations();
        int x, y, p;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmSearchCategorizations CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmSearchCategorizations();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }

        public FrmSearchCategorizations()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SCat.CloseFormSearchCategorizations();
        }

        private void FrmSearchCategorizations_Load(object sender, EventArgs e)
        {
            SCat.GetAllCategorizations();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SCat.SearchCategorization();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SCat.SelectCategorization();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
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
    }
}
