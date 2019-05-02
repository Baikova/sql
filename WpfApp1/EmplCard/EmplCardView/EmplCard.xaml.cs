using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using EmplCard.EmplCardViewModel;
using EmplCard.Model;
using System.Data;
using System.Security.Permissions;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ShowEmpl.xaml
    /// </summary>
    ///


    public partial class EmplCard : Window
    {

        public ObservableCollection<ModelEmplCard> Employee { get; set; }

        public EmplCard(string EmplId)
        {
            InitializeComponent();
            EmplCardViewModel vm = new EmplCardViewModel();
            //vm.SelectEmpl();
            this.DataContext = vm;


            string id = EmplId;
            Employee = new ObservableCollection<ModelEmplCard>();

            string sqlExpression = "sel_empl";
            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
            SqlConnection connEmpl = new SqlConnection(ssqlconnectionstring);
            connEmpl.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connEmpl);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = System.Data.CommandType.StoredProcedure;
            // параметр 
            SqlParameter name_publParam = new SqlParameter
            {
                ParameterName = "@empl_id",
                Value = int.Parse(id)
            };
            // добавляем параметр
            command.Parameters.Add(name_publParam);
            SqlDataReader reader = command.ExecuteReader();
            string empName, megaDep, dep, subdiv, scienDeg, position, snNagr;
            double hour, normativ, stavSn, prStav, stavka, sop;
            //string megaDep;
            //string dep;
            //string subdiv;
            //string scienDeg;
            //double hour;
            //string position;
            //double normativ;
            //double stavSn;
            //string snNagr;
            //double prStav;
            //double stavka;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try { megaDep = (string)reader.GetValue(13);}
                    catch (InvalidCastException e) { megaDep = "-";}

                    try { dep = (string) reader.GetValue(14);}
                    catch (InvalidCastException e) { dep = "-"; }

                    try{ subdiv = (string) reader.GetValue(12);}
                    catch (InvalidCastException e) { subdiv = "-";}

                    try { scienDeg = (string) reader.GetValue(2); }
                    catch (InvalidCastException e) { scienDeg = "-"; }

                    try { hour = (double) reader.GetValue(11);}
                    catch (InvalidCastException e) { hour = -1; }

                    try { position = (string) reader.GetValue(3);}
                    catch (InvalidCastException e) { position = "-";}

                    try { normativ = (double) reader.GetValue(8);}
                    catch (InvalidCastException e) { normativ = -1;}

                    try { stavSn = (double) reader.GetValue(7);}
                    catch (InvalidCastException e) { stavSn = -1;}

                    try { snNagr = (string) reader.GetValue(6);}
                    catch (InvalidCastException e) { snNagr = "-";}

                    try { prStav = (double) reader.GetValue(5);}
                    catch (InvalidCastException e){ prStav = -1;}

                    try{ stavka = (double) reader.GetValue(4);}
                    catch (InvalidCastException e){stavka = -1;}

                    Employee.Add(new ModelEmplCard
                    {
                        EmplName = (string)reader.GetValue(1), MegaDep = megaDep, Department = dep, Subdivision = subdiv, 
                        ScienceDegree = scienDeg, Hours = hour, Position = position, Normativ = normativ, Stavka = stavka,
                        PrivStavka =prStav , SnizhNagr = snNagr, StavkaSnizh = stavSn

                    });
                   // try
                    {
                       /* Employee.Add(new ModelEmplCard { EmplName = (string)reader.GetValue(1), MegaDep = (string)reader.GetValue(13),
                            Department = (string)reader.GetValue(14), Subdivision = (string)reader.GetValue(12),
                            ScienceDegree = (string)reader.GetValue(2), Hours = (double)reader.GetValue(11),
                            Position = (string)reader.GetValue(3), Normativ = (double)reader.GetValue(8), StavkaSnizh = (double)reader.GetValue(7),
                            SnizhNagr = (string)reader.GetValue(6), PrivStavka = (double) reader.GetValue(5), Stavka = (double)reader.GetValue(4)
                        });
                        */

                    }

                }
            }
            connEmpl.Close();
            TextBoxEmplName.Text = Employee[0].EmplName;
            TextBoxMegaDep.Text = Employee[0].MegaDep;
            TextBoxDepartment.Text = Employee[0].Department;
            TextBoxSubdiv.Text = Employee[0].Subdivision;
            TextBoxScienceDeg.Text = Employee[0].ScienceDegree;
            TextBoxPosition.Text = Employee[0].Position;

            if (Employee[0].Hours == -1) TextBoxHour.Text = "-";
            else TextBoxHour.Text = Employee[0].Hours.ToString();

            if (Employee[0].Normativ == -1) TextBoxNorm.Text = "-";
            else TextBoxNorm.Text = Employee[0].Normativ.ToString();

            if (Employee[0].PrivStavka == -1) TextBoxPrivStavka.Text = "-";
            else TextBoxPrivStavka.Text = Employee[0].PrivStavka.ToString();

            if (Employee[0].Stavka == -1) TextBoxStavka.Text = "-";
            else TextBoxStavka.Text = Employee[0].Stavka.ToString();

            TextBoxSnNagr.Text = Employee[0].SnizhNagr;

            if (Employee[0].StavkaSnizh == -1) TextBoxStavkaSn.Text = "-";
            else TextBoxStavkaSn.Text = Employee[0].StavkaSnizh.ToString();

            

            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sel_empl_publ";
            SqlParameter emplIdParameter = new SqlParameter
            {
                ParameterName = "@emplId",
                Value = int.Parse(id)
            };
            // добавляем параметр
            comm.Parameters.Add(emplIdParameter);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            //conn.Close();
            float kpi = 0;
            foreach (DataRow row in dt.Rows)
            {
                int publId = (int) row["publ_id"];
                SqlConnection connPub = new SqlConnection(ssqlconnectionstring);
                connPub.Open();
                SqlCommand commPub = connPub.CreateCommand();
                commPub.CommandType = CommandType.StoredProcedure;
                commPub.CommandText = "sel_kpi_empl";
                SqlParameter pubIdParameter = new SqlParameter
                {
                    ParameterName = "@publId",
                    Value = publId
                };
                // добавляем параметр
                commPub.Parameters.Add(pubIdParameter);
                SqlDataReader readerPub = commPub.ExecuteReader(); 

                int countAut = 0;
                if (readerPub.HasRows)
                {
                    while (readerPub.Read())
                    {
                        countAut = (int)readerPub.GetValue(0);
                    }
                }

                float snip;
                if (float.TryParse(row["SNIP"].ToString(), out snip))
                {
                    kpi = kpi + snip / countAut;
                }
                //float snip = float.Parse(row["SNIP"].ToString());
                
                connPub.Close();
            }
            TextBoxKPI.Text = kpi.ToString();
            dataGridEmpPub.ItemsSource = dt.DefaultView;

            SqlCommand commSop = conn.CreateCommand();
            commSop.CommandType = CommandType.StoredProcedure;
            commSop.CommandText = "sel_empl_sop";

            // добавляем параметр
            SqlParameter emplIdParam = new SqlParameter
            {
                ParameterName = "@emplId",
                Value = int.Parse(id)
            };
            commSop.Parameters.Add(emplIdParam);
            reader = commSop.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    try { sop = (double)reader.GetValue(0); }
                    catch (InvalidCastException e) { sop = -1; }
                    if (sop == -1) TextBoxSOP.Text = "-";
                    else TextBoxSOP.Text = sop.ToString();
                }

        }


    }
}
