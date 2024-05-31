using LoudPhone.Models;

namespace LoudPhone.Interfaces
{
    public interface IDefaultSettings
    {
        Task<int> GetDefaultSilentIntervalAsync();
        Task SetDefaultSilentIntervalAsync(int interval);

        Task<IEnumerable<Todo>> GetSettingsAsync();

        Task AddSettingsAsync(Todo todo);

        Task RemoveTodoAsync(Todo todo);
    }
}
