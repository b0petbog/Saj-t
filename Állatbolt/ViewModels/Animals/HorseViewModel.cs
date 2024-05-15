using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class HorseViewModel : BaseViewModel
    {
        private readonly HorseSpeciesRepo _horseSpeciesRepo = new();
        private readonly HorseRepo _horseRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfHorses = 0;

        [ObservableProperty]
        private ObservableCollection<string> _horseSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Horse> _horses = new();

        [ObservableProperty]
        private Horse _selectedHorse;

        public string SearchedHorseSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public HorseViewModel()
        {
            _selectedHorse = new Horse();
            UpdateView();
            StatusBarText = $"{NumberOfHorses} ló adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Horse horse)
        {
            if (horse.HasId)
                _horseRepo.Update(horse);
            else
                _horseRepo.Insert(horse);
            UpdateView();
        }

        [RelayCommand]
        void DoNewHorse()
        {
            SelectedHorse = new Horse();
            StatusBarText = "Adja meg az új ló adatait!";
        }

        [RelayCommand]
        public void DoRemove(Horse horseToDelete)
        {
            _horseRepo.Delete(horseToDelete);
            UpdateView();
            StatusBarText = $"{horseToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Horse> result = _horseRepo.Filtering(SearchedHorseSpecies, IsGenderSearchingEnabled, IsFemale);
            Horses = new ObservableCollection<Horse>(result);
        }

        private void UpdateView()
        {
            HorseSpecies = new ObservableCollection<string>(_horseSpeciesRepo.FindAll());
            Horses = new ObservableCollection<Horse>(_horseRepo.FindAll());
            NumberOfHorses = _horseRepo.GetNumberOfHorses();
        }
    }
}
