using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EmplCard.Model;
using ViewEmpl.Model;

namespace EmplCard.EmplCardViewModel 
{
    class EmplCardViewModel :BaseNotifyClass
    {
        private ModelEmplCard selectedEmpl;
        public ObservableCollection<ModelEmplCard> Employee { get; set; }
        public string EmplId { get; set; }
       /* public ModelEmplCard SelectedEmpl
        {
            get { return selectedEmpl; }
            set
            {
                selectedEmpl = value;
                NotifyPropertyChanged();
            }
        }*/

        public EmplCardViewModel()
        {
            
        }
        
        public ObservableCollection<ModelEmplCard> SelectEmpl()
        {
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
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        Employee.Add(new ModelEmplCard { EmplName = (string)reader.GetValue(1), Department = (string)reader.GetValue(13), ScienceDegree = (string)reader.GetValue(2), Hours = (double)reader.GetValue(11) });

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            return Employee;
        }

       
        
        /*
        public void Print(string id)
        {
            
        }


        /*private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox TextBoxEmplName = (TextBox)sender;
            MessageBox.Show(TextBoxEmplName.Text);
        }*/

    }
}
