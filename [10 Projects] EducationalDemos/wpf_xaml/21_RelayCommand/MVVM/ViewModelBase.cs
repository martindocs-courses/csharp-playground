﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelsInMVVM.MVVM
{
    internal class ViewModelBase : INotifyPropertyChanged
    {       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
