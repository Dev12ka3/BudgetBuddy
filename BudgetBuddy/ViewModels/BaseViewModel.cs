using CommunityToolkit.Mvvm.ComponentModel;

namespace BudgetBuddy.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(this.IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !this.IsBusy;
    }
}
