using System;

namespace Task3
{
    public class Vacation
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Vacation(string name, DateTime vacationStart, DateTime vacationEnd)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name should be not null or empty");
            }

            Name = name;
            StartDate = vacationStart;
            EndDate = vacationEnd;
        }

        public override string ToString() => $"Name: {Name}\nVacation started: {StartDate}\nVacation ended: {EndDate}";
    }
}