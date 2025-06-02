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
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderBrowserDialog
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            /*
                To be able use this FolderBrowserDialog feature we need install through NuGet Package Manager:                
                * Right-click on your project in Solution Explorer (Not the solution, but the actual project)
                * Choose: Manage NuGet Packages...
                * In the NuGet Manager
                - Search for: Microsoft.WindowsAPICodePack-Shell
                - Download count: 100K+ is a good sign
                - Click Install

                * Confirm it's working, by adding to the top of your C# file: 
                - using Microsoft.WindowsAPICodePack.Dialogs;
             
             */
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = @"C:\temp",
                EnsurePathExists = true
            };

            //dialog.InitialDirectory = "C:\\temp";

            CommonFileDialogResult result = dialog.ShowDialog();

            if(result == CommonFileDialogResult.Ok){

                string folder = dialog.FileName; // folder file path                      
            
            }
            
        }
    }
}