using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using LoudPhone.Interfaces;

[assembly: Dependency(typeof(LoudPhone.AudioManagerService))]
namespace LoudPhone
{
    public class AudioManagerService : IAudioManagerService
    {

        private const string ChannelId = "silent_mode_channel";
        private const string ChannelName = "Silent Mode Notifications";
        private const int NotificationId = 1000;

        public AudioManagerService()
        {
            CreateNotificationChannel();
        }

        public bool IsSilent()
        {
            var audioManager = (AudioManager?)MauiApplication.Current.GetSystemService(Context.AudioService);
            return audioManager?.RingerMode == RingerMode.Silent || audioManager?.RingerMode == RingerMode.Vibrate;
        }

        public void SetSilent(bool silent)
        {
            var audioManager = (AudioManager?)MauiApplication.Current.GetSystemService(Context.AudioService);
            if (audioManager != null)
            {
                if (silent)
                {
                    audioManager.RingerMode = RingerMode.Silent;
                    ShowNotification("Modo Silencioso Ativado", "Seu telefone está no modo silencioso.");
                }
                else
                {
                    audioManager.RingerMode = RingerMode.Normal;
                    ShowNotification("Modo Silencioso Desativado", "Seu telefone saiu do modo silencioso.");
                }
            }
        }

        private static void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(ChannelId, ChannelName, NotificationImportance.Default)
                {
                    Description = "Notificações para mudanças no modo silencioso"
                };
                var notificationManager = (NotificationManager)MauiApplication.Current.GetSystemService(Context.NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        private void ShowNotification(string title, string message)
        {
            var notificationManager = (NotificationManager)MauiApplication.Current.GetSystemService(Context.NotificationService);

            var notificationBuilder = new Notification.Builder(MauiApplication.Current)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.dotnet_bot)
                .SetAutoCancel(true);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                notificationBuilder.SetChannelId(ChannelId);
            }

            notificationManager.Notify(NotificationId, notificationBuilder.Build());
        }
    }
}
