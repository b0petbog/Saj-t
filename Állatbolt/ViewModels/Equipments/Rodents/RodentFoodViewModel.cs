using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Equipments;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using AllatboltProject.Repos;

namespace AllatboltProject.ViewModels.Equipments
{
    public partial class RodentFoodViewModel : BaseViewModel
    {
        private readonly RodentFoodRepo _foodRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfFoods = 0;

        [ObservableProperty]
        private ObservableCollection<Food> _foods = new();

        [ObservableProperty]
        private Food _selectedFood;

        public RodentFoodViewModel()
        {
            _selectedFood = new Food();
            UpdateView();
            StatusBarText = $"{NumberOfFoods} féle rágcsáló eleség betöltve";
        }

        [RelayCommand]
        public void DoSave(Food food)
        {
            if (food.HasId)
                _foodRepo.Update(food);
            else
                _foodRepo.Insert(food);
            UpdateView();
        }

        [RelayCommand]
        void DoNewFood()
        {
            SelectedFood = new Food();
            StatusBarText = "Adja meg az új eleség adatait!";
        }

        [RelayCommand]
        public void DoRemove(Food foodToDelete)
        {
            _foodRepo.Delete(foodToDelete);
            UpdateView();
            StatusBarText = $"{foodToDelete.Brand} {foodToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(Food food)
        {
            _foodRepo.UploadImage(food);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Foods = new ObservableCollection<Food>(_foodRepo.FindAll());
            NumberOfFoods = _foodRepo.GetNumberOfFoods();
        }
    }
}
