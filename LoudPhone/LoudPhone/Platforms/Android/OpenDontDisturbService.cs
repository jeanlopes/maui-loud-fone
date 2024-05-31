using Android.App;
using Android.Content;
using Android.OS;
using LoudPhone.Interfaces;

[assembly: Dependency(typeof(LoudPhone.AudioManagerService))]
namespace LoudPhone
{
    public class OpenDontDisturbService : IOpenDontDisturbService
    {

        public void OpenDoNotDisturbSettings()
        {
            var notificationManager = (NotificationManager)Platform.CurrentActivity.GetSystemService(Context.NotificationService);
            if (notificationManager.IsNotificationPolicyAccessGranted)
            {
                var intent = new Intent(Android.Provider.Settings.ActionNotificationPolicyAccessSettings);
                Platform.CurrentActivity.StartActivity(intent);
            }
        }
    }
}
