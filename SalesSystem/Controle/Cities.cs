using SalesSystem.Modle;
using SalesSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.Controle
{
    class Cities
    {
        API Cit = new API();
        
        public void OpenFormCities(bool IsPus)
        {
            if (IsPus == true)
            {
                FrmSuppliers.CV.Enabled = false;
                FrmCities.CV.lblCheck.Text = "1";
            }
            else
            {
                Frm_Countries.CV.Enabled = false;
                FrmCities.CV.lblCheck.Text = "0";
            }
            FrmCities.CV.Show();
            FullC_NAME();
            GetAllCountries();
            
        }
        public void CloseFormCities()
        {
            if (FrmCities.CV.lblCheck.Text== "1")
            {
                FrmSuppliers.CV.Enabled = true;
            }
            else
            {
                Frm_Countries.CV.Enabled = true;
            }
            FrmCities.CV.Close();
        }
        public void CleanOb()
        {
            Cit.Table = "Countries";
            Cit.Falds = new string[] { "*" };
            Cit.where = null;
            Cit.param = null;
            Cit.Name = null;
            Cit.prm = null;
            Cit.value = null;

        }
        public void FullC_NAME()
        {
            FrmCities.CV.CT_NAME.Text = FrmCities.CV.listCities.Text.ToString();
            FrmCities.CV.btnAdd.Enabled = false;
            FrmCities.CV.btnEdit.Enabled = true;
            FrmCities.CV.btnDelete.Enabled = true;
            FrmCities.CV.btnNew.Enabled = true;

        }
        public void New_NAME()
        {
            FrmCities.CV.CT_NAME.Text = "";
            FrmCities.CV.btnAdd.Enabled = true;
            FrmCities.CV.btnEdit.Enabled = false;
            FrmCities.CV.btnDelete.Enabled = false;
            FrmCities.CV.btnNew.Enabled = false;
            FrmCities.CV.CT_NAME.Focus();

        }
        public void GetAllCountries()
        {
            CleanOb();
            DataTable Dt = new DataTable();
            Cit.Table = "Countries";
            Cit.Falds = new string[] { "*" };
            Cit.where = "order by C_NAME";
            FrmCities.CV.listCoun.DataSource = Cit.GetDataWithParameters();
            FrmCities.CV.listCoun.DisplayMember = "C_NAME";
            FrmCities.CV.listCoun.ValueMember = "C_ID";
            GetCities();


        }
        public void GetCities()
        {
            CleanOb();
            
            if (FrmCities.CV.listCoun.SelectedIndex>-1)
            {
                FrmCities.CV.listCities.DataSource = null;
                Cit.Table = "Cities";
                Cit.Falds = new string[] { "*" };
                Cit.param = new SqlParameter[1];
                Cit.param[0] = new SqlParameter("@C_ID", SqlDbType.Int);
                try
                {
                    Cit.param[0].Value = Convert.ToInt32(FrmCities.CV.listCoun.SelectedValue);
                }
                catch (Exception)
                {
                    Cit.param[0].Value = 0;
                   
                }
                
                Cit.where = "where C_ID = @C_ID order by CT_Name ";
                FrmCities.CV.listCities.DataSource = Cit.GetDataWithParameters();
                FrmCities.CV.listCities.DisplayMember = "CT_Name";
                FrmCities.CV.listCities.ValueMember = "CT_ID";
            }
            else
            {
                FrmCities.CV.listCities.DataSource = null;  
            }
            if (FrmCities.CV.listCities.Items.Count <= 0)
            {
                New_NAME();
            }
            else
            {
                FullC_NAME();
            }

        }
        public void IsNotNull(string op)
        {
            if (op == "Delete")
            {
                Delete();
                return;
            }
            if (FrmCities.CV.CT_NAME.Text == "" )
            {
                MessageBox.Show("يجب ادخل اسم المدينة قبل اتمام العملية", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmCities.CV.CT_NAME.Focus();
                return;
            }
            else if (FrmCities.CV.listCoun.SelectedIndex < 0)
            {
                MessageBox.Show("يجب ادخل أختيار الدولة قبل اتمام العملية", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (op == "Add")
            {
                IsNotFind();
            }
            if (op == "Edit")
            {
                Edit();
            }
        
        }
        /*=======================start Add Countries======================*/
        public void IsNotFind()
        {
            CleanOb();
            DataTable Dt = new DataTable();
            string C_NAME = FrmCities.CV.CT_NAME.Text;
            Cit.Table = "Cities";
            Cit.Falds = new string[] { "*" };
            Cit.where = "where CT_Name = @CT_Name order by CT_Name ";
            Cit.param = new SqlParameter[1];
            Cit.param[0] = new SqlParameter("@CT_Name", SqlDbType.NVarChar, 150);
            Cit.param[0].Value = C_NAME;
            Dt = Cit.GetDataWithParameters();
            if (Dt.Rows.Count > 0)
            {
                MessageBox.Show("هدة المدينة موجدة بالفعل", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddCities();
            }
        }
        public void AddCities()
        {
            CleanOb();
            int t = 0;
            string C_NAME = FrmCities.CV.CT_NAME.Text;
            Cit.Table = "Cities";
            Cit.Falds = new string[] { "CT_Name", "C_ID" };
            Cit.param = new SqlParameter[2];
            Cit.param[0] = new SqlParameter("@CT_Name", SqlDbType.NVarChar, 150);
            Cit.param[0].Value = FrmCities.CV.CT_NAME.Text;

            Cit.param[1] = new SqlParameter("@C_ID", SqlDbType.Int);
            Cit.param[1].Value = Convert.ToInt32(FrmCities.CV.listCoun.SelectedValue); ;

            t = Cit.InsertWithParameters();
            GetCities();
            if (t == 1)
            {
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("لم تنجح عملية الإضاقة", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        /*=======================End Add Countries======================*/
        /*=======================Start Edit Countries===================*/
        public void Edit()
        {
            CleanOb();
            string id;
            int t = 0;
            try
            {
                id = FrmCities.CV.listCoun.SelectedValue.ToString();
            }
            catch (Exception)
            {
                return;
            }
            if (MessageBox.Show("سوف يتم حفط هده التعديلات , هل تريد الاستمرار؟", "تعديل البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != "")
                {
                    Cit.Table = "Cities";
                    Cit.Falds = new string[] { "CT_ID", "CT_Name", "C_ID" };
                    Cit.param = new SqlParameter[3];

                    Cit.param[0] = new SqlParameter("@CT_ID", SqlDbType.Int);
                    Cit.param[0].Value = Convert.ToInt32(FrmCities.CV.listCities.SelectedValue);

                    Cit.param[1] = new SqlParameter("@CT_Name", SqlDbType.NVarChar, 150);
                    Cit.param[1].Value = FrmCities.CV.CT_NAME.Text;

                    Cit.param[2] = new SqlParameter("@C_ID", SqlDbType.Int);
                    Cit.param[2].Value =id;

                    Cit.FaldsCansale = new string[] { "CT_ID" };
                    Cit.where = "where CT_ID = @CT_ID";
                    t = Cit.UpdateWithParameters();
                    GetCities();
                    if (t == 1)
                    {
                        MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("لم تنجح عملية التعديل", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        /*=======================End Edit Countries===================*/
        /*============================================================*/
        /*=====================Start Delete Countries=================*/
        public void Delete()
        {

            string id;
            CleanOb();
            int t = 0;
            try
            {
                id = FrmCities.CV.listCities.SelectedValue.ToString(); 
            }
            catch (Exception)
            {

                return;
            }
            if (MessageBox.Show("سوف يتم حدف هده السجل , هل تريد الاستمرار؟", "تعديل البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != "")
                {
                    Cit.Table = "Cities";
                    Cit.param = new SqlParameter[1];
                    Cit.param[0] = new SqlParameter("@CT_ID", SqlDbType.Int);
                    Cit.param[0].Value = Convert.ToInt32(id);
                    Cit.FaldsCansale = new string[] { "CT_ID" };
                    Cit.where = "where CT_ID = @CT_ID";
                    t = Cit.DeleteWithParameters();
                    GetCities();
                    if (t == 1)
                    {
                        MessageBox.Show("تمت عملية الحدف بنجاح", "عملية الحدف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("لم تنجح عملية الحدف", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    return;
                }

            }
        }
        /*=====================End Delete Countries===================*/
    }
}
