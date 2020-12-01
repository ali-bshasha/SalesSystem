using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using SalesSystem.Modle;
using SalesSystem.View;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace SalesSystem.Controle
{
    class Search_Customers
    {
        API CustSer = new API();
       
        DataTable DT;
        
        public Search_Customers()
        {
            CustSer.Table = "Customers";
            CustSer.Falds = new string[] { "*" };
            CustSer.Name = null;
            CustSer.value = null;
            CustSer.isint = null;
            CustSer.where = null;
        }
        
        public void search_Customers()
        {
            int select = Frm_Search_Customers.CV.cmb_search.SelectedIndex;
            string txt = Frm_Search_Customers.CV.txt_search.Text;
            CustSer.Falds = new string[] { "CustomerCode", "CustomerName", "Mobile" };
            CustSer.param = new SqlParameter[3];

            CustSer.param[0] = new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 25);
            CustSer.param[0].Value = txt;

            CustSer.param[1] = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 100);
            CustSer.param[1].Value = txt;

            CustSer.param[2] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
            CustSer.param[2].Value = txt;

            CustSer.Name = new string[] { "رمز العميل", "اسم العميل", "رقم الهاتف" };
            if (txt.Length==0)
            {
                CustSer.where = "order by CustomerName ";
            }else if (select==0)
            {
                CustSer.where = $"where CustomerCode like '%'+@CustomerCode+'%' order by CustomerCode";
            }else if (select == 1)
            {
                CustSer.where = $"where CustomerName like '%'+@CustomerName+'%' order by CustomerName";
            }
            else if (select == 2)
            {
                CustSer.where = $"where Mobile like '%'+@Mobile+'%' order by CustomerName";
            }
            else
            {
                CustSer.where = $"where CustomerCode + CustomerName + Mobile  like '%'+@CustomerName+'%' order by CustomerName";
            }
            Frm_Search_Customers.CV.dataGridView1.DataSource= CustSer.GetDataWithParameters();
        }
        public void selectCsut()
        {
            string CustSel = null;
            DataTable Dt = new DataTable();
            var f = Frm_Customers.CV;
            try
            {
                Frm_Search_Customers.CV.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                Frm_Search_Customers.CV.dataGridView1 = null;
            }
            if (Frm_Search_Customers.CV.dataGridView1 == null)
            {
                CustSel = null;
            }
            else
            {
                CustSel = Frm_Search_Customers.CV.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            
            
            if (CustSel!=null)
            {
                CustSer.Falds = new string[] { "CustomerCode", "CustomerName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status", "Cust_Image" };
                CustSer.Name = null;
                CustSer.Table = "Customers";

                CustSer.param = new SqlParameter[1];

                CustSer.param[0] = new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 25);
                CustSer.param[0].Value = CustSel;
                CustSer.where = $"where CustomerCode =@CustomerCode";
                Dt = CustSer.GetDataWithParameters();
                if (Dt.Rows.Count!=0)
                {
                    f.CustomerCode.Text = Dt.Rows[0]["CustomerCode"].ToString();
                    f.CustomerName.Text = Dt.Rows[0]["CustomerName"].ToString();
                    f.Address.Text = Dt.Rows[0]["Address"].ToString();
                    f.Country.Text = Dt.Rows[0]["Country"].ToString();
                    f.City.Text = Dt.Rows[0]["City"].ToString();
                    f.Mobile.Text = Dt.Rows[0]["Mobile"].ToString();
                    f.Fax.Text = Dt.Rows[0]["Fax"].ToString();
                    f.Facebook.Text = Dt.Rows[0]["Facebook"].ToString();
                    f.Email.Text = Dt.Rows[0]["Email"].ToString();
                    f.Note.Text = Dt.Rows[0]["Note"].ToString();
                    f.credit.Text = Dt.Rows[0]["credit"].ToString();
                    f.debit.Text = Dt.Rows[0]["debit"].ToString();
                    f.balance.Text = Dt.Rows[0]["balance"].ToString();
                    f.status.Text = Dt.Rows[0]["status"].ToString();
                    string x = Convert.ToString(Dt.Rows[0]["Cust_Image"]);
                    if (x=="")
                    {
                        f.Cust_Image.Image = null;
                    }
                    else
                    {  
                        byte[] image = (byte[])Dt.Rows[0]["Cust_Image"];
                        MemoryStream ms = new MemoryStream(image);
                        f.Cust_Image.Image = Image.FromStream(ms);
                    }
                   
                    f.btnNew.Enabled = true;
                    f.btnSave.Enabled = false;
                    f.btnEdit.Enabled = true;
                    f.btnDelete.Enabled = true;
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
            Frm_Customers.CV.Enabled = true;
            Frm_Search_Customers.CV.Close();
        }
    }
}
