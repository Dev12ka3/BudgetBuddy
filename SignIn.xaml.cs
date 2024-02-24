namespace BudgetBuddy;

public partial class SignIn : ContentPage
{
    public SignIn()
    {
        InitializeComponent();
    }
    bool eye = false;

    private void Button_Clicked(object sender, EventArgs e)
    {
        ImageButton statusb = (ImageButton)sender;
        if (!eye)
        {
            statusb.Source = "https://cdn0.iconfinder.com/data/icons/typicons-2/24/lock-open-outline-1024.png";
            //Password.IsPassword = false;
            eye = true;
        }
        else
        {
            statusb.Source = "https://cdn0.iconfinder.com/data/icons/typicons-2/24/lock-closed-outline-512.png";
            //Password.IsPassword = true;
            eye = false;

        }
       
    }
}