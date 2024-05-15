using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Users;
using AllatboltProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using AllatboltProject.Repos;

namespace AllatboltProject.ViewModels.Users
{
    public partial class UserViewModel : BaseViewModel
    {
        private readonly UserRepo _userRepo = new();

        [ObservableProperty]
        private string _statusBarText = string.Empty;

        [ObservableProperty]
        public int _numberOfUsers = 0;

        [ObservableProperty]
        private ObservableCollection<User> _users = new();

        [ObservableProperty]
        private User _selectedUser;

        public UserViewModel()
        {
            _selectedUser = new User();
            UpdateView();
            StatusBarText = $"{NumberOfUsers} felhasználó betöltve";
        }

        [RelayCommand]
        public void DoSave(User user)
        {
            if (user.HasId)
                _userRepo.Update(user);
            else
                _userRepo.Insert(user);
            UpdateView();
        }

        [RelayCommand]
        void DoNewUser()
        {
            SelectedUser = new User();
            StatusBarText = "Adja meg az új ketrec adatait!";
        }

        [RelayCommand]
        public void DoRemove(User userToDelete)
        {
            _userRepo.Delete(userToDelete);
            UpdateView();
            StatusBarText = $"{userToDelete.FirstName} {userToDelete.LastName} törölve lett";
        }

        [RelayCommand]
        public void UploadImage(User user)
        {
            _userRepo.UploadImage(user);
            UpdateView();
            StatusBarText = $"Kép módosítva";
        }

        private void UpdateView()
        {
            Users = new ObservableCollection<User>(_userRepo.FindAll());
            NumberOfUsers = _userRepo.GetNumberOfUsers();
        }
    }
}
