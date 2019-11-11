using Firebase.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team3.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public DateTime DateCreated { get; set; }
        public int GradeId { get; set; }
        public string CourseCode { get; set; }

        public static explicit operator User(FirebaseObject<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
