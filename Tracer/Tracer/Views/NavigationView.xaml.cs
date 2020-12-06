using Xamarin.Forms;

namespace Tracer.Views
{
    public partial class NavigationView : ContentPage
    {
        public NavigationView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Parallax.ParallaxView = HeaderView;
        }
    }
}