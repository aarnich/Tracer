using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Tracer.Models;
using Xamarin.Forms;

namespace Tracer.Services
{
    public class FirebaseService
    {
        private FirebaseClient _client;

        public FirebaseService()
        {
            _client = new FirebaseClient("https://traceblazer.firebaseio.com/");
        }

        public async Task AddPerson(string username, string email, string firstName, string lastName, string address, string occupation,
            string dateOfBirth)
        {
            await _client.Child("userdetails").PostAsync(new UserDetails()
            {
                Username = username, FirstName = firstName, LastName = lastName, Address = address,
                Occupation = occupation, DateOfBirth = dateOfBirth, Email = email
            });
        }
    }
}
