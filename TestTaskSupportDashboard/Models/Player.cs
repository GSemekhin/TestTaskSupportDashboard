using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskSupportDashboard.Models
{
    public class Player
    {
        [Key]
        public Guid Token { get; set; }
        [StringLength(16)]
        public string Nickname { get; set; }
    }
}
