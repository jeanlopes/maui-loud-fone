using LoudPhone.Interfaces;
using LoudPhone.Models;


namespace LoudPhone.ViewModels
{
    public class ConfigsViewModel(IDefaultSettings defaultSettings)
    {
        private readonly IDefaultSettings _defaultSettings = defaultSettings;

        public int SilentInterval { get; set; }
        public List<Todo> Todos { get; set; } = [];


        public void Initialize()
        {
            SilentInterval = _defaultSettings.GetDefaultSilentInterval();
            Todos = _defaultSettings.GetSettings().ToList();
        }

        public void UpdateSilentInterval(int interval)
        {
            _defaultSettings.SetDefaultSilentInterval(interval);
            SilentInterval = interval;
        }

        public void SaveSettings()
        {
            foreach (var todo in Todos)
            {
                _defaultSettings.AddSettings(todo);
            }
        }
    }
}
