using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewEmpl.NewEmplViewModel;
using ViewEmpl.Model;

namespace ViewEmpl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class EmplView : Window
    {
        public EmplView()
        {
            InitializeComponent();
            DataContext = new NewEmplViewModel();
        }

       /* private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // throw new NotImplementedException();
            IInputElement element = e.MouseDevice.DirectlyOver;
            if (element != null && element is FrameworkElement)
            {
                if (((FrameworkElement)element).Parent is DataGridCell)
                {
                    var grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null
                                     && grid.SelectedItems.Count == 1)
                    {
                        var rowView = grid.SelectedItem as DataRowView;
                        var rowGrid = grid.SelectedItem as ObservableCollection<ModelEmpl>;
                        string name = rowGrid[1].ToString();
                        MessageBox.Show("Done: "+ name);//do something with the underlying data

                        if (rowView != null)
                        {
                            DataRow row = rowView.Row;
                        }
                    }
                }
            }
        }*/
    }
}
