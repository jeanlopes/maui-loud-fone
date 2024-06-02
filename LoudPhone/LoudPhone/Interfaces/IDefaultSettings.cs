using LoudPhone.Models;

namespace LoudPhone.Interfaces
{
    public interface IDefaultSettings
    {
        int GetDefaultSilentInterval();
        void SetDefaultSilentInterval(int interval);

        IEnumerable<Todo> GetSettings();

        void AddSettings(Todo todo);

        void RemoveTodo(Todo todo);
    }
}
