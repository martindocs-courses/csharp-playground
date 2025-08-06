using System.Collections;
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

namespace ListViewControl
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // add new entry to list view
            lvEntries.Items.Add(txtEntry.Text); // Items is item collection that implements Ilist interface and is very similar to a list, we have ADD, REMOVE or CLEAR  
            txtEntry.Clear();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // 1) If we want just remove element from list view we could use just INDEX
            //int index = lvEntries.SelectedIndex;
            //if (index != -1) { 
            //    lvEntries.Items.RemoveAt(index);
            //}

            // 2) if we want to do something with the element/object like remove from DB or internal collection
            //object item = lvEntries.SelectedItem; // selected items are objects as .Items is Generic

            //var result = MessageBox.Show($"Are you sure you want to delete: {(string)item}?", "Sure?", MessageBoxButton.YesNo);
            //if(result == MessageBoxResult.Yes){
            //    lvEntries.Items.Remove(item);
            //}

            // 3) with  multiple selected view items to delete
            var items = lvEntries.SelectedItems; // we getting IList of objects

            var result = MessageBox.Show($"Are you sure you want to delete: {items.Count} items?", "Sure?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // 2) the way we can fix that is to have temp object that we are looping over while other collection is changing
                var itemsList = new ArrayList(items); // we coping the collection we want change 
                foreach (var item in itemsList)
                {
                    // 1) we cannot change the collection, like remove and still iterate over it, so below will break
                    lvEntries.Items.Remove(item);                    
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Clear();          
        }
    }
}