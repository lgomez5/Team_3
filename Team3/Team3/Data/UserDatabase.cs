using Firebase.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Firebase.Database.Query;

namespace Team3.Data
{
    public class UserDatabase
    {

        public FirebaseClient firebase = new FirebaseClient("https://yourdbname.firebaseio.com/");

        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

     
        public async Task SaveUserAsync(User user)
        {
            await firebase.Child("users").PostAsync(user);
        }

        public async Task SaveAssignmentAsync(Assignment assignment) {
            await firebase.Child("assignments").PostAsync(assignment);
        }

        public async Task<User> CheckUserAsync(string username, string password) {

            var user= (await firebase
              .Child("users")
              .OnceAsync<User>()).Where(a => a.Object.Username == username && a.Object.Password == password).FirstOrDefault().Object;

            if (user != null)
            {
                return user;
            }
            else {
                return null;
            }
        }
    }
}
