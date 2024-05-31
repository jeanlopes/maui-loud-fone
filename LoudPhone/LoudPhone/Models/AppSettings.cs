using SQLite;

namespace LoudPhone.Models
{
    public class AppSettings
    {
        [PrimaryKey]
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
