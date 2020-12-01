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
    public partial class Frm_Countries : Form
    {
        private static Frm_Countries frm;
        Countries Coun = new Countries();
        Cities Cit = new Cities();
        int p, x, y;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Countries CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new Frm_Countries();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }

        public Frm_Countries()
        {
             if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Coun.CloseFormCountries();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Coun.IsNotNull("Add");
        }

        private void listCoun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coun.FullC_NAME();
        }

        private void listCoun_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Coun.New_NAME();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Coun.IsNotNull("Edit");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Coun.IsNotNull("Delete");
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

        private void btnCities_Click(object sender, EventArgs e)
        {
            Cit.OpenFormCities(false);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
        }
    }
}
