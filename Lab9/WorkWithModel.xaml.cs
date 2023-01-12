using Lab9.Commands;
using Microsoft.Win32;
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

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для WorkWithModel.xaml
    /// </summary>
    public partial class WorkWithModel : Window
    {
        public WorkWithModel()
        {
            InitializeComponent();
        }
        #region Свойства
        public string ModelName
        {
            get { return (string)GetValue(ModelNameProperty); }
            set { SetValue(ModelNameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        // FullName.This enables animation, styling, binding, etc...
          public static readonly DependencyProperty ModelNameProperty
            = DependencyProperty.Register("ModelName", typeof(string),
                typeof(WorkWithModel), new PropertyMetadata(default(string)));
        public decimal Price
        {
            get { return (decimal)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        // FullName.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty
          = DependencyProperty.Register("Price", typeof(decimal),
              typeof(WorkWithModel), new PropertyMetadata(default(decimal)));
        public DateTime IssueDate
        {
            get { return (DateTime)GetValue(IssueDateProperty); }
            set { SetValue(IssueDateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        // FullName.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IssueDateProperty
          = DependencyProperty.Register("IssueDate", typeof(DateTime),
              typeof(WorkWithModel), new PropertyMetadata(default(DateTime)));
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        // FullName.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty
          = DependencyProperty.Register("ImagePath", typeof(string),
              typeof(WorkWithModel), new PropertyMetadata(default(string)));
        #endregion
        #region  Выбор изображения
        private ICommand selectImageCommand;
        public ICommand SelectImageCommand => selectImageCommand ?? new RelayCommand(OnSelectImageExecuted);
        public void OnSelectImageExecuted(object param)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ImagePath = dialog.FileName;
            }
        }
        #endregion
        #region Команда для Ок
        private ICommand okCommand;
        public ICommand OkCommand => okCommand ?? new RelayCommand(OnOkExecuted);
        public void OnOkExecuted(object param)
        {
            this.DialogResult = true;
            this.Close();
        }
        #endregion
    }
}
