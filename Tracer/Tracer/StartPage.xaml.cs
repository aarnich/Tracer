using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        public string WebApi { get; } = "AIzaSyDWHdJo1jRj2Z2LQxaiMCy6NnZEg1WTQ84";
        public static string Email { get; private set; }

        private async void LogInToApp(object sender, EventArgs e)
        {
            var email = TxtLogEmail.Text;
            Email = email;
            var password = TxtLogPassword.Text;
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApi));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedContent);
                await App.InitNavigation();
            }
            catch
            {
                await DisplayAlert("Log In Failed", "Invalid Email or Password", "Ok");
            }
        }

        private async void RegisterToApp(object sender, EventArgs e)
        {
            var email = TxtRegEmail.Text;
            Email = email;
            var password = TxtRegPassword.Text;
            var confirmPassword = TxtRegConPassword.Text;
            if (email != string.Empty && password != string.Empty && confirmPassword != string.Empty &&
                password == confirmPassword)
            {
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApi));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                    await DisplayAlert("Registration Successful", "Registration Completed", "Ok");
                    await Navigation.PushAsync(new InputUserDetailsPage());
                }
                catch (Exception exception)
                {
                    await DisplayAlert("Registration Fail", exception.ToString(), "Pk");
                }
            }
        }
    }
}