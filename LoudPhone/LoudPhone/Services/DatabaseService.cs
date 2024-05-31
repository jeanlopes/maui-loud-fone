using SQLite;
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
            _database.CreateTableAsync<Todo>().Wait();
        }

        public async Task<int> SaveSettingsAsync(Todo todo)
        {
            return await _database.InsertOrReplaceAsync(todo);
        }

        public async Task<IEnumerable<Todo>> GetSettingAsync()
        {
            return await _database.Table<Todo>().ToListAsync();
        }

        public async Task<int> GetLastInserted()
        {
            return (await _database.Table<Todo>().OrderByDescending(t => t.Id).FirstOrDefaultAsync()).Id;
        }

        public async Task<int> SaveSettingAsync(AppSettings setting)
        {
            return await _database.InsertOrReplaceAsync(setting);
        }

        public async Task<AppSettings> GetSettingAsync(string key)
        {
            return await _database.Table<AppSettings>().FirstOrDefaultAsync(s => s.Key == key);
        }

        public async Task RemoveSettingsAsync(Todo todo)
        {
            await _database.Table<Todo>().DeleteAsync(t => t.Id == todo.Id);
        }
    }
}
