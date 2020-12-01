using SalesSystem.Modle;
using SalesSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Controle
{
    class SearchCategorizations
    {
        API SCat = new API();
        //دوال التحكم في النافيذة 
        //فتح نافيذة الاصناف
        public void OpenFormSearchCategorizations()
        {
            var f = FrmSearchCategorizations.CV;
            f.Show();
            FrmCategorizations.CV.Enabled = false;
        }
        //إغلاق نافيذة الاصناف
        public void CloseFormSearchCategorizations()
        {
            FrmCategorizations.CV.Enabled = true;
            var f = FrmSearchCategorizations.CV;
            f.Close();
        }
        public void CleanOb()
        {
            SCat.Table = "Categorizations";
            SCat.Falds = new string[] { "*" };
            SCat.where = null;
            SCat.param = null;
            SCat.Name = null;
            SCat.prm = null;
            SCat.value = null;
        }
        public void GetAllCategorizations()
        {
            CleanOb();
            var f = FrmSearchCategorizations.CV;
            SCat.Falds = new string[] { "CategorizationsCode", "CategorizationsName" };
            SCat.Name = new string[] { "رمز التصنيف", "التصنيف" };
           f.dataGridView1.DataSource= SCat.GetDataWithParameters();
        }
        public void SearchCategorization()
        {
            CleanOb();
            var f = FrmSearchCategorizations.CV;
            SCat.Falds = new string[] { "CategorizationsCode", "CategorizationsName" };
            SCat.Name = new string[] { "رمز التصنيف", "التصنيف" };
            SCat.param = new SqlParameter[1];
            SCat.param[0] = new SqlParameter("@CategorizationsName", SqlDbType.NVarChar, 75);
            SCat.param[0].Value = f.txtSearch.Text;
            SCat.where= $"where CategorizationsName like '%'+@CategorizationsName+'%' order by CategorizationsName";
            f.dataGridView1.DataSource = SCat.GetDataWithParameters();
        }
        public void SelectCategorization()
        {
            CleanOb();
            string CatSel = null;
            DataTable Dt = new DataTable();
            var f = FrmSearchCategorizations.CV;
            var fs = FrmCategorizations.CV;
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
                CatSel = null;
            }
            else
            {
                CatSel = f.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }

            if (CatSel != null)
            {
                SCat.Falds = new string[] { "CategorizationsCode", "CategorizationsName", "Note" };
                SCat.param = new SqlParameter[1];
                SCat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 25);
                SCat.param[0].Value = CatSel;
                SCat.where = $"where CategorizationsCode = @CategorizationsCode";
                Dt = SCat.GetDataWithParameters();
                if (Dt.Rows.Count != 0)
                {
                    fs.CategorizationsCode.Text = Dt.Rows[0]["CategorizationsCode"].ToString();
                    fs.CategorizationsName.Text = Dt.Rows[0]["CategorizationsName"].ToString();
                    fs.Note.Text = Dt.Rows[0]["Note"].ToString();
                    fs.btnNew.Enabled = true;
                    fs.btnSave.Enabled = false;
                    fs.btnEdit.Enabled = true;
                    fs.btnDelete.Enabled = true;
                    CloseFormSearchCategorizations();
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
    }
}
