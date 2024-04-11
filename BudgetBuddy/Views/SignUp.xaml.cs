using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using System;
using System.Text.RegularExpressions;


namespace BudgetBuddy.Views
{
    public partial class SignUp : ContentPage
    {
        private FirebaseAuthClient client;

        public SignUp()
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
            client = new FirebaseAuthClient(config);
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUppercase = new Regex(@"[A-Z]+");
            var hasLowercase = new Regex(@"[a-z]+");
            var hasSpecialChar = new Regex(@"[!@#$%^&*(),.?""]+");

            return hasNumber.IsMatch(password) &&
                   hasUppercase.IsMatch(password) &&
                   hasLowercase.IsMatch(password) &&
                   hasSpecialChar.IsMatch(password);
        }

        private bool ArePasswordsMatching(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        private async void SignUpbutton(object sender, EventArgs e)
        {
            if (!IsPasswordStrong(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Password must be at least 8 characters long and contain at least one number, one uppercase letter, one lowercase letter, and one special character", "OK");
                return;
            }

            if (!ArePasswordsMatching(PasswordEntry.Text, ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            try
            {
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(EmailEntry.Text, PasswordEntry.Text);
                await DisplayAlert("Success", "User created successfully", "OK");
                await Navigation.PushAsync(new SignIn());
            }
            catch (FirebaseAuthException ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void RedirectLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());

        }
    }
}