using System;
using System.Collections.Generic;

namespace Task2.Entities
{
    public class Employee : Entity<Guid>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Vacation> Vacations { get; set; }
        public ICollection<Training> Trainings { get; set; }

        public Employee() => (Vacations, Trainings) = (new HashSet<Vacation>(), new HashSet<Training>());
    }
}
