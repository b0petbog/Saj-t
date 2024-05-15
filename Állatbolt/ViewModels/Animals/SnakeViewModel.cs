using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Repos;
using AllatboltProject.Animals;
using AllatboltProject.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AllatboltProject.ViewModels.Animals
{
    public partial class SnakeViewModel : BaseViewModel
    {
        private readonly SnakeSpeciesRepo _snakeSpeciesRepo = new();
        private readonly SnakeRepo _snakeRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfSnakes = 0;

        [ObservableProperty]
        private ObservableCollection<string> _snakeSpecies = new();

        [ObservableProperty]
        private ObservableCollection<Snake> _snakes = new();

        [ObservableProperty]
        private Snake _selectedSnake;

        public string SearchedSnakeSpecies { get; set; } = string.Empty;

        public bool IsGenderSearchingEnabled { get; set; } = false;

        public bool IsFemale { get; set; } = false;

        public SnakeViewModel()
        {
            _selectedSnake = new Snake();
            UpdateView();
            StatusBarText = $"{NumberOfSnakes} kígyó adat betöltve";
        }

        [RelayCommand]
        public void DoSave(Snake snake)
        {
            if (snake.HasId)
                _snakeRepo.Update(snake);
            else
                _snakeRepo.Insert(snake);
            UpdateView();
        }

        [RelayCommand]
        void DoNewSnake()
        {
            SelectedSnake = new Snake();
            StatusBarText = "Adja meg az új kígyó adatait!";
        }

        [RelayCommand]
        public void DoRemove(Snake snakeToDelete)
        {
            _snakeRepo.Delete(snakeToDelete);
            UpdateView();
            StatusBarText = $"{snakeToDelete.Name} törölve lett";
        }

        [RelayCommand]
        public void Filtering()
        {
            List<Snake> result = _snakeRepo.Filtering(SearchedSnakeSpecies, IsGenderSearchingEnabled, IsFemale);
            Snakes = new ObservableCollection<Snake>(result);
        }

        private void UpdateView()
        {
            SnakeSpecies = new ObservableCollection<string>(_snakeSpeciesRepo.FindAll());
            Snakes = new ObservableCollection<Snake>(_snakeRepo.FindAll());
            NumberOfSnakes = _snakeRepo.GetNumberOfSnakes();
        }
    }
}
