using Android.App;
using Android.Content;
using Android.OS;
using LoudPhone.Interfaces;
using Timer = System.Timers.Timer;
using System.Timers;
using LoudPhone.Services;

namespace LoudPhone
{
    [Service]
    public class SilentModeService : Service
    {
        private Timer _timer;
        
        private IAudioManagerService _audioManagerService;
        private IDefaultSettings _defaultSettings;
        private DatabaseService _databaseService;
        public TimeSpan TimeLeft { private set; get; }
        public bool IsSilent { private set; get; }

        public async override void OnCreate()
        {
            base.OnCreate();
            _audioManagerService = new AudioManagerService();
            _databaseService = new DatabaseService();
            _defaultSettings = new DefaultSettings(_databaseService);
            var defaultTime = await _defaultSettings.GetDefaultSilentIntervalAsync();
            TimeLeft = TimeSpan.FromMinutes(defaultTime);
            _timer = new Timer(1000);
            _timer.Elapsed += OnTimedEvent;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            _timer.Start();
            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _timer.Stop();
            _timer.Dispose();
            base.OnDestroy();
        }

        private async void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (_audioManagerService.IsSilent())
            {
                if (!IsSilent)
                {
                    var defaultTime = await _defaultSettings.GetDefaultSilentIntervalAsync();
                    TimeLeft = TimeSpan.FromMinutes(defaultTime);
                    IsSilent = true;
                }
            }
            else
                IsSilent = false;

            if (IsSilent)
            {
                if (TimeLeft.TotalSeconds > 0)
                {
                    TimeLeft = TimeLeft.Add(TimeSpan.FromSeconds(-1));
                }
                else
                {
                    _audioManagerService.SetSilent(false);
                }

            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}
