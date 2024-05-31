namespace LoudPhone.Interfaces
{
    public interface IDefaultSettings
    {
        Task<int> GetDefaultSilentIntervalAsync();
        Task SetDefaultSilentIntervalAsync(int interval);
    }
}
