using LoudPhone.Interfaces;

[assembly: Dependency(typeof(LoudPhone.AudioManagerService))]
namespace LoudPhone
{
    public class OpenDontDisturbService : IOpenDontDisturbService
    {
        public void OpenDoNotDisturbSettings()
        {
            throw new NotImplementedException();
        }
    }
}
