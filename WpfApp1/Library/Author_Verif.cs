using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Annotations;


namespace WpfApp1
{
    public class CountAut
    {
        public ArrayList list = new ArrayList();
        public int count { get; set;} //кол-во найденных авторов

        public ArrayList idNum
        {
            get { return list; }
            set
            {
                list=value;
            }
        } //id найденных авторов

        public CountAut()
        {
            count = 0;
            //idNum.Add(0);
        }
    }


    class Author_Verif
    {
        internal static DataTable dtEmplSearch;
        internal static DataRow AuthorRow;
        
        public static string LastName (string str)
        {
            string lastName = "";
            int i = 0;
            while (str[i] != ',')
            {
                if (str[i]!='\'')
                {
                    lastName = lastName + str[i];
                }
                i++;
            }
            i++; // пропускаем запятую в строке 
            lastName = lastName + str[i] + str[i + 1];
            return lastName;
        }




        public static CountAut CountAuthor (DataRow author)
        {
            CountAut res = new CountAut();
            AuthorRow = author;
            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();
            string author_name = author["Авторы"].ToString();
            /*if (author_name == "Grachev, N.N.")
            {
                int a = 2;
            }*/

            //выделить фамилию
            string last_name = LastName(author_name);

            string author_name_full = author_name.Replace(",", string.Empty);
            author_name_full = author_name_full.Replace(".", string.Empty);
            int i = author_name_full.IndexOf(' ', 0, author_name_full.Length);
            string init = author_name_full.Substring(i + 1);
            string name = "";
            string ot = "";
            string sqlLike = "";
            string sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '" + last_name + "%' OR synonym LIKE '%" + last_name + "%'"; ;
            init = init.Replace(" ", string.Empty);
            if (init.Length > 1)
            {
                if (Char.IsLower(init[1]) == false)
                {
                    name = init[0].ToString();
                     ot = init.Substring(1);
                    last_name = last_name.Substring(0, last_name.Length - 2);
                    sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '" + last_name + " " + name +
                          "%" + ot + "%' OR translit_name LIKE '" + last_name + "  " + name +"%" + ot + "%'";
                    sqlLike = "SELECT * FROM [dip].[dbo].[Employees] WHERE synonym LIKE '%" + last_name + "%'";
                }
                else
                {
                    int j = 0;
                    while ((Char.IsLower(init[j]) == false) && (j < init.Length))
                    {
                        j++;
                        break;
                    }

                    name = init.Substring(0, init.Length - j);
                    ot = init.Substring(j+1);
                    last_name = last_name.Substring(0, last_name.Length - 2);
                    sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '" + last_name + " " + name +
                          "%" + ot + "%' OR translit_name LIKE '" + last_name + "  " + name + "%" + ot + "%'";
                    sqlLike = "SELECT * FROM [dip].[dbo].[Employees] WHERE synonym LIKE '%" + last_name + "%'";
                }
                
            }
            else
            {
                name = init;
                sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '" + last_name + "%'";
                sqlLike = "SELECT * FROM [dip].[dbo].[Employees] WHERE synonym LIKE '%" + last_name + "%'";
            }
            //добавили к строке поиска первую букву имени 
            //string sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '"+ last_name + "%' OR synonym LIKE '%"+ last_name+"%'";

            SqlDataAdapter daEmpl = new SqlDataAdapter(sql, conn);
            DataSet dsEmpl = new DataSet("dip");

            SqlDataAdapter dLike = new SqlDataAdapter(sqlLike, conn);
            DataSet dsLike = new DataSet("like");

            daEmpl.FillSchema(dsEmpl, SchemaType.Source, "[dbo].[Employees]");
            daEmpl.Fill(dsEmpl, "[dbo].[Employees]");
            dtEmplSearch = dsEmpl.Tables["[dbo].[Employees]"];

            DataTable dtEmplLikeSearch = dtEmplSearch;
            dLike.FillSchema(dsLike, SchemaType.Source, "[dbo].[Employees]");
            dLike.Fill(dsLike, "[dbo].[Employees]");
            dtEmplLikeSearch = dsLike.Tables["[dbo].[Employees]"];
            if (dtEmplSearch.Rows.Count > 0)
            {
                foreach (DataRow row in dtEmplSearch.Rows)
                {

                    res.idNum.Add(row["employees_id"].ToString());
                }
                res.count = dtEmplSearch.Rows.Count;
            }
            else
            if (dtEmplLikeSearch.Rows.Count>0)
            {
                foreach (DataRow row in dtEmplLikeSearch.Rows)
                {

                    res.idNum.Add(row["employees_id"].ToString());
                }
                res.count = dtEmplLikeSearch.Rows.Count;
            }



            return res;
        }
    }
}
