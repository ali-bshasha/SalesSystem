namespace SalesSystem.View
{
    partial class FrmSuppliers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.credit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.debit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCity = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.City = new System.Windows.Forms.ComboBox();
            this.Country = new System.Windows.Forms.ComboBox();
            this.Sup_Image = new System.Windows.Forms.PictureBox();
            this.Note = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Fax = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Mobile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Facebook = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SupplierName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SupplierCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Image)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImage.ForeColor = System.Drawing.Color.White;
            this.btnSelectImage.Location = new System.Drawing.Point(10, 312);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(200, 31);
            this.btnSelectImage.TabIndex = 94;
            this.btnSelectImage.Text = "إختيار صورة";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(875, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 27);
            this.label11.TabIndex = 1;
            this.label11.Text = "بطاقة تعريف مورد ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(163, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 21);
            this.label15.TabIndex = 64;
            this.label15.Text = "الحالة";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // credit
            // 
            this.credit.BackColor = System.Drawing.Color.Gainsboro;
            this.credit.Location = new System.Drawing.Point(691, 27);
            this.credit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.credit.Name = "credit";
            this.credit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.credit.Size = new System.Drawing.Size(134, 28);
            this.credit.TabIndex = 63;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(374, 31);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 21);
            this.label14.TabIndex = 62;
            this.label14.Text = "الرصيد";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // debit
            // 
            this.debit.BackColor = System.Drawing.Color.Gainsboro;
            this.debit.Location = new System.Drawing.Point(446, 27);
            this.debit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.debit.Name = "debit";
            this.debit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.debit.Size = new System.Drawing.Size(134, 28);
            this.debit.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(599, 31);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 21);
            this.label13.TabIndex = 60;
            this.label13.Text = "حركة دائن";
            // 
            // balance
            // 
            this.balance.BackColor = System.Drawing.Color.Gainsboro;
            this.balance.Location = new System.Drawing.Point(223, 27);
            this.balance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.balance.Name = "balance";
            this.balance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.balance.Size = new System.Drawing.Size(134, 28);
            this.balance.TabIndex = 59;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(842, 31);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 21);
            this.label16.TabIndex = 58;
            this.label16.Text = "حركة مدين";
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Gainsboro;
            this.status.Location = new System.Drawing.Point(10, 27);
            this.status.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.status.Name = "status";
            this.status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.status.Size = new System.Drawing.Size(134, 28);
            this.status.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.credit);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.debit);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.balance);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.status);
            this.panel3.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(122, 457);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(930, 84);
            this.panel3.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(881, 440);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 27);
            this.label12.TabIndex = 2;
            this.label12.Text = "حركة رصيد العميل";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCity);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.City);
            this.panel2.Controls.Add(this.Country);
            this.panel2.Controls.Add(this.btnSelectImage);
            this.panel2.Controls.Add(this.Sup_Image);
            this.panel2.Controls.Add(this.Note);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.Fax);
            this.panel2.Controls.Add(this.Email);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Mobile);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.Facebook);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Address);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.SupplierName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SupplierCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(122, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 394);
            this.panel2.TabIndex = 0;
            // 
            // btnCity
            // 
            this.btnCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCity.ForeColor = System.Drawing.Color.White;
            this.btnCity.Location = new System.Drawing.Point(217, 176);
            this.btnCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(34, 32);
            this.btnCity.TabIndex = 98;
            this.btnCity.Text = "+";
            this.toolTip1.SetToolTip(this.btnCity, "اضافة مدينة جديد");
            this.btnCity.UseVisualStyleBackColor = true;
            this.btnCity.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(572, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 97;
            this.button1.Text = "+";
            this.toolTip1.SetToolTip(this.button1, "اضافة دولة جديد");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // City
            // 
            this.City.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.City.FormattingEnabled = true;
            this.City.Location = new System.Drawing.Point(257, 176);
            this.City.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.City.Name = "City";
            this.City.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.City.Size = new System.Drawing.Size(221, 29);
            this.City.TabIndex = 96;
            this.City.DropDown += new System.EventHandler(this.CmbCities_DropDown);
            // 
            // Country
            // 
            this.Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Country.FormattingEnabled = true;
            this.Country.Location = new System.Drawing.Point(613, 176);
            this.Country.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Country.Name = "Country";
            this.Country.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Country.Size = new System.Drawing.Size(210, 29);
            this.Country.TabIndex = 95;
            this.Country.DropDown += new System.EventHandler(this.CmbCoun_DropDown);
            this.Country.SelectedIndexChanged += new System.EventHandler(this.Country_SelectedIndexChanged);
            this.Country.SelectedValueChanged += new System.EventHandler(this.Country_SelectedValueChanged);
            // 
            // Sup_Image
            // 
            this.Sup_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Sup_Image.Image = global::SalesSystem.Properties.Resources.a;
            this.Sup_Image.Location = new System.Drawing.Point(13, 75);
            this.Sup_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sup_Image.Name = "Sup_Image";
            this.Sup_Image.Size = new System.Drawing.Size(198, 231);
            this.Sup_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sup_Image.TabIndex = 93;
            this.Sup_Image.TabStop = false;
            // 
            // Note
            // 
            this.Note.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Note.Location = new System.Drawing.Point(13, 349);
            this.Note.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Note.Name = "Note";
            this.Note.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Note.Size = new System.Drawing.Size(808, 28);
            this.Note.TabIndex = 92;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(838, 355);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 91;
            this.label10.Text = "ملاحظات";
            // 
            // Fax
            // 
            this.Fax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Fax.Location = new System.Drawing.Point(574, 227);
            this.Fax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Fax.Name = "Fax";
            this.Fax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Fax.Size = new System.Drawing.Size(246, 28);
            this.Fax.TabIndex = 89;
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Email.Location = new System.Drawing.Point(572, 275);
            this.Email.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Email.Name = "Email";
            this.Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Email.Size = new System.Drawing.Size(248, 28);
            this.Email.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 230);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 88;
            this.label9.Text = "الهاتف";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 87;
            this.label6.Text = "الفيس بوك";
            // 
            // Mobile
            // 
            this.Mobile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Mobile.Location = new System.Drawing.Point(217, 226);
            this.Mobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Mobile.Name = "Mobile";
            this.Mobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Mobile.Size = new System.Drawing.Size(261, 28);
            this.Mobile.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(847, 230);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 21);
            this.label8.TabIndex = 84;
            this.label8.Text = "الفاكس";
            // 
            // Facebook
            // 
            this.Facebook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Facebook.Location = new System.Drawing.Point(217, 274);
            this.Facebook.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Facebook.Name = "Facebook";
            this.Facebook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Facebook.Size = new System.Drawing.Size(261, 28);
            this.Facebook.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(824, 279);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 21);
            this.label7.TabIndex = 83;
            this.label7.Text = "بريد الكتروني";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 81;
            this.label5.Text = "المدينة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(850, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 79;
            this.label4.Text = "الدولة";
            // 
            // Address
            // 
            this.Address.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Address.Location = new System.Drawing.Point(217, 131);
            this.Address.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Address.Name = "Address";
            this.Address.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Address.Size = new System.Drawing.Size(604, 28);
            this.Address.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(845, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 77;
            this.label3.Text = "العنوان";
            // 
            // SupplierName
            // 
            this.SupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SupplierName.Location = new System.Drawing.Point(217, 83);
            this.SupplierName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SupplierName.Size = new System.Drawing.Size(604, 28);
            this.SupplierName.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(835, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 75;
            this.label2.Text = "اسم المورد";
            // 
            // SupplierCode
            // 
            this.SupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SupplierCode.Location = new System.Drawing.Point(629, 35);
            this.SupplierCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            this.SupplierCode.Size = new System.Drawing.Size(192, 28);
            this.SupplierCode.TabIndex = 74;
            this.SupplierCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(833, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "رمز المورد";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 568);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(12, 31);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(105, 511);
            this.panel4.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(8, 449);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 55);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(8, 375);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 55);
            this.button6.TabIndex = 77;
            this.button6.Text = "تعليمات";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(8, 297);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 55);
            this.btnSearch.TabIndex = 76;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(8, 227);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 55);
            this.btnDelete.TabIndex = 75;
            this.btnDelete.Text = "حدف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(8, 153);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 55);
            this.btnEdit.TabIndex = 74;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(8, 79);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 55);
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(8, 5);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 55);
            this.btnNew.TabIndex = 72;
            this.btnNew.Text = "جديد";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "مساعدة";
            // 
            // FrmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1064, 568);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FrmSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Image)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox credit;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox debit;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.PictureBox Sup_Image;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox Fax;
        public System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Mobile;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox Facebook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox SupplierName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox SupplierCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox Country;
        public System.Windows.Forms.ComboBox City;
    }
}