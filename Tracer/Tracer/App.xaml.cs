using System;
using System.Threading.Tasks;
using Tracer.Services;
using Tracer.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.Get("MyFirebaseRefreshToken", "") != string.Empty)
            {
                InitNavigation();
            }
            else
            {
                MainPage = new NavigationPage(new StartPage());
            }
            //InitNavigation();
        }
        public static Task InitNavigation()
        {
            return NavigationService.Instance.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
