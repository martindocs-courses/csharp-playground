using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModelsInMVVM.Model;

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
namespace ViewModelsInMVVM.ViewModel_OLD
{
 
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        /* 
            ObservableCollection<T> :
            * Is a special type of collection that provides notifications when items get added, removed, or when the whole list is refreshed.
            * It implements INotifyCollectionChanged and INotifyPropertyChanged interfaces.
            * This event enables WPF controls bound to the collection (like ListBox, DataGrid, or ItemsControl) to update their displayed data automatically without you having to refresh the UI manually.
        */
        public ObservableCollection<Item> Items { get; set; } // for inventory list and if anything of them is changing it's automatically notified on the GUI

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

        // Implement INotifyPropertyChanged to be able to use selectedItem prop
        public event PropertyChangedEventHandler? PropertyChanged;

        // Implement method to fire the PropertyChanged event. Also because we use [CallerMemberName] we do not need pass SelectedItem method as [CallerMemberName] do that automatically for us
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null){ // when using [CallerMemberName] compiler service attribute called member name allow us to make this an optional parameter that will be automatically populated with the method name that is calling it
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // PropertyChanged? - means if ProppertyChanged is not null we want invoked this object and property changed event argument, given our property name
        }

        public MainWindowViewModel()

        {
            
        }
    }
}
