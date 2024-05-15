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
    public partial class RodentCageViewModel : BaseViewModel
    {
        private readonly RodentCageRepo _cageRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfCages = 0;

        [ObservableProperty]
        private ObservableCollection<Cage> _cages = new();

        [ObservableProperty]
        private Cage _selectedCage;

        public RodentCageViewModel()
        {
            _selectedCage = new Cage();
            UpdateView();
            StatusBarText = $"{NumberOfCages} féle rágcsáló ketrec betöltve";
        }

        [RelayCommand]
        public void DoSave(Cage cage)
        {
            if (cage.HasId)
                _cageRepo.Update(cage);
            else
                _cageRepo.Insert(cage);
            UpdateView();
        }

        [RelayCommand]
        void DoNewCage()
        {
            SelectedCage = new Cage();
            StatusBarText = "Adja meg az új ketrec adatait!";
        }

        [RelayCommand]
        public void DoRemove(Cage cageToDelete)
        {
            _cageRepo.Delete(cageToDelete);
            UpdateView();
            StatusBarText = $"{cageToDelete.Brand} {cageToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(Cage cage)
        {
            _cageRepo.UploadImage(cage);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Cages = new ObservableCollection<Cage>(_cageRepo.FindAll());
            NumberOfCages = _cageRepo.GetNumberOfCages();
        }
    }
}
