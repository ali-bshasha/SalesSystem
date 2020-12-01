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
using System.Windows.Forms;

namespace SalesSystem.Controle
{  
    class Suppliers
    {
        API Sup = new API();
        DataTable DT;
 /*||============================>|الدوال العامة|<============================||*/
 
 /*||==>دالة فتح النافدة */  
        public void OpenFormSuppliers()
        {
            FrmSuppliers.CV.Show();
            Frm_Mian.CV.Enabled = false;
            Get_Last_Record();
        }

/*||==>دالة إغلاق النافدة */
        public void CloseFormSuppliers()
        {
            Frm_Mian.CV.Enabled = true;
            FrmSuppliers.CV.Close();
        }


/*||=======================>|الدوال المشتركة بين العمليات|<========================||*/

/*||==>دالة تنظيف الكلاس */
        public void CleanOb()
        {
            Sup.Table = "Suppliers";
            Sup.Falds = new string[] { "*" };
            Sup.where = null;
            Sup.param = null;
            Sup.Name = null;
            Sup.prm = null;
            Sup.value = null;
        }

/*||==>دالة تجهيز أزرار التحكم لعمليات  */
        public void statOp(string op)
        {
            var f = FrmSuppliers.CV;
            if (op == "New")
            {
                f.btnNew.Enabled = false;
                f.btnSave.Enabled = true;
                f.btnEdit.Enabled = false;
                f.btnDelete.Enabled = false;
                CleanContrlw();
            }
            else if (op == "ED")
            {
                f.btnNew.Enabled = true;
                f.btnSave.Enabled = false;
                f.btnEdit.Enabled = true;
                f.btnDelete.Enabled = true;
            }
        }

/*||==>تنظيف صناديق البيانات */
        public void CleanContrlw()
        {
            CleanOb();
            var f = FrmSuppliers.CV;
            f.SupplierCode.Text = "";
            f.SupplierName.Text = "";
            f.Address.Text = "";
            f.Country.Text = "";
            f.City.Text = "";
            f.Mobile.Text = "";
            f.Facebook.Text = "";
            f.Fax.Text = "";
            f.Email.Text = "";
            f.Note.Text = "";
            f.Country.DataSource = null;
            for (int i = 0; i < f.Country.Items.Count; i++)
            {
                f.Country.Items.RemoveAt(i);
            }
            f.City.DataSource = null;
            for (int i = 0; i < f.City.Items.Count; i++)
            {
                f.City.Items.RemoveAt(i);
            }
            f.credit.Text = "";
            f.debit.Text = "";
            f.balance.Text = "";
            f.Sup_Image.Image = null;
            f.status.Text = "";
        }

/*||==>التحقق من البيانات المدخلة و تحديد العملية المطلوبة */
        public void CheckValue(string op)
        {
            var f = FrmSuppliers.CV;
            if (op == "add")
            {
                if (f.SupplierName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم المورد", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UserNotFind();
                }
            }
            else if (op == "edit")
            {

                if (f.SupplierName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم المورد", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FindUserForEdit();
                }
            }
            else if (op == "delete")
            {

                FindUserForDelete();

            }
        }

        /*||==>  جلب زمز المورد المطابق لرمز المحدد لتحقق قبل عملية الحدف أو التعديل */
        public DataTable GetSupplierCode()
        {
            var f = FrmSuppliers.CV;
            CleanOb();
            Sup.param = new SqlParameter[1];
            Sup.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
            Sup.param[0].Value = f.SupplierCode.Text;
            Sup.where = $"where SupplierCode = @SupplierCode";
            return Sup.GetDataWithParameters();
        }

        /*||==>جلب اسم المورد المطابق للأسم المدخل لستخدمة في عملية التحقق قبل عملية الحفظ أو التعديل */
        public DataTable GetSupplierName(string ob="Delete")
        {
            var f = FrmSuppliers.CV;
            CleanOb();
            if (ob=="Edit")
            {
                Sup.param = new SqlParameter[2];
                Sup.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
                Sup.param[0].Value = f.SupplierCode.Text;
                Sup.param[1] = new SqlParameter("@SupplierName", SqlDbType.NVarChar, 100);
                Sup.param[1].Value = f.SupplierName.Text;
                Sup.where = $"where Not SupplierCode=@SupplierCode and SupplierName = @SupplierName  ";
                return Sup.GetDataWithParameters();
            }
            else
            {
                Sup.param = new SqlParameter[1];
                
                Sup.param[0] = new SqlParameter("@SupplierName", SqlDbType.NVarChar, 100);
                Sup.param[0].Value = f.SupplierName.Text;
                Sup.where = $"where SupplierName = @SupplierName";
                return Sup.GetDataWithParameters();
            }
            

            
            return Sup.GetDataWithParameters();
        }
        /*||=========================>|الدوال  الخاص بأصورة|<=========================||*/
/*||==>أختيار صورة */
        public void SelectImage()
        {
            var f = FrmSuppliers.CV;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور |*.jpg;*.fig;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                f.Sup_Image.Image = Image.FromFile(ofd.FileName);
            }
        }
/*||==>تحويل الصور إلي مصفوفة ثنائية*/
        public byte[] Convert_Imaget_to_byte()
        {
            var f = FrmSuppliers.CV;
            if (f.Sup_Image.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                f.Sup_Image.Image.Save(ms, f.Sup_Image.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                return byteImage;
            }
            else
            {
                return null;
            }

        }
        /*||=========================>|الدوال  الخاص بعمليةالحفط|<=========================||*/

        /*||==إنشاء كود المورد لستخدامة في عملية الحفظ  */
        public void Get_Last_Record()
        {
            statOp("New");
            FrmSuppliers.CV.SupplierCode.Text = Sup.Get_Last_Record("SupInternal_ID", "SUP00000").ToString();
        }

/*||==>التحقق من اسم المورد غير موجد في قاعدة البيانات قبل عملية الحفظ تفادين للتكرار */
        public void UserNotFind()
        {
            DT = new DataTable();
            DT = GetSupplierName();
            if (DT.Rows.Count > 0)
            {
                MessageBox.Show("اسم المورد موجد مسبقان");
            }
            else
            {
                InsertSupplier();
            }

        }
        /*||==> دالة اضافة مورد جديد*/
                public void InsertSupplier()
                {
                    var f = FrmSuppliers.CV;
                    Sup.Falds = new string[] { "SupplierCode", "SupplierName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status", "Sup_Image" };
                    Sup.param = new SqlParameter[15];

                    Sup.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
                    Sup.param[0].Value = f.SupplierCode.Text;

                    Sup.param[1] = new SqlParameter("@SupplierName", SqlDbType.NVarChar, 100);
                    Sup.param[1].Value = f.SupplierName.Text;

                    Sup.param[2] = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
                    Sup.param[2].Value = f.Address.Text;

                    Sup.param[3] = new SqlParameter("@Country", SqlDbType.NVarChar, 100);
                    Sup.param[3].Value = f.Country.Text;

                    Sup.param[4] = new SqlParameter("@City", SqlDbType.NVarChar, 100);
                    Sup.param[4].Value = f.City.Text;

                    Sup.param[5] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
                    Sup.param[5].Value = f.Mobile.Text;

                    Sup.param[6] = new SqlParameter("@Fax", SqlDbType.NVarChar, 100);
                    Sup.param[6].Value = f.Fax.Text;

                    Sup.param[7] = new SqlParameter("@Facebook", SqlDbType.NVarChar, 100);
                    Sup.param[7].Value = f.Facebook.Text;

                    Sup.param[8] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
                    Sup.param[8].Value = f.Email.Text;

                    Sup.param[9] = new SqlParameter("@Note", SqlDbType.NVarChar, 100);
                    Sup.param[9].Value = f.Note.Text;

                    Sup.param[10] = new SqlParameter("@credit", SqlDbType.Decimal, 3);
                    Sup.param[10].Value = f.credit.Text;

                    Sup.param[11] = new SqlParameter("@debit", SqlDbType.Decimal, 3);
                    Sup.param[11].Value = f.debit.Text;

                    Sup.param[12] = new SqlParameter("@balance", SqlDbType.Decimal, 3);
                    Sup.param[12].Value = f.balance.Text;

                    Sup.param[13] = new SqlParameter("@status", SqlDbType.Bit);
                    Sup.param[13].Value = true;

                    Sup.param[14] = new SqlParameter("@Sup_Image", SqlDbType.Image);
                    Sup.param[14].Value = Convert_Imaget_to_byte();

                    if (Sup.InsertWithParameters() == 1)
                    {
                        MessageBox.Show("تم عملية الإضافة بنجاح");;
                        statOp("ED");
                    }
                    else
                    {
                        MessageBox.Show("لم تم عملية الإضافة"); ;

                    }
                }

        /*||========================>|الدوال  الخاص بعمليةالتعديل|<========================||*/

        /*||==> التحقق من رمز المورد اسم المورد في قاعد البيانات  قبل عملية التعديل   */
        public void FindUserForEdit()
        {
            DT = new DataTable();
            DT = GetSupplierCode();
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("لم يتم العثور علي عميل بهذا الرقم");
                return;
            }
            else if (GetSupplierName("Edit").Rows.Count>0)
            {
                MessageBox.Show("اسم المورد المدخل موجد مسبقان");
                return;

            }
            else
            {
                UpdateSupplier();
            }

        }
        public void UpdateSupplier()
        {
            var f = FrmSuppliers.CV;

            Sup.Falds = new string[] { "SupplierCode", "SupplierName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status", "Sup_Image" };
            Sup.param = new SqlParameter[15];

            Sup.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
            Sup.param[0].Value = f.SupplierCode.Text;

            Sup.param[1] = new SqlParameter("@SupplierName", SqlDbType.NVarChar, 100);
            Sup.param[1].Value = f.SupplierName.Text;

            Sup.param[2] = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
            Sup.param[2].Value = f.Address.Text;

            Sup.param[3] = new SqlParameter("@Country", SqlDbType.NVarChar, 100);
            Sup.param[3].Value = f.Country.Text;

            Sup.param[4] = new SqlParameter("@City", SqlDbType.NVarChar, 100);
            Sup.param[4].Value = f.City.Text;

            Sup.param[5] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
            Sup.param[5].Value = f.Mobile.Text;

            Sup.param[6] = new SqlParameter("@Fax", SqlDbType.NVarChar, 100);
            Sup.param[6].Value = f.Fax.Text;

            Sup.param[7] = new SqlParameter("@Facebook", SqlDbType.NVarChar, 100);
            Sup.param[7].Value = f.Facebook.Text;

            Sup.param[8] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
            Sup.param[8].Value = f.Email.Text;

            Sup.param[9] = new SqlParameter("@Note", SqlDbType.NVarChar, 100);
            Sup.param[9].Value = f.Note.Text;

            Sup.param[10] = new SqlParameter("@credit", SqlDbType.Decimal, 3);
            Sup.param[10].Value = f.credit.Text;

            Sup.param[11] = new SqlParameter("@debit", SqlDbType.Decimal, 3);
            Sup.param[11].Value = f.debit.Text;

            Sup.param[12] = new SqlParameter("@balance", SqlDbType.Decimal, 3);
            Sup.param[12].Value = f.balance.Text;

            Sup.param[13] = new SqlParameter("@status", SqlDbType.Bit);
            Sup.param[13].Value = true;

            Sup.param[14] = new SqlParameter("@Sup_Image", SqlDbType.Image);
            Sup.param[14].Value = Convert_Imaget_to_byte();

            Sup.FaldsCansale = new string[] { "SupplierCode" };
            Sup.where = $"where SupplierCode = @SupplierCode";

            if (Sup.UpdateWithParameters() == 1)
            {
                MessageBox.Show("تم عملية التعديل بنجاح"); 
                
            }
            else
            {
                MessageBox.Show("لم تم عملية التعديل"); ;

            }
        }

        /*||=========================>|الدوال  الخاصة بعمليةالحدف|<=========================||*/

        /*||==> التحقق من وجد رمز العمبل في قاعد البيانات  قبل عملية الحدف  */
        public void FindUserForDelete()
        {
            DT = new DataTable();
            DT = GetSupplierCode();
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("لم يتم العثور علي عميل بهذا الرقم");
            }
            else
            {
                DeleteSupplier();

            }


        }
        public void DeleteSupplier()
        {
            var f = FrmSuppliers.CV;
            if (MessageBox.Show("سوف يتم حدف هده السجل , هل تريد الاستمرار؟", "حدف السجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Sup.Falds = new string[] { "SupplierCode", "status" };

                Sup.param = new SqlParameter[2];
                Sup.param[0] = new SqlParameter("@SupplierCode", SqlDbType.NVarChar, 25);
                Sup.param[0].Value = f.SupplierCode.Text;

                Sup.param[1] = new SqlParameter("@status", SqlDbType.Bit);
                Sup.param[1].Value = false;

                Sup.where = $"where SupplierCode =@SupplierCode";
                Sup.FaldsCansale = new string[] { "SupplierCode" };
                if (Sup.UpdateWithParameters() == 1)
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

        /*||========================>|الدوال  الخاصة بنافدة البحث |<========================||*/
        //فتح فورم البحث
        public void OpenFromShearchSuppliers()
        {
            var f = FrmSuppliers.CV;
            f.Enabled = false;
            FrmSearchSuppliers.CV.Show();
        }

        /*||========================>|الدوال  الخاصة بنافدة الدوال |<========================||*/

        public void GetAllCountries()
        {
            
            var f = FrmSuppliers.CV;
            string txt = f.Country.Text;
            CleanOb();
            DataTable Dt = new DataTable();
            Sup.Table = "Countries";
            Sup.Falds = new string[] { "*" };
            Sup.where = "order by C_NAME";
            f.Country.DataSource = Sup.GetDataWithParameters();
            f.Country.DisplayMember = "C_NAME";
            f.Country.ValueMember = "C_ID";
            f.Country.Text = txt;
            f.City.DataSource = null;
            
        }
        /*||========================>|الدوال  الخاصة بنافدة المدن |<========================||*/
        public void GetCities()
        {
            var f = FrmSuppliers.CV;
            CleanOb();
            if (f.Country.SelectedIndex > -1)
            {
                FrmCities.CV.listCities.DataSource = null;
                Sup.Table = "Cities";
                Sup.Falds = new string[] { "CT_ID", "CT_Name" };
                Sup.param = new SqlParameter[1];
                Sup.param[0] = new SqlParameter("@C_ID", SqlDbType.Int);
                try
                {
                    Sup.param[0].Value = Convert.ToInt32(f.Country.SelectedValue);
                }
                catch (Exception)
                {
                    Sup.param[0].Value = 0;
                }

                Sup.where = "where C_ID = @C_ID order by CT_Name ";
                f.City.DataSource = Sup.GetDataWithParameters();
                f.City.DisplayMember = "CT_Name";
                f.City.ValueMember = "CT_ID";
            }
            else
            {
                f.City.DataSource = null;

            }
        }









    }
}
