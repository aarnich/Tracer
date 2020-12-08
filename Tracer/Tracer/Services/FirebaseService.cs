using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddNote(string content, string email, string date, string time, string location)
        {
            await _client.Child("notedetails").PostAsync(new NotesItem()
            {
                Content = content, UserID = email, Date = date, Time = time, Location = location, Icon = "notif.png"
            });
        }

        public async Task<List<NotesItem>> GetAllCurrentUserNotes()
        {
            var listNotes = (await _client.Child("notedetails").OnceAsync<NotesItem>()).Select(
                item => new NotesItem()
                {
                    Content = item.Object.Content,
                    UserID = item.Object.UserID,
                    Date = item.Object.Date,
                    Time = item.Object.Time,
                    Location = item.Object.Location,
                    Icon = item.Object.Icon
                }).ToList();
            return listNotes.Where(item => item.UserID == StartPage.Email).ToList();
        }
    }
}
