using Microsoft.Win32;
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


namespace OpenFileDialogBox
{    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); // is not static so we need create object
            // filter files user can pick from
            fileDialog.Filter = "DXF Source Files (*.dxf) | *.dxf| All Files (*.*) | *.*"; // = "description | fileType"

            // by default the dialog will open folder you last browser to or we could specify initial directory that always will open
            //fileDialog.InitialDirectory = "C:\\temp"// if directory do not exist it will still open last folder was browser to

            // If need give user more guidance
            fileDialog.Title = "Please pick DXF Source files...";

            // multiple files selection
            //fileDialog.Multiselect = true;

            // boll? - is null-able bool => it can be null / true / false
            bool? sucess = fileDialog.ShowDialog(); // fileDialog is modal and we get return a bool val , so true or false if OK button was pressed

            if (sucess == true) { 
                string path = fileDialog.FileName; // full path with file name
                string fileName = fileDialog.SafeFileName; // only file name
                tbInfo.Text = fileName;
            }else{
                // didn't pick anything
            }
        }
    }
}