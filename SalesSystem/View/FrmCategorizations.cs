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
    public partial class FrmCategorizations : Form
    {
        private static FrmCategorizations frm;
        int x, y, p;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmCategorizations CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmCategorizations();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        Categorizations Cat = new Categorizations();
        SearchCategorizations SCat = new SearchCategorizations();
        public FrmCategorizations()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cat.CloseFormCategorizations();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Cat.Get_Last_Record();
        }

        private void FrmCategorizations_Load(object sender, EventArgs e)
        {
            Cat.Get_Last_Record();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cat.CheckValue("add");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Cat.CheckValue("edit");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cat.CheckValue("delete");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SCat.OpenFormSearchCategorizations();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            p = 1;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (p == 1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
            
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
        }
    }
}
