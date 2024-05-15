using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class BunnyViewModel : BaseViewModel
    {
        private readonly BunnySpeciesRepo _bunnySpeciesRepo = new();
        private readonly BunnyRepo _bunnyRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfBunnies = 0;

        [ObservableProperty]
        private ObservableCollection<string> _bunnySpecies = new();

        [ObservableProperty]
        private ObservableCollection<Bunny> _bunnies = new();

        [ObservableProperty]
        private Bunny _selectedBunny;

        public string SearchedBunnySpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public BunnyViewModel()
        {
            _selectedBunny = new Bunny();
            UpdateView();
            StatusBarText = $"{NumberOfBunnies} nyúl adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Bunny bunny)
        {
            if (bunny.HasId)
                _bunnyRepo.Update(bunny);
            else
                _bunnyRepo.Insert(bunny);
            UpdateView();
        }

        [RelayCommand]
        void DoNewBunny()
        {
            SelectedBunny = new Bunny();
            StatusBarText = "Adja meg az új macska adatait!";
        }

        [RelayCommand]
        public void DoRemove(Bunny bunnyToDelete)
        {
            _bunnyRepo.Delete(bunnyToDelete);
            UpdateView();
            StatusBarText = $"{bunnyToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Bunny> result = _bunnyRepo.Filtering(SearchedBunnySpecies, IsGenderSearchingEnabled, IsFemale);
            Bunnies = new ObservableCollection<Bunny>(result);
        }

        private void UpdateView()
        {
            BunnySpecies = new ObservableCollection<string>(_bunnySpeciesRepo.FindAll());
            Bunnies = new ObservableCollection<Bunny>(_bunnyRepo.FindAll());
            NumberOfBunnies = _bunnyRepo.GetNumberOfBunnies();
        }
    }
}

