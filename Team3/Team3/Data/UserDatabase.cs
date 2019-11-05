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

     
        public async Task<int> SaveUserAsync(User user)
        {
             return await _database.InsertAsync(user);
        }
        public async Task<bool> CheckUserAsync(String username, String password) {

            var obj = await _database.Table<User>()
                            .Where(i => i.Username == username && i.Password == password)
                            .FirstOrDefaultAsync();

            if (obj != null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public async Task<string> GetRole(String username) {
            var obj = await _database.Table<User>()
                        .Where(i => i.Username == username)
                        .FirstOrDefaultAsync();
            return obj.UserType;
        }
    }
}
