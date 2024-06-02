using SQLite;
using LoudPhone.Models;
using LoudPhone.Interfaces;

namespace LoudPhone.Services
{
    public class DatabaseService: IDatabaseService
    {
        private SQLiteConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "appsettings.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<AppSettings>();
            _database.CreateTable<Todo>();
        }        

        public int SaveSettings(Todo todo)
        {
            return _database.InsertOrReplace(todo);
        }

        public IEnumerable<Todo> GetSetting()
        {
            return _database.Table<Todo>().ToList();
        }

        public int GetLastInserted()
        {
            return _database.Table<Todo>().OrderByDescending(t => t.Id).FirstOrDefault().Id;
        }

        public int SaveSetting(AppSettings setting)
        {
            return _database.InsertOrReplace(setting);
        }

        public AppSettings GetSetting(string key)
        {

            return _database.Table<AppSettings>().FirstOrDefault(s => s.Key == key);
        }            

        public void RemoveSettings(Todo todo)
        {
            _database.Table<Todo>().FirstOrDefault(t => t.Id == todo.Id);
        }
    }
}
