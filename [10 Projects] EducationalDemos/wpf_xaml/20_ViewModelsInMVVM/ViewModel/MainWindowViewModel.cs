using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModelsInMVVM.Model;
using ViewModelsInMVVM.MVVM;

// When naming the file for stick with convention of the view name , plus the word ViewModel
// We replacing the code behind with the below ViewModel
/*
     * Acts as a bridge between the View and the Model.
     * Contains:
        - Properties that the View binds to.
        - Commands that the View invokes.
        - Notification logic (INotifyPropertyChanged).
    * No UI logic—only application state and logic for presentation.
*/
namespace ViewModelsInMVVM.ViewModel
{
 
    internal class MainWindowViewModel : ViewModelBase // we replace INotifyPropertyChanged with ViewModelBase
    {

        /* 
            ObservableCollection<T> :
            * Is a special type of collection that provides notifications when items get added, removed, or when the whole list is refreshed.
            * It implements INotifyCollectionChanged and INotifyPropertyChanged interfaces.
            * This event enables WPF controls bound to the collection (like ListBox, DataGrid, or ItemsControl) to update their displayed data automatically without you having to refresh the UI manually.
        */
        public ObservableCollection<Item> Items { get; set; } // for inventory list and if anything of them is changing it's automatically notified on the GUI

        // Constructor
        public MainWindowViewModel()

        {
            // Instantiate the collection
            Items = new ObservableCollection<Item>();

            // Add some dummy data to populate DataGrid
            Items.Add(new Item {
                Name="Product1",
                SerialNumber="0001",
                Quantity=5,
            });
            Items.Add(new Item
            {
                Name = "Product2",
                SerialNumber = "0002",
                Quantity = 15,
            });
        }


        // Represent whatever item is selected and changed on the right of the GUI
        // As application grows we would need to crate more methods for each property and view models, so we should create BASE CLASS for ViewModel in MVVM folder
        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set { 
                selectedItem = value;
                // every time the selectedItem prop is called we want use OnPropertyChanged() method
                OnPropertyChanged();
            }
        }

        // MOVED OnPropertyChanged TO MVVM FOLDER in ViewModelBase
        
       
    }
}
