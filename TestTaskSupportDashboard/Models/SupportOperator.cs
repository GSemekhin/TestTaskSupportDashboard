using TestTaskSupportDashboard.Enums;
using System.ComponentModel.DataAnnotations;

namespace TestTaskSupportDashboard.Models
{
    public class SupportOperator
    {
        public string Name { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
