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
using OpeningNewWindows.View;
namespace OpeningNewWindows
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
           NormalWindow normalWindow = new NormalWindow();
           normalWindow.Show(); // use case for additional info, like app settings
        }

        private void btnModal_Click(object sender, RoutedEventArgs e)
        {
            ModalWindow modalWindow = new ModalWindow(this); // we pass this which is MainWindow
            Opacity = 0.4; // reduce opacity of owning window aka. in our case MainWindow
            modalWindow.ShowDialog();
            Opacity = 1.0;
            if(modalWindow.Success == true){
                txtInput.Text = modalWindow.Input;
            }
        }
    }
}