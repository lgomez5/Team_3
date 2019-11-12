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

        public UserDatabase()
        {
            Console.WriteLine("New object of DB class contstructed");
        }

        public async Task SaveUserAsync(User user)
        {
            await firebase.Child("users").PostAsync(user);
        }

        public async Task SaveAssignmentAsync(Assignment assignment)
        {
            await firebase.Child("assignments").PostAsync(assignment);
        }

        public async Task<User> CheckUserAsync(string username, string password)
        {
            var user = (await firebase
              .Child("users")
              .OnceAsync<User>()).Where(a => a.Object.Username == username && a.Object.Password == password).FirstOrDefault().Object;

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
      
        public async Task<List<Assignment>> GetAssignmentList(string status)
        {
            var assignmentlist = (await firebase
              .Child("assignments")
              .OnceAsync<Assignment>()).Where(a => a.Object.Status == status).ToList();

            List<Assignment> assignments = new List<Assignment>();
            Assignment obj;
            foreach (var assignment in assignmentlist)
            {
                obj = new Assignment();
                obj = assignment.Object;
                assignments.Add(obj);
            }
            return assignments;
        }

        public async Task<List<Assignment>> GetGradeAssignmentList(int gradeid)
        {
            var GradeAssignmentList = (await firebase
              .Child("assignments")
              .OnceAsync<Assignment>()).Where(a => a.Object.GradeId == gradeid).ToList();

            List<Assignment> assignments = new List<Assignment>();
            Assignment obj;
            foreach (var assignment in GradeAssignmentList)
            {
                obj = new Assignment();
                obj = assignment.Object;
                assignments.Add(obj);
            }
            return assignments;
        }

        public async Task<List<Assignment>> GetCourseAssignmentList(string coursecode)
        {
            var CourseAssignmentList = (await firebase
              .Child("assignments")
              .OnceAsync<Assignment>()).Where(a => a.Object.CourseCode == coursecode).ToList();

            List<Assignment> assignments = new List<Assignment>();
            Assignment obj;
            foreach (var assignment in CourseAssignmentList)
            {
                obj = new Assignment();
                obj = assignment.Object;
                assignments.Add(obj);
            }
            return assignments;
        }
    }
}
