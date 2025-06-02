using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelsInMVVM.MVVM
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        // Implement INotifyPropertyChanged to be able to use selectedItem prop
        public event PropertyChangedEventHandler? PropertyChanged;

        // Implement method to fire the PropertyChanged event. Also because we use [CallerMemberName] we do not need pass SelectedItem method as [CallerMemberName] do that automatically for us
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { // when using [CallerMemberName] compiler service attribute called member name allow us to make this an optional parameter that will be automatically populated with the method name that is calling it
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // PropertyChanged? - means if ProppertyChanged is not null we want invoked this object and property changed event argument, given our property name
        }
    }
}
