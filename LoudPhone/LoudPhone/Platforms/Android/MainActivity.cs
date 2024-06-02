using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using LoudPhone.Interfaces;

namespace LoudPhone
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize
            | ConfigChanges.Orientation
            | ConfigChanges.UiMode
            | ConfigChanges.ScreenLayout
            | ConfigChanges.SmallestScreenSize
            | ConfigChanges.Density
    )]
    public class MainActivity : MauiAppCompatActivity, ISilentModeDaemon
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    
        public void StartSilentModeService()
        {            
            var intent = new Intent(Platform.CurrentActivity, typeof(SilentModeService));
            Platform.CurrentActivity.StartService(intent);            
        }

        public void StopSilentModeService()
        {
            var intent = new Intent(Platform.CurrentActivity, typeof(SilentModeService));
            Platform.CurrentActivity.StopService(intent);
        }
    }
}
