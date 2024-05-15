using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class HamsterViewModel : BaseViewModel
    {
        private readonly HamsterSpeciesRepo _hamsterSpeciesRepo = new();
        private readonly HamsterRepo _hamsterRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfHamsters = 0;

        [ObservableProperty]
        private ObservableCollection<string> _hamsterSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Hamster> _hamsters = new();

        [ObservableProperty]
        private Hamster _selectedHamster;

        public string SearchedHamsterSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public bool IsAvabilitySearchingEnabled { get; set; } = false;

        public bool IsAvailable { get; set; } = false;

        public HamsterViewModel()
        {
            _selectedHamster = new Hamster();
            UpdateView();
            StatusBarText = $"{NumberOfHamsters} hörcsög adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Hamster hamster)
        {
            if (hamster.HasId)
                _hamsterRepo.Update(hamster);
            else
                _hamsterRepo.Insert(hamster);
            UpdateView();
        }

        [RelayCommand]
        void DoNewHamster()
        {
            SelectedHamster = new Hamster();
            StatusBarText = "Adja meg az új hörcsög adatait!";
        }

        [RelayCommand]
        public void DoRemove(Hamster hamsterToDelete)
        {
            _hamsterRepo.Delete(hamsterToDelete);
            UpdateView();
            StatusBarText = $"{hamsterToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Hamster> result = _hamsterRepo.Filtering(SearchedHamsterSpecies, IsGenderSearchingEnabled, IsFemale, IsAvabilitySearchingEnabled, IsAvailable);
            Hamsters = new ObservableCollection<Hamster>(result);
        }

        private void UpdateView()
        {
            HamsterSpecies = new ObservableCollection<string>(_hamsterSpeciesRepo.FindAll());
            Hamsters = new ObservableCollection<Hamster>(_hamsterRepo.FindAll());
            NumberOfHamsters = _hamsterRepo.GetNumberOfHamsters();
        }
    }
}
