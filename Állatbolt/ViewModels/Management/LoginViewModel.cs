using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Users;
using AllatboltProject.Management;
using AllatboltProject.ViewModels.Base;
using AllatboltProject.Repos;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AllatboltProject.ViewModels.Management
{
    public partial class UserLoginViewModel : BaseViewModel
    {
        private readonly UserRepo _userRepo = new();

        [ObservableProperty]
        private ObservableCollection<User> _users = new();

        [ObservableProperty]
        private UserLogin _userToLogIn;

        [ObservableProperty]
        private MainWindowViewModel _mainWindow = new();

        public UserLoginViewModel()
        {
            _userToLogIn = new UserLogin();
            UpdateView();
        }

        [RelayCommand]
        public void Login(UserLogin userToLogIn)
        {
            foreach (User user in Users) 
            {
                if( (userToLogIn.Username==user.Username || userToLogIn.Username==user.Email) && userToLogIn.Password==user.Password)
                {
                    MainWindow.ShowWelcomeView();
                    break;
                }
            }
        }

        [RelayCommand]
        public void GoToRegistration()
        {
            MainWindow.ShowRegistrationView();
        }

        private void UpdateView()
        {
            Users = new ObservableCollection<User>(_userRepo.FindAll());
        }
    }
}
