using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BudgetBuddy.ViewModels
{
    public partial class LoginpageViewmodel : BaseViewmodel
    {
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;

        [ICommand]
        public async void Login() { }

    }
}
