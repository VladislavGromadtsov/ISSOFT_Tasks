using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Entities;

namespace Task2
{
    public class Statistics
    {
        private readonly CompanyContext _context;

        public Statistics(CompanyContext context) => _context = context;

        public IEnumerable<Employee> GetPeopleWithLongVacation()
        {
            var items = _context.Vacations.AsEnumerable().Where(x => x.Length > 30).ToList();
            var employees = new HashSet<Employee>();
            foreach (var item in items)
            {
                _context.Entry(item).Reference(x => x.Employee).Load();
                employees.Add(item.Employee);
            }

            return employees;
        }

        public int GetPeopleNumber(Guid trainingId) => _context.Set<EmployeeTraining>().Where(x => x.TrainingId == trainingId).Count();
    }
}
