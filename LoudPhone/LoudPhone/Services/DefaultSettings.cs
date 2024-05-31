using LoudPhone.Interfaces;
using LoudPhone.Models;

namespace LoudPhone.Services
{
    public class DefaultSettings : IDefaultSettings
    {
        private readonly DatabaseService _databaseService;
        private const string SilentIntervalKey = "DefaultSilentInterval";
        private const int SilentIntervalDefault = 30;

        public DefaultSettings(DatabaseService databaseService) => _databaseService = databaseService;

        public async Task<int> GetDefaultSilentIntervalAsync()
        {
            var setting = await _databaseService.GetSettingAsync(SilentIntervalKey);
            if (setting != null && int.TryParse(setting.Value, out int interval))
            {
                return interval;
            }
            return SilentIntervalDefault;
        }

        public Task SetDefaultSilentIntervalAsync(int interval)
        {
            return _databaseService.SaveSettingAsync(new AppSettings
            {
                Key = SilentIntervalKey,
                Value = interval.ToString()
            });
        }

        public async Task<IEnumerable<Todo>> GetSettingsAsync()
        {
            return await _databaseService.GetSettingAsync();
        }

        public async Task AddSettingsAsync(Todo todo)
        {
            if (todo.Id == 0)
            {
                var lastId = await _databaseService.GetLastInserted();
                todo.Id = lastId++;
            }

            await _databaseService.SaveSettingsAsync(todo);
        }

        public async Task RemoveTodoAsync(Todo todo)
        {
            await _databaseService.RemoveSettingsAsync(todo);
        }
    }
}
