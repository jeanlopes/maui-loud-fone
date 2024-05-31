namespace LoudPhone.Interfaces
{
    public interface IAudioManagerService
    {
        bool IsSilent();
        void SetSilent(bool silent);
    }
}
