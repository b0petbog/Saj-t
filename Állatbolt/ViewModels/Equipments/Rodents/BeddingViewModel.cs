using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Equipments;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using AllatboltProject.Repos;
using System.Windows.Data;

namespace AllatboltProject.ViewModels.Equipments
{
    public partial class BeddingViewModel : BaseViewModel
    {
        private readonly BeddingRepo _beddingRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfBeddings = 0;

        [ObservableProperty]
        private ObservableCollection<Bedding> _beddings = new();

        [ObservableProperty]
        private Bedding _selectedBedding;

        public BeddingViewModel()
        {
            _selectedBedding = new Bedding();
            UpdateView();
            StatusBarText = $"{NumberOfBeddings} féle rágcsáló alom betöltve";
        }

        [RelayCommand]
        public void DoSave(Bedding bedding)
        {
            if (bedding.HasId)
                _beddingRepo.Update(bedding);
            else
                _beddingRepo.Insert(bedding);
            UpdateView();
        }

        [RelayCommand]
        void DoNewBedding()
        {
            SelectedBedding = new Bedding();
            StatusBarText = "Adja meg az új alom adatait!";
        }

        [RelayCommand]
        public void DoRemove(Bedding beddingToDelete)
        {
            _beddingRepo.Delete(beddingToDelete);
            UpdateView();
            StatusBarText = $"{beddingToDelete.Brand} {beddingToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(Bedding bedding)
        {
            _beddingRepo.UploadImage(bedding);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Beddings = new ObservableCollection<Bedding>(_beddingRepo.FindAll());
            NumberOfBeddings = _beddingRepo.GetNumberOfBeddings();
        }
    }
}
