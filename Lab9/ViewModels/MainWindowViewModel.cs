using Lab9.Business.Infrastructure;
using Lab9.Business.Managers;
using Lab9.Commands;
using Lab9.Domain.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        BrandManager brandManager;
        ModelManager modelManager;
        // Список групп
        public ObservableCollection<Brand> Brands { get; set; }

        /// Список студентов группы
        public ObservableCollection<Model> Models { get; set; }
        public string Title { get => title; set => title = value; }
        #region Выбранный производитель (бренд)
        private Brand _selectedBrand;
        public Brand SelectedBrand
        {
            get => _selectedBrand;
            set
            {
                Set(ref _selectedBrand, value);
            }
        }
        #endregion
        #region Модель авто для редактирования
        private Model selectedModel;
        public Model SelectedModel
        {
            get => selectedModel;
            set
            {
                Set(ref selectedModel, value);
            }
        }
        #endregion
        private string title = "Brands Window";
        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            brandManager = factory.GetBrandManager();
            //иниц БД
            if (brandManager.Brands.Count() == 0)
                DbTestData.SetupData(brandManager);
            modelManager = factory.GetModelManager();
            Brands = new ObservableCollection<Brand>(brandManager.Brands);
            Models = new ObservableCollection<Model>();
            if (Brands.Count > 0)
                OnGetModelExecuted(Brands[0].Id);
        }
        #region Commands
        #region Выбор производителя 
        private ICommand getModelsCommand;
        public ICommand GetModelsCommand => getModelsCommand ?? new RelayCommand(OnGetModelExecuted);
        private async void OnGetModelExecuted(object id)
        {
            Models.Clear();
            var models =await brandManager.GetModelsOfBrandAsync((int)id);
            foreach (var m in models) 
                Models.Add(m);
        }
        #endregion
        #region Добавить модель авто
        private ICommand newModelCommand;
        public ICommand NewModelCommand => newModelCommand ??= new RelayCommand(OnNewModelExecuted);
        private void OnNewModelExecuted(object id)
        {
            var dialog = new WorkWithModel
            {
                IssueDate = DateTime.Now
            };

            if (dialog.ShowDialog() != true) return;
            var model = new Model
            {
                Name = dialog.ModelName,
                IssueDate = dialog.IssueDate,
                Price = dialog.Price
            };
            var fileName = Path.GetFileName(dialog.ImagePath);
            model.ImageModel = fileName;
            brandManager.AddModelToBrand(model, _selectedBrand.Id);

            var target = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            File.Copy(dialog.ImagePath, target);// ошибка при добавлении но добавляет
            Models.Add(model);
        }
        #endregion
        #region Редактирование информации о модели авто
        private ICommand _editModelCommand;
        public ICommand EditModelCommand => _editModelCommand ?? new RelayCommand(OnEditModelExecuted, EditModelCanExecute);
        // Проверка возможности редактирования
        private bool EditModelCanExecute(object p) => selectedModel != null;
        private void OnEditModelExecuted(object id)
        {
            var dialog = new WorkWithModel
            {
                ModelName = selectedModel.Name,
                IssueDate = selectedModel.IssueDate,
                ImagePath = selectedModel.ImageModel,
                Price=selectedModel.Price

            };
            if (dialog.ShowDialog() != true) return;

            // Путь к папке Images
            var imageFolderPass = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            // Если выбрано новое изображение
            if (!selectedModel.ImageModel.Equals(dialog.ImagePath))
            {
                // Удалить старое изображение
                File.Delete(Path.Combine(imageFolderPass, selectedModel.ImageModel));
                // Получить имя нового файла изображения
                var newImage = Path.GetFileName(dialog.ImagePath);
                // Скопировать файл в папку Images
                File.Copy(dialog.ImagePath, Path.Combine(imageFolderPass,newImage), true);
                selectedModel.ImageModel =newImage;
            }
            selectedModel.Name = dialog.ModelName;
            selectedModel.IssueDate = dialog.IssueDate;
            selectedModel.Price = dialog.Price;
            modelManager.UpDateModel(selectedModel);

            // Обновить список студентов
            OnGetModelExecuted(_selectedBrand.Id);                 
        }
        #endregion
        #region Удаление записи о модели авто
        private ICommand deleteModelCommand;
        public ICommand DeleteModelCommand => deleteModelCommand ?? new RelayCommand(OnDeleteModelExecute, OnDeleteModelCanExecute);
        private bool OnDeleteModelCanExecute(object o) => selectedModel != null;
        private void OnDeleteModelExecute(object id)
        {
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            //удалить старое изображение
            File.Delete(Path.Combine(imageFolder, selectedModel.ImageModel));
            //удалить модель
            modelManager.DeleteModel(selectedModel.Id);

            //обновляем список моделей
            OnGetModelExecuted(_selectedBrand.Id);
        }
        #endregion
        #endregion
    }
}

