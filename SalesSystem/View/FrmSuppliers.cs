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
    public partial class FrmSuppliers : Form
    {
        Suppliers Sup = new Suppliers();
        Countries Coun = new Countries();
        Cities Cit = new Cities();
        private static FrmSuppliers frm;
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmSuppliers CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmSuppliers();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        public FrmSuppliers()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Sup.CloseFormSuppliers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Coun.OpenFormCountries();
        }

        private void CmbCoun_DropDown(object sender, EventArgs e)
        {
            Sup.GetAllCountries();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            Cit.OpenFormCities(true);
        }

        private void CmbCities_DropDown(object sender, EventArgs e)
        {
            Sup.GetCities();
        }

        private void Country_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sup.CheckValue("add");
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            Sup.SelectImage();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Sup.CheckValue("edit");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Sup.OpenFromShearchSuppliers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Sup.CheckValue("delete");
        }

        private void Country_SelectedValueChanged(object sender, EventArgs e)
        {
            Sup.GetCities();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Sup.Get_Last_Record();
        }
    }
}
