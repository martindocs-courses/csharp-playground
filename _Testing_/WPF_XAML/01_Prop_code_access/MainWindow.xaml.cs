using System.Windows;

namespace PropCodeAccess
{
    public partial class MainWindow : Window
    {
        bool running = default;

        public MainWindow()
        {
            InitializeComponent();

            // modify UI elements 
            //msg.Text = "Hello";
            //btnRun.Content = "Stop";
        }

        // Fire an event, object sender which is generic object, where the event is coming from         
        private void btnToggleRun_Click(object sender, RoutedEventArgs e)
        {
            if (running)
            {             
                // stop
                tbStatus.Text = "Stopped";
                btnToggleRun.Content = "Run";
            }
            else
            {         
                // run
                tbStatus.Text = "Running";
                btnToggleRun.Content = "Stop";
            }

            running = !running;
        }
    }
}