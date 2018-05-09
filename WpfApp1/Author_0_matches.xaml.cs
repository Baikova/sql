﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Author_0_matches.xaml
    /// </summary>
    public partial class Author_0_matches : Window
    {
        public Author_0_matches()
        {
            InitializeComponent();
            textBoxAuthName.Text = Dataview.AuthVerifName; //вывести имя автора, которое не найдено в общем списке

            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();
            char first = Dataview.AuthVerifName[0];
            string sql = "SELECT * FROM [dip].[dbo].[Employees] WHERE translit_name LIKE '" + first + "%'";
            SqlDataAdapter daEmpl = new SqlDataAdapter(sql, conn);
            DataSet dsEmpl = new DataSet("dip");
            daEmpl.FillSchema(dsEmpl, SchemaType.Source, "[dbo].[Employees]");
            daEmpl.Fill(dsEmpl, "[dbo].[Employees]");
            DataTable dtSearch;
            dtSearch = dsEmpl.Tables["[dbo].[Employees]"];

            string s = dataGridViewAuth_0.CurrentCell.ToString();
            dataGridViewAuth_0.ItemsSource = dtSearch.DefaultView;           

        }

        private void buttonChoose_Click (object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dataGridViewAuth_0.SelectedItems[0];
            string s = row["empl_name"].ToString();
            MessageBox.Show(s);
            //тут функция проверки по публикации
        }


        private void buttonErrorAuth_Click(object sender, RoutedEventArgs e)
        {
            Dataview.errDt.ImportRow(Author_Verif.AuthorRow); //добавили в файл с ошибками строку, увеличили счетчик строк в этом файле
            Dataview.er++;
        }

        private void buttonAddAuth_Click(object sender, RoutedEventArgs e)
        {
            NewEmpl newEmpl = new NewEmpl();
            newEmpl.ShowDialog();
            
        }
    }
}
