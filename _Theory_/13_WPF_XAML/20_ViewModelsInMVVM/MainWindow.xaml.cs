using System.Windows;
using ViewModelsInMVVM.ViewModel;

namespace ViewModelsInMVVM
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Let our view that has different data context. We could do in the XAML or here which is better as we can use parameters
            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;

        }
    }
}