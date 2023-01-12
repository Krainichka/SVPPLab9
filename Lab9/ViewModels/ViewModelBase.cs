﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new
           PropertyChangedEventArgs(propertyName));
        }

        // Метод изменения свойства с вызовом события PropertyChanged
        protected bool Set<T>(ref T prop, T value, [CallerMemberName] string propName=null)
        {
            if (Equals(prop, value)) return false;
            prop = value;
            OnPropertyChanged(propName);
            return true;
        }
    }

}
