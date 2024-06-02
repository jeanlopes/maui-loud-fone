using LoudPhone.Models;

namespace LoudPhone.Interfaces
{
    public interface IDatabaseService
    {
        int SaveSettings(Todo todo);

        IEnumerable<Todo> GetSetting();

        int GetLastInserted();

        int SaveSetting(AppSettings setting);

        AppSettings GetSetting(string key);

        void RemoveSettings(Todo todo);
    }
}
