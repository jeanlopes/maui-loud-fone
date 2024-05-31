using LoudPhone.Interfaces;

namespace LoudPhone.ViewModels
{
    public class ConfigsViewModel
    {
        private readonly IDefaultSettings _defaultSettings;

        public ConfigsViewModel(IDefaultSettings defaultSettings)
        {
            _defaultSettings = defaultSettings;
        }

        public int SilentInterval { get; set; }

        public async Task InitializeAsync()
        {
            SilentInterval = await _defaultSettings.GetDefaultSilentIntervalAsync();
        }

        public async Task UpdateSilentIntervalAsync(int interval)
        {
            await _defaultSettings.SetDefaultSilentIntervalAsync(interval);
            SilentInterval = interval;
        }
    }
}
