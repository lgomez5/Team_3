using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

     
        public Task<int> SaveUserAsync(User user)
        {
             return _database.InsertAsync(user);
        }
        public bool CheckUserAsync(String username, String password) {

            var obj = _database.Table<User>()
                            .Where(i => i.Username == username)
                            .FirstOrDefaultAsync();

            if (obj.Result.Password == password)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public string GetRole(String username) {
            var obj = _database.Table<User>()
                        .Where(i => i.Username == username)
                        .FirstOrDefaultAsync();
            return obj.Result.UserType;
        }
    }
}
