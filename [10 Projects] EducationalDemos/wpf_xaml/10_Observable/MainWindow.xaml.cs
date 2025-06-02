using System.Collections.ObjectModel;
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

namespace ObservableCollectionListView
{    
    public partial class MainWindow : Window
    {
        // we use ObservableCollection as ItemsSource in ListView is collection and we do not need use list , but ObservableCollection so the UI know how to change. Also we don't need implement InotifiedPropertyChanged as ObservableCollection do that for us
        private ObservableCollection<string> _entries = new ObservableCollection<string>();

        public ObservableCollection<string> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Entries.Add(txtEntry.Text);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = (string)lvEntries.SelectedItem; // we call control directly here instead of using a binding 
            Entries.Remove(selectedItem); // will take care to remove from collection and from our GUI
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();
        }
    }
}