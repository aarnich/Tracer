using System;
using System.Threading.Tasks;
using Tracer.Services;
using Tracer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitNavigation();
        }
        Task InitNavigation()
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
