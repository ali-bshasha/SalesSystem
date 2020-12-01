﻿using SalesSystem.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.View
{
    public partial class FrmSearchSuppliers : Form
    {
        SearchSuppliers SupSer = new SearchSuppliers();
        private static FrmSearchSuppliers frm;
        
        static void frm_Fromclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FrmSearchSuppliers CV
        {
            get
            {
                if (frm == null)
                {

                    frm = new FrmSearchSuppliers();
                    frm.FormClosed += new FormClosedEventHandler(frm_Fromclosed);

                }
                return frm;
            }
        }
        public FrmSearchSuppliers()
        {
            if (frm == null)
            {
                frm = this;
            }
            InitializeComponent();
        }

        private void FrmSearchSuppliers_Load(object sender, EventArgs e)
        {
            SupSer.search_Suppliers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            SupSer.search_Suppliers();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SupSer.selectSuppliers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupSer.CloseFrom();
        }
        int p, x, y;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p = 1;
            x = e.X;
            y = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            p = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (p==1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }
    }
}
