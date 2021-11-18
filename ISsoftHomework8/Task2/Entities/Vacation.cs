using System;

namespace Task2.Entities
{
    public class Vacation : Entity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int Length => (EndDate - StartDate).Days + 1;
    }
}
