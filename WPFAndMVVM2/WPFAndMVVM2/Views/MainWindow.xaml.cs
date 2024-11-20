using System.Windows;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            mainViewModel.AddDefaultPerson();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
