using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для KPI_PA.xaml
    /// </summary>
    public partial class KPI_PA : Window
    {
        public KPI_PA()
        {
            InitializeComponent();
            boxComboDepart.Items.Add("Департамент прикладной математики");
            boxComboDepart.Items.Add("Департамент электронной инженерии");
            boxComboDepart.Items.Add("Департамент компьютерной инженерии");
            boxComboDepart.Items.Add("МИЭМ");

        }

        private void buttonKPI_Click(object sender, RoutedEventArgs e)
        {
            string res = boxComboDepart.SelectedItem.ToString();
            if (res == "Департамент прикладной математики")
                //result.Text = "1,15";
            {
                string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(ssqlconnectionstring);
                conn.Open();

            }
            if (res == "Департамент электронной инженерии")
                result.Text = "1,74";
            if (res == "Департамент компьютерной инженерии")
                result.Text = "0,95";
            if (res == "МИЭМ")
                result.Text = KPI.Count_KPI("a").ToString();
        }
    }
}
