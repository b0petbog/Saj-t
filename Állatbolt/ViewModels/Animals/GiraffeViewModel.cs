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
    public partial class GiraffeViewModel : BaseViewModel
    {
        private readonly GiraffeSpeciesRepo _giraffeSpeciesRepo = new();
        private readonly GiraffeRepo _giraffeRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfGiraffes = 0;

        [ObservableProperty]
        private ObservableCollection<string> _giraffeSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Giraffe> _giraffes = new();

        [ObservableProperty]
        private Giraffe _selectedGiraffe;

        public string SearchedGiraffeSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public GiraffeViewModel()
        {
            _selectedGiraffe = new Giraffe();
            UpdateView();
            StatusBarText = $"{NumberOfGiraffes} zsiráf adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Giraffe giraffe)
        {
            if (giraffe.HasId)
                _giraffeRepo.Update(giraffe);
            else
                _giraffeRepo.Insert(giraffe);
            UpdateView();
        }

        [RelayCommand]
        void DoNewGiraffe()
        {
            SelectedGiraffe = new Giraffe();
            StatusBarText = "Adja meg az új zsiráf adatait!";
        }

        [RelayCommand]
        public void DoRemove(Giraffe giraffeToDelete)
        {
            _giraffeRepo.Delete(giraffeToDelete);
            UpdateView();
            StatusBarText = $"{giraffeToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Giraffe> result = _giraffeRepo.Filtering(SearchedGiraffeSpecies, IsGenderSearchingEnabled, IsFemale);
            Giraffes = new ObservableCollection<Giraffe>(result);
        }

        private void UpdateView()
        {
            GiraffeSpecies = new ObservableCollection<string>(_giraffeSpeciesRepo.FindAll());
            Giraffes = new ObservableCollection<Giraffe>(_giraffeRepo.FindAll());
            NumberOfGiraffes = _giraffeRepo.GetNumberOfGiraffes();
        }
    }
}
