using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModelsInMVVM.Model;
using ViewModelsInMVVM.MVVM;

namespace ViewModelsInMVVM.ViewModel
{
 
    internal class MainWindowViewModel : ViewModelBase 
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem(), canExecute => { return true; });
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => canSave());
               

        public MainWindowViewModel()

        {            
            Items = new ObservableCollection<Item>();            
        }
                      
        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set { 
                selectedItem = value;                
                OnPropertyChanged();
            }
        }

        private void AddItem(){
            Items.Add(new Item
            {
                Name = "New Item",
                SerialNumber = "XXXXX",
                Quantity = 0
            });
        }

        private void DeleteItem()
        {
            Items.Remove(selectedItem);
        }

        private void Save()
        {
            // Save to file or DB, not implemented yet
            throw new NotImplementedException();
        }

        private bool canSave()
        {
            return true;
        }

    }
}
