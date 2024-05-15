using AllatboltProject.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using AllatboltProject.ViewModels;
using AllatboltProject.ViewModels.Management;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AllatboltProject.ViewModels
{
    public partial class WelcomeLoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private BaseViewModel _childViewModel;
        public WelcomeLoginViewModel() 
        {
            ChildViewModel = new UserLoginViewModel();
        }

        [RelayCommand]
        public void ShowRegistrationView()
        {
            ChildViewModel = new UserRegistrationViewModel();
        }

        [RelayCommand]
        public void ShowLoginView()
        {
            ChildViewModel = new UserLoginViewModel();
        }
    }
}
