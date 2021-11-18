using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Task2
{
    public class DataLoader
    {
        private readonly CompanyContext _context;

        public DataLoader(CompanyContext context) => _context = context;

        public void LoadTrainings()
        {
            var trainings = _context.Trainings.ToList();
            foreach (var employee in _context.Employees.Include(x => x.Vacations).Include(x => x.Trainings))
            {
                foreach (var training in trainings)
                {
                    var intersect = false;
                    foreach (var vacation in employee.Vacations)
                    {
                        if (intersect = AreDatesIntersect(training.StartDate, training.EndDate, vacation.StartDate, vacation.EndDate))
                        {
                            break;
                        }
                    }

                    if (!intersect)
                    {
                        employee.Trainings.Add(training);   
                    }
                }
            }

            _context.SaveChanges();
        }

        private bool AreDatesIntersect(DateTime start1, DateTime end1, DateTime start2, DateTime end2) =>
            Math.Max(start1.Ticks, start2.Ticks) <= Math.Min(end1.Ticks, end2.Ticks);
    }
}
