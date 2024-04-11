using BudgetBuddy.Views;

namespace BudgetBuddy;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new SignIn())
		{
			BarTextColor = Color.FromRgb(255,255,255),
			BarBackgroundColor = Color.FromArgb("#3366ff")
		};
	}
}
