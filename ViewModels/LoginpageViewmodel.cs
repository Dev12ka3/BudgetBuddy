using Javax.Security.Auth.Login;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
