using SalesSystem.Modle;
using SalesSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Controle
{
    class SearchSuppliers
    {
        API SupSer = new API();

        DataTable DT;

        public SearchSuppliers()
        {
            SupSer.Table = "Suppliers";
            SupSer.Falds = new string[] { "*" };
            SupSer.Name = null;
            SupSer.value = null;
            SupSer.isint = null;
            SupSer.where = null;
        }

        public void search_Suppliers()
        {
            var f = FrmSearchSuppliers.CV;
            
            int select = f.cmb_search.SelectedIndex;
            string txt = f.txt_search.Text;
            SupSer.Falds = new string[] { "SupplierCode", "SupplierName", "Mobile" };
            SupSer.param = new SqlParameter[3];

            SupSer.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
            SupSer.param[0].Value = txt;

            SupSer.param[1] = new SqlParameter("@SupplierName", SqlDbType.NVarChar, 100);
            SupSer.param[1].Value = txt;

            SupSer.param[2] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
            SupSer.param[2].Value = txt;

            SupSer.Name = new string[] { "رمز المورد", "اسم المورد", "رقم الهاتف" };
            if (txt.Length == 0)
            {
                SupSer.where = "order by SupplierName ";
            }
            else if (select == 0)
            {
                SupSer.where = $"where SupplierCode like '%'+@SupplierCode+'%' order by SupplierCode";
            }
            else if (select == 1)
            {
                SupSer.where = $"where SupplierName like '%'+@SupplierName+'%' order by SupplierName";
            }
            else if (select == 2)
            {
                SupSer.where = $"where Mobile like '%'+@Mobile+'%' order by SupplierName";
            }
            else
            {
                SupSer.where = $"where SupplierCode + SupplierName + Mobile  like '%'+@SupplierName+'%' order by SupplierName";
            }
            FrmSearchSuppliers.CV.dataGridView1.DataSource = SupSer.GetDataWithParameters();
        }
        public void selectSuppliers()
        {
            string SupSel = null;
            DataTable Dt = new DataTable();
            var f = FrmSearchSuppliers.CV;
            var fs = FrmSuppliers.CV;
            try
            {
                f.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                f.dataGridView1 = null;
            }
            if (f.dataGridView1 == null)
            {
                SupSel = null;
            }
            else
            {
                SupSel = f.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }


            if (SupSel != null)
            {
                SupSer.Falds = new string[] { "SupplierCode", "SupplierName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status", "Sup_Image" };
                SupSer.Name = null;
                SupSer.Table = "Suppliers";

                SupSer.param = new SqlParameter[1];

                SupSer.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
                SupSer.param[0].Value = SupSel;
                SupSer.where = $"where SupplierCode =@SupplierCode";
                Dt = SupSer.GetDataWithParameters();
                if (Dt.Rows.Count != 0)
                {
                    fs.SupplierCode.Text = Dt.Rows[0]["SupplierCode"].ToString();
                    fs.SupplierName.Text = Dt.Rows[0]["SupplierName"].ToString();
                    fs.Address.Text = Dt.Rows[0]["Address"].ToString();
                    fs.Country.DataSource = null;
                    for (int i = 0; i < fs.Country.Items.Count; i++)
                    {
                        fs.Country.Items.RemoveAt(i);
                    }
                    fs.Country.Items.Add(Dt.Rows[0]["Country"].ToString());
                    fs.Country.SelectedIndex = 0;
                    fs.City.DataSource = null;

                    for (int i = 0; i < fs.City.Items.Count; i++)
                    {
                        fs.City.Items.RemoveAt(i);
                    }
                    fs.City.Items.Add(Dt.Rows[0]["City"].ToString());
                    fs.City.SelectedIndex = 0;
                    fs.Mobile.Text = Dt.Rows[0]["Mobile"].ToString();
                    fs.Fax.Text = Dt.Rows[0]["Fax"].ToString();
                    fs.Facebook.Text = Dt.Rows[0]["Facebook"].ToString();
                    fs.Email.Text = Dt.Rows[0]["Email"].ToString();
                    fs.Note.Text = Dt.Rows[0]["Note"].ToString();
                    fs.credit.Text = Dt.Rows[0]["credit"].ToString();
                    fs.debit.Text = Dt.Rows[0]["debit"].ToString();
                    fs.balance.Text = Dt.Rows[0]["balance"].ToString();
                    fs.status.Text = Dt.Rows[0]["status"].ToString();
                    string x = Convert.ToString(Dt.Rows[0]["Sup_Image"]);
                    if (x == "")
                    {
                        fs.Sup_Image.Image = null;
                    }
                    else
                    {
                        byte[] image = (byte[])Dt.Rows[0]["Sup_Image"];
                        MemoryStream ms = new MemoryStream(image);
                        fs.Sup_Image.Image = Image.FromStream(ms);
                    }
                    fs.btnNew.Enabled = true;
                    fs.btnSave.Enabled = false;
                    fs.btnEdit.Enabled = true;
                    fs.btnDelete.Enabled = true;
                    CloseFrom();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        public void CloseFrom()
        {
            FrmSuppliers.CV.Enabled = true;
            FrmSearchSuppliers.CV.Close();
        }
    }
}
