using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using AllatboltProject.Repos;
using AllatboltProject.Workers;

namespace AllatboltProject.ViewModels.Workers
{
    public partial class VetViewModel : BaseViewModel
    {
        private readonly VetRepo _vetRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfVets = 0;

        [ObservableProperty]
        private ObservableCollection<Vet> _vets = new();

        [ObservableProperty]
        private Vet _selectedVet;

        public VetViewModel()
        {
            _selectedVet = new Vet();
            UpdateView();
            StatusBarText = $"{NumberOfVets} állatorvos betöltve";
        }

        [RelayCommand]
        public void DoSave(Vet vet)
        {
            if (vet.HasId)
                _vetRepo.Update(vet);
            else
                _vetRepo.Insert(vet);
            UpdateView();
        }

        [RelayCommand]
        void DoNewVet()
        {
            SelectedVet = new Vet();
            StatusBarText = "Adja meg az új orvos adatait!";
        }

        [RelayCommand]
        public void DoRemove(Vet vetToDelete)
        {
            _vetRepo.Delete(vetToDelete);
            UpdateView();
            StatusBarText = $"{vetToDelete.FirstName} {vetToDelete.LastName} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(Vet vet)
        {
            _vetRepo.UploadImage(vet);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Vets = new ObservableCollection<Vet>(_vetRepo.FindAll());
            NumberOfVets = _vetRepo.GetNumberOfVets();
        }
    }
}
