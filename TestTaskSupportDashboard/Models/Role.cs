using System.Collections.Generic;

namespace TestTaskSupportDashboard.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SupportOperator> Operators { get; set; }
        public Role()
        {
            Operators = new List<SupportOperator>();
        }
    }
}
