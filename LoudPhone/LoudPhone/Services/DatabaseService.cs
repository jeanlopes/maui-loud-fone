using SQLite;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using LoudPhone.Models;

namespace LoudPhone.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "appsettings.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppSettings>().Wait();
        }

        public Task<int> SaveSettingAsync(AppSettings setting)
        {
            return _database.InsertOrReplaceAsync(setting);
        }

        public Task<AppSettings> GetSettingAsync(string key)
        {
            return _database.Table<AppSettings>().FirstOrDefaultAsync(s => s.Key == key);
        }
    }
}
