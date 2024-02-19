using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.ViewModels
{
    public partial class BaseViewmodel : ObservableObject
    {
        [ObservableProperty]
        public bool _isbusy;
        [ObservableProperty]
        public string _Title;

    }
}
