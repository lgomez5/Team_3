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

        public FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-49182.firebaseio.com/");

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

        public async Task<List<Assignment>> GetAssignmentList()
        {
            var assignmentlist = (await firebase
              .Child("assignments")
              .OnceAsync<Assignment>()).ToList();
            List<Assignment> assignments = new List<Assignment>();
            foreach (var assignment in assignmentlist)
            {
                Assignment obj = new Assignment();
                obj.Id = assignment.Object.Id;
                obj.GradeId = assignment.Object.GradeId;
                obj.SubmissionDate = assignment.Object.SubmissionDate;
                obj.Teacher = assignment.Object.Teacher;
                obj.Title = assignment.Object.Title;
                obj.Status = assignment.Object.Status;
                assignments.Add(obj);
            }
            return assignments;
        }
    }
}
