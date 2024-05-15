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
    public partial class GroomerViewModel : BaseViewModel
    {
        private readonly GroomerRepo _groomerRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfGroomers = 0;

        [ObservableProperty]
        private ObservableCollection<Groomer> _groomers = new();

        [ObservableProperty]
        private Groomer _selectedGroomer;

        public GroomerViewModel()
        {
            _selectedGroomer = new Groomer();
            UpdateView();
            StatusBarText = $"{NumberOfGroomers} kozmetikus betöltve";
        }

        [RelayCommand]
        public void DoSave(Groomer groomer)
        {
            if (groomer.HasId)
                _groomerRepo.Update(groomer);
            else
                _groomerRepo.Insert(groomer);
            UpdateView();
        }

        [RelayCommand]
        void DoNewGroomer()
        {
            SelectedGroomer = new Groomer();
            StatusBarText = "Adja meg az új orvos adatait!";
        }

        [RelayCommand]
        public void DoRemove(Groomer groomerToDelete)
        {
            _groomerRepo.Delete(groomerToDelete);
            UpdateView();
            StatusBarText = $"{groomerToDelete.FirstName} {groomerToDelete.LastName} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(Groomer groomer)
        {
            _groomerRepo.UploadImage(groomer);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Groomers = new ObservableCollection<Groomer>(_groomerRepo.FindAll());
            NumberOfGroomers = _groomerRepo.GetNumberOfGroomers();
        }
    }
}
