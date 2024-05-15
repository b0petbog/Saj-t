using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.ViewModels.Base;
using AllatboltProject.ViewModels.Animals;
using AllatboltProject.ViewModels.Equipments;
using AllatboltProject.ViewModels.Users;
using AllatboltProject.ViewModels.Workers;

namespace AllatboltProject.ViewModels
{
    partial class  MainWindowViewModel : BaseViewModel
    {
        [ObservableProperty]
        private BaseViewModel _childViewModel;

        [ObservableProperty]
        private string _statusBarText="A program betölödött...";

        public MainWindowViewModel()
        {
            _childViewModel = new WelcomeViewModel();
        }

        [RelayCommand]
        private void ShowHorseView()
        {
            ChildViewModel=new HorseViewModel();
            StatusBarText = "Ló adatok kezelése";
        }

        [RelayCommand]
        private void ShowCatView()
        {
            ChildViewModel = new CatViewModel();
            StatusBarText = "Macska adatok kezelése";
        }

        [RelayCommand]
        private void ShowHamsterView()
        {
            ChildViewModel = new HamsterViewModel();
            StatusBarText = "Hörcsög adatok kezelése";
        }

        [RelayCommand]
        private void ShowDogView()
        {
            ChildViewModel = new DogViewModel();
            StatusBarText = "Kutya adatok kezelése";
        }

        [RelayCommand]
        private void ShowBunnyView()
        {
            ChildViewModel = new BunnyViewModel();
            StatusBarText = "Nyúl adatok kezelése";
        }

        [RelayCommand]
        private void ShowGiraffeView()
        {
            ChildViewModel = new GiraffeViewModel();
            StatusBarText = "Zsiráf adatok kezelése";
        }

        [RelayCommand]
        private void ShowSnakeView()
        {
            ChildViewModel = new SnakeViewModel();
            StatusBarText = "Kígyó adatok kezelése";
        }

        //-------------------------------------------------------

        [RelayCommand]
        private void ShowRodentFoodView()
        {
            ChildViewModel = new RodentFoodViewModel();
            StatusBarText = "Rágcsáló eleségek";
        }

        [RelayCommand]
        private void ShowRodentCageView()
        {
            ChildViewModel = new RodentCageViewModel();
            StatusBarText = "Ketrecek";
        }

        [RelayCommand]
        private void ShowBeddingView()
        {
            ChildViewModel = new BeddingViewModel();
            StatusBarText = "Almok";
        }

        //-------------------------------------------------------

        [RelayCommand]
        private void ShowDogFoodView()
        {
            ChildViewModel = new DogFoodViewModel();
            StatusBarText = "Kutyakaják";
        }

        //-------------------------------------------------------

        [RelayCommand]
        private void ShowVetView() 
        {
            ChildViewModel = new VetViewModel();
            StatusBarText = "Állatorvosok";
        }

        //-------------------------------------------------------

        [RelayCommand]
        private void ShowUsersView()
        {
            ChildViewModel = new UserViewModel();
            StatusBarText = "Felhasználók";
        }

    }
}
