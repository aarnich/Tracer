using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Tracer.Services;
using Tracer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotesPopUpView : PopupPage
    {
        private FirebaseService firebase;
        private List<string> locationList = new List<string>(){"Makati", "BGC", "Glorietta"};
        public AddNotesPopUpView()
        {
            InitializeComponent();
            firebase = new FirebaseService();
            CmbLocations.ItemsSource = locationList;
            CmbLocations.SelectedIndex = 0;
        }

        private async void AddToDatabase(object sender, EventArgs e)
        {
            var content = TxtContent.Text;
            var email = StartPage.Email;
            var date = DprDoa.Date.ToString("d");
            var time = TprToa.Time.ToString();
            var location = CmbLocations.SelectedItem.ToString();
            await firebase.AddNote(content, email, date, time, location);
            await PopupNavigation.Instance.PopAsync();
            await NavigationService.Instance.InitializeAsync();
        }
    }
}