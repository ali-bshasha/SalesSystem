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
    class Countries
    {
        API Coun = new API();


        //تنظيف خصائس الكلاس 
        public void CleanOb()
        {
            Coun.Table = "Countries";
            Coun.Falds = new string[] { "*" };
            Coun.where = null;
            Coun.param = null;
            Coun.Name = null;
            Coun.prm = null;
            Coun.value = null;

        }


        //عند فتح نافيد الدول
        public void OpenFormCountries()
        {
            CleanOb();
            FrmSuppliers.CV.Enabled = false;
            Frm_Countries.CV.Show();
            GetAllCountries();
            FullC_NAME();
        }


        //جلب كل الدول
        public void GetAllCountries()
        {
            CleanOb();
            DataTable Dt = new DataTable();
            Coun.Table = "Countries";
            Coun.Falds = new string[] { "*" };
            Coun.where = "order by C_NAME";
            Frm_Countries.CV.listCoun.DataSource = Coun.GetDataWithParameters();
            Frm_Countries.CV.listCoun.DisplayMember = "C_NAME";
            Frm_Countries.CV.listCoun.ValueMember = "C_ID";
        }


        // حالة الازرار في وضعيت إضافة دول جديدة
        public void FullC_NAME()
        {
            Frm_Countries.CV.C_NAME.Text = Frm_Countries.CV.listCoun.Text.ToString();
            Frm_Countries.CV.btnAdd.Enabled = false;
            Frm_Countries.CV.btnEdit.Enabled = true;
            Frm_Countries.CV.btnDelete.Enabled = true;
            Frm_Countries.CV.btnNew.Enabled = true;

        }


        // حالة الازرار في وضعيت الحدف  دول جديدةأو العديل
        public void New_NAME()
        {
            Frm_Countries.CV.C_NAME.Text = "";
            Frm_Countries.CV.btnAdd.Enabled = true;
            Frm_Countries.CV.btnEdit.Enabled = false;
            Frm_Countries.CV.btnDelete.Enabled = false;
            Frm_Countries.CV.btnNew.Enabled = false;
            Frm_Countries.CV.C_NAME.Focus();
        }


        // التأكد من ان اسم الدول مدخل قبل عملية وتحديد العميلة المطلوبة و استدعاء الدالة المطلوبة 
        public void IsNotNull(string op)
        {
            SelectFunctoin(op);         
        }


        public void SelectFunctoin(string op)
        {
            if (op == "Add")
            {
                if (Frm_Countries.CV.C_NAME.Text == "")
                {
                    MessageBox.Show("يجب ادخل اسم الدولة قبل اتمام عملية الإضافة", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmSuppliers.CV.Focus();
                    return;
                }
                IsNotFind();
            }
            else if (op == "Edit")
            {
                if (Frm_Countries.CV.C_NAME.Text == "")
                {
                    MessageBox.Show("يجب ادخل اسم الدولة قبل اتمام عملية التعديل", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmSuppliers.CV.Focus();
                    return;
                }
                Edit();
            }

            if (op == "Delete")
            {
                Delete();
            }

        }


        //عند إغلاق نافيد الدول
        public void CloseFormCountries()
        {
            FrmSuppliers.CV.Enabled = true;
            Frm_Countries.CV.Close();
        }
       


        /*=======================start Add Countries======================*/
        
        public void IsNotFind()
        {
            CleanOb();
            DataTable Dt = new DataTable();
            string C_NAME = Frm_Countries.CV.C_NAME.Text;
            Coun.Table = "Countries";
            Coun.Falds = new string[] { "*" };
            Coun.where = "where C_NAME = @C_NAME";
            Coun.param = new SqlParameter[1];
            Coun.param[0] = new SqlParameter("@C_NAME", SqlDbType.NVarChar, 150);
            Coun.param[0].Value= Frm_Countries.CV.C_NAME.Text;
            Dt= Coun.GetDataWithParameters();
            if (Dt.Rows.Count>0)
            {
                MessageBox.Show("هدة الدولة موجدة بالفعل", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddCountries();
            }
        }


        public void AddCountries()
        {
            CleanOb();
            int t = 0;
            string C_NAME = Frm_Countries.CV.C_NAME.Text;
            Coun.Table = "Countries";
            Coun.Falds = new string[] { "C_NAME" };
            Coun.param = new SqlParameter[1];
            Coun.param[0] = new SqlParameter("@C_NAME", SqlDbType.NVarChar, 150);
            Coun.param[0].Value = Frm_Countries.CV.C_NAME.Text;

            t=Coun.InsertWithParameters();
            GetAllCountries();
            if (t==1)
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
                id = Frm_Countries.CV.listCoun.SelectedValue.ToString();
            }
            catch (Exception)
            {

                return;
            }
            if (MessageBox.Show("سوف يتم حفط هده التعديلات , هل تريد الاستمرار؟", "تعديل البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != "")
                {
                    Coun.Table = "Countries";
                    Coun.Falds = new string[] { "C_ID", "C_NAME" };
                    Coun.param = new SqlParameter[2];
                    Coun.param[0] = new SqlParameter("@C_ID", SqlDbType.Int);
                    Coun.param[0].Value = id;
                    Coun.param[1] = new SqlParameter("@C_NAME", SqlDbType.NVarChar, 150);
                    Coun.param[1].Value = Frm_Countries.CV.C_NAME.Text;
                    Coun.FaldsCansale = new string[] { "C_ID" };
                    Coun.where = "where C_ID = @C_ID";
                    t = Coun.UpdateWithParameters();
                    GetAllCountries();
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
                id = Frm_Countries.CV.listCoun.SelectedValue.ToString();
            }
            catch (Exception)
            {

                return;
            }
            if (MessageBox.Show("سوف يتم حدف هده السجل , هل تريد الاستمرار؟", "تعديل البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != "")
                {
                    Coun.Table = "Countries";
                    Coun.param = new SqlParameter[1];
                    Coun.param[0] = new SqlParameter("@C_ID", SqlDbType.Int);
                    Coun.param[0].Value = id;
                    Coun.FaldsCansale = new string[] { "C_ID" };
                    Coun.where = "where C_ID = @C_ID";
                    t = Coun.DeleteWithParameters();
                    GetAllCountries();
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
