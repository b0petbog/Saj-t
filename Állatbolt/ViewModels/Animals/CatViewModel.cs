using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class CatViewModel : BaseViewModel
    {
        private readonly CatSpeciesRepo _catSpeciesRepo = new();
        private readonly CatRepo _catRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfCats = 0;

        [ObservableProperty]
        private ObservableCollection<string> _catSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Cat> _cats = new();

        [ObservableProperty]
        private Cat _selectedCat;

        public string SearchedCatSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public CatViewModel()
        {
            _selectedCat = new Cat();
            UpdateView();
            StatusBarText = $"{NumberOfCats} macska adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Cat cat)
        {
            if (cat.HasId)
                _catRepo.Update(cat);
            else
                _catRepo.Insert(cat);
            UpdateView();
        }

        [RelayCommand]
        void DoNewCat()
        {
            SelectedCat = new Cat();
            StatusBarText = "Adja meg az új macska adatait!";
        }

        [RelayCommand]
        public void DoRemove(Cat catToDelete)
        {
            _catRepo.Delete(catToDelete);
            UpdateView();
            StatusBarText = $"{catToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Cat> result = _catRepo.Filtering(SearchedCatSpecies, IsGenderSearchingEnabled, IsFemale);
            Cats = new ObservableCollection<Cat>(result);
        }

        private void UpdateView()
        {
            CatSpecies = new ObservableCollection<string>(_catSpeciesRepo.FindAll());
            Cats = new ObservableCollection<Cat>(_catRepo.FindAll());
            NumberOfCats = _catRepo.GetNumberOfCats();
        }
    }
}

