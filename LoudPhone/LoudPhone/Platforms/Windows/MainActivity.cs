using LoudPhone.Interfaces;


[assembly: Dependency(typeof(LoudPhone.MainActivity))]
namespace LoudPhone
{
    public class MainActivity : ISilentModeDaemon
    {
        public void StartSilentModeService()
        {
            throw new NotImplementedException();
        }

        public void StopSilentModeService()
        {
            throw new NotImplementedException();
        }
    }
}
