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
    public class SilentModeService : Service, ISilentModeService
    {
        private Timer _timer;
        
        private IAudioManagerService _audioManagerService;
        private ISilentIntervalService _silentIntervalService;
        private IDefaultSettings _defaultSettings;
        private IDatabaseService _databaseService;
        public TimeSpan TimeLeft { private set; get; }
        public bool IsSilent { private set; get; }
        private bool ItWasOnSilentInterval { get; set; }

        public SilentModeService()
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            var serviceProvider = MauiApplication.Current.Services;
            _audioManagerService = serviceProvider.GetRequiredService<IAudioManagerService>();
            _databaseService = serviceProvider.GetRequiredService<IDatabaseService>();
            _defaultSettings = serviceProvider.GetRequiredService<IDefaultSettings>();
            _silentIntervalService = serviceProvider.GetRequiredService<ISilentIntervalService>();

            InitializeService();
        }

        private void InitializeService()
        {
            
            var defaultTime = _defaultSettings.GetDefaultSilentInterval();
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

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (_silentIntervalService.IsOnSilentInterval() && !IsSilent)
            {
                _audioManagerService.SetSilent(true);
                IsSilent = true;
                ItWasOnSilentInterval = true;
                return;
            }

            if (ItWasOnSilentInterval)
            {
                _audioManagerService.SetSilent(false);
                ItWasOnSilentInterval = false;
            }

            if (_audioManagerService.IsSilent())
            {
                if (!IsSilent)
                {
                    var defaultTime = _defaultSettings.GetDefaultSilentInterval();
                    TimeLeft = TimeSpan.FromMinutes(defaultTime);
                    IsSilent = true;
                }

                if (TimeLeft.TotalSeconds > 0)
                {
                    TimeLeft = TimeLeft.Add(TimeSpan.FromSeconds(-1));
                }
                else
                {
                    _audioManagerService.SetSilent(false);
                    IsSilent = false;
                }
            }
            else
            {
                IsSilent = false;
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

    }
}
