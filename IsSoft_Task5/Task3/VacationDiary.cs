using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class VacationDiary
    {
        private readonly List<Vacation> _vocations;

        public VacationDiary()
        {
            _vocations = new List<Vacation>();
        }

        public void AddVocation(Vacation vacation)
        {
            _ = vacation ?? throw new ArgumentNullException(nameof(vacation));
            _vocations.Add(vacation);
        }

        public double GetAverageVacationTime() =>
            _vocations.Count == 0 ? _vocations.Average(el => (el.EndDate - el.StartDate).TotalDays) : 0;

        public IEnumerable<(string, double)> GetAverageVacationForPersons()
        {
            if (_vocations.Count == 0)
            {
                throw new ArgumentException("There are no people in diary");
            }

            return _vocations.GroupBy(i => i.Name).Select(i =>
                (i.Key.ToString(), i.Average(el => (el.EndDate - el.StartDate).TotalDays)));
        }

        public IEnumerable<(int, int)> GetVacationByMonth()
        {
            return Enumerable.Range(1, 12)
                .Select(el => (el, _vocations.Count(i => el <= i.EndDate.Month && el >= i.StartDate.Month && (i.EndDate - i.StartDate).TotalDays >= 1)));
        }

        public IEnumerable<DateTime> GetNonVacationDates()
        {
            return GetDays(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1)).Where(d => _vocations.All(v => (d > v.EndDate || d < v.StartDate)));
        }

        private IEnumerable<DateTime> GetDays(DateTime from, DateTime to)
        {
            for (var i = from; i < to; i = i.AddDays(1))
            {
                yield return i;
            }
        }
        public bool CheckVacationsIntersection()
        {
            return _vocations.GroupBy(v => v.Name)
                .Select(g => (g.First(), g.Skip(1)))
                .Any(v => v.Item2.Any(e => IsIntersection((v.Item1.StartDate, v.Item1.EndDate), (e.StartDate, e.EndDate))));

        }
        private bool IsIntersection((DateTime start, DateTime end) first, (DateTime start, DateTime end) second)
        {
            return first.start <= second.end && second.start <= first.end;
        }
    }
}