using LoudPhone.Interfaces;

namespace LoudPhone.Services
{
    public class SilentIntervalService : ISilentIntervalService
    {
        private readonly IDefaultSettings _defaultSettings;
        private readonly Dictionary<DayOfWeek, int> _dayOfWeek = new() {
            { DayOfWeek.Sunday, 1 }, 
            { DayOfWeek.Monday, 2 }, 
            { DayOfWeek.Tuesday, 3 }, 
            { DayOfWeek.Wednesday, 4 },
            { DayOfWeek.Thursday, 5 },
            { DayOfWeek.Friday, 6 },
            { DayOfWeek.Saturday, 7 },
         };

        public SilentIntervalService(IDefaultSettings defaultSettings) => _defaultSettings = defaultSettings;
        public bool IsOnSilentInterval()
        {
            var todos = _defaultSettings.GetSettings();
            var now = DateTime.Now;
            var day = _dayOfWeek[now.DayOfWeek];

            var any = todos.Any(t => t.DayOfWeek == day && t.StartTime <= now && t.EndTime >= now);

            return any;
        }
    }
}
