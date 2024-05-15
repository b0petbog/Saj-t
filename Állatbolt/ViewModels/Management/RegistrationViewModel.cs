using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.Users;
using AllatboltProject.ViewModels.Base;
using System.Collections.ObjectModel;
using AllatboltProject.Repos;

namespace AllatboltProject.ViewModels.Management
{
    public partial class UserRegistrationViewModel : BaseViewModel
    {
        private readonly UserRepo _userRepo = new();

        [ObservableProperty]
        private ObservableCollection<User> _users = new();

        [ObservableProperty]
        private User _selectedUser;

        public UserRegistrationViewModel()
        {
            _selectedUser = new User();
            UpdateView();
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
        }

        [RelayCommand]
        public void DoRemove(User userToDelete)
        {
            _userRepo.Delete(userToDelete);
            UpdateView();
        }

        [RelayCommand]
        public void UploadImage(User user)
        {
            _userRepo.UploadImage(user);
            UpdateView();
        }

        private void UpdateView()
        {
            Users = new ObservableCollection<User>(_userRepo.FindAll());
        }
    }
}
