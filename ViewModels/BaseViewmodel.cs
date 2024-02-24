using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetBuddy.ViewModels
{
    public partial class BaseViewmodel : ObservableObject
    {
        [ObservableProperty]
        public bool _isbusy;
        //[ObservableProperty]
        //public string? Title;

    }
}
