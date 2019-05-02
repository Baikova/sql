using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp1.SOP
{
    /// <summary>
    /// Логика взаимодействия для SOP.xaml
    /// </summary>
    public partial class SOP : System.Windows.Window
    {
        public SOP()
        {
            InitializeComponent();
        }

        //выбор файла
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.Filter = "Exel Files|*.xls;*.xlsx;*.xlsm";
            if (ope.ShowDialog() == true)
            {
                textBox1.Text = ope.FileName;
            }
        }

        private void button1_ClickInsert(object sender, RoutedEventArgs e)
        {
           /* string res;
            /*UploadWindow upWnd = new UploadWindow();
            res = boxDataSource.SelectedItem.ToString();
            upWnd.dataSource = res;

            OpenFileDialog ope = new OpenFileDialog();
            ope.FileName = textBox1.Text;

            string excelFilePath = textBox1.Text;
            Excel.Workbook xlWB;
            Excel.Application xlApp = new Excel.Application();
            xlWB = xlApp.Workbooks.Open(textBox1.Text);
            //добавить название листов из книги
            string sheetName = xlWB.Worksheets[1].Name;
            //string ssqltable = boxDataTable.SelectedItem.ToString();
            //string sheet1 = boxListExcel.SelectedItem.ToString();
            string myexceldataquery = "select * from [" + sheetName + "$]"; // select * into dbo.tablename - создаст новую таблицу при запросе

            try
            {
                // Командная строка "подключения к Excel"
                string sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 12.0 xml; HDR=YES;'";
                // Строка подключения к SQL
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("Tables");
                // Открываем соединение с Excel
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                oledbconn.Open();
                // Получаем список листов в файле
                DataTable schemaTable = oledbconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable); // Заполняем таблицу
                dataTable.TableName = sheetName.Substring(0, sheetName.Length - 1); // В конце от Экселя стоит символ '$'
                dataSet.Tables.Add(dataTable);
               
                //MessageBox.Show(UploadWindow.dataTable.Rows[2]["Авторы с аффилиациями"].ToString());

                oledbconn.Close();
                //MessageBox.Show("File imported into sql server.");

                string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(ssqlconnectionstring);
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр 
                SqlParameter emplIdParameter = new SqlParameter
                {
                    ParameterName = "@emplId",
                    Value = int.Parse(aut.idNum[0].ToString())
                };
                SqlParameter publIdParameter = new SqlParameter
                {
                    ParameterName = "@publId",
                    Value = int.Parse(publId.ToString())
                };
                // добавляем параметр
                command.Parameters.Add(emplIdParameter);
                command.Parameters.Add(publIdParameter);

                int insEmplPubl = command.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            */
        }
    }
}
