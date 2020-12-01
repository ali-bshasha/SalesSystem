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
    class Categorizations
    {
        API Cat = new API();
        //دوال التحكم في النافيذة 
        //فتح نافيذة الاصناف
        public void OpenFormCategorizations()
        {
            var f = FrmCategorizations.CV;
            f.Show();
            FrmItems.CV.Enabled = false;
        }
        //إغلاق نافيذة الاصناف
        public void CloseFormCategorizations()
        {
            FrmItems.CV.Enabled = true;
            var f = FrmCategorizations.CV;
            f.Close();
        }
        public void CleanOb()
        {
            Cat.Table = "Categorizations";
            Cat.Falds = new string[] { "*" };
            Cat.where = null;
            Cat.param = null;
            Cat.Name = null;
            Cat.prm = null;
            Cat.value = null;
        }

        /*||==>تنظيف صناديق البيانات */
        public void CleanContrlw()
        {
            CleanOb();
            var f = FrmCategorizations.CV;
            f.CategorizationsCode.Text = "";
            f.CategorizationsName.Text = "";
            f.Note.Text = "";
        }
        /*||==>دالة تجهيز أزرار التحكم لعمليات  */
        public void statOp(string op)
        {
            var f = FrmCategorizations.CV;
            if (op == "New")
            {
                f.btnNew.Enabled = false;
                f.btnSave.Enabled = true;
                f.btnEdit.Enabled = false;
                f.btnDelete.Enabled = false;
                f.CategorizationsCode.ReadOnly = false;
                CleanContrlw();
            }
            else if (op == "ED")
            {
                f.btnNew.Enabled = true;
                f.btnSave.Enabled = false;
                f.btnEdit.Enabled = true;
                f.btnDelete.Enabled = true;
                f.CategorizationsCode.ReadOnly = true;
            }
        }
        //جلب  رمز التصنيف
        public void Get_Last_Record()
        {
            statOp("New");
            FrmCategorizations.CV.CategorizationsCode.Text = Cat.Get_Last_Record("CategorizationsAutoNumber", "CTS00000").ToString();
        }
        /*||==>  جلب زمز التصنيف المطابق لرمز المحدد لتحقق قبل عملية الحدف أو التعديل */
        public DataTable GetCategorizationsCode()
        {
            var f = FrmCategorizations.CV;
            CleanOb();
            Cat.param = new SqlParameter[1];
            Cat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 15);
            Cat.param[0].Value = f.CategorizationsCode.Text;
            Cat.where = $"where CategorizationsCode = @CategorizationsCode";
            return Cat.GetDataWithParameters();
        }
        public DataTable GetCategorizationsName()
        {
            var f = FrmCategorizations.CV;
            CleanOb();
            Cat.param = new SqlParameter[1];
            Cat.param[0] = new SqlParameter("@CategorizationsName", SqlDbType.NVarChar, 75);
            Cat.param[0].Value = f.CategorizationsName.Text;
            Cat.where = $"where CategorizationsName = @CategorizationsName";
            return Cat.GetDataWithParameters();
        }
        public DataTable GetCategorizationsNameDeffrentCode()
        {
            var f = FrmCategorizations.CV;
            CleanOb();
            Cat.param = new SqlParameter[2];

            Cat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 25);
            Cat.param[0].Value = f.CategorizationsCode.Text;
            Cat.param[1] = new SqlParameter("@CategorizationsName", SqlDbType.NVarChar, 75);
            Cat.param[1].Value = f.CategorizationsName.Text;
            Cat.where = $"where CategorizationsName = @CategorizationsName and not CategorizationsCode = @CategorizationsCode";
            return Cat.GetDataWithParameters();
        }
        /*||==>التحقق من البيانات المدخلة و تحديد العملية المطلوبة */
        public void CheckValue(string op)
        {
            var f = FrmCategorizations.CV;
            if (op == "add")
            {
                if (f.CategorizationsCode.Text == "")
                {
                    MessageBox.Show("يجب إدخال رمز التصيف", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(f.CategorizationsName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم التصيف", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FindCategorizationsForAdd();
                }
            }else if (op == "edit")
            {
                if (f.CategorizationsCode.Text == "")
                {
                    MessageBox.Show("يجب إختيار رمز التصيف", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (f.CategorizationsName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم التصيف", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FindCategorizationsForEdit();
                }
            }
            else
            {
                if (f.CategorizationsCode.Text == "")
                {
                    MessageBox.Show("يجب إختيار رمز التصيف", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                FindCategorizationsForDelete();
                }
            }
        }
        public void FindCategorizationsForAdd()
        {
            DataTable DT = new DataTable();
            DT = GetCategorizationsCode();
            if (DT.Rows.Count > 0)
            {
                MessageBox.Show("يوجد تصنيف بهداالرمز");
                return;
            }
            else if (GetCategorizationsName().Rows.Count > 0)
            {
                DT = new DataTable();
                DT = GetCategorizationsName();
                
                MessageBox.Show($"{DT.Rows[0][1].ToString()} اسم التصيف المدخل موجد مسبقان تحت الرمز ");
                return;
            }
            else
            {
                InsertCategorization();
            }

        }
        public void FindCategorizationsForEdit()
        {
            DataTable DT = new DataTable();
            DT = GetCategorizationsCode();
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد تصنيف بهداالرمز ");
                return;
            }
            else if (GetCategorizationsNameDeffrentCode().Rows.Count > 0)
            {
                DT = new DataTable();
                DT = GetCategorizationsNameDeffrentCode();
                MessageBox.Show($"{DT.Rows[0][1].ToString()} اسم التصيف المدخل موجد مسبقان تحت الرمز ");
                return;
            }
            else
            {
                UpdateCategorization();
            }

        }
        /*||==> التحقق من وجد رمز العمبل في قاعد البيانات  قبل عملية الحدف  */
        public void FindCategorizationsForDelete()
        {
            DataTable DT = new DataTable();
            DT = GetCategorizationsCode();
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("لم يتم العثور علي عميل بهذا الرقم");
            }
            else
            {
                DeleteCategorization();
            }
        }
        /*||==> دالة اضافة تصنيف جديد*/
        public void InsertCategorization()
        {
            CleanOb();
            var f = FrmCategorizations.CV;
            Cat.Falds = new string[] { "CategorizationsCode", "CategorizationsName", "Note"};
            Cat.param = new SqlParameter[3];

            Cat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 15);
            Cat.param[0].Value = f.CategorizationsCode.Text;

            Cat.param[1] = new SqlParameter("@CategorizationsName", SqlDbType.NVarChar, 75);
            Cat.param[1].Value = f.CategorizationsName.Text;

            Cat.param[2] = new SqlParameter("@Note", SqlDbType.NVarChar, 255);
            Cat.param[2].Value = f.Note.Text;

           if (Cat.InsertWithParameters() == 1)
            {
                MessageBox.Show("تم عملية الإضافة بنجاح"); ;
                statOp("ED");
            }
            else
            {
                MessageBox.Show("لم تم عملية الإضافة"); ;
            }
        }
        //تعديل تصنيف 
        public void UpdateCategorization()
        {
            var f = FrmCategorizations.CV;

            Cat.Falds = new string[] { "CategorizationsCode", "CategorizationsName", "Note" };
            Cat.param = new SqlParameter[3];

            Cat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 25);
            Cat.param[0].Value = f.CategorizationsCode.Text;

            Cat.param[1] = new SqlParameter("@CategorizationsName", SqlDbType.NVarChar, 75);
            Cat.param[1].Value = f.CategorizationsName.Text;

            Cat.param[2] = new SqlParameter("@Note", SqlDbType.NVarChar, 255);
            Cat.param[2].Value = f.Note.Text;

            Cat.FaldsCansale = new string[] { "CategorizationsCode" };
            Cat.where = $"where CategorizationsCode = @CategorizationsCode";

            if (Cat.UpdateWithParameters() == 1)
            {
                MessageBox.Show("تم عملية التعديل بنجاح");
            }
            else
            {
                MessageBox.Show("لم تم عملية التعديل"); ;
            }
        }
        /*||=========================>|الدوال  الخاصة بعمليةالحدف|<=========================||*/

        public void DeleteCategorization()
        {
            var f = FrmCategorizations.CV;
            if (MessageBox.Show("سوف يتم حدف هده السجل , هل تريد الاستمرار؟", "حدف السجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            Cat.Falds = new string[] {"CategorizationsCode"};

                Cat.param = new SqlParameter[1];
                Cat.param[0] = new SqlParameter("@CategorizationsCode", SqlDbType.NVarChar, 25);
                Cat.param[0].Value = f.CategorizationsCode.Text;

                Cat.where = $"where CategorizationsCode = @CategorizationsCode";
                if (Cat.DeleteWithParameters() == 1)
                {
                    MessageBox.Show("تم عملية الحدف بنجاح");
                    Get_Last_Record();
                }
                else
                {
                    MessageBox.Show("لم تم عملية الحدف");
                }

            }
        }

    }
}
