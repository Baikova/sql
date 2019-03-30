using System.Windows;
using EmplCard.EmplCardViewModel;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ShowEmpl.xaml
    /// </summary>
    public partial class EmplCard : Window
    {
        public EmplCard()
        {
            InitializeComponent();
            EmplCardViewModel vm = new EmplCardViewModel();

            this.DataContext = vm;
        }

        private void TextBoxEmplName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }
    }
}
