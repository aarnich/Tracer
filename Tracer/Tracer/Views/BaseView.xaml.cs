
using Tracer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer.Views
{
    
    public partial class BaseView : ContentPage
    {
        const uint ExpandAnimationSpeed = 350;
        const uint CollapseAnimationSpeed = 250;
        const uint SharedTransitionDuration = 100;
        double _pageHeight = 0;
        public BaseView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

        }
        protected override void OnAppearing()
        {
            Popup.OnExpandTapped += OnExpand;
            Popup.OnCollapseTapped += OnCollapse;
            base.OnAppearing();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            _pageHeight = height;
            Popup.TranslationY = _pageHeight - Popup.PageHeader;
            base.OnSizeAllocated(width, height);
        }
        protected override void OnDisappearing()
        {
            Popup.OnExpandTapped -= OnExpand;
            Popup.OnCollapseTapped -= OnCollapse;
            base.OnDisappearing();
        }
        private void OnExpand()
        {
            PopupFade.IsVisible = true;
            var height = _pageHeight - Popup.PageHeader;
            Popup.TranslateTo(0, Height - height, ExpandAnimationSpeed, Easing.SinInOut);
        }
        private void OnCollapse()
        {
            PopupFade.FadeTo(0, CollapseAnimationSpeed, Easing.SinInOut);
            PopupFade.IsVisible = false;
            PopupFade.TranslateTo(0, _pageHeight - Popup.PageHeader, CollapseAnimationSpeed, Easing.SinInOut);
        }
        
    }
}