using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Modle
{
    class API
    {
        DAL db = new DAL();
        public string Table { get; set; } = null;
        public string[] Falds { get; set; } = null;
        public string[] Name { get; set; } = null;
        public string[] value { get; set; } = null;
        public int[] isint { get; set; } = null;
        public string where { get; set; } = null;
        public string[] FaldsCansale { get; set; }
        public SqlParameter[] param { get; set; } = null;
        public SqlParameter[] prm { get; set; } = null;
        public API()
        {
            this.Table =null;
            this.Falds = new string[] { "*" };
            this.Name = null;
            this.value = null;
            this.isint = null;
            this.where = null;
            this.param = null;
            this.prm  = null;
        }
        public DataTable GetData()
        {
            string f = "";
            if (this.Falds[0] == "*")
            {
                f = "*";
            }
            else if (this.Name == null)
            {
                for (int i = 0; i < this.Falds.Length; i++)
                {
                    if (i != this.Falds.Length - 1)
                    {
                        f += $"{this.Falds[i]},";
                    }
                    else
                    {
                        f += $"{this.Falds[i]}";
                    }

                }
            }
            else
            {

                for (int i = 0; i < this.Falds.Length; i++)
                {
                    if (i != this.Falds.Length - 1)
                    {
                        f += $"{this.Falds[i]} as '{this.Name[i]}',";
                    }
                    else
                    {
                        f += $"{this.Falds[i]} as '{this.Name[i]}'";
                    }

                }
            }
            string cmd = $"select {f} from {this.Table} {this.where}";
            return db.SelectData(cmd);
        }
        public int Insert()
        {
            string f = "";
            string v = "";
            bool t = false;

            for (int i = 0; i < this.Falds.Length; i++)
            {
                if (this.value[i] != "")
                {
                    if (i == this.Falds.Length || i == 0)
                    {

                    }
                    else
                    {
                        f += $",";
                        v += $",";
                    }
                    if (this.isint == null)
                    {

                        f += $"{this.Falds[i]}";
                        v += $"N'{this.value[i]}'";

                    }
                    else
                    {
                        foreach (int item in isint)
                        {
                            if (i == item)
                            {
                                t = true;

                            }

                        }
                        if (t == true)
                        {
                            f += $"{this.Falds[i]}";
                            v += $"{this.value[i]}";
                        }
                        else
                        {

                            f += $"{this.Falds[i]}";
                            v += $"N'{this.value[i]}'";

                        }
                        t = false;
                    }

                }
            }
            string query = $"insert into {this.Table} ({f}) values ({v})";
            int x = 10;
            return db.ExecuteCommand(query);

        }
        public int Delete()
        {
            string query = $"delete from {this.Table} {this.where}";
            return db.ExecuteCommand(query);
        }
        public int Update()
        {
            string q = "";

            bool t = false;
            for (int i = 0; i < this.Falds.Length; i++)
            {
                if (this.value[i] != "")
                {
                    if (i == this.Falds.Length || i == 0)
                    {

                    }
                    else
                    {
                        q += $",";
                    }

                    if (this.isint == null)
                    {
                        q += $"{this.Falds[i]} = N'{this.value[i]}'";

                    }
                    else
                    {
                        foreach (int item in isint)
                        {
                            if (i == item)
                            {
                                t = true;
                            }

                        }
                        if (t == true)
                        {
                            q += $"{this.Falds[i]} = {this.value[i]}";

                        }
                        else
                        {

                            q += $"{this.Falds[i]} = N'{this.value[i]}'";
                        }
                        t = false;
                    }
                }
            }
            string query = $"update {this.Table} set {q} {this.where} ";
            int x = 10;
            return db.ExecuteCommand(query);

        }
        public string Get_Last_Record( string OrderByField ,string Code)
        {
            DataTable DT = new DataTable();
            string txt;
            int Max = 0;
            int c;
            this.where = $"Order by {OrderByField}";
            this.Falds = new string[] { "*" };
            DT = this.GetDataWithParameters();
            if (DT.Rows.Count==0)
            {
                return $"{Code}1";
            }
            else
            {
                c = DT.Rows.Count - 1;
                //txt = DT.Rows[c][$"{OrderByField}"].ToString();
                txt = Convert.ToString(DT.Rows[c][OrderByField]);
                Max = Convert.ToInt16(txt) + 1;
            }
            return $"{Code}{Max}";
        }

        public int InsertWithParameters()
        {
            string f = "";
            string p = "";
            int notnull = 0;
            int ch = -1;
            for (int i = 0; i < this.Falds.Length; i++)
            {
                if (this.param[i].Value=="" || this.param[i].Value == null)
                {
                }
                else
                {
                    ch++;
                    if (i == this.Falds.Length || ch == 0)
                    {
                    }
                    else
                    {
                        f += $",";
                        p += $",";
                    }
                    f += $"{this.Falds[i]}";
                    p += $"@{this.Falds[i]}";
                    notnull++;
                }
            }
            this.prm = new SqlParameter[notnull];
            int c = -1;
            foreach (SqlParameter item in this.param)
            {
                if (item.Value != "" && item.Value != null)
                {
                    c++;
                    this.prm[c] = item;
                }
            }
            string query = $"insert into {this.Table} ({f}) values ({p})";
            int x = 10;
            return db.Ex(query, this.prm);
        }
        public int UpdateWithParameters()
        {
            int notnull = 0;
            int ch = -1, m = -1;
            bool t = false;
            string q = "";
            int ln = this.Falds.Length;
            for (int i = 0; i < this.Falds.Length; i++)
            {
                if (this.param[i].Value == "" || this.param[i].Value == null)
                {
                }
                else { 
                    ch++;
                    foreach (var item in this.FaldsCansale)
                    {
                        if (this.Falds[i] == item)
                        {
                            t = true;
                        }

                    }
                    if (t != true)
                    {
                        m++;
                        if (i != ln && m!=0)
                        {
                            q += $",";
                        }
                        q += $"{this.Falds[i]} = @{this.Falds[i]}";


                    }
                    notnull++;
                    t = false;
                }
            }
            this.prm = new SqlParameter[notnull];
            int c = -1;
            foreach (SqlParameter item in this.param)
            {
                if (item.Value!= "" && item.Value != null)
                {
                    c++;
                    this.prm[c] = item;
                }
            }
            string query = $"update {this.Table} set {q} {this.where} ";
            int x = 10;
            return db.Ex(query, this.prm);
        }

        public DataTable GetDataWithParameters()
        {
            string f = "";
            int ch = -1;
            if (this.Falds[0] == "*")
            {
                f = "*";
            }
            else if (this.Name == null)
            {
                for (int i = 0; i < this.Falds.Length; i++)
                {   
                  f += $"{this.Falds[i]}";
                    if (i != this.Falds.Length-1)
                    {
                        f += $",";
                    }
                }
            }
            else
            {

                for (int i = 0; i < this.Falds.Length; i++)
                {

                  f += $"{this.Falds[i]} as '{this.Name[i]}'";
                    if (i != this.Falds.Length - 1)
                    {
                        f += $",";
                    }
                }
            }
            string cmd = $"select {f} from {this.Table} {this.where}";
            int x = 10;
            return db.Read(cmd,this.param);
        }
        public int DeleteWithParameters()
        {
            string query = $"delete from {this.Table} {this.where}";
            int x = 10;
            return db.Ex(query, this.param);
        }
    }
}
