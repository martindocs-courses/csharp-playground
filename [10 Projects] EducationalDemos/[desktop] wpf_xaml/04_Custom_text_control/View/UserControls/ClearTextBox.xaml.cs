using System;
using System.Collections.Generic;
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

namespace CustomTextControl.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClearTextBox.xaml
    /// </summary>
    public partial class ClearTextBox : UserControl
    {
        // custom placeholder: type propfull or prop
        private string _placeholder; // backing field

        public string Placeholder // property accessible for MainWindow
        {
            get { return _placeholder; }
            set { 
                _placeholder = value;

                // do not do that way. Use instead OnPropertyChange() instead
                tbPlaceholder.Text = _placeholder; // update the placeholder to whatever text was set in the MainWindow
            }
        }

        public ClearTextBox()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear(); // clear all of txt from input
            txtInput.Focus(); // put cursor back into box after clicking clear button
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtInput.Text)){ // if no text in the field
                tbPlaceholder.Visibility = Visibility.Visible;            
            }else{
                tbPlaceholder.Visibility = Visibility.Hidden;
            }
        }
    }
}
