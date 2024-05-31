using SQLite;

namespace LoudPhone.Models
{
    public class Todo
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
