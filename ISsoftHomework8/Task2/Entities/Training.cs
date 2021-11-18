using System;
using System.Collections.Generic;

namespace Task2.Entities
{
    public class Training : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Training() => Employees = new HashSet<Employee>();
    }
}
