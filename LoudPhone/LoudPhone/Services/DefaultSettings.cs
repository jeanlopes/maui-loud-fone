using LoudPhone.Interfaces;
using LoudPhone.Models;

namespace LoudPhone.Services
{
    public class DefaultSettings : IDefaultSettings
    {
        private readonly IDatabaseService _databaseService;
        private const string SilentIntervalKey = "DefaultSilentInterval";
        private const int SilentIntervalDefault = 30;

        public DefaultSettings(IDatabaseService databaseService) => _databaseService = databaseService;

        public int GetDefaultSilentInterval()
        {
            var setting = _databaseService.GetSetting(SilentIntervalKey);
            if (setting != null && int.TryParse(setting.Value, out int interval))
            {
                return interval;
            }
            return SilentIntervalDefault;
        }

        public void SetDefaultSilentInterval(int interval)
        {
            _databaseService.SaveSetting(new AppSettings
            {
                Key = SilentIntervalKey,
                Value = interval.ToString()
            });
        }

        public IEnumerable<Todo> GetSettings()
        {
            return _databaseService.GetSetting();
        }

        public void AddSettings(Todo todo)
        {
            if (todo.Id == 0)
            {
                var lastId = _databaseService.GetLastInserted();
                todo.Id = lastId++;
            }

            _databaseService.SaveSettings(todo);
        }

        public void RemoveTodo(Todo todo)
        {
            _databaseService.RemoveSettings(todo);
        }
    }
}
