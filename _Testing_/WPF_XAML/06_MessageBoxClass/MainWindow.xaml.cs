using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageBoxClass
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox class is static, so we do not need create an object
            // if we do not need result from it
            //MessageBox.Show("Could not open file.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

            // if we need result back from it
            MessageBoxResult result = MessageBox.Show("Do you agree?", "Agreement", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes) {
                tbInfo.Text = "Agreed";
            }else{
                tbInfo.Text = "Not Agreed";            
            }
        }
    }
}