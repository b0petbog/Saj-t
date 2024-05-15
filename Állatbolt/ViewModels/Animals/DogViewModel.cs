using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class DogViewModel : BaseViewModel
    {
        private readonly DogSpeciesRepo _dogSpeciesRepo = new();
        private readonly DogRepo _dogRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfDogs = 0;

        [ObservableProperty]
        private ObservableCollection<string> _dogSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Dog> _dogs = new();

        [ObservableProperty]
        private Dog _selectedDog;

        public string SearchedDogSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public DogViewModel()
        {
            _selectedDog = new Dog();
            UpdateView();
            StatusBarText = $"{NumberOfDogs} kutya adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Dog dog)
        {
            if (dog.HasId)
                _dogRepo.Update(dog);
            else
                _dogRepo.Insert(dog);
            UpdateView();
        }

        [RelayCommand]
        void DoNewDog()
        {
            SelectedDog = new Dog();
            StatusBarText = "Adja meg az új kutya adatait!";
        }

        [RelayCommand]
        public void DoRemove(Dog dogToDelete)
        {
            _dogRepo.Delete(dogToDelete);
            UpdateView();
            StatusBarText = $"{dogToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Dog> result = _dogRepo.Filtering(SearchedDogSpecies, IsGenderSearchingEnabled, IsFemale);
            Dogs = new ObservableCollection<Dog>(result);
        }

        private void UpdateView()
        {
            DogSpecies = new ObservableCollection<string>(_dogSpeciesRepo.FindAll());
            Dogs = new ObservableCollection<Dog>(_dogRepo.FindAll());
            NumberOfDogs = _dogRepo.GetNumberOfDogs();
        }
    }
}
