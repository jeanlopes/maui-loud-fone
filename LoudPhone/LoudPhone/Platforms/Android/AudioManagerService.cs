using Android.Content;
using Android.Media;
using LoudPhone.Interfaces;

[assembly: Dependency(typeof(LoudPhone.AudioManagerService))]
namespace LoudPhone
{
    public class AudioManagerService : IAudioManagerService
    {
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
                }
                else
                {
                    audioManager.RingerMode = RingerMode.Normal;
                }
            }
        }
    }
}
