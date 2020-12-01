using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using SalesSystem.Modle;
using SalesSystem.View;
using System.Data.SqlClient;
using System.Drawing;

namespace SalesSystem.Controle
{
    class Cust
    {
        API cust = new API();
        //Controle.Search_Customers CustSer = new Search_Customers();
        DataTable DT;
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string credit { get; set; }
        public string debit { get; set; }
        public string balance { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
        public byte[] Cust_Image { get; set; }
        public Cust()
        {
            cust.Table = "Customers";
            cust.Falds = new string[] { "*" };
            cust.Name = null;
            cust.value = null;
            cust.isint = null;
            cust.where = null;
        }
        //تنظيف الكائن
        public void CleanOb()
        {
            cust.Table = "Customers";
            cust.Falds = new string[] { "*" };
            cust.Name = null;
            cust.value = null;
            cust.isint = null;
            cust.where = null;
            cust.param = null;
            cust.prm=null;
        }
       //فتح فورم البحث
        public void open_frm_search()
        {
            var f = Frm_Customers.CV;
            f.Enabled = false;
            Frm_Search_Customers.CV.Show();
        }
        
        public void Get_Last_Record()
        {
            CleanContrlw();
            statOp("New");
            Frm_Customers.CV.CustomerCode.Text= cust.Get_Last_Record("CusInternal_ID", "CUS00000").ToString(); 
        }
        public void statOp(string op)
        {
            var f = Frm_Customers.CV;
            if (op=="New")
            {
                f.btnNew.Enabled = false;
                f.btnSave.Enabled = true;
                f.btnEdit.Enabled = false;
                CleanContrlw();
                f.btnDelete.Enabled = false;
                
            }
            else if (op == "ED")
            {
                f.btnNew.Enabled = true;
                f.btnSave.Enabled = false;
                f.btnEdit.Enabled = true;
                f.btnDelete.Enabled = true;
            }
        }
        public void CheckValue(string op)
        {
            if (op == "add")
            {
                if (Frm_Customers.CV.CustomerName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم العميل", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    userLoop();
                }
            } else if (op == "edit")
            {

                if (Frm_Customers.CV.CustomerName.Text == "")
                {
                    MessageBox.Show("يجب إدخال اسم العميل", "خطاء في إدخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    userfond(op);
                }
            }
            else if (op == "delete")
            {

                userfond(op);

            }



        }
        public DataTable GetCustomersCode()
        {
            var f = Frm_Customers.CV;
            CleanOb();
            cust.param = new SqlParameter[1];
            cust.param[0] = new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 25);
            cust.param[0].Value = f.CustomerCode.Text;
            cust.where = $"where CustomerCode = @CustomerCode";
            return cust.GetDataWithParameters();
        }

        public DataTable GetCustomersName()
        {
            var f = Frm_Customers.CV;
            CleanOb();
            cust.param = new SqlParameter[1];
            cust.param[0] = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 100);
            cust.param[0].Value = f.CustomerName.Text;
            cust.where = $"where CustomerName = @CustomerName";
            return cust.GetDataWithParameters();
        }
      
        public void userLoop()
        {
            DT = new DataTable();
            DT = GetCustomersName();
            if (DT.Rows.Count > 0)
            {
                MessageBox.Show("اسم العميل موجد مسبقان");
            }
            else
            {
                InsertCust();
            }
        }

        public void userfond(string op)
        {
            DT = new DataTable();
            DT = GetCustomersCode();
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("لم يتم العثور علي عميل بهذا الرقم");
                return;
            }
            else
            {
                if (op == "delete")
                {
                    DeleteCust();
                }
                else
                {

                        EditCust();
                    
                    
                }

            }

        }
        public void setData()
        {
            CleanOb();
            var f = Frm_Customers.CV;
            this.CustomerCode = f.CustomerCode.Text;
            this.CustomerName = f.CustomerName.Text;
            this.Address = f.Address.Text;
            this.Country = f.Country.Text;
            this.City = f.City.Text;
            this.Mobile = f.Mobile.Text;
            this.Facebook = f.Facebook.Text;
            this.Fax = f.Fax.Text;
            this.Email = f.Email.Text;
            this.Note = f.Note.Text;
            this.credit = f.credit.Text;
            this.debit = f.debit.Text;
            this.balance = f.balance.Text;
            this.status = "true";
            this.Cust_Image = Convert_Imaget_to_byte();
        }
        public byte[] Convert_Imaget_to_byte()
        {
            var f = Frm_Customers.CV;
            if (f.Cust_Image.Image!=null)
            {
                MemoryStream ms = new MemoryStream();
                f.Cust_Image.Image.Save(ms, f.Cust_Image.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                return byteImage;
            }
            else
            {
                return null;
            }
          
        }
        public void SelectImage()
        {
            var f = Frm_Customers.CV;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور |*.jpg;*.fig;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                f.Cust_Image.Image = Image.FromFile(ofd.FileName);
            }
        }
        public void InsertCust()
        {
            setData();
            cust.Falds = new string[] { "CustomerCode", "CustomerName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status","Cust_Image" };
            cust.param = new SqlParameter[15];

            cust.param[0] = new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 25);
            cust.param[0].Value = this.CustomerCode;

            cust.param[1] = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 100);
            cust.param[1].Value = this.CustomerName;

            cust.param[2] = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
            cust.param[2].Value = this.Address;

            cust.param[3] = new SqlParameter("@Country", SqlDbType.NVarChar, 100);
            cust.param[3].Value = this.Country;

            cust.param[4] = new SqlParameter("@City", SqlDbType.NVarChar, 100);
            cust.param[4].Value = this.City;   

            cust.param[5] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
            cust.param[5].Value = this.Mobile;

            cust.param[6] = new SqlParameter("@Fax", SqlDbType.NVarChar, 100);
            cust.param[6].Value = this.Fax;

            cust.param[7] = new SqlParameter("@Facebook", SqlDbType.NVarChar, 100);
            cust.param[7].Value = this.Facebook;

            cust.param[8] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
            cust.param[8].Value = this.Email;
             
            cust.param[9] = new SqlParameter("@Note", SqlDbType.NVarChar, 100);
            cust.param[9].Value = this.Note;

            cust.param[10] = new SqlParameter("@credit", SqlDbType.Decimal, 3);
            cust.param[10].Value = this.credit;

            cust.param[11] = new SqlParameter("@debit", SqlDbType.Decimal,3);
            cust.param[11].Value = this.debit;

            cust.param[12] = new SqlParameter("@balance", SqlDbType.Decimal,3);
            cust.param[12].Value = this.balance;

            cust.param[13] = new SqlParameter("@status", SqlDbType.Bit);
            cust.param[13].Value = this.status;

            cust.param[14] = new SqlParameter("@Cust_Image", SqlDbType.Image);
            cust.param[14].Value = this.Cust_Image;

            

            //cust.value = new string[] { this.CustomerCode, this.CustomerName, this.Address, this.Country, this.City, this.Mobile, this.Fax, this.Facebook, this.Email, this.Note, this.credit, this.debit, this.balance, "1" };
            //cust.isint = new int[] { 10, 11, 12, 13 };
            if (cust.InsertWithParameters() == 1)
            {
                this.msg = "تم عملية الإضافة بنجاح";
                statOp("ED");
            }
            else
            {
                this.msg = "لم تم عملية الإضافة";
            }
            MessageBox.Show(this.msg);
        }
        public void EditCust()
        {
            if (MessageBox.Show("سوف يتم حفط هده التعديلات , هل تريد الاستمرار؟", "تعديل البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                setData();

                cust.Falds = new string[] { "CustomerCode", "CustomerName", "Address", "Country", "City", "Mobile", "Fax", "Facebook", "Email", "Note", "credit", "debit", "balance", "status", "Cust_Image" };
                cust.param = new SqlParameter[15];

                cust.param[0] = new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 25);
                cust.param[0].Value = this.CustomerCode;

                cust.param[1] = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 100);
                cust.param[1].Value = this.CustomerName;

                cust.param[2] = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
                cust.param[2].Value = this.Address;

                cust.param[3] = new SqlParameter("@Country", SqlDbType.NVarChar, 100);
                cust.param[3].Value = this.Country;

                cust.param[4] = new SqlParameter("@City", SqlDbType.NVarChar, 100);
                cust.param[4].Value = this.City;

                cust.param[5] = new SqlParameter("@Mobile", SqlDbType.NVarChar, 100);
                cust.param[5].Value = this.Mobile;

                cust.param[6] = new SqlParameter("@Fax", SqlDbType.NVarChar, 100);
                cust.param[6].Value = this.Fax;

                cust.param[7] = new SqlParameter("@Facebook", SqlDbType.NVarChar, 100);
                cust.param[7].Value = this.Facebook;

                cust.param[8] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
                cust.param[8].Value = this.Email;

                cust.param[9] = new SqlParameter("@Note", SqlDbType.NVarChar, 100);
                cust.param[9].Value = this.Note;

                cust.param[10] = new SqlParameter("@credit", SqlDbType.Decimal, 3);
                cust.param[10].Value = this.credit;

                cust.param[11] = new SqlParameter("@debit", SqlDbType.Decimal, 3);
                cust.param[11].Value = this.debit;

                cust.param[12] = new SqlParameter("@balance", SqlDbType.Decimal, 3);
                cust.param[12].Value = this.balance;

                cust.param[13] = new SqlParameter("@status", SqlDbType.Bit);
                cust.param[13].Value = this.status;

                cust.param[14] = new SqlParameter("@Cust_Image", SqlDbType.Image);
                cust.param[14].Value = this.Cust_Image;

                cust.FaldsCansale = new string[] { "CustomerCode" };


                //cust.value = new string[] { this.CustomerName, this.Address, this.Country, this.City, this.Mobile, this.Fax, this.Facebook, this.Email, this.Note, this.credit, this.debit, this.balance, "true" };
                //cust.isint = new int[] { 9, 10, 11, 12 };
                cust.where = $"where CustomerCode = @CustomerCode";
                if (cust.UpdateWithParameters() == 1)
                {
                    this.msg = "تم عملية التعديل بنجاح";
                }
                else
                {
                    this.msg = "لم تم عملية التعديل";
                }
                MessageBox.Show(this.msg);
            }
        }
        public void DeleteCust()
        {
            if (MessageBox.Show("سوف يتم حدف هده السجل , هل تريد الاستمرار؟", "حدف السجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                setData();
                cust.Falds = new string[] { "status" };
                cust.value = new string[] { "0" };
                cust.isint = new int[] { 0 };
                cust.where = $"where CustomerCode =N'{Frm_Customers.CV.CustomerCode.Text}'";
                if (cust.Update() == 1)
                {
                    this.msg = "تم عملية الحدف بنجاح";
                    Get_Last_Record();
                }
                else
                {
                    this.msg = "لم تم عملية الحدف";
                }
                MessageBox.Show(this.msg);
            }
        }
        public void CleanContrlw ()
        {
            CleanOb();
            var f = Frm_Customers.CV;
             f.CustomerCode.Text = "";
            f.CustomerName.Text = "";
            f.Address.Text = "";
            f.Country.Text = "";
            f.City.Text = "";
            f.Mobile.Text = "";
            f.Facebook.Text = "";
            f.Fax.Text = "";
            f.Email.Text = "";
            f.Note.Text = "";
            f.credit.Text = "";
            f.debit.Text = "";
            f.balance.Text = "";
            f.Cust_Image.Image = null;
            f.status.Text = "";
        }
        public void CloseFormCustomers()
        {
            var f = Frm_Customers.CV;
            Frm_Mian.CV.Enabled = true;
            CleanContrlw();
            f.Close();

        }
        public void OpenFormCustomers()
        {
            var f = Frm_Customers.CV;
            f.Show();
            Frm_Mian.CV.Enabled = false;
            CleanContrlw();
            Get_Last_Record();
        }
    }
}
