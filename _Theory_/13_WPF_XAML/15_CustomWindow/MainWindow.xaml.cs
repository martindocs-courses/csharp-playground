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

namespace CustomWindow
{    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); // the MainWindow has method to drag and move 
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            // as maximize also works as restore, we need check if window is already maximized
            if(WindowState != WindowState.Maximized){
                WindowState = WindowState.Maximized;
            }else{
                WindowState = WindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // 1. in-build method in MainWindow, but it closing only current open window. If we have opened more windows in application it will close only the we pushing the 'X' on, and not the whole application
            Close(); // generally that is sufficient to close the window application

            // 2. Close current application
            //Application.Current.Shutdown();
        }
    }
}