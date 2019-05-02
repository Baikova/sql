using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewEmpl.Model;
using WpfApp1;
using System.Windows.Input;
using EmplCard.EmplCardViewModel;
using EmplCard.Model;
using NewEmpl.NewEmplViewModel;
using NewEmpl = WpfApp1.NewEmpl;


namespace WpfApp1
{
    
    public class ViewModelEmpl :BaseNotifyClass
    {
        private ModelEmpl selectedEmpl;
        public ObservableCollection<ModelEmpl> Employees { get; set; }

        public ModelEmpl SelectedEmpl
        {
            get { return selectedEmpl; }
            set
            {
                selectedEmpl = value;
                NotifyPropertyChanged("SelectedEmpl");
            }
        }


        public ViewModelEmpl()
        {
            Employees = new ObservableCollection<ModelEmpl>();

            string ssqlconnectionstring = "Data Source=LAPTOP-LCJH6N9V;Initial Catalog=dip;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(ssqlconnectionstring);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "view_empl";
            //DataTable dt = new DataTable();
            //dt.Load(comm.ExecuteReader());

            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        Employees.Add(new ModelEmpl { EmplName = (string)reader.GetValue(0), Department = (string)reader.GetValue(1), ScienceDegree = (string)reader.GetValue(2), Hours = (double)reader.GetValue(3), Id = (int)reader.GetValue(4) });

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public void ShowNewEmplView()
        {
            NewEmplViewModel vm = new NewEmplViewModel() { };
            NewEmpl view = new NewEmpl() { DataContext = vm };
            ViewShower.Show(view, true);
        }
        private RelayCommand viewNewEmplButton;
        public ICommand ViewNewEmplButton
        {
            get
            {
                return viewNewEmplButton ??
                       (viewNewEmplButton = new RelayCommand(obj =>
                       {
                           ShowNewEmplView();
                       }));

            }
        }

        public void ShowEmplCardView(object ob)
        {
           /*
            * ModelEmpl emp = ob as ModelEmpl;
            
            
            EmplCardViewModel vm = new EmplCardViewModel() { EmplId = SelectedEmpl.Id.ToString() };
            EmplCard view = new EmplCard()  { DataContext = vm};
            
            MessageBox.Show(SelectedEmpl.Id.ToString());
            ViewShower.Show(view, true, b => { if (b != null && b.Value) vm.EmplId = SelectedEmpl.Id.ToString(); });
            //view.Show();
            */
            EmplCard emplCardWindow = new EmplCard(SelectedEmpl.Id.ToString());
            emplCardWindow.Show();
        }

        private RelayCommand viewEmplCardButton;
        public ICommand ViewEmplCardButton 
        {
            get
            {
                return viewEmplCardButton ??
                       (viewEmplCardButton = new RelayCommand(obj =>
                       {
                           ShowEmplCardView(obj);
                       }));
            }
        }
        
    }
}