﻿using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using NewEmpl.NewEmplViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для NewEmpl.xaml
    /// </summary>
    public partial class NewEmpl : Window
    {
        internal static bool flagCancel = false; //флаг для отслеживания кнопки ОТМЕНА
        public NewEmpl()
        {
            InitializeComponent();
            this.DataContext = new NewEmplViewModel();

            textBoxNewName.Text = Dataview.AuthVerifName;
            comboDegree.Items.Add("Профессор");
            comboDegree.Items.Add("Доцент"); 
            comboDegree.Items.Add("Старший преподаватель");
            comboDegree.Items.Add("Ассистент");
            comboDegree.Items.Add("Профессор-исследователь");
            comboPosition.Items.Add("внеш. совмест.");
            comboPosition.Items.Add("основная");
            comboPosition.Items.Add("внутр. совмест.");
            comboPosition.Items.Add("ГПД");
            comboDepart.Items.Add("Прикладная математика");
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            CountAut aut = new CountAut();
            aut.count = 1;
            
            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";


            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();
            //вычисляем ID последней публикации
            SqlCommand countEmplCommand = conn.CreateCommand();
            countEmplCommand.CommandType = CommandType.StoredProcedure;
            countEmplCommand.CommandText = "count_publ";
            
            SqlDataReader reader = countEmplCommand.ExecuteReader();
            int countEmpl = reader.GetInt16(0);
            int emplId = countEmpl + 1;
            aut.idNum.Add(emplId.ToString());
            string sqlInsert = "INSERT INTO [dip].[dbo].[Employees] (employees_id, empl_name, position, department, science_degree, translit_name) VALUES (@empl_id, @empl_name, @pos, @depart, @deg, @translit)";

            string sql = "SELECT * FROM [dip].[dbo].[Employees]";
            SqlDataAdapter daEmpl = new SqlDataAdapter(sql, conn);
            DataSet dsEmpl = new DataSet("dip");
            daEmpl.FillSchema(dsEmpl, SchemaType.Source, "[dbo].[Employees]");
            daEmpl.Fill(dsEmpl, "[dbo].[Employees]");
            DataTable dtEmpl;
            dtEmpl = dsEmpl.Tables["[dbo].[Employees]"];
            int last_id = dtEmpl.Rows.Count;
            int empl_id = last_id + 1;
            string empl_name = textBoxNewName.Text;
            string pos = comboPosition.SelectedItem.ToString();
            string deg = comboDegree.SelectedItem.ToString();
            string translit_name = textBoxNewTranslitName.Text;
            string depart = comboDepart.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlInsert;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@empl_id", SqlDbType.Float).Value = empl_id;
            cmd.Parameters.Add("@empl_name", SqlDbType.NVarChar).Value = empl_name;
            cmd.Parameters.Add("@pos", SqlDbType.NVarChar).Value = pos;
            cmd.Parameters.Add("@deg", SqlDbType.NVarChar).Value = deg;
            cmd.Parameters.Add("@translit", SqlDbType.NVarChar).Value = translit_name;
            cmd.Parameters.Add("@depart", SqlDbType.NVarChar).Value = depart;
            if (empl_name == "")
                MessageBox.Show("Необходимо добавить ФИО сотрудника");
            else
                { int insertRow = cmd.ExecuteNonQuery();}
            Publication_Verif.InsRow(Author_0_matches.drCur, "[dip].[dbo].[Publ]", aut);
            
            this.Close();
            
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            flagCancel = true;
            this.Close();
        }
    }
}
