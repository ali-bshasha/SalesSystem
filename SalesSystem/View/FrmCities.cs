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
    public partial class FrmCities : Form
    {
        Cities Cit = new Cities();
        private static FrmCities frm;
        int p, x, y;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmCities CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmCities();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        public FrmCities()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cit.CloseFormCities();
        }

        private void listCoun_DropDown(object sender, EventArgs e)
        {
            
        }

        private void listCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cit.FullC_NAME();
        }

        private void listCoun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cit.GetCities();
        }

        private void listCoun_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Cit.New_NAME();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cit.IsNotNull("Add");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Cit.IsNotNull("Edit");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cit.IsNotNull("Delete");
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
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
