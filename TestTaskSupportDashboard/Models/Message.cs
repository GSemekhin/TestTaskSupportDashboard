using TestTaskSupportDashboard.Enums;
using System;

namespace TestTaskSupportDashboard.Models
{
    public class Message
    {
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
        public SenderType Type { get; set; }
        public string ChatId { get; set; }
        public Guid Id { get; set; }
    }
}
