using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputUserDetailsPage : ContentPage
    {
        public InputUserDetailsPage()
        {
            InitializeComponent();
        }

        private async void AddUserDetails(object sender, EventArgs e)
        {
            var username = TxtUName.Text;
            var email = StartPage.Email;
            var firstName = TxtFName.Text;
            var lastName = TxtLName.Text;
            var address = TxtAddress.Text;
            var occupation = TxtOccupation.Text;
            var dateOfBirth = DprBirthDate.Date.ToString("d");
            var firebase = new FirebaseService();
            await firebase.AddPerson(username, email, firstName, lastName, address, occupation, dateOfBirth);
            await App.InitNavigation();
        }
    }
}