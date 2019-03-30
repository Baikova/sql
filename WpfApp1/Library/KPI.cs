using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;

namespace WpfApp1
{
    public class KPI
    {
        public int npr;
        //internal static DataTable dtPubl;

        public static double Count_KPI(string department_name)
        {
            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();

            string sql = "select distinct [Название публикации] from dip.dbo.Publ where dip.dbo.Publ.SNIP is not null";
            SqlDataAdapter daPubl = new SqlDataAdapter(sql, conn);
            DataSet dsPubl = new DataSet("publications");
            daPubl.FillSchema(dsPubl, SchemaType.Source,  "[dip].[dbo].[Publ]");
            daPubl.Fill(dsPubl, " [dip].[dbo].[Publ]");
            DataTable dtDistPubl;
            dtDistPubl = dsPubl.Tables[" [dip].[dbo].[Publ]"];
            conn.Close();
            double sum = 0;
            int count = 0;
            
            foreach (DataRow drPubl in dtDistPubl.Rows)
            {
                string str = drPubl["Название публикации"].ToString();
                string publ = "";
                bool flag = false;
                for (int i = 0; i < str.Length; i++)
                {
                   
                    if (str[i].ToString() == "'")
                    {
                        flag = true;
                        break;
                        // publ +="\""+"\"'" + str[i].ToString();
                    }
                    else
                    {
                        //publ+= str[i].ToString();
                    }
                }

                if (!flag)
                {
                    string ssqlconnectionstringSn = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
                    SqlConnection connSn = new SqlConnection(ssqlconnectionstringSn);
                    conn.Open();
                    string sqlSn = "select [Название публикации], [Авторы], [SNIP] from dip.dbo.Publ " +
                                   "where dip.dbo.Publ.[Название публикации]=\'" + str + "\' and dip.dbo.Publ.SNIP is not null";

                    SqlDataAdapter daPublSn = new SqlDataAdapter(sqlSn, connSn);
                    DataSet dsPublSn = new DataSet("publicationsSn");
                    daPublSn.FillSchema(dsPublSn, SchemaType.Source, "[dip].[dbo].[Publ]");
                    daPublSn.Fill(dsPublSn, " [dip].[dbo].[Publ]");
                    DataTable dtDistPublSn;
                    dtDistPublSn = dsPublSn.Tables[" [dip].[dbo].[Publ]"];
                    conn.Close();
                    count = dtDistPublSn.Rows.Count;
                    if (count != 0)
                    {
                        var snip = dtDistPublSn.Rows[0]["SNIP"];
                        var a = (double)snip;

                        sum += a * 1 / count;
                    }
                   

                }
                // название процедуры

                /*string sqlExpression = "kpi_sel_publ_aut";

                SqlConnection connKPI = new SqlConnection(ssqlconnectionstring);
                connKPI.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connKPI);
                    // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                    // параметр 
                SqlParameter name_publParam = new SqlParameter
                {
                    ParameterName = "@publ_name",
                    Value = drPubl["Название публикации"].ToString()
                };
                    // добавляем параметр
                command.Parameters.Add(name_publParam);
                SqlDataReader result = command.ExecuteReader();
                object snip = result.GetValue(1);
                var a = (string)snip;*/
                //MessageBox.Show(a.ToString());
             
            }

            float srspis = 138.25F; // среднесписочная численность МИЭМ


                //if (department_name == "")
                return sum/srspis;
        }
    }

}