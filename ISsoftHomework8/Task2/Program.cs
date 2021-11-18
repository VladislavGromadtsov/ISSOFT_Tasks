using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = GetContext();

            var dl = new DataLoader(context);
            dl.LoadTrainings();

            var s = new Statistics(context);
            foreach (var item in s.GetPeopleWithLongVacation())
            {
                Console.WriteLine(item.Name + " " + item.Surname);
            }

            Console.WriteLine(s.GetPeopleNumber(new Guid("C12C49AB-1BD0-4EC6-AB35-1DE1566C670D")));
            Console.WriteLine(s.GetPeopleNumber(new Guid("0E1257D6-9661-4D54-9C30-E924B4CF1B72")));
        }

        private static CompanyContext GetContext()
        {
            var connection = ConfigurationManager.AppSettings["DefaultConnection"];

            var optionsBuilder = new DbContextOptionsBuilder();
            var options = optionsBuilder.UseSqlServer(connection).Options;
            return new CompanyContext(options);
        }
    }
}
