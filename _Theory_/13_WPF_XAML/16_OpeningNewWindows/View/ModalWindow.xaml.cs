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
using System.Windows.Shapes;

namespace OpeningNewWindows.View
{  
    public partial class ModalWindow : Window
    {
        public bool Success { get; set; }
        public string Input { get; set; }

        public ModalWindow(MainWindow parentWindow)
        {
            Owner = parentWindow; // it will set the modal window to the parent window
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Input = txtInput.Text;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtInput.Text)){
                btnOK.IsEnabled = true;
            }else{
                btnOK.IsEnabled = false;
            }
        }
    }
}
