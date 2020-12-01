using SalesSystem.Modle;
using SalesSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Controle
{
    class Items
    {
        API Itm = new API();
        //فتح نافيذة الاصناف
        public void OpenFormItems()
        {
            var f = FrmItems.CV;
            f.Show();
            Frm_Mian.CV.Enabled = false;
        }
        public void CleanOb()
        {
            Itm.Table = "Categorizations";
            Itm.Falds = new string[] { "*" };
            Itm.where = null;
            Itm.param = null;
            Itm.Name = null;
            Itm.prm = null;
            Itm.value = null;
        }
        public void GetAllCategorizations()
        {
            var f = FrmItems.CV;
            CleanOb();
            DataTable Dt = new DataTable();
            Itm.Falds = new string[] { "*" };
            Itm.where = "order by CategorizationsName";
            f.CategorizationsName.DataSource = Itm.GetDataWithParameters();
            f.CategorizationsName.DisplayMember = "CategorizationsName";
            f.CategorizationsName.ValueMember = "CategorizationsCode";
        }

        //إغلاق نافيذة الاصناف
        public void CloseFormItems()
        {
            Frm_Mian.CV.Enabled = true;
            var f = FrmItems.CV;
            f.Close(); 
        }
    }
}
