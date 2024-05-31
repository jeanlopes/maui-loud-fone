using LoudPhone.Interfaces;

[assembly: Dependency(typeof(LoudPhone.AudioManagerService))]
namespace LoudPhone
{
    public class AudioManagerService : IAudioManagerService
    {
        public bool IsSilent()
        {
            return false;
        }

        public void SetSilent(bool silent)
        {
            
        }
    }
}
