using LoudPhone.Interfaces;
using LoudPhone.Models;


namespace LoudPhone.ViewModels
{
    public class ConfigsViewModel
    {
        private readonly IDefaultSettings _defaultSettings;

        public ConfigsViewModel(IDefaultSettings defaultSettings)
        {
            _defaultSettings = defaultSettings;
            Todos = [];
        }

        public int SilentInterval { get; set; }
        public List<Todo> Todos { get; set; }


        public async Task InitializeAsync()
        {
            SilentInterval = await _defaultSettings.GetDefaultSilentIntervalAsync();
            Todos = (await _defaultSettings.GetSettingsAsync()).ToList();
        }

        public async Task UpdateSilentIntervalAsync(int interval)
        {
            await _defaultSettings.SetDefaultSilentIntervalAsync(interval);
            SilentInterval = interval;
        }

        public async Task SaveSettings()
        {
            foreach (var todo in Todos)
            {
                await _defaultSettings.AddSettingsAsync(todo);
            }
        }
    }
}
