using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;


namespace BudgetBuddy.Views
{
    public partial class SignIn : ContentPage
    {
        public FirebaseAuthClient Client;

        public SignIn()
        {
            InitializeComponent();

            // Configure...
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyB4Qs7j-71SBV_cSg9hC4O05fGt2kj_uHE",
                AuthDomain = "fir-auth-2f00d.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                    //...
                },
                // WPF:
                UserRepository = new FileUserRepository("BudgetBuddy") // persist data into %AppData%\BudgetBuddy
                // UWP:
                //UserRepository = new StorageRepository() // persist data into ApplicationDataContainer
            };

            //...and create your FirebaseAuthClient
            Client = new FirebaseAuthClient(config);
        }

        private async void Loginbutton(object sender, EventArgs e)
        {
            try
            {
                var userCredential = await Client.SignInWithEmailAndPasswordAsync(EmailEntry.Text, PasswordEntry.Text);
                await Navigation.PushAsync(new PayItemListPage());
            }
            catch (FirebaseAuthException ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Createaccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}